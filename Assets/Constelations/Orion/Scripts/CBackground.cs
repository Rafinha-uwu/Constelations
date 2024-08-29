using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBackground : MonoBehaviour
{
    public float Velocidade;
    public bool BackgroundMovement;

    // Start is called before the first frame update
    void Start()
    {
        BackgroundMovement = true;
    }

    private void FixedUpdate()
    {
        if (Decanoid.On == true)
        {
            // Find
            Transform Primeiro = transform.Find("1");
            Transform Segundo = transform.Find("2");

            // Movement
            float verticalMovement = -1f;

            Vector3 movement = new Vector3(0f, verticalMovement, 0f).normalized;

            // Move Screen
            Primeiro.transform.Translate(movement * Velocidade * Time.deltaTime);
            Segundo.transform.Translate(movement * Velocidade * Time.deltaTime);

            // Loop
            if (Primeiro.transform.position.y < -50f)
            {
                Primeiro.transform.position = new Vector3(0, 106f, 0);
            }
            if (Segundo.transform.position.y < -50f)
            {
                Segundo.transform.position = new Vector3(0, 106f, 0);
            }

        }
    }
}
