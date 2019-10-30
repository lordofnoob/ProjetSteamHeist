using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeistBtn : MonoBehaviour
{
    public GameObject up;
    public GameObject down;


    public void OnMouseDown()
    {
        if (up.activeInHierarchy == true)
        {
            up.gameObject.SetActive(false);
            down.gameObject.SetActive(true);

        }

    }

    public void OnMouseUp()
    {
        up.gameObject.SetActive(true);
        down.gameObject.SetActive(false);
    }
}
