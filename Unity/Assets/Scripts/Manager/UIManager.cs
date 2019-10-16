using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    UIManager Instance;

    [Header("AllUiSlots")]
    [SerializeField] Sc_Chara_Interface[] allCharaCards;
    [SerializeField] Image chaosBar;
    [SerializeField] Text timeElpased;

    void Awake()
    {
        Instance = this;



    }



    void Update()
    {
        
    }
}
