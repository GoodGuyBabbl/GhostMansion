using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BuildButton : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    [SerializeField] private Button Button;
    private MaterialHandler MaterialHandler;
    private SaveStateManager SaveStateManager;
    private MovementDisable MovementDisable;

    public RepairableObject RepairableObject;

    public Image Renderer;

    public Sprite CantCraft;
    public Sprite CantCraftHover;
    public Sprite CanCraft;
    public Sprite CanCraftHover;


    public TextMeshProUGUI InInventory1;
    public TextMeshProUGUI InInventory2;
    public TextMeshProUGUI InInventory3;
    public TextMeshProUGUI InInventory4;
    public TextMeshProUGUI InInventory5;
    public TextMeshProUGUI AmountIngredient1;
    public TextMeshProUGUI AmountIngredient2;
    public TextMeshProUGUI AmountIngredient3;
    public TextMeshProUGUI AmountIngredient4;
    public TextMeshProUGUI AmountIngredient5;



    public string Ingredient1;
    public string Ingredient2;
    public string Ingredient3;
    public string Ingredient4;
    public string Ingredient5;
    public int Amount1;
    public int Amount2;
    public int Amount3;
    public int Amount4;
    public int Amount5;
    //public int AmountInInventory1;
    //public int AmountInInventory2;
    //public int AmountInInventory3;
    //public int AmountInInventory4;
    //public int AmountInInventory5;


    private void Awake()
    {
 
        MaterialHandler = FindFirstObjectByType<MaterialHandler>();
        Renderer = GetComponent<Image>();
    }

    private void Start()
    {
        MovementDisable = FindFirstObjectByType<MovementDisable>();
        SaveStateManager = FindFirstObjectByType<SaveStateManager>();
    }


    private void OnEnable()
    {
        if(Ingredient1 != "Nothing")
        {
            InInventory1.text = MaterialHandler.GetResourceCount(Ingredient1).ToString();
            AmountIngredient1.text = Amount1.ToString();
        }
        if (Ingredient2 != "Nothing")
        {
            InInventory2.text = MaterialHandler.GetResourceCount(Ingredient2).ToString();
            AmountIngredient2.text = Amount2.ToString();
        }
        if (Ingredient3 != "Nothing")
        {
            InInventory3.text = MaterialHandler.GetResourceCount(Ingredient3).ToString();
            AmountIngredient3.text = Amount3.ToString();
        }
        if (Ingredient4 != "Nothing")
        {
            InInventory4.text = MaterialHandler.GetResourceCount(Ingredient4).ToString();
            AmountIngredient4.text = Amount4.ToString();
        }
        if (Ingredient5 != "Nothing")
        {
            InInventory5.text = MaterialHandler.GetResourceCount(Ingredient5).ToString();
            AmountIngredient5.text = Amount5.ToString();
        }










        if (MaterialHandler.HasEnoughResources(Ingredient1, Amount1, Ingredient2, Amount2, Ingredient3, Amount3, Ingredient4, Amount4, Ingredient5, Amount5))
        {
            Renderer.sprite = CanCraft;
        }
        else
        {
            Renderer.sprite = CantCraft;
        }
    }

    public void SelectButton()
    {
        StartCoroutine(DelayedSelect());
    }

    private IEnumerator DelayedSelect()
    {
        yield return null;
        Button.Select();
    }

    public void OnSelect(BaseEventData eventData)
    {

        if (MaterialHandler.HasEnoughResources(Ingredient1, Amount1, Ingredient2, Amount2, Ingredient3, Amount3, Ingredient4, Amount4, Ingredient5, Amount5))
        {
            Renderer.sprite = CanCraftHover;
        }
        else
        {
            Renderer.sprite = CantCraftHover;
        }
    }
    public void OnDeselect(BaseEventData eventData)
    {
        if (MaterialHandler.HasEnoughResources(Ingredient1, Amount1, Ingredient2, Amount2, Ingredient3, Amount3, Ingredient4, Amount4, Ingredient5, Amount5))
        {
            Renderer.sprite = CanCraft;
        }
        else
        {
            Renderer.sprite = CantCraft;
        }
    }
    public void OnClick()
    {
        if (Renderer.sprite == CanCraftHover)
        {
            MaterialHandler.DecreaseResourceCount(Ingredient1, Amount1);
            MaterialHandler.DecreaseResourceCount(Ingredient2, Amount2);
            MaterialHandler.DecreaseResourceCount(Ingredient3, Amount3);
            MaterialHandler.DecreaseResourceCount(Ingredient4, Amount4);
            MaterialHandler.DecreaseResourceCount(Ingredient5, Amount5);
            SaveStateManager.MarkAsBuildPlot(RepairableObject.UniqueID.ID);
            RepairableObject.SpriteRenderer.sprite = RepairableObject.BuildPlot;
            RepairableObject.GreyVersionCollider.gameObject.SetActive(false);
            RepairableObject.BuildPlotCollider.gameObject.SetActive(true);
            RepairableObject.IsBuildPlot = true;
            MovementDisable.EnableMovement();
            transform.parent.gameObject.SetActive(false);

        }
    }




}

