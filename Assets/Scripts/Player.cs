using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private float speed = 4f;
    private float stamina = 500f;
    private float stopCostPerSecond = 100f;
    private float recoverStaminaPerSecond = 100f;
    public Image staminaBar;

    public GameObject gameController;

    private int isGrowing;
    private float xPos;
    private float originalPos;
    private bool isMoving = true;
    private float timeSinceStopped = 0f;

    void Start()
    {
        originalPos = transform.position.x;
        isGrowing = 1;
    }

    void Update()
    {
        HandleTouchInput();
        HandleKeyInput();

        UpdateStamina();

        if(isMoving){
            MoveBackAndForth();
        }        
    }

    public float movementRangeMultiplier = 0.4f;

    private void MoveBackAndForth()
    {
        // Calculate movement range based on screen size
        float cameraHeight = Camera.main.orthographicSize * 2.0f;
        float cameraWidth = cameraHeight * Camera.main.aspect;
        float movementRange = cameraWidth * movementRangeMultiplier;

        // Calculate current x position and movement limits
        float xPos = transform.position.x - originalPos;
        float xMax = originalPos + movementRange;
        float xMin = originalPos - movementRange;

        // Move the object back and forth
        if(isGrowing == 1){

            if(xPos >= xMax){
                isGrowing = 0;
            }

            xPos += speed * Time.deltaTime;
        }

        else {

            if(xPos <= xMin){
                isGrowing = 1;
            }

            xPos -= speed * Time.deltaTime;
        }

        transform.position = new Vector3(xPos + originalPos, transform.position.y, transform.position.z);
    }

    private void HandleTouchInput()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary && (stamina >= stopCostPerSecond))
        {
            Time.timeScale = 0.7f;
            isMoving = false;
            timeSinceStopped = 0f;
        }

        else 
        {
            Time.timeScale = 1f;
            isMoving = true;
        }
    }


    private void HandleKeyInput()
    {
        if (Input.GetKey(KeyCode.Space) && (stamina >= stopCostPerSecond)) 
        {
            Time.timeScale = 0.7f;
            isMoving = false;
            timeSinceStopped = 0f;
        }           

        else 
        {
            Time.timeScale = 1f;
            isMoving = true;
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
        stamina = Mathf.Clamp(stamina, 0, 500f);
        staminaBar.fillAmount = (stamina-100) / 400;
    }

    //call die function if meteor hits player
    void OnTriggerEnter2D (Collider2D col) {
        if (col.CompareTag("Meteor") == true) {
            gameController.GetComponent<LevelControl>().Die();
        }
    }
}
