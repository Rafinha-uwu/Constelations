using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowCursor : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Decanoid.On = true;
        Decanoid.sensitivity = 0.6f;
    }
    private void Update()
    {
        //Camera seguir o mouse
        if (Decanoid.On == true)
        {
            Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            cursorPosition.z = 0;

            cursorPosition *= Decanoid.sensitivity;
            this.transform.position = cursorPosition;
        }
    }
}
