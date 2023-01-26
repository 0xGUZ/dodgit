using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public GameObject p5prefab; //+5 text
    private int score;

    void Start()
    {
        score = PlayerPrefs.GetInt("score", 0);
    }

    void Update()
    {
        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.Save();
    }

    void OnTriggerEnter2D (Collider2D col) {
        if(col.CompareTag("Meteor") == true){
            score += 5;
            
            Vector3 p5position = new Vector3 (0, 0, 0);
            //Instantiate(p5prefab, p5position, Quaternion.identity);
        }
    }
}
