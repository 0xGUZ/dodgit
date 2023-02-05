using UnityEngine;

public class Meteor : MonoBehaviour
{
    public float speed = 6f;
    private float rotationSpeedMin = 10f;
    private float rotationSpeedMax = 30f;
    private float scaleMin = 0.5f;
    private float scaleMax = 0.7f;

    private float rotationSpeed;

    private void Start()
    {
        float randomScale = Random.Range(scaleMin, scaleMax);
        transform.localScale = new Vector3(randomScale, randomScale, 1f);
        
        rotationSpeed = Random.Range(rotationSpeedMin, rotationSpeedMax);
    }

    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
        
        if (transform.position.y <= -10f){
            Destroy(gameObject);
        }
    }
}