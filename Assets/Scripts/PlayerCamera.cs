using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    // Game object variable. So we can attach a object in the game onto the script. 
    public GameObject player;
    private float y = 0f;
    private float z = -10;
    
    // Update is called once per frame
    void LateUpdate()
    {
        // Update camera position with the player position.
        if (player.transform.position.x > 0)
        {
            transform.position = new Vector3(player.transform.position.x, y, z);
        }
    }
}
