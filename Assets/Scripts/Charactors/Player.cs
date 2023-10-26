using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField, Range(1,20)] private float mouseSensX;
    [SerializeField, Range(1,20)] private float mouseSensY;
    [SerializeField] private Transform followTarget;
    private Vector2 currentAngle;

    [SerializeField, Range(-90,0)] private float minViewAngle;
    [SerializeField, Range(0, 90)] private float maxViewAngle;

    [SerializeField] private float speed;
    private Vector3 _moveDirection;

    public static int score;

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
        transform.position += transform.rotation * (speed * Time.deltaTime * _moveDirection);
        fallCheck();
    }

    public static void ScoreInc()
    {
        score += 1;
        Debug.Log("Score:"+score);
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
        _moveDirection = currentDirection;
        //if (currentDirection == new Vector3(0,0,0)) _moveDirection = currentDirection;
        //else if (currentDirection.x > 0) _moveDirection = transform.right;
        //else if (currentDirection.x < 0) _moveDirection = -transform.right;
        //else if (currentDirection.z > 0) _moveDirection = transform.forward;
        //else if (currentDirection.z < 0) _moveDirection = -transform.forward;
    }

    public void SetLookRotation(Vector2 readValue)
    {
        currentAngle.x += readValue.x * Time.deltaTime * mouseSensX;
        currentAngle.y += readValue.y * Time.deltaTime * mouseSensY;

        currentAngle.y = Mathf.Clamp(currentAngle.y, minViewAngle, maxViewAngle);


        transform.rotation = Quaternion.AngleAxis(currentAngle.x, Vector3.up);
        followTarget.localRotation = Quaternion.AngleAxis(currentAngle.y, Vector3.right);
    }

    public void Punch()
    {

    }
}
