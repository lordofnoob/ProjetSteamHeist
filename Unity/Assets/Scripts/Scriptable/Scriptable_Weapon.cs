using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon¨/NewWeapon")]
public class Scriptable_Weapon : ScriptableObject
{
    [Header("Characteristiques")]
    public int tickParSalve;
    public int tirParSalve;
    public int range;
    public int precision;


    [Header("Shop")]
    public int price;

}
