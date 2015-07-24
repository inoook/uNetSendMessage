using UnityEngine;
using System.Collections;

public class TestB : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void Update()
	{

	}

	public void ChangeColor(string colorStr)
	{
		this.GetComponent<Renderer>().material.color = UnetAction.StringToColor(colorStr);
	}

}
