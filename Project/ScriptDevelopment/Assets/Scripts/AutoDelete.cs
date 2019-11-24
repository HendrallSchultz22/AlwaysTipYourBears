using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDelete : MonoBehaviour
{
    [Header("Controls")]
    public bool isActivated = false;
    public float timeFrame; // How much time until it's despawned.

    void OnTriggerEnter(Collider other)
    {
        // Despawn player if they enter through the trigger.
        if (other.gameObject.GetComponent<PlayerController>())
        {
            Destroy(gameObject.GetComponentInParent<SolidSurface>().gameObject, timeFrame);
        }
    }

}
