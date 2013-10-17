using UnityEngine;
using System.Collections;



public class PlayerAnims: MonoBehaviour {

    private Char character;
    private tk2dSpriteAnimator anim;
	public CharacterController CharacterController;

    void Awake()
    {
        anim = GetComponent<tk2dSpriteAnimator>();
	    CharacterController = gameObject.GetComponent("CharacterController")
        as CharacterController;

    }
	// Use this for initialization
	void Start () {
        character = GetComponent<Char>();
	
	}
	
	// Update is called once per frame
	void Update () {

        if (character.isFist == true  && character.isSword == false){
			if(character.isLeft && CharacterController.isGrounded){
				if(!anim.IsPlaying("Fist walk 1")){
					anim.Play("Fist walk 1");
					anim.AnimationCompleted = null;
				
				}

			}

			if(character.isRight && CharacterController.isGrounded){
				if(!anim.IsPlaying("Fist walk 2")){
					anim.Play("Fist walk 2");
					anim.AnimationCompleted = null;
				
				
				}		
			}

		
			if(character.isUp && character.facingDir == 2){ 
                    if (!anim.IsPlaying("Fist Jump 2")){
					    anim.Play("Fist Jump 2");}
                
        }
                
				
				

            if (character.isUp && character.facingDir == 1)
            {
                    if (!anim.IsPlaying("Fist Jump 1"))
                    {
                        anim.Play("Fist Jump 1");

                    }
                    
                }
            
		
			if(character.isPunch && character.facingDir == 2){
				if(!anim.IsPlaying("Fist Punch 1")){
				anim.Play ("Fist Punch 1");
		
				
				}
			}
			if (character.isPunch && character.facingDir == 1){
				if(!anim.IsPlaying ("Fist Punch 2")){
				anim.Play ("Fist Punch 2");


			
    			}
			}
		}
		else if (character.isSword == true && character.isFist == false){
			if(character.isLeft && CharacterController.isGrounded){
				if(!anim.IsPlaying("Sword Walk left")){
					anim.Play("Sword Walk left");
					anim.AnimationCompleted = null;
				
			
				}

			}

			if(character.isRight && CharacterController.isGrounded){
				if(!anim.IsPlaying("Sword walk right")){
					anim.Play("Sword walk right");
					anim.AnimationCompleted = null;
				
				
				}		
			}

		
			if(character.isUp && character.facingDir == 2){
				if (!anim.IsPlaying("Sword Jump Right") && !CharacterController.isGrounded){
					anim.Play("Sword Jump Right");

				}
				else if (CharacterController.isGrounded){
					anim.Stop();
				}
			}
			if(character.isUp && character.facingDir == 1){
				if(!anim.IsPlaying ("Sword Jump Left") && !CharacterController.isGrounded){
					anim.Play("Sword Jump Left");
				
				}
			}
		}
		else if (character.isGun == true && character.isSword == false && character.isFist == false){
			if(character.isLeft && CharacterController.isGrounded){
				if(!anim.IsPlaying("Gun walk left")){
					anim.Play("Gun walk left");
					anim.AnimationCompleted = null;
				
			
				}

			}

			if(character.isRight && CharacterController.isGrounded){
				if(!anim.IsPlaying("Gun walk right")){
					anim.Play("Gun walk right");
					anim.AnimationCompleted = null;
				
				
				}		
			}

		
			if(character.isUp && character.facingDir == 2){
				if (!anim.IsPlaying("Gun jump right") && !CharacterController.isGrounded){
					anim.Play("Gun jump right");

				}
				else if (CharacterController.isGrounded){
					anim.Stop();
				}
			}
			if(character.isUp && character.facingDir == 1){
				if(!anim.IsPlaying ("Gun jump left") && !CharacterController.isGrounded){
					anim.Play("Gun jump left");
				
				}
			}
		}
	}
}
			
					
		
		
		
	
	


