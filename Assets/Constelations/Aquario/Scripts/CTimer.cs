using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTimer : MonoBehaviour
{
    public bool Active = false;
    public float Stage = 1;
    public float Ctime = 0f;
    public float Stime = 5f;

    public Animator HourGlass;


    CLife cLife;
    public GameObject Life;

    CJogador cjogador;
    public GameObject Jogador;

    CTarget ctarget;
    public GameObject Target;

    // Start is called before the first frame update
    void Start()
    {
        cjogador = Jogador.GetComponent<CJogador>();
        cLife = Life.GetComponent<CLife>();
        ctarget = Target.GetComponent<CTarget>();

        Stage = 1;
    }

    // Update is called once per frame
    void Update()
    {

        //Countdown 

        if (Active == true)
        {
            if (Ctime >= 0.01f) { Ctime -= 1 * Time.deltaTime; }
            if (Ctime < 0.1f)
            {
                cLife.Lives -= 1;
                Active = false;

                if (cLife.Lives > 0) { cjogador.Invoke("Restart", 0); } 
            }
        }

        //Target

        if (cjogador.Cup == false) { ctarget.Target = ctarget.Mesa; }
        if (cjogador.Cup == true)
        {
            switch (Stage)
            {
                case 1:
                    ctarget.Target = ctarget.Hades;

                    //Timer Animation

                    if (Ctime >= 40f) { HourGlass.SetTrigger("1"); }

                    break;
                case 2:
                    ctarget.Target = ctarget.Poseidon;

                    //Timer Animation

                    if (Ctime >= 37f) { HourGlass.SetTrigger("1"); }

                    break;
                case 3:
                    ctarget.Target = ctarget.Zeus;

                    //Timer Animation

                    if (Ctime >= 35f) { HourGlass.SetTrigger("1"); }

                    break;
                case 4:
                    ctarget.TargetActive(false);
                    break;

            }

            if (Ctime >= 10f && Ctime < 20f) { HourGlass.SetTrigger("2"); }
            if (Ctime < 10f) { HourGlass.SetTrigger("3"); }
            if (Active == false) { HourGlass.SetTrigger("Idle"); }
        }
    }

}
