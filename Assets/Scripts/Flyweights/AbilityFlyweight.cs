/***************************************************************
* Filename:       	AbilityFlyweight.cs                        *
* Authors:        	Noah Stern                                 *
* Version Authors:	Noah Stern                                 *
* Current Version:  0.0.2                                      *
* Previous Version: 0.0.1                                      *
* Creation Date:  	April 28, 2026                             *
* Last Modified:  	April 30, 2026                             *
* Due Date:       	May 14th, 2026                             *
* Course:         	CPSC 323                                   *
* Professor Name: 	Professor Jacklitsch                       *
* Project:        	Braket Reset                               *
* Purpose:        	The basis of a abilities, used to create   *
*                   new abilities                              *
* Version Changes:	Commented everything                       *
****************************************************************/
using System.Collections.Generic;
using UnityEngine;

public class AbilityFlyweight
{
    //The ID of the ability
    public string abilityID;

    //How much damage the ability does
    public float abilityDamage;

    //The range of the ability
    public int abilityRange;

    //The ability's cooldown
    public int abilityCooldown;

    //The ability's hype cost
    public int abilityCost;

    //The icon of the ability
    public GameObject abilityIcon;

    //The sound the ability makes when used
    public AudioClip abilitySound;

    //The effect(s) the ability applies
    public List<EffectFlyweight> statusEffect;
    //Determines how long an animation should play for.
    public float animationLength = 1f;
}//end AbilityFlyweight
