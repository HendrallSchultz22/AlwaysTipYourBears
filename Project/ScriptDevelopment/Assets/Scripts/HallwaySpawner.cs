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

    [Header("Contents")]
    public List<Hallways> ScenerySpawns;
    public GameObject Hallway;
    public int hallwayCount;
    public int hallwayMax;

    [Header("Instantiated Objects")]
    public List<GameObject> _instantiatedObjects;

    float squareSize = 1.0f;

    public GameObject _instance;

    private void FixedUpdate()
    {
        _instantiatedObjects.Capacity = hallwayMax; // Hallway max
        hallwayCount = _instantiatedObjects.Count;  // Hallway count
        DetectHallways(hallwayMax);                 // Spawns Hallways.
        UpdateList();                               // Update the _instance List

        if (hallwayCount > hallwayMax)
        {
            hallwayCount = hallwayMax;
        }
    }

    void DetectHallways(int hallwayMax)
    {
        // Allows random Hallways to be used
        int Rand = Random.Range(0, 100);
        if (Rand < 50)
        {
            int HallSpawn = Random.Range(0, ScenerySpawns.Count);
            _instance = ScenerySpawns[HallSpawn].HallA;
        }
        else
        {
            int HallTwoSpawn = Random.Range(0, ScenerySpawns.Count);
            _instance = ScenerySpawns[HallTwoSpawn].HallB;
        }

        // Spawns Hallways
        if (hallwayCount < hallwayMax)
        {
            _instantiatedObjects.Add(_instance); // Adds created _instance into List

            Vector3 objectPos = _instance.transform.position; // Set Vector3 for _instance

            for (int i = _instantiatedObjects.Count + 1; i < hallwayMax; i++)
            {
                objectPos.z += 1; // Previous object's position + 10 is the spawn point for _instance
            }

            Instantiate(_instance, objectPos, Quaternion.identity); // Instantiate _instance
        }
    }

    void OnApplicationQuit() // This is to prevent objects from modifying the Prefab's starting location.
    {
        _instance.transform.position = new Vector3(-0.5f, 0f, 0f);

#if UNITY_EDITOR
        ScenerySpawns[0].HallA.transform.position = new Vector3(-0.5f, 0f, 0f);
        ScenerySpawns[0].HallB.transform.position = new Vector3(-0.5f, 0f, 0f);
#endif
    }

    void UpdateList()
    {
        // If an object is "null", delete them. Make space for a new one.
        for (int i = _instantiatedObjects.Count - 1; i > -1; i--)
        {
            if (_instantiatedObjects[i] == null)
            {
                _instantiatedObjects.RemoveAt(i);
                // hallwayMax++;
                // hallwayCount++;
            }
        }
    }
}