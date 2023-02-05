using UnityEngine;

public class MoveAndReposition : MonoBehaviour
{
    private Camera mainCamera;
    private float speed = 0.005f;

    private void Start()
    {
        mainCamera = Camera.main;

        foreach (Transform child in transform)
        {
            float x = Random.Range(mainCamera.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).x, mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x);
            float y = Random.Range(mainCamera.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).y, mainCamera.ScreenToWorldPoint(new Vector3(0f, Screen.height, 0f)).y);

            child.position = new Vector3(x, y, 0f);
        }
    }

    private void Update()
    {
        foreach (Transform child in transform)
        {
            child.position += new Vector3(0f, -speed, 0f);

            if (child.position.y < mainCamera.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).y)
            {
                float x = Random.Range(mainCamera.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).x, mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x);
                float y = mainCamera.ScreenToWorldPoint(new Vector3(0f, Screen.height, 0f)).y;

                child.position = new Vector3(x, y, 0f);
            }
        }
    }
}
