using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Control : MonoBehaviour
{
    public static Camera_Control Instance;

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

    [SerializeField] Transform child;

    private void Awake()
    {
        Instance = this;
    }

    private void LateUpdate()
    {
        if(Event_Manager.IsGamePaused)
        {
            return;
        }

        PanHorizontal();

        PanVertical();

        RotateAroundPoint();

        Zoom();

        //RotateAroundSelf();
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
            Vector3 dir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            dir.Normalize();

            transform.Translate(moveSpeed * Time.deltaTime * dir, Space.Self);
        }
    }

    private void PanVertical()
    {
        if (Input.GetMouseButton(2))
        {
            transform.Translate(MiddleClickPanSpeed * Time.deltaTime * new Vector3(-transform.right.x * Input.GetAxis("Mouse X"), -transform.up.y * Input.GetAxis("Mouse Y"), 0), Space.World);
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

        transform.position += child.transform.forward * scrollChange;
    }

    private void RotateAroundSelf()
    {
        //TODO fix me
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
