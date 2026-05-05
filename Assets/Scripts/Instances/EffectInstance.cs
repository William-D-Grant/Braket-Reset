/***************************************************************
* Filename:       	EffectInstance.cs                          *
* Authors:        	Noah Stern                                 *
* Version Authors:	Noah Stern                                 *
* Current Version:  0.1.0                                      *
* Previous Version: 0.0.1                                      *
* Creation Date:  	April 28, 2026                             *
* Last Modified:  	April 30, 2026                             *
* Due Date:       	May 14th, 2026                             *
* Course:         	CPSC 323                                   *
* Professor Name: 	Professor Jacklitsch                       *
* Project:        	Braket Reset                               *
* Purpose:        	A runtime instance of an effect. Used to   *
*                   separate the EffectFlyweights from         *
*                   gameplay so they can be reused             *
* Version Changes:	Added IsExpired and finished EffectTick    *
****************************************************************/

using UnityEngine;

public class EffectInstance
{
    //The name of the effect ticking or expiring or anything really
    private string _effectID;

    //The duration of said effect
    private int _duration;
    //can be more here for additional effects like hype generation or DOT

    /**********************************************************************************/
    /*                                                                                */
    /* Function name: EffectInstance                                                  */
    /* Description: Assigns the EffectFlyweight's stats to this effect instance       */
    /* Parameters: EffectFlyweight effectStats: The flyweight of the effect stats     */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public EffectInstance(EffectFlyweight effectStats)
    {
        this._effectID = effectStats.effectID;
        this._duration = effectStats.effectDuration;
    }

    public void EffectTick(ClassVitals effectedBlox)
    {
        _duration--;
    }//end EffectTick

    public bool IsExpired()
    {
        if (_duration > 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

}//end EffectInstance
