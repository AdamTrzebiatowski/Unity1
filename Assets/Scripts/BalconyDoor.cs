using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalconyDoor : MonoBehaviour
{

    private Animator animator;
    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            animator.SetBool("open_balcony", true);

    }


    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
            animator.SetBool("opened_balcony", true);



    }

    void OnTriggerExit(Collider other)
    {
        animator.SetBool("open_balcony", false);
        animator.SetBool("close_balcony", true);
        animator.SetBool("opened_balcony", false);
    }


    // Update is called once per frame
    void Update()
    {

    }
}
