using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shot : MonoBehaviour {

    public float damage;
    public float range;

    public Camera camera;
    public ParticleSystem flash;
    public GameObject impact;
    public GameObject after_impact;
    public float fire_rate;
    public static float ready_to_fire;
    public float reloading;
    public static float after_reload;
    public static int ammo;
    


    public GameObject indicator;
    public GameObject ammo_main_capsule;
    public GameObject ammo_capsule7;
    public GameObject ammo_capsule6;
    public GameObject ammo_capsule5;
    public GameObject ammo_capsule4;
    public GameObject ammo_capsule3;
    public GameObject ammo_capsule2;
    public GameObject ammo_capsule1;

    public Material red;
    public Material blue;


    public static RaycastHit hit;




    // Use this for initialization
    void Start () {

        ammo = 7;
        Weapon.weapon_animator.SetBool("ammo", true);



    }
	
	// Update is called once per frame
	void Update () {


        if (Time.time >= after_reload - 0.2f)
        {
            AmmoCapsules();
        }
        

        if(Weapon.weapon_on==true)
        {
            if(Input.GetMouseButtonDown(0) && Time.time >= ready_to_fire && Time.time >= after_reload && ammo>0)
            {
                ammo--;
                ready_to_fire = Time.time + fire_rate;
                flash.Play();
                Shoot();
                
            }

            if (ammo<=0)
            {
                Weapon.weapon_animator.SetBool("ammo", false);
                indicator.GetComponent<Renderer>().material = red;
                ammo_main_capsule.GetComponent<Renderer>().material = red;
            }

            if (Input.GetKeyDown("r") && Weapon.aiming==false)
            {
                after_reload = Time.time + reloading;

                ammo = 7;
                Weapon.weapon_animator.SetBool("ammo", true);

                

                
            }

        }

        


	}

    void Shoot ()
    {       

        

        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Enemy enemy = hit.transform.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.Damage(damage);


            }


           /* if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * 500);
            }
*/

            if (Casting.target_distance>4f)
            {
                GameObject new_impact = Instantiate(impact, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(new_impact, 0.02f);

                if(hit.transform.tag!="Enemy")
                {
                    GameObject new_after_impact = Instantiate(after_impact, hit.point, Quaternion.LookRotation(hit.normal));
                    Destroy(new_after_impact, 10f);

                    

                }
                
            }

            
        }
            
    }


    void AmmoCapsules()
    {
        indicator.GetComponent<Renderer>().material = blue;
        ammo_main_capsule.GetComponent<Renderer>().material = blue;

        switch (ammo)
        {
            case 7:
                ammo_capsule7.GetComponent<Renderer>().material = blue;
                ammo_capsule6.GetComponent<Renderer>().material = blue;
                ammo_capsule5.GetComponent<Renderer>().material = blue;
                ammo_capsule4.GetComponent<Renderer>().material = blue;
                ammo_capsule3.GetComponent<Renderer>().material = blue;
                ammo_capsule2.GetComponent<Renderer>().material = blue;
                ammo_capsule1.GetComponent<Renderer>().material = blue;
                break;

            case 6:
                ammo_capsule7.GetComponent<Renderer>().material = red;
                ammo_capsule6.GetComponent<Renderer>().material = blue;
                ammo_capsule5.GetComponent<Renderer>().material = blue;
                ammo_capsule4.GetComponent<Renderer>().material = blue;
                ammo_capsule3.GetComponent<Renderer>().material = blue;
                ammo_capsule2.GetComponent<Renderer>().material = blue;
                ammo_capsule1.GetComponent<Renderer>().material = blue;
                break;

            case 5:
                ammo_capsule7.GetComponent<Renderer>().material = red;
                ammo_capsule6.GetComponent<Renderer>().material = red;
                ammo_capsule5.GetComponent<Renderer>().material = blue;
                ammo_capsule4.GetComponent<Renderer>().material = blue;
                ammo_capsule3.GetComponent<Renderer>().material = blue;
                ammo_capsule2.GetComponent<Renderer>().material = blue;
                ammo_capsule1.GetComponent<Renderer>().material = blue;
                break;

            case 4:
                ammo_capsule7.GetComponent<Renderer>().material = red;
                ammo_capsule6.GetComponent<Renderer>().material = red;
                ammo_capsule5.GetComponent<Renderer>().material = red;
                ammo_capsule4.GetComponent<Renderer>().material = blue;
                ammo_capsule3.GetComponent<Renderer>().material = blue;
                ammo_capsule2.GetComponent<Renderer>().material = blue;
                ammo_capsule1.GetComponent<Renderer>().material = blue;
                break;

            case 3:
                ammo_capsule7.GetComponent<Renderer>().material = red;
                ammo_capsule6.GetComponent<Renderer>().material = red;
                ammo_capsule5.GetComponent<Renderer>().material = red;
                ammo_capsule4.GetComponent<Renderer>().material = red;
                ammo_capsule3.GetComponent<Renderer>().material = blue;
                ammo_capsule2.GetComponent<Renderer>().material = blue;
                ammo_capsule1.GetComponent<Renderer>().material = blue;
                break;

            case 2:
                ammo_capsule7.GetComponent<Renderer>().material = red;
                ammo_capsule6.GetComponent<Renderer>().material = red;
                ammo_capsule5.GetComponent<Renderer>().material = red;
                ammo_capsule4.GetComponent<Renderer>().material = red;
                ammo_capsule3.GetComponent<Renderer>().material = red;
                ammo_capsule2.GetComponent<Renderer>().material = blue;
                ammo_capsule1.GetComponent<Renderer>().material = blue;
                break;

            case 1:
                ammo_capsule7.GetComponent<Renderer>().material = red;
                ammo_capsule6.GetComponent<Renderer>().material = red;
                ammo_capsule5.GetComponent<Renderer>().material = red;
                ammo_capsule4.GetComponent<Renderer>().material = red;
                ammo_capsule3.GetComponent<Renderer>().material = red;
                ammo_capsule2.GetComponent<Renderer>().material = red;
                ammo_capsule1.GetComponent<Renderer>().material = blue;
                break;

            case 0:
                ammo_capsule7.GetComponent<Renderer>().material = red;
                ammo_capsule6.GetComponent<Renderer>().material = red;
                ammo_capsule5.GetComponent<Renderer>().material = red;
                ammo_capsule4.GetComponent<Renderer>().material = red;
                ammo_capsule3.GetComponent<Renderer>().material = red;
                ammo_capsule2.GetComponent<Renderer>().material = red;
                ammo_capsule1.GetComponent<Renderer>().material = red;
                break;
        }

    }
}
