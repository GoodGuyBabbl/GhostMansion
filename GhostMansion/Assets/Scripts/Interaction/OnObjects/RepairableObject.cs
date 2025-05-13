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

    public int WoodNeeded;
    public int StoneNeeded;
    public int ClothNeeded;
    public int FlowersNeeded;

    public int FramesToBuild;

    private int i = 0;

    private bool StartLongInteract;
    private bool HasTalkedToRoomNPC;
    private bool IsBuildPlot;
    private bool IsRepaired;

    private Interactions Interactions;

    private RoomNPC RoomNPC;

    private Animator PlayerAnimator;

    private SpriteRenderer SpriteRenderer;

    private MaterialHandler MaterialHandler;

    public void Awake()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        Interactions = FindFirstObjectByType<Interactions>();
        RoomNPC = FindFirstObjectByType<RoomNPC>();
        MaterialHandler = FindFirstObjectByType<MaterialHandler>();
        
    }

    public void Start()
    {
        base.Start();
        PlayerAnimator = Player.GetComponent<Animator>();
    }

    public void Update()
    {
        HasTalkedToRoomNPC = RoomNPC.GetHasBeenTalkedTo();

        base.Update();
        LongInteract();
        

    }


    public override void Interact()
    {
        
        //Overlay öffnen, in dem Ressourcenanforderungen dargestellt sind, dann auf "Build" klicken, Overlay schließen
        if(HasTalkedToRoomNPC && !IsRepaired)
        {
            
            if (IsBuildPlot)
            {
                StartLongInteract = true;  
            }
            else //Wenn es noch nicht BuildPlot ist
            {
                //Hier eigentlich: Overlay öffnen, in dem gezeigt wird, wie viele Ressourcen man von was brauch inklusive build button und das nachfolgende ist die logik des buttons
                if (MaterialHandler.HasEnoughResources(WoodNeeded, StoneNeeded, ClothNeeded, FlowersNeeded))
                {
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

                    if(RepairableObjectBackground != null)
                    {
                        RepairableObjectBackground.IsRepaired();
                    }
                    
                    BuildPlotIcon.SetActive(false);
                    PlayerAnimator.SetBool("IsBuilding", false);
                    StartLongInteract = false;

                }
            }
            else if (Interactions.WasInteractReleased)
            {
                PlayerAnimator.SetBool("IsBuilding", false);
                StartLongInteract = false;
                i = 0;
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if (HasTalkedToRoomNPC && !IsRepaired)
        {
            BuildPlotIcon.SetActive(true);
        }       
    }



    public void OnTriggerExit2D(Collider2D collision)
    {
        base.OnTriggerExit2D(collision);
        
        BuildPlotIcon.SetActive(false);
        
    }
}
