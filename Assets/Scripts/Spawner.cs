using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject[] fruitsToSpawn;
	public Transform[] spawnPlaces;
	public float minDelay = 0.3f;
	public float maxDelay = 1f;

	// Use this for initialization
	void Start () {
		StartCoroutine(SpawnFruits());
	}
	
	private IEnumerator SpawnFruits(){
		while(true){
			// delay 
			yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
			
			// random rotation to spawn position
			// shit solution
			for(int i = 0; i < spawnPlaces.Length; i++){
				if(i == 0){
					spawnPlaces[0].transform.Rotate(0, 0, Random.Range(30, 50));
				} else if (i == 1){
					spawnPlaces[0].transform.Rotate(0, 0, Random.Range(0, 15));
				} else {
					spawnPlaces[0].transform.Rotate(0, 0, Random.Range(-30, -60));
				}				
			}

			// get a random spawn palce
			Transform t  = spawnPlaces[Random.Range(0, spawnPlaces.Length)];

			// spawn a random fruit
			GameObject fruit = Instantiate(
				fruitsToSpawn[Random.Range(0, fruitsToSpawn.Length)],
			 	t.position, 
				t.rotation);

			// rotation and force
			fruit.GetComponent<Rigidbody2D>().AddForce(-t.transform.up * 2, ForceMode2D.Impulse);
		
			Destroy(fruit, 7);	
		}
	}
}
