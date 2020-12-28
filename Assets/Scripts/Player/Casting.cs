using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casting : MonoBehaviour {


    public static float target_distance;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            target_distance = hit.distance;
        }


    }
}
