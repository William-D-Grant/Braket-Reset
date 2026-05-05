using UnityEngine;

public class FighterClass : ClassAbstract
{

    /**********************************************************************************/
    /*                                                                                */
    /* Function name: FighterClass                                                    */
    /* Description: An overidden function from ClassAbstract, gets/sets the specified */
    /*              class' stats and abilities                                        */
    /* Parameters: N/A                                                                */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public FighterClass()
    {
        CreateClass();
    }//end FighterClass Constructor


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
        className = "FIGHTER";

        //The fighter's maximum health points
        classMaxHP = 60;

        //The fighter's speed
        classSPD = 3;

        //The fighter's attack
        classATK = 5;

        //The fighter's defense
        classDEF = 3;

        //The fighter's tile movement
        classTM = 3;

        //The fighter's hype 
        classHype = 2;

        //The fighter's range of their attack
        classRange = 1;

        //The fighter's luck 
        classLuck = 2;

        //The array of the fighter's abilities
        abilityArray = new string[]
        {
            "HEAVY_HITTER"
        };

    }//end CreateClass
}//end FighterClass
