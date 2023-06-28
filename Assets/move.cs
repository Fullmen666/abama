using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float moveSpeed = 2;
    public float runSpeed = 4;
    public float jumpPower = 10;
    public float mouse_x = 1000;
    public float mouse_y = 1000;
    public Transform play1;
    public float max_angle = 70, min_angle = -60;
    private Rigidbody rbody;
    [SerializeField] private int maxJumps = 1;
    private int jumps = 0;
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }
    private bool doJump = false;
    float angle = 0;
    bool jumpCommand = false;
    void Update()
    {
        jumpCommand |= Input.GetButtonDown("Jump");
        var mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        transform.rotation *= Quaternion.Euler(0, mouseInput.x * mouse_x, 0);
        angle = Mathf.Clamp(angle - mouseInput.y * mouse_y, -max_angle, -min_angle);
        play1.localRotation = Quaternion.Euler(angle, 0, 0);
    }
    private void FixedUpdate()
    {
        var motionInput = transform.rotation * new
            Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        motionInput.x += rbody.velocity.x;
        motionInput.z += rbody.velocity.z;
        var speed = Input.GetButton("Fire3") ? runSpeed : moveSpeed;
        motionInput = Vector3.ClampMagnitude(motionInput, speed);

        motionInput.y = rbody.velocity.y;
        if (jumpCommand && jumps < maxJumps)
        {
            jumpCommand = false;
            motionInput.y = jumpPower;
        }
        rbody.velocity = motionInput;
        Vector3 motion = rbody.velocity;
        if (doJump)
        {
            doJump = false;
            motion.y = jumpPower;

        }
    }  
           
}