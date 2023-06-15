using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public float FollowSpeed = 3f;
    public Transform target;

    private void Update()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y, -100f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed);
    }
}
