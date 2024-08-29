using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CLife : MonoBehaviour
{
    public Sprite Vida3;
    public Sprite Vida2;
    public Sprite Vida1;
    public Sprite Vida0;
    public float Lives = 3;

    // Start is called before the first frame update
    void Start()
    {
        Lives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        //Lives

        switch (Lives)
        {

            case 3:
                gameObject.GetComponentInChildren<Image>().sprite = Vida3;
                break;

            case 2:
                gameObject.GetComponentInChildren<Image>().sprite = Vida2;
                break;

            case 1:
                gameObject.GetComponentInChildren<Image>().sprite = Vida1;
                break;

            case 0:
                gameObject.GetComponentInChildren<Image>().sprite = Vida0;
                break;
        }
    }
}
