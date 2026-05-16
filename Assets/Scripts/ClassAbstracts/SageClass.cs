using UnityEngine;

public class SageClass : ClassAbstract
{

    /**********************************************************************************/
    /*                                                                                */
    /* Function name: SageClass                                                       */
    /* Description: An overidden function from ClassAbstract, gets/sets the specified */
    /*              class' stats and abilities                                        */
    /* Parameters: N/A                                                                */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public SageClass()
    {
        CreateClass();
    }//end SageClass Constructor


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
        className = "SAGE";

        //The Sage's maximum health points
        classMaxHP = 50;

        //The Sage's speed
        classSPD = 2;

        //The Sage's attack
        classATK = 4;

        //The Sage's defense
        classDEF = 1;

        //The Sage's tile movement
        classTM = 2;

        //The Sage's hype generation
        classHype = 4;

        //The Sage's range of their attack
        classRange = 4;

        //The Sage's luck 
        classLuck = 1;

        //The array of the Sage's abilities
        abilityArray = new string[]
        {
            "Heal",
            "Shock",
            "Life Drain"
        };

        bloxObject = Resources.Load<GameObject>("PreFabs/Blox Classes/Sage");

    }//end CreateClass
}//end SageClass
