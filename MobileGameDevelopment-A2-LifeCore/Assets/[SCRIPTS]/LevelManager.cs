using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadGameScene()
    {
        SceneManager.LoadScene(2);
    }
    public void LoadInstructions()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadGameOver()
    {
        SceneManager.LoadScene(3);
    }

}
