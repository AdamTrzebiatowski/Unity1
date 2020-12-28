using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour {

    public Light light;
    private bool torch_on;
    // Use this for initialization
    void Start () {
        light = GetComponent<Light>();
        light.intensity = 0;
        torch_on = false;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("l") && torch_on==false)
        {
            light.intensity = 1;
            torch_on = true;
        }
        else if (Input.GetKeyDown("l") && torch_on == true)
        {
            light.intensity = 0;
            torch_on = false;
        }

    }
}
