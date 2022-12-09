using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


//Clase que controla los spawns de los enemigos
public class EnemySpawnerManager : MonoBehaviour
{
    public List<GameObject> enemysToSpawn;
    public List<Transform> spawnPoints;
    private int randomSpawnPoint;
    private int randomEnemy;
    public List<Transform> OldSpawnPoints;
    private int prefabLifeTime = 2;

    void Update()
    {
        //Se invoca el metodo para que ocurra cada 0.5 segundos
        Invoke("SpawnAtRandom", 1.5F);
    }

    void SpawnAtRandom()
    {
        //Se define el lugar random y el enemigo random que va a hacer spawn
        randomSpawnPoint = Random.Range(0, spawnPoints.Count);
        randomEnemy = Random.Range(0, enemysToSpawn.Count);


        //Se verifica que no haya otro eneimgo en el mismo lugar
        if (!OldSpawnPoints.Contains(spawnPoints[randomSpawnPoint]))
        {
            Transform OldSpawn = spawnPoints[randomSpawnPoint];
            OldSpawnPoints.Add(OldSpawn);
            ////Se destruye el animal que hizo spawn despues de 2 segundos de vida
            //Destroy(Instantiate(animalsToSpawn[randomAnimal], spawnHoles[randomSpawnHole].transform), prefabLifeTime);
            //OldSpawnPoints.Clear();
        }
        CancelInvoke();
    }

    public GameObject GetObject(int index)
    {
        GameObject indexObject = enemysToSpawn[index];
        return indexObject;
    }
}