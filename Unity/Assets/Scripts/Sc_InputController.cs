using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_InputController : MonoBehaviour
{
    [HideInInspector] public bool Z, Q, S, D;
    [HideInInspector] public float scroll;

    private void Update()
    {
        Z = Input.GetKey(KeyCode.Z);
        Q = Input.GetKey(KeyCode.Q);
        S = Input.GetKey(KeyCode.S);
        D = Input.GetKey(KeyCode.D);

        scroll = Input.GetAxis("Mouse ScrollWheel");
    }
}
