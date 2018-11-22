using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour {

	private Rigidbody2D rd;

	// Use this for initialization
	void Awake(){
		rd = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {
		SetBladeToMouse();
	}

	private void SetBladeToMouse(){
		var mousePos = Input.mousePosition;
		mousePos.z = 5;

		rd.position = Camera.main.ScreenToWorldPoint(mousePos);
	}
}
