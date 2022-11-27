using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedEnemysController : MonoBehaviour
{
    [SerializeField]
    public int points = 2;



    void OnDestroy()
    {
        EnemySpawnerManager spawner = FindObjectOfType<EnemySpawnerManager>();

        if (gameObject.tag.Equals("Mole"))
        {
            spawner.enemyOneCount--;
        }
        else
        {
            spawner.enemyTwoCount--;
        }
    }
}
