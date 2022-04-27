using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public int score;
    public int currentscore;
  
    [SerializeField] private int ScoreValue;
    [SerializeField] private AudioClip gemPickUpSound;
    private HighScore highscore;

    private void Awake()
    {
        currentscore = 0;
        score = 0;
        ScoreValue = 1;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SoundManager.instance.PlaySound(gemPickUpSound);
            collision.GetComponent<HighScore>().AddScore();

           // highscore.AddScore();
            gameObject.SetActive(false);
        }
    }

    public void Update()
    {
        Debug.Log("the score is" + currentscore);
    }

    public void CurrentScore()
    {
        score = currentscore;
    }
    public void AddScore(int _value)
    {
        currentscore = score + _value;
        Debug.Log("the score is" + currentscore);
        score = currentscore;
    }
}
