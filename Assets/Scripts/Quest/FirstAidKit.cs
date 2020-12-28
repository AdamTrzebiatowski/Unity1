using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstAidKit : MonoBehaviour {

    private bool can_heal;
    public Text first_aid_kit_text;

	// Use this for initialization
	void Start () {

        can_heal = false;
        first_aid_kit_text.text = "";
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            can_heal = true;
            first_aid_kit_text.text = "PRESS E TO USE FIRST AID KIT";
        }

            

    }

    void OnTriggerExit(Collider other)
    {
        can_heal = false;
        first_aid_kit_text.text = "";

    }

    // Update is called once per frame
    void Update () {
		
        if (Input.GetKeyDown("e") && can_heal == true)
        {
            if (Player.player_health <= 80)
            {
                Player.player_health += 20;
            }
            
            else if (Player.player_health > 80 && Player.player_health <= 100)
            {
                Player.player_health = 100;
            }

            Quest1.healed = true;

        }

	}
}
