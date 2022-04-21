using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OpeningDialogue : MonoBehaviour
{
    public GameObject openDialouge;
    public Button start;
    // Start is called before the first frame update
   private void Awake()
    {
     start.onClick.AddListener(startGame);
        Time.timeScale = 0; //pause time in the game
        openDialouge.SetActive(true);
    }

    // Update is called once per frame
    void startGame()
    {
        Time.timeScale = 1;
        openDialouge.SetActive(false);
    }
}
