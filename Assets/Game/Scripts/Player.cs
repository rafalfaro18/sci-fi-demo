﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private CharacterController _controller;
    [SerializeField]
    private float _speed = 3.5f;
    private float _gravity = 9.81f;

	// Use this for initialization
	void Start () {
        _controller = GetComponent<CharacterController>();
        //hide cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

	}
	
	// Update is called once per frame
	void Update () {

        //if left click
        if (Input.GetMouseButtonDown(0))
        {
            //cast ray from center point of main camera
            Ray rayOrigin = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0));
            if(Physics.Raycast(rayOrigin, Mathf.Infinity)){
                Debug.Log("Hit Something");
            }
        }

        //if esc key pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //unhide mouse cursor
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        CalculateMovement();
	}

    void CalculateMovement(){
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        Vector3 velocity = direction * _speed;
        velocity.y -= _gravity;
        velocity = transform.transform.TransformDirection(velocity);
        _controller.Move(velocity * Time.deltaTime);
    }
}
