using UnityEngine;

public class RepairableObject : TriggerInteraction
{
    public GameObject BuildPlotIcon;

    public RepairableObjectBackground RepairableObjectBackground;

    public Sprite BuildPlot;
    public Sprite ColoredVersion;

    public Collider2D GreyVersionCollider;
    public Collider2D BuildPlotCollider;
    public Collider2D ColoredVersionCollider;

    public string Resource1;
    public string Resource2;
    public string Resource3;
    public string Resource4;
    public string Resource5;

    public int Amount1;
    public int Amount2;
    public int Amount3;
    public int Amount4;
    public int Amount5;

    public int FramesToBuild;

    private int i = 0;

    private float XPlayerAnimationDirection;
    private float YPlayerAnimationDirection;
    private bool StartLongInteract;
    private bool IsRepairEnabled;
    private bool IsBuildPlot;

    public bool IsRepaired;

    private MovementDisable MovementDisable;

    private Interactions Interactions;

    private RoomNPC RoomNPC;

    private Animator PlayerAnimator;

    private SpriteRenderer SpriteRenderer;

    private MaterialHandler MaterialHandler;

    private ColorChangeController ColorChangeController;

    private SaveStateManager SaveStateManager;

    private UniqueID UniqueID;

    public void Awake()
    {
        MovementDisable = FindFirstObjectByType<MovementDisable>();
        SaveStateManager = FindFirstObjectByType<SaveStateManager>();
        UniqueID = GetComponent<UniqueID>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        Interactions = FindFirstObjectByType<Interactions>();
        RoomNPC = FindFirstObjectByType<RoomNPC>();
        MaterialHandler = FindFirstObjectByType<MaterialHandler>();
        ColorChangeController = FindFirstObjectByType<ColorChangeController>(); 
        
    }

    public void Start()
    {
        base.Start();
        PlayerAnimator = Player.GetComponent<Animator>();
        if (SaveStateManager.IsBuildPlot(UniqueID.ID))
        {
            SpriteRenderer.sprite = BuildPlot;
            GreyVersionCollider.gameObject.SetActive(false);
            BuildPlotCollider.gameObject.SetActive(true);
            IsBuildPlot = true;
        }else if (SaveStateManager.IsFurnitureRepaired(UniqueID.ID))
        {
            IsRepaired = true;
            SpriteRenderer.sprite = ColoredVersion;
            GreyVersionCollider.gameObject.SetActive(false);
            BuildPlotCollider.gameObject.SetActive(false);
            ColoredVersionCollider.gameObject.SetActive(true);
            if (RepairableObjectBackground != null)
            {
                RepairableObjectBackground.IsRepaired();
            }
        }

    }

    public void Update()
    {
        IsRepairEnabled = RoomNPC.GetIsRepairEnabled();

        base.Update();
        LongInteract();
        

    }


    public override void Interact()
    {
        XPlayerAnimationDirection = new Vector2(transform.position.x - Player.transform.position.x, 0).x;
        YPlayerAnimationDirection = new Vector2(0, transform.position.y - Player.transform.position.y).y;
        PlayerAnimator.SetFloat("XAnimationDirection", XPlayerAnimationDirection);
        PlayerAnimator.SetFloat("YAnimationDirection", YPlayerAnimationDirection);

        //Overlay öffnen, in dem Ressourcenanforderungen dargestellt sind, dann auf "Build" klicken, Overlay schließen
        if (IsRepairEnabled && !IsRepaired)
        {
            
            if (IsBuildPlot)
            {
                StartLongInteract = true;  
            }
            else //Wenn es noch nicht BuildPlot ist
            {
                //Hier eigentlich: Overlay öffnen, in dem gezeigt wird, wie viele Ressourcen man von was brauch inklusive build button und das nachfolgende ist die logik des buttons
                if (MaterialHandler.HasEnoughResources(Resource1, Amount1, Resource2, Amount2, Resource3, Amount3, Resource4, Amount4, Resource5, Amount5))
                {
                    SaveStateManager.MarkAsBuildPlot(UniqueID.ID);
                    SpriteRenderer.sprite = BuildPlot;
                    GreyVersionCollider.gameObject.SetActive(false);
                    BuildPlotCollider.gameObject.SetActive(true);
                    IsBuildPlot = true;
                }
                else
                {
                    Debug.Log("Nicht genug Ressourcen");
                }
                
            }
        }
    }


    public void LongInteract()
    {
        if (StartLongInteract)
        {

            if (Interactions.GetHolding())
            {
                MovementDisable.DisableMovement();
                PlayerAnimator.SetBool("IsBuilding", true);
                i++;
                //Debug.Log(i);
                if (i >= FramesToBuild)
                {
                    IsRepaired = true;
                    i = 0;
                    SpriteRenderer.sprite = ColoredVersion;
                    BuildPlotCollider.gameObject.SetActive(false);
                    ColoredVersionCollider.gameObject.SetActive(true);

                    ColorChangeController.IncrementRepairedObjects(); //Start Color Change in Room
                    ColorChangeController.CheckColorChange();   

                    //SaveStateManager
                    SaveStateManager.RemoveFromBuildPlot(UniqueID.ID);  
                    SaveStateManager.MarkAsRepaired(UniqueID.ID);

                    if(RepairableObjectBackground != null)
                    {
                        RepairableObjectBackground.IsRepaired();
                    }
                    
                    BuildPlotIcon.SetActive(false);
                    PlayerAnimator.SetBool("IsBuilding", false);
                    StartLongInteract = false;
                    MovementDisable.EnableMovement();

                }
            }
            else if (Interactions.WasInteractReleased)
            {
                MovementDisable.EnableMovement();
                PlayerAnimator.SetBool("IsBuilding", false);
                StartLongInteract = false;
                i = 0;
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        Debug.Log("works");
        if (IsRepairEnabled && !IsRepaired)
        {
            BuildPlotIcon.SetActive(true);
        }       
    }



    public void OnTriggerExit2D(Collider2D collision)
    {
        base.OnTriggerExit2D(collision);
        
        if(BuildPlotIcon != null && BuildPlotIcon.activeSelf )
        {
            BuildPlotIcon.SetActive(false);
        }

        
    }
}
