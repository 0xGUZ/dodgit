using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleAnimation : MonoBehaviour
{
    float originalPos;
    int isGrowing;
    float xPos;

    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.position.x;
        isGrowing = 1;
    }

    // Update is called once per frame
    void Update()
    {
        xPos = transform.position.x - originalPos;
        
        if(isGrowing == 1){

            if(xPos >= 0.2f){
                isGrowing = 0;
                xPos -= 0.0005f;
            }

            else{
                xPos += 0.0005f;
            }
        }

        else {

            if(xPos <= -0.2f){
                isGrowing = 1;
                xPos += 0.0005f;
            }
        
            else{
                xPos -= 0.0005f;
            }
        }

        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
    }
}
