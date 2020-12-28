using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    private Animator animator;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();

	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            animator.SetBool("open", true);

            if (Quest1.drones1_quest1 == 0)
            {
                Quest1.door_opened = true;
            }
                
        }

    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
            animator.SetBool("opened", true);



    }

    void OnTriggerExit(Collider other)
    {    
            animator.SetBool("open", false);
            animator.SetBool("close", true);
            animator.SetBool("opened", false);

    }


    // Update is called once per frame
    void Update () {
		
	}
}
