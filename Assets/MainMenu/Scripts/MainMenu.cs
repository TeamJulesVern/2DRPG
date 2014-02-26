using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public Texture backGroundTexture;

	private float guiPlacementY1 = .25f; 
	private float guiPlacementY2 = .50f; 

	private float guiPlacementX1 = .25f; 
	private float guiPlacementX2 = .25f; 
	void OnGUI(){

		//DISPlay our BackGround Texture
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height),
		                backGroundTexture);

		//Display Buttons
		if (GUI.Button (new Rect (Screen.width * guiPlacementX1, Screen.height * guiPlacementY1, Screen.width * .5f, Screen.height * .1f)
		                , "Play Game")) 
		{
			print("Clicked Play Game");
	    };
		if (GUI.Button (new Rect (Screen.width * guiPlacementX2, Screen.height * guiPlacementY2, Screen.width * .5f, Screen.height * .1f)
		                , "Exit")) 
		{
			print("Clicked Exit");
		};
	}
}
