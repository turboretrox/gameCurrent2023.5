using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public Transform player;
    public float smothingSpeed = 1f;

    private Vector3 targetPos, newPos;
    public Vector3 minPos, maxPos;

    private void LateUpdate()
    {
        if(transform.position != player.position)
        {
            targetPos = player.position;
            Vector3 newCamBoundaryPos = new Vector3(Mathf.Clamp(targetPos.x, minPos.x, maxPos.x), Mathf.Clamp(targetPos.y, minPos.y, maxPos.y), Mathf.Clamp(targetPos.z, minPos.z, maxPos.z));

            newPos = Vector3.Lerp(transform.position,newCamBoundaryPos, smothingSpeed);
            transform.position = newPos;
        }
    }
}
