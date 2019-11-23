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

        public Transform Spawn;
        public bool taken;

        public GenerateNpcs(Transform obj, bool shouldIPlace)
        {

        }

    }
    public List<GenerateNpcs> Generate = new List<GenerateNpcs>();
    public List<GameObject> NpcSpawns;
    public List<Transform> spawnpoints;

    private void Start()
    {
        SpawnNpcs();
    }
   

    void SpawnNpcs()
    {
        foreach (Transform t in spawnpoints)
        {
            int Rand = Random.Range(0, 100);
            bool result = true;
            if (Rand <= 60)
            {
                result = false;
                int VictimSpawn = Random.Range(0, NpcSpawns.Count);
                Instantiate(NpcSpawns[VictimSpawn], t.position, t.rotation);
            }
            else if (Rand <= 85 && Rand > 60)
            {
                result = false;
                int EmptySpawn = Random.Range(0, NpcSpawns.Count);
                Instantiate(NpcSpawns[EmptySpawn], t.position, t.rotation);
            }
            else
            {
                result = false;
                int HunterSpawn = Random.Range(0, NpcSpawns.Count);
                Instantiate(NpcSpawns[HunterSpawn], t.position, t.rotation);
            }
            Generate.Add(new GenerateNpcs(t, result));
            Debug.Log("result" + spawnpoints + Rand + result);
        }

        

    }
}
