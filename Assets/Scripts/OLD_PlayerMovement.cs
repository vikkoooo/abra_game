using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OLD_PlayerMovement : MonoBehaviour
{

    public float movementSpeed = 15f;
    public Vector2 jumpHeight = new Vector2(0f, 7f);
    public bool isGrounded = false;
    private int n_jumps;
    public Transform wizard;

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
            WobbleRight();
        }
        // Left
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            WobbleLeft();
        }
        // Standing still
        else
        {
            wizard.transform.rotation = Quaternion.identity;
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



    private void WobbleRight()
    {
        wizard.transform.rotation = Quaternion.Lerp(wizard.transform.rotation, Quaternion.Euler(0,0,4), 0.1f);
    }
    
    private void WobbleLeft()
    {
        wizard.transform.rotation = Quaternion.Lerp(wizard.transform.rotation, Quaternion.Euler(0,0,-4), 0.1f);
    }
    
}
