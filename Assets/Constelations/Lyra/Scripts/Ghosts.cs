using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghosts : MonoBehaviour
{
    public float speed = 1f;
    public Animator Sprite;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.PlaySfx("Boo");
        Decanoid.DestroyGhost = false;
    }

    // Update is called once per frame
    void Update()
    {

        this.transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (this.transform.position.y < -15f) { Destroy(this.gameObject); }

        if(Decanoid.DestroyGhost == true) { Invoke("Destroy", .2f); }
    }

    private void Destroy()
    {
        Transform child = transform.Find("Colider");
        if (child != null)
        {
            Destroy(child.gameObject);
        }
        Sprite.SetTrigger("Fade");
        Decanoid.DestroyGhost = false; 
    }
}
