using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Telescope : MonoBehaviour
{
    public Animator ATelescope;

    LevelLoader levelLoader;
    public GameObject LevelLoader;

    // Start is called before the first frame update
    void Start()
    {
        levelLoader = LevelLoader.GetComponent<LevelLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        //Telescope Up or down
        switch (Decanoid.Position)
        {
            case 1:
                ATelescope.SetTrigger("Down");
                break;
            case 2:
                ATelescope.SetTrigger("Up");
                Decanoid.Level = 1;
                    break;
            case 3:
                if (Decanoid.Phase > 1)
                {
                    ATelescope.SetTrigger("Up");
                    Decanoid.Level = 2;
                }
                else { ATelescope.SetTrigger("Down"); }
                break;
            case 4:
                if (Decanoid.Phase > 2)
                {
                    Decanoid.Level = 3;
                    ATelescope.SetTrigger("Up");
                }
                else { ATelescope.SetTrigger("Down"); }
                break;
            case 5:
                if (Decanoid.Phase > 3)
                {
                    Decanoid.Level = 4;
                    ATelescope.SetTrigger("Up");

                }
                else { ATelescope.SetTrigger("Down"); }
                break;

        }
    }
    public void GotoLevel()
    {
        //Wich level to go
        switch (Decanoid.Level)
        {

            case 1:
                Decanoid.Current = 1;
                AudioManager.Instance.PlaySfx("TransClose");
                levelLoader.transition.SetTrigger("Start");
                levelLoader.Invoke("Night", 3);
                break;
            case 2:
                Decanoid.Current = 2;
                AudioManager.Instance.PlaySfx("TransClose");
                levelLoader.transition.SetTrigger("Start");
                levelLoader.Invoke("Night", 3);
                break;
            case 3:
                Decanoid.Current = 3;
                AudioManager.Instance.PlaySfx("TransClose");
                levelLoader.transition.SetTrigger("Start");
                levelLoader.Invoke("Night", 3);
                break;
            case 4:
                Decanoid.Current = 4;
                AudioManager.Instance.PlaySfx("TransClose");
                levelLoader.transition.SetTrigger("Start");
                levelLoader.Invoke("Night", 3);
                break;

        }
    }
}
