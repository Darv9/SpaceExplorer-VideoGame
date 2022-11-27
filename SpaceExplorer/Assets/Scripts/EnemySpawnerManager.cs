using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawnerManager : MonoBehaviour
{

    [Header("Spawning Objects")]

    [SerializeField]
    Transform[] spawnPoints;

    [SerializeField]
    Transform[] enemyOnePrefabs;

    [SerializeField]
    Transform[] enemyTwoPrefabs;


    [Header("Spawning Behaviour")]

    [SerializeField]
    float interval = 3.0F;

    [SerializeField]
    int maxObjectsThrow = 3;

    [SerializeField]
    int maxMoleCount = 4;

    [SerializeField]
    int maxBunnyCount = 5;

    [SerializeField]
    float minLifeTime = 2.75F;

    [SerializeField]
    float maxLifeTime = 5.25F;

    float timer = 0.0F;

    [Tooltip("Count the amount of enemy one type showed on screnn")]
    [HideInInspector]
    public int enemyOneCount = 0;

    [Tooltip("Count the amount of enemy 2 type being showed on screnn")]
    [HideInInspector]
    public int enemyTwoCount = 0;

    void Update()
    {
        //Adds to timer the amount of seconds from last frame to the current one
        timer = timer + Time.deltaTime;

        if (timer >= interval)
        {
            SpawnObjects();
            timer = 0.0F;
        }
    }

    /// <summary>
    /// Spawn objects on screnn
    /// </summary>

    private void SpawnObjects()
    {
        for (int i = 1; i <= maxObjectsThrow; i++)
        {
            while (true)
            {
                int spawnPointRandom = Random.Range(0, spawnPoints.Length);
                int childCount =
                    spawnPoints[spawnPointRandom].GetComponentsInChildren<SpawnedEnemysController>().Count();

                if (childCount == 0)
                {
                    Transform[] prefabs = null;
                    int spawnType = Random.Range(0, 2);

                    switch (spawnType)
                    {
                        case 0:
                            if (enemyOneCount < maxMoleCount)
                            {
                                enemyOneCount++;
                                prefabs = enemyOnePrefabs;

                            }
                            break;

                        default:
                            if (enemyTwoCount < maxBunnyCount)
                            {
                                enemyTwoCount++;
                                prefabs = enemyTwoPrefabs;
                            }
                            break;
                    }

                    if (prefabs != null)
                    {
                        int index = Random.Range(0, prefabs.Length);

                        //Create a new instance of a random prefab
                        Transform instance =
                            Instantiate(prefabs[index], spawnPoints[spawnPointRandom]);

                        float lifeTime = Random.Range(minLifeTime, maxLifeTime);
                        Destroy(instance.gameObject, lifeTime);

                        //Finishes the while cycle
                        break;
                    }
                }
            }
        }
    }
}
