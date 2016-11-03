using UnityEngine;
using System.Collections;
using PrefabsCache;

public class TargetSpawner : MonoBehaviour 
{
	public static float Timeout
	{
		get;
		set;
	}

	public static event System.Action GameOver;

	private float duration = 30f;

	void Start () 
	{
		Timeout = duration;
		Spawn();
		Invoke("Spawn", 2f);
	}

	void Update()
	{
		if(Timeout > 0f)
			Timeout -= Time.deltaTime;
		else
			Timeout = 0f;
	}

	void Spawn() 
	{
		if(Target.Counter < 25)
		{
			Vector3 rand = new Vector3(Random.Range(-4f,4f), Random.Range(-4f,4f), 0);

			GameObject target = (Random.Range(0,3) == 0 ? Prefab.Cat.GetInstance(rand) : Prefab.Troll.GetInstance(rand));

			Prefab.FreeInstance(target, 10f);
		}

		float targetTime = 2f + Random.Range(-0.5f, 0.2f);
		if(Timeout - targetTime > 0f)
			Invoke("Spawn", targetTime);
		else
		{
			if(GameOver != null)
				GameOver();
		}
	}
}

