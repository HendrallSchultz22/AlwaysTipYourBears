using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawn : MonoBehaviour
{
    [System.Serializable]
    public class Objects
    {
        public GameObject FlowerPot;
        public GameObject Empty;
        public GameObject Slippage;
        public GameObject HousekeepingCart;

    }
    public List<Objects> ObjectSpawns;
    public List<Transform> spawnpoints;
    void Start()
    {
        SpawnObjects();
    }

    void SpawnObjects()
    {
        foreach (Transform t in spawnpoints)
        {
            int Rand = Random.Range(0, 100);
            if (Rand <= 7)
            {
                int FlowerPotSpawn = Random.Range(0, ObjectSpawns.Count);
                Instantiate(ObjectSpawns[FlowerPotSpawn].FlowerPot, t.position, t.rotation);
            }
            else if (Rand <= 50 && Rand > 7)
            {
                int EmptySpawn = Random.Range(0, ObjectSpawns.Count);
                Instantiate(ObjectSpawns[EmptySpawn].Empty, t.position, t.rotation);
            }
            else if (Rand <= 90 && Rand > 50)
            {
                int SlippageSpawn = Random.Range(0, ObjectSpawns.Count);
                Instantiate(ObjectSpawns[SlippageSpawn].Slippage, t.position, t.rotation);
            }
            else
            {
                int HouseKeepingCartSpawn = Random.Range(0, ObjectSpawns.Count);
                Instantiate(ObjectSpawns[HouseKeepingCartSpawn].HousekeepingCart, t.position, t.rotation);
            }
        }
    }
}
