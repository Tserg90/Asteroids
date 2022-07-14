using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Spawner
{

    public static AsteroidControl asteroidPrefab;
    public static NloControl nloPrefab;
    public static Transform spawnerTransform;

    public static void SpawnWave ( int wave )
    {
        float spawnDistance = 15.0f;
        float trajectoryVariance = 15.0f;
        bool is_nloSpawn = false;

        for ( int i = 0; i<wave; i++ )
        {
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * spawnDistance;
            Vector3 spawnPoint = spawnerTransform.position + spawnDirection;

            float variance = Random.Range( -trajectoryVariance, trajectoryVariance );
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

            AsteroidControl asteroid = Object.Instantiate( asteroidPrefab, spawnPoint, rotation );
            asteroid.SetAsteroidLevel(1);
            asteroid.CreatAsteroid();
            asteroid.MoveAsteroid(rotation * -spawnDirection);

            if (!is_nloSpawn)
            {
                NloControl nlo = Object.Instantiate( nloPrefab, spawnPoint, rotation );
                is_nloSpawn = !is_nloSpawn;
            }
        }

    }

    public static void SpawnSplit ( int splitLevel, Vector2 spawnPoint )
    {
        for ( int i = 0; i<2; i++ )
        {
            spawnPoint += Random.insideUnitCircle * 0.5f;
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * 15.0f;
            Quaternion rotation = Random.rotation;

            AsteroidControl asteroid = Object.Instantiate( asteroidPrefab, spawnPoint, Random.rotation );
            asteroid.SetAsteroidLevel(splitLevel);
            asteroid.CreatAsteroid();
            asteroid.MoveAsteroid( Random.insideUnitCircle.normalized * 13.0f);
        }
    }
}
