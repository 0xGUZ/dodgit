using UnityEngine;

public class DecorationMeteorSpawner : MonoBehaviour
{
    public GameObject meteorPrefab; // the meteor prefab to be spawned
    private float spawnInterval = 0.5f; // interval between spawning meteors
    public float spawnDistance = 2.3f; // distance at which meteors spawn

    private float spawnTimer = 0.0f; // timer for spawning meteors

    void Update()
    {
        spawnTimer += Time.deltaTime; // increment spawn timer

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
