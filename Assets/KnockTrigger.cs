using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockTrigger : MonoBehaviour
{
    public bool playerDeath = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerDeath = true;
            collision.gameObject.GetComponent<TrainEngineController>().isDie = true;
            
        }
    }
}
