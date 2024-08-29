using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LyraSpawner : MonoBehaviour
{
    COrpheu cOrpheu;
    public GameObject COrpheu;

    public float CtimeGhost;
    public float StimeGhost = 3;
    public bool Ghost;

    public bool Music;
    public float CtimeMusic;
    public float StimeMusic = 6;

    public GameObject Nota1;
    public GameObject Nota2;
    public GameObject Espirito1;
    public GameObject Espirito2;
    public GameObject Espirito3;


    // Start is called before the first frame update
    void Start()
    {
        cOrpheu = COrpheu.GetComponent<COrpheu>();


        StimeGhost = 3;
        CtimeGhost = 3;
        StimeMusic = 6;
        CtimeMusic = 6;

        Ghost = true;
        Music = true;
        Decanoid.ACTIVE = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (Decanoid.On == true)
        {
            if (Decanoid.ACTIVE == true)
            {
                //Timer Obstaculos

                if (CtimeGhost >= 0.01f) { CtimeGhost -= 1 * Time.deltaTime; }
                if (CtimeGhost < 1f && Ghost == true)
                {
                    Invoke("SpawnGhost", 0);
                    Ghost = false;

                }
                if (CtimeGhost < 0.1f)
                {
                    switch (cOrpheu.Stage)
                    {
                        case 1:
                            StimeGhost = 2f;
                            
                            CtimeGhost = StimeGhost;
                            Ghost = true;
                            break;
                        case 2:
                            StimeGhost = 1.8f;

                            CtimeGhost = StimeGhost;
                            Ghost = true;
                            break;
                        case 3:
                            StimeGhost = 1.5f;

                            CtimeGhost = StimeGhost;
                            Ghost = true;
                            break;
                    }
                }
                //Timer Arrows
                if (CtimeMusic >= 0.01f) { CtimeMusic -= 1 * Time.deltaTime; }
                if (CtimeMusic < 1f && Music == true)
                {
                    Invoke("SpawnMusic", 0);
                    Music = false;

                }
                if (CtimeMusic < 0.1f)
                {
                    CtimeMusic = StimeMusic;
                    Music = true;
                }
            }
        }
    }

    private void SpawnMusic()
    {
        int randomobs = Random.Range(0, 2);

        float X = Random.Range(-4f, 4f);
        float Y = 9f;

        if (randomobs == 0)
        {
            Instantiate(Nota1, transform.position + new Vector3(X, Y, 0), transform.rotation);
        }
        else
        {
            Instantiate(Nota2, transform.position + new Vector3(X, Y, 0), transform.rotation);
        }

    }
    private void SpawnGhost()
    {

        float X = Random.Range(-4f, 4f);
        float Y = Random.Range(9f, 12f);
        switch (cOrpheu.Stage)
        {
            case 1:
                Instantiate(Espirito1, transform.position + new Vector3(X, Y, 0), transform.rotation);
                break;
            case 2:
                Instantiate(Espirito2, transform.position + new Vector3(X, Y, 0), transform.rotation);
                break;
            case 3:
                 Instantiate(Espirito3, transform.position + new Vector3(X, Y, 0), transform.rotation);
                break;
        }

    }

}
