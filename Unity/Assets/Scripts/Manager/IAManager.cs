﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAManager : MonoBehaviour
{
    IAManager Instance;

    public List<Sc_IACharacter> IAList = new List<Sc_IACharacter>();

    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
