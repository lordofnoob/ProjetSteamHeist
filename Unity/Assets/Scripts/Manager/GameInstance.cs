using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInstance : MonoBehaviour
{
    GameInstance Instance;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        LevelManager.Instance.InitLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
