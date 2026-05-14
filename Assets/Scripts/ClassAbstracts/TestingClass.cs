using NUnit.Framework.Internal.Filters;
using UnityEngine;

public class TestingClass : ClassAbstract
{

    /**********************************************************************************/
    /*                                                                                */
    /* Function name: ClownClass                                                       */
    /* Description: An overidden function from ClassAbstract, gets/sets the specified */
    /*              class' stats and abilities                                        */
    /* Parameters: N/A                                                                */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public TestingClass()
    {
        CreateClass();
    }//end ClownClass Constructor


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
        className = "TEST";

        //The Clown's maximum health points
        classMaxHP = 99;

        //The Clown's speed
        classSPD = 99;

        //The Clown's attack
        classATK = 99;

        //The Clown's defense
        classDEF = 99;

        //The Clown's tile movement
        classTM = 99;

        //The Clown's hype generation
        classHype = 99;

        //The Clown's range of their attack
        classRange = 99;

        //The Clown's luck 
        classLuck = 99;

        //The array of the Clown's abilities
        abilityArray = new string[]
        {
            "Long Shot"
        };

        bloxObject = Resources.Load<GameObject>("PreFabs/Blox Classes/Test");

    }//end CreateClass

}//end ClownClass
