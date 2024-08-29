using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class Night : MonoBehaviour
{
    LevelLoader levelLoader;
    public GameObject LevelLoader;

    public SpriteRenderer Lvlum;
    public SpriteRenderer Lvldois;
    public SpriteRenderer Lvltres;

    public Color Normal;

    public Transform Back;
    public Transform Credits;
    public Animator ACreditos;
    public Animator ABack;

    public CinemachineVirtualCamera Cam;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.PlaySfx("Tele");
        AudioManager.Instance.PlayMusic("MusicLevels");
        levelLoader = LevelLoader.GetComponent<LevelLoader>();

        // Ativo ou desativo
        switch (Decanoid.Current)
        {
            case 1:
                Lvlum.color = Normal;
                break;
            case 2:
                Lvldois.color = Normal;
                break;
            case 3:
                Lvltres.color = Normal;
                break;
            case 4:
                StartCoroutine(Ending());

                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Creditos
    public IEnumerator Ending()
    {
        Cursor.visible = false;
        Cam.gameObject.SetActive(true);
        Credits.gameObject.SetActive(true);
        ACreditos.SetTrigger("Start");

        yield return new WaitForSeconds(17f);
        Cursor.visible = true;
        Back.gameObject.SetActive(true);
        ABack.SetTrigger("Start");
    }
    //Button back
    public void FinalBack()
    {
        levelLoader.transition.SetTrigger("Start");
        levelLoader.Invoke("Startofitall", 1);
    }

}
