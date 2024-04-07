using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

[System.Serializable]
public class PlayerAbilities : ScriptableObject
{
    public HatThrowAbility hatThrowAbility;
    public BowtieDashAbility bowtieDashAbility;
    public DirectionalHatThrowAbility directionalHatThrowAbility;
    public BowtieShieldAbility bowtieShieldAbility;
    public HatMegaThrowAbility hatMegaThrowAbility;
    public HatTeleportAbility hatTeleportAbility;
    public TieAttackAbility tieAttackAbility;
    public TieGrabAbility tieGrabAbility;

    public bool hasHat;
    public int health;
    public int maxHealth;
    public int elegance;
    public int maxElegance;
}

[System.Serializable]
public abstract class AbilityScriptable : ScriptableObject
{
    [SerializeField]
    public bool unlocked;
}
