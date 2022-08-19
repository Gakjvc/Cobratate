using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject groundEnemy;
    public GameObject flyingEnemy;
    public GameObject[] backgroundElements;
    public float maxSpeed;
    public float startingCooldown;
    public float cooldownDecrease;
    public float cooldown;
    public float minCooldown;
    public float gameSpeed;
    public float speedIncreaseBy;
    public float timerCooldown;
    private void Start()
    {
        cooldown = startingCooldown;
    }
    private void Update()
    {
        if (timerCooldown <= 0)
        {
            SpawnRandomBackgroundElement();
            int num = Random.Range(0,2);
            switch (num)
            {
                case 0:
                    SpawnGroundEnemy();
                    break;
                case 1:
                    SpawnFlyingEnemy();
                    break;
            }
            if (cooldown - cooldownDecrease < minCooldown)
            {
                timerCooldown = minCooldown;
            }
            else
            {
                timerCooldown = cooldown;
                if(cooldown <= minCooldown * 2)
                {
                    cooldown -= cooldownDecrease / 2;
                }
                else
                {
                cooldown -= cooldownDecrease;
                }
            }
            if((gameSpeed += speedIncreaseBy) != maxSpeed)
            {
            gameSpeed += speedIncreaseBy;
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
        instance.GetComponent<Enemy>().speed = gameSpeed;
    }
    void SpawnFlyingEnemy()
    {
        GameObject instance = Instantiate(flyingEnemy, new Vector2(transform.position.x, flyingEnemy.transform.position.y), Quaternion.identity);
        instance.GetComponent<Enemy>().speed = gameSpeed;
    }
    void SpawnRandomBackgroundElement()
    {
        int num = Random.Range(0, backgroundElements.Length);
        GameObject instance = Instantiate(backgroundElements[num], backgroundElements[num].transform.position, Quaternion.identity);
        instance.GetComponent<Enemy>().speed = gameSpeed;
    }
}
