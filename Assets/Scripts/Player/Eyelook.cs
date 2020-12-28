using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyelook : MonoBehaviour {

    private Vector2 md; //mouse direction
    private float r;

    private Transform player;
	// Use this for initialization
	void Start () {
        player = this.transform.parent.transform;
        r = 1f;
	}
	
	// Update is called once per frame
	void Update () {

        Vector2 mc = new Vector2 (Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")); //mouse change

        if (PlayerMovement.running == true && Input.GetAxis("Vertical") > 0)
        {
            r = 0.35f;
        }
        else if (PlayerMovement.running == false)
        {
            r = 1f;
        }

            md += mc * r;
        this.transform.localRotation = Quaternion.AngleAxis(-md.y, Vector3.right);
        player.localRotation = Quaternion.AngleAxis(md.x, Vector3.up);
	}
}
