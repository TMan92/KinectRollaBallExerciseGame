using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{

    public float timeValue = 0;
    public TextMeshProUGUI scoreText;
    private float timer;
    [SerializeField]
    private bool countDown = true;

    //private float flashTimer;
    //private float flashDuration = 1f;

    // Update is called once per frame
    void Update()
    {
        if (countDown && timeValue > 0)
        {
            timeValue -= Time.deltaTime;

        }
        else if (!countDown && timer <= timeValue)
        {
            timeValue += Time.deltaTime;
        }
        else
        {
            timeValue = 0;
        }

        DisplayTime(timeValue);
        //DisplayTimeEnd(timeValue);
    }
 
    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        scoreText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    /*
    void DisplayTimeEnd(float timeToDisplay)
    {

        if (timeToDisplay == 0)
        {
            SceneManager.LoadScene("Character Selection");
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        scoreText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }
    */
}
