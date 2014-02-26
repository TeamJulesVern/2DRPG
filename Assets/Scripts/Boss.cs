using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour
{
	public GameManager gameManager;
	private Transform player;
	
	Animator animator;
	
	int spiderXp = 10;
	int spiderHealth = 5;
	int spiderDmg = 2;
	float spiderAttackSpeed = 0.3f;
	float coolDown;
	float spiderSpeed = 3;
	
	void Start()
	{
		animator = GetComponent<Animator>();
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	// Update is called once per frame
	void Update()
	{
		//rotates towards player
		transform.LookAt(player.position);
		transform.Rotate(new Vector3(0, -90, 0), Space.Self);

		//move towards the player and attacks
		if (Vector3.Distance(transform.position, player.position) <= 0.5)
		{
			animator.SetTrigger ("BossAttack");
			if (Time.time >= coolDown)
			{

				gameManager.SendMessage("PlayerDamaged", spiderDmg, SendMessageOptions.DontRequireReceiver);
				coolDown = Time.time + spiderAttackSpeed;
			}
		}
		else if (Vector3.Distance(transform.position, player.position) <= 4)
		{           
			transform.Translate(new Vector3(spiderSpeed * Time.deltaTime, 0, 0));
			animator.SetTrigger ("BossWalk");
		}
		
	}
	
	//Enemy taking dmg
	void EnemyDamaged(int damage)
	{
		if (spiderHealth > 0)
		{
			spiderHealth -= damage;
		}
		if (spiderHealth <= 0)
		{
			spiderHealth = 0;
			Destroy(gameObject);
			gameManager.curEXP += spiderXp;
		}
	}
}