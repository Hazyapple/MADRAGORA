using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionDamage : MonoBehaviour
{

    private float damage = 1;

    private void OnCollisionEnter2D(Collision2D other)
    {
        DamageEnemyPL(other); 
    
    }

    public void DamageEnemyPL(Collision2D other)
    {
        if (other.transform.tag == "Player")
        {
            other.transform.GetComponent<PlayerLife>();
        }
    }


}

