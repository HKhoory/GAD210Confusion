using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandle : MonoBehaviour
{
    // verti and hori input values
    public float verticalAxis;
    public float horizontalAxis;

    // mouse movemnt for camera rotation
    private float MouseX;
    private float MouseY;

    void Start()
    {
        //locks the cursor int the middle and makes the mouse curor disapper
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        //call Moving function
        Moving();

        //get mouse movemnts 
        MouseX += Input.GetAxis("Mouse X");
        MouseY += Input.GetAxis("Mouse Y");

        //limits camaera movment angle
        MouseY = Mathf.Clamp(MouseY, -45, 60);

        //handles rotation
        transform.rotation = Quaternion.Euler(0, MouseX, 0);
        Camera.main.transform.rotation = Quaternion.Euler(-MouseY, MouseX, 0);
    }

    private void Moving()
    {
        //vertical axis for W and S keys or up and down arrows
        //horizontal axis for A and D keys or left and right arrows

        verticalAxis = Input.GetAxis("Vertical");
        horizontalAxis = Input.GetAxis("Horizontal");

    }
}
