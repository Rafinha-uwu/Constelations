using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    CScorpion cScorpion;
    public GameObject CScorpion;

    public float CtimeObs;
    public float StimeObs = 15;
    public GameObject Obs1;
    public GameObject Obs2;
    public bool Obs;

    public bool Arr;
    public float CtimeArr;
    public float StimeArr = 3;

    public GameObject Arr1;
    public GameObject Arr2;
    public GameObject Arr3;
    public GameObject Arr4;
    public GameObject Arr5;
    public GameObject Arr6;
    public GameObject Arr7;
    public GameObject Arr8;
    public GameObject Arr9;

    // Start is called before the first frame update
    void Start()
    {
        cScorpion = CScorpion.GetComponent<CScorpion>();


        StimeObs = 15;
        CtimeObs = 15;
        StimeArr = 3;
        CtimeArr = 3;

        Obs = true;
        Arr = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (Decanoid.On == true)
        {
            if (Decanoid.ACTIVE == true)
            {
                //Timer Obstaculos

                if (CtimeObs >= 0.01f) { CtimeObs -= 1 * Time.deltaTime; }
                if (CtimeObs < 10f && Obs == true)
                {
                    Invoke("SpawnObs", 0);
                    Obs = false;

                }
                if (CtimeObs < 0.1f)
                {
                    CtimeObs = StimeObs;
                    Obs = true;

                }
                //Timer Arrows
                if (CtimeArr >= 0.01f) { CtimeArr -= 1 * Time.deltaTime; }
                if (CtimeArr < 1f && Arr == true)
                {
                    Invoke("SpawnArr", 0);
                    Arr = false;

                }
                if (CtimeArr < 0.1f)
                {
                    switch (cScorpion.Stage)
                    {
                        case 1:
                            StimeArr = 3f;
                            CtimeArr = StimeArr;
                            Arr = true;
                            break;
                        case 2:
                            StimeArr = 5f;
                            CtimeArr = StimeArr;
                            Arr = true;
                            break;
                        case 3:
                            StimeArr = 8f;
                            CtimeArr = StimeArr;
                            Arr = true;
                            break;
                    }

                }
            }
        }
    }

    private void SpawnObs()
    {

        int randomobs = Random.Range(0, 2);

        float X = Random.Range(-4f, 4f);
        float Y = 9f;

        if (randomobs == 0)
        {
            Instantiate(Obs1, transform.position + new Vector3(X, Y, 0), transform.rotation);
        }
        else
        {
            Instantiate(Obs2, transform.position + new Vector3(X, Y, 0), transform.rotation);
        }
    }
    private void SpawnArr()
    {
        int randomArr = Random.Range(0, 3);
        float Y = 12f;

        switch (cScorpion.Stage)
        {
            case 1:

                if (randomArr == 0)
                {
                    Instantiate(Arr1, transform.position + new Vector3(0, Y, 0), transform.rotation);
                }
                if (randomArr == 1)
                {
                    Instantiate(Arr2, transform.position + new Vector3(0, Y, 0), transform.rotation);
                }
                if (randomArr == 2)
                {
                    Instantiate(Arr3, transform.position + new Vector3(0, Y, 0), transform.rotation);
                }
                break;
            case 2:

                if (randomArr == 0)
                {
                    Instantiate(Arr4, transform.position + new Vector3(0, Y, 0), transform.rotation);
                }
                if (randomArr == 1)
                {
                    Instantiate(Arr5, transform.position + new Vector3(0, Y, 0), transform.rotation);
                }
                if (randomArr == 2)
                {
                    Instantiate(Arr6, transform.position + new Vector3(0, Y, 0), transform.rotation);
                }
                break;
            case 3:

                if (randomArr == 0)
                {
                    Instantiate(Arr7, transform.position + new Vector3(0, Y, 0), transform.rotation);
                }
                if (randomArr == 1)
                {
                    Instantiate(Arr8, transform.position + new Vector3(0, Y, 0), transform.rotation);
                }
                if (randomArr == 2)
                {
                    Instantiate(Arr9, transform.position + new Vector3(0, Y, 0), transform.rotation);
                }
                break;
        }
    }
}
