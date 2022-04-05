using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameOver : MonoBehaviour
{
    public Button mainMenu;
    public Button exitButton;
    public bool playerDead;
    public string gameSceneName;
    //public Button pause;
    public GameObject GameOverMenuOnOff;
    public static bool isGameOver = false;
    // Start is called before the first frame update
    void Awake()
    {

        GameOverMenuOnOff.SetActive(false);
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerDead == true)
        {
            TurnOnGameOver();
        }


    }
    void TurnOnGameOver()
    {
        Time.timeScale = 0; //pause time in the game
        GameOverMenuOnOff.SetActive(true);
        isGameOver = true;

        mainMenu.onClick.AddListener(LoadGameScene);
        exitButton.onClick.AddListener(OnApplicationQuit);

    }


    public void LoadGameScene()
    {
        //loads the main menu
        GameSceneManager.Instance.LoadScene(gameSceneName);
    }


    private void OnApplicationQuit()
    {
        //quit application
        Application.Quit();
    }
}

