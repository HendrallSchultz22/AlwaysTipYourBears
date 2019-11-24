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
        PlayerController Bear = other.gameObject.GetComponent<PlayerController>();
        if (isAVictim)
        {
            Bear.Hiber_Health += 5;
        }
        else if (isAHunter)
        {
            Bear.Hiber_Health -= 10;
        }
        else if (isASlippage)
        {
            Bear.movementSpeed = 2.5f;
        }
        else if (iSACart)
        {
            Bear.Hiber_Health -= 5;
        }
        else if (isACactus)
        {
            Bear.Hiber_Health -= 5;
        }
    }
}
