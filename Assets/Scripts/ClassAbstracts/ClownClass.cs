using NUnit.Framework.Internal.Filters;
using UnityEngine;

public class ClownClass : ClassAbstract
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
    public ClownClass()
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
        className = "CLOWN";

        //The Clown's maximum health points
        classMaxHP = 25;

        //The Clown's speed
        classSPD = 2;

        //The Clown's attack
        classATK = 2;

        //The Clown's defense
        classDEF = 2;

        //The Clown's tile movement
        classTM = 4;

        //The Clown's hype generation
        classHype = 5;

        //The Clown's range of their attack
        classRange = 3;

        //The Clown's luck 
        classLuck = 2;

        //The array of the Clown's abilities
        abilityArray = new string[]
        {
            "Joke",
            "Throw Pie",
            "Eat Pie",
            "Hype Train"
        };

        bloxObject = Resources.Load<GameObject>("PreFabs/Blox Classes/Clown");

    }//end CreateClass

}//end ClownClass
