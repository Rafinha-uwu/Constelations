using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;

    // Update is called once per frame
    void Update()
    {

    }

     public void GameO()
    {
        SceneManager.LoadScene("GameOver");
    }
    public void Mid()
    {
        SceneManager.LoadScene("Mid");
    }
    public void Levels()
    {
        SceneManager.LoadScene("Levels");
    }
    public void Night()
    {
        SceneManager.LoadScene("NightSky");
    }
    public void Aqua()
    {
        SceneManager.LoadScene("Labirinto");

    }
    public void Orion()
    {
        SceneManager.LoadScene("Orion");

    }
    public void Lyra()
    {
        SceneManager.LoadScene("Lyra");

    }
    public void Startofitall()
    {
        SceneManager.LoadScene("Start");

    }
}
