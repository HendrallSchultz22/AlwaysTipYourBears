using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class HallwaySpawner : MonoBehaviour
{
    /*[System.Serializable]
    public class Hallways
    {
        public GameObject HallA;
        public GameObject HallB;
    }

    public List<Hallways> ScenerySpawns;*/

    [Header("Contents")]
    public GameObject Hallway;
    public GameObject StartingLocation;
    public int hallwayCount;
    public int hallwayMax;
    public List<GameObject> _instantiatedObjects;

    private void FixedUpdate()
    {
        // _instantiatedObjects.Capacity = hallwayMax;

        hallwayCount = _instantiatedObjects.Count;

        if (hallwayCount > hallwayMax)
        {
            hallwayCount = hallwayMax;
        }

        if (hallwayCount < hallwayMax)
        {
            _instantiatedObjects.AddRange(GameObject.FindGameObjectsWithTag("Ground"));
        }

        DetectHallways(hallwayMax);
    }

    void DetectHallways(int hallwayMax)
    {
        GameObject _instance;

        _instance = Hallway;

        if (hallwayCount < hallwayMax)
        {
            Instantiate(_instance);

            _instance.transform.position += new Vector3(0, 0, 10);
        }
    }
    
    /*void SpawnScenery()
    {
        foreach (GameObject t in _instantiatedObjects)
        {
            int Rand = Random.Range(0, 100);
            if (Rand < 50)
            {
                int HallSpawn = Random.Range(0, ScenerySpawns.Count);
                Instantiate(ScenerySpawns[HallSpawn].HallA, t.transform.position, Quaternion.identity);

            }
            else
            {
                int HallTwoSpawn = Random.Range(0, ScenerySpawns.Count);
                Instantiate(ScenerySpawns[HallTwoSpawn].HallB, t.transform.position, Quaternion.identity);


            }
        }
    }*/
}