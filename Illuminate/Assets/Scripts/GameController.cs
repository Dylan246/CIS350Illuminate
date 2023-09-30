/*****************************************************************************
// File Name : GameController.cs
// Author : Sam Dwyer
//
// Brief Description : Holds all of the game controller functions
*****************************************************************************/
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController gc;
    public int level;

    private void Awake()
    {
        gc = this;
    }

    /// <summary>
    /// Will be called when a level is complete and load the next level
    /// </summary>
    public void FinishLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
