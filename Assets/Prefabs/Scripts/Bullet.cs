using UnityEngine;
using System.Collections;

public class Bullet : Char {

	// Use this for initialization
	void Start () {
	
	}
	void Awake () {
		if(facingDir == 1){
			transform.Translate(Vector3.right * bulletSpeed*Time.deltaTime); 
		}
		if (facingDir == 2){
			transform.Translate(Vector3.left * bulletSpeed*Time.deltaTime); 
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
