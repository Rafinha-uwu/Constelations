using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CJogador : MonoBehaviour
{
    public float Velocidade = 10;
    public bool Cup = false;
    public bool canInteract = false;

    public GameObject SpritePlayer;

    public Animator Hades;
    public Animator Poseidon;
    public Animator Zeus;

    CTimer cTimer;
    public GameObject Timer;

    CLife cLife;
    public GameObject Life;

    LevelLoader levelLoader;
    public GameObject LevelLoader;


    void Start()
    {
        AudioManager.Instance.PlaySfx("Tele");
        AudioManager.Instance.PlayMusic("AquaMusic");

        levelLoader = LevelLoader.GetComponent<LevelLoader>();
        cLife = Life.GetComponent<CLife>();
        cTimer = Timer.GetComponent<CTimer>();

        cTimer.Stage = 1;
        Cup = false;

        this.transform.position = new Vector3(0, 0, 0);
    }

    private void Update()
    {
        //Mesa Ativar
        if (canInteract == true && Keyboard.current.eKey.isPressed)
        {
            switch (cTimer.Stage)
            {
                case 1:
                    cTimer.Stime = 60f;
                    break;
                case 2:
                    cTimer.Stime = 50f;
                    break;
                case 3:
                    cTimer.Stime = 40f;
                    break;
            }

            cTimer.Ctime = cTimer.Stime;
            cTimer.Active = true;
            Cup = true;
        }
    }

    private void FixedUpdate()
    {
        if (Decanoid.On == true)
        {
            // Movement

            float horizontalMovement = 0f;
            if (Keyboard.current.aKey.isPressed)
            {
                horizontalMovement = -1f;
            }
            else if (Keyboard.current.dKey.isPressed)
            {
                horizontalMovement = 1f;
            }

            float verticalMovement = 0f;
            if (Keyboard.current.wKey.isPressed)
            {
                verticalMovement = 1f;
            }
            else if (Keyboard.current.sKey.isPressed)
            {
                verticalMovement = -1f;
            }

            Vector3 movement = new Vector3(horizontalMovement, verticalMovement, 0f).normalized;

            if (movement.magnitude > 0f)
            {
                this.transform.Translate(movement * Velocidade * Time.deltaTime);
            }

            // Animation

            if (Cup == false)
            {
                if (movement.magnitude > 0f)
                {
                    float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
                    if (angle > -45f && angle <= 45f)
                    {
                        SpritePlayer.GetComponent<Animator>().Play("dir");
                    }
                    else if (angle > 45f && angle <= 135f)
                    {
                        SpritePlayer.GetComponent<Animator>().Play("cima");
                    }
                    else if (angle > 135f || angle <= -135f)
                    {
                        SpritePlayer.GetComponent<Animator>().Play("esq");
                    }
                    else if (angle > -135f && angle <= -45f)
                    {
                        SpritePlayer.GetComponent<Animator>().Play("baixo");
                    }
                }
                else
                {
                    SpritePlayer.GetComponent<Animator>().Play("idle");
                }
            }

            if (Cup == true)
            {
                if (movement.magnitude > 0f)
                {
                    float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
                    if (angle > -45f && angle <= 45f)
                    {
                        SpritePlayer.GetComponent<Animator>().Play("dir_copo");
                    }
                    else if (angle > 45f && angle <= 135f)
                    {
                        SpritePlayer.GetComponent<Animator>().Play("cima_copo");
                    }
                    else if (angle > 135f || angle <= -135f)
                    {
                        SpritePlayer.GetComponent<Animator>().Play("esq_copo");
                    }
                    else if (angle > -135f && angle <= -45f)
                    {
                        SpritePlayer.GetComponent<Animator>().Play("baixo_copo");
                    }
                }
                else
                {
                    SpritePlayer.GetComponent<Animator>().Play("idle_copo");
                }
            }

        }

        //GameOver

        if (cLife.Lives == 0)
        {
            AudioManager.Instance.PlaySfx("Lose");

            if (Cup == false) { SpritePlayer.GetComponent<Animator>().Play("fall"); }
            if (Cup == true) { SpritePlayer.GetComponent<Animator>().Play("fall_withcup"); }
            Decanoid.On = false;

            levelLoader.transition.SetTrigger("Stop");
            levelLoader.Invoke("GameO", 4);

        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {

        // Estatuas 

        switch (col.gameObject.name)
        {
            case "Hades":
                if (cTimer.Stage == 1 && Cup == true)
                {
                    AudioManager.Instance.PlaySfx("Deliver");
                    Hades.SetTrigger("AHades");
                    cTimer.Stage = 2;
                    Invoke("Restart", 0);
                }
                break;

            case "Poseidon":
                if (cTimer.Stage == 2 && Cup == true)
                {
                    AudioManager.Instance.PlaySfx("Deliver");
                    Poseidon.SetTrigger("APoseidon");
                    cTimer.Stage = 3;
                    Invoke("Restart", 0);
                }
                break;

            case "Zeus":
                if (cTimer.Stage == 3 && Cup == true)
                {
                    AudioManager.Instance.PlaySfx("Deliver");
                    cTimer.Stage = 4;
                    cTimer.Active = false;

                    Decanoid.On = false;
                    Cup = false;
                    AudioManager.Instance.PlaySfx("Win");
                    SpritePlayer.GetComponent<Animator>().Play("idle");
                    Zeus.SetTrigger("AZeus");
                    AudioManager.Instance.PlaySfx("TransClose");

                    levelLoader.transition.SetTrigger("Stop");
                    levelLoader.Invoke("Levels", 3);
                    if (Decanoid.Phase < 3) { Decanoid.Phase = 3; }

                }
                break;

            case "Grab":
                AudioManager.Instance.PlaySfx("Grab");
                //Mesa 
                canInteract = true;
                break;
        }
    }

    // De-Interact

    private void OnCollisionExit2D(Collision2D collision)
    {
        canInteract = false;
    }
    //Restart

    void Restart() { StartCoroutine(RestartAction()); }
    public IEnumerator RestartAction()
    {
        AudioManager.Instance.PlaySfx("TP");
        cTimer.Ctime = 50f;
        cTimer.Active = false;

        Decanoid.On = false;

        SpritePlayer.GetComponent<Animator>().Play("tp_out");

        yield return new WaitForSeconds(1f);

        Cup = false;
        this.transform.position = new Vector3(0, 0, 0);

        yield return new WaitForSeconds(1f);

        Decanoid.On = true;
    }
}