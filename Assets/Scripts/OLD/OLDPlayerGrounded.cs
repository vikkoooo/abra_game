using UnityEngine;

/*
 * This class is used to only allow initial jump once grounded
 * This script is attached to groundcheck child of player
 */
public class OLDPlayerGrounded : MonoBehaviour
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
            player.GetComponent<OLDPlayerMovement>().isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            player.GetComponent<OLDPlayerMovement>().isGrounded = false;
        }
    }
}
