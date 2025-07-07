using UnityEngine;

public class RepairableObject : TriggerInteraction
{
    public GameObject BuildPlotIcon;
    public GameObject BuildplotOverlay;

    public RepairableObjectBackground RepairableObjectBackground;

    public Sprite BuildPlot;
    public Sprite ColoredVersion;

    public Collider2D GreyVersionCollider;
    public Collider2D BuildPlotCollider;
    public Collider2D ColoredVersionCollider;

    public UniqueID UniqueID;

    public SpriteRenderer SpriteRenderer;

    public BuildButton FirstActiveButton;

    public Progressbar ThisProgressbar; //PB

    //public string Resource1;
    //public string Resource2;
    //public string Resource3;
    //public string Resource4;
    //public string Resource5;

    //public int Amount1;
    //public int Amount2;
    //public int Amount3;
    //public int Amount4;
    //public int Amount5;

    public int FramesToBuild;
    public int ToolbarIndexNeeded = 4;

    private int i = 0;

    private float XPlayerAnimationDirection;
    private float YPlayerAnimationDirection;
    private bool StartLongInteract;
    private bool IsRepairEnabled;

    public bool IsBuildPlot;
    public bool IsRepaired;

    private MovementDisable MovementDisable;

    private Interactions Interactions;

    private RoomNPC RoomNPC;

    private Animator PlayerAnimator;

    //private MaterialHandler MaterialHandler;

    private ColorChangeController ColorChangeController;

    private SaveStateManager SaveStateManager;

    private ToolbarControl ToolbarControl;

    private UIManager UIManager;

    public AK.Wwise.Event Build;
    public AK.Wwise.Event Colored;
    private bool buildSound;

    public void Awake()
    {
        MovementDisable = FindFirstObjectByType<MovementDisable>();
        SaveStateManager = FindFirstObjectByType<SaveStateManager>();
        UniqueID = GetComponent<UniqueID>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        Interactions = FindFirstObjectByType<Interactions>();
        RoomNPC = FindFirstObjectByType<RoomNPC>();
        //MaterialHandler = FindFirstObjectByType<MaterialHandler>();
        ColorChangeController = FindFirstObjectByType<ColorChangeController>(); 
        
    }

    public void Start()
    {
        base.Start();
        UIManager = FindFirstObjectByType<UIManager>();
        ToolbarControl = FindFirstObjectByType<ToolbarControl>();
        PlayerAnimator = Player.GetComponent<Animator>();
        if (SaveStateManager.IsBuildPlot(UniqueID.ID))
        {
            SpriteRenderer.sprite = BuildPlot;
            GreyVersionCollider.gameObject.SetActive(false);
            BuildPlotCollider.gameObject.SetActive(true);
            IsBuildPlot = true;
        }else if (SaveStateManager.IsFurnitureRepaired(UniqueID.ID))
        {
            Colored.Post(gameObject);
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
                if(UIManager.GetToolCollected(ToolbarIndexNeeded) && ToolbarControl.CurrentIndex == ToolbarIndexNeeded)
                {
                    StartLongInteract = true;
                    buildSound = true;
                }

            }
            else if(!UIManager.IsOverlayActive()) //Wenn es noch nicht BuildPlot ist
            {

                MovementDisable.DisableMovement();
                BuildplotOverlay.SetActive(true);
                UIManager.AddActiveOverlay("Buildplot");
                FirstActiveButton.SelectButton();
                //Hier eigentlich: Overlay öffnen, in dem gezeigt wird, wie viele Ressourcen man von was brauch inklusive build button und das nachfolgende ist die logik des buttons
                //if (MaterialHandler.HasEnoughResources(Resource1, Amount1, Resource2, Amount2, Resource3, Amount3, Resource4, Amount4, Resource5, Amount5))
                //{
                //    SaveStateManager.MarkAsBuildPlot(UniqueID.ID);
                //    SpriteRenderer.sprite = BuildPlot;
                //    GreyVersionCollider.gameObject.SetActive(false);
                //    BuildPlotCollider.gameObject.SetActive(true);
                //    IsBuildPlot = true;
                //}


            }
        }
    }


    public void LongInteract()
    {
        if (StartLongInteract)
        {
            
            if (Interactions.GetHolding())
            {
                if (buildSound)
                {
                    Build.Post(gameObject);
                    buildSound = false;
                }
                MovementDisable.DisableMovement();
                PlayerAnimator.SetBool("IsBuilding", true);
                ThisProgressbar.gameObject.transform.parent.gameObject.SetActive(true); //PB
                ThisProgressbar.GetMaximum(FramesToBuild); //PB
                ThisProgressbar.SetCurrentFill(i); //PB
                i++;
                //Debug.Log(i);
                if (i >= FramesToBuild)
                {
                    IsRepaired = true;
                    ThisProgressbar.gameObject.transform.parent.gameObject.SetActive(false); //PB
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
                Build.Stop(gameObject);
                ThisProgressbar.gameObject.transform.parent.gameObject.SetActive(false); //PB
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
