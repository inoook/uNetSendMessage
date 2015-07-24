using UnityEngine;
using System.Collections;

public class TestA : MonoBehaviour {

	public Renderer render;
	// Use this for initialization
	void Start () {
		render = gameObject.GetComponent<Renderer>();
	}

	public void ToggleRenderer()
	{
		render.enabled = !render.enabled;
	}
	
	public void SetAngleY(float v)
	{
		this.transform.eulerAngles = new Vector3(0,v,0);
	}

}
