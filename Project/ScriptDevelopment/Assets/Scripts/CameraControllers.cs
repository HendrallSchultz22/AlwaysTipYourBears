using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllers : MonoBehaviour
{
    public Transform targetTransform;
    Vector3 tempVec3 = new Vector3();

    void LateUpdate()
    {
        tempVec3.x = this.targetTransform.position.x;
        tempVec3.y = this.transform.position.y;
        tempVec3.z = targetTransform.position.z - 2;
        this.transform.position = tempVec3;
    }
}
