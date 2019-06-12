using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawnIntervalMin = 1;
    public float spawnIntervalMax = 3;

    public float heightMin = -5;
    public float heightMax = 5;
    public float heightDeltaMax = 3;

    private float previousHeight = 0;

    // Start is called before the first frame update
    void Start()
    {
        SpawnNext();
    }

    private void SpawnNext()
    {
        Invoke("SpawnPipe", Random.Range(spawnIntervalMin, spawnIntervalMax));
    }

    private void SpawnPipe()
    {
        if (GameController.instance.gameState != GameState.Play)
        {
            return;
        }

        var randomSpawnHeight = Random.Range(previousHeight - heightDeltaMax, previousHeight + heightDeltaMax);
        var newSpawnHeight = Between(heightMin, randomSpawnHeight, heightMax);
        var newSpawnPoint = new Vector2(transform.position.x, newSpawnHeight);

        var pipe = Instantiate(prefab, newSpawnPoint, transform.rotation, transform);
        
        SpawnNext();
    }

    private float Between(float min, float value, float max)
    {
        return Mathf.Max(Mathf.Min(max, value), min);
    }
}
