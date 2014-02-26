using UnityEngine;
using System.Collections;

public class Boss : Enemy
{
	public Boss(int Xp, int Health, int Damage, float AttackSpeed,float Speed) : base(Xp,Health,Damage,AttackSpeed,Speed){
		
	}
	public Boss() : this(10,5,2,0.3f,3){
		
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
			Animator.SetTrigger ("BossAttack");
			if (Time.time >= CoolDown)
			{

				gameManager.SendMessage("PlayerDamaged", Damage, SendMessageOptions.DontRequireReceiver);
				CoolDown = Time.time + AttackSpeed;
			}
		}
		else if (Vector3.Distance(transform.position, player.position) <= 4)
		{           
			transform.Translate(new Vector3(Speed * Time.deltaTime, 0, 0));
			Animator.SetTrigger ("BossWalk");
		}
		
	}

}