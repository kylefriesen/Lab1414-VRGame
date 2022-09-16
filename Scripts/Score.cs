using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshPro Text;
    public int score;

    float Currentscore;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Text = GetComponent<TextMeshPro>();
        float Currentscore = PlayerPrefs.GetFloat("CurrentScore");
        
    }

    // Update is called once per frame
    void Update()
    {
        Text.text = "Score: " + score.ToString();
    }
    
    public void EndScore()
    {
        PlayerPrefs.SetFloat("CurrentScore", score);
        
    }
}
