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
    public Text pointsText;
   
  private DetectCollision detectcollision;
    public GameObject GameOverMenuOnOff;
    public static bool isGameOver = false;
    // Start is called before the first frame update
    void Awake()
    {

        GameOverMenuOnOff.SetActive(false);
        isGameOver = false;
        mainMenu.onClick.AddListener(LoadGameScene); //main menu button loads main menu on click
        exitButton.onClick.AddListener(OnApplicationQuit);
    }
   /** public void Setup(int score)
    {
     score = detectcollision.CurrentScore();
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + "Points";
    }
   **/

    public void TurnOnGameOver(int score)
    {
        //score = detectcollision.CurrentScore();
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + "Points";
        Time.timeScale = 0; //pause time in the game
        GameOverMenuOnOff.SetActive(true); //turn on Game Over Menu
        isGameOver = true; //set isGameOver boolean to true


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

