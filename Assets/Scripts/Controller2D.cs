using UnityEngine;
using System.Collections;

public class Controller2D : MonoBehaviour 
{
    //Reff to character controller
    CharacterController charController;

    // Use this for initialization
    public Rigidbody bulletPrefab1;
    public Rigidbody bulletPrefab2;
    public Rigidbody bulletPrefab3;
    public Rigidbody bulletPrefab4;

    public float attackSpeed = 0.5f;
    float coolDown;
  
    public float walkSpeed = 1;

    //Control our Player movment 
    Vector3 moveDirection = Vector3.zero;
    float horizontal = 0;
	float vertical = 0;

    

	Animator animator;

	//The direction he is movin
	static public bool moveRight;
	static public bool moveLeft;
	static public bool moveUp;
	static public bool moveDown;


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
		if (horizontal > 0.000001f)
        {
			moveRight=true;
			moveLeft=false;
			moveUp=false;
			moveDown=false;
			animator.SetTrigger("MoveRight");        
            moveDirection.x = horizontal * walkSpeed;
        }

        //move left
		if (horizontal < -0.000001f)
        {
			moveRight=false;
			moveLeft=true;
			moveUp=false;
			moveDown=false;
			animator.SetTrigger("MoveLeft");
            moveDirection.x = horizontal * walkSpeed;
        }

		//move up
		if (vertical > 0.000001f) 
		{
			moveRight=false;
			moveLeft=false;
			moveUp=true;
			moveDown=false;
			animator.SetTrigger("MoveUp");

			moveDirection.y = vertical * walkSpeed;
		}


		//move down
		if (vertical < -0.000001f) 
		{
			moveRight=false;
			moveLeft=false;
			moveUp=false;
			moveDown=true;
			animator.SetTrigger("MoveDown");
			moveDirection.y = vertical * walkSpeed;	
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
    void Fire()
    {
        if (Controller2D.moveUp)
        {
            Rigidbody bPrefab = Instantiate(bulletPrefab1, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity) as Rigidbody;
            bPrefab.rigidbody.AddForce(Vector3.up * 500);

            coolDown = Time.time + attackSpeed;
        }
        else if (Controller2D.moveDown)
        {
            Rigidbody bPrefab = Instantiate(bulletPrefab2, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity) as Rigidbody;
            bPrefab.rigidbody.AddForce(Vector3.down * 500);

            coolDown = Time.time + attackSpeed;
        }
        else if (Controller2D.moveRight)
        {
            Rigidbody bPrefab = Instantiate(bulletPrefab3, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity) as Rigidbody;
            bPrefab.rigidbody.AddForce(Vector3.right * 500);

            coolDown = Time.time + attackSpeed;
        }
        else if (Controller2D.moveLeft)
        {
            Rigidbody bPrefab = Instantiate(bulletPrefab4, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity) as Rigidbody;
            bPrefab.rigidbody.AddForce(Vector3.left * 500);

            coolDown = Time.time + attackSpeed;
        }
    }

   
}
