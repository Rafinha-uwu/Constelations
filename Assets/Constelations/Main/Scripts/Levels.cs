using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Levels : MonoBehaviour
{
    public float ShowPhase = 1;

    public CinemachineVirtualCamera myCinemachine;
    public Transform Follow;
    public Transform Player;

    public Color Normal;

    public SpriteRenderer Pad1;
    public SpriteRenderer Pad2;
    public SpriteRenderer Pad3;

    public SpriteRenderer Star1;
    public SpriteRenderer Star2;
    public SpriteRenderer Star3;


    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.PlaySfx("TransOpen");
        Cursor.visible = true;
        Decanoid.Current = 0;
        Decanoid.On = true;

        AudioManager.Instance.PlayMusic("OceanAmbient");
        AudioManager.Instance.PlayMusic("MusicLevels");
        //AudioManager.Instance.musicSource.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        //Lock on levelsa
        ShowPhase = Decanoid.Phase;
        switch (Decanoid.Phase)
        {
            case 1:
                if(Decanoid.First == false) { StartCoroutine(OnlyOnce()); }
                break;
            case 2:
                Pad1.enabled = false;
                Star1.color = Normal;
                break;
            case 3:
                Pad1.enabled = false;
                Star1.color = Normal;
                Pad2.enabled = false;
                Star2.color = Normal;
                break;
            case 4:
                Pad1.enabled = false;
                Star1.color = Normal;
                Pad2.enabled = false;
                Star2.color = Normal;
                Pad3.enabled = false;
                Star3.color = Normal;
                break;
        }
    }
    //Beguining Follow
    public IEnumerator OnlyOnce()
    {
        Decanoid.On = false;
        myCinemachine.m_Follow = Follow; 
        Decanoid.First = true;

        yield return new WaitForSeconds(7f);

        myCinemachine.m_Follow = Player;
        Decanoid.On = true;
    }
    }
