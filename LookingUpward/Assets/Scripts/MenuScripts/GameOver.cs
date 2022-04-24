using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameOver : MonoBehaviour
{ 
    private int finalscore;
    public Button mainMenu;
    public Button exitButton;
    public bool playerDead;
    public string gameSceneName;
    
    public DetectCollision detectcollision;
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
            //sets final score equal to score
            finalscore =  detectcollision.score;
           //calls TurnOnGameOverMethos
            TurnOnGameOver();
        }


    }
    public void TurnOnGameOver()
    {
        Time.timeScale = 0; //pause time in the game
        GameOverMenuOnOff.SetActive(true); //turn on Game Over Menu
        isGameOver = true; //set isGameOver boolean to true

        mainMenu.onClick.AddListener(LoadGameScene); //main menu button loads main menu on click
        exitButton.onClick.AddListener(OnApplicationQuit);

    }


    public void LoadGameScene() //loads main menu
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

