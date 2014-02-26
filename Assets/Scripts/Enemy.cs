using UnityEngine;
using System.Collections;

public abstract class Enemy : MonoBehaviour {
	
	public GameManager gameManager;
	public Transform player;
	
	Animator animator;
	
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
	
	public int XP{ get; set;}
	public int Health { get; set;}
	public int Damage { get; set;}
	public float AttackSpeed { get; set;}
	public float CoolDown { get; set;}
	public float Speed{ get; set;}
	public Animator Animator { get; set;}

	void Start()
	{
		Animator = GetComponent<Animator>();
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	//Enemy taking dmg
	void EnemyDamaged(int damage)
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


