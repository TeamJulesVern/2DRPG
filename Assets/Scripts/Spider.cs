using UnityEngine;
using System.Collections;

public class Spider : Enemy
{
	private const int Xp = 10;
	private const int Health = 4;
	private const int Damage = 2;
	private const float AttackSpeed = 0.3f;
	private const float Speed = 3;

	public Spider(int Xp, int Health, int Damage, float AttackSpeed,float Speed) 
	: base(Xp,Health,Damage,AttackSpeed,Speed)
	{
	}
	public Spider() : this(Xp,Health,Damage,AttackSpeed,Speed)
	{
	}  

	// Update is called once per frame
	void Update()
	{
		//rotates towards player
		transform.LookAt(player.position);
		transform.Rotate(new Vector3(0, -90, 0), Space.Self);
		Animator.SetTrigger ("SpiderWalkRight");
		//move towards the player and attacks
		if (Vector3.Distance(transform.position, player.position) <= 0.5)
		{
			if (Time.time >= CoolDown)
			{
				gameManager.SendMessage("PlayerDamaged", Damage, SendMessageOptions.DontRequireReceiver);
				CoolDown = Time.time + AttackSpeed;
			}
		}
		else if (Vector3.Distance(transform.position, player.position) <= 4)
		{           
			transform.Translate(new Vector3(Speed * Time.deltaTime, 0, 0));                                 
		}
	}
}
