using UnityEngine;
using TMPro;

public class UpdateScoreTxt : MonoBehaviour
{
    private TextMeshProUGUI text;
    
    void Start() 
    {
    	text = GetComponent<TextMeshProUGUI>();
    }
    
    void Update()
    {
    	text.SetText(PlayerPrefs.GetInt("score", 1).ToString());    
    }
}
