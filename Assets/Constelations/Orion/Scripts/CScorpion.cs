using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
public class CScorpion : MonoBehaviour
{
    public float Velocidade = 10;
    public float DownForce = 2f;
    public bool canInteract = false;
    public bool WaitCol = false;

    public CinemachineVirtualCamera myCinemachine;
    public Transform Scorpio;
    public float Stage;

    CLife cLife;
    public GameObject Life;

    LevelLoader levelLoader;
    public GameObject LevelLoader;

    public bool Hit;

    public Animator animator;
    public Animator Scorpion;
    public Animator OrionSprite;

    public GameObject collidedObject;

    // Start is called before the first frame update
    void Start()
    {
        cLife = Life.GetComponent<CLife>();
        levelLoader = LevelLoader.GetComponent<LevelLoader>();

        WaitCol = true;
        Stage = 1;
    }
    private void Update()
    {
        if (Keyboard.current.eKey.isPressed)
        {

            if (WaitCol == true)
            {
                Scorpion.SetTrigger("Atack"); ;
            }

            //Atack
            if (canInteract == true)
            {
                if (WaitCol == true)
                {
                    AudioManager.Instance.PlaySfx("Atack");
                    switch (Stage)
                    {
                        case 1:
                            OrionSprite.SetTrigger("Damage");
                            Hit = true;
                            Stage = 2;
                            WaitCol = false;
                            Invoke("Wait", 5);
                            break;
                        case 2:
                            OrionSprite.SetTrigger("Damage");
                            Hit = true;
                            WaitCol = false;
                            Invoke("Stagetres", 5);
                            Invoke("Wait", 5);

                            break;
                        case 3:
                            OrionSprite.SetTrigger("Die");
                            Scorpion.SetTrigger("Idle");
                            Hit = true;
                            WaitCol = false;
                            Invoke("Wait", 5);
                            AudioManager.Instance.PlaySfx("Win");
                            myCinemachine.m_Follow = Scorpio;
                            levelLoader.transition.SetTrigger("Stop");
                            levelLoader.Invoke("Levels", 6);
                            if (Decanoid.Phase < 2) { Decanoid.Phase = 2; }
                            Decanoid.On = false;
                            AudioManager.Instance.PlaySfx("TransClose");
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
                animator.speed = 1.3f;
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
                    speedMultiplier *= .5f;
                }
                else if (verticalMovement > 0f)
                {
                    //Up
                    speedMultiplier *= .3f;
                }
                else if (horizontalMovement != 0f)
                {
                    //Sides
                    speedMultiplier *= 1f;
                }

                this.GetComponent<Rigidbody2D>().MovePosition(transform.position + movement * Velocidade * speedMultiplier * Time.deltaTime);
            }
        }

        //GameOver

        if (cLife.Lives == 0)
        {
            AudioManager.Instance.PlaySfx("Lose");

            Scorpion.SetTrigger("Die");
            Decanoid.On = false;

            myCinemachine.m_Follow = Scorpio;
            AudioManager.Instance.PlaySfx("TransClose");
            levelLoader.transition.SetTrigger("Stop");
            levelLoader.Invoke("GameO", 4);

        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        // Colision
        switch (col.gameObject.name)
        {
            case "Orion":
                canInteract = true;
                break;

        }
        switch (col.gameObject.tag)
        {
            case "Obstacle":
                AudioManager.Instance.PlaySfx("1Life");
                Scorpion.SetTrigger("Damage");
                Decanoid.Destroy = true;
                cLife.Lives -= 1;
                break;
            case "Arrow":

                collidedObject = col.collider.gameObject;
                AudioManager.Instance.PlaySfx("1Life");
                cLife.Lives -= 1;
                Scorpion.SetTrigger("Damage");
                Decanoid.DestroyArr = true;
                break;

        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        canInteract = false;
    }
    public void Wait()
    {
        WaitCol = true;
    }
    public void Stagetres()
    {
        Stage = 3;
    }

}
