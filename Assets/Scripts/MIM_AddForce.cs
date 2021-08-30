using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MIM_AddForce : MonoBehaviour
{
    private Rigidbody2D MIM;
    
    // Start is called before the first frame update
    void Start()
    {
        MIM = GetComponent<Rigidbody2D>();
        MIM.AddForce(new Vector2(Random.Range(-2, 10), Random.Range(3, 20)), ForceMode2D.Impulse);
    }

}
