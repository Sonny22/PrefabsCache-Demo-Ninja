using UnityEngine;
using System.Collections;
using PrefabsCache;

public class AimAndThrowShuriken : MonoBehaviour 
{
	public float force = 35f;
	private GameObject currentShuriken;

	void Start()
	{
		Rearm();
	}
		
	void Update () 
	{
		if(currentShuriken == null)
		{
			// If I don't have a shuriken, but I clicked I rearm and shoot directly
			if (Input.GetMouseButtonDown(0))
				Rearm();

			// if not clicked, just do nothing
			else
				return;
		}

		// Aim the shuriken according to the mouse position
		Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
		Vector3 target = r.GetPoint(10f);
		currentShuriken.transform.LookAt(target);

		// If mouse clicked
		if (Input.GetMouseButtonDown(0))
		{
			// throw the shuriken
			Rigidbody shurikenRigibody = currentShuriken.GetComponent<Rigidbody>();
			shurikenRigibody.velocity = currentShuriken.transform.forward * force;
			shurikenRigibody.angularVelocity = currentShuriken.transform.up * force * 2f;

			// Automatically make the thrown shuriken to disappear after 2 seconds
			Prefab.FreeInstance(currentShuriken, 2f); 

			// Rearm, get a new shuriken 
			currentShuriken = null;
			Invoke("Rearm", 1f);
		}
	}

	void Rearm()
	{
		if(currentShuriken == null)
		{
			currentShuriken = Prefab.Shuriken.GetInstance(transform.position);
		}
	}
}
