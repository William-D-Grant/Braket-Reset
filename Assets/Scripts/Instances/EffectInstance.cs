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
* Version Changes:	Added _casterTeam and _effectedTeam        *
****************************************************************/

using UnityEngine;

public class EffectInstance
{
    //The name of the effect ticking or expiring or anything really
    public string _effectID { get; private set; }

    //The duration of said effect
    private int _duration;
    //can be more here for additional effects like hype generation or DOT

    //The team of the Blox who casted the effect
    public Team _casterTeam { get; private set; }

    //The team of the Blox effected
    public Team _effectedTeam { get; private set; }

    /**********************************************************************************/
    /*                                                                                */
    /* Function name: EffectInstance                                                  */
    /* Description: Assigns the EffectFlyweight's stats to this effect instance       */
    /* Parameters: EffectFlyweight effectStats: The flyweight of the effect stats     */
    /*             Team casterTeamL: The team of the Blox who casted the effect       */
    /*             Team effectedTeam: The team of the Blox effected                   */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public EffectInstance(EffectFlyweight effectStats, Team casterTeam, Team effectedTeam)
    {
        this._effectID = effectStats.effectID;
        this._duration = effectStats.effectDuration;
        _casterTeam = casterTeam;
        _effectedTeam = effectedTeam;
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
        else if (_duration <= 0)
        {
            return true;
        }
        return false;
    }

}//end EffectInstance
