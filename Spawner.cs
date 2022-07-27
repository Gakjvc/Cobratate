using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject groundEnemy;
    public GameObject flyingEnemy;
    public float spawnHeight;
    public float startingCooldown;
    public float cooldownDecrease;
    public float minCooldown;
    public float speedIncrement;
    public float speedAdd;
    float timerCooldown;
    private void Update()
    {
        if (timerCooldown <= 0)
        {
            SpawnFlyingEnemy();
            int num = Random.Range(0,2);
            
            if (startingCooldown - cooldownDecrease < minCooldown)
            {
                timerCooldown = minCooldown;
            }
            else
            {
                timerCooldown = startingCooldown - cooldownDecrease;
            }
        }
        else
        {
            timerCooldown -= Time.deltaTime;
        }
    }
    void SpawnGroundEnemy()
    {
        GameObject instance = Instantiate(groundEnemy, transform.position, Quaternion.identity);
        instance.GetComponent<Enemy>().speed += speedIncrement;
    }
    void SpawnFlyingEnemy()
    {
        GameObject instance = Instantiate(flyingEnemy, new Vector2(transform.position.x, spawnHeight), Quaternion.identity);
        instance.GetComponent<Enemy>().speed += speedIncrement;
    }
}
