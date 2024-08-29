using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
public class COrpheu : MonoBehaviour
{
    public float Velocidade = 10;
    public float DownForce = 2f;
    public bool canInteract;
    public bool WaitCol = false;

    public CinemachineVirtualCamera myCinemachine;
    public Transform Cam2;
    public float Stage;
    public float Lyra;

    CLife cLife;
    public GameObject Life;

    LevelLoader levelLoader;
    public GameObject LevelLoader;

    public Animator animator;
    public Animator Orpheu;
    public Animator Euridice;
    public Animator ALyra;

    public GameObject collidedObject;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.PlaySfx("Tele");
        AudioManager.Instance.PlayMusic("LyraMusic");

        cLife = Life.GetComponent<CLife>();
        levelLoader = LevelLoader.GetComponent<LevelLoader>();

        WaitCol = true;
        Stage = 1;
        Lyra = 0;
        canInteract = false;
    }
    void Update()
    {
        if (Keyboard.current.eKey.isPressed)
        {
            // Lyra Blast
            if (canInteract)
            {
                if (WaitCol)
                {
                    switch (Stage)
                    {
                        case 1:
                            Orpheu.SetTrigger("Lyra");
                            AudioManager.Instance.PlaySfx("AtaqueLyra");

                            Stage = 2;
                            WaitCol = false;
                            Invoke("Wait", 2);
                            
                            canInteract = false;
                            break;
                        case 2:
                            AudioManager.Instance.PlaySfx("AtaqueLyra");
                            Orpheu.SetTrigger("Lyra");
                            WaitCol = false;

                            Invoke("Stagetres", 5);
                            Invoke("Wait", 2);

                            canInteract = false;
                            break;
                        case 3:
                            AudioManager.Instance.PlaySfx("AtaqueLyra");
                            Orpheu.SetTrigger("Lyra");

                            StartCoroutine(LastAnim());

                            WaitCol = false;
                            myCinemachine.m_Follow = Cam2;
                            Invoke("GoBack", 9);

                            canInteract = false;
                            break;
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Decanoid.On == true)
        {
            // Movement
            animator.speed = 1f;

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
                animator.speed = 1.4f;
                verticalMovement = 1f;
            }
            else if (Keyboard.current.sKey.isPressed)
            {
                verticalMovement = -1f;
            }

            // Força Baixo
            if (!Keyboard.current.wKey.isPressed)
            {
                verticalMovement = -DownForce;
            }

            Vector3 movement = new Vector3(horizontalMovement, verticalMovement, 0f).normalized;

            if (movement.magnitude > 0f)
            {
                float speedMultiplier = 1f;

                if (verticalMovement < 0f)
                {
                    //Down
                    speedMultiplier *= .3f;
                }
                else if (verticalMovement > 0f)
                {
                    //Up
                    speedMultiplier *= .3f;
                }
                else if (horizontalMovement != 0f)
                {
                    //Sides
                    speedMultiplier *= 2f;
                }

                this.GetComponent<Rigidbody2D>().MovePosition(transform.position + movement * Velocidade * speedMultiplier * Time.deltaTime);
            }
        }

        //Lyra
        switch (Lyra)
        {
            case 0:
                ALyra.SetTrigger("0");
                break;
            case 1:
                ALyra.SetTrigger("1");
                break;
            case 2:
                ALyra.SetTrigger("2");
                break;
            case 3:
                ALyra.SetTrigger("3");
                break;
            case 4:
                ALyra.SetTrigger("4");
                break;
            case 5:
                ALyra.SetTrigger("5");
                break;
            case 6:
                ALyra.SetTrigger("6");
                break;
        }

        //GameOver

        if (cLife.Lives == 0)
        {
            AudioManager.Instance.PlaySfx("Lose");
            Decanoid.On = false;
            Decanoid.ACTIVE = false;
            Orpheu.SetTrigger("Die");
            Euridice.SetTrigger("Idle");

            AudioManager.Instance.PlaySfx("TransClose");
            myCinemachine.m_Follow = Cam2;
            levelLoader.transition.SetTrigger("Stop");
            levelLoader.Invoke("GameO", 4);

        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        // Collision
        switch (col.gameObject.tag)
        {
            case "Ghost":
                cLife.Lives -= 1;
                Orpheu.SetTrigger("Damage");
                AudioManager.Instance.PlaySfx("Dano");

                Decanoid.DestroyGhost = true;
                break;

            case "Music":
                Lyra += 1f;
                if (Lyra > 5) { canInteract = true; }

                Decanoid.DestroyMusic = true;
                break;
        }
    }
    public void Wait()
    {
        WaitCol = true;
        Lyra = 0;
    }
    public void Stagetres()
    {
        Stage = 3;
    }
    public IEnumerator LastAnim()
    {
        Decanoid.ACTIVE = false;

        yield return new WaitForSeconds(5f);
        Decanoid.On = false;
        Orpheu.SetTrigger("End");
        Euridice.SetTrigger("End");

        yield return new WaitForSeconds(3.5f);
        Euridice.SetTrigger("Die");
    }
    public void GoBack()
    {
        AudioManager.Instance.PlaySfx("TransClose");
        levelLoader.transition.SetTrigger("Stop");
        levelLoader.Invoke("Levels", 3);
        if (Decanoid.Phase < 4) { Decanoid.Phase = 4; }
        Decanoid.On = false;
    }
}
