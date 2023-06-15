using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public static double HealNum = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            HealNum += 0.5;
            Debug.Log("Health: " +  HealNum);
            Destroy(gameObject);
        }
    }
}
