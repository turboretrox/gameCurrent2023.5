using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{
    public Transform AttackPos;
    public GameObject bullet;
  
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            AttackOO();
        }
    }
    void AttackOO()
    {
        Instantiate(bullet, AttackPos.position, AttackPos.rotation);
    }


}
