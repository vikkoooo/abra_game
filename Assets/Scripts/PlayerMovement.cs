using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float movementSpeed = 15f;
    public Vector2 jumpHeight = new Vector2(0f, 7f);
    public bool isGrounded = false;
    private int n_jumps;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.position += horizontal * Time.deltaTime * movementSpeed;
        
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
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
}
