using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;
    [SerializeField] Vector3 direction;

    public void Movement(Rigidbody rigidbody)
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.z = Input.GetAxisRaw("Vertical");

        direction.Normalize();

        rigidbody.position += rigidbody.transform.TransformDirection(direction * speed * Time.deltaTime);
    }

}
