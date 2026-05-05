/***************************************************************
* Filename:       	EffectFlyweight.cs                         *
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
* Purpose:        	The basis of a effects, used to create     *
*                   new effects                                *
* Version Changes:	Commented everything                       *
****************************************************************/
using UnityEngine;

public class EffectFlyweight
{
    //The name of the effect
    public string effectID;

    //The icon of the effect
    public GameObject effectIcon;

    //The duration of the effect
    public int effectDuration;

}//end EffectFlyweight
