using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSpeed : MonoBehaviour
{
    public GameObject Spawner;
    public float GameSpeed;
    public Animator PlayerAnimator;
    public Animator RoadAnimator;
    public Animator BackgroundAnimator;
    private void Update()
    {
        PlayerAnimator.SetFloat("WalkSpeed", GameSpeed);
        RoadAnimator.SetFloat("RoadScrollSpeed", GameSpeed);
        BackgroundAnimator.SetFloat("BackgroundScrollSpeed", GameSpeed);
    }
}
