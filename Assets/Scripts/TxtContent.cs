using UnityEngine;
using TMPro;

public class TxtContent : MonoBehaviour
{

    void Start()
    {
        GetComponent<TextMeshProUGUI>().SetText("Level " + (PlayerPrefs.GetInt("currentLevel", 1) - 1).ToString());
    }

}
