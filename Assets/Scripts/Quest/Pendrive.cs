using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pendrive : MonoBehaviour
{

    private bool can_take_pendrive;
    public static bool hacking_disrupted;
    public Text pendrive_text;

    public GameObject pendrive;

    // Use this for initialization
    void Start()
    {

    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && hacking_disrupted == true)
        {
            can_take_pendrive = true;
            pendrive_text.text = "PRESS E TO TAKE PENDRIVE";
        }



    }

    void OnTriggerExit(Collider other)
    {
        can_take_pendrive = false;
        pendrive_text.text = "";

    }


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("e") && can_take_pendrive == true)
        {
            Quest1.clues_quest1++;
            pendrive_text.text = "";
            Destroy(pendrive);

        }


    }
}
