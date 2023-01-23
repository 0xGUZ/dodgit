using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.GetInt("level", 0);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
