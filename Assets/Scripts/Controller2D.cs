using UnityEngine;
using System.Collections;

public class Controller2D :  MonoBehaviour, iMove, iFire
{
	//Reff to character controller
	CharacterController charController;
	
	// Use this for initialization
	public Rigidbody bulletPrefab1;
	public Rigidbody bulletPrefab2;
	public Rigidbody bulletPrefab3;
	public Rigidbody bulletPrefab4;
	
	public float attackSpeed = 0.2f;
	float coolDown;
	
	public float walkSpeed = 1;
	
	//Control our Player movment 
	Vector3 moveDirection = Vector3.zero;
	float horizontal = 0;
	float vertical = 0;
	
	Animator animator;
	
	//The direction he is movin
	static public bool Right;
	static public bool Left;
	static public bool Up;
	static public bool Down;

	// Use this for initialization
	void Start () 
	{
		charController = GetComponent<CharacterController>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		charController.Move(moveDirection * Time.deltaTime);
		
		horizontal = Input.GetAxis("Horizontal");
		vertical = Input.GetAxis ("Vertical");

		//move right
		if (horizontal > 0.000001f) {
			moveDirection.x = moveRight(horizontal);
		}
		
		//move left
		if (horizontal < -0.000001f) {
			moveDirection.x = moveLeft (horizontal);
		}
		
		//move up
		if (vertical > 0.000001f) {
			moveDirection.y = moveUp (vertical);
		}
			
		//move down
		if (vertical < -0.000001f) {
			moveDirection.y = moveDown (vertical);
		}		    
		if (vertical == 0f && horizontal == 0f) 
		{
			moveDirection.x=horizontal;
			moveDirection.y=vertical;
			animator.SetTrigger("Static");
		}
		
		if (Time.time >= coolDown)
		{
			if (Input.GetKey(KeyCode.Space))
				Fire();
		}  
	}
	
	public float moveRight(float horizontal)
	{
		Right = true;
		Left = false;
		Up = false;
		Down = false;
		animator.SetTrigger ("MoveRight");  
		return horizontal * walkSpeed;
	}
	
	public float moveLeft(float horizontal)
	{
		Right=false;
		Left=true;
		Up=false;
		Down=false;
		animator.SetTrigger("MoveLeft");
		return horizontal * walkSpeed;
	}
	
	public float moveUp(float vertical)
	{
		Right=false;
		Left=false;
		Up=true;
		Down=false;
		animator.SetTrigger("MoveUp");
		return vertical * walkSpeed;
	}
	
	public float moveDown(float vertical)
	{
		Right=false;
		Left=false;
		Up=false;
		Down=true;
		animator.SetTrigger("MoveDown");
		return vertical * walkSpeed;	
	}
	
	public void Fire()
	{
		if (Up)
		{
			Rigidbody bPrefab = Instantiate(bulletPrefab1, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity) as Rigidbody;
			bPrefab.rigidbody.AddForce(Vector3.up * 500);
			coolDown = Time.time + attackSpeed;
		}
		else if (Down)
		{
			Rigidbody bPrefab = Instantiate(bulletPrefab2, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity) as Rigidbody;
			bPrefab.rigidbody.AddForce(Vector3.down * 500);
			coolDown = Time.time + attackSpeed;
		}
		else if (Right)
		{
			Rigidbody bPrefab = Instantiate(bulletPrefab3, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity) as Rigidbody;
			bPrefab.rigidbody.AddForce(Vector3.right * 500);
			coolDown = Time.time + attackSpeed;
		}
		else if (Left)
		{
			Rigidbody bPrefab = Instantiate(bulletPrefab4, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity) as Rigidbody;
			bPrefab.rigidbody.AddForce(Vector3.left * 500);
			coolDown = Time.time + attackSpeed;
		}
	}
	
	
}
