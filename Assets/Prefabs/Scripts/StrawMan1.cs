using UnityEngine;
using System.Collections;

public class StrawMan1 : MonoBehaviour {
	private tk2dSpriteAnimator anim;
	
	
	// Use this for initialization
	void Start () {
			anim = GetComponent<tk2dSpriteAnimator>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider weapon){
		if(weapon.gameObject.tag == "slash" ){
			anim.Play("Break");
			collider.enabled = false;

		}
		if(weapon.gameObject.tag == "bullet" || weapon.gameObject.tag == "Fist"){
			anim.Play ("Nope");
		}
	}
}
