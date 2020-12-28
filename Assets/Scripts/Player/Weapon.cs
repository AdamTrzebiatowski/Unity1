using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public static Animator weapon_animator;
    public static bool weapon_on;
    public static bool aiming;



    void Start () {




        weapon_animator = GetComponent<Animator>();
        weapon_animator.SetBool("weapon_active", false);
        weapon_on = false;
        aiming = false;

    }
	
	// Update is called once per frame
	void Update () {




        if (Input.GetKeyDown("1"))
        {
            if (weapon_on == false)
            {
                weapon_animator.SetBool("weapon_active", true);
                weapon_on = true;
            }
            else
            {
                weapon_animator.SetBool("weapon_active", false);
                weapon_on = false;
            }

        }

        if (Input.GetMouseButton(1) && PlayerMovement.running == false)
        {
            weapon_animator.SetBool("aiming", true);
            aiming = true;
        }
        else
        {
            weapon_animator.SetBool("aiming", false);
            aiming = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            weapon_animator.SetBool("shot", true);
        }
        else
        {
            weapon_animator.SetBool("shot", false);
        }




    }
}
