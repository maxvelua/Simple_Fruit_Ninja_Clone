using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Fruit : MonoBehaviour {

	private int scoreNumber;

	public GameObject sliceEffect;
	public Text scoreText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){
			SliceFruit();
		}
	}

	public void SliceFruit(){
		GameObject effect = Instantiate(sliceEffect, transform.position, Quaternion.identity);
		Destroy(effect, 0.5f);
		Destroy(gameObject);
	}

	private void OnTriggerEnter2D(Collider2D other) {
		Blade blade = other.GetComponent<Blade>();

		if(!blade){
			return;
		} else if (!blade && scoreNumber > 0){
			scoreNumber--;
			scoreText.text = scoreNumber.ToString();
		} else if (blade){
			scoreNumber++;
			scoreText.text = scoreNumber.ToString();
			SliceFruit();
		}
	}
}
