//Rakan's Character Controller 
﻿using UnityEngine;
using System.Collections;


public class Player : Char
{


	public AudioClip jumping;
	public AudioClip Walk;
	public AudioClip Punch;
	public AudioClip Swing;
    public AudioClip Shoot;
	public int maxHealth = 30;
	public int curHealth = 30;
    public int JumpAllowed = 1;
    public int JumpTimes = 0;
	public GameObject target;
    public Vector3 MoveVector { get; set; }
    public float VerticalVelocity { get; set; }
	public int BulletSpeed = 30;

	private double deadZone = .10;
	public GameObject Fist;
	public GameObject Sword;
	public Rigidbody Bullet;

	private tk2dSpriteAnimator anim;
	private Renderer bulletRenderer;
	private Vector3 spawnPoint;
	public GUIText referencetotext;
	
	
	//will's GUI stuff
	public int weapon = 1; //to let GUI know what weapon is currently selected
	public bool hasGun = false;
	public bool hasSword = false;
	
	

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
		if(curHealth <= 0){
			Destroy(this.gameObject);
			Application.LoadLevel("GameOver");
		}
    }
	
    void Awake()
    {
		anim = GetComponent<tk2dSpriteAnimator>();
        CharacterController = gameObject.GetComponent("CharacterController")
        as CharacterController;
        bulletRenderer = GameObject.FindGameObjectWithTag("bullet").renderer;

    }

    // Update is called once per frame
    void Update()
    {
        checkMovement();
        HandleActionInput();
        processMovement();
		
		if(curHealth <= 0){
			Destroy(this.gameObject);
			Application.LoadLevel("GameOver");
		}


        isStand = false;
        isLeft = false;
        isRight = false;
        isUp = false;
        isDown = false;
        isPunch = false;
        Fist.SetActive(false);
		Sword.SetActive(false);


        if (CharacterController.isGrounded)
        {
            JumpTimes = 0;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            JumpTimes++;
        }
		
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
			weapon = 1;
        }
        if (Input.GetKey(KeyCode.Alpha2) && Katana == 1)
        {
            isSword = true;
            isFist = false;
			weapon = 2;
        }
		if (Input.GetKey (KeyCode.Alpha3) && Gun == 1){
			isSword = false;
			isFist = false;
			isGun = true;
			weapon = 3;
		}
		if(Input.GetKeyDown(KeyCode.N)){
			curHealth -= 10;
		}
	
	
		
		//Sounds!
		#region Sounds
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
			if (JumpTimes <= JumpAllowed){
                if (audio.clip != jumping)
                {
                    audio.Stop();
                    audio.clip = jumping;
                    audio.volume = .8f;
                    audio.pitch = .5f;
                }
                if (!audio.isPlaying)
                {
                    audio.Stop();
                    audio.Play();
                }
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
		else if (anim.IsPlaying("Gun shoot right")){
            if (audio.clip != Shoot)
            {
                audio.Stop();
                audio.clip = Shoot;
                audio.volume = .8f;
                audio.pitch = .5f;
            }
            if (!audio.isPlaying)
            {
                audio.Play();
            }
            bulletRenderer.enabled = true;
			Rigidbody clone;
			clone = Instantiate(Bullet,transform.position + Vector3.right*2 + (Vector3.up/3) + (Vector3.up/20), Quaternion.Euler(0, 0, 0)) as Rigidbody;
			clone.velocity = transform.TransformDirection (Vector3.right * BulletSpeed);
			Destroy(clone.gameObject, 1);
			}
		else if (anim.IsPlaying ("Gun shoot left")){
            if (audio.clip != Shoot)
            {
                audio.Stop();
                audio.clip = Shoot;
                audio.volume = 1f;
                audio.pitch = .5f;
            }
            if (!audio.isPlaying)
            {
                audio.Play();
            }
            bulletRenderer.enabled = true;
            Rigidbody clone;
			clone = Instantiate(Bullet,transform.position + Vector3.left* 2 + (Vector3.up/3) + (Vector3.up/20), Quaternion.Euler(0, 0, 0)) as Rigidbody;
			clone.velocity = transform.TransformDirection (Vector3.left * BulletSpeed);
			Destroy(clone.gameObject, 1);
		}
	
		
		else{
			audio.Stop ();
		}
		#endregion

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
			hasSword = true;
		}
		if (weapon.gameObject.tag == "gun"){
			Destroy (weapon.gameObject);
			Gun = 1;
			hasGun = true;
		}
		if(weapon.gameObject.tag == "Trigger1"){
		referencetotext.text ="USE W,A,S,D TO MOVE";
		}
		if(weapon.gameObject.tag == "Trigger2"){
		referencetotext.text ="PRESS J TO PUNCH THE BOX";
		}
		if(weapon.gameObject.tag == "Trigger3"){
			referencetotext.text ="PRESS 2 TO PULL OUT YOUR SWORD";
		}	
 		if(weapon.gameObject.tag == "Trigger4"){
			referencetotext.text ="PRESS J TO SLASH";
		}
		if(weapon.gameObject.tag == "Trigger5"){
			referencetotext.text ="PRESS J TO SHOOT";
		}
		if(weapon.gameObject.tag == "Trigger6"){
			referencetotext.text ="CHECKPOINT";
		}
		if(weapon.gameObject.tag == "Trigger7"){
			referencetotext.text ="QUICKLY, GET YOUR GUN!";
		}
		if(weapon.gameObject.tag == "Trigger8"){
			referencetotext.text ="PRESS 3 TO PULL OUT YOUR GUN";
		}
		if(weapon.gameObject.tag == "Ending"){
			Application.LoadLevel("Next Scene");
		}
	}
		
	
	
	void OnTriggerExit(Collider hit){
    	referencetotext.text ="";
	}
}
// CharacterControllers are stupid. 