using UnityEngine;
using System.Collections.Generic;

public class Level : MonoBehaviour
{
    public List<EnemyWave> waves;
    public List<SpawnPoint> spawnPoints;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnPoints = new List<SpawnPoint>(FindObjectsByType<SpawnPoint>(FindObjectsInactive.Exclude, FindObjectsSortMode.None));
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
