using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRoomSpawner : MonoBehaviour
{
    [System.Serializable]   
   
   public struct RandomSpawner
    {
        public string name;

        public SpawnerData spawnerData;
    }

    public int EnemyAmountOnLevel;

    public GridController grid;

    public RandomSpawner[] spawnerData;

    void Start()
    {
        //grid = GetComponentInChildren<GridController>();
    }
    //spawning objects stored in spawner data
    public void InitialisObjectSpawning()
    {
        foreach(RandomSpawner rs in spawnerData)
        {
            SpawnObjects(rs);
        }
    }
    //for enemy random spawn position in random amount in given range 
    void SpawnObjects(RandomSpawner data)
    {
        int randomIteration = Random.Range(data.spawnerData.minSpawn, data.spawnerData.maxSpawn + 1);

        for(int i=0; i < randomIteration; i++)
        {
            EnemyAmountOnLevel++;
            int randomPos = Random.Range(0, grid.availablePoints.Count - 1);
            GameObject go = Instantiate(data.spawnerData.itemToSpawn, grid.availablePoints[randomPos], Quaternion.identity, transform) as GameObject;
            grid.availablePoints.RemoveAt(randomPos);
        }
    }
}
