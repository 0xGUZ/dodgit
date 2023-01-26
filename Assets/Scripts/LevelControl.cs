using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelControl : MonoBehaviour
{
    //tap to play
    public GameObject startGameButton;

    //UI
    private Image fill;
    private TextMeshProUGUI currentLevel;
    private TextMeshProUGUI nextLevel;

    //win panel stuff
    public GameObject winPanel;

    //death panel stuff  
    public GameObject deathPanel;
    public GameObject adsCounterObj;
    private Image adsCounter;
    
    //references
    private GameObject gameController;

    //start time of the level
    private float startTimer;

    //vars
    private int level;
    private int haveWon;
    private int haveStarted;

    // Start is called before the first frame update
    void Start()
    {
        //gets currentLevel or set it to 0
        level = PlayerPrefs.GetInt("currentLevel", 1);

        //conditions zeroed
        haveWon = 0;
        haveStarted = 0;

        //gameController
        gameController = GameObject.FindWithTag("GameController");
        gameController.GetComponent<MeteorSpawner>().enabled = false;
        GameObject.FindWithTag("ScoreManager").SetActive(true);

        //level bar
        fill = GameObject.FindWithTag("FillLevel").GetComponent<Image>();
        fill.fillAmount = 0;

        //UI
        currentLevel = GameObject.FindWithTag("CurrentLevel").GetComponent<TextMeshProUGUI>();
        nextLevel = GameObject.FindWithTag("NextLevel").GetComponent<TextMeshProUGUI>();
        
        currentLevel.SetText(level.ToString());
        nextLevel.SetText((level+1).ToString());

        //death panel
        adsCounter = adsCounterObj.GetComponent<Image>();
        adsCounter.fillAmount = 1;

        //STARTGAME
        startGameButton.SetActive(true);

        //disabling panels
        winPanel.SetActive(false);
        deathPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(haveStarted == 1){

            //win
            if (((Time.timeSinceLevelLoad - startTimer) >= 40f) && haveWon == 0){
                WinGame();
            }

            UpdateUI();
        }
    }

    public void StartGame() {

        gameController.GetComponent<MeteorSpawner>().enabled = true;
        startGameButton.SetActive(false);
        startTimer = Time.timeSinceLevelLoad;
        haveStarted = 1;
    
    }

    private void WinGame(){
        
        haveWon = 1;
        
        GameObject.FindWithTag("Player").GetComponent<BoxCollider2D>().enabled = false;
        gameController.GetComponent<MeteorSpawner>().enabled = false;
        GameObject.FindWithTag("ScoreManager").SetActive(false);

        PlayerPrefs.SetInt("currentLevel", PlayerPrefs.GetInt("currentLevel") + 1);

        winPanel.SetActive(true);

        //reloads after 3s
        Invoke("ReloadScene", 3f);
    }
    
    public void Die(){
        
        Destroy(GameObject.FindWithTag("Player"));
        gameController.GetComponent<MeteorSpawner>().enabled = false;
        GameObject.FindWithTag("ScoreManager").SetActive(false);

        deathPanel.SetActive(true);

        StartCoroutine(DecreaseAdsCounter());

        PlayerPrefs.SetInt("score", 0); //reset score   


        Invoke("ReloadScene", 6f);
    }

    private IEnumerator DecreaseAdsCounter(){
        float time = 6f;
        float startTime = Time.timeSinceLevelLoad;
        float endTime = startTime + time;
        while (Time.timeSinceLevelLoad < endTime)
        {
            adsCounter.fillAmount = 1 - (Time.timeSinceLevelLoad - startTime) / time;
            yield return null;
        }
        adsCounter.fillAmount = 0;
    }


    private void UpdateUI() {
        //bar fill
        fill.fillAmount = (Time.timeSinceLevelLoad - startTimer) / 40;

    }

    public void ReloadScene() {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }
}
