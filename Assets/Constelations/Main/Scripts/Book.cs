using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Book : MonoBehaviour
{
    public bool Open = false;
    public float Page = 0;
    // Start is called before the first frame update
    void Start()
    {
        Page = 0;
        Open = false;
    }
    public Transform Page0;
    public Transform Page1;
    public Transform Page2;
    public Transform Page3;
    public Transform Page4;
    public Transform Book1;

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame && Open == false)
        {
            Invoke("OpenBook", 0);

        }
        if (Keyboard.current.eKey.wasPressedThisFrame && Open == true)
        {
            Decanoid.On = true;
            Open = false;
            Book1.gameObject.SetActive(false);

        }

        if (Open == true)
        {
            switch (Page)
            {
                case 0:
                    Page0.gameObject.SetActive(true);
                    if (Keyboard.current.dKey.wasPressedThisFrame && Decanoid.Phase > 1)
                    {
                        AudioManager.Instance.PlaySfx("Folhear");
                        Page0.gameObject.SetActive(false);
                        Page = 1;
                    }
                    break;
                case 1:
                    Page1.gameObject.SetActive(true);
                    if (Keyboard.current.aKey.wasPressedThisFrame)
                    {
                        AudioManager.Instance.PlaySfx("Folhear");
                        Page1.gameObject.SetActive(false);
                        Page = 0;

                    }
                    if (Keyboard.current.dKey.wasPressedThisFrame && Decanoid.Phase > 2)
                    {
                        AudioManager.Instance.PlaySfx("Folhear");
                        Page1.gameObject.SetActive(false);
                        Page = 2;

                    }
                    break;
                case 2:
                    Page2.gameObject.SetActive(true);
                    if (Keyboard.current.aKey.wasPressedThisFrame)
                    {
                        AudioManager.Instance.PlaySfx("Folhear");
                        Page2.gameObject.SetActive(false);
                        Page = 1;

                    }
                    if (Keyboard.current.dKey.wasPressedThisFrame && Decanoid.Phase > 3)
                    {
                        AudioManager.Instance.PlaySfx("Folhear");
                        Page2.gameObject.SetActive(false);
                        Page = 3;

                    }
                    break;
                case 3:
                    Page3.gameObject.SetActive(true);
                    if (Keyboard.current.aKey.wasPressedThisFrame)
                    {
                        AudioManager.Instance.PlaySfx("Folhear");
                        Page3.gameObject.SetActive(false);
                        Page = 2;

                    }
                    if (Keyboard.current.dKey.wasPressedThisFrame)
                    {
                        AudioManager.Instance.PlaySfx("Folhear");
                        Page3.gameObject.SetActive(false);
                        Page = 4;

                    }
                    break;
                case 4:
                    Page4.gameObject.SetActive(true);
                    if (Keyboard.current.aKey.wasPressedThisFrame)
                    {
                        AudioManager.Instance.PlaySfx("Folhear");
                        Page4.gameObject.SetActive(false);
                        Page = 3;

                    }
                    break;

            }

        }

    }
    public void OpenBook()
    {
        Decanoid.On = false;
        Open = true;
        Book1.gameObject.SetActive(true);
        AudioManager.Instance.PlaySfx("BotaoLivro");
    }
}

