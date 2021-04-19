using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Control : MonoBehaviour
{
    [SerializeField] float PanSpeed = 5;
    [SerializeField] float BoostModifier = 2;
    [SerializeField] float MiddleClickPanSpeed = 10;
    [SerializeField] float ZoomMax = 5;
    [SerializeField] float RotateSpeed = 50;
    [SerializeField] float RightClickRotateSpeed = 5;
    [SerializeField] float MinVerticalAngle, MaxVerticalAngle;

    private float moveSpeed;
    private float currZoomLevel;
    private float pitch, yaw;

    private void LateUpdate()
    {
        PanHorizontal();

        PanVertical();

        RotateAroundPoint();

        Zoom();

        RotateAroundSelf();
    }

    private void PanHorizontal()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = PanSpeed * BoostModifier;
        }
        else
        {
            moveSpeed = PanSpeed;
        }

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            transform.Translate(moveSpeed * Time.deltaTime * new Vector3(transform.right.x * Input.GetAxisRaw("Horizontal"), 0, transform.forward.z * Input.GetAxisRaw("Vertical")), Space.World);
        }
    }

    private void PanVertical()
    {
        if (Input.GetMouseButton(2))
        {
            transform.Translate(MiddleClickPanSpeed * Time.deltaTime * new Vector3(-transform.right.x * Input.GetAxisRaw("Mouse X"), -transform.up.y * Input.GetAxisRaw("Mouse Y"), 0), Space.World);
        }
    }

    private void RotateAroundPoint()
    {
        //if user presses Q or E rotate the camera around
        if(Input.GetKey(KeyCode.Q))
        {
            //rotate left
            transform.RotateAround(transform.forward * 0, Vector3.up, RotateSpeed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.E))
        {
            //rotate right
            transform.RotateAround(transform.forward * 0, Vector3.up, -RotateSpeed * Time.deltaTime);
        }
    }

    private void Zoom()
    {
        //zoom the camera in or out based on scrollwheel
        float scrollChange = Input.GetAxis("Mouse ScrollWheel");

        currZoomLevel += scrollChange;

        //Debug.Log(scrollChange + "::" + currZoomLevel);

        if(Mathf.Abs(currZoomLevel) >= ZoomMax)
        {
            scrollChange = 0;
            currZoomLevel = Mathf.Clamp(currZoomLevel, -ZoomMax, ZoomMax);
        }

        transform.position += transform.forward * scrollChange;
    }

    private void RotateAroundSelf()
    {
        //if user holds down right mouse button, allow them to rotate the camera vertically(within the min and max bounds) and horizontally
        if(Input.GetMouseButtonDown(1))
        {
            pitch = transform.eulerAngles.x;
            yaw = transform.eulerAngles.y;
        }
        
        if(Input.GetMouseButton(1))
        {
            yaw += RightClickRotateSpeed * Input.GetAxis("Mouse X");
            pitch += RightClickRotateSpeed * Input.GetAxis("Mouse Y");

            pitch = Mathf.Clamp(pitch, MinVerticalAngle, MaxVerticalAngle);

            transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        }
    }
}
