using UnityEngine;
using System.Collections;
using System.Threading;
public class GameManager : MonoBehaviour {
	
	
	
	public Texture playersHealthTexture;
	public GUIText statsDisplay;
	public GUIText shop;
	public GUIText negative;
	
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
	public const float guiPlacementY1 = .25f; 
	public const float guiPlacementY2 = .50f; 
	public const float guiPlacementY3= .75f;
		    
	public const float guiPlacementX1 = .25f; 
	public const float guiPlacementX2 = .25f; 
	public const float guiPlacementX3 = .25f; 
	
	void Update()
	{
		if (curEXP >= maxEXP)
			LevelUp ();
		if (Input.GetKeyDown (KeyCode.C)) 
		{
			playerStats = !playerStats;	
		}
		
		if (Input.GetKeyDown (KeyCode.E))
			curEXP += 10;
		
		if (playerStats) 
		{
			statsDisplay.text = "Level: " + level + ": XP: " + curEXP + " / " + maxEXP + ": Gold: "+ playersGold;
		} 
		else
			statsDisplay.text = "";

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
		
	}


	// Use this for initialization
	void OnGUI()
	{
		
		for (int h = 0; h < curHealth; h++) 
		{
			GUI.DrawTexture(new Rect(5f+h*3f,8f, 17,17),playersHealthTexture,ScaleMode.ScaleToFit,true,0);
		}
		
		if (pauseMenu) {
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
					if (curHealth <= maxHealth - 1){ curHealth += 1; playersGold-=50;}
					else negative.text="You have max health";
				}
				else{ 
					negative.text = "Unsufficient gold"; 
				}
				
			}
			else if (GUI.Button (new Rect (Screen.width * guiPlacementX2, Screen.height * guiPlacementY2, Screen.width * .2f, Screen.height * .1f)
			                     , "Leave Shop")) {
				buyHP = false;
				negative.text="";
				Time.timeScale = 1f;
			}
		}
		if (buyDamage) {
			shop.text="";
			if (GUI.Button (new Rect (Screen.width * guiPlacementX1, Screen.height * guiPlacementY1, Screen.width * .2f, Screen.height * .1f)
			                , "Buy 1 dmg for 100 gold")) {
				if (playersGold >= 100) {
					PlayerShooting.damageValue += 1; playersGold-=100;}
				
				
				else{ negative.text = "Unsufficient gold";}
				
			}
			else if (GUI.Button (new Rect (Screen.width * guiPlacementX2, Screen.height * guiPlacementY2, Screen.width * .2f, Screen.height * .1f)
			                     , "Leave Shop")) {
				buyDamage = false;
				negative.text="";
				Time.timeScale = 1f;
			}
		}

		
	}
	
	void getGold(){
		playersGold += 100;
	}
	
	void PlayerDamaged(int damage)
	{
		if (curHealth > 0)
		{
			curHealth -= damage;
		}
		if (curHealth <= 0)
		{
			curHealth = 0;
			RestartScene();
		}
	}
	
	void RestartScene()
	{
		Application.LoadLevel (Application.loadedLevel);
	}
	
	
}

