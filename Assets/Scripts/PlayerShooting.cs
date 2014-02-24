using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {

	// Use this for initialization
	public Rigidbody bulletPrefab1;
	public Rigidbody bulletPrefab2;
	public Rigidbody bulletPrefab3;
	public Rigidbody bulletPrefab4;

	public float attackSpeed = 0.5f;
	float coolDown;


	
	// Update is called once per frame
	void Update () {
		if (Time.time >= coolDown) {
			if(Input.GetKey(KeyCode.Space))
			Fire();
		}
	}
	void Fire()
	{
		if (Controller2D.moveUp) {
				Rigidbody bPrefab = Instantiate (bulletPrefab1, new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity) as Rigidbody;
				bPrefab.rigidbody.AddForce (Vector3.up * 500);

				coolDown = Time.time + attackSpeed;
		} 
		else if(Controller2D.moveDown){
				Rigidbody bPrefab = Instantiate (bulletPrefab2, new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity) as Rigidbody;
				bPrefab.rigidbody.AddForce (Vector3.down * 500);
				
				coolDown = Time.time + attackSpeed;
		}
		else if(Controller2D.moveRight){
			Rigidbody bPrefab = Instantiate (bulletPrefab3, new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity) as Rigidbody;
			bPrefab.rigidbody.AddForce (Vector3.right * 500);
			
			coolDown = Time.time + attackSpeed;
		}
		else if(Controller2D.moveLeft){
			Rigidbody bPrefab = Instantiate (bulletPrefab4, new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity) as Rigidbody;
			bPrefab.rigidbody.AddForce (Vector3.left * 500);
			
			coolDown = Time.time + attackSpeed;
		}
	}
}
