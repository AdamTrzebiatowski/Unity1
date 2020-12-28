using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest1 : MonoBehaviour {

    public static int drones1_quest1;
    public static int clues_quest1;

    public Text quest1_text;
    public Text parachute_text;


    public static bool jumped_out;
    public static bool parachute_opened;
    public static bool door_opened;
    public static bool healed;

	// Use this for initialization
	void Start () {

        jumped_out = false;
        drones1_quest1 = 3;
        clues_quest1 = 0;

        door_opened = false;
        healed = false;

    }
	
	// Update is called once per frame
	void Update () {

        quest1_text.text = "Jump out of the plane.";

        if (jumped_out == true)
        {
            
            quest1_text.text = "Defend the base from the drones. \nDrones destroyed " + (3 - drones1_quest1).ToString() + "/3";

            if (drones1_quest1 == 0)
            {

                quest1_text.text = "Defend the base from the drones. \nAll drones destroyed. Walk inside.";

                if (door_opened == true)
                {
                    quest1_text.text = "Explore the base. \nFind first aid kit and use it.";

                    if (healed == true)
                    {
                        quest1_text.text = "Explore the base. \nFind clues " + clues_quest1 + "/3";
                    }

                }

            }
        }



    }
}
