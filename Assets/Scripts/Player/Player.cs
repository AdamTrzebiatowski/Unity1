using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject player;
    public static float player_health = 100;
    public static int score;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        Debug.Log("Score: " + score);

        if (player_health <= 100)
        {
            Debug.Log(player_health);
        }


        if (player_health <= 0)
        {
            Destroy(player);
			Application.Quit();
        }
		
		if (Input.GetKey(KeyCode.Escape))
		{
			Application.Quit();
		}


	}
}
