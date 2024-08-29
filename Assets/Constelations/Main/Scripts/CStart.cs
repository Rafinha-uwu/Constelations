using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CStart : MonoBehaviour
{
    LevelLoader levelLoader;
    public GameObject LevelLoader;

    public Animator transition;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.PlayMusic("MusicFirst");
        levelLoader = LevelLoader.GetComponent<LevelLoader>();
        Cursor.visible = true;
        Decanoid.Current = 0;
}

    // Update is called once per frame
    void Update()
    {
    }

    //Play animation and GO to levelchosing
    public void Play()
    {
        AudioManager.Instance.PlaySfx("SecButton");
        Invoke("Anim", 1);
        Invoke("GO", 5);
    }
    public void GO()
    {
        AudioManager.Instance.PlaySfx("TransClose");
        levelLoader.transition.SetTrigger("Start");
        levelLoader.Invoke("Levels", 3);
    }

    //Animation
    public void Anim()
    {
        AudioManager.Instance.PlaySfx("Book");
        AudioManager.Instance.PlaySfx("Wood");
        transition.SetTrigger("Walk");
    }

}
