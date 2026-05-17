using UnityEngine;

public class AnimationControlScript : MonoBehaviour
{
    //https://www.youtube.com/watch?v=9yFnaLD0PLI
    private float animationTimer;
    public Animator theAnim;

    void Start()
    {
        animationTimer = 0;
        theAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
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

    public void playDesiredAnimation(string animationString, float animationTime)
    {
        animationTimer = animationTime;
        theAnim.Play(animationString);  
        Debug.Log("Animation Test Message");
    }
}
