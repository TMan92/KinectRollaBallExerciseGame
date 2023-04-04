using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    [SerializeField] SoundManager soundManager;

    // variables
    public int scoreToGive = 1; // how much score to add
    //public int clicksToPop = 5; // how many times we need to click on the balloon to pop it
    public int PopSprite = 5; // added
    public float scaleIncreasePerClick = 0.1f; // how much the balloon will increase by each time the balloon is clicked
    public ScoreManager scoreManager;

    // 
    void OnMouseDown()
    {
        soundManager.PlaySound();

        //clicksToPop -= 1; // subtracting 1 from clicks to pop
        PopSprite -= 1; //added
        transform.localScale += Vector3.one * scaleIncreasePerClick; // increaes the x,y,z scale by 1

        if (PopSprite == 0)
        {

            scoreManager.IncreaseScore(scoreToGive);
            Destroy(gameObject);
        }

    }


}
