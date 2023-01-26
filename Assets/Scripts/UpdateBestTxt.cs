using UnityEngine;
using TMPro;

public class UpdateBestTxt : MonoBehaviour
{
    private TextMeshProUGUI text;
    
    void Start() 
    {
    	text = GetComponent<TextMeshProUGUI>();
  	text.SetText("Best: " + PlayerPrefs.GetInt("bestScore", 0).ToString());
    }
    
    void Update()
    {
    	if ((PlayerPrefs.GetInt("score", 0)) > (PlayerPrefs.GetInt("bestScore", 0))) {
    		PlayerPrefs.SetInt("bestScore", PlayerPrefs.GetInt("score"));
    		PlayerPrefs.Save();
    	}
    	
    	text.SetText("Best: " + PlayerPrefs.GetInt("bestScore", 0).ToString());    
    }
}
