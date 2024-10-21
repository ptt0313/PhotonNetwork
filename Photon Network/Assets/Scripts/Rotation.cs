using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] float mouseX;
    [SerializeField] float mouseY;
    [SerializeField] float speedX = 250f;
    [SerializeField] float speedY = 125f;

    public void RotateY()
    {
        mouseX += Input.GetAxisRaw("Mouse X") * speedX * Time.deltaTime;

        transform.eulerAngles = new Vector3(mouseY, mouseX, 0);
    }
    public void RotateX()
    {
        mouseY -= Input.GetAxisRaw("Mouse Y") * speedY * Time.deltaTime;
        
        transform.eulerAngles = new Vector3(mouseY, mouseX, 0);
    }
}
