using UnityEngine;

public class CowboyClass : ClassAbstract
{

    /**********************************************************************************/
    /*                                                                                */
    /* Function name: CowboyClass                                                       */
    /* Description: An overidden function from ClassAbstract, gets/sets the specified */
    /*              class' stats and abilities                                        */
    /* Parameters: N/A                                                                */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public CowboyClass()
    {
        CreateClass();
    }//end CowboyClass Constructor


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
        //The Cowboy's maximum health points
        classMaxHP = 60;

        //The Cowboy's speed
        classSPD = 5;

        //The Cowboy's attack
        classATK = 3;

        //The Cowboy's defense
        classDEF = 3;

        //The Cowboy's tile movement
        classTM = 3;

        //The Cowboy's hype generation
        classHype = 3;

        //The Cowboy's range of their attack
        classRange = 3;

        //The Cowboy's luck 
        classLuck = 2;

        //The array of the Cowboy's abilities
        abilityArray = new string[]
        {
            "CAUGHT"
        };
    }//end CreateClass

}//end CowboyClass
