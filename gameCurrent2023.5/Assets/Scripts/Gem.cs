using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public static int GemsNum = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GemsNum++;
            Debug.Log("Gems :" + GemsNum);
            Destroy(gameObject);
        }
    }
}
