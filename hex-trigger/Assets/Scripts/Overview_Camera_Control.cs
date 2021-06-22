using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overview_Camera_Control : MonoBehaviour
{
    [SerializeField] float PanSpeed = 5;
    [SerializeField] float BoostModifier = 2;
    private float moveSpeed;

    private void LateUpdate()
    {
        PanHorizontal();
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
            Vector3 dir = new Vector3(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"), 0);
            dir.Normalize();

            transform.Translate(moveSpeed * Time.deltaTime * dir, Space.Self);
        }
    }
}
