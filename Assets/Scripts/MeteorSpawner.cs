using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject meteorPrefab; // the meteor prefab to be spawned
    public float spawnInterval = 0.9f; // interval between spawning meteors
    public float spawnDistance = 2.3f; // distance at which meteors spawn

    private float spawnTimer = 0.0f; // timer for spawning meteors
    private float difficultyTimer = 0.0f; // timer for increasing difficulty
    private float difficultyInterval = 10.0f; // interval for increasing difficulty
    private float difficultySpawnDelta = 0.1f; // amount of time that is reduced from spawn interval every difficulty change

    void Update()
    {
        spawnTimer += Time.deltaTime; // increment spawn timer
        difficultyTimer += Time.deltaTime; // increment difficulty timer

        if (difficultyTimer >= difficultyInterval)
        {
            difficultyTimer = 0.0f; // reset difficulty timer
            if (spawnInterval -  difficultySpawnDelta >= 0){ // check for invalid spawnInterval
                spawnInterval -= difficultySpawnDelta; // decrease spawn interval
            }
        }

        if (spawnTimer >= spawnInterval)
        {
            spawnTimer = 0.0f; // reset spawn timer

            Vector3 spawnPosition = new Vector3(Random.Range(-spawnDistance, spawnDistance), transform.position.y, 0);
            Quaternion spawnRotation = Quaternion.identity;
            GameObject meteor = Instantiate(meteorPrefab, spawnPosition, spawnRotation);
            meteor.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0), ForceMode2D.Impulse);
        }
    }
}
