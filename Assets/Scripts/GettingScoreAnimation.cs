using UnityEngine;
using TMPro;

public class GettingScoreAnimation : MonoBehaviour
{
    private float startTime;
    private TextMeshProUGUI text;

    void Start()
    {
        startTime  = Time.timeSinceLevelLoad;
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.fontSize -= 2f;
        if ((Time.timeSinceLevelLoad - startTime) >= 1f) {
            Destroy(gameObject);
        }
    }
}
