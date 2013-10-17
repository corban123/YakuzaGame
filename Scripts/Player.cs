//Rakan's Character Controller 
﻿using UnityEngine;
using System.Collections;


public class Player : Char
{


	public AudioClip jumping;
	public AudioClip Walk;
	public AudioClip Punch;
	public int maxHealth = 30;
	public int curHealth = 30;
	public GameObject target;
    public Vector3 MoveVector { get; set; }
    public float VerticalVelocity { get; set; }
	
	
	private double deadZone = .10;
	public GameObject Fist;

	
	

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


        //Again, Defining Directions
        if (Input.GetKey(KeyCode.A))
        {
            isLeft = true;
            facingDir = 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            isRight = true;
            facingDir = 2;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            isUp = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            isDown = true;
        }
        if (Input.GetKey(KeyCode.J) && CharacterController.isGrounded)
        {
            isPunch = true;
            Fist.SetActive(true);
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
		if (Input.GetKey (KeyCode.Alpha3)){
			isSword = false;
			isFist = false;
			isGun = true;
		}
	
	
		
		//Sounds!
        if (isLeft && CharacterController.isGrounded || isRight && CharacterController.isGrounded)
        {
			if (audio.clip != Walk){
				audio.Stop ();
				audio.clip = Walk;
			}
			if (!audio.isPlaying){
				audio.Play();
			}
		}
        else if (isUp)
        {
			if(audio.clip != jumping){
				audio.Stop ();
				audio.clip = jumping;
			}
			if (!audio.isPlaying){
				audio.Play ();
			}
            if (!CharacterController.isGrounded)
                audio.Play();
		}
		
		else if (isPunch && isFist == true){
			if( audio.clip != Punch){
				audio.Stop();
				audio.clip = Punch;
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
	void OnTriggerEnter(Collider katana){
		Destroy(katana.gameObject);
		Katana = 1;
	}

}
// CharacterControllers are stupid. 