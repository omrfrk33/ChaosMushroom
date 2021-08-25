﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField]
    float speed = 20f;

    [SerializeField]
    int damage;
    private Rigidbody2D rb2d;
    
    // Start is called before the first frame update
    void StartShooting(bool isFacingLeft)
    {
        
        rb2d = GetComponent<Rigidbody2D>();
        if (isFacingLeft)
        {
            rb2d.velocity = new Vector2(-speed, 0);
        }
        else
        {
            rb2d.velocity = new Vector2(speed, 0);
        }
        
        
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