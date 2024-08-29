using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGameOver : MonoBehaviour
{

    LevelLoader levelLoader;
    public GameObject LevelLoader;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        levelLoader = LevelLoader.GetComponent<LevelLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Retry()
    {
        AudioManager.Instance.PlaySfx("MainButton");
        AudioManager.Instance.PlaySfx("TransClose");
        levelLoader.transition.SetTrigger("Start");

        switch (Decanoid.Current) 
        {
            case 1:
                levelLoader.Invoke("Orion", 1);
                break;
            case 2:
                levelLoader.Invoke("Aqua", 1);
                break;
            case 3:
                levelLoader.Invoke("Lyra", 1);
                break;
        }
    }


    public void Menu()
    {
        AudioManager.Instance.PlaySfx("SecButton");
        AudioManager.Instance.PlaySfx("TransClose");
        levelLoader.transition.SetTrigger("Start");
        levelLoader.Invoke("Levels", 1);
    }

}
