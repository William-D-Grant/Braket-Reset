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

//All dialogue systems based heavily on this video from AVILLASTUDIO: https://www.youtube.com/watch?v=AqnNrTJaeLA&t=900s


using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUIHandler : MonoBehaviour
{
    //The player's sprite
    [SerializeField]
    private Image _playerSprite;

    //The enemy's sprite
    [SerializeField]
    private Image _enemySprite;
    //The name of who is talking
    [SerializeField]
    private TextMeshProUGUI _talkingName;

    //What they are saying
    [SerializeField]
    private TextMeshProUGUI _talkingDialogue;


    /***************************************************************************************************/
    /*                                                                                                 */
    /* Function name: DisplayText                                                                      */
    /* Description: Updates the text and sprites on screen                                             */
    /* Parameters: DialogueData data: who is talking, what is being said, the sprite to be updated,    */
    /*             and if the player is talking or not                                                 */
    /* Return Value: N/A                                                                               */
    /*                                                                                                 */
    /***************************************************************************************************/
    public void DisplayText(DialogueData data)
    {
        _talkingName.text = data.talkingName;
        _talkingDialogue.text = data.dialogueline;

        if(data.isPlayerTalking == true)
        {
            _playerSprite.sprite = data.talkingSprite;
        }//end if

        else if(data.isPlayerTalking == false)
        {
            _enemySprite.sprite = data.talkingSprite;
        }//end else if
        
    }//end DisplayText

}//end DialogueUIHandler