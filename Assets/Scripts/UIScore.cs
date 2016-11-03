using UnityEngine;
using System.Collections;

public class UIScore : MonoBehaviour 
{
	public static int score = 0;
	private GUIText ui;

	void Start()
	{
		ui = GetComponent<GUIText>();
	}

	void Update () 
	{
		ui.text = "Score: " + score;
	}
}
