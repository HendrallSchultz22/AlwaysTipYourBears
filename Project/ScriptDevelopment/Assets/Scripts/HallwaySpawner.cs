using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class HallwaySpawner : MonoBehaviour
{
    [System.Serializable]
    public class Hallways
    {
        public GameObject HallA;
        public GameObject HallB;
    }

    public List<Hallways> ScenerySpawns;
    public List<Transform> spawnpoints;
    //Vector3 Spacing = new Vector3(6, 0, 0);
    //Vector3 SpaceStart = new Vector3(0, .5f, 0);
    private void Start()
    {
        //SpawnSpawnPoints();
        SpawnScenery();
    }
    private void FixedUpdate()
    {
        
    }
    //void SpawnSpawnPoints()
    //{
    //    Vector3 Previous = new Vector3(0, 0, 0);
    //    Instantiate(spawnpoints[0], SpaceStart, Quaternion.identity);
    //    Instantiate(spawnpoints[1], SpaceStart + Spacing, Quaternion.identity);
    //    Previous = SpaceStart + Spacing;
    //    Instantiate(spawnpoints[2], Previous + Spacing, Quaternion.identity);
    //    Previous = Previous + Spacing;
    //    Instantiate(spawnpoints[3], Previous + Spacing, Quaternion.identity);
        
    //}
    void SpawnScenery()
    {
        foreach (Transform t in spawnpoints)
        {
            int Rand = Random.Range(0, 100);
            if (Rand < 50)
            {
                int HallSpawn = Random.Range(0, ScenerySpawns.Count);
                Instantiate(ScenerySpawns[HallSpawn].HallA, t.position, Quaternion.identity);
                
            }
            else
            {
                int HallTwoSpawn = Random.Range(0, ScenerySpawns.Count);
                Instantiate(ScenerySpawns[HallTwoSpawn].HallB, t.position, Quaternion.identity);
                

            }
        }

        
    }

    
}
