using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float MoveSpeed;

    public float GroundDrag;

    public float JumpForce;
    public float JumpCooldown;
    public float AirMultiplier;
    bool ReadyToJump = true;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public float PlayerHeight;
    public LayerMask WhatIsGround;
    bool Grounded;

    public Transform Orientation;

    float HorizontalInput;
    float VerticalInput;
    Vector3 MoveDirection;

    Rigidbody rb;
    private Vector3 OldTransPos;
    private Vector3 currentPosition;

    //On Load data loading
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        int SpeedCounter = PlayerPrefs.GetInt("PlayerSpeedCounter");
        MoveSpeed += SpeedCounter * 1f;
        // Debug.Log(MoveSpeed);
    }



    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        //ground check
        Grounded = Physics.Raycast(transform.position, Vector3.down, PlayerHeight * 0.5f + 0.2f, WhatIsGround);

        MyInput();
        SpeedControl();

        currentPosition = transform.position;
        if (currentPosition != OldTransPos)
        {
            Debug.Log("play sound");
        }
        else
        {
            Debug.Log("dont play sound");
        }
        OldTransPos = currentPosition;

        //handle drag
        if (Grounded)
        {
            rb.drag = GroundDrag;
        }
        else
        {
            rb.drag = 0;
        }

    }

    private void FixedUpdate()
    {
        MovePlayer();
    }
    private void MyInput()
    {
        HorizontalInput = Input.GetAxisRaw("Horizontal");
        VerticalInput = Input.GetAxisRaw("Vertical");



        if (Input.GetKey(jumpKey) && ReadyToJump && Grounded)
        {

            ReadyToJump = false;

            Jump();

            Invoke(nameof(JumpReady), JumpCooldown);

        }

    }

    private void MovePlayer()
    {
        //calculate movement direction
        MoveDirection = Orientation.forward * VerticalInput + Orientation.right * HorizontalInput;

        if (Grounded)
        {
            rb.AddForce(MoveDirection.normalized * MoveSpeed * 10f, ForceMode.Force);

        }


        else if (!Grounded)
            rb.AddForce(MoveDirection.normalized * MoveSpeed * 10f * AirMultiplier, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        // limit velocity if needed
        if (flatVel.magnitude > MoveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * MoveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }



    }

    private void Jump()
    {
        // reset Y velocity
        // rb.velocity = new Vector3(0f, rb.velocity.y);
        // rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.y);
        rb.AddForce(transform.up * JumpForce, ForceMode.Impulse);
    }

    private void JumpReady()
    {
        ReadyToJump = true;
    }


}