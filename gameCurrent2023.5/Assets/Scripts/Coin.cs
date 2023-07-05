using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{

    int ScoreNum = 0;
    public Text scoreText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            ScoreNum += 10;
            scoreText.text = "Score: " + ScoreNum.ToString();
        }
    }
}
