using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public Text scoreDisplay;
    public float timerScoreIncrease;
    float countdown;
    Player pc;
    private void Start()
    {
        countdown = timerScoreIncrease;
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    private void Update()
    {
        countdown -= Time.deltaTime;
        if(countdown <= 0)
        {
         if (!pc.playerIsDead)
          {
                score += 1;
                countdown = timerScoreIncrease;
          }
        }
        scoreDisplay.text = "<color=#feae3>Score:</color> <color=#feae34>" + score + "</color>";
    }
    public void EnemyDied(int score)
    {
        if (pc.playerIsDead)
        {
        score += score;
        }
    }
}
