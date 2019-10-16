using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [HideInInspector]
    private bool Z, Q, S, D;

    private void Update()
    {
        Z = Input.GetKey(KeyCode.Z);
        Q = Input.GetKey(KeyCode.Q);
        S = Input.GetKey(KeyCode.S);
        D = Input.GetKey(KeyCode.D);
    }
}
