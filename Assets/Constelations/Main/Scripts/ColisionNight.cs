using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ColisionNight : MonoBehaviour
{
    LevelLoader levelLoader;
    public GameObject LevelLoader;

    public bool MusicFade;

    // Start is called before the first frame update
    void Start()
    {
        levelLoader = LevelLoader.GetComponent<LevelLoader>();
    }
    // Update is called once per frame
    void Update()
    {
        if(MusicFade == true) {
        AudioManager.Instance.musicSource.volume = AudioManager.Instance.musicSource.volume - .001f;
    }
}
    private void OnCollisionStay2D(Collision2D col)
    {
        //Load level for each constelation
        switch (col.gameObject.name)
        {
            case "orion":
                if (Decanoid.Current == 1)
                {
                    if (Keyboard.current.eKey.isPressed)
                    {
                        AudioManager.Instance.PlaySfx("MainButton");
                        MusicFade = true;
                        Invoke("GoMid", .5f);
                    }
                }
                break;
            case "aquarius":
                if (Decanoid.Current == 2)
                {
                    if (Keyboard.current.eKey.isPressed)
                    {
                        AudioManager.Instance.PlaySfx("MainButton");
                        Invoke("GoMid", .5f);
                    }
                }
                break;
            case "lyra":
                if (Decanoid.Current == 3)
                {
                    if (Keyboard.current.eKey.isPressed)
                    {
                        AudioManager.Instance.PlaySfx("MainButton");
                        Invoke("GoMid", .5f);
                    }
                }
                break;
        }
    }
    // Ir para o Mid
    public void GoMid()
    {
        AudioManager.Instance.PlaySfx("TransClose");
        levelLoader.transition.SetTrigger("Start");
        levelLoader.Invoke("Mid", 3);
    }
}
