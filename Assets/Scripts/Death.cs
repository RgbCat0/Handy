using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public bool breaker;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            while (true)
            {
                if (breaker)
                    break;
            }
            Debug.Log("You died.");
        }
    }
}
