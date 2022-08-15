using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationMaestro : MonoBehaviour
{
    public Animator cameraAnimator;
    Player pc;
    bool triggered;
    void Start()
    {
        triggered = false;
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    void Update()
    {
        if (pc.playerIsDead & !triggered)
        {
            cameraAnimator.SetTrigger("Death");
            triggered = true;
        }
    }
}
