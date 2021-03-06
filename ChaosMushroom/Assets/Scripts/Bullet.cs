using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        Destroy(gameObject, 1f);
    }

    void OnTriggerEnter2D (Collider2D hitInfo)
    {
      CommonEnemy enemy = hitInfo.GetComponent<CommonEnemy>();
      if (enemy != null)
      {
          enemy.TakeDamage(50);
      }
      Destroy(gameObject);
      
    }

}
