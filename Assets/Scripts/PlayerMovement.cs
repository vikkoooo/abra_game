using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
 
    public float movementSpeed = 15f;
    public Vector2 jumpHeight = new Vector2(0f, 8f);
    public bool isGrounded = false;
    private int n_jumps;
    public Transform wizard;
    private bool isWalking = false;
    private bool wobbleDirection = false;

    // Update is called once per frame
    void Update()
    {
        Jump();
        Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.position += horizontal * Time.deltaTime * movementSpeed;
        
        // Right
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            isWalking = true;
        }
        // Left
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            isWalking = true;
        }
        // Standing still
        else
        {
            isWalking = false;
            wizard.transform.rotation = Quaternion.identity;
        }

        if (isWalking == true)
        {
            Wobble();
        }
        
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            n_jumps = 1;
            GetComponent<Rigidbody2D>().AddForce(jumpHeight, ForceMode2D.Impulse);
        }
        
        else if (Input.GetButtonDown("Jump") && n_jumps == 1)
        {
            n_jumps = 0;
            GetComponent<Rigidbody2D>().AddForce(jumpHeight, ForceMode2D.Impulse);
        }
    }
    
    private void Wobble()
    {
        if (wobbleDirection == true)
        {
            wizard.transform.rotation = Quaternion.Lerp(wizard.transform.rotation, Quaternion.Euler(0, 0, 4), 0.025f);
        }        
        else
        {
            wizard.transform.rotation = Quaternion.Lerp(wizard.transform.rotation, Quaternion.Euler(0,0,-4), 0.025f);
        }

        if (wizard.transform.rotation == Quaternion.Euler(0, 0, 4))
        {
            wobbleDirection = !wobbleDirection;
        }
            
        if (wizard.transform.rotation == Quaternion.Euler(0, 0, -4))
        {
            wobbleDirection = !wobbleDirection;
        }
    }


}
