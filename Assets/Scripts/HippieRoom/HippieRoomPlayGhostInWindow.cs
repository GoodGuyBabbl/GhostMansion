using System.Collections;
using UnityEngine;

public class HippieRoomPlayGhostInWindow : MonoBehaviour 
{
    private Animator Animator;
    public string Trigger = "PlayGhost";

    void Start()
    {
        Animator = GetComponent<Animator>();
        Animator.SetTrigger(Trigger);
        StartCoroutine(WaitAndPlayAgain());
        Debug.Log("test");
    }



    private IEnumerator WaitAndPlayAgain()
    {
        Debug.Log("Playing");
        yield return new WaitForSeconds(25f);
        Animator.SetTrigger(Trigger);
        StartCoroutine(WaitAndPlayAgain());
    }
}
