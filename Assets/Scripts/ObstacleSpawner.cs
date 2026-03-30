using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float spawnInterval = 2f;
    public float rangeX = 3f;

    void Start()
    {
        InvokeRepeating("SpawnObstacle", 2f, spawnInterval);
    }

    void SpawnObstacle()
    {
        float randomX = Random.Range(-rangeX, rangeX);
        Vector3 pos = new Vector3(randomX, 0.5f, transform.position.z);

        Instantiate(obstaclePrefab, pos, Quaternion.identity);
    }
}