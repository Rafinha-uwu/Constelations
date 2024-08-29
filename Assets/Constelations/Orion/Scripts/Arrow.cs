using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 1f;

    CScorpion cScorpion;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.PlaySfx("Arrow");
        GameObject CScorpion = GameObject.Find("Jogador");

        Decanoid.DestroyArr = false;
        cScorpion = CScorpion.GetComponent<CScorpion>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (this.transform.position.y < -60f) { Destroy(this.gameObject); }

        if (Decanoid.DestroyArr == true) { Invoke("Destroy", .05f); }
    }

    private void Destroy()
    {
        if (cScorpion.collidedObject != null && cScorpion.collidedObject.transform.parent != null)
        {
            Destroy(cScorpion.collidedObject.transform.parent.gameObject);
        }
        Decanoid.DestroyArr = false;
    }
}