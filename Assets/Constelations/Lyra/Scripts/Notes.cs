using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notes : MonoBehaviour
{
    public float speed = 10f;
    public Animator Sprite;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        

        this.transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (this.transform.position.y < -15f) { Destroy(this.gameObject); }

        if (Decanoid.DestroyMusic == true)
        {
            Decanoid.DestroyMusic = false;

            int randomobs = Random.Range(0, 2);
            if (randomobs == 0)
            {
                AudioManager.Instance.PlaySfx("Nota1");
            }
            else
            {
                AudioManager.Instance.PlaySfx("Nota2");
            }
            Decanoid.DestroyMusic = false;

            Destroy(this.gameObject);
        }
    }
}
