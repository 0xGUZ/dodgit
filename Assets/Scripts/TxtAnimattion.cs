using UnityEngine;
using TMPro;

public class TxtAnimattion : MonoBehaviour
{
    TextMeshProUGUI text;
    float size;
    int isGrowing;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        size = 90.0f;
        text.fontSize = size;
        isGrowing = 1;
    }

    void Update()
    {
        text.fontSize = size;

        if(isGrowing == 1){

            if(size >= 100.0f){
                isGrowing = 0;
                size -= 0.2f;
            }

            else{
                size += 0.2f;
            }
        }

        else {

            if(size <= 90.0f){
                isGrowing = 1;
                size += 0.2f;
            }
        
            else{
                size -= 0.2f;
            }
        }
    }
}
