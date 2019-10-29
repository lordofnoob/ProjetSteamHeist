﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAManager : MonoBehaviour
{
    public static IAManager Instance;

    public List<Sc_IAOstage> IAList = new List<Sc_IAOstage>();
    public List<Mb_Trial> OstageArea = new List<Mb_Trial>();

    public float repeatActionInterval = 3f;
    private float timer = 0;

    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer >= repeatActionInterval)
        {
            foreach(Sc_IAOstage IACharacter in IAList)
            {
                IACharacter.RandomMovement();
            }
            timer = 0f;
        }
        timer += Time.deltaTime;
    }
}
