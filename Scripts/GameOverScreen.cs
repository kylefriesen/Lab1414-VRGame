using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.ProBuilder;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameOverScreen : MonoBehaviour
{

    public TextMeshPro ScoreText;

   

    public GameObject damageUI;
    // Start is called before the first frame update
    void Start()
    {
        
        float Currentscore = PlayerPrefs.GetFloat("CurrentScore");
        
        ScoreText.text = "Score: " + Currentscore.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            damageUI.GetComponent<FadeScreen>().FadeOut();
            SceneManager.LoadScene("level1");


        }
    }


}
