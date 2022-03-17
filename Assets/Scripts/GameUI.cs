using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public enum GameState { MainMenu,Paused,Playing,GameOver};
    public GameState currentState;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI lifeText;
    public TextMeshProUGUI starsText;
    public Image redKeyUI, blueKeyUI, yellowKeyUI;
    public GameObject allGameUI, mainMenuPanel, pauseMenuPanel, gameOverPanel, titleText,creditsPanel,creditsPanelGOver;
   


    // Start is called before the first frame update
    private void Awake()
    {

        if(SceneManager.GetActiveScene().name == "MainMenu")
        {
            CheckGameState(GameState.MainMenu);
        }
        else
        {
            CheckGameState(GameState.Playing);
        }
    }

    public void CheckGameState(GameState newGameState)
    {
        currentState = newGameState;
        switch (currentState)
        {
            case GameState.MainMenu:
                MainMenuSetup();
                break;
            case GameState.Paused:
                GamePaused();
                Manager3d.gamePaused = true;
                Time.timeScale = 0f;
                break;
            case GameState.Playing:
                GameActive();
                Manager3d.gamePaused = false;
                Time.timeScale = 1f;
                break;
            case GameState.GameOver:
                GameOver();
                Manager3d.gamePaused = true;
                Time.timeScale = 0f;
                break;
           
        }
    }


    public void MainMenuSetup()
    {
        allGameUI.SetActive(false);
        mainMenuPanel.SetActive(true);
        pauseMenuPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        titleText.SetActive(true);
    }

  

    public void GameActive()
    {
        allGameUI.SetActive(true);
        mainMenuPanel.SetActive(false);
        pauseMenuPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        titleText.SetActive(false);
    }

    public void GamePaused()
    {
        allGameUI.SetActive(true);
        mainMenuPanel.SetActive(false);
        pauseMenuPanel.SetActive(true);
        gameOverPanel.SetActive(false);
        titleText.SetActive(true);
    }

    public void GameOver()
    {
        allGameUI.SetActive(false);
        mainMenuPanel.SetActive(false);
        pauseMenuPanel.SetActive(false);
        gameOverPanel.SetActive(true);
        titleText.SetActive(true);
    }
    public void CreditsCheck()
    {
        allGameUI.SetActive(false);
        mainMenuPanel.SetActive(false);
        pauseMenuPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        titleText.SetActive(true);
    }

    //public void CreditsCheckGameOver()
    //{
    //    allGameUI.SetActive(false);
    //    mainMenuPanel.SetActive(false);
    //    pauseMenuPanel.SetActive(false);
    //    gameOverPanel.SetActive(true);
    //    titleText.SetActive(true);
    //}

   


    // Update is called once per frame
    void Update()
    {
        CheckInputs();
    }

    void CheckInputs()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(currentState == GameState.Playing)
            {
                CheckGameState(GameState.Paused);
            }
            else if(currentState == GameState.Paused)
            {
                CheckGameState(GameState.Playing);    
            }
        }
    }

    public void StarGame()
    {
        SceneManager.LoadScene("Level1");
        CheckGameState(GameState.Playing);
    }

 

    public void PauseGame()
    {
        CheckGameState(GameState.Paused);
    }

    public void ResumeGame()
    {
        CheckGameState(GameState.Playing);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); 
        CheckGameState(GameState.MainMenu);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    //public void GoToGameOver()
    //{
    //    CheckGameState(GameState.GameOver);
    //}


    public void Credits()
    {
        OpenPanel();

    }

    //public void CreditsGameOver()
    //{
    //    OpenPanelGameOver();

    //}


    public void OpenPanel()
    {
        if (creditsPanel != null)
        {
            bool isActive = creditsPanel.activeSelf;
            creditsPanel.SetActive(!isActive);
            CreditsCheck();
        }
    }

    //public void OpenPanelGameOver()
    //{
    //    if (creditsPanelGOver != null)
    //    {
    //        bool isActive = creditsPanelGOver.activeSelf;
    //        creditsPanelGOver.SetActive(!isActive);
    //        CreditsCheckGameOver();
    //    }
    //}


    public void UpdateCoins()
    {
        coinText.text = Manager3d.coins.ToString();
    }

    public void UpdateLives()
    {
        lifeText.text = Manager3d.lives.ToString();
    }

    public void UpdateStars()
    {
        starsText.text = Manager3d.stars.ToString();
    }

    public void UpdateKeys(Manager3d.DoorKeyColour keyColours)
    {
        switch (keyColours)
        {
            case Manager3d.DoorKeyColour.Red:
                redKeyUI.GetComponent<Image>().color = Color.white;
                break;
            case Manager3d.DoorKeyColour.Blue:
                blueKeyUI.GetComponent<Image>().color = Color.white;
                break;
            case Manager3d.DoorKeyColour.Yellow:
                yellowKeyUI.GetComponent<Image>().color = Color.white;
                break;
        }
    }
}
