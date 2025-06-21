using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;


//AKA Wayblocker
public class TreeLog : TriggerInteraction
{
    private float XPlayerAnimationDirection;
    private float YPlayerAnimationDirection;
    private bool StartLongInteract;
    private int i = 0;
    private Interactions Interactions;
    private Animator Animator;
    private Animator PlayerAnimator;
    private MovementDisable MovementDisable;
    private UniqueID UniqueID;
    private float TimePassed;
    private SaveStateManager SaveStateManager;

    public GameObject TreeLogTop;
    public GameObject TreeLogBottom;
    public Vector3 ItemSpawnPoint; //ItemSpawnPointAdditionTo Gameobjects transform.position
    public Progressbar ThisProgressbar; //PB
    public int FramesToMine;
    public int HowManyItemsDropped;
    public GameObject DroppedItem;
    public string PlayerAnimationChangeName; // für Baum IsChopping, also im Player Animator

    private ToolbarControl ToolbarControl;
    private UIManager UIManager;
    public int ToolbarIndexNeeded;





    private void Awake()
    {
        UniqueID = GetComponent<UniqueID>();
        ItemSpawnPoint += GetComponent<PolygonCollider2D>().transform.position;
        Interactions = FindFirstObjectByType<Interactions>();
        Animator = GetComponent<Animator>();
        MovementDisable = FindFirstObjectByType<MovementDisable>();
        SaveStateManager = FindFirstObjectByType<SaveStateManager>();
        UIManager = FindFirstObjectByType<UIManager>();
        ToolbarControl = FindFirstObjectByType<ToolbarControl>();

    }

    public void Start()
    {
        base.Start();
        PlayerAnimator = Player.GetComponent<Animator>();
        if(SaveStateManager.IsObjectChanged(UniqueID.ID))
        {
            if(TreeLogBottom != null)
            {
                TreeLogBottom.SetActive(true);
                TreeLogTop.SetActive(true);
            }
            this.gameObject.SetActive(false);
        }
        
        //Debug.Log(PlayerAnimator);
    }

    public void Update()
    {
        base.Update();
        LongInteract(FramesToMine, HowManyItemsDropped);





    }
    public override void Interact()
    {
        if (UIManager.GetToolCollected(ToolbarIndexNeeded) && ToolbarControl.CurrentIndex == ToolbarIndexNeeded)
        {
            XPlayerAnimationDirection = new Vector2(transform.position.x - Player.transform.position.x, 0).x;
            YPlayerAnimationDirection = new Vector2(0, transform.position.y - Player.transform.position.y).y;
            PlayerAnimator.SetFloat("XAnimationDirection", XPlayerAnimationDirection);
            PlayerAnimator.SetFloat("YAnimationDirection", YPlayerAnimationDirection);
            Debug.Log("Interact");
            StartLongInteract = true;
        }
    }



    public void LongInteract(int FramesToMine, int HowManyItemsDropped)
    {
        if (StartLongInteract)
        {
            Debug.Log("a");
            if (Interactions.GetHolding())
            {
                MovementDisable.DisableMovement();
                PlayerAnimator.SetBool(PlayerAnimationChangeName, true);
                ThisProgressbar.gameObject.transform.parent.gameObject.SetActive(true); //PB
                ThisProgressbar.GetMaximum(FramesToMine); //PB
                ThisProgressbar.SetCurrentFill(i); //PB
                //Animation hier
                i++;
                Debug.Log(i);
                if (i >= FramesToMine)
                {

                    MovementDisable.EnableMovement();
                    ThisProgressbar.gameObject.transform.parent.gameObject.SetActive(false); //PB
                    i = 0;
                    DropItems(HowManyItemsDropped);
                    PlayerAnimator.SetBool(PlayerAnimationChangeName, false);
                    StartLongInteract = false;
                    if (TreeLogBottom != null)
                    {
                        TreeLogBottom.SetActive(true);
                        TreeLogTop.SetActive(true);
                    }
                    SaveStateManager.MarkObjectAsChanged(UniqueID.ID);
                    this.gameObject.SetActive(false);

                    //this.gameObject.SetActive(false);
                }
            }
            else if (Interactions.WasInteractReleased)
            {
                MovementDisable.EnableMovement();
                PlayerAnimator.SetBool(PlayerAnimationChangeName, false);
                StartLongInteract = false;
                ThisProgressbar.gameObject.transform.parent.gameObject.SetActive(false); //PB
                i = 0;
            }
        }
    }



    public void DropItems(int i)
    {
        if (i > 0)
        {
            Instantiate(DroppedItem, ItemSpawnPoint, Quaternion.identity);
            i--;
            DropItems(i);
        }

    }



}
