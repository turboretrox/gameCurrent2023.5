using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTrigger : MonoBehaviour
{
    public Vector3 newCamPos, newPlayerPos;
    CamController camController;

    private void Start()
    {
        camController = Camera.main.GetComponent<CamController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            camController.minPos += newCamPos;
            camController.maxPos += newCamPos;

            collision.transform.position += newPlayerPos;
        }
    }
}
