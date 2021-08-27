using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrounded : MonoBehaviour
{
    private GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = transform.parent.gameObject;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            player.GetComponent<PlayerMovement_2>().isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            player.GetComponent<PlayerMovement_2>().isGrounded = false;
        }
    }
}
