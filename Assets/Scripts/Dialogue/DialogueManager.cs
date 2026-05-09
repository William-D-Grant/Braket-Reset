using UnityEngine;
using System.Collections.Generic;
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
    private Sprite _playerWappy;

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

    private List<DialogueData> _currentDialogue;
    private int _index;

    public void BeginDialogue(string enemyName)
    {
        _currentDialogue = new List<DialogueData>();
        _currentDialogue = GetDialogue(enemyName);
        _index = 0;
        _dialogueUIHandler.DisplayText(_currentDialogue[_index]);
    }

    public void NextLine()
    {
        _index++;

        if( _index >= _currentDialogue.Count)
        {
            EndDialogue();
            return;
        }

        _dialogueUIHandler.DisplayText( _currentDialogue[_index]);
    }

    public void EndDialogue()
    {
        SceneManager.LoadScene("Arena");
    }

    private List<DialogueData> GetDialogue(string enemyName)
    {
        List<DialogueData> currentDialogue = new List<DialogueData>();

        switch (enemyName)
        {
            case "ALEC_SMARTSVILLE_XII":

                currentDialogue.Add(new DialogueData("Alec Smartsville XII", "OooHoohoo! Fresh meat, you act far too dull. You’re not nearly entertaining enough to keep up with me.", _jokerboyHappy, false));
                currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Enter…taining? Entertain who, the Warden?", _playerIdle, true));
                currentDialogue.Add(new DialogueData("Alec Smartsville XII", "Why, the loving and adoring fans of course! The audience LOVES a good competition, and they love seeing me curbstomp newbies! So get a-flapping, ‘Butterfly!’", _jokerboyIdle, false));
                currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Oh yeah I forgot about that. Busy day yesterday.", _playerSad, true));
                currentDialogue.Add(new DialogueData("Alec Smartsville XII", "Ohohohohohoho! God, you’re funny to laugh at, Bug Bite.", _jokerboyHappy, false));
                currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Tch. Whatever. Cross me, and you’re getting lost in the shuffle!", _playerHappy, true));
                currentDialogue.Add(new DialogueData("Alec Smartsville XII", "You’re so corny.", _jokerboySad, false));

                break;

            case "GERRELE_HATCHETMAN":
                currentDialogue.Add(new DialogueData("Gerrele Hatchetman", "A newbie! ? Gwah gah gah! Welcome to your deathbed.", _hatchetHappy, false));
                currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Deathbed? I’m gonna be in and out, what do you know?", _playerHappy, true));
                currentDialogue.Add(new DialogueData("Gerrele Hatchetman", "Locked up and chopped, toilin’ because injustice is entertain’…it’s been the same since I was thrown in here! Young blood, you ain’t changing that!", _hatchetSad, false));
                currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Alright oldbag, time for your meds.", _playerIdle, true));
                break;

            case "CIRCE_LISTERINE":
                currentDialogue.Add(new DialogueData("Circe Listerine", "HEY! You, you, you, yes YOU! Would you like one of my patented Listerine Bars? Only three ninety niiiiaIIIEEEEE-", _hushpuppyHappy, false));
                currentDialogue.Add(new DialogueData("Crowd", "(Throws bricks at Circe, causing Circe dropping the candy bar he was flaunting)", _hushpuppySad, false));
                currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Oh nice. Free candy.", _playerHappy, true));
                currentDialogue.Add(new DialogueData("Circe Listerine", "No, no, no! The candy is not free! I need to make a buck, buck, buck, quick buck somehow!", _hushpuppyIdle, false));
                currentDialogue.Add(new DialogueData("Jocelyne Waybright", "(Eating the candy bar) “Are you even allowed to sell things here? And how do you even make these without like…equipment?", _playerIdle, true));
                currentDialogue.Add(new DialogueData("Circe Listerine", "HAHAHAHAHAHA you’re a funny one, sweetie!", _hushpuppyHappy, false));
                currentDialogue.Add(new DialogueData("Circe Listerine", "(Throws candies into the audience) Free samples, my sweeties! Now please, shower me in the bliss that is non-chocolate coins!", _hushpuppyHappy, false));
                currentDialogue.Add(new DialogueData("Crowd", "(Throws the candies back)", _playerIdle, true));
                currentDialogue.Add(new DialogueData("Circe Listerine", "I SAID NON-CHOCOLATE!", _hushpuppySad, false));
                currentDialogue.Add(new DialogueData("Jocelyne Waybright", "You’re… Hushpuppy, right? What the hell is your deal?", _playerSad, true));
                currentDialogue.Add(new DialogueData("Circe Listerine", "THATS SWEETIE, AKA CIRCE, AKAKA CANDY EXTRODINAIRE CIRCE LISTERINE TO YOU. I am only Hushpuppy to the loyal audience of sweeties! <3", _hushpuppyHappy, false));
                currentDialogue.Add(new DialogueData("Crowd", "WE HATE YOU!!", _playerHappy, true));
                break;

            case "LENEYJOCE_SUPERDARK":
                currentDialogue.Add(new DialogueData("Jocelyne Waybright", "So, you’re my next opponent, yeah?", _playerIdle, true));
                currentDialogue.Add(new DialogueData("Leneyjoce Superdark", "Wahahahaha! Silly girl! Of course I’m your next opponent, yeah!", _bumblebeeHappy, false));
                currentDialogue.Add(new DialogueData("Jocelyne Waybright", "...okay.", _playerIdle, true));
                currentDialogue.Add(new DialogueData("Leneyjoce Superdark", "So, how does prison life suit you, fool?", _bumblebeeIdle, false));
                currentDialogue.Add(new DialogueData("Jocelyne Waybright", "It’s whatever. Don’t really plan on experiencing it for long.", _playerSad, true));
                currentDialogue.Add(new DialogueData("Leneyjoce Superdark", "How optimistic! You’re just such a comic.", _bumblebeeSad, false));
                currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Just play the game, man. Just play the game.", _playerSad, true));
                currentDialogue.Add(new DialogueData("Leneyjoce Superdark", "Oh, I once thought that same way. Now it’s all I can think of! It’s just all so funny! Oh, we’ve got a game to play alright! Wahahahahaha!", _bumblebeeHappy, false));
                currentDialogue.Add(new DialogueData("Jocelyne Waybright", "...", _playerIdle, true));
                currentDialogue.Add(new DialogueData("Leneyjoce Superdark", "...", _bumblebeeIdle, false));
                currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Are we going to acknowledge how we’re like…?", _playerHappy, true));
                currentDialogue.Add(new DialogueData("Leneyjoce Superdark", "It’s way funnier if we don’t.", _bumblebeeHappy, false));
                break;

            case "VECTOR_VACHGLITCH":
                currentDialogue.Add(new DialogueData("Vector Vachglitch", "Augh a filthy newbie; Probably just another Sage spammer trying to cheese me;", _playerIdle, true));

                currentDialogue.Add(new DialogueData("Vector Vachglitch", "Gyeh; Sorry; Knee-jerk; It’s nice to meet you; I hope you are acclimating well;", _playerIdle, true));


                currentDialogue.Add(new DialogueData("Vector Vachglitch", "Grah; Yes; It is I; Fear me for I have learned justice;", _playerIdle, true));

                currentDialogue.Add(new DialogueData("Vector Vachglitch", "Khah; And you are not depending on how you play;", _playerIdle, true));

                break;

            case "CHIMP_T_LUCKY":

                break;

            case "HOLLY_WARMHART":
                currentDialogue.Add(new DialogueData("Holly Warmheart", "Hi! N-nice to meet you, I hope you do great out there!", _hollytreeIdle, false));
                currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Oh? What’s a sapling like you doing out here? What, got arrested at a deforestation protest?", _playerIdle, true));
                currentDialogue.Add(new DialogueData("Holly Warmheart", "No! I was called over by a police officer, and he was so nervous to do a good job that I offered to go to the precinct with him and…. I haven’t left.", _hollytreeSad, false));
                currentDialogue.Add(new DialogueData("Jocelyne Waybright", "That’s…kinda sweet. But also really weird. How’re you even managing here?", _playerHappy, true));
                currentDialogue.Add(new DialogueData("Holly Warmheart", "I’m pretty good, haha! Everyone here is so nice once you get to know them.", _hollytreeHappy, false));
                currentDialogue.Add(new DialogueData("Jocelyne Waybright", "Is that so...", _playerIdle, true));
                break;
        }

        return currentDialogue;
    }
}
