using UnityEngine;
using System.Collections;

public class UnetActionTest : MonoBehaviour {

	public UnetAction uNetAction;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public Color color;
	public float angleY;

	void OnGUI()
	{
		if( !uNetAction.isServer ){ return; }

		GUILayout.BeginArea(new Rect(10, 200, 200, 400));

		GUILayout.Label("Box");
		if(GUILayout.Button("ToggleRenderer")){
			uNetAction.SendNetMessage("Box", "ToggleRenderer", UnetAction.SendMode.All);
		}
		GUILayout.Label("angleY: "+angleY);
		angleY = GUILayout.HorizontalSlider(angleY, 0, 360);
		if(GUILayout.Button("RotateY")){
			uNetAction.SendNetMessageWithFloat("Box", "SetAngleY", angleY, UnetAction.SendMode.All);
		}

		GUILayout.Space(20);

		GUILayout.Label("Sphere");
		color = ColorSlider(color);
		color.a = 1.0f;
		GUI.color = color;
		string colorStr = UnetAction.ColorToString(color);
		GUILayout.Label(colorStr);
		GUI.color = Color.white;
		if(GUILayout.Button("ChangeColor")){
			uNetAction.SendNetMessageWithString("Sphere", "ChangeColor", colorStr, UnetAction.SendMode.All);
		}

		GUILayout.EndArea();
	}

	Color ColorSlider(Color c){
		float labelW = 20;

		GUILayout.BeginHorizontal();
		GUILayout.Label("R", GUILayout.Width(labelW));
		c.r = GUILayout.HorizontalSlider(c.r, 0, 1.0f);
		GUILayout.EndHorizontal();

		GUILayout.BeginHorizontal();
		GUILayout.Label("G", GUILayout.Width(labelW));
		c.g = GUILayout.HorizontalSlider(c.g, 0, 1.0f);
		GUILayout.EndHorizontal();

		GUILayout.BeginHorizontal();
		GUILayout.Label("B", GUILayout.Width(labelW));
		c.b = GUILayout.HorizontalSlider(c.b, 0, 1.0f);
		GUILayout.EndHorizontal();

		return c;
	}
}
