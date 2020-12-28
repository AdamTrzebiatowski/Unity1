using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class DroneDestroyed : MonoBehaviour {

    public Text drone_destroyed_text;
    public Text drone_damaged_text;

    public static bool drone_destroyed;
    public static bool drone_damaged;
    public static bool hacking_disrupted;

    private float text_visible;
    private float text_disappear;


    int a;
    bool allow_random;

    // Use this for initialization
    void Start () {

        text_visible = 2f;
        drone_destroyed = false;
        hacking_disrupted = false;



    }
	
	// Update is called once per frame
	void Update () {

        if (allow_random == true)
        {
            a = Random.Range(0, 3);
            allow_random = false;
        }
       

        if (drone_destroyed == true && hacking_disrupted == false)
        {
            drone_destroyed_text.text = "Drone destroyed +10";
        }

        else if (drone_destroyed == true && hacking_disrupted == true)
        {
            drone_damaged_text.text = "Hacking disrupted +5";
            drone_destroyed_text.text = "Drone destroyed +10";
            hacking_disrupted = false;
        }



        if (drone_damaged == true)
        {

            

            switch (a)
            {
                case 0:
                    drone_damaged_text.text = "GPS system disabled +2";                     
                    break;

                case 1:
                    drone_damaged_text.text = "Subsystem cable burnout +2";
                    break;

                case 2:
                    drone_damaged_text.text = "Video transmission disrupted +2";

                    break;

            }
            
        }


        




        if (Time.time >= text_disappear)
        {
            text_disappear = Time.time + text_visible;
            drone_destroyed_text.text = "";
            drone_damaged_text.text = "";
            drone_destroyed = false;
            drone_damaged = false;
            allow_random = true;
        }





    }
}
