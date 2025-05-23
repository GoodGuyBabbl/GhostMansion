using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class RegrowingResource : TriggerInteraction
{
    private float XPlayerAnimationDirection;
    private float YPlayerAnimationDirection;
    private bool StartLongInteract;
    private int i = 0;
    private Interactions Interactions;
    private Animator Animator;
    private Animator PlayerAnimator;
    private MovementDisable MovementDisable;
    


    public Vector3 ItemSpawnPoint; //ItemSpawnPointAdditionTo Gameobjects transform.position
    public int FramesToMine;
    public int HowManyItemsDropped;
    public GameObject DroppedItem;
    public string AnimationChangeName; //beim Baum IsChopped, also für das jeweilige objekt
    public string PlayerAnimationChangeName; // für Baum IsChopping, also im Player Animator
    


    private void Awake()
    {
        ItemSpawnPoint += transform.position;
        Interactions = FindFirstObjectByType<Interactions>();
        Animator = GetComponent<Animator>();
        MovementDisable = FindFirstObjectByType<MovementDisable>();

    }

    public void Start()
    {
        base.Start();
        PlayerAnimator = Player.GetComponent<Animator>();
        Debug.Log(PlayerAnimator);
    }

    public void Update()
    {
        base.Update();
        LongInteract(FramesToMine, HowManyItemsDropped);
    }
    public override void Interact()
    {
        XPlayerAnimationDirection = new Vector2(transform.position.x - Player.transform.position.x, 0).x;
        YPlayerAnimationDirection = new Vector2(0,transform.position.y - Player.transform.position.y ).y;
        PlayerAnimator.SetFloat("XAnimationDirection", XPlayerAnimationDirection);
        PlayerAnimator.SetFloat("YAnimationDirection", YPlayerAnimationDirection);
        Debug.Log("Interact");
        StartLongInteract = true;
    }



    public void LongInteract(int FramesToMine, int HowManyItemsDropped)
    {
        if (StartLongInteract)
        {
            Debug.Log("a");
            if (Interactions.GetHolding() && Animator.GetBool(AnimationChangeName) == false)
            {
                MovementDisable.DisableMovement();
                PlayerAnimator.SetBool(PlayerAnimationChangeName, true);
                //Animation hier
                i++;
                Debug.Log(i);
                if (i >= FramesToMine)
                {

                    MovementDisable.EnableMovement();
                    Animator.SetBool(AnimationChangeName, true);
                    i = 0;
                    DropItems(HowManyItemsDropped);
                    PlayerAnimator.SetBool(PlayerAnimationChangeName, false);
                    StartLongInteract = false;


                    //this.gameObject.SetActive(false);
                }
            }
            else if (Interactions.WasInteractReleased)
            {
                MovementDisable.EnableMovement();
                PlayerAnimator.SetBool(PlayerAnimationChangeName, false);
                StartLongInteract = false;
                i = 0;
            }
        }
    }

    public void DropItems(int i)
    {
        if(i > 0)
        {
            Instantiate(DroppedItem, ItemSpawnPoint, Quaternion.identity);
            i--;
            DropItems(i);
        }
        
    }



}
