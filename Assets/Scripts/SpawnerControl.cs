using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerControl : MonoBehaviour
{
    public AsteroidControl asteroidPrefab;
    public NloControl nloPrefab;

    private int wave = 1;
    private float spawnRate = 10.0f;
    
    private void Awake()
    {
        Spawner.asteroidPrefab = asteroidPrefab;
        Spawner.nloPrefab = nloPrefab;
        Spawner.spawnerTransform = transform;
    }

    private void Start()
    {
        InvokeRepeating( nameof(Spawn), 0.0f, this.spawnRate );
    }

    private void Update ()
    {
        if ( GameData.gameOver )
        {
            CancelInvoke(nameof(Spawn));
        }
    }

    private void Spawn()
    {
        Spawner.SpawnWave( wave );
        wave++;
    }

}
