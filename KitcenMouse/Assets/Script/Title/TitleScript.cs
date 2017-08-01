using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0)) {
			Application.LoadLevel ("Game");
		}
		if (Input.GetKey(KeyCode.Joystick1Button0)) {
			Application.LoadLevel ("Game");
		}
		if (Input.GetKey(KeyCode.Joystick1Button1)) {
			Application.LoadLevel ("Game");
		}
		if (Input.GetKey(KeyCode.Joystick1Button2)) {
			Application.LoadLevel ("Game");
		}
		if (Input.GetKey(KeyCode.Joystick1Button3)) {
			Application.LoadLevel ("Game");
		}
		if (Input.GetKey(KeyCode.Joystick1Button4)) {
			Application.LoadLevel ("Game");
		}
		if (Input.GetKey(KeyCode.Joystick1Button5)) {
			Application.LoadLevel ("Game");
		}
		if (Input.GetKey(KeyCode.Joystick1Button6)) {
			Application.LoadLevel ("Game");
		}
		if (Input.GetKey(KeyCode.Joystick1Button7)) {
			Application.LoadLevel ("Game");
		}
		if (Input.GetKey(KeyCode.Joystick1Button8)) {
			Application.LoadLevel ("Game");
		}
		if (Input.GetKey(KeyCode.Joystick1Button9)) {
			Application.LoadLevel ("Game");
		}
	}
}
