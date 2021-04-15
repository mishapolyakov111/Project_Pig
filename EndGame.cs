using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
    //класс отвечает за появление и работу меню,
    //которые появляются после смерти игрока или в в случае попбеды
{
    public GameObject EndMenu;
    public GameObject WinMenu;
    bool end = true;
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") == null && end)
        {
            Instantiate(EndMenu);
            end = false;
        }

        if (GameObject.FindGameObjectWithTag("Enemy") == null && end && GameObject.FindGameObjectWithTag("Player") != null)
        {
            Instantiate(WinMenu);
            end = false;
        }
    }
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
