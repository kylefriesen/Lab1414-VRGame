using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FlyExplosiveAI : MonoBehaviour
{
    // Movement speed
    public float _speed = 2f;
    // Minimum distance before exploding
    public float minDist = 2;
    // Is the AI suppoesd to explode?
    public bool Explosive = false;
    // Player Position
    private Transform Player;
    // Explosion prefab to insantiate
    public Transform explosionPrefab;
    // Damage to deal on explode
    public int damage;


    private void Start()
    {

        Player = GameObject.FindWithTag("Player").transform;

    }



    private void Update()
    {
        float dist = Vector3.Distance(Player.position, transform.position);
        
        if (Vector3.Distance(transform.position, Player.position) < 0.01f)
        {
           
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.position, _speed * Time.deltaTime);
            transform.LookAt(Player);
        }

        if (dist < minDist && Explosive)
        {
            ExplosiveProbe();
        }

    }

    void ExplosiveProbe()
    {
        //Spawn Explosion
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        //Damage Player
        var targetHealth = Player.GetComponent<Health>();
        targetHealth.HealthNumber -= damage;

        //Get damage splash
        Player.GetComponent<Health>().DamagePlayer();
        //Destroy AI gameobject
        Destroy(gameObject);
    }

}