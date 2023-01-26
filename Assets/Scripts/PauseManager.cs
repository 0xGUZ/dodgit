using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel;
    private bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPaused) {
            pausePanel.SetActive(true);
            Time.timeScale = 0;
        }
        
        else {
            pausePanel.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void TogglePause(){
        if (isPaused == false){
            isPaused = true;
        }
        else {
            isPaused = false;
        }
    }

    public void Mute() {
        //TODO
    }


}
