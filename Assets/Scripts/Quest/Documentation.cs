using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Documentation : MonoBehaviour {

    private bool can_take_doc;
    public Text doc_text;

    public GameObject documentation;

    // Use this for initialization
    void Start () {
		
	}

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            can_take_doc = true;
            doc_text.text = "PRESS E TO COLLECT DOCUMENTATION";
        }



    }

    void OnTriggerExit(Collider other)
    {
        can_take_doc = false;
        doc_text.text = "";

    }


    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown("e") && can_take_doc == true)
        {
            Quest1.clues_quest1++;
            doc_text.text = "";
            Destroy(documentation);

        }


    }
}
