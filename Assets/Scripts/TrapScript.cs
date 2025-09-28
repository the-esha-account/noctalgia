using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerScript player = collision.GetComponent<PlayerScript>();

        if (player != null)
        {
            if (player.transform.position.x > transform.position.x)
            {
                player.Knockback(1);
            }
            else if (player.transform.position.x < transform.position.x)
            {
                player.Knockback(-1);
            }
            else
            {
                player.Knockback(0);
            }
        }
    }
}
