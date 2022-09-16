using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.SocialPlatforms.Impl;

public class Health : MonoBehaviour
{
    
    public int HealthNumber;

    public bool isPlayer = false;

    public int ScoreReward;

    public Transform explosionPrefab;

    private GameObject GameManager;

    public GameObject AIroot;

    

    public GameObject damageUI;

   
    public TextMeshPro HealthUI;



    
    void Start()
    {
        GameManager = GameObject.FindWithTag("ScoreCounter");
        
    }

    
    void Update()
    {
        if (isPlayer)
        {


            HealthUI.text = HealthNumber.ToString();

        }

        


        if (HealthNumber <= 0)
        {
            if (isPlayer)
            {


                DiePlayer();

            }
           
            else
            {
                DieAI();
            }
            

        }
    }

    void DieAI()
    {
        
        var Playerscore = GameManager.GetComponent<Score>();
        Playerscore.score += ScoreReward;
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(AIroot);
    }

    void DiePlayer()
    {
        
        damageUI.GetComponent<FadeScreen>().FadeOut();
        GameManager.GetComponent<Score>().EndScore();
        
        
        SceneManager.LoadScene("GameOver");
    }

    public void DamagePlayer()
    {
        

        
        damageUI.GetComponent<FadeScreen>().DamageFade();
        


    }
}