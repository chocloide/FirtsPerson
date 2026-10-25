using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector2 input = Vector2.zero;
    Vector3 Direction = Vector3.zero;

    public int walkSpeed = 10;

    Rigidbody Rigid;

    void Start(){
        Rigid = GetComponent<Rigidbody>();
    }

    
    void Update(){
        input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    void FixedUpdate(){
        Direction = transform.forward * input.y + transform.right * input.x;
        Rigid.velocity = new Vector3(Direction.x * walkSpeed, Rigid.velocity.y, Direction.z * walkSpeed);
    }
}
