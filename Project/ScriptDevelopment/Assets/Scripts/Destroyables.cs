using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyables : MonoBehaviour
{
    public bool isAVictim;
    public bool isAHunter;
    public bool isACactus;
    public bool iSACart;
    public bool isASlippage;

    private void OnTriggerEnter(Collider other)
    {
       
        if (isAVictim)
        {
            PlayerController.Hiber_Health += 5;
        }
        else if (isAHunter)
        {
            PlayerController.Hiber_Health -= 10;
        }
        
        else if (iSACart)
        {
            PlayerController.Hiber_Health -= 5;
        }
        else if (isACactus)
        {
            PlayerController.Hiber_Health -= 5;
        }
    }
}
