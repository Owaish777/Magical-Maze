using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    float mouseX;
    float mouseY;
    float xRotation= 0f;

    public int mouseSensetivity = 100;
    public Transform body;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSensetivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensetivity * Time.deltaTime;

        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localEulerAngles = new Vector3 (xRotation, 0, 0);

        body.Rotate(Vector3.up * mouseX);
    }
}
