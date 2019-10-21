﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_InputController : MonoBehaviour
{
    public bool Z, Q, S, D;
    public bool RightClick, LeftClick, MiddleClick;
    public float scroll;
    public Vector2 mousePosition;

    private void Update()
    {
        Z = Input.GetKey(KeyCode.Z);
        Q = Input.GetKey(KeyCode.Q);
        S = Input.GetKey(KeyCode.S);
        D = Input.GetKey(KeyCode.D);

        scroll = Input.GetAxis("Mouse ScrollWheel");

        LeftClick = Input.GetMouseButton(0);
        RightClick = Input.GetMouseButton(1);
        MiddleClick = Input.GetMouseButton(2);


        // MOUSE POS
        mousePosition = Input.mousePosition;
    }
}
