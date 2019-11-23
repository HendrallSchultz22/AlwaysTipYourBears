using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcSpawn : MonoBehaviour
{
    [System.Serializable]
    public class GenerateNpcs
    {
        public GameObject Victim;
        public GameObject Empty;
        public GameObject Hunter;
    }
    public List<GenerateNpcs> Generate = new List<GenerateNpcs>();
    public List<Transform> spawnpoints;
    void Start()
    {
        SpawnNpcs();
    }
    void SpawnNpcs()
    {
        foreach (Transform t in spawnpoints)
        {
            int Rand = Random.Range(0, 100);
            if (Rand <= 60)
            {
                int VictimSpawn = Random.Range(0, Generate.Count);
                Instantiate(Generate[VictimSpawn].Victim, t.position, t.rotation);
            }
            else if (Rand <= 85 && Rand > 60)
            {
                int EmptySpawn = Random.Range(0, Generate.Count);
                Instantiate(Generate[EmptySpawn].Empty, t.position, t.rotation);
            }
            else
            {
                int HunterSpawn = Random.Range(0, Generate.Count);
                Instantiate(Generate[HunterSpawn].Hunter, t.position, t.rotation);
            }
        }
    }
}
