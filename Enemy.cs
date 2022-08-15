using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage = 1;
    public int health = 1;
    public float speed;
    public int scoreincrease;
    [HideInInspector] public bool speedAltered;
    ScoreManager sm;
    private void Start()
    {
        sm = GameObject.FindGameObjectWithTag("Maestro").GetComponent<ScoreManager>();
    }
    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (transform.position.x < -20 )
        {
            sm.EnemyDied(scoreincrease);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().TakeDamage(damage);
            DamageEnemy(other.GetComponent<Player>().damage);
        }
    }
    void DamageEnemy(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            EnemyDie();
        }
    }
    void EnemyDie()
    {
        Destroy(gameObject);
    }
}
