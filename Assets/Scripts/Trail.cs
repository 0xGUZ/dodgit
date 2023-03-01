using UnityEngine;

public class Trail : MonoBehaviour
{
    public float trailTime = 1f;
    public float startWidth = 0.3f;
    public float endWidth = 0.1f;
    
    private TrailRenderer trailRenderer;
    private float timer = 0f;
    
    void Start()
    {
        trailRenderer = GetComponent<TrailRenderer>();
        trailRenderer.startWidth = startWidth;
        trailRenderer.endWidth = endWidth;
    }
    
    void Update()
    {
        timer += Time.deltaTime;
        
        if (timer < trailTime)
        {
            float t = timer / trailTime;
            trailRenderer.startWidth = Mathf.Lerp(startWidth, endWidth, t);
            trailRenderer.endWidth = Mathf.Lerp(startWidth, endWidth, t);
        }
    }
}

