using UnityEngine;
using System.Collections;

public class Orc : MonoBehaviour 
{
	public GameManager gameManager;
	private Transform player;
	
	Animator animator;
	
	int batXp = 5;
	int batHealth = 2;
	int batDamage = 1;
	float batAttackSpeed = 0.6f;
	float coolDown;
	float batSpeed = 2;
	
	void Start()
	{
		animator = GetComponent<Animator>();
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	// Update is called once per frame
	void Update () 
	{
		//rotates towards player
		transform.LookAt(player.position);
		transform.Rotate(new Vector3(0, -90, 0), Space.Self);     
		
		//move towards the player and attacks
		if (Vector3.Distance(transform.position,player.position)<=0.5)
		{

			if (Time.time>=coolDown)
			{
				gameManager.SendMessage("PlayerDamaged", batDamage, SendMessageOptions.DontRequireReceiver);
				coolDown = Time.time + batAttackSpeed;
			}
			
		}
		else if (Vector3.Distance(transform.position,player.position)<=3)
		{
			transform.Translate(new Vector3(batSpeed*Time.deltaTime,0,0));
		}
		
	}
	
	//Enemy taking dmg
	void EnemyDamaged(int damage)
	{
		if (batHealth > 0)
		{
			batHealth -= damage;
		}
		if (batHealth <= 0)
		{
			batHealth = 0;
			Destroy(gameObject);
			gameManager.curEXP += batXp;
		}
	}
}