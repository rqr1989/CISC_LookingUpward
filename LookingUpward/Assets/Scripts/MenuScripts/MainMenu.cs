using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button startButton;
    public Button exitButton;
    public string gameSceneName;

    // Start is called before the first frame update
    void Start()
    {

        startButton.onClick.AddListener(LoadGameScene);

        exitButton.onClick.AddListener(OnApplicationQuit);


    }
    private void OnApplicationQuit()
    {
        Application.Quit();
    }

    // Update is called once per frame
    public void LoadGameScene()
    {

        GameSceneManager.Instance.LoadScene(gameSceneName);
    }
}
