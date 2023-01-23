using UnityEngine;

public class Player : MonoBehaviour
{
    public float xMin = -2.4f;
    public float xMax = 2.4f;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Moved)
            {
                float xPos = touch.position.x;
                xPos = Mathf.Clamp(xPos, xMin, xMax);
                rb.MovePosition(new Vector2(xPos, transform.position.y));
            }
        }

        else {
            float xPos = transform.position.x;
            if (Input.GetKey(KeyCode.A))
            {
                xPos -= 0.1f;
            }
            if (Input.GetKey(KeyCode.D))
            {
                xPos += 0.1f;
            }
            xPos = Mathf.Clamp(xPos, xMin, xMax);
            rb.MovePosition(new Vector2(xPos, transform.position.y));
        }
    }
}
