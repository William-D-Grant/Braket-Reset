/***************************************************************
* Filename:       	AnimationControlScript.cs                  *
* Authors:        	Ophelia Carlin                             *
* Version Authors:	Ophelia Carlin                             *
* Current Version:  0.0.1                                      *
* Previous Version: N/A                                        *
* Creation Date:  	May 17, 2026                               *
* Last Modified:  	May 17, 2026                               *
* Due Date:       	May 17th, 2026                             *
* Course:         	CPSC 323                                   *
* Professor Name: 	Professor Jacklitsch                       *
* Project:        	Braket Reset                               *
* Purpose:        	Changes animation of the Blox when a move  *
*                   is used and resets them to idle after an   *
*                   amount of time has passed                  *
* Version Changes:	Created.                                   *
****************************************************************/

using UnityEngine;

public class AnimationControlScript : MonoBehaviour
{
    //Credit to the below YouTube video for helping me with much of my understanding of Animation Controllers and how to use them in a script.
    //https://www.youtube.com/watch?v=9yFnaLD0PLI
    private float animationTimer;
    public Animator theAnim;


    /**********************************************************************************/
    /*                                                                                */
    /* Function name: Start                                                           */
    /* Description: Sets the animation timer to 0 and sets the animator in code.      */
    /* Parameters: N/A                                                                */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    void Start()
    {
        animationTimer = 0;
        theAnim = GetComponent<Animator>();
    }

    // Update is called once per frame

    /**********************************************************************************/
    /*                                                                                */
    /* Function name: Update                                                          */
    /* Description: Counts down. Once the timer reaches 0, set animation to idle.     */
    /* Parameters: N/A                                                                */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/

    void Update()
    {
        if (animationTimer > 0)
        {
            Debug.Log("Animation timer is at: "+ animationTimer);
            animationTimer -= Time.deltaTime;
        }
        else
        {
            theAnim.Play("Idle");
        }
    }


    /**********************************************************************************/
    /*                                                                                */
    /* Function name: PlayDesiredAnimation                                            */
    /* Description: Sets the animation timer and causes a Blox to start their         */
    /*              animation.                                                        */
    /* Parameters: string animationString                                             */
    /* Return Value: N/A                                                              */
    /*                                                                                */
    /**********************************************************************************/
    public void PlayDesiredAnimation(string animationString)
    {
        animationTimer = 2f;
        theAnim.Play(animationString);  
        Debug.Log("Animation Test Message");
    }
}
