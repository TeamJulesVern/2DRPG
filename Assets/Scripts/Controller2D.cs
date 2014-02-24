using UnityEngine;
using System.Collections;

public class Controller2D : MonoBehaviour 
{
    //Reff to character controller
    CharacterController charController;

  
    public float walkSpeed = 5;

    //Control our Player movment 
    Vector3 moveDirection = Vector3.zero;
    float horizontal = 0;
	float vertical = 0;
   
	//Player attack vars
    public Rigidbody bulletPrefab;

    float attackRate = 0.5f;
    float coolDown;

    //turn player vars
    bool pLookingToRight = true;
	bool pLookingToUp = true;

	Animator animator;


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
		if (horizontal > 0f)
        {
			animator.SetTrigger("MoveRight");
            pLookingToRight = true;
            moveDirection.x = horizontal * walkSpeed;
        }

        //move left
		if (horizontal < 0f)
        {
			animator.SetTrigger("MoveLeft");
            pLookingToRight = false;
            moveDirection.x = horizontal * walkSpeed;
        }

		//move up
		if (vertical > 0f) 
		{
			animator.SetTrigger("MoveUp");
			pLookingToUp = true;
			moveDirection.y = vertical * walkSpeed;
		}


		//move down
		if (vertical < 0f) 
		{
			animator.SetTrigger("MoveDown");
			pLookingToUp = false;
			moveDirection.y = vertical * walkSpeed;	
		}
				    
		if (vertical == 0f && horizontal == 0f) 
		{
			animator.SetTrigger("Static");
		}
        //Control's player attack
        if (Time.time >= coolDown)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                BulletAttack();
            }
        }

	}

    void BulletAttack()
    {
        if (pLookingToRight)
        {
            Rigidbody bPrefab = Instantiate(bulletPrefab, transform.position, Quaternion.identity) as Rigidbody;
            bPrefab.rigidbody.AddForce(Vector3.right * 500);
            coolDown = Time.time + attackRate;
        }
        else
        {
            Rigidbody bPrefab = Instantiate(bulletPrefab, transform.position, Quaternion.identity) as Rigidbody;
            bPrefab.rigidbody.AddForce(-Vector3.right * 500);
            coolDown = Time.time + attackRate;
        }
       
    }
}
