using UnityEngine;

public class DecorationMeteorSpawner : MonoBehaviour
{
    public GameObject meteorPrefab; // the meteor prefab to be spawned
    private float spawnInterval = 1.4f; // interval between spawning meteors
    public float spawnDistance = 2.3f; // distance at which meteors spawn

    private float spawnTimer = 0.0f; // timer for spawning meteors
    private float difficultyTimer = 0.0f; // timer for increasing difficulty
    private float difficultyInterval = 10.0f; // interval for increasing difficulty

    void Update()
    {
        spawnTimer += Time.deltaTime; // increment spawn timer
        difficultyTimer += Time.deltaTime; // increment difficulty timer

        if (difficultyTimer >= difficultyInterval)
        {
            difficultyTimer = 0.0f; // reset difficulty timer
            spawnInterval -= 0.1f; // decrease spawn interval
        }

        if (spawnTimer >= spawnInterval)
        {
            spawnTimer = 0.0f; // reset spawn timer

            Vector3 spawnPosition = new Vector3(Random.Range(-spawnDistance, spawnDistance), 6, 0);
            Quaternion spawnRotation = Quaternion.identity;
            GameObject meteor = Instantiate(meteorPrefab, spawnPosition, spawnRotation);
            meteor.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0), ForceMode2D.Impulse);
        }
    }
}
