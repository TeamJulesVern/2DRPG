using UnityEngine;
using System.Collections;

public class Shop : MonoBehaviour {
	public GameManager gameManager;
	// Use this for initialization
	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Player") {
			gameManager.SendMessage("Shop",SendMessageOptions.DontRequireReceiver);
				}
	}
}
