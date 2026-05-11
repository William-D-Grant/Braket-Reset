using UnityEngine;

public class ThiefClass : ClassAbstract
{

    /**********************************************************************************/
    /*                                                                                */
    /* Function name: ThiefClass                                                       */
    /* Description: An overidden function from ClassAbstract, gets/sets the specified */
    /*              class' stats and abilities                                        */
    /* Parameters: N/A                                                                */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public ThiefClass()
    {
        CreateClass();
    }//end ThiefClass Constructor


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
        className = "THIEF";

        //The Thief's maximum health points
        classMaxHP = 35;

        //The Thief's speed
        classSPD = 6;

        //The Thief's attack
        classATK = 2;

        //The Thief's defense
        classDEF = 2;

        //The Thief's tile movement
        classTM = 5;

        //The Thief's hype
        classHype = 3;

        //The Thief's range of their attack
        classRange = 1;

        //The Thief's luck 
        classLuck = 5;

        //The array of the Thief's abilities
        abilityArray = new string[]
        {
            "Hit",
            "Slash",
            "Speed Demon"
        };

        bloxObject = Resources.Load<GameObject>("PreFabs/Blox Classes/Thief");

    }//end CreateClass
}//end ThiefClass
