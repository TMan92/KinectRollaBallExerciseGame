using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class QuitLevel : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("QUIT LEVEL!");
        SceneManager.LoadScene("Home Screen");
    }
}