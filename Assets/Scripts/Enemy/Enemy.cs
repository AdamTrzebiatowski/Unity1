using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Enemy : MonoBehaviour {

    public float enemy_health = 100;

    public Rigidbody drone_rb;

    public Animator drone_animator;


    public float cube_size = 0.02f;
    public int cubes_in_row = 10;

    float cubes_pivot_distance;
    Vector3 cubes_pivot;

   // public float explosion_radius = 100f;
   // public float explosion_force = 200f;
   // public float explosion_upward = 5f;

    public GameObject player;
    public GameObject enemy;

    public static float enemy_damage;

    public Transform drone_looking_target;

    public float drone_max_speed = 0.2f;
    public float drone_range = 10f;

    private bool start_drone_walking;

    public GameObject drone_eye;
    public float drone_fire_rate = 1f;
    private float drone_ready_to_fire;
    public Light drone_flash_light;

    private bool add_points;
    
    public Material explosion_material;
    public Light explosion_light;
    public ParticleSystem smoke;
    public ParticleSystem sparks;
    bool can_explode;


    void Start()
    {
        enemy_damage = 10;

        drone_rb = GetComponent<Rigidbody>();
        drone_animator = GetComponent<Animator>();
        drone_animator.SetBool("drone_walking", false);

        if (enemy.name != "Drone_PC")
        {
            drone_flash_light.intensity = 0;
        }
        else
        {
            drone_flash_light.intensity = 5;
        }

        add_points = true;

        cubes_pivot_distance = cube_size * cubes_in_row / 2;
        cubes_pivot = new Vector3(cubes_pivot_distance, cubes_pivot_distance, cubes_pivot_distance);
        explosion_light.intensity = 0;
        can_explode = true;


        start_drone_walking = false;

        smoke.enableEmission = false;
        sparks.enableEmission = false;



        }

    void Update()
    {
        Vector3 drone_direction = player.transform.position - enemy.transform.position;

        if (drone_direction.magnitude < 80 || enemy_health < 100)
        {
            start_drone_walking = true;
        }

        if (enemy_health > 0 && start_drone_walking == true && enemy.name != "Drone_PC")
        {
            drone_animator.SetBool("drone_walking", true);

            drone_rb.velocity = (drone_direction * drone_max_speed);
            transform.LookAt(drone_looking_target);
            transform.Rotate(-90, -90, 0);

            

            if (drone_direction.magnitude < drone_range && Time.time >= drone_ready_to_fire)
            {
                drone_ready_to_fire = Time.time + drone_fire_rate;

                drone_flash_light.intensity = 10;
                Player.player_health = Player.player_health - enemy_damage;

            }
            else
            {
                drone_flash_light.intensity = 0;
            }

        }
        
    }



    public void Damage (float damage_taken)
    {
        enemy_health -= damage_taken;

        if (add_points == true)
        {
            Player.score += 1;
            
        }

        if (enemy_health <= 20 && enemy_health > 0)
        {
            DroneDestroyed.drone_damaged = true;
            Player.score += 2;
        }
          


        if (enemy_health <= 0)
        {         
            DroneDestroyed.drone_destroyed = true;
            

            if (add_points == true)
            {
                Player.score += 10;

                if (enemy.name == "Drone_Base")
                {
                    Quest1.drones1_quest1--;
                }

                if (enemy.name == "Drone_PC")
                {
                    DroneDestroyed.hacking_disrupted = true;
                    Pendrive.hacking_disrupted = true;
                    Player.score += 5;
                }


                add_points = false;
            }
            
            drone_animator.SetBool("drone_walking", false);
            drone_eye.GetComponent<Renderer>().material = explosion_material;
            explosion_light.intensity = 5;
            smoke.enableEmission = true;
            sparks.enableEmission = true;
            Destroy(explosion_light, 5);
            Destroy(enemy, 5);

            

            if (can_explode == true)
            {
                Explosion();
                can_explode = false;
            }


            

        }

          

    }
 


    void Explosion()
    {
        can_explode = true;

        for (int x = 0; x < cubes_in_row; x++)
        {
            for (int y = 0; y < cubes_in_row; y++)
            {
                for (int z = 0; z < cubes_in_row; z++)
                {
                    CreateCube(x, y, z);
                }
            }
        }


    
    }

    void CreateCube(int x, int y, int z)
    {
        GameObject cube;
        
        cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.GetComponent<Renderer>().material = explosion_material;

        cube.transform.position = transform.position + new Vector3(cube_size * x, cube_size * y, cube_size * z) - cubes_pivot;
        cube.transform.localScale = new Vector3(cube_size, cube_size, cube_size);
        cube.AddComponent<Rigidbody>();
        cube.GetComponent<Rigidbody>().mass = 0.1f;
        Destroy(cube, 5);
    }
}
