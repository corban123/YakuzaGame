using UnityEngine;
using System.Collections;


public class Instructions : MonoBehaviour {
	
	public GUIText referencetotext;
 
void OnTriggerEnter(Collider hit){
    if(hit.gameObject.tag == "Trigger1"){
		referencetotext.text ="USE W,A,S,D TO MOVE";
	}
	if(hit.gameObject.tag == "Trigger2"){
		referencetotext.text ="PRESS J TO PUNCH THE BOX";
	}
	if(hit.gameObject.tag == "Trigger3"){
		referencetotext.text ="PRESS 2 TO PULL OUT YOUR SWORD";
	}	
 	if(hit.gameObject.tag == "Trigger4"){
		referencetotext.text ="PRESS J TO SLASH";
	}
	if(hit.gameObject.tag == "Trigger5"){
		referencetotext.text ="PRESS J TO SHOOT";
	}
	if(hit.gameObject.tag == "Trigger6"){
		referencetotext.text ="CHECKPOINT";
	}
}
void OnTriggerExit(Collider hit){
    referencetotext.text ="";
}
}
