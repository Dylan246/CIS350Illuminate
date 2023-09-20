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

    public void FinishLevel()
    {
        SceneManager.LoadScene(level + 1);
    }
}
