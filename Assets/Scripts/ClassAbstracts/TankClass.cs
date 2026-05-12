using UnityEngine;

public class TankClass : ClassAbstract
{

    /**********************************************************************************/
    /*                                                                                */
    /* Function name: TankClass                                                       */
    /* Description: An overidden function from ClassAbstract, gets/sets the specified */
    /*              class' stats and abilities                                        */
    /* Parameters: N/A                                                                */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public TankClass()
    {
        CreateClass();
    }//end TankClass Constructor


    /**********************************************************************************/
    /*                                                                                */
    /* Function name: CreateClass                                                     */
    /* Description: An overidden function from ClassAbstract, gets the specified      */
    /*              class' stats and abilities                                        */
    /* Parameters: N/A                                                                */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public override void CreateClass()
    {
        //The class's name
        className = "TANK";

        //The Tank's maximum health points
        classMaxHP = 45;

        //The Tank's speed
        classSPD = 1;

        //The Tank's attack
        classATK = 3;

        //The Tank's defense
        classDEF = 5;

        //The Tank's tile movement
        classTM = 2;

        //The Tank's hype
        classHype = 2;

        //The Tank's range of their attack
        classRange = 1;

        //The Tank's luck 
        classLuck = 2;

        //The array of the Tank's abilities
        abilityArray = new string[]
        {
            "Hit",
            "Defend",
            "Shield Bash"
        };

        bloxObject = Resources.Load<GameObject>("PreFabs/Blox Classes/Tank");
    }//end CreateClass
}//end TankClass
