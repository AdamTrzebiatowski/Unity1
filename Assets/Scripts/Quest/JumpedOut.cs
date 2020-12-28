using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpedOut : MonoBehaviour {

    private Animator animator;
    public GameObject plane;


    // Use this for initialization
    void Start () {

        animator = GetComponent<Animator>();
        animator.SetBool("plane_moving", false);

    }


    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Quest1.jumped_out = true;
            animator.SetBool("plane_moving", true);

        }



    }

    void AnimationEnded ()
    {
        Destroy(plane);
    }


    // Update is called once per frame
    void Update () {



    }
}
