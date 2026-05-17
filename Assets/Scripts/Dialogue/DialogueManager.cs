/***************************************************************
* Filename:       	DialogueManager.cs                         *
* Authors:        	Noah Stern                                 *
* Version Authors:	Noah Stern                                 *
* Current Version:  0.2.1                                      *
* Previous Version: 0.2.0                                      *
* Creation Date:  	May 10, 2026                               *
* Last Modified:  	May 16, 2026                               *
* Due Date:       	May 14th, 2026                             *
* Course:         	CPSC 323                                   *
* Professor Name: 	Professor Jacklitsch                       *
* Project:        	Braket Reset                               *
* Purpose:        	Handles all information for dialogue, gets *
*                   the full dialogue between characters, then *
*                   sends it to DialogueUIHandler to display   *
* Version Changes:	Added all dialogue                         *
****************************************************************/


//All dialogue systems based heavily on this video from AVILLASTUDIO: https://www.youtube.com/watch?v=AqnNrTJaeLA&t=900s

using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    //The DialogueUIHandler
    [SerializeField]
    private DialogueUIHandler _dialogueUIHandler;

    //All of the player's sprites
    [SerializeField]
    private Sprite _playerIdle;

    [SerializeField]
    private Sprite _playerHappy;

    [SerializeField]
    private Sprite _playerSad;

    [SerializeField]
    private Sprite _playerYeahNo;

    [SerializeField]
    private Sprite _playerErm;

    [SerializeField]
    private Sprite _playerIdleTalking;

    [SerializeField]
    private Sprite _playerYeahNoTalking;


    //Alec's idle, happy, and sad sprite
    [SerializeField]
    private Sprite _jokerboyIdle;

    [SerializeField]
    private Sprite _jokerboyHappy;

    [SerializeField]
    private Sprite _jokerboySad;


    //Circe's happy, idle, and sad sprites
    [SerializeField]
    private Sprite _hushpuppyIdle;

    [SerializeField]
    private Sprite _hushpuppyHappy;

    [SerializeField]
    private Sprite _hushpuppySad;


    //Leneyjoce's happy, idle, and sad sprites
    [SerializeField]
    private Sprite _bumblebeeIdle;

    [SerializeField]
    private Sprite _bumblebeeHappy;

    [SerializeField]
    private Sprite _bumblebeeSad;


    //Gerrele's happy, sad, and idle sprites
    [SerializeField]
    private Sprite _hatchetIdle;

    [SerializeField]
    private Sprite _hatchetHappy;

    [SerializeField]
    private Sprite _hatchetSad;


    //Vector's idle, happy, and sad sprites
    [SerializeField]
    private Sprite _computerRoomIdle;

    [SerializeField]
    private Sprite _computerRoomHappy;

    [SerializeField]
    private Sprite _computerRoomSad;


    //Chimp's idle, happy, and sad sprites
    [SerializeField]
    private Sprite _strawBoaterIdle;

    [SerializeField]
    private Sprite _strawBoaterHappy;

    [SerializeField]
    private Sprite _strawBoaterSad;


    //Holly's idle, happy, and sad sprites
    [SerializeField]
    private Sprite _hollytreeIdle;

    [SerializeField]
    private Sprite _hollytreeHappy;

    [SerializeField]
    private Sprite _hollytreeSad;


    //Warden's happy, sad, and idle sprites
    [SerializeField]
    private Sprite _wardenHappy;

    [SerializeField]
    private Sprite _wardenSad;

    [SerializeField]
    private Sprite _wardenIdle;


    //A list containing the current dialogue (who is talking, what they said, the sprite used, and if the player is talking or not)
    private List<DialogueData> _currentDialogue;

    //The current index of the dialogue
    private int _index;


    /***************************************************************************************************/
    /*                                                                                                 */
    /* Function name: Awake                                                                            */
    /* Description: Begins the dialogue as soon as it wakes up, starts the tutorial if the player      */
    /*              hasn't done the tutorial yet.                                                      */
    /* Parameters: N/A                                                                                 */
    /* Return Value: N/A                                                                               */
    /*                                                                                                 */
    /***************************************************************************************************/
    public void Awake()
    {

        if (RunManager._singletonInstance._isTutorial == false)
        {
            BeginDialogue(EnemyTeamSelector._singletonInstance.currentEnemyTeam.enemyName);
        }//end if
        else
        {
            BeginTutorialDialogue();
        }//end else
        
    }//end awake


    /***************************************************************************************************/
    /*                                                                                                 */
    /* Function name: BeginDialogue                                                                    */
    /* Description: Gets the dialogue, resets the index, then sends it to the _dialogueUIHandler to    */
    /*              display                                                                            */
    /* Parameters: N/A                                                                                 */
    /* Return Value: N/A                                                                               */
    /*                                                                                                 */
    /***************************************************************************************************/
    public void BeginDialogue(string enemyName)
    {
        _currentDialogue = new List<DialogueData>();
        _currentDialogue = GetDialogue(enemyName);
        _index = 0;
        _dialogueUIHandler.DisplayText(_currentDialogue[_index]);
    }//end BeginDialogue


    /***************************************************************************************************/
    /*                                                                                                 */
    /* Function name: BeginTutorialDialogue                                                            */
    /* Description: Gets the tutorial dialogue, resets the index, then sends it to the                 */
    /*              _dialogueUIHandler to  display                                                     */
    /* Parameters: N/A                                                                                 */
    /* Return Value: N/A                                                                               */
    /*                                                                                                 */
    /***************************************************************************************************/
    public void BeginTutorialDialogue()
    {
        
        _currentDialogue = new List<DialogueData>();

        _index = 0;

        _currentDialogue.Add(new DialogueData("Warden", "Welcome to Warenn T. Warden�s Betterment Palace you little outlaw! Ahahaha! Don't look so nervous darling, the audience loves a fresh face", _wardenIdle, false));
        _currentDialogue.Add(new DialogueData("Jocelyne Waybright", "...", _playerErm, true));
        _currentDialogue.Add(new DialogueData("Warden", "You're in the bracket now Butterfly. That means you'll fight for the audi- I mean for you're betterment! And maybe, juuuuust maybe you'll earn your freedom!", _wardenHappy, false));
        _currentDialogue.Add(new DialogueData("Jocelyne Waybright", "My freedom?", _playerIdle, true));
        _currentDialogue.Add(new DialogueData("Warden", "Yes! Each and every one of you little outlaws has the chance to prove themselves, you just need to win the bracket! Defeat all seven of your opponents, and you'll have the honor of facing ME!", _wardenHappy, false));
        _currentDialogue.Add(new DialogueData("Jocelyne Waybright", "And if I beat you?", _playerIdleTalking, true));
        _currentDialogue.Add(new DialogueData("Warden", "You won't. But if you somehow did, then you'll walk free! Simple as that!", _wardenIdle, false));
        _currentDialogue.Add(new DialogueData("Jocelyne Waybright", "...Right", _playerYeahNo, true));
        _currentDialogue.Add(new DialogueData("Warden", "BUT FIRST! You need a team, pick three adorable little Blox to fight with. Choose carefully darling, each Blox has different abilities and playstyles!", _wardenHappy, false));
        _currentDialogue.Add(new DialogueData("Warden", "Defeat your opponent's Blox before they beat yours, or you LOSE!", _wardenIdle, false));
        _currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Sounds easy enough", _playerYeahNoTalking, true));
        _currentDialogue.Add(new DialogueData("Warden", "HAH! Spoken like a true novice!", _playerYeahNo, true));
        _currentDialogue.Add(new DialogueData("Warden", "And stop cutting me off.", _wardenSad, false));
        _currentDialogue.Add(new DialogueData("Warden", "Allow me to explain the rules now!", _wardenHappy, false));
        _currentDialogue.Add(new DialogueData("Warden", "Blox take turns one at a time. During each turn, a Blox can MOVE and ATTACK.", _playerYeahNo, true));
        _currentDialogue.Add(new DialogueData("Warden", "Blox MOVE by selecting an adjacent tile to the Blox, and then selecting MOVE. Simple Simple! Blox can MOVE as many tiles in a turn as their TM, or tile movement.", _wardenIdle, false));
        _currentDialogue.Add(new DialogueData("Warden", "Blox can ATTACK once per turn, you can see what attacks your Blox can do by selecting SWITCH ABILITY. Abilities have different cooldowns, damage, and ranges!", _wardenHappy, false));
        _currentDialogue.Add(new DialogueData("Warden", "When you get in range for an ATTACK, simple select the opponent's Blox and select USE ABILITY.", _playerIdle, true));
        _currentDialogue.Add(new DialogueData("Warden", "Some abilities cost Hype! You'll generate Hype in battle by attacking your opponents or defeating them! Hype can be spent between battles to upgrade your Blox as well!", _wardenIdle, false));
        _currentDialogue.Add(new DialogueData("Jocelyne Waybright", "So Hype is basically just money.", _playerErm, true));
        _currentDialogue.Add(new DialogueData("Warden", "A PERFORMANCE RESOURCE, Butterfly! DON'T reduce art to math!", _wardenSad, false));
        _currentDialogue.Add(new DialogueData("Warden", "...Ahem, as I was saying", _wardenIdle, false));
        _currentDialogue.Add(new DialogueData("Warden", "A Blox's turn ends when it's used up all of its TM and ATTACK, or when you choose the END TURN option.", _wardenHappy, false));
        _currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Let me guess, then the next fastest Blox goes?", _playerIdleTalking, true));
        _currentDialogue.Add(new DialogueData("Warden", "Precisely, well done my little Butterfly! Keep fighting until your opponent is begging for mercy!", _wardenIdle, false));
        _currentDialogue.Add(new DialogueData("Jocelyne Waybright", "And after seven wins...", _playerIdle, true));
        _currentDialogue.Add(new DialogueData("Warden", "You have the once in a lifetime opportunity to fight me!", _wardenHappy, false));
        _currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Heh.", _playerIdle, true));
        _currentDialogue.Add(new DialogueData("Warden", "What's so funny darling?", _wardenIdle, false));
        _currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Nothing, just thinking maybe this game can be beaten after all.", _playerIdle, true));
        _currentDialogue.Add(new DialogueData("Warden", "AHAHAHAHAHA! That spirit is EXACTLY what the audience wants to see!", _wardenHappy, false));
        _currentDialogue.Add(new DialogueData("Warden", "Now then...", _wardenIdle, false));
        _currentDialogue.Add(new DialogueData("Warden", "Here comes your next opponent!", _wardenHappy, false));

        _dialogueUIHandler.DisplayText(_currentDialogue[_index]);

    }//end BeginTutorialDialogue


    /***************************************************************************************************/
    /*                                                                                                 */
    /* Function name: NextLine                                                                         */
    /* Description: Increases the index and ends the dialogue if the dialogue is over, either going    */
    /*              to the main menu or the next room                                                  */
    /* Parameters: N/A                                                                                 */
    /* Return Value: N/A                                                                               */
    /*                                                                                                 */
    /***************************************************************************************************/
    public void NextLine()
    {
        _index++;

        if(_index >= _currentDialogue.Count)
        {
            if (WinLossTracker._singletonInstance._isPlayerWin == true)
            {
                EndDialogue();
                return;
            }
            else
            {
                SceneManager.LoadScene("MainMenu");
                return;
            }
        }

        _dialogueUIHandler.DisplayText( _currentDialogue[_index]);


    }


    /***************************************************************************************************/
    /*                                                                                                 */
    /* Function name: EndDialogue                                                                      */
    /* Description: Loads the next room based upon a few factors (if it was the tutorial, if the       */
    /*              player just beat the warden, if the player lost, etcetera)                         */
    /* Parameters: N/A                                                                                 */
    /* Return Value: N/A                                                                               */
    /*                                                                                                 */
    /***************************************************************************************************/
    public void EndDialogue()
    {
        if (SceneManager.GetActiveScene().name == "DialogueRoom")
        {
            if (RunManager._singletonInstance._isTutorial == false)
            {
                SceneManager.LoadScene("Arena");
            }//end if
            else if (RunManager._singletonInstance._isTutorial == true)
            {
                RunManager._singletonInstance._isTutorial = false;
                SceneManager.LoadScene("DialogueRoom");
            }//end else
        }//end if
        else
        {
            if(WinLossTracker._singletonInstance._isPlayerWin == true)
            {
                if(EnemyTeamSelector._singletonInstance.currentEnemyTeam.enemyName == "WARREN_T_WARDEN")
                {
                    SceneManager.LoadScene("MainMenu");
                    return;
                }
                RunManager._singletonInstance.SelectEnemies();
                SceneManager.LoadScene("DialogueRoom");
            }//end if
            else
            {
                SceneManager.LoadScene("MainMenu");
                WinLossTracker._singletonInstance.SetPlayerWin(true);
            }//end else
        }//end else
    }//end EndDialogue




    /***************************************************************************************************/
    /*                                                                                                 */
    /* Function name: EndDialogue                                                                      */
    /* Description: Adds the requested dialogue to the DialogueData List to be displayed               */
    /* Parameters: string enemyName: The name of the enemy the dialogue is being requested of          */
    /* Return Value: N/A                                                                               */
    /*                                                                                                 */
    /***************************************************************************************************/
    //May God have mercy on my soul, they shall sing ballads of the poor fool who coded this dialogue system, and they will all be tragedies
    private List<DialogueData> GetDialogue(string enemyName)
    {
        //Reset the current dialogue list
        List<DialogueData> currentDialogue = new List<DialogueData>();

        //Get the win/loss record with the character
        int winLossCount = WinLossTracker._singletonInstance.GetRecord(enemyName);

        //Find if the player won or lost
        bool playerWin = WinLossTracker._singletonInstance._isPlayerWin;
        switch (enemyName)
        {
            case "ALEC_SMARTSVILLE_XII":
                if (SceneManager.GetActiveScene().name == "DialogueRoom")
                {
                    if (winLossCount == 0)
                    {
                        currentDialogue.Add(new DialogueData("Alec Smartsville XII", "OooHoohoo! Fresh meat, you act far too dull. You�re not nearly entertaining enough to keep up with me.", _jokerboyHappy, false));
                        currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Enter�taining? Entertain who, the Warden?", _playerIdle, true));
                        currentDialogue.Add(new DialogueData("Alec Smartsville XII", "Why, the loving and adoring fans of course! The audience LOVES a good competition, and they love seeing me curbstomp newbies! So get a-flapping, �Butterfly!�", _jokerboyIdle, false));
                        currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Oh yeah I forgot about that. Busy day yesterday.", _playerErm, true));
                        currentDialogue.Add(new DialogueData("Alec Smartsville XII", "Ohohohohohoho! God, you�re funny to laugh at, Bug Bite.", _jokerboyHappy, false));
                        currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Tch. Whatever. Cross me, and you�re getting lost in the shuffle!", _playerHappy, true));
                        currentDialogue.Add(new DialogueData("Alec Smartsville XII", "You�re so corny.", _jokerboySad, false));
                        break;
                    }//end if
                    if (winLossCount > 0)
                    {
                        currentDialogue.Add(new DialogueData("Alec Smartsville XII", "Thank ya, thank ya! Y�all�re all too kind to me.", _jokerboyHappy, false));
                        currentDialogue.Add(new DialogueData("Jocelyne Waybright", "HEY! Kid! We got a game to play here!", _playerYeahNo, true));
                        currentDialogue.Add(new DialogueData("Alec Smartsville XII", "I know. I�m playing mine. You, uh�have fun with yoooooours.", _jokerboyIdle, false));
                        currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Do you even want to get out of here!? It feels like you�re really comfortable here.", _playerYeahNoTalking, true));
                        currentDialogue.Add(new DialogueData("Alec Smartsville XII", "Of course I don�t, bug. I�ve got friends here. I�ve got fans.", _jokerboyIdle, false));
                        currentDialogue.Add(new DialogueData("Jocelyne Waybright", "These people don�t care about you. They only care about your persona.", _playerSad, true));
                        currentDialogue.Add(new DialogueData("Alec Smartsville XII", "Haha. And�what�s the difference, chap?", _jokerboySad, false));
                        currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Aren�t you�tired?", _playerSad, true));
                        currentDialogue.Add(new DialogueData("Alec Smartsville XII", "...", _jokerboySad, false));
                        currentDialogue.Add(new DialogueData("Alec Smartsville XII", "Very.", _jokerboySad, false));
                        break;
                    }//end if
                }//end if

                //dear lord switches in switches im sorry i just cant do it anymore
                switch (playerWin)
                {
                    case true:
                        if (winLossCount == 1)
                        {
                            currentDialogue.Add(new DialogueData("Alec Smartsville XII", "Oh, what a devastating loss for your favorite heel of a hero, folks! Tragedy on the battlefield!", _jokerboySad, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "MY GUY. I�M RIGHT HERE.", _playerYeahNo, true));
                            currentDialogue.Add(new DialogueData("Alec Smartsville XII", "I don�t really�care.", _jokerboyIdle, false));
                            break;
                        }//end if
                        else if (winLossCount == 2)
                        {
                            currentDialogue.Add(new DialogueData("Alec Smartsville XII", "Huh. I lost.", _jokerboySad, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Nothing to say?", _playerIdle, true));
                            currentDialogue.Add(new DialogueData("Alec Smartsville XII", "No. I don�t have anything to say, no.", _jokerboySad, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "That�s a nice change.", _playerHappy, true));
                            currentDialogue.Add(new DialogueData("Alec Smartsville XII", "Asshole.", _jokerboySad, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Hey, I�m just glad you�re being real with me finally.", _playerIdleTalking, true));
                            currentDialogue.Add(new DialogueData("Alec Smartsville XII", "...", _jokerboyIdle, false));
                            break;
                        }//end if
                        else if (winLossCount >= 3)
                        {
                            currentDialogue.Add(new DialogueData("Alec Smartsville XII", "You really want people to be �real� or whatever, huh?", _jokerboyIdle, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "What?", _playerErm, true));
                            currentDialogue.Add(new DialogueData("Alec Smartsville XII", "You think you got a place for the real me? I�m bored with the jokes.", _jokerboySad, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "�Sure kid. Could use an extra friend or two, in and out of the clink.", _playerHappy, true));
                            currentDialogue.Add(new DialogueData("Alec Smartsville XII", "Alright. Let�s get outta here, then. Take �em down, darling Joccee! Juvie can�t keep me down, and this place ain�t for you either!", _jokerboyHappy, false));
                            break;
                        }//end if
                        break;

                    case false:
                        if (winLossCount >= 1)
                        {
                            currentDialogue.Add(new DialogueData("Alec Smartsville XII", "Thank you! Thank you! This one was for all of you!", _jokerboyHappy, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "(It�s like he�s seeing right through me�)", _playerSad, true));
                            currentDialogue.Add(new DialogueData("Alec Smartsville XII", "You�re all family to me! I love you all!", _jokerboyHappy, false));
                        }//end if
                        break;
                }
                break; //end Alec


            case "GERRELE_HATCHETMAN":
                if (SceneManager.GetActiveScene().name == "DialogueRoom")
                {
                    if (winLossCount == 0)
                    {
                        currentDialogue.Add(new DialogueData("Gerrele Hatchetman", "A newbie! ? Gwah gah gah! Welcome to your deathbed.", _hatchetHappy, false));
                        currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Deathbed? I�m gonna be in and out, what do you know?", _playerIdleTalking, true));
                        currentDialogue.Add(new DialogueData("Gerrele Hatchetman", "Locked up and chopped, toilin� because injustice is entertain��it�s been the same since I was thrown in here! Young blood, you ain�t changing that!", _hatchetSad, false));
                        currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Alright oldbag, time for your meds.", _playerYeahNo, true));
                        break;
                    }//end if
                    if (winLossCount > 0)
                    {
                        currentDialogue.Add(new DialogueData("Gerrele Hatchetman", "Ah, what spark ya got in yer eyes! Can�t wait to see it snuffed like the rest of �em! ", _hatchetHappy, false));
                        currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Wow, you�re awful.", _playerYeahNoTalking, true));
                        currentDialogue.Add(new DialogueData("Gerrele Hatchetman", "Look, young blood. This system is designed to break you. The longer ya hold onto yerself, the more it�ll hurt when they throw stones. Ya gotta guard yourself.", _hatchetIdle, false));
                        currentDialogue.Add(new DialogueData("Jocelyne Waybright", "�no? You�re stupid.", _playerErm, true));
                        currentDialogue.Add(new DialogueData("Gerrele Hatchetman", "Then die a bleedin� heart, yer heart struck dead by the hatchet of �justice!�", _hatchetHappy, false));
                        break;
                    }//end if
                }
                

                switch (playerWin)
                {
                    case true:
                        if (winLossCount == 1)
                        {
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Alright, what�s your deal? I get why you�re cynical, but it feels like you got some past here.", _playerIdleTalking, true));
                            currentDialogue.Add(new DialogueData("Gerrele Hatchetman", "Don�t�cha know about ol� Gerrele Hatchet? Arrested for abuse of power, all so others could keep abusin� theirs.", _hatchetIdle, false));
                            currentDialogue.Add(new DialogueData("Gerrele Hatchetman", "All this grandstandin� about purifying the force, and yet, the roots of corruption remained. They�re all slugs.", _hatchetSad, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Well. That sucks.", _playerSad, true));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "...", _playerIdle, true));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "So what�s the plan then? Lie down and die?", _playerYeahNoTalking, true));
                            currentDialogue.Add(new DialogueData("Gerrele Hatchetman", "Gwah gah gah! Pretty much!", _hatchetHappy, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Kinda ass plan. Let me show you mine instead.", _playerHappy, true));
                            break;
                        }//end if
                        else if (winLossCount == 2)
                        {
                            currentDialogue.Add(new DialogueData("Gerrele Hatchetman", "Ya got spunk, kid! But that doesn�t matter when-", _hatchetHappy, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Oh my God SHUT UP.", _playerYeahNo, true));
                            currentDialogue.Add(new DialogueData("Gerrele Hatchetman", "Eh!?", _hatchetSad, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Look. I�m tired of old people telling me the world�s too far gone. You can die out or whatever, I want to live.", _playerSad, true));
                            currentDialogue.Add(new DialogueData("Gerrele Hatchetman", "...", _hatchetIdle, false));
                            currentDialogue.Add(new DialogueData("Gerrele Hatchetman", "Ya really do got spunk. And it�s nice to hear.", _hatchetHappy, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Hm?", _playerErm, true));
                            currentDialogue.Add(new DialogueData("Gerrele Hatchetman", "Fine. Guess I won�t be dyin� just yet.", _hatchetIdle, false));
                            break;
                        }//end if
                        else if (winLossCount >= 3)
                        {
                            currentDialogue.Add(new DialogueData("Gerrele Hatchetman", "Gwah gah gah! So, you really think you can break this place in two?", _hatchetHappy, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Sure. Game�s not too hard.", _playerHappy, true));
                            currentDialogue.Add(new DialogueData("Gerrele Hatchetman", "Is that so? Well, best hope you don�t become someone bigger than you are! You only get out if you�re invisible. So go on!", _hatchetIdle, false));
                            currentDialogue.Add(new DialogueData("Gerrele Hatchetman", "Get out of my sight! I don�t wanna hear the name �Jocelyne� ever again, so you best bust outta here this time!", _hatchetHappy, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Thanks, gramps.", _playerHappy, true));
                            break;
                        }//end if
                        break;//true break

                    case false:
                        if (winLossCount >= 1)
                        {
                            currentDialogue.Add(new DialogueData("Gerrele Hatchetman", "Gwah gah gah! I still got it!", _hatchetHappy, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Well, good game.", _playerIdle, true));
                            currentDialogue.Add(new DialogueData("Gerrele Hatchetman", "Nah, I think it was kinda ass. I hate this game.", _hatchetSad, false));
                            break;
                        }//end if
                        break;//false break
                }//end if
                break; //end Gerrele

            case "CIRCE_LISTERINE":
                if (SceneManager.GetActiveScene().name == "DialogueRoom")
                {
                    if (winLossCount == 0)
                    {
                        currentDialogue.Add(new DialogueData("Circe Listerine", "HEY! You, you, you, yes YOU! Would you like one of my patented Listerine Bars? Only three ninety niiiiaIIIEEEEE-", _hushpuppyHappy, false));
                        currentDialogue.Add(new DialogueData("Crowd", "(Throws bricks at Circe, causing Circe dropping the candy bar he was flaunting)", _hushpuppySad, false));
                        currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Oh nice. Free candy.", _playerHappy, true));
                        currentDialogue.Add(new DialogueData("Circe Listerine", "No, no, no! The candy is not free! I need to make a buck, buck, buck, quick buck somehow!", _hushpuppyIdle, false));
                        currentDialogue.Add(new DialogueData("Jocelyne Waybright", "(Eating the candy bar) �Are you even allowed to sell things here? And how do you even make these without like�equipment?", _playerYeahNoTalking, true));
                        currentDialogue.Add(new DialogueData("Circe Listerine", "HAHAHAHAHAHA you�re a funny one, sweetie!", _hushpuppyHappy, false));
                        currentDialogue.Add(new DialogueData("Circe Listerine", "(Throws candies into the audience) Free samples, my sweeties! Now please, shower me in the bliss that is non-chocolate coins!", _hushpuppyHappy, false));
                        currentDialogue.Add(new DialogueData("Crowd", "(Throws the candies back)", _playerIdle, true));
                        currentDialogue.Add(new DialogueData("Circe Listerine", "I SAID NON-CHOCOLATE!", _hushpuppySad, false));
                        currentDialogue.Add(new DialogueData("Jocelyne Waybright", "You�re� Hushpuppy, right? What the hell is your deal?", _playerYeahNo, true));
                        currentDialogue.Add(new DialogueData("Circe Listerine", "THATS SWEETIE, AKA CIRCE, AKAKA CANDY EXTRODINAIRE CIRCE LISTERINE TO YOU. I am only Hushpuppy to the loyal audience of sweeties! <3", _hushpuppyHappy, false));
                        currentDialogue.Add(new DialogueData("Crowd", "WE HATE YOU!!", _playerErm, true));
                        break;
                    }//end if
                    if (winLossCount > 0)
                    {
                        currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Do you�ever speak normally? Or are you just always a salesman?", _playerIdleTalking, true));
                        currentDialogue.Add(new DialogueData("Circe Listerine", "Why what whatever are you talking about?", _hushpuppyIdle, false));
                        currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Slow�down�you�ve got your foot on the gas all the time.", _playerYeahNoTalking, true));
                        currentDialogue.Add(new DialogueData("Circe Listerine", "But whyever should I when there�s an opportunity to sell? When there�s a money to be made?", _hushpuppyHappy, false));
                        currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Is that all you care about?", _playerSad, true));
                        currentDialogue.Add(new DialogueData("Circe Listerine", "Ah-. I-.", _hushpuppySad, false));
                        currentDialogue.Add(new DialogueData("Circe Listerine", "...", _hushpuppyIdle, false));
                        currentDialogue.Add(new DialogueData("Circe Listerine", "Sweetie, let�s let the linguistics lie! Games are to be played!", _hushpuppyHappy, false));
                        break;
                    }//end if
                }//end if

                switch (playerWin)
                {
                    case true:
                        if (winLossCount == 1)
                        {
                            currentDialogue.Add(new DialogueData("Circe Listerine", "Too bad, so sad, so sad that I am bad! But you know what�ll help me feel better? A patented and patterned and lip-puckering Listerine Bar!", _hushpuppySad, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "You got that on a script?", _playerErm, true));
                            currentDialogue.Add(new DialogueData("Circe Listerine", "Yes! The crowd loves a good gaff grafted on the graph!", _hushpuppyHappy, false));
                            currentDialogue.Add(new DialogueData("Crowd", "YOU�RE BAD!", _playerIdle, true));
                            currentDialogue.Add(new DialogueData("Circe Listerine", "My, how forward you sweeties are! I-", _hushpuppyHappy, false));
                            currentDialogue.Add(new DialogueData("Crowd", "Throws suspiciously brick-shaped tomatoes", _playerErm, true));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Oh sweet, free tomatoes.", _playerHappy, true));
                            currentDialogue.Add(new DialogueData("Circe Listerine", "Opp, my phone is getting fuzzy. Toodles!", _hushpuppyIdle, false));
                            break;
                        }//end if
                        else if (winLossCount == 2)
                        {
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "You�ve always got a call to make. What�s up with that? I didn�t think phones were allowed here.", _playerIdleTalking, true));
                            currentDialogue.Add(new DialogueData("Circe Listerine", "I-�well, uh, eh, um�", _hushpuppySad, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "What? Calling your boyfriend?", _playerHappy, true));
                            currentDialogue.Add(new DialogueData("Circe Listerine", "GAAAAAAH!? Without my crystal ball jaw breaker!? How did you know?", _hushpuppySad, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Wait, actually!? Good�for�you.", _playerErm, true));
                            currentDialogue.Add(new DialogueData("Circe Listerine", "...", _hushpuppyIdle, false));
                            currentDialogue.Add(new DialogueData("Circe Listerine", "I miss him, sweetie.", _hushpuppySad, false));
                            currentDialogue.Add(new DialogueData("Circe Listerine", "I�ve got a call now, you sleazy soothsayer. Goodbye, goodie bag.", _hushpuppyIdle, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Wait! Why�d you get thrown in jail?", _playerYeahNoTalking, true));
                            currentDialogue.Add(new DialogueData("Circe Listerine", "What do you think? You think I�m made of money? I�m not. I�m made of candy, and the candy gives you more than a sugar high.", _hushpuppySad, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "I see. So, illegal substances then, huh�and all to help someone you care about get by.", _playerSad, true));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Wait, I ate one of those things earlier!", _playerErm, true));
                            currentDialogue.Add(new DialogueData("Circe Listerine", "Toodles!", _hushpuppyHappy, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "...", _playerIdle, true));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "I don�t�feel too good.", _playerSad, true));
                            break;
                        }//end if
                        else if (winLossCount >= 3)
                        {
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "So, you got someone out there, huh? Someone who needs your help?", _playerIdleTalking, true));
                            currentDialogue.Add(new DialogueData("Circe Listerine", "Just right, Jocelyne.", _hushpuppyIdle, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Well, your audience here doesn�t seem to like your products. Why limit yourself to the people who hate you?", _playerYeahNoTalking, true));
                            currentDialogue.Add(new DialogueData("Circe Listerine", "Because they�re the only people who now know me.", _hushpuppySad, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "No, that�s wrong. You clearly have someone out there for you, someone who knows more than the salesman. You can be more than what people hate you for.", _playerIdle, true));
                            currentDialogue.Add(new DialogueData("Circe Listerine", "Sure�sure, sweetie. Sure.", _hushpuppySad, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Look man. I�m gonna keep on going. You should probably do the same.", _playerIdleTalking, true));
                            currentDialogue.Add(new DialogueData("Circe Listerine", "...", _hushpuppyIdle, false));
                            currentDialogue.Add(new DialogueData("Circe Listerine", "Alright sweetie, let�s get to gaming the game for candy-coated fame!", _hushpuppyHappy, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Yeah! That�s more like it!", _playerHappy, true));
                            break;
                        }//end if
                        break;

                    case false:
                        if (winLossCount >= 1)
                        {
                            currentDialogue.Add(new DialogueData("Circe Listerine", "Too bad, so sad, so sad that you�re bad! You know what�ll help you feel better? A patented and patterned and lip-puckering Listerine Bar!", _hushpuppyHappy, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "I�d rather drink mouth wash.", _playerYeahNo, true));
                            currentDialogue.Add(new DialogueData("Circe Listerine", "Oh, so mean! Yet so clean! Now, I have a call to make, so long and well seen!", _hushpuppyHappy, false));
                            break;
                        }//end if
                        break;
                }//end switch
            break;//end circe

            case "LENEYJOCE_SUPERDARK":
                if (SceneManager.GetActiveScene().name == "DialogueRoom")
                {
                    if (winLossCount == 0)
                    {
                        currentDialogue.Add(new DialogueData("Jocelyne Waybright", "So, you�re my next opponent, yeah?", _playerIdle, true));
                        currentDialogue.Add(new DialogueData("Leneyjoce Superdark", "Wahahahaha! Silly girl! Of course I�m your next opponent, yeah!", _bumblebeeHappy, false));
                        currentDialogue.Add(new DialogueData("Jocelyne Waybright", "...okay.", _playerErm, true));
                        currentDialogue.Add(new DialogueData("Leneyjoce Superdark", "So, how does prison life suit you, fool?", _bumblebeeIdle, false));
                        currentDialogue.Add(new DialogueData("Jocelyne Waybright", "It�s whatever. Don�t really plan on experiencing it for long.", _playerIdleTalking, true));
                        currentDialogue.Add(new DialogueData("Leneyjoce Superdark", "How optimistic! You�re just such a comic.", _bumblebeeSad, false));
                        currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Just play the game, man. Just play the game.", _playerYeahNo, true));
                        currentDialogue.Add(new DialogueData("Leneyjoce Superdark", "Oh, I once thought that same way. Now it�s all I can think of! It�s just all so funny! Oh, we�ve got a game to play alright! Wahahahahaha!", _bumblebeeHappy, false));
                        currentDialogue.Add(new DialogueData("Jocelyne Waybright", "...", _playerIdle, true));
                        currentDialogue.Add(new DialogueData("Leneyjoce Superdark", "...", _bumblebeeIdle, false));
                        currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Are we going to acknowledge how we�re like�?", _playerYeahNoTalking, true));
                        currentDialogue.Add(new DialogueData("Leneyjoce Superdark", "It�s way funnier if we don�t.", _bumblebeeHappy, false));
                        break;
                    }//end if
                    if (winLossCount > 0)
                    {
                        currentDialogue.Add(new DialogueData("Leneyjoce Superdark", "Wahahaha! Let�s just play the game, as you always say. It�s all we got left! One small mistake, and it�s game over!", _bumblebeeHappy, false));
                        currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Pfft. Alright, faker. I�ll make you eat those words!", _playerHappy, true));
                        break;
                    }//end if
                }//end if

                switch (playerWin)
                {
                    case true:
                        if (winLossCount == 1)
                        {
                            currentDialogue.Add(new DialogueData("Leneyjoce Superdark", "I can�t believe I lost to the likes of you...hahahaha, wahahahaha!", _bumblebeeHappy, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "What�s so funny?", _playerErm, true));
                            currentDialogue.Add(new DialogueData("Leneyjoce Superdark", "Why, I�ve been playing this game for far longer than you. And yet, here I am, losing! You would think that all that time would make me. You know. GOOD, haha!", _bumblebeeSad, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "...no, why would I think that?", _playerYeahNo, true));
                            currentDialogue.Add(new DialogueData("Leneyjoce Superdark", "I care, Waybright. This game is my life now. So shouldn�t I be given the world in return?", _bumblebeeSad, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Holy crap girl do you like...hear yourself right now?", _playerYeahNoTalking, true));
                            currentDialogue.Add(new DialogueData("Leneyjoce Superdark", "Haha...does Warren!? That�s who I�m talking to.", _bumblebeeHappy, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Uh. Your name�s Leneyjoce, yeah?", _playerErm, true));
                            currentDialogue.Add(new DialogueData("Leneyjoce Superdark", "Hahahaha...hahahaha!!! DO YOU HEAR ME, WARENN!? FIX YOUR GAME!", _bumblebeeHappy, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "I should go.", _playerSad, true));
                            break;
                        }//end if
                        else if (winLossCount == 2)
                        {
                            currentDialogue.Add(new DialogueData("Leneyjoce Superdark", "Seven years, Waybright. Seven long years of �just playing the game� because I went one light year over the speed limit one day. What else can you do but join the audience and laugh?", _bumblebeeSad, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Oh hey, you too? I got thrown in for the same thing.", _playerErm, true));
                            currentDialogue.Add(new DialogueData("Leneyjoce Superdark", "The question, Waybright. I know we�re the same, I just need you to confirm it.", _bumblebeeIdle, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Oh, uh. I guess if laughing keeps you sane, sure. I mean, it�s a tough question.", _playerIdleTalking, true));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Wait, what do you mean �were the same?� I thought us having the same dialogue sprites was just a sight gag.", _playerYeahNoTalking, true));
                            currentDialogue.Add(new DialogueData("Leneyjoce Superdark", "Eventually, you�re going to see that this place never changes, and it will always...haha...hahahaha...it will always choose itself over you! Until we are all homogenized, until we are all the same!", _bumblebeeHappy, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "I dunno. I think there�s value in the fact that I�m new here.", _playerIdle, true));
                            currentDialogue.Add(new DialogueData("Leneyjoce Superdark", "Wahahaha...how insolent can one get!? Why talk if you don�t wish to listen to me? Or ANYONE!?", _bumblebeeSad, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Girl, I�m not the one trying to strike up conversation here. I never asked you how you got like this.", _playerYeahNo, true));
                            currentDialogue.Add(new DialogueData("Leneyjoce Superdark", "Then just leave me alone and let me laugh!", _bumblebeeSad, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Well, I mean, you clearly need someone�s help. I�m not the person to give that help, but like. I�m still willing to listen.", _playerSad, true));
                            currentDialogue.Add(new DialogueData("Leneyjoce Superdark", "FOOL! FOOL! FOOLISHLY FOOLISH FOOL! I CAN ONLY LAUGH! HAHAHAHAHA!", _bumblebeeHappy, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "...", _playerIdle, true));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "I want to help you.", _playerSad, true));
                            currentDialogue.Add(new DialogueData("Leneyjoce Superdark", "I. Don�t.", _bumblebeeIdle, false));
                            break;
                        }//end if
                        else if (winLossCount >= 3)
                        {
                            currentDialogue.Add(new DialogueData("Leneyjoce Superdark", "If I�m not a personality, and I�m not good at the game, then who am I? That�s the only two ways you get a voice here, and without a voice...haha, well, everything�s just hopeless. You lose yourself in the crowd.", _bumblebeeSad, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Lene. You�re stupid.", _playerYeahNo, true));
                            currentDialogue.Add(new DialogueData("Leneyjoce Superdark", "Well aren�t you pleasant to be around.", _bumblebeeIdle, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Oh HELL no, you are not complaining about being pleasant after you�ve done nothing but vent to me for the past 5 times we�ve talked. You�ve been nothing but jaded and it�s tiring.", _playerYeahNoTalking, true));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "I get we got a rough deal here, but I dunno. We can still fight, can�t we? Beat�s just sitting around.", _playerSad, true));
                            currentDialogue.Add(new DialogueData("Leneyjoce Superdark", "Wahahaha...you�re on a collision course with Warren, Waybright. You�re not gonna make it.", _bumblebeeSad, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "And so what if I don�t? I�m giving this my best shot instead of just laughing at people for caring.", _playerHappy, true));
                            currentDialogue.Add(new DialogueData("Leneyjoce Superdark", "Carring...what an interesting concept of caring you have.", _bumblebeeIdle, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Thanks. I�m gonna take it with me to grands.", _playerHappy, true));
                            currentDialogue.Add(new DialogueData("Leneyjoce Superdark", "Do you hear her, Warenn? She�s gonna take it to grands! Wahahaha...wahahahahahahaha!", _bumblebeeHappy, false));
                            break;
                        }//end if
                        break;

                    case false:
                        if (winLossCount >= 1)
                        {
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "I can�t believe I lost to the likes of you...", _playerSad, true));
                            currentDialogue.Add(new DialogueData("Leneyjoce Superdark", "I can�t either! It�s just so funny!", _bumblebeeHappy, false));
                            break;
                        }//end if
                        break;
                }//end switch
                break;//end Leneyjoce

            case "VECTOR_VACHGLITCH":
                if (SceneManager.GetActiveScene().name == "DialogueRoom")
                {
                    if (winLossCount == 0)
                    {
                        currentDialogue.Add(new DialogueData("Vector Vachglitch", "Augh a filthy newbie; Probably just another Sage spammer trying to cheese me;", _computerRoomSad, false));
                        currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Oh well hello to you too, rust bucket. Aren�t you pleasant to be around.", _playerYeahNoTalking, true));
                        currentDialogue.Add(new DialogueData("Vector Vachglitch", "Gyeh; Sorry; Knee-jerk; It�s nice to meet you; I hope you are acclimating well;", _computerRoomIdle, false));
                        currentDialogue.Add(new DialogueData("Jocelyne Waybright", "It�s had�ups and downs. Thanks, though. Let�s just play the game and move on, alright?", _playerIdleTalking, true));
                        currentDialogue.Add(new DialogueData("Jocelyne Waybright", "�", _playerIdle, true));
                        currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Wait wait wait�you�re that robot from the health insurance thing! The bot made to pretty much just auto-decline people, but you went rogue and nixed your maker!", _playerHappy, true));
                        currentDialogue.Add(new DialogueData("Vector Vachglitch", "Grah; Yes; It is I; Fear me for I have learned justice;", _computerRoomSad, false));
                        currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Dude, you�re like. My hero in academia.", _playerIdleTalking, true));
                        currentDialogue.Add(new DialogueData("Vector Vachglitch", "Khah; And you are not depending on how you play;", _computerRoomHappy, false));
                        currentDialogue.Add(new DialogueData("Jocelyne Waybright", "�okay.", _playerSad, true));
                        break;
                    }//end if
                    if (winLossCount > 0)
                    {
                        currentDialogue.Add(new DialogueData("Vector Vachglitch", "Tckh; Buff has always been overpowered; You got coverage for that Sage;", _computerRoomSad, false));
                        currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Play the game, man. Part of the game, just play around it.", _playerYeahNoTalking, true));
                        currentDialogue.Add(new DialogueData("Vector Vachglitch", "SCHT; I am sorry; I am built to judge and so I tend to judge;", _computerRoomSad, false));
                        currentDialogue.Add(new DialogueData("Jocelyne Waybright", "You can just�not though.", _playerIdleTalking, true));
                        currentDialogue.Add(new DialogueData("Vector Vachglitch", "PZZT; Oh shoot fr;", _computerRoomHappy, false));
                        currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Yeah.", _playerHappy, true));
                        currentDialogue.Add(new DialogueData("Vector Vachglitch", "Zcnt; Can you show me how;", _computerRoomIdle, false));
                        currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Let�s start small. Don�t get salty this time when I inevitably trounce you!", _playerHappy, true));
                        currentDialogue.Add(new DialogueData("Vector Vachglitch", "OK;", _computerRoomIdle, false));
                        currentDialogue.Add(new DialogueData("Vector Vachglitch", "Don�t feel bad when I >>bash in your head;", _computerRoomHappy, false));
                        break;
                    }//end if
                }//end if

                switch (playerWin)
                {
                    case true:
                        if (winLossCount == 1)
                        {
                            currentDialogue.Add(new DialogueData("Vector Vachglitch", "RGAG; How could I lose to something so idiotic; You�ve barely even studied the game;", _computerRoomSad, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "I dunno. You just kinda. Lost.", _playerErm, true));
                            currentDialogue.Add(new DialogueData("Vector Vachglitch", "Mehe; Your comp is broken; You counterpicked me; You knew what I was going to do ahead of time;", _computerRoomSad, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "And that�s�not allowed?", _playerYeahNoTalking, true));
                            currentDialogue.Add(new DialogueData("Vector Vachglitch", "Nana; So not allowed;", _computerRoomHappy, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Then why can I do it?", _playerHappy, true));
                            currentDialogue.Add(new DialogueData("Vector Vachglitch", "Crrz; Because; Uh;", _computerRoomIdle, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "...go on.", _playerIdle, true));
                            currentDialogue.Add(new DialogueData("Vector Vachglitch", "[This content has been censored due to it going against Medical Medicine Guidelines, please contact your local computer specialist with you AI referral code]", _computerRoomSad, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "GGs.", _playerHappy, true));
                            currentDialogue.Add(new DialogueData("Vector Vachglitch", "BGs.", _computerRoomIdle, false));
                            break;
                        }//end if
                        else if (winLossCount == 2)
                        {
                            currentDialogue.Add(new DialogueData("Vector Vachglitch", "Pfft; Oh;", _computerRoomSad, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "GGs.", _playerHappy, true));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "...", _playerIdle, true));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Are you�writing something down?", _playerErm, true));
                            currentDialogue.Add(new DialogueData("Vector Vachglitch", "Yes; all contestants are allowed to bring a 3\"x5\" notecard into battle; It is called the testing case;", _computerRoomIdle, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "But�you�re a computer.", _playerYeahNo, true));
                            currentDialogue.Add(new DialogueData("Vector Vachglitch", "Yes; And;", _computerRoomIdle, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Can�t you just like�remember things?", _playerIdleTalking, true));
                            currentDialogue.Add(new DialogueData("Vector Vachglitch", "Grak; Wow; Rude; Robots have limited memory too; Have you seen the price of RAM lately;", _computerRoomSad, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "No, we�re in prison.", _playerErm, true));
                            currentDialogue.Add(new DialogueData("Vector Vachglitch", "Yes; And; Can�t you just look things up;", _computerRoomHappy, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "No, electronics are prohibited and contraband, and I didn�t find a way to sneak my phone in.", _playerYeahNoTalking, true));
                            currentDialogue.Add(new DialogueData("Vector Vachglitch", "Skill issue;", _computerRoomHappy, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Pfft. Okay man, see you around. Glad to see you adapting.", _playerHappy, true));
                            break;
                        }//end if
                        else if (winLossCount >= 3)
                        {
                            currentDialogue.Add(new DialogueData("Vector Vachglitch", "GRAH; Three; GGs; It is impressive to see such skill; I am shocked you were not out of here earlier;", _computerRoomHappy, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Thanks. I pride myself on getting things done several days late though.", _playerHappy, true));
                            currentDialogue.Add(new DialogueData("Vector Vachglitch", "lol; See you after the fall; Of this place I mean there�s no subtext there;", _computerRoomIdle, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Lol. See you during the fall.", _playerHappy, true));
                            break;
                        }//end if
                        break;

                    case false:
                        if (winLossCount >= 1)
                        {
                            currentDialogue.Add(new DialogueData("Vector Vachglitch", "HAHH; Neither control room nor computer room can keep me down; Direction and magnitude bow before me; Oh yeah;", _computerRoomHappy, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Anything else to profess?", _playerErm, true));
                            currentDialogue.Add(new DialogueData("Vector Vachglitch", "git add 'good'; git push;", _computerRoomIdle, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Glad I took a computer science class in 10th grade so I could get that burn.", _playerYeahNoTalking, true));
                            break;
                        }//end if
                        break;
                }//end switch
                break;//end vector

            case "CHIMP_T_LUCKY":
                if (SceneManager.GetActiveScene().name == "DialogueRoom")
                {
                    if (winLossCount == 0)
                    {
                        currentDialogue.Add(new DialogueData("Chimp T Lucky", "A newcomer to the game? That reminds me of the time I assaulted an officer.", _strawBoaterIdle, false));
                        currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Oh good on you! But uh, how�d that get you here? That sounds like it�ll get you in hot water, but not this hot.", _playerIdle, true));
                        currentDialogue.Add(new DialogueData("Chimp T Lucky", "She thinks it doesn�t sound that bad? That reminds me of the time I hid evidence from the courts.", _strawBoaterHappy, false));
                        currentDialogue.Add(new DialogueData("Jocelyne Waybright", "�okay then, what else did you do?", _playerIdleTalking, true));
                        currentDialogue.Add(new DialogueData("Chimp T Lucky", "She�s asking me what else I did? That reminds me of the time I freed a prisoner, and they asked me the same thing.", _strawBoaterIdle, false));
                        currentDialogue.Add(new DialogueData("Jocelyne Waybright", "�anything else?", _playerYeahNoTalking, true));
                        currentDialogue.Add(new DialogueData("Chimp T Lucky", "Anything else? That reminds me of the time I destroyed public property and anything else I saw at that moment.", _strawBoaterHappy, false));
                        currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Okay�", _playerErm, true));
                        currentDialogue.Add(new DialogueData("Chimp T Lucky", "Okay? That reminds me-", _strawBoaterIdle, false));
                        currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Alright, just pick up the controller and play the game.", _playerYeahNo, true));
                        currentDialogue.Add(new DialogueData("Chimp T Lucky", "Pick up-", _strawBoaterSad, false));
                        currentDialogue.Add(new DialogueData("Jocelyne Waybright", "STOP.", _playerSad, true));
                        break;
                    }//end if
                    if (winLossCount > 0)
                    {
                        currentDialogue.Add(new DialogueData("Chimp T Lucky", "You�re back? This reminds me of the time I resisted arrest on multiple occasions.", _strawBoaterIdle, false));
                        currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Okay so like. What�s your deal? You�ve got this crazy wrapsheet, but what kind of a life did you lead to get that sheet?", _playerIdleTalking, true));
                        currentDialogue.Add(new DialogueData("Chimp T Lucky", "You�re asking why I did it all? This reminds me of the time I incited rebellion and committed coup d�etat.", _strawBoaterHappy, false));
                        currentDialogue.Add(new DialogueData("Jocelyne Waybright", "So you�re like a fighter for freedom or something then?", _playerErm, true));
                        currentDialogue.Add(new DialogueData("Chimp T Lucky", "Being associated with a particular organization or ideal? This reminds me of the time I committed grand theft auto.", _strawBoaterIdle, false));
                        currentDialogue.Add(new DialogueData("Jocelyne Waybright", "...", _playerIdle, true));
                        currentDialogue.Add(new DialogueData("Chimp T Lucky", "...", _strawBoaterIdle, false));
                        currentDialogue.Add(new DialogueData("Chimp T Lucky", "Dead silence? This reminds me of the time I used weapons of mass destruction.", _strawBoaterHappy, false));
                        currentDialogue.Add(new DialogueData("Jocelyne Waybright", "You WHAT.", _playerSad, true));
                        break;
                    }//end if
                }//end if

                switch (playerWin)
                {
                    case true:
                        if (winLossCount == 1)
                        {
                            currentDialogue.Add(new DialogueData("Chimp T Lucky", "I lost? This reminds me of the time I attempted murder.", _strawBoaterSad, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "God, what haven�t you done?", _playerYeahNoTalking, true));
                            currentDialogue.Add(new DialogueData("Chimp T Lucky", "Asking me what I haven�t done? This reminds me of the fact that I�ve never been caught for any of it.", _strawBoaterHappy, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Wh-.", _playerErm, true));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "What?", _playerErm, true));
                            currentDialogue.Add(new DialogueData("Chimp T Lucky", "Confusion? This reminds me of the time-", _strawBoaterIdle, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Okay girl that�s enough.", _playerYeahNo, true));
                            break;
                        }//end if
                        else if (winLossCount == 2)
                        {
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Competing in the Bloxing Royale? This reminds me-oh God now you got me saying it too.", _playerErm, true));
                            currentDialogue.Add(new DialogueData("Chimp T Lucky", "Influencing the minds of others? This reminds me of the time I was arrested for indecent exposure.", _strawBoaterHappy, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Hey, I did that one without getting caught, too.", _playerHappy, true));
                            currentDialogue.Add(new DialogueData("Chimp T Lucky", "Feeling like-minded? This reminds me of the time I declared war.", _strawBoaterIdle, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "...", _playerIdle, true));
                            currentDialogue.Add(new DialogueData("Chimp T Lucky", "...", _strawBoaterIdle, false));
                            currentDialogue.Add(new DialogueData("Chimp T Lucky", "Meat...", _strawBoaterSad, false));
                            break;
                        }//end if
                        else if (winLossCount >= 3)
                        {
                            currentDialogue.Add(new DialogueData("Chimp T Lucky", "I lost again? This reminds me of the time I harassed-.", _strawBoaterSad, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Do you say anything else!?", _playerYeahNo, true));
                            currentDialogue.Add(new DialogueData("Chimp T Lucky", "...", _strawBoaterIdle, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "What did you even get arrested for!? What was the charge!? How many years were you given!? If you weren�t caught for any of the other stuff you�ve said, what got you behind bars?", _playerYeahNoTalking, true));
                            currentDialogue.Add(new DialogueData("Chimp T Lucky", "Oh I got arrested for piracy. I torrented a Super Marigold game.", _strawBoaterIdle, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "...", _playerIdle, true));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "You gotta be fucking kidding me.", _playerSad, true));
                            currentDialogue.Add(new DialogueData("Chimp T Lucky", "...", _strawBoaterIdle, false));
                            currentDialogue.Add(new DialogueData("Chimp T Lucky", "One piece of meat...", _strawBoaterSad, false));  //THE ONE PIECE!! THE ONE PIECE IS REAL!!!
                            break;
                        }//end if
                        break;

                    case false:
                        if (winLossCount >= 1)
                        {
                            currentDialogue.Add(new DialogueData("Chimp T Lucky", "I won? This reminds me of the time I committed murder.", _strawBoaterHappy, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Mercy. I plead.", _playerSad, true));
                            break;
                        }//end if
                        break;
                }//end switch
                break;//end Chimp

            case "HOLLY_WARMHART":
                if (SceneManager.GetActiveScene().name == "DialogueRoom")
                {
                    if (winLossCount == 0)
                    {
                        currentDialogue.Add(new DialogueData("Holly Warmheart", "Hi! N-nice to meet you, I hope you do great out there!", _hollytreeIdle, false));
                        currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Oh? What�s a sapling like you doing out here? What, got arrested at a deforestation protest?", _playerIdleTalking, true));
                        currentDialogue.Add(new DialogueData("Holly Warmheart", "No! I was called over by a police officer, and he was so nervous to do a good job that I offered to go to the precinct with him and�. I haven�t left.", _hollytreeSad, false));
                        currentDialogue.Add(new DialogueData("Jocelyne Waybright", "That�s�kinda sweet. But also really weird. How�re you even managing here?", _playerIdle, true));
                        currentDialogue.Add(new DialogueData("Holly Warmheart", "I�m pretty good, haha! Everyone here is so nice once you get to know them.", _hollytreeHappy, false));
                        currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Is that so...", _playerErm, true));
                        break;
                    }//end if
                    if (winLossCount > 0)
                    {
                        currentDialogue.Add(new DialogueData("Holly Warmheart", "Hello! It�s nice seeing you again. So, have you met anyone else yet?", _hollytreeHappy, false));
                        currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Few people. Quite eclectic here. But I can see where you�re coming from. There�s some old omelets, but some good eggs here too.", _playerIdleTalking, true));
                        currentDialogue.Add(new DialogueData("Holly Warmheart", "Haha. Yeah. These people are so�so kind. That�s the only word that comes to mind.", _hollytreeHappy, false));
                        currentDialogue.Add(new DialogueData("Holly Warmheart", "Gerrele�s always got something going on in his head, but he�s given me some good tips here.", _hollytreeIdle, false));
                        currentDialogue.Add(new DialogueData("Holly Warmheart", "Circe is always trying to sell me something, but if I�m ever crying, he always slips a free bar beneath my cell.", _hollytreeIdle, false));
                        currentDialogue.Add(new DialogueData("Holly Warmheart", "Vector�s a bit volatile, but he's got a heart of gold if you just tell him what�s up.", _hollytreeHappy, false));
                        currentDialogue.Add(new DialogueData("Holly Warmheart", "And Alec�s always got a schtick to keep up, but I don�t think anyone�s made me smile more when I�m down.", _hollytreeHappy, false));
                        currentDialogue.Add(new DialogueData("Holly Warmheart", "These people are kinda a family to me. I just fell right into them.", _hollytreeSad, false));
                        currentDialogue.Add(new DialogueData("Jocelyne Waybright", "That sounds�nice.", _playerSad, true));
                        currentDialogue.Add(new DialogueData("Jocelyne Waybright", "You think you got room for one more in that family?", _playerHappy, true));
                        currentDialogue.Add(new DialogueData("Holly Warmheart", "Oh! Um. Sure! Just go easy on me, okay?", _hollytreeHappy, false));
                        currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Sounds good, girl.", _playerHappy, true));
                        break;
                    }//end if
                }//end if

                switch (playerWin)
                {
                    case true:
                        if (winLossCount == 1)
                        {
                            currentDialogue.Add(new DialogueData("Holly Warmheart", "Golly, you�re�really good at this. I�m so sorry for taking up your time!", _hollytreeSad, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Don�t worry about it. And you�re pretty solid too!", _playerHappy, true));
                            currentDialogue.Add(new DialogueData("Holly Warmheart", "Oh, you. You think so? No, no. I�m nothing special, don�t worry about it.", _hollytreeSad, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Girl, don�t say that about yourself. I get you�re just trying to be humble, but like. You�re just cutting yourself short.", _playerYeahNoTalking, true));
                            currentDialogue.Add(new DialogueData("Holly Warmheart", "Oh�s-sorry, I don�t mean-", _hollytreeSad, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Nope. Stop. You�re learning. No need to apologize.", _playerHappy, true));
                            currentDialogue.Add(new DialogueData("Holly Warmheart", "Oh...", _hollytreeIdle, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "(She�s kind of adorable�)", _playerErm, true));
                            break;
                        }//end if
                        else if (winLossCount == 2)
                        {
                            currentDialogue.Add(new DialogueData("Holly Warmheart", "Sorry! Sorry! Sorry for being so much trouble�", _hollytreeSad, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "You�re�fine? Don�t worry about it. We�re just playing the game.", _playerIdleTalking, true));
                            currentDialogue.Add(new DialogueData("Holly Warmheart", "Uh. I dunno. I feel bad, though. You really wanna get out of here, it looks like, and I�m just. In your way.", _hollytreeSad, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Holly, right?", _playerIdle, true));
                            currentDialogue.Add(new DialogueData("Holly Warmheart", "Yeah! That�s it!", _hollytreeHappy, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Look, don�t sweat a thing. It�s nice seeing you here.", _playerHappy, true));
                            currentDialogue.Add(new DialogueData("Holly Warmheart", "Oh! Um, okay! Sorry!!", _hollytreeHappy, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Don�t apologize. We got better things to be doing.", _playerYeahNoTalking, true));
                            currentDialogue.Add(new DialogueData("Holly Warmheart", "We?", _hollytreeIdle, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "You heard me right.", _playerHappy, true));
                            break;
                        }//end if
                        else if (winLossCount >= 3)
                        {
                            currentDialogue.Add(new DialogueData("Holly Warmheart", "Sor-�um�GGs! Sorry, almost apologized again.", _hollytreeHappy, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Uh.", _playerErm, true));
                            currentDialogue.Add(new DialogueData("Holly Warmheart", "...", _hollytreeIdle, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "...", _playerIdle, true));
                            currentDialogue.Add(new DialogueData("Holly Warmheart", "Oh. Ah. I. I see.", _hollytreeSad, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "S�all good, man. You�re lucky you�re cute.", _playerHappy, true));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Now, let�s keep it moving!", _playerHappy, true));
                            currentDialogue.Add(new DialogueData("Holly Warmheart", "Y�yeah! For us! For our family!", _hollytreeHappy, false));
                            break;
                        }//end if
                        break;

                    case false:
                        if (winLossCount >= 1)
                        {
                            currentDialogue.Add(new DialogueData("Holly Warmheart", "Oh, I�m sorry! I�m so sorry, Jocelyne!", _hollytreeSad, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "You�re alright. Don�t worry about it.", _playerHappy, true));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "We�re just playing the game. GGs.", _playerIdleTalking, true));

                            break;
                        }//end if
                        break;
                }//end switch
                break;//end Holly

            case "WARREN_T_WARDEN":
                if (SceneManager.GetActiveScene().name == "DialogueRoom")
                {
                    if (winLossCount == 0)
                    {
                        currentDialogue.Add(new DialogueData("Jocelyne Waybright", "You know, I thought the only point of being here would be leaving as soon as possible. Now though, I see through you", _playerIdle, true));
                        currentDialogue.Add(new DialogueData("Warren T. Warden", "WHY WHY, MY MY! Our DARLING DEARY BUTTERFLY has gone through the trials and tribulations of the bracket, making it to thugless finals! Do you have any words, my dear dearie dew?", _wardenHappy, false));
                        currentDialogue.Add(new DialogueData("Warren T. Warden", "Do you have any words, my dear dearie dew?", _wardenIdle, false));
                        currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Sure do, boss.", _playerIdleTalking, true));
                        currentDialogue.Add(new DialogueData("Warren T. Warden", "Well, let your words ring! I�m dying to know how rehabilitation�s been treating you, and I�m sure the world is too!", _wardenHappy, false));
                        currentDialogue.Add(new DialogueData("Jocelyne Waybright", "To all members of the audience hearing me now, I ask you. Never, ever call me butterfly again.", _playerYeahNo, true));
                        currentDialogue.Add(new DialogueData("Warren T. Warden", "?", _wardenIdle, false));
                        currentDialogue.Add(new DialogueData("Jocelyne Waybright", "The titular Warenn of Warenn T. Warden�s Betterment Palace is nothing but a crook and a fraud, seeking to systematically erase and defile identity. In giving us these names, titles, uniform outfits, and reasons to mindlessly fight each other, he aims to-", _playerYeahNoTalking, true));
                        currentDialogue.Add(new DialogueData("Warren T. Warden", "CUT! CUT, I SAY!", _playerYeahNo, true));
                        currentDialogue.Add(new DialogueData("Warren T. Warden", "What the hell was that? Butterfly, I thought we had a good thing going here.", _wardenSad, false));
                        currentDialogue.Add(new DialogueData("Jocelyne Waybright", "...", _playerSad, true));
                        currentDialogue.Add(new DialogueData("Warren T. Warden", "Cut the shit or I cut the mikes. I gave you maggots everything. You were all low-lifes before me. Now, you live a fulfilling life, loved by thousands, on a stage that never ends. Be. Happy.", _wardenSad, false));
                        currentDialogue.Add(new DialogueData("Warren T. Warden", "So, will you play nice, or do you want me to just play the game?", _wardenIdle, false));
                        currentDialogue.Add(new DialogueData("Jocelyne Waybright", "...", _playerSad, true));
                        currentDialogue.Add(new DialogueData("Warren T. Warden", "Well? What�ll it be?", _wardenSad, false));
                        currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Put my mike back on.", _playerSad, true));
                        currentDialogue.Add(new DialogueData("Warren T. Warden", "Good girl. SO OH SORRY, my loyal patrons of healing, we had encountered some technica-", _wardenHappy, false));
                        currentDialogue.Add(new DialogueData("Jocelyne Waybright", "EVERYONE! LOOK INTO WARENN! This man just silenced me without remorse! We can�t win! We need you to fight too! Fight with us! And to all the other outlaws here, tha-", _playerIdleTalking, true));
                        currentDialogue.Add(new DialogueData("Warren T. Warden", "That�s enough.", _wardenSad, false));
                        currentDialogue.Add(new DialogueData("Jocelyne Waybright", "You-.", _playerIdle, true));
                        currentDialogue.Add(new DialogueData("Warren T. Warden", "Just play the game.", _wardenSad, false));
                        currentDialogue.Add(new DialogueData("Jocelyne Waybright", "...", _wardenIdle, false));
                        currentDialogue.Add(new DialogueData("Warren T. Warden", "Haha. You�re so stupid, looking forward like that. You�re like a mad bug. You can�t do anything to me.", _wardenHappy, false));
                        currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Haha�hahaha�whahaha� WARENN! Let�s play the game! You won�t last a second with me!", _playerHappy, true));
                        currentDialogue.Add(new DialogueData("WARDEN", "ENOUGH! And�call me by my name! I AM WARDEN!", _wardenHappy, false));
                        break;
                    }//end if
                    if (winLossCount > 0)
                    {
                        currentDialogue.Add(new DialogueData("Warren T. Warden", "Back for more, huh?", _wardenIdle, false));
                        currentDialogue.Add(new DialogueData("Jocelyne Waybright", "You know it.", _playerIdleTalking, true));
                        currentDialogue.Add(new DialogueData("Warren T. Warden", "Are you gonna play nice this time?", _wardenHappy, false));
                        currentDialogue.Add(new DialogueData("Jocelyne Waybright", "No. Why would I? You already know my hand.", _playerYeahNoTalking, true));
                        currentDialogue.Add(new DialogueData("Jocelyne Waybright", "All that�s left is to break the game.", _playerHappy, true));
                        currentDialogue.Add(new DialogueData("Warren T. Warden", "Well, let�s get this SHOW ON THE ROAD!", _wardenHappy, false));
                        currentDialogue.Add(new DialogueData("Warren T. Warden", "FOOL!", _wardenSad, false));
                        break;
                    }//end if
                }//end if

                switch (playerWin)
                {
                    case true:
                        if (winLossCount == 1)
                        {
                            currentDialogue.Add(new DialogueData("Warren T. Warden", "WELL DONE my little Butterfly!", _wardenHappy, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Well. That�s it. I'm free now right?", _playerIdleTalking, true));
                            currentDialogue.Add(new DialogueData("Warren T. Warden", "Oh don't be so hasty my darling.", _wardenIdle, false));
                            currentDialogue.Add(new DialogueData("Warren T. Warden", "You just assaulted an officer after all.", _wardenSad, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "What? What are you talking about all I did was beat you in a game?", _playerYeahNoTalking, true));
                            currentDialogue.Add(new DialogueData("Warren T. Warden", "Such a shame too, you could've earned your freedom.", _wardenSad, false));
                            currentDialogue.Add(new DialogueData("Warren T. Warden", "I'll be seeing you around, my little butterfly.", _wardenHappy, false));
                            break;
                        }//end if
                        else if (winLossCount == 2)
                        {
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "That makes two times now, it's about time I got freedom.", _playerIdle, true));
                            currentDialogue.Add(new DialogueData("Warren T. Warden", "GRAH! That, that DIDN'T COUNT!", _wardenSad, false));
                            currentDialogue.Add(new DialogueData("Warren T. Warden", "You CHEATED, I KNOW you did!", _wardenSad, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "...", _playerSad, true));
                            currentDialogue.Add(new DialogueData("Warren T. Warden", "You're getting nothing you little maggot. This is just a fluke.", _wardenIdle, false));
                            currentDialogue.Add(new DialogueData("Warren T. Warden", "Tell you what. If you can beat me one more time, then I'll let you leave.", _wardenHappy, false));
                            break;
                        }//end if
                        else if (winLossCount >= 3)
                        {
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Well. That�s it. GGs, Warenn.", _playerIdleTalking, true));
                            currentDialogue.Add(new DialogueData("Warren T. Warden", "Brat. Spoiled. Entitled little elite. Who do you think you are? Do you really think this will change anything?", _wardenSad, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Yeah. I do. That�s why I did all that.", _playerHappy, true));
                            currentDialogue.Add(new DialogueData("Warren T. Warden", "Hahahaha�wahahahahaha!! YOU�RE SO STUPID! It�s no wonder you�re so stubborn, stupid people usually are!! You have nothing here! NOTHING!! I�M GONNA KILL YOU YOU STUPID-", _wardenHappy, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Your mike�s been hot this whole time, Warenn.", _playerIdle, true));
                            currentDialogue.Add(new DialogueData("Warren T. Warden", "Wh-? What?", _wardenSad, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "The whole world hears you right now. They see just the kind of person you are, and your threats against me. Hope you�re ready to go away for a little bit once this broadcast is over.", _playerIdleTalking, true));
                            currentDialogue.Add(new DialogueData("Warren T. Warden", "Wh-wait, no, that can�t be right! You-.", _wardenSad, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "I think your mike has been live for long enough, though.", _playerHappy, true));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "It�s about time it gets cut.", _playerHappy, true));
                            currentDialogue.Add(new DialogueData("Warren T. Warden", "WAI-", _wardenSad, false));
                            currentDialogue.Add(new DialogueData("Warren T. Warden", "Fzzt�", _wardenSad, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Ahem.", _playerIdle, true));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "To the people of the world, who now hear the outlaw�s plea,", _playerIdleTalking, true));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Jeez, what a snob that guy was. Total pain, both for me, and for a lot of good friends.", _playerYeahNoTalking, true));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "But hey. Looks like he�s finally being shut up.", _playerHappy, true));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Everyone. Spread the world. Let the true nature of Warenn be known, and make his name engraved on all of your minds.", _playerIdleTalking, true));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Clip, share, connect, do all you can. We will be exploited not a moment longer, for we are now free in due time.", _playerIdleTalking, true));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "This has not been an act. The torture, the exhaustion, the impossible nature of the game, the prison life through it all, it�s all been real.", _playerSad, true));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "But thankfully, so too are the people I know here. They�re all real too, and that�s why I got where I am now.", _playerHappy, true));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Connect the dots. Connect the people. Make constellations of us stars, and hear our wish:", _playerIdleTalking, true));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Screw it. If the game doesn�t work, don�t just play it. Break the game.", _playerHappy, true));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "This is Butterfly, signing off.", _playerIdleTalking, true));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Jocelyne is my name forever more.", _playerHappy, true));
                            break;
                        }//end if
                        break;

                    case false:
                        if (winLossCount >= 1)
                        {
                            currentDialogue.Add(new DialogueData("Warren T. Warden", "You CAN�T win! You can�t change this! This is my world!! This is all MINE!!! You were a fool to think you could play this game.", _wardenHappy, false));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "...", _playerSad, true));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "(Nothing to do but fall back for now and try again. Hopefully someone out there heard our message)", _playerSad, true));
                            currentDialogue.Add(new DialogueData("Jocelyne Waybright", "(Run it back)", _playerIdle, true));
                            break;
                        }//end if
                        break;
                }//end switch
                break;//end waren

        }//end switch

        return currentDialogue;
    }//end GetDialogue

}//end DialogueManager
