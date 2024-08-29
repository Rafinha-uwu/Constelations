using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Menu : MonoBehaviour
{
    public Transform Base;
    public Transform Op;
    public Transform ConfirmExit;
    public Transform ConfirmMenu;
    public Button All;
    public Transform ActualMenu;
    public Text MMenu;

    private string sceneName;
    public Color Fade;

    LevelLoader levelLoader;
    public GameObject LevelLoader;

    public bool MenuOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        levelLoader = LevelLoader.GetComponent<LevelLoader>();

        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;

        MMenu = MMenu.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //Desativar o icon
        if (sceneName != "Levels") { All.gameObject.SetActive(false); }
        else { All.gameObject.SetActive(true); }

        //Keybord to open menu
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if( MenuOpen == false)
            {
                Invoke("Open", 0);
            }
            else
            {
                Invoke("Resume", 0);
            }
        }
    }
    public void Open()
    {
        AudioManager.Instance.PlaySfx("MainButton");
        Decanoid.On = false;
        Cursor.visible = true;
        MenuOpen = true;
        Base.gameObject.SetActive(true);
        Op.gameObject.SetActive(false);

        //Color Fade On menu
        if (sceneName == "Levels")
        {
            ActualMenu.GetComponent<Animator>().enabled = false;
            MMenu.color = Fade;
        }

    }
    public void Resume()
    {
        AudioManager.Instance.PlaySfx("SecButton");
        if (sceneName != "Levels")
        {
            Cursor.visible = false;
        }

        Decanoid.On = true;
        MenuOpen = false;
        Base.gameObject.SetActive(false);
        Op.gameObject.SetActive(false);
        ConfirmExit.gameObject.SetActive(false);
        ConfirmMenu.gameObject.SetActive(false);

    }
    public void MainM()
    {
        AudioManager.Instance.PlaySfx("SecButton");
        if (sceneName != "Levels") {
            Base.gameObject.SetActive(false);
            ConfirmMenu.gameObject.SetActive(true);
        }
    }
    public void Sai() 
    {
        AudioManager.Instance.PlaySfx("SecButton");
        Base.gameObject.SetActive(false);
        ConfirmExit.gameObject.SetActive(true);
    }
    public void Options()
    {
        AudioManager.Instance.PlaySfx("SecButton");
        Base.gameObject.SetActive(false);
        Op.gameObject.SetActive(true);
    }

    public void MainVolume(Slider MV)
    { 
        Decanoid.MainVolume = MV.value;
        AudioManager.Instance.SfxVolume(Decanoid.MainVolume);

    }
    public void MusicaVolume(Slider MV)
    {
        Decanoid.MusicVolume = MV.value;
        AudioManager.Instance.MusicVolume(Decanoid.MusicVolume);
    }
    public void Sencibilidade(Slider MV)
    {
        Decanoid.sensitivity = MV.value;
    }
    public void Back()
    {
        AudioManager.Instance.PlaySfx("SecButton");
        Base.gameObject.SetActive(true);
        Op.gameObject.SetActive(false);
    }
    public void NoMenu()
    {
        AudioManager.Instance.PlaySfx("SecButton");
        Base.gameObject.SetActive(true);
        ConfirmMenu.gameObject.SetActive(false);
    }
    public void NoExit()
    {
        AudioManager.Instance.PlaySfx("SecButton");
        Base.gameObject.SetActive(true);
        ConfirmExit.gameObject.SetActive(false);
    }
    public void YesExit()
    {
        AudioManager.Instance.PlaySfx("SecButton");
        MenuOpen = false;
        print("Aplicação terminou!");
        Application.Quit();
    }
    public void YesMenu()
    {
        AudioManager.Instance.PlaySfx("SecButton");
        Invoke("MovementOn", 1);
        MenuOpen = false;
        levelLoader.transition.SetTrigger("Start");
        levelLoader.Invoke("Levels", 1);
    }
    private void MovementOn()
    {
        Decanoid.On = true;
    }
}
