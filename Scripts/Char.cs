using UnityEngine;
using System.Collections;

public class Char : MonoBehaviour {

    //Random Shit
    public static int Katana = 0;
	public static int Gun = 0;
    public bool isStand;
    public bool isLeft;
    public bool isRight;
    public bool isUp;
    public bool isDown;
    public bool isPunch;
    public int facingDir = 1;

    //Movement behaviors
    public float Gravity = 15;	 //downward force
    public float TerminalVelocity = 20f;	//max downward speed
    public float JumpSpeed = 6f;
    public float MoveSpeed = 10f;
    public float RunSpeed = 15;


    public bool isFist = true;
    public bool isSword = false;
	public bool isGun = false;

	// Use this for initialization
	void Start () {
	
		
		
	}
	
	// Update is called once per frame
	void Update () {

        //Defining Directions

        if (isLeft && !isPunch)
        {
            facingDir = 1;
        }
        if (isRight && !isPunch)
        {
            facingDir = 2;
        }

        if (isUp && !isPunch)
        {
            facingDir = 3;
        }
        if (isDown && !isPunch)
        {
            facingDir = 4;
        }
	}
		
		
	}

