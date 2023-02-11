using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float xMin = -2.1f;
    public float xMax = 2.1f;
    public float moveSpeed = 1f;
    public float stamina = 600f;
    public float stopCostPerSecond = 100f;
    public float recoverStaminaPerSecond = 150f;
    public Image staminaBar;

    public GameObject gameController;

    private Vector3 touchPos;
    private Rigidbody2D rb;
    private Vector3 direction;
    private bool isMoving = true;
    private float timeSinceStopped = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = Vector2.right;
    }

    void Update()
    {
        HandleTouchInput();

        if(isMoving){
            MoveBackAndForth();
        }
        
        UpdateStamina();
    }

    private void MoveBackAndForth()
    {
        float lerpValue = Mathf.PingPong(Time.time * moveSpeed, 1);
        transform.position = new Vector2(Mathf.Lerp(xMin, xMax, lerpValue), transform.position.y);
    }

    private void HandleTouchInput()
    {
        // Stop movement
        if (Input.touchCount > 0)
        {
            Debug.Log("is touching");
            Touch touch = Input.GetTouch(0);

            // Stop player if touching and there is enough stamina
            if (touch.phase == TouchPhase.Began)
            {
                if (stamina >= stopCostPerSecond)
                {
                    
                    Time.timeScale = 0.8f;
                    isMoving = false;
                    timeSinceStopped = 0f;
                }
            }

            // Start moving again if touch ends
            if (touch.phase == TouchPhase.Ended)
            {
                isMoving = true;
                Time.timeScale = 1f;
            }
        }
    }

    private void UpdateStamina()
    {
        // Reduce stamina if player is stopped
        if (!isMoving)
        {
            timeSinceStopped += Time.deltaTime;
            stamina -= stopCostPerSecond * timeSinceStopped;
        }

        // Increase stamina if player is moving
        else
        {
            stamina += recoverStaminaPerSecond * Time.deltaTime;
        }

        // Clamp stamina value
        stamina = Mathf.Clamp(stamina, 0, 600f);
        staminaBar.fillAmount = stamina/600;
    }

    //call die function if meteor hits player
    void OnTriggerEnter2D (Collider2D col) {
        if (col.CompareTag("Meteor") == true) {
            gameController.GetComponent<LevelControl>().Die();
        }
    }
}
