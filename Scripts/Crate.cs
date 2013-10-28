using UnityEngine;
using System.Collections;

public class Crate : MonoBehaviour {
	public GameObject item;
	private tk2dSpriteAnimator anim;
	private bool broken = false;
	


	void Awake (){
		anim = GetComponent<tk2dSpriteAnimator>();
		item.SetActive(false);
	}
	// Update is called once per frame
	void Update () {

	
	}
	 void OnTriggerEnter(Collider weapon){
		if(weapon.gameObject.tag == "slash" || weapon.gameObject.tag == "bullet" || weapon.gameObject.tag == "Fist" && broken == false){
			anim.Play("Break");
			item.SetActive(true);
			collider.enabled = false;
			broken = true;
		}
	}
}