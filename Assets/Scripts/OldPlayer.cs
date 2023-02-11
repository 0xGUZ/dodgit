using UnityEngine;

public class OldPlayer : MonoBehaviour
{
    public float xMin = -2f;
    public float xMax = 2f;
    
    public GameObject gameController;

    //touch move stuff
    private Vector3 touchPos;
    private Rigidbody2D rb;
    private Vector3 direction;
    private float moveSpeed = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //mobile movement => if is touching "follow" if not stop / drag move (ONLY X ASIS)
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            touchPos.z = 0;
            touchPos.y = transform.position.y; // keep the y position constant
            direction = (touchPos - transform.position);
            rb.velocity = new Vector2 (direction.x, 0) * moveSpeed; // only use the x component of the velocity

            if(touch.phase == TouchPhase.Ended)
            {
                rb.velocity = Vector2.zero;
            }
        }

        //move with keyboard -- mainly to test
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

    //call die function if meteor hits player
    void OnTriggerEnter2D (Collider2D col) {
        if (col.CompareTag("Meteor") == true) {
            gameController.GetComponent<LevelControl>().Die();
        }
    }
}
