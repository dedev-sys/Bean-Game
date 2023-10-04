using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float speed;
    private Vector3 _moveDirection;

    bool isGround;

    private Rigidbody rig;
    private float jumpSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        InputManager.Init(this);
        rig = GetComponent<Rigidbody>();
        InputManager.SetGameControls();
    }

    // Update is called once per frame
    void Update()
    {
        isGround = Physics.Raycast(transform.position, -Vector3.up, GetComponent<Collider>().bounds.extents.y);
        transform.position += speed * Time.deltaTime * _moveDirection;
        fallCheck();
    }

    public void fallCheck()
    {
        if (transform.position.y < -5)
        {
            ResetCharactor();
        }
    }

    public void Jump()
    {
        if (isGround)
        {
            rig.velocity = new Vector3(rig.velocity.x, jumpSpeed, rig.velocity.z);
        }
    }

    public void ResetCharactor()
    {
        transform.position = new Vector3(0,3,0);
        // WORK ON THIS LATER IT IS SUPPOST TO RESPAWN THE TOAST
        //Collectables.RespawnToast(this);
    }

    public void Move(Vector3 currentDirection)
    {
        if (currentDirection == new Vector3(0,0,0)) _moveDirection = currentDirection;
        else if (currentDirection.x > 0) _moveDirection = transform.right;
        else if (currentDirection.x < 0) _moveDirection = -transform.right;
        else if (currentDirection.z > 0) _moveDirection = transform.forward;
        else if (currentDirection.z < 0) _moveDirection = -transform.forward;
    }
}
