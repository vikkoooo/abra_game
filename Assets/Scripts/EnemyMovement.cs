using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // For physics and movement
    private Rigidbody2D body;
    private int xDirection;
    private float movementSpeed = 1f;
    
    // For wobble
    private float z = 1f; // How much should it wobble, large number is more rotation
    private float t = 0.2f; // How fast should it wobble, larger number is faster rotation
    private int wobbleX = 1;
    
    // Start is called before the first frame update
    private void Start()
    {
        body = this.GetComponent<Rigidbody2D>();
        
        // Randomize start direction
        int rand = Random.Range(0, 2);
        if (rand == 0)
        {
            xDirection = -1;
            // Turn monster left
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        else if (rand == 1) 
        {
            xDirection = 1;
            // Turn monster right
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }

    private void LateUpdate()
    {
        Move();
    }

    private void Move()
    {
        body.velocity = new Vector2(xDirection, body.velocity.y) * movementSpeed;
        Wobble();
    }
    
    private void Wobble()
    {
        if (wobbleX == 1)
        {
            // This causes the object to rotate to the left, until the end point z with speed t
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(0, 0, z), t);

            // When z value is reached, we flip wobbleX to make the wizard start rotating on the other direction
            if (this.transform.rotation == Quaternion.Euler(0, 0, z))
            {
                wobbleX = -1;
            }
        }

        else if (wobbleX == -1)
        {
            // Makes the object rotate to the right, until end point z with speed t
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(0, 0, -z), t);

            // When z is reached
            if (this.transform.rotation == Quaternion.Euler(0, 0, -z))
            {
                wobbleX = 1;
            }
        }
    }
}
