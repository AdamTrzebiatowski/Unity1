using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reload : MonoBehaviour {

    public static Animator reload_animator;


    // Use this for initialization
    void Start () {

        reload_animator = GetComponent<Animator>();
        reload_animator.SetBool("reload", false);
        Weapon.weapon_animator.SetBool("weapon_reload", false);

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("r") && Weapon.aiming == false)
        {
            reload_animator.SetBool("reload", true);
            Weapon.weapon_animator.SetBool("weapon_reload", true);

        }

        if (Time.time >= Shot.after_reload - 0.2f)
        {
            reload_animator.SetBool("reload", false);
            Weapon.weapon_animator.SetBool("weapon_reload", false);

        }




    }
}
