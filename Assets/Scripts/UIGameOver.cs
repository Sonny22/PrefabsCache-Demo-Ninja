using UnityEngine;
using System.Collections;

public class UIGameOver : MonoBehaviour 
{
	void Start () 
	{
		TargetSpawner.GameOver += GameOver;
		GetComponent<GUIText>().enabled = false;
	}

	void GameOver() 
	{
		GetComponent<GUIText>().enabled = true;
	}
}
