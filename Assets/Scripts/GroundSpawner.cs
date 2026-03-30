using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundPrefab;
    public float spawnZ = 0;
    public float groundLength = 30f;
    public int numberOfTiles = 5;

    void Start()
    {
        for (int i = 0; i < numberOfTiles; i++)
        {
            SpawnTile();
        }
    }

    public void SpawnTile()
    {
        Instantiate(groundPrefab, new Vector3(0, 0, spawnZ), Quaternion.identity);
        spawnZ += groundLength;
    }
}