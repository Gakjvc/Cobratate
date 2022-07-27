using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Animator animator;
    public float transitionTime;
    public void LoadGame()
    {
        StartCoroutine("StartGame");
    }
    public void LoadAScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Quit()
    {
        Application.Quit();
    }
    IEnumerator StartGame()
    {
        animator.SetTrigger("Start");
        yield return new WaitForSecondsRealtime(transitionTime);
        SceneManager.LoadScene(1);
    }
  
}
