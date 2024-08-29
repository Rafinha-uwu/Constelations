using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTarget : MonoBehaviour
{

    public Transform Target;
    public float Hide;

    public Transform Hades;
    public Transform Poseidon;
    public Transform Zeus;
    public Transform Mesa;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        var dir = Target.position - transform.position;


        if (dir.magnitude < Hide)
        {
            TargetActive(false);
        }
        else
        {
            TargetActive(true);

            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    public void TargetActive (bool value)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(value);
        }
    }
}
