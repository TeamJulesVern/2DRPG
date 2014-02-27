using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	
	
	public Texture playersHealthTexture;
	public GUIText statsDisplay;
	public GUIText shop;
	public GUIText negative;
	public GUIText messanger;
	public GUIText HPbar;

	public int curHealth = 50;
	public int maxHealth = 50;
	
	public int curEXP = 0;
	
	bool playerStats;
	
	
	int maxEXP = 50;
	int level =1;
	
	int playersGold = 0;
	
	bool pauseMenu = false;
	bool buyHP= false;
	bool buyDamage = false;
	
	//Menu borders
	public float guiPlacementY1 = .38f; 
	public float guiPlacementY2 = .50f; 
	public float guiPlacementY3= .62f;
		    
	public float guiPlacementX1 = 25f; 
	public float guiPlacementX2 = .5f; 
	public float guiPlacementX3 = .5f; 

	//timer
	public float timer =2f;

	int count = 0;

	void Update()
	{
		if (curEXP >= maxEXP) {
						LevelUp ();
			messanger.text="You have leveled up!!!";
			timer=2f;
		}
		if (Input.GetKeyDown (KeyCode.C)) 
		{
			playerStats = !playerStats;	
		}
		
		if (Input.GetKeyDown (KeyCode.E))
			curEXP += 10;
		

			statsDisplay.text = "Level: " + level + "\nXP: " + curEXP + " / " + maxEXP + "\nGold: "+ playersGold + "\n"
				+ "Damage: " + PlayerShooting.damageValue;

		timer-=Time.deltaTime;
		if(timer <= 0f){
			messanger.text = "";
			timer=2f;
		}

	}
	void Shop(){
		pauseMenu = true;
		Time.timeScale = 0;
	 }

	void LevelUp()
	{
		curEXP = 0;
		maxEXP = maxEXP + 50;
		level ++;
		
		// Add Stats when Leveling
		maxHealth+=4;
		curHealth = maxHealth;

		PlayerShooting.damageValue += 1;
		
	}


	// Use this for initialization
	void OnGUI()
	{
		
		for (int h = 0; h < curHealth; h++) 
		{
			GUI.DrawTexture(new Rect(23f+h*3f,8f, 17,17),playersHealthTexture,ScaleMode.ScaleToFit,true,0);
			HPbar.text="HP:           :"+curHealth;
		}

		if (pauseMenu) {
			messanger.text="";
			shop.text = "WELCOME TO THE SHOP";
			if (GUI.Button (new Rect (Screen.width * guiPlacementX1, Screen.height * guiPlacementY1, Screen.width * .2f, Screen.height * .1f)
			                , "Buy Health")) {
				pauseMenu = false;
				buyHP = true;
			} else if (GUI.Button (new Rect (Screen.width * guiPlacementX2, Screen.height * guiPlacementY2, Screen.width * .2f, Screen.height * .1f)
			                       , "Buy Damage")){
				pauseMenu = false;
				buyDamage = true;
			}
			
			else if (GUI.Button (new Rect (Screen.width * guiPlacementX3, Screen.height * guiPlacementY3, Screen.width * .2f, Screen.height * .1f)
			                     , "Leave Shop")) {
				pauseMenu = false;
				Time.timeScale = 1f;
			}
		}

		if(!pauseMenu) shop.text="";

		if (buyHP) {
			shop.text="";
			if (GUI.Button (new Rect (Screen.width * guiPlacementX1, Screen.height * guiPlacementY1, Screen.width * .2f, Screen.height * .1f)
			                , "Buy 1 HP for 50 gold")) {
				if (playersGold >= 50) {
					if (curHealth <= maxHealth - 1){ count++; curHealth += 1; playersGold-=50; messanger.text="+" + count + " health";
						 }
					else negative.text="You have max health";
				}
				else{ 
					negative.text = "Unsufficient gold"; 

				}
				
			}
			else if (GUI.Button (new Rect (Screen.width * guiPlacementX2, Screen.height * guiPlacementY2, Screen.width * .2f, Screen.height * .1f)
			                     , "Back")) {
				buyHP = false;
				pauseMenu=true;
				count=0;

				negative.text="";
			}

				
		   

		}

		if (buyDamage) {
			shop.text="";
			if (GUI.Button (new Rect (Screen.width * guiPlacementX1, Screen.height * guiPlacementY1, Screen.width * .2f, Screen.height * .1f)
			                , "Buy 1 dmg for 100 gold")) {
				if (playersGold >= 100) {
					count++;
					PlayerShooting.damageValue += 1; playersGold-=100; messanger.text = "+" + count + " damage"; 
					}
				
				
				else{ negative.text = "Unsufficient gold"; }
				
			}
			else if (GUI.Button (new Rect (Screen.width * guiPlacementX2, Screen.height * guiPlacementY2, Screen.width * .2f, Screen.height * .1f)
			                     , "Back")) {
				buyDamage = false;
				pauseMenu = true;
				count=0;
				negative.text="";
			}
		}

		
	}
	
	void getGold(){
		playersGold += 150;
		timer=2f;
		messanger.text = "+" + 150 + " gold";
	}
	
	void PlayerDamaged(int damage)
	{
		if (curHealth > 0)
		{
			curHealth -= damage;
			timer=0.5f;
			messanger.text = "-" + damage + " damage";

		}
		if (curHealth <= 0)
		{
			curHealth = 0;

			PlayerShooting.damageValue=1;
			RestartScene();
		}
	}
	
	void RestartScene()
	{
		Application.LoadLevel (Application.loadedLevel);
	}
	
	
}

