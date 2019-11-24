using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{

    public GameObject hall;
    public List<Transform> spawnpoints;
    private List<GameObject> halls;
    public GameObject manager;

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameController");
       if (manager.GetComponent<mang>().count < 500)
        {
            generate();
        }
    }
    void generate()
    {
        
        foreach (Transform t in spawnpoints)
        {           
                Instantiate(hall, t.position, t.rotation);
                manager.GetComponent<mang>().count++;         
        }
    }
}
