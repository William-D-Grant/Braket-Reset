/***************************************************************
* Filename:       	EffectFactory.cs                           *
* Authors:        	Noah Stern                                 *
* Version Authors:	Noah Stern                                 *
* Current Version:  0.1.1                                      *
* Previous Version: 0.1.0                                      *
* Creation Date:  	April 28, 2026                             *
* Last Modified:  	April 31, 2026                             *
* Due Date:       	May 14th, 2026                             *
* Course:         	CPSC 323                                   *
* Professor Name: 	Professor Jacklitsch                       *
* Project:        	Braket Reset                               *
* Purpose:        	A factory to create effects, mainly for    *
*                   abilities. Makes sure a new effect is      *
*                   created and stored in a dictionary each    *
*                   time so EffectFlyweights can be reused     *
* Version Changes:	Created BuildEffect to move switch logic   *
****************************************************************/

using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public static class EffectFactory
{
    //Stores effects for reference in RetrieveEffect
    //Dictionaries learned from: https://imran-momin.medium.com/dictionaries-unity-c-69b48448445f
    // and https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2?view=net-6.0
    private static Dictionary<string, EffectFlyweight> _effectsDictionary = new();


    /**********************************************************************************/
    /*                                                                                */
    /* Function name: RetrieveEffect                                                  */
    /* Description: Finds and retrieves an EffectFlyweight if it already exists,      */
    /*              otherwise it creates and stores the EffectFlyweight in            */
    /*              _effectsDictionary for future reference                           */
    /* Parameters: string effectID: the name of the effect being retrieved            */
    /* Return Value: EffectFlyweight _effectsDictionary[effectID]: the effect         */
    /*               stats that were requested                                        */
    /*                                                                                */
    /**********************************************************************************/
    public static EffectFlyweight RetrieveEffect(string effectID)
    {
        //if the EffectFlyweight has already been made, return the EffectFlyweight
        if (_effectsDictionary.ContainsKey(effectID))
        {
            return _effectsDictionary[effectID];
        }

        //if the EffectFlyweight hasn't already been made, create the EffectFlyweight, store it, return it
        EffectFlyweight newEffect = BuildEffect(effectID);
        _effectsDictionary[effectID] = newEffect;
        return _effectsDictionary[effectID];

    }//end RetrieveEffect


    /**********************************************************************************/
    /*                                                                                */
    /* Function name: BuildEffect                                                     */
    /* Description: Creates an effect for RetrieveEffect with an EffectFlyweight      */
    /* Parameters: string effectID: the name of the effect being created              */
    /* Return Value: EffectFlyweight _____Effect: the created effect based on what    */
    /*               effect was requested                                             */
    /*                                                                                */
    /**********************************************************************************/
    private static EffectFlyweight BuildEffect(string effectID)
    {
        EffectFlyweight effectplaceholdersocodecompiles = new EffectFlyweight();

        switch (effectID)
        {
            case "SHIELD_BASH":
                EffectFlyweight shieldBashEffect = new EffectFlyweight();
                shieldBashEffect.effectID = effectID;
                //shieldBashEffect.effectIcon = effecticon;
                shieldBashEffect.effectDuration = 0; //duration doesnt matter
                return shieldBashEffect;

            case "SPEED_DEMON":
                EffectFlyweight speedDemonEffect = new EffectFlyweight();
                speedDemonEffect.effectID = effectID;
                //speedDemonEffect.effectIcon = effecticon;
                speedDemonEffect.effectDuration = 3;
                return speedDemonEffect;

            case "LIFE_DRAIN":
                EffectFlyweight lifeDrainEffect = new EffectFlyweight();
                lifeDrainEffect.effectID = effectID;
                //lifeDrainEffect.effectIcon = effecticon;
                lifeDrainEffect.effectDuration = 0; //duration doesnt matter
                return lifeDrainEffect;

            case "HYPE_TRAIN":
                EffectFlyweight hypeTrainEffect = new EffectFlyweight();
                hypeTrainEffect.effectID = effectID;
                //hypeTrainEffect.effectIcon = effecticon;
                hypeTrainEffect.effectDuration = 3; //duration doesnt matter
                return hypeTrainEffect;

            case "JOKE":
                EffectFlyweight jokeEffect = new EffectFlyweight();
                jokeEffect.effectID = effectID;
                //icon
                jokeEffect.effectDuration = 1;
                return jokeEffect;

            case "CAUGHT":
                EffectFlyweight caughtEffect = new EffectFlyweight();
                caughtEffect.effectID = effectID;
                //caughtEffect.effectIcon = effecticon
                caughtEffect.effectDuration = 2;
                return caughtEffect;

            case "SEA_SHANTY":
                EffectFlyweight seaShantyEffect = new EffectFlyweight();
                seaShantyEffect.effectID = effectID;
                //seaShantyEffect.effectIcon = effecticon
                seaShantyEffect.effectDuration = 2;
                return seaShantyEffect;
        }
        return effectplaceholdersocodecompiles;
    }
}//end EffectFactory
