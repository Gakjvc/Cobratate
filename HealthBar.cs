using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image[] Hearts;
    public Sprite emptyHearts;
    Player pc;

    private void Start()
    {
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>() ;
    }
    private void Update()
    {
        switch (pc.health) {
            case 2:
                Hearts[2].sprite = emptyHearts;
                break;
            case 1:
                Hearts[2].sprite = emptyHearts;
                Hearts[1].sprite = emptyHearts;
                break;
            case 0:
                Hearts[2].sprite = emptyHearts;
                Hearts[1].sprite = emptyHearts;
                Hearts[0].sprite = emptyHearts;
                break;
        }
    }
}
