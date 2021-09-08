using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D body;
    private int startX;
    private float movementSpeed = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        body = this.GetComponent<Rigidbody2D>();
        
        // Randomize start position
        int rand = Random.Range(0, 2);
        if (rand == 0)
        {
            startX = -1;
        }
        else if (rand == 1) 
        {
            startX = 1;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Move();
    }

    private void Move()
    {
        body.velocity = new Vector2(startX, body.velocity.y) * movementSpeed;
    }
}
