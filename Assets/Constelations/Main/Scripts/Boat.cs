using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Boat : MonoBehaviour
{
    public float ShowPosition;

    public Animator Barco;
    public Animator BarcoDad;
    public GameObject SBoat;

    // Start is called before the first frame update
    void Start()
    {
        Decanoid.On = true;
        //Idle Boat depending on position
        switch (Decanoid.Level)
        {
            case 1:
                BarcoDad.GetComponent<Animator>().Play("2");
                break;
            case 2:
                BarcoDad.GetComponent<Animator>().Play("3");
                break;
            case 3:
                BarcoDad.GetComponent<Animator>().Play("4");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Boat movement and Animations
        ShowPosition = Decanoid.Position;
        if (Decanoid.On == true)
        {
            switch (Decanoid.Position)
            {
                case 1:
                    if (Keyboard.current.dKey.wasPressedThisFrame)
                    {
                        AudioManager.Instance.PlaySfx("BoatMove");

                        SBoat.transform.eulerAngles = new Vector3(0, 180, 0);
                        Barco.SetTrigger("Speed");
                        BarcoDad.SetTrigger("1d");

                        Decanoid.On = false;
                        Invoke("Move", 3);
                    }

                    break;
                case 2:

                    if (Keyboard.current.aKey.wasPressedThisFrame)
                    {
                        AudioManager.Instance.PlaySfx("BoatMove");
                        AudioManager.Instance.PlaySfx("BoatMove");
                        SBoat.transform.eulerAngles = new Vector3(0, 0, 0);
                        Barco.SetTrigger("Speed");
                        BarcoDad.SetTrigger("2e");

                        Decanoid.On = false;
                        Invoke("Move", 3);
                    }
                    if (Keyboard.current.dKey.wasPressedThisFrame)
                    {
                        AudioManager.Instance.PlaySfx("BoatMove");
                        SBoat.transform.eulerAngles = new Vector3(0, 180, 0);
                        Barco.SetTrigger("Speed");
                        BarcoDad.SetTrigger("2d");

                        Decanoid.On = false;
                        Invoke("Move", 4);
                    }

                    break;
                case 3:
                    if (Keyboard.current.aKey.wasPressedThisFrame)
                    {
                        AudioManager.Instance.PlaySfx("BoatMove");
                        SBoat.transform.eulerAngles = new Vector3(0, 0, 0);
                        Barco.SetTrigger("Speed");
                        BarcoDad.SetTrigger("3e");

                        Decanoid.On = false;
                        Invoke("Move", 4);
                    }
                    if (Keyboard.current.dKey.wasPressedThisFrame && Decanoid.Phase > 1)
                    {
                        AudioManager.Instance.PlaySfx("BoatMove");
                        SBoat.transform.eulerAngles = new Vector3(0, 180, 0);
                        Barco.SetTrigger("Speed");
                        BarcoDad.SetTrigger("3d");

                        Decanoid.On = false;
                        Invoke("Move", 5);
                    }
                    break;
                case 4:
                    if (Keyboard.current.aKey.wasPressedThisFrame && Decanoid.Phase > 1)
                    {
                        AudioManager.Instance.PlaySfx("BoatMove");
                        SBoat.transform.eulerAngles = new Vector3(0, 0, 0);
                        Barco.SetTrigger("Speed");
                        BarcoDad.SetTrigger("4e");

                        Decanoid.On = false;
                        Invoke("Move", 5);
                    }
                    if (Keyboard.current.dKey.wasPressedThisFrame && Decanoid.Phase > 2)
                    {
                        AudioManager.Instance.PlaySfx("BoatMove");
                        SBoat.transform.eulerAngles = new Vector3(0, 180, 0);
                        Barco.SetTrigger("Speed");
                        BarcoDad.SetTrigger("4d");

                        Decanoid.On = false;
                        Invoke("Move", 7);
                    }
                    break;
                case 5:
                    if (Keyboard.current.aKey.wasPressedThisFrame)
                    {
                        AudioManager.Instance.PlaySfx("BoatMove");
                        SBoat.transform.eulerAngles = new Vector3(0, 0, 0);
                        Barco.SetTrigger("Speed");
                        BarcoDad.SetTrigger("5e");

                        Decanoid.On = false;
                        Invoke("Move", 7);
                    }
                    break;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        //Know Position based on colision
        switch (col.gameObject.name)
        {
            case "Start":
                Decanoid.Position = 1;
                break;

            case "Level1":
                Decanoid.Position = 2;
                break;

            case "Level2":
                Decanoid.Position = 3;
                break;

            case "Level3":
                Decanoid.Position = 4;
                break;

            case "End":
                Decanoid.Position = 5;
                break;
        }

    }
    //Movement Back on and idle playing
    public void Move()
    {
        Decanoid.On = true;
        Barco.SetTrigger("Idle");
    }

}
