using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HighScore : MonoBehaviour
{
    public float Score;
    public float Highscore;

    public Text scoretext;
    public Text highscoretext;



    public void AddScore()
    {
        Score ++;
        Debug.Log("the score is" + Score);
       // score = currentscore;
    }

    private void Start()
    {
        Highscore = PlayerPrefs.GetFloat("Highscore");
    }

    // Update is called once per frame
    void Update()
    {
        scoretext.text = Score.ToString();

        highscoretext.text = Highscore.ToString();

        //if scoer is higher than highscore
        if (Score > Highscore )
        {
            //highscore is set equal to score
            PlayerPrefs.SetFloat("Highscore", Score);
        }

        
    }


}

