using UnityEngine;

/*
 * This class triggers the shot
 * This script is attached to the player
 */

public class PlayerWeapon : MonoBehaviour
{
    public Transform firePoint; // Makes the bullet start at wanted position
    public GameObject bullet; // The bullet prefab we wanna shoot
    
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        // When this is true, it means the dude is rotated to the left. So we should shoot to the left
        // So we need to rotate 180 degrees on z axis
        if (this.transform.localScale.x > 0)
        {
            Instantiate(bullet, firePoint.position, Quaternion.Euler(0, 0, 180));
        }
        // Rotated to the right, so original rotation can be used
        else if (this.transform.localScale.x < 0)
        {
            Instantiate(bullet, firePoint.position, Quaternion.Euler(0,0,0));
        }
    }
    
    
}
