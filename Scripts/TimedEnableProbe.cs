using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedEnableProbe : MonoBehaviour
{
    public float seconds;
    
    
    
    void Start()
    {
        StartCoroutine(LateCall());
    }

    IEnumerator LateCall()
    {
        

        yield return new WaitForSeconds(seconds);

        GetComponent<FlyExplosiveAI>().enabled = true;
        transform.parent = null;

    }
}