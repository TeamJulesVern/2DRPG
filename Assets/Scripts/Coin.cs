using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {
	
	public GameManager gameManager;
	
	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Player") {
			
			gameManager.SendMessage("getGold",SendMessageOptions.DontRequireReceiver);
			Destroy(gameObject);
			
		}
	}
}
