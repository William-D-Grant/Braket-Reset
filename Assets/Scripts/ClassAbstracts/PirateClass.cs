using UnityEngine;

public class PirateClass : ClassAbstract
{

    /**********************************************************************************/
    /*                                                                                */
    /* Function name: PirateClass                                                       */
    /* Description: An overidden function from ClassAbstract, gets/sets the specified */
    /*              class' stats and abilities                                        */
    /* Parameters: N/A                                                                */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public PirateClass()
    {
        CreateClass();
    }//end PirateClass Constructor


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
        //The Pirate's maximum health points
        classMaxHP = 60;

        //The Pirate's speed
        classSPD = 4;

        //The Pirate's attack
        classATK = 2;

        //The Pirate's defense
        classDEF = 2;

        //The Pirate's tile movement
        classTM = 4;

        //The Pirate's hype generation
        classHype = 4;

        //The Pirate's range of their attack
        classRange = 1;

        //The Pirate's luck 
        classLuck = 5;

        //The array of the Pirate's abilities
        abilityArray = new string[]
        {
            "SEA_SHANTY"
        };
    }//end CreateClass

}//end PirateClass
