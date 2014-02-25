using UnityEngine;
using System.Collections;

public class Spider : MonoBehaviour
{
    public Transform target;
    public int rotationSpeed = 2;
    public int speed = 5;

    private Transform myTransform;

    Animator animator;

    void Awake()
    {
        myTransform = transform;
    }

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        GameObject goTo = GameObject.FindGameObjectWithTag("Player");
        target = goTo.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(target.position, myTransform.position, Color.red);

        //Look at target
        myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
            Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);

        //move towards target
        myTransform.position += myTransform.forward * speed * Time.deltaTime;
    }
}
