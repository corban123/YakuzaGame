//GUI scripting by Will Hubbell
using UnityEngine;
using System.Collections;
	
public class loadLevel : MonoBehaviour {
	
	public Texture2D hair1;
	public Texture2D hair2;
	public Texture2D hair3;
	public Texture2D hair4;
	public Texture2D hair5;
	public Texture2D weapon1;
	public Texture2D weapon2;
	public Texture2D weapon3;
	public Texture2D smallWeapon1;
	public Texture2D smallWeapon2;
	public Texture2D smallWeapon3;
	public Player other; //player script reference
	
	private int inventoryX = 150;
	private int bigInventoryX = 50;
	private int hairX = 70;
	
	
	void OnGUI () {
		// Hair
		if(other.curHealth >=24)
		{
			GUI.Label(new Rect(hairX,20,100,90), hair1);
		}
		else if(other.curHealth >=18 && other.curHealth < 24)
		{
			GUI.Label(new Rect(hairX,20,100,90), hair2);
		}
		else if(other.curHealth >=12 && other.curHealth < 18)
		{
			GUI.Label(new Rect(hairX,20,100,90), hair3);
		}
		else if(other.curHealth >=6 && other.curHealth < 12)
		{
			GUI.Label(new Rect(hairX,20,100,90), hair4);
		}
		else if(other.curHealth >=1 && other.curHealth < 6)
		{
			GUI.Label(new Rect(hairX,20,100,90), hair5);
		}
		
		//Weapons
		if(other.weapon == 1)
		{
			GUI.Label (new Rect(bigInventoryX, 50, 100, 90), weapon1);
			if(other.hasSword){
				GUI.Label(new Rect(inventoryX,20,100,90), smallWeapon2);
			}
			if(other.hasGun){
				GUI.Label(new Rect(inventoryX,50,100,90), smallWeapon3);
			}
		}
		if(other.weapon == 2)
		{
			GUI.Label (new Rect(bigInventoryX,50,100,90),weapon2);
			GUI.Label(new Rect(inventoryX,20,100,90), smallWeapon1);
			if(other.hasGun){
				GUI.Label(new Rect(inventoryX,50,100,90), smallWeapon3);
			}
		}
		if(other.weapon == 3)
		{
			GUI.Label(new Rect(bigInventoryX,50,100,90),weapon3);
			GUI.Label(new Rect(inventoryX,20,100,90), smallWeapon1);
			if(other.hasSword){
				GUI.Label(new Rect(inventoryX,50,100,90), smallWeapon2);
			}
		}
		
		/*
		//Kill button
		if (GUI.Button (new Rect (300,20,100,20), "hurt player")) {
			other.curHealth -= 5;
		}*/
	}
}