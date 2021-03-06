﻿using UnityEngine;
using System.Collections;

public class Bat : Enemy 
{
	private const int Xp = 5;
	private const int Healthh = 20;
	private const int Damagee = 1;
	private const float AttackSpeede = 0.6f;
	private const float Speede = 2;
	
	public Bat(int Xp, int Health, int Damage, float AttackSpeed,float Speed) 
		: base(Xp,Health,Damage,AttackSpeed,Speed)
	{	
	}
	public Bat() : this(Xp,Healthh,Damagee,AttackSpeede,Speede)
	{	
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
			if (Time.time>=CoolDown)
			{
				gameManager.SendMessage("PlayerDamaged", Damage, SendMessageOptions.DontRequireReceiver);
				CoolDown = Time.time + AttackSpeed;
			}
		}
		else if (Vector3.Distance(transform.position,player.position)<=3)
		{
			transform.Translate(new Vector3(Speed*Time.deltaTime,0,0));
		}
	}
	public void EnemyDamaged(int damage)
	{
		if (Health > 0)
		{
			Health -= damage;
		}
		if (Health <= 0)
		{
			Health = 0;
			Destroy(gameObject);
			gameManager.curEXP += XP;
		}
	}
}
