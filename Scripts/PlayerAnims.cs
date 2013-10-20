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
					character.isStand = false;
				
				}

			}

			if(character.isRight && CharacterController.isGrounded){
				if(!anim.IsPlaying("Fist walk 2")){
					anim.Play("Fist walk 2");
					anim.AnimationCompleted = null;
					character.isStand = false;

				
				}		
			}

		
			if(character.isUp && character.facingDir == 2){ 
                    if (!anim.IsPlaying("Fist Jump 2")){
					    anim.Play("Fist Jump 2");
						character.isStand = false;
					
				}
			
                
        }
			if(character.isDown && character.facingDir == 2){ 
                    if (!anim.IsPlaying("Fist fall 2")){
					    anim.Play("Fist fall 2");
						character.isStand = false;
				}
			
                
        }
			if(character.isDown && character.facingDir == 1){ 
                    if (!anim.IsPlaying("Fist fall 1")){
					    anim.Play("Fist fall 1");
						character.isStand = false;
				}
			
                
        }
        
			if(character.isStand && character.facingDir == 2 && CharacterController.isGrounded){
				if (!anim.IsPlaying("Fist Jump 2") || !anim.IsPlaying ("Fist fall 2")){
					anim.Play ("Fist idle 2");
				}
			}
			
			if(character.isStand && character.facingDir == 1 && CharacterController.isGrounded){

				if (!anim.IsPlaying("Fist Jump 1") || !anim.IsPlaying ("Fist fall 1") || !anim.IsPlaying("Fist Punch 2")){
					anim.Play ("Fist idle 1");
				}
			}
                
				
				

            if (character.isUp && character.facingDir == 1)
            {
                    if (!anim.IsPlaying("Fist Jump 1"))
                    {
                        anim.Play("Fist Jump 1");
						character.isStand = false;

                    }
                    
                }
            
		
			if(character.isPunch && character.facingDir == 2){
				if(!anim.IsPlaying("Fist Punch 1")){
					anim.Play ("Fist Punch 1");
			   		character.isPunch = true;
					character.isStand = false;
		
				
				}
				
				
			}
			if (character.isPunch && character.facingDir == 1){
				if(!anim.IsPlaying ("Fist Punch 2")){
				anim.Play ("Fist Punch 2");
				character.isStand = false;


			
    			}
			}
		}
		else if (character.isSword == true && character.isFist == false){
			if(character.isLeft && CharacterController.isGrounded){
				if(!anim.IsPlaying("Sword Walk left")){
					anim.Play("Sword Walk left");
					anim.AnimationCompleted = null;
					character.isStand = false;
			
				}

			}

			if(character.isRight && CharacterController.isGrounded){
				if(!anim.IsPlaying("Sword walk right")){
					anim.Play("Sword walk right");
					anim.AnimationCompleted = null;
					character.isStand = false;
				
				}		
			}

		
			if(character.isUp && character.facingDir == 2){
				if (!anim.IsPlaying("Sword Jump Right") && !CharacterController.isGrounded){
					anim.Play("Sword Jump Right");
					character.isStand = false;
				}
				else if (CharacterController.isGrounded){
					anim.Stop();
				}
			}
			if(character.isUp && character.facingDir == 1){
				if(!anim.IsPlaying ("Sword Jump Left") && !CharacterController.isGrounded){
					anim.Play("Sword Jump Left");
					character.isStand = false;
				
				}
			}
			if(character.isPunch && character.facingDir == 2){
				if(!anim.IsPlaying("Sword Swing right")){
					anim.Play ("Sword Swing right");
			   		character.isPunch = true;
					character.isStand = false;
		
				
				}
				
				
			}
			if (character.isPunch && character.facingDir == 1){
				if(!anim.IsPlaying ("Sword Swing left")){
				anim.Play ("Sword Swing left");
					character.isPunch = true;
					character.isStand = false;
					
				}
			}
			if(character.isStand && character.facingDir == 2 && CharacterController.isGrounded){
				if (!anim.IsPlaying("Sword Jump Right") || !anim.IsPlaying ("Sword Fall Right") || !anim.IsPlaying("Sword Swing right")){
					anim.Play ("Sword Idle right");
				}
			}
			
			if(character.isStand && character.facingDir == 1 && CharacterController.isGrounded){

				if (!anim.IsPlaying("Sword Walk left") || !anim.IsPlaying ("Sword Fall left") || !anim.IsPlaying("Sword Swing left")){
					anim.Play ("Sword Idle Left");
				}
			}

			if(character.isDown && character.facingDir == 2){ 
                    if (!anim.IsPlaying("Sword Fall Right")){
					    anim.Play("Sword Fall Right");
						character.isStand = false;
				}
			
                
        }
			if(character.isDown && character.facingDir == 1){ 
                    if (!anim.IsPlaying("Sword Fall Left")){
					    anim.Play("Sword Fall Left");
						character.isStand = false;
				}
			
                
        }
			
    			
			
		}
		else if (character.isGun == true && character.isSword == false && character.isFist == false){
			if(character.isLeft && CharacterController.isGrounded){
				if(!anim.IsPlaying("Gun walk left")){
					anim.Play("Gun walk left");
					anim.AnimationCompleted = null;
					character.isStand = false;
			
				}

			}

			if(character.isRight && CharacterController.isGrounded){
				if(!anim.IsPlaying("Gun walk right")){
					anim.Play("Gun walk right");
					anim.AnimationCompleted = null;
					character.isStand = false;
				
				}		
			}

		
			if(character.isUp && character.facingDir == 2){
				if (!anim.IsPlaying("Gun jump right") && !CharacterController.isGrounded){
					anim.Play("Gun jump right");
					character.isStand = false;
				}
				else if (CharacterController.isGrounded){
					anim.Stop();
				}
			}
			if(character.isUp && character.facingDir == 1){
				if(!anim.IsPlaying ("Gun jump left") && !CharacterController.isGrounded){
					anim.Play("Gun jump left");
					character.isStand = false;
				}
			}
			if(character.isStand && character.facingDir == 2 && CharacterController.isGrounded){
				if (!anim.IsPlaying("Gun jump right") || !anim.IsPlaying ("Gun fall right") || !anim.IsPlaying("Gun shoot right")){
					anim.Play ("Gun idle right");
					character.isStand = false;
				}
			}
			
			if(character.isStand && character.facingDir == 1 && CharacterController.isGrounded){

				if (!anim.IsPlaying("Gun walk left") || !anim.IsPlaying ("Gun fall left") || !anim.IsPlaying("Gun shoot left")){
					anim.Play ("Gun idle left");
					character.isStand = false;
				}
			}
			if(character.isDown && character.facingDir == 1){ 
                    if (!anim.IsPlaying("Gun fall left")){
					    anim.Play("Gun fall left");
						character.isStand = false;
				}
			
                
        }
			if(character.isDown && character.facingDir == 2){ 
                    if (!anim.IsPlaying("Gun fall right")){
					    anim.Play("Gun fall right");
						character.isStand = false;
				}
			
                
        }
		}
	}
}
			
					
		
		
		
	
	


