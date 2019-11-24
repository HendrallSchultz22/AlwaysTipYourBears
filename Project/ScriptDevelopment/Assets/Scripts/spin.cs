using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spin : MonoBehaviour
{
    public GameObject spinPoint;
    public Vector3 SpinRatio = Vector3.zero;
    public bool point = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spinning();
    }
    public void spinning()
    {
        if(point)
        {
            if (spinPoint.transform.eulerAngles.y >= 180)
            {
                point = false;
            }
            spinPoint.transform.Rotate(SpinRatio * Time.deltaTime);
        }
     
    }
}