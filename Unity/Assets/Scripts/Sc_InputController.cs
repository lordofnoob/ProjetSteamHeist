using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_InputController : MonoBehaviour
{
    public bool Z, Q, S, D;
    public bool RightClick, LeftClick, MiddleClick;
    public float scroll;
    public Vector2 mousePosition;
    public static Sc_InputController inputControler;

    private void Awake()
    {
        inputControler = this;
    }

    private void Update()
    {
        Z = Input.GetKey(KeyCode.Z);
        Q = Input.GetKey(KeyCode.Q);
        S = Input.GetKey(KeyCode.S);
        D = Input.GetKey(KeyCode.D);

        scroll = Input.GetAxis("Mouse ScrollWheel");

        LeftClick = Input.GetMouseButtonDown(0);
        RightClick = Input.GetMouseButtonDown(1);
        MiddleClick = Input.GetMouseButtonDown(2);


        // MOUSE POS
        mousePosition = Input.mousePosition;
    }
}
