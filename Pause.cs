using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject PauseUI;
    bool paused;
    public void PauseButton()
    {
        if (paused)
        {
            Time.timeScale = 1f;
            paused = false;
            PauseUI.SetActive(false);
        }
        else
        {
            Time.timeScale = 0f;
            paused = true;
            PauseUI.SetActive(true);
        }
    }
    private void Update()
    {
        if (Input.GetButtonDown("Cancel")){
            PauseButton();
        }
    }
}
