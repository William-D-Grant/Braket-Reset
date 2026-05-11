using UnityEngine;

public class RangerClass : ClassAbstract
{

    /**********************************************************************************/
    /*                                                                                */
    /* Function name: RangerClass                                                       */
    /* Description: An overidden function from ClassAbstract, gets/sets the specified */
    /*              class' stats and abilities                                        */
    /* Parameters: N/A                                                                */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public RangerClass()
    {
        CreateClass();
    }//end RangerClass Constructor


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
        className = "RANGER";

        //The Ranger's maximum health points
        classMaxHP = 70;

        //The Ranger's speed
        classSPD = 3;

        //The Ranger's attack
        classATK = 4;

        //The Ranger's defense
        classDEF = 2;

        //The Ranger's tile movement
        classTM = 2;

        //The Ranger's hype
        classHype = 3;

        //The Ranger's range of their attack
        classRange = 5;

        //The Ranger's luck 
        classLuck = 2;

        //The array of the Ranger's abilities
        abilityArray = new string[]
        {
            "Shoot",
            "Long Shot"
        };

        bloxObject = Resources.Load<GameObject>("PreFabs/Blox Classes/Ranger");

    }//end CreateClass
}//end RangerClass