using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Chara/Skill")]
public class Sc_Skill : ScriptableObject
{
    public Sprite skillIcon;
    public SkillType skillType;

   public enum SkillType
    {
        Negociation, Forcing, Physical, Explosive, Intimidate, Mechanism, Intellect, Hacking
    }
}

