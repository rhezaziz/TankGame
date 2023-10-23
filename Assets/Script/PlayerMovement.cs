using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // S
    // tart is called before the first frame update
    Rigidbody rb;
    public float speed;
    private Vector3 _moveDir;

    public Transform tank;
    public float rotateSpeed;

    public InputActionReference move;
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _moveDir = move.action.ReadValue<Vector3>();
       // lookAtDir();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(_moveDir.x * speed, transform.position.y, _moveDir.z * speed);
    }


    void lookAtDir()
    {
        tank.rotation = Quaternion.Slerp(tank.transform.rotation, Quaternion.LookRotation(_moveDir), rotateSpeed * Time.deltaTime);
    }
}
