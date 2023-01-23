using UnityEngine;

public class Meteor : MonoBehaviour
{
    void Update()
    {
        if (transform.position.y <= -30f){
            Destroy(gameObject);
        }
    }
}
