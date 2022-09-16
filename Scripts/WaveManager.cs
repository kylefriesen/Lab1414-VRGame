using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{

    //Spawn this object
    public GameObject ExplosiveAI;
    public Transform SpawnPoint;
    public Animator OpenAnimator;



    public float maxTime = 5;
    public float minTime = 2;

    //current time
    private float time;

    //The time to spawn the object
    private float spawnTime;

    void Start()
    {
        OpenAnimator = gameObject.GetComponent<Animator>();
        SetRandomTime();
        time = minTime;
        
        
    }

    void FixedUpdate()
    {

        //Counts up
        time += Time.deltaTime;

        //Check if its the right time to spawn the object
        if (time >= spawnTime)
        {
            SpawnObject();
            SetRandomTime();
        }

    }


    //Spawns the object and resets the time
    void SpawnObject()
    {
        time = 0; 

        OpenAnimator.Play("CapsuleOpen");
        
        Instantiate(ExplosiveAI, SpawnPoint.position, Quaternion.identity, transform);
       

    }

    //Sets the random time between minTime and maxTime
    void SetRandomTime()
    {
        spawnTime = Random.Range(minTime, maxTime);
    }
}