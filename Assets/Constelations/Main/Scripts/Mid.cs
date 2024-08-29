using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Mid : MonoBehaviour
{
    public bool Pressed = true;

    LevelLoader levelLoader;
    public GameObject LevelLoader;

    public Transform Button;
    public Animator AButton;

    public Transform Oriona;
    public Transform Orionb;
    public Transform Orionc;

    public Animator AOriona;
    public Animator AOrionb;
    public Animator AOrionc;

    public Transform Aquaa;
    public Transform Aquab;
    public Transform Aquac;

    public Animator AAquaa;
    public Animator AAquab;
    public Animator AAquac;

    public Transform Lyraa;
    public Transform Lyrab;
    public Transform Lyrac;

    public Animator ALyraa;
    public Animator ALyrab;
    public Animator ALyrac;

    private string Level;

    // Start is called before the first frame update
    void Start()
    {
        Pressed = false;
        levelLoader = LevelLoader.GetComponent<LevelLoader>();

        //Read wich Level to go
        switch (Decanoid.Current)
        {
            case 1:
                StartCoroutine(Orion1());
                break;
            case 2:
                StartCoroutine(Aqua1());
                break;
            case 3:
                StartCoroutine(Lyra1());
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.eKey.isPressed && Pressed == true)
        {
            AudioManager.Instance.PlaySfx("SecButton");
            switch (Level)
            {
                case "Orion1":
                    StartCoroutine(Orion15());
                    break;
                case "Orion2":
                    StartCoroutine(Orion25());
                    break;
                case "Orion3":
                    StartCoroutine(Orion35());
                    break;
                case "Aqua1":
                    StartCoroutine(Aqua15());
                    break;
                case "Aqua2":
                    StartCoroutine(Aqua25());
                    break;
                case "Aqua3":
                    StartCoroutine(Aqua35());
                    break;
                case "Lyra1":
                    StartCoroutine(Lyra15());
                    break;
                case "Lyra2":
                    StartCoroutine(Lyra25());
                    break;
                case "Lyra3":
                    StartCoroutine(Lyra35());
                    break;

            }
        }

    }
    public IEnumerator Orion1()
    {
        Level = "Orion1";
        yield return new WaitForSeconds(1f);

        Oriona.gameObject.SetActive(true);
        AOriona.SetTrigger("FadeIn");

        yield return new WaitForSeconds(4f);

        Button.gameObject.SetActive(true);
        AButton.SetTrigger("FadeIn");

        yield return new WaitForSeconds(1f);

        Pressed = true;
    }

    public IEnumerator Orion15()
    {
        Pressed = false;

        AOriona.SetTrigger("FadeOut");
        AButton.SetTrigger("FadeOut");

        yield return new WaitForSeconds(1f);

        Oriona.gameObject.SetActive(false);
        Button.gameObject.SetActive(false);

        StartCoroutine(Orion2());

    }

    public IEnumerator Orion2()
    {
        Level = "Orion2";
        yield return new WaitForSeconds(1f);

        Orionb.gameObject.SetActive(true);
        AOrionb.SetTrigger("FadeIn");

        yield return new WaitForSeconds(4f);

        Button.gameObject.SetActive(true);
        AButton.SetTrigger("FadeIn");

        yield return new WaitForSeconds(1f);

        Pressed = true;
    }

    public IEnumerator Orion25()
    {
        Pressed = false;

        AOrionb.SetTrigger("FadeOut");
        AButton.SetTrigger("FadeOut");

        yield return new WaitForSeconds(1f);

        Orionb.gameObject.SetActive(false);
        Button.gameObject.SetActive(false);

        StartCoroutine(Orion3());

    }
    public IEnumerator Orion3()
    {
        Level = "Orion3";
        yield return new WaitForSeconds(1f);

        Orionc.gameObject.SetActive(true);
        AOrionc.SetTrigger("FadeIn");

        yield return new WaitForSeconds(4f);

        Button.gameObject.SetActive(true);
        AButton.SetTrigger("FadeIn");

        yield return new WaitForSeconds(1f);

        Pressed = true;
    }

    public IEnumerator Orion35()
    {
        Pressed = false;

        AOrionc.SetTrigger("FadeOut");
        AButton.SetTrigger("FadeOut");

        yield return new WaitForSeconds(1f);

        Orionc.gameObject.SetActive(false);
        Button.gameObject.SetActive(false);

        yield return new WaitForSeconds(4f);

        levelLoader.Invoke("Orion", 0);

    }
    public IEnumerator Aqua1()
    {
        Level = "Aqua1";
        yield return new WaitForSeconds(1f);

        Aquaa.gameObject.SetActive(true);
        AAquaa.SetTrigger("FadeIn");

        yield return new WaitForSeconds(4f);

        Button.gameObject.SetActive(true);
        AButton.SetTrigger("FadeIn");

        yield return new WaitForSeconds(1f);

        Pressed = true;
    }
    public IEnumerator Aqua15()
    {
        Pressed = false;

        AAquaa.SetTrigger("FadeOut");
        AButton.SetTrigger("FadeOut");

        yield return new WaitForSeconds(1f);

        Aquaa.gameObject.SetActive(false);
        Button.gameObject.SetActive(false);

        StartCoroutine(Aqua2());

    }
    public IEnumerator Aqua2()
    {
        Level = "Aqua2";
        yield return new WaitForSeconds(1f);

        Aquab.gameObject.SetActive(true);
        AAquab.SetTrigger("FadeIn");

        yield return new WaitForSeconds(4f);

        Button.gameObject.SetActive(true);
        AButton.SetTrigger("FadeIn");

        yield return new WaitForSeconds(1f);

        Pressed = true;
    }
    public IEnumerator Aqua25()
    {
        Pressed = false;

        AAquab.SetTrigger("FadeOut");
        AButton.SetTrigger("FadeOut");

        yield return new WaitForSeconds(1f);

        Aquab.gameObject.SetActive(false);
        Button.gameObject.SetActive(false);

        StartCoroutine(Aqua3());

    }
    public IEnumerator Aqua3()
    {
        Level = "Aqua3";
        yield return new WaitForSeconds(1f);

        Aquac.gameObject.SetActive(true);
        AAquac.SetTrigger("FadeIn");

        yield return new WaitForSeconds(4f);

        Button.gameObject.SetActive(true);
        AButton.SetTrigger("FadeIn");

        yield return new WaitForSeconds(1f);

        Pressed = true;
    }
    public IEnumerator Aqua35()
    {
        Pressed = false;

        AAquac.SetTrigger("FadeOut");
        AButton.SetTrigger("FadeOut");

        yield return new WaitForSeconds(1f);

        Aquac.gameObject.SetActive(false);
        Button.gameObject.SetActive(false);

        yield return new WaitForSeconds(4f);

        levelLoader.Invoke("Aqua", 0);

    }
    public IEnumerator Lyra1()
    {
        Level = "Lyra1";
        yield return new WaitForSeconds(1f);

        Lyraa.gameObject.SetActive(true);
        ALyraa.SetTrigger("FadeIn");

        yield return new WaitForSeconds(4f);

        Button.gameObject.SetActive(true);
        AButton.SetTrigger("FadeIn");

        yield return new WaitForSeconds(1f);

        Pressed = true;
    }
    public IEnumerator Lyra15()
    {
        Pressed = false;

        ALyraa.SetTrigger("FadeOut");
        AButton.SetTrigger("FadeOut");

        yield return new WaitForSeconds(1f);

        Lyraa.gameObject.SetActive(false);
        Button.gameObject.SetActive(false);

        StartCoroutine(Lyra2());
    }
    public IEnumerator Lyra2()
    {
        Level = "Lyra2";
        yield return new WaitForSeconds(1f);

        Lyrab.gameObject.SetActive(true);
        ALyrab.SetTrigger("FadeIn");

        yield return new WaitForSeconds(4f);

        Button.gameObject.SetActive(true);
        AButton.SetTrigger("FadeIn");

        yield return new WaitForSeconds(1f);

        Pressed = true;
    }
    public IEnumerator Lyra25()
    {
        Pressed = false;

        ALyrab.SetTrigger("FadeOut");
        AButton.SetTrigger("FadeOut");

        yield return new WaitForSeconds(1f);

        Lyrab.gameObject.SetActive(false);
        Button.gameObject.SetActive(false);

        StartCoroutine(Lyra3());
    }
    public IEnumerator Lyra3()
    {
        Level = "Lyra3";
        yield return new WaitForSeconds(1f);

        Lyrac.gameObject.SetActive(true);
        ALyrac.SetTrigger("FadeIn");

        yield return new WaitForSeconds(4f);

        Button.gameObject.SetActive(true);
        AButton.SetTrigger("FadeIn");

        yield return new WaitForSeconds(1f);

        Pressed = true;
    }
    public IEnumerator Lyra35()
    {
        Pressed = false;

        ALyrac.SetTrigger("FadeOut");
        AButton.SetTrigger("FadeOut");

        yield return new WaitForSeconds(1f);

        Lyrac.gameObject.SetActive(false);
        Button.gameObject.SetActive(false);

        yield return new WaitForSeconds(4f);

        levelLoader.Invoke("Lyra", 0);
    }
}