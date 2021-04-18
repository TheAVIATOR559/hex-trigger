using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Control : MonoBehaviour
{
    [SerializeField] float PanSpeed = 5;
    [SerializeField] float BoostModifier = 2;
    [SerializeField] float RotateSpeed;
    [SerializeField] float ZoomSpeed;

    [SerializeField] float MinimumAngle, MaximumAngle;

    private float moveSpeed;

    private void LateUpdate()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = PanSpeed * BoostModifier;
        }
        else
        {
            moveSpeed = PanSpeed;
        }

        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            transform.position += moveSpeed * Time.deltaTime * new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        }

        //if user presses Q or E rotate the camera around

        //zoom the camera in or out based on scrollwheel

        //if user holds down right mouse button, allow them to rotate the camera vertically(within the min and max bounds) and horizontally
    }
}
