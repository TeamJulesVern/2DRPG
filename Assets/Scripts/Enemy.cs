using UnityEngine;
using System;
using System.Collections;

public abstract class Enemy : MonoBehaviour {
	
	public GameManager gameManager;
	public Transform player;
	
	public Animator Animator;
	
	int xp;
	int health;
	int damage;
	float attackSpeed;
	float coolDown;
	float speed;
	
	
	public Enemy(int Xp, int Health, int Damage, float AttackSpeed,float Speed){
		this.xp = Xp;
		this.Health = Health;
		this.Damage = Damage;
		this.AttackSpeed = AttackSpeed;
		this.Speed = Speed;
	}
	
	public int XP{ 
		get { return this.xp; } 
		set {
			if (value == null)
			{
				throw new ArgumentNullException("XP cannot be null.");
			}
			this.xp=value;
		}
	}
	public int Health { get{return this.health;} 
		set{
			if (value == null)
			{
				throw new ArgumentNullException("Health cannot be null.");
			}
			this.health=value;
		}
	}
	public int Damage { 
		get{ return this.damage; } 
		set{
			if (value == null)
			{
				throw new ArgumentNullException("Damage cannot be null.");
			}
			this.damage=value;
		}
	}
	public float AttackSpeed { 
		get{ return this.attackSpeed;}
		set{
			if (value < 0)
			{
				throw new ArgumentNullException("Attackspeed cannot be less than null.");
			}
			this.attackSpeed=value;
		}
	}
	public float CoolDown { get; set;}
	public float Speed{ 
		get{return this.speed;} 
		set{
			if (value < null)
			{
				throw new ArgumentNullException("Speed cannot be less than null.");
			}
			this.speed = value;
		}
	}
	//public Animator Animator { get; set;}

	void Start()
	{
		Animator = GetComponent<Animator>();
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	//Enemy taking dmg
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


