using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon¨/NewWeapon")]
public class Scriptable_Weapon : ScriptableObject
{
    [Header("Characteristiques")]
    public int tickParTir;
    public int range;
    public int precision;
    [Header("Shop")]
    public int price;

}
