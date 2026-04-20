using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {
    [SerializeField] private GameObject obstaclePrefab;

    [SerializeField] private float worldSpeed = 10f;
    [SerializeField] private float firstSpawnZ = 20f;
    [SerializeField] private float distanceBetweenRows = 12f;
    [SerializeField] private int rowsAhead = 10;

    [SerializeField] private float[] lanePositions = { -3f, 0f, 3f };

    private readonly bool[][] obstaclePatterns = {
        new[] { true, false, false },
        new[] { false, true, false },
        new[] { false, false, true },

        new[] { true, true, false },
        new[] { true, false, true },
        new[] { false, true, true }
    };

    private float nextSpawnZ;
    private float simulatedPlayerZ;

    private void Start() {
        nextSpawnZ = firstSpawnZ;

        for (int i = 0; i < rowsAhead; i++) {
            SpawnObstacleRow();
        }
    }

    private void Update() {
        simulatedPlayerZ += worldSpeed * Time.deltaTime;

        while (nextSpawnZ < simulatedPlayerZ + rowsAhead * distanceBetweenRows) {
            SpawnObstacleRow();
        }
    }

    private void SpawnObstacleRow() {
        bool[] selectedPattern = obstaclePatterns[
            Random.Range(0, obstaclePatterns.Length)
        ];

        for (int laneIndex = 0; laneIndex < lanePositions.Length; laneIndex++) {
            if (!selectedPattern[laneIndex]) {
                continue;
            }

            Vector3 obstaclePosition = new Vector3(
                lanePositions[laneIndex],
                0.5f,
                nextSpawnZ
            );

            Instantiate(obstaclePrefab, obstaclePosition, Quaternion.identity);
        }

        nextSpawnZ += distanceBetweenRows;
    }
}