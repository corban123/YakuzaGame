using UnityEngine;
using System.Collections;

public class Strawman2: MonoBehaviour {
    private tk2dSpriteAnimator anim;


    // Use this for initialization
    void Start()
    {
        anim = GetComponent<tk2dSpriteAnimator>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider weapon)
    {
        if (weapon.gameObject.tag == "bullet" || weapon.gameObject.tag == "slash" || weapon.gameObject.tag == "Fist")
        {	
			if (weapon.gameObject.tag == "bullet"){
			Destroy(weapon.gameObject);
			}
            anim.Play("Break");
            collider.enabled = false;
        }
    }
    
}
