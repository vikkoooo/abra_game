using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D body;
    public int damage = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        body.velocity = transform.right * speed;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
    
        if (collision.CompareTag("Enemy"))
        {

            EnemyHealth enemy = collision.GetComponent<EnemyHealth>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
        
        
        
    }

}
