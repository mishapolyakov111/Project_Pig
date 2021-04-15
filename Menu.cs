using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    //класс начального меню
    public void Play1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Play2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void Play3()
    {
        SceneManager.LoadScene("Boss");
    }

    public void Levels()
    {
        SceneManager.LoadScene("LevelsMenu");
    }

    public void Quit()
    {
        Debug.Log("Ну давай попробуй");
    }
}
