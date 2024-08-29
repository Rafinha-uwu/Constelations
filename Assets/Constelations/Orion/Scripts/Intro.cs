using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Intro : MonoBehaviour
{
    public CinemachineVirtualCamera myCinemachine;
    public Transform Follow;
    public Transform Player;

    public Animator Mask;
    public float Tempo =7f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Começar());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator Começar()
    {
        Decanoid.On = false;
        this.enabled = true;
        myCinemachine.m_Follow = Follow;

        yield return new WaitForSeconds(Tempo);

        Mask.SetTrigger("Start");

        myCinemachine.m_Follow = Player;
        Decanoid.On = true;
        this.enabled = false;
    }
}
