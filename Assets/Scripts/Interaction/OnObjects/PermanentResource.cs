using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
public class PermanentResource : TriggerInteraction
{
    private float XPlayerAnimationDirection;
    private float YPlayerAnimationDirection;
    private bool StartLongInteract;
    private int i = 0;
    private Interactions Interactions;
    private Animator PlayerAnimator;
    private MovementDisable MovementDisable;
    private float TimePassed;

    private ToolbarControl ToolbarControl;
    private UIManager UIManager;
    public int ToolbarIndexNeeded; //0 Pickaxe, 1 Axe, 2 Watering Can...

    public string UniqueID;
    private UniqueID IDManager;
    public SaveStateManager SaveStateManager;


    public Vector3 ItemSpawnPoint; //ItemSpawnPoint Addition To Gameobject's transform.position
    public Progressbar ThisProgressbar; //PB
    public int FramesToMine;
    public int HowManyItemsDropped;
    public GameObject DroppedItem;
    public string PlayerAnimationChangeName; // für Baum IsChopping, im Player Animator





    private void Awake()
    {
        ItemSpawnPoint += transform.position;
        Interactions = FindFirstObjectByType<Interactions>();
        MovementDisable = FindFirstObjectByType<MovementDisable>();
        UIManager = FindFirstObjectByType<UIManager>();
        ToolbarControl = FindFirstObjectByType<ToolbarControl>();

    }

    public void Start()
    {
        base.Start();
        PlayerAnimator = Player.GetComponent<Animator>();
        SaveStateManager = FindFirstObjectByType<SaveStateManager>();
        IDManager = GetComponent<UniqueID>();
        UniqueID = IDManager.ID;
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
                    SaveStateManager.Instance.MarkResourceAsMined(UniqueID);//Eigentlich unnötig
                    ThisProgressbar.gameObject.transform.parent.gameObject.SetActive(false); //PB
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
                ThisProgressbar.gameObject.transform.parent.gameObject.SetActive(false); //PB
                StartLongInteract = false;
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
