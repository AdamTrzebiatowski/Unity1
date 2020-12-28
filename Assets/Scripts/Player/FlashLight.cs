using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour {


    public Light light;


    // Use this for initialization
    void Start () {
        light = GetComponent<Light>();
        light.intensity = 0;
    }
	
	// Update is called once per frame
	void Update () {

        if (Weapon.weapon_on==true)
        {
            if (Input.GetMouseButtonDown(0) && Time.time >= Shot.ready_to_fire && Shot.ammo > 0 && Time.time >= Shot.after_reload)
                {
                    light.intensity = 1;
                }
            else
                {
                    light.intensity = 0;
                }
        }

    }
        
}
