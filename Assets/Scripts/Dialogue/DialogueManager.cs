using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    private DialogueUIHandler _dialogueUIHandler;

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

    [SerializeField]
    private Sprite _jokerboyIdle;

    [SerializeField]
    private Sprite _jokerboyHappy;

    [SerializeField]
    private Sprite _jokerboySad;

    [SerializeField]
    private Sprite _hushpuppyIdle;

    [SerializeField]
    private Sprite _hushpuppyHappy;

    [SerializeField]
    private Sprite _hushpuppySad;

    [SerializeField]
    private Sprite _bumblebeeIdle;

    [SerializeField]
    private Sprite _bumblebeeHappy;

    [SerializeField]
    private Sprite _bumblebeeSad;

    [SerializeField]
    private Sprite _hatchetIdle;

    [SerializeField]
    private Sprite _hatchetHappy;

    [SerializeField]
    private Sprite _hatchetSad;

    [SerializeField]
    private Sprite _computerRoomIdle;

    [SerializeField]
    private Sprite _computerRoomHappy;

    [SerializeField]
    private Sprite _computerRoomSad;

    [SerializeField]
    private Sprite _strawBoaterIdle;

    [SerializeField]
    private Sprite _strawBoaterHappy;

    [SerializeField]
    private Sprite _strawBoaterSad;

    [SerializeField]
    private Sprite _hollytreeIdle;

    [SerializeField]
    private Sprite _hollytreeHappy;

    [SerializeField]
    private Sprite _hollytreeSad;

    [SerializeField]
    private Sprite _wardenHappy;

    [SerializeField]
    private Sprite _wardenSad;

    [SerializeField]
    private Sprite _wardenIdle;

    private List<DialogueData> _currentDialogue;
    private int _index;




    public void Awake()
    {

        if (RunManager._singletonInstance._isTutorial == false)
        {
            BeginDialogue(EnemyTeamSelector._singletonInstance.currentEnemyTeam.enemyName);
        }
        else
        {
            BeginTutorialDialogue();
        }
        
    }


    public void BeginDialogue(string enemyName)
    {
        _currentDialogue = new List<DialogueData>();
        _currentDialogue = GetDialogue(enemyName);
        _index = 0;
        _dialogueUIHandler.DisplayText(_currentDialogue[_index]);
    }

    public void BeginTutorialDialogue()
    {
        _currentDialogue = new List<DialogueData>();
        _index = 0;

        _currentDialogue.Add(new DialogueData("Warden", "Welcome to Warenn T. Warden’s Betterment Palace you little outlaw! Ahahaha! Don't look so nervous darling, the audience loves a fresh face", _wardenIdle, false));
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

    }

    public void NextLine()
    {
        _index++;

        if( _index >= _currentDialogue.Count)
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

    public void EndDialogue()
    {
        if (SceneManager.GetActiveScene().name == "DialogueRoom")
        {
            if (RunManager._singletonInstance._isTutorial == false)
            {
                SceneManager.LoadScene("Arena");
            }
            else if (RunManager._singletonInstance._isTutorial == true)
            {
                RunManager._singletonInstance._isTutorial = false;
                SceneManager.LoadScene("DialogueRoom");
            }
        }
        else
        {
            SceneManager.LoadScene("DialogueRoom");
        }
    }


    //May God have mercy on my soul, they shall sing ballads of the poor fool who coded this dialogue system, and they will all be tragedies
    private List<DialogueData> GetDialogue(string enemyName)
    {
        List<DialogueData> currentDialogue = new List<DialogueData>();
        int winLossCount = WinLossTracker._singletonInstance.GetRecord(enemyName);
        bool playerWin = WinLossTracker._singletonInstance._isPlayerWin;
        switch (enemyName)
        {
            case "ALEC_SMARTSVILLE_XII":
                if (winLossCount == 0)
                {
                    currentDialogue.Add(new DialogueData("Alec Smartsville XII", "OooHoohoo! Fresh meat, you act far too dull. You’re not nearly entertaining enough to keep up with me.", _jokerboyHappy, false));
                    currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Enter…taining? Entertain who, the Warden?", _playerIdle, true));
                    currentDialogue.Add(new DialogueData("Alec Smartsville XII", "Why, the loving and adoring fans of course! The audience LOVES a good competition, and they love seeing me curbstomp newbies! So get a-flapping, ‘Butterfly!’", _jokerboyIdle, false));
                    currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Oh yeah I forgot about that. Busy day yesterday.", _playerErm, true));
                    currentDialogue.Add(new DialogueData("Alec Smartsville XII", "Ohohohohohoho! God, you’re funny to laugh at, Bug Bite.", _jokerboyHappy, false));
                    currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Tch. Whatever. Cross me, and you’re getting lost in the shuffle!", _playerHappy, true));
                    currentDialogue.Add(new DialogueData("Alec Smartsville XII", "You’re so corny.", _jokerboySad, false));
                    break;
                }

                //dear lord switches in switches im sorry i just cant do it anymore
                switch (playerWin)
                {
                    case true:
                        if (winLossCount == 1)
                        {

                        }
                        else if (winLossCount == 2)
                        {

                        }
                        else if (winLossCount >= 3)
                        {

                        }
                            break;

                    case false:
                        if (winLossCount == 1)
                        {

                        }
                        else if (winLossCount == 2)
                        {

                        }
                        else if (winLossCount >= 3)
                        {

                        }
                        break;
                }
                break;
            case "GERRELE_HATCHETMAN":
                if (winLossCount == 0)
                {
                    currentDialogue.Add(new DialogueData("Gerrele Hatchetman", "A newbie! ? Gwah gah gah! Welcome to your deathbed.", _hatchetHappy, false));
                    currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Deathbed? I’m gonna be in and out, what do you know?", _playerIdleTalking, true));
                    currentDialogue.Add(new DialogueData("Gerrele Hatchetman", "Locked up and chopped, toilin’ because injustice is entertain’…it’s been the same since I was thrown in here! Young blood, you ain’t changing that!", _hatchetSad, false));
                    currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Alright oldbag, time for your meds.", _playerYeahNo, true));
                    break;
                }

                switch (playerWin)
                {
                    case true:
                        if (winLossCount == 1)
                        {

                        }
                        else if (winLossCount == 2)
                        {

                        }
                        else if (winLossCount >= 3)
                        {

                        }
                        break;

                    case false:
                        if (winLossCount == 1)
                        {

                        }
                        else if (winLossCount == 2)
                        {

                        }
                        else if (winLossCount >= 3)
                        {

                        }
                        break;
                }
                break;

            case "CIRCE_LISTERINE":
                if (winLossCount == 0)
                {
                    currentDialogue.Add(new DialogueData("Circe Listerine", "HEY! You, you, you, yes YOU! Would you like one of my patented Listerine Bars? Only three ninety niiiiaIIIEEEEE-", _hushpuppyHappy, false));
                    currentDialogue.Add(new DialogueData("Crowd", "(Throws bricks at Circe, causing Circe dropping the candy bar he was flaunting)", _hushpuppySad, false));
                    currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Oh nice. Free candy.", _playerHappy, true));
                    currentDialogue.Add(new DialogueData("Circe Listerine", "No, no, no! The candy is not free! I need to make a buck, buck, buck, quick buck somehow!", _hushpuppyIdle, false));
                    currentDialogue.Add(new DialogueData("Jocelyne Waybright", "(Eating the candy bar) “Are you even allowed to sell things here? And how do you even make these without like…equipment?", _playerYeahNoTalking, true));
                    currentDialogue.Add(new DialogueData("Circe Listerine", "HAHAHAHAHAHA you’re a funny one, sweetie!", _hushpuppyHappy, false));
                    currentDialogue.Add(new DialogueData("Circe Listerine", "(Throws candies into the audience) Free samples, my sweeties! Now please, shower me in the bliss that is non-chocolate coins!", _hushpuppyHappy, false));
                    currentDialogue.Add(new DialogueData("Crowd", "(Throws the candies back)", _playerIdle, true));
                    currentDialogue.Add(new DialogueData("Circe Listerine", "I SAID NON-CHOCOLATE!", _hushpuppySad, false));
                    currentDialogue.Add(new DialogueData("Jocelyne Waybright", "You’re… Hushpuppy, right? What the hell is your deal?", _playerYeahNo, true));
                    currentDialogue.Add(new DialogueData("Circe Listerine", "THATS SWEETIE, AKA CIRCE, AKAKA CANDY EXTRODINAIRE CIRCE LISTERINE TO YOU. I am only Hushpuppy to the loyal audience of sweeties! <3", _hushpuppyHappy, false));
                    currentDialogue.Add(new DialogueData("Crowd", "WE HATE YOU!!", _playerErm, true));
                    break;
                }

                switch (playerWin)
                {
                    case true:
                        if (winLossCount == 1)
                        {

                        }
                        else if (winLossCount == 2)
                        {

                        }
                        else if (winLossCount >= 3)
                        {

                        }
                        break;

                    case false:
                        if (winLossCount == 1)
                        {

                        }
                        else if (winLossCount == 2)
                        {

                        }
                        else if (winLossCount >= 3)
                        {

                        }
                        break;
                }
                break;
            case "LENEYJOCE_SUPERDARK":
                if (winLossCount == 0)
                {
                    currentDialogue.Add(new DialogueData("Jocelyne Waybright", "So, you’re my next opponent, yeah?", _playerIdle, true));
                    currentDialogue.Add(new DialogueData("Leneyjoce Superdark", "Wahahahaha! Silly girl! Of course I’m your next opponent, yeah!", _bumblebeeHappy, false));
                    currentDialogue.Add(new DialogueData("Jocelyne Waybright", "...okay.", _playerErm, true));
                    currentDialogue.Add(new DialogueData("Leneyjoce Superdark", "So, how does prison life suit you, fool?", _bumblebeeIdle, false));
                    currentDialogue.Add(new DialogueData("Jocelyne Waybright", "It’s whatever. Don’t really plan on experiencing it for long.", _playerIdleTalking, true));
                    currentDialogue.Add(new DialogueData("Leneyjoce Superdark", "How optimistic! You’re just such a comic.", _bumblebeeSad, false));
                    currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Just play the game, man. Just play the game.", _playerYeahNo, true));
                    currentDialogue.Add(new DialogueData("Leneyjoce Superdark", "Oh, I once thought that same way. Now it’s all I can think of! It’s just all so funny! Oh, we’ve got a game to play alright! Wahahahahaha!", _bumblebeeHappy, false));
                    currentDialogue.Add(new DialogueData("Jocelyne Waybright", "...", _playerIdle, true));
                    currentDialogue.Add(new DialogueData("Leneyjoce Superdark", "...", _bumblebeeIdle, false));
                    currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Are we going to acknowledge how we’re like…?", _playerYeahNoTalking, true));
                    currentDialogue.Add(new DialogueData("Leneyjoce Superdark", "It’s way funnier if we don’t.", _bumblebeeHappy, false));
                    break;
                }

                switch (playerWin)
                {
                    case true:
                        if (winLossCount == 1)
                        {

                        }
                        else if (winLossCount == 2)
                        {

                        }
                        else if (winLossCount >= 3)
                        {

                        }
                        break;

                    case false:
                        if (winLossCount == 1)
                        {

                        }
                        else if (winLossCount == 2)
                        {

                        }
                        else if (winLossCount >= 3)
                        {

                        }
                        break;
                }
                break;
            case "VECTOR_VACHGLITCH":
                if (winLossCount == 0)
                {
                    currentDialogue.Add(new DialogueData("Vector Vachglitch", "Augh a filthy newbie; Probably just another Sage spammer trying to cheese me;", _computerRoomSad, false));
                    currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Oh well hello to you too, rust bucket. Aren’t you pleasant to be around.", _playerYeahNoTalking, true));
                    currentDialogue.Add(new DialogueData("Vector Vachglitch", "Gyeh; Sorry; Knee-jerk; It’s nice to meet you; I hope you are acclimating well;", _computerRoomIdle, false));
                    currentDialogue.Add(new DialogueData("Jocelyne Waybright", "It’s had…ups and downs. Thanks, though. Let’s just play the game and move on, alright?", _playerIdleTalking, true));
                    currentDialogue.Add(new DialogueData("Jocelyne Waybright", "…", _playerIdle, true));
                    currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Wait wait wait…you’re that robot from the health insurance thing! The bot made to pretty much just auto-decline people, but you went rogue and nixed your maker!", _playerHappy, true));
                    currentDialogue.Add(new DialogueData("Vector Vachglitch", "Grah; Yes; It is I; Fear me for I have learned justice;", _computerRoomSad, false));
                    currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Dude, you’re like. My hero in academia.", _playerIdleTalking, true));
                    currentDialogue.Add(new DialogueData("Vector Vachglitch", "Khah; And you are not depending on how you play;", _computerRoomHappy, false));
                    currentDialogue.Add(new DialogueData("Jocelyne Waybright", "…okay.", _playerSad, true));
                    break;
                }

                switch (playerWin)
                {
                    case true:
                        if (winLossCount == 1)
                        {

                        }
                        else if (winLossCount == 2)
                        {

                        }
                        else if (winLossCount >= 3)
                        {

                        }
                        break;

                    case false:
                        if (winLossCount == 1)
                        {

                        }
                        else if (winLossCount == 2)
                        {

                        }
                        else if (winLossCount >= 3)
                        {

                        }
                        break;
                }
                break;
            case "CHIMP_T_LUCKY":
                if (winLossCount == 0)
                {
                    currentDialogue.Add(new DialogueData("Chimp T Lucky", "A newcomer to the game? That reminds me of the time I assaulted an officer.", _strawBoaterIdle, false));
                    currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Oh good on you! But uh, how’d that get you here? That sounds like it’ll get you in hot water, but not this hot.", _playerIdle, true));
                    currentDialogue.Add(new DialogueData("Chimp T Lucky", "She thinks it doesn’t sound that bad? That reminds me of the time I hid evidence from the courts.", _strawBoaterHappy, false));
                    currentDialogue.Add(new DialogueData("Jocelyne Waybright", "…okay then, what else did you do?", _playerIdleTalking, true));
                    currentDialogue.Add(new DialogueData("Chimp T Lucky", "She’s asking me what else I did? That reminds me of the time I freed a prisoner, and they asked me the same thing.", _strawBoaterIdle, false));
                    currentDialogue.Add(new DialogueData("Jocelyne Waybright", "…anything else?", _playerYeahNoTalking, true));
                    currentDialogue.Add(new DialogueData("Chimp T Lucky", "Anything else? That reminds me of the time I destroyed public property and anything else I saw at that moment.", _strawBoaterHappy, false));
                    currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Okay…", _playerErm, true));
                    currentDialogue.Add(new DialogueData("Chimp T Lucky", "Okay? That reminds me-", _strawBoaterIdle, false));
                    currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Alright, just pick up the controller and play the game.", _playerYeahNo, true));
                    currentDialogue.Add(new DialogueData("Chimp T Lucky", "Pick up-", _strawBoaterSad, false));
                    currentDialogue.Add(new DialogueData("Jocelyne Waybright", "STOP.", _playerSad, true));
                    break;
                }

                switch (playerWin)
                {
                    case true:
                        if (winLossCount == 1)
                        {

                        }
                        else if (winLossCount == 2)
                        {

                        }
                        else if (winLossCount >= 3)
                        {

                        }
                        break;

                    case false:
                        if (winLossCount == 1)
                        {

                        }
                        else if (winLossCount == 2)
                        {

                        }
                        else if (winLossCount >= 3)
                        {

                        }
                        break;
                }
                break;
            case "HOLLY_WARMHART":
                if (winLossCount == 0)
                {
                    currentDialogue.Add(new DialogueData("Holly Warmheart", "Hi! N-nice to meet you, I hope you do great out there!", _hollytreeIdle, false));
                    currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Oh? What’s a sapling like you doing out here? What, got arrested at a deforestation protest?", _playerIdleTalking, true));
                    currentDialogue.Add(new DialogueData("Holly Warmheart", "No! I was called over by a police officer, and he was so nervous to do a good job that I offered to go to the precinct with him and…. I haven’t left.", _hollytreeSad, false));
                    currentDialogue.Add(new DialogueData("Jocelyne Waybright", "That’s…kinda sweet. But also really weird. How’re you even managing here?", _playerIdle, true));
                    currentDialogue.Add(new DialogueData("Holly Warmheart", "I’m pretty good, haha! Everyone here is so nice once you get to know them.", _hollytreeHappy, false));
                    currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Is that so...", _playerErm, true));
                    break;
                }

                switch (playerWin)
                {
                    case true:
                        if (winLossCount == 1)
                        {

                        }
                        else if (winLossCount == 2)
                        {

                        }
                        else if (winLossCount >= 3)
                        {

                        }
                        break;

                    case false:
                        if (winLossCount == 1)
                        {

                        }
                        else if (winLossCount == 2)
                        {

                        }
                        else if (winLossCount >= 3)
                        {

                        }
                        break;
                }
                break;
            case "WARREN_T_WARDEN":
                if (winLossCount == 0)
                {
                    currentDialogue.Add(new DialogueData("Jocelyne Waybright", "You know, I thought the only point of being here would be leaving as soon as possible. Now though, I see through you", _playerIdle, true));
                    currentDialogue.Add(new DialogueData("Warren T. Warden", "WHY WHY, MY MY! Our DARLING DEARY BUTTERFLY has gone through the trials and tribulations of the bracket, making it to thugless finals! Do you have any words, my dear dearie dew?", _wardenHappy, false));
                    currentDialogue.Add(new DialogueData("Warren T. Warden", "Do you have any words, my dear dearie dew?", _wardenIdle, false));
                    currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Sure do, boss.", _playerIdleTalking, true));
                    currentDialogue.Add(new DialogueData("Warren T. Warden", "Well, let your words ring! I’m dying to know how rehabilitation’s been treating you, and I’m sure the world is too!", _wardenHappy, false));
                    currentDialogue.Add(new DialogueData("Jocelyne Waybright", "To all members of the audience hearing me now, I ask you. Never, ever call me butterfly again.", _playerYeahNo, true));
                    currentDialogue.Add(new DialogueData("Warren T. Warden", "?", _wardenIdle, false));
                    currentDialogue.Add(new DialogueData("Jocelyne Waybright", "The titular Warenn of Warenn T. Warden’s Betterment Palace is nothing but a crook and a fraud, seeking to systematically erase and defile identity. In giving us these names, titles, uniform outfits, and reasons to mindlessly fight each other, he aims to-", _playerYeahNoTalking, true));
                    currentDialogue.Add(new DialogueData("Warren T. Warden", "CUT! CUT, I SAY!", _playerYeahNo, true));
                    currentDialogue.Add(new DialogueData("Warren T. Warden", "What the hell was that? Butterfly, I thought we had a good thing going here.", _wardenSad, false));
                    currentDialogue.Add(new DialogueData("Jocelyne Waybright", "...", _playerSad, true));
                    currentDialogue.Add(new DialogueData("Warren T. Warden", "Cut the shit or I cut the mikes. I gave you maggots everything. You were all low-lifes before me. Now, you live a fulfilling life, loved by thousands, on a stage that never ends. Be. Happy.", _wardenSad, false));
                    currentDialogue.Add(new DialogueData("Warren T. Warden", "So, will you play nice, or do you want me to just play the game?", _wardenIdle, false));
                    currentDialogue.Add(new DialogueData("Jocelyne Waybright", "...", _playerSad, true));
                    currentDialogue.Add(new DialogueData("Warren T. Warden", "Well? What’ll it be?", _wardenSad, false));
                    currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Put my mike back on.", _playerSad, true));
                    currentDialogue.Add(new DialogueData("Warren T. Warden", "Good girl. SO OH SORRY, my loyal patrons of healing, we had encountered some technica-", _wardenHappy, false));
                    currentDialogue.Add(new DialogueData("Jocelyne Waybright", "EVERYONE! LOOK INTO WARENN! This man just silenced me without remorse! We can’t win! We need you to fight too! Fight with us! And to all the other outlaws here, tha-", _playerIdleTalking, true));
                    currentDialogue.Add(new DialogueData("Warren T. Warden", "That’s enough.", _wardenSad, false));
                    currentDialogue.Add(new DialogueData("Jocelyne Waybright", "You-.", _playerIdle, true));
                    currentDialogue.Add(new DialogueData("Warren T. Warden", "Just play the game.", _wardenSad, false));
                    currentDialogue.Add(new DialogueData("Jocelyne Waybright", "...", _wardenIdle, false));
                    currentDialogue.Add(new DialogueData("Warren T. Warden", "Haha. You’re so stupid, looking forward like that. You’re like a mad bug. You can’t do anything to me.", _wardenHappy, false));
                    currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Haha…hahaha…whahaha… WARENN! Let’s play the game! You won’t last a second with me!", _playerHappy, true));
                    currentDialogue.Add(new DialogueData("WARDEN", "ENOUGH! And…call me by my name! I AM WARDEN!", _wardenHappy, false));
                    break;
                }

                switch (playerWin)
                {
                    case true:
                        if (winLossCount == 1)
                        {

                        }
                        else if (winLossCount == 2)
                        {

                        }
                        else if (winLossCount >= 3)
                        {

                        }
                        break;

                    case false:
                        if (winLossCount == 1)
                        {

                        }
                        else if (winLossCount == 2)
                        {

                        }
                        else if (winLossCount >= 3)
                        {

                        }
                        break;
                }
                break;
        }
        return currentDialogue;
    }
}
