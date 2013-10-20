//Rakan's Character Controller 
﻿using UnityEngine;
using System.Collections;


public class Player : Char
{


	public AudioClip jumping;
	public AudioClip Walk;
	public AudioClip Punch;
	public AudioClip Swing;
	public int maxHealth = 30;
	public int curHealth = 30;
	public GameObject target;
    public Vector3 MoveVector { get; set; }
    public float VerticalVelocity { get; set; }
	
	
	private double deadZone = .10;
	public GameObject Fist;
	public GameObject Sword;
	private tk2dSpriteAnimator anim;

	
	

    public CharacterController CharacterController;
	
	
    // Use this for initialization
	
	public void AddjustCurrentHealth(int adj)
    {
        curHealth += adj;


        if (curHealth < 0)
        {
            curHealth = 0;
        }
        if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }
        if (maxHealth < 1)
        {
            maxHealth = 1;
        }
    }
	
    void Awake()
    {
		anim = GetComponent<tk2dSpriteAnimator>();
        CharacterController = gameObject.GetComponent("CharacterController")
        as CharacterController;

    }

    // Update is called once per frame
    void Update()
    {
        checkMovement();
        HandleActionInput();
        processMovement();


        isStand = false;
        isLeft = false;
        isRight = false;
        isUp = false;
        isDown = false;
        isPunch = false;
        Fist.SetActive(false);
		Sword.SetActive(false);
		


        //Again, Defining Directions
        if (isDown == false && isUp == false && isRight == false && isLeft == false && !anim.IsPlaying("Fist Punch 1") && !anim.IsPlaying("Fist Punch 2") && !anim.IsPlaying("Sword Swing left" ) && !anim.IsPlaying ("Sword Swing right")){
			isStand = true;
			isDown = false;
			isUp = false;
		}
		if (Input.GetAxis("Horizontal") < -deadZone)
        {
            isLeft = true;
            facingDir = 1;
			isStand = false;
        }
        if (Input.GetAxis("Horizontal") > deadZone)
        {
            isRight = true;
            facingDir = 2;
			isStand = false;
        }
        if (MoveVector.y < TerminalVelocity && Input.GetKeyDown(KeyCode.W))
        {
            isUp = true;
			isStand = false;
        }
        if (MoveVector.y < -1)
        {
            isDown = true;
			isUp = false;
			isStand = false;
        }
        if (Input.GetKeyDown(KeyCode.J) && CharacterController.isGrounded)
        {
            isPunch = true;
			isStand = false;
        }
        if (Input.GetKey(KeyCode.Alpha1))
        {
            isFist = true;
            isSword = false;
        }
        if (Input.GetKey(KeyCode.Alpha2) && Katana == 1)
        {
            isSword = true;
            isFist = false;
        }
		if (Input.GetKey (KeyCode.Alpha3) && Gun == 1){
			isSword = false;
			isFist = false;
			isGun = true;
		}
	
	
		
		//Sounds!
        if (anim.IsPlaying("Fist walk 2") || anim.IsPlaying("Fist walk 1") || anim.IsPlaying ("Sword Walk left") || anim.IsPlaying ("Sword walk right") || anim.IsPlaying("Gun walk left") || anim.IsPlaying("Gun walk right"))
        {
			
			if (audio.clip != Walk){
				audio.Stop ();
				audio.clip = Walk;
				audio.volume = .5f;
				audio.pitch = .5f;
			}
			if (!audio.isPlaying){
				audio.Play();
			}
		}
        else if (anim.IsPlaying("Fist Jump 2") || anim.IsPlaying("Fist Jump 1") || anim.IsPlaying ("Sword Jump Left") || anim.IsPlaying("Sword Jump Right") || anim.IsPlaying("Gun jump left") || anim.IsPlaying("Gun jump right"))
        {
			if(audio.clip != jumping){
				audio.Stop ();
				audio.clip = jumping;
				audio.volume = .8f;
				audio.pitch = .5f;
			}
			if (!audio.isPlaying){
				audio.Stop ();
				audio.Play();
			}
		}
		
		else if (anim.IsPlaying("Fist Punch 1")  && isLeft == false|| anim.IsPlaying("Fist Punch 2") && isRight == false){
			Fist.SetActive(true);
			if( audio.clip != Punch){
				audio.Stop();
				audio.clip = Punch;
				audio.volume = .8f;
				audio.pitch = .28f;
			}
			if(!audio.isPlaying){
				audio.Play();
			}
		}
		else if (anim.IsPlaying ("Sword Swing left")  && isLeft == false|| anim.IsPlaying("Sword Swing right") && isRight == false ){
			Sword.SetActive(true);
			if(audio.clip != Swing){
				audio.Stop ();
				audio.clip = Swing;
				audio.volume = .8f;
				audio.pitch = 1f;
			}
			if(!audio.isPlaying){
				audio.Play();
			}
		
		
		}
		else{
			audio.Stop ();
		}
	

    }
		
    void checkMovement()
    {
        //move l/r
        VerticalVelocity = MoveVector.y;
        MoveVector = Vector3.zero;
        if (Input.GetAxis("Horizontal") > deadZone || Input.GetAxis("Horizontal") < -deadZone)
        {
            MoveVector = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        }
        //jump

    }
	
		
	
    void HandleActionInput()
    {

        if (Input.GetKeyDown(KeyCode.W))
        {
            jump();
        
		}
    }

    void processMovement()
    {
        //transform moveVector into world-space relative to character rotation
        MoveVector = transform.TransformDirection(MoveVector);

        //normalize moveVector if magnitude > 1
        if (MoveVector.magnitude > 1)
        {
            MoveVector = Vector3.Normalize(MoveVector);
        }

        //multiply moveVector by moveSpeed
        MoveVector *= MoveSpeed;



        //reapply vertical velocity to moveVector.y
        MoveVector = new Vector3(MoveVector.x, VerticalVelocity, MoveVector.z);

        //apply gravity
        applyGravity();

        //move character in world-space
        CharacterController.Move(MoveVector * Time.deltaTime);
    }

    void applyGravity()
    {
        if (MoveVector.y >= -TerminalVelocity)
        {
            MoveVector = new Vector3(MoveVector.x, (MoveVector.y - Gravity * Time.deltaTime),
            MoveVector.z);
        }


        if (CharacterController.isGrounded && MoveVector.y < -1)
        {
            MoveVector = new Vector3(MoveVector.x, (-1), MoveVector.z);
        }
    }


    public void jump()
    {
        if (CharacterController.isGrounded)
        {
            VerticalVelocity = JumpSpeed;
        }

    }
	void OnTriggerEnter(Collider weapon){
		if(weapon.gameObject.tag == "katana"){
			Destroy(weapon.gameObject);
			Katana = 1;
		}
		if (weapon.gameObject.tag == "gun"){
		Destroy (weapon.gameObject);
		Gun = 1;
		}
	}

}
// CharacterControllers are stupid. 