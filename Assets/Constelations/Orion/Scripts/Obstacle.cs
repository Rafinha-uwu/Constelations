using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Decanoid.Destroy = false;
    }

    // Update is called once per frame
    void Update()
    {

        this.transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (this.transform.position.y < -9f) { Destroy(this.gameObject); }

        if(Decanoid.Destroy == true) { Invoke("Destroy", .2f); }
    }

    private void Destroy()
    {
        Transform child = transform.Find("Colider");
        if (child != null)
        {
            Destroy(child.gameObject);
        }
        Decanoid.Destroy = false; 
    }
}
