using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody rigidbody;
    public float jump_force;
    CapsuleCollider collider;
    private bool crouching;
    private bool standing;
    public static bool running;
    private float v;
    private float a;
    private float run;
    public float jumping;
    private float ready_to_jump;

    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponent<CapsuleCollider>();
        standing = true;
        crouching = false;
        
        Cursor.visible = false;
        v = 1f;
        a = 1f;
        run = 0f;
    }
	
	// Update is called once per frame
	void Update () {

        float movementV = Input.GetAxis("Vertical") * (10 + run);
        float movementH = Input.GetAxis("Horizontal") * 10;
        movementV *= Time.deltaTime;
        movementH *= Time.deltaTime;
        this.transform.Translate(Vector3.forward * movementV * v * a);
        this.transform.Translate(Vector3.right * movementH * v * a);




        if (Input.GetKeyDown("space") && standing == true && Time.time>=ready_to_jump)
        {
            this.rigidbody.AddForce(Vector3.up*jump_force);
            ready_to_jump = Time.time + jumping;
        }


        if (Input.GetKeyDown("c") && crouching==false)
        {
            collider.height = 1.5f;

        }
        else if (Input.GetKeyDown("c") && crouching == true)
        {
            collider.height = 3f;

        }




        if (collider.height == 3f)
        {
            standing = true;
            crouching = false;
        }

        if (collider.height == 1.5f)
        {
            standing = false;
            crouching = true;
        }



        if (Input.GetKeyDown("left shift"))
        {
            collider.height = 3f;
            running = true;
        }
        if (Input.GetKeyUp("left shift"))
        {
            running = false;
        }



        
        if (standing == true)
        {
            v = 1f;
        }
        else if (crouching == true)
        {
            v = 0.5f;
        }




        if (Weapon.aiming == true)
        {
            a = 0.6f;
        }
        else if (Weapon.aiming == false)
        {
            a = 1f;
        }



        if (running == true && Input.GetAxis("Vertical")>0)
        {
            run = 5f;
        }
        else if (running == false)
        {
            run = 0f;
        }

        

    }
}
