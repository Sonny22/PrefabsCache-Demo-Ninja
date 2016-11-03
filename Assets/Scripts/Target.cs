using UnityEngine;
using System.Collections;
using PrefabsCache;

public class Target : MonoBehaviour 
{
	public static int Counter = 0;

	public Prefab hitVFXPrefab;

	public int hitPoint = 1;

	public float speed = 2f;

	private Vector3 direction;

	void OnEnable()
	{
		Counter++;
		direction = RandomDirection();
	}

	void Update()
	{
		transform.position += speed * Time.deltaTime * direction;
	}

	void OnDisable()
	{
		Counter--;
	}

	Vector3 RandomDirection()
	{
		int r = Random.Range(0,9);

		switch(r)
		{
		case 0:
			return Vector3.zero;
		case 1:
			return Vector3.left;
		case 2:
			return Vector3.left + Vector3.up;
		case 3:
			return Vector3.up;
		case 4:
			return Vector3.right + Vector3.up;
		case 5:
			return Vector3.right;
		case 6:
			return Vector3.right + Vector3.down;
		case 7:
			return Vector3.down;
		case 8:
			return Vector3.left + Vector3.down;
		}

		return Vector3.zero;
	}

	void OnCollisionEnter(Collision collision)
	{
		Prefab.FreeInstance(gameObject);

		if(hitVFXPrefab != Prefab.None)
		{
			GameObject hit = hitVFXPrefab.GetInstance(collision.contacts[0].point);
			Prefab.FreeInstance(hit, 1f);
		}

		UIScore.score += hitPoint;
	}
}
