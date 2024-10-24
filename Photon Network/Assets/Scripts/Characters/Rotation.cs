using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] float mouseX;
    [SerializeField] float mouseY;
    [SerializeField] float speedX = 250f;
    [SerializeField] float speedY = 200f;
    public void InputRotateY()
    {
        mouseX += Input.GetAxisRaw("Mouse X") * speedX * Time.deltaTime;
    }
    public void RotateY(Rigidbody rigidbody)
    {
        rigidbody.transform.eulerAngles = new Vector3(0, mouseX, 0);
    }
    public void RotateX()
    {
        //Mathf.Clamp(제한하는 값, 최소값, 최대값)

        mouseY = Mathf.Clamp(mouseY, -65, 65);
        mouseY -= Input.GetAxisRaw("Mouse Y") * speedY * Time.deltaTime;
        if (mouseY < -65) mouseY = -65;
        else if (mouseY > 65) mouseY = 65;
        transform.localEulerAngles = new Vector3(mouseY, 0, 0);
    }
}
