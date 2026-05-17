/***************************************************************
* Filename:       	DialogueUIHandler.cs                       *
* Authors:        	Noah Stern                                 *
* Version Authors:	Noah Stern                                 *
* Current Version:  0.0.1                                      *
* Previous Version: 0.0.0                                      *
* Creation Date:  	May 10, 2026                               *
* Last Modified:  	May 10, 2026                               *
* Due Date:       	May 17th, 2026                             *
* Course:         	CPSC 323                                   *
* Professor Name: 	Professor Jacklitsch                       *
* Project:        	Braket Reset                               *
* Purpose:        	Handles displayering the current dialogue  *
*                   and sprites                                *
* Version Changes:	Created and finished                       *
****************************************************************/
using UnityEngine;

public class DialogueData
{
    //Who is talking
    public string talkingName;

    //What they said
    public string dialogueline;

    //What sprite to use
    public Sprite talkingSprite;
    public Sprite backgroundSprite;

    //If the player talking or not
    public bool isPlayerTalking;


    /***************************************************************************************************/
    /*                                                                                                 */
    /* Function name: Dialoguedata                                                                     */
    /* Description: A constructor to make a dialogue data                                              */
    /* Parameters: string whoIsTalking: The name of the character talking                              */
    /*             string line: What is being said                                                     */
    /*             Sprite sprite: the sprite being used                                                */
    /*             bool isPlayerDialogue: if the player is talking or not                              */
    /* Return Value: N/A                                                                               */
    /*                                                                                                 */
    /***************************************************************************************************/
    public DialogueData(string whoIsTalking, string line, Sprite sprite, bool isPlayerDialogue)
    {
        talkingName = whoIsTalking;

        dialogueline = line;

        talkingSprite = sprite; 

        isPlayerTalking = isPlayerDialogue;
    }//end DialgoueData constructor

}//end DialogueData
