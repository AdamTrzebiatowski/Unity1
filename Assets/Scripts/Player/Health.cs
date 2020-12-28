using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    public Text health_text;
    public Image health_bar;

    Vector3 health_bar_position;

    // Use this for initialization
    void Start () {

        health_bar_position = health_bar.transform.position;

    }
	
	// Update is called once per frame
	void Update () {

        health_text.text = Player.player_health.ToString();

        if (Player.player_health <= 20)
        {
            health_text.color = Color.red;
        }
        else
        {
            health_text.color = Color.white;
        }


        health_bar.rectTransform.sizeDelta = new Vector2 (30, Player.player_health * 2);
        health_bar.transform.position = health_bar_position + new Vector3(0, -(100 - Player.player_health), 0);

    }
}
