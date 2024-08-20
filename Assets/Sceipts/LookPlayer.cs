using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public float speed = 5f; 
    

    private void Update()
    {
        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;

            // the enemy follow the player
            transform.position += direction * speed * Time.deltaTime;

            // makeing the enemy look at the player
            transform.LookAt(player);
        }
    }
   
}
