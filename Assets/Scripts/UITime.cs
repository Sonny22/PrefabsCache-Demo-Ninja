using UnityEngine;
using System.Collections;

public class UITime : MonoBehaviour 
{
	private GUIText ui;

	void Start () 
	{
		ui = GetComponent<GUIText>();
	}

	void Update () 
	{
		ui.text = "Time: " + TargetSpawner.Timeout.ToString("0.");
	}
}
