using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class COrion : MonoBehaviour
{
    CScorpion cScorpion;
    public GameObject CScorpion;

    public float Ctime = 0f;
    public float Stime = 30f;

    public bool AtackT;
    public bool Once;

    public Animator OrionSprite;
    public Animator Orion;

    public Transform Arrow;
    public Animator AArrow;

    // Start is called before the first frame update
    void Start()
    {
        cScorpion = CScorpion.GetComponent<CScorpion>();

        AudioManager.Instance.PlaySfx("Tele");
        AudioManager.Instance.PlayMusic("OrionMusic");

        Stime = 30f;
        Ctime = Stime;

        AtackT = false;
        Once = false;

        Decanoid.On = false;

        StartCoroutine(OrionStart());
    }

    // Update is called once per frame
    void Update()
    {
        //Countdown 

        if (Decanoid.On == true)
        {
            if (Ctime >= 0.01f)
            {
                Ctime -= 1 * Time.deltaTime;
            }
            if (Ctime < 0.1f)
            {
                StartCoroutine(AtackTime());
            }
        }
        if (AtackT == true)
        {
            if (cScorpion.Hit == true && cScorpion.Stage < 3)
            {
                Ctime = Stime;
                Orion.SetTrigger("GoUp");
                cScorpion.Hit = false;
            }
        }
    }
    // Intro
    public IEnumerator OrionStart()
    {
        yield return new WaitForSeconds(6f);
        AudioManager.Instance.PlaySfx("Atack");
        cScorpion.Scorpion.SetTrigger("Atack");
        yield return new WaitForSeconds(1f);
        AudioManager.Instance.PlaySfx("Arrow");
        OrionSprite.SetTrigger("Atack");
        yield return new WaitForSeconds(.8f);
        Arrow.gameObject.SetActive(true);
        AArrow.SetTrigger("go");
        yield return new WaitForSeconds(.3f);
        Arrow.gameObject.SetActive(false);
        AudioManager.Instance.PlaySfx("1Life");
        cScorpion.Scorpion.SetTrigger("Damage");
        yield return new WaitForSeconds(.5f);
        AudioManager.Instance.PlaySfx("Atack");
        cScorpion.Scorpion.SetTrigger("Atack");
        yield return new WaitForSeconds(1f);
        Orion.SetTrigger("GoUpStart");
        OrionSprite.SetTrigger("Sprint");
        yield return new WaitForSeconds(1f);
        cScorpion.Scorpion.SetTrigger("Run");
        Decanoid.On = true;
        Decanoid.ACTIVE = true;

    }
    // Redo Timer
    public IEnumerator AtackTime()
    {

        if (Once == false)
        {
            Decanoid.ACTIVE = false;
            AtackT = true;
            Once = true;

            Orion.SetTrigger("GoDown");
            OrionSprite.SetTrigger("Tired");

            yield return new WaitForSeconds(7f);

            if (cScorpion.Hit == false && cScorpion.WaitCol == true)
            {
                Orion.SetTrigger("GoUp");
                OrionSprite.SetTrigger("Sprint");
                Ctime = Stime;
            }
            Decanoid.ACTIVE = true;
            Once = false;
            AtackT = false;
        }
    }
}
