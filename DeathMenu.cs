using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour
{
    public GameObject deathmenu;
    Player player;
    private void Update()
    {
        PlayerDied();
    }
    public void PlayerDied()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if (player.playerIsDead)
        {
            deathmenu.SetActive(true);
        }
    }
}
