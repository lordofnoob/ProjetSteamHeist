using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Chara/CharaSpecs")]
public class Scriptable_Charaspec : ScriptableObject
{
    public string characterName;
    public Sprite characterPortrait;
    public Sc_Skill[] charaSkills; 
    //public 

}
