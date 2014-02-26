using UnityEngine;
using System.Collections;

public class Bat : MonoBehaviour 
{
    public GameManager gameManager;

    private float xMove;
    private float yMove;
    private RaycastHit rhit;
    private float distanceFromPlayer;
    private Transform player;

    Animator animator;

    int batXp = 5;
    int batHealth = 5;
    int batDamage = 1;

    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
	// Update is called once per frame
	void Update () 
    {
        distanceFromPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceFromPlayer <= 1)
        {
            Debug.Log("Attakking Player");
        }
        else if (distanceFromPlayer <= 5)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player.position - transform.position), Time.deltaTime * 4);
            transform.Translate(0, 0, .05f);
        }
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            gameManager.SendMessage("PlayerDamaged", batDamage, SendMessageOptions.DontRequireReceiver);
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
