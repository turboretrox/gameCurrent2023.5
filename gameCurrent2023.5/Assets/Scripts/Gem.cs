using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gem : MonoBehaviour
{
    public static int GemsNum = 0;
    public Text GemText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GemsNum++;
            GemText.text = GemsNum.ToString();
            Destroy(gameObject);
        }
    }
}
