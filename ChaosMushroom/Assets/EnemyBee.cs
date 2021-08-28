﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBee : MonoBehaviour
{
    [SerializeField]
    private float timeBtwAttack;
    [SerializeField]
    public float startTimeBtwAttack;
    
    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public int health = 4;
    public int damage = 1;
    int Count;
    const string ENEMY_IDLE = "Bee_Movement";
    const string ENEMY_TAKEDAMAGE = "Bee_TakeDamage";
    const string ENEMY_DEATH = "Bee_Explode";
    const string ENEMY_ATTACK = "Bee_Attacking";
    /*
    public void TakeDamage (int damage)
    {
        health -= damage;
        if (health <=0)
        {
            Destroy(gameObject);
        }

    }
    */
    void Update() 
    {
    Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);

        if (timeBtwAttack <= 0)
        {
        if (enemiesInRange.Length >= 1)
        {
            //for giving every one of enemies damage.
            for (int i = 0; i < enemiesInRange.Length; i++)
            {
                enemiesInRange[i].GetComponent<PlayerScript>().PlayerTakeDamage(damage);
                Debug.Log("damage given");
            }
        }
        timeBtwAttack = startTimeBtwAttack;
        } else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }
    /// <summary>
    /// Callback to draw gizmos only if the object is selected.
    /// </summary>
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
        
    private void OnTriggerEnter2D (Collider2D collision)
    {
      if(collision.CompareTag("Bullet"))
    {
        Destroy(collision.gameObject);
        health--;
    }
     if (health <= 0)
        {
        Destroy(gameObject);
        }
    }
}
