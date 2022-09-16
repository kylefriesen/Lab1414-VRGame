using Facebook.WitAi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Projectile : MonoBehaviour
{



    public Transform explosionPrefab;

    public int damage;

    public GameObject child;

    

    void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 position = contact.point;
        Instantiate(explosionPrefab, transform.position, transform.rotation);

        

        
        

        
        Destroy(gameObject);

        var targetHealth = collision.gameObject.GetComponentInParent<Health>();
        targetHealth.HealthNumber -= damage;

        collision.gameObject.GetComponentInParent<Health>().DamagePlayer();
    }

    
}    

