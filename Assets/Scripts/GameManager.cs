using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	
	
	public Texture playersHealthTexture;
	public GUIText statsDisplay;
	public int curHealth = 14;
	public int maxHealth = 14;
    public int curEXP = 0;
	
	bool playerStats;
	
	
	int maxEXP = 50;
	int level =1;

	
	
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
			statsDisplay.text = "Level " + level + ": XP" + curEXP + " / " + maxEXP;
		} 
		else
			statsDisplay.text = "";
	}
	
	void LevelUp()
    {
		curEXP = 0;
		maxEXP = maxEXP + 50;
		level ++;
		
		// Add Stats when Leveling
		maxHealth+=4;
	}
	
	// Use this for initialization
	void OnGUI()
	{
		
		for (int h = 0; h < maxHealth; h++) 
        {
			GUI.DrawTexture(new Rect(5f+h*3f,8f, 17,17),playersHealthTexture,ScaleMode.ScaleToFit,true,0);
		}
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

