using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WinFlag : MonoBehaviour
{
   
    public string gameSceneName;
    public string MainMenu;
    public GameObject WinDialogue;
    public Button main;
    public Button quit;
    public bool gameWon = false;
    private void Awake()
    {
       main.onClick.AddListener(loadMain);
        Time.timeScale = 1; //pause time in the game
        WinDialogue.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameWon == true)
        {
            Time.timeScale = 0; //pause time in the game
            WinDialogue.SetActive(true);
        }
        else
            
        WinDialogue.SetActive(false);
    }
    public void loadMain()
    {
        GameSceneManager.Instance.LoadScene(MainMenu);
    }
    public void quitGame()
    {
        Application.Quit();
    }
}
