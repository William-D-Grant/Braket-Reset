

//added isPlayerTalking to handle sprite updating better
using UnityEngine;

public class DialogueData
{
    public string talkingName;

    public string dialogueline;

    public Sprite talkingSprite;

    public bool isPlayerTalking;


    public DialogueData(string whoIsTalking, string line, Sprite sprite, bool isPlayerDialogue)
    {
        talkingName = whoIsTalking;

        dialogueline = line;

        talkingSprite = sprite; 

        isPlayerTalking = isPlayerDialogue;
    }//end DialgoueData constructor

}//end DialogueData
