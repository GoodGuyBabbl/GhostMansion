using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System.Collections;
using Unity.VisualScripting;



public class CraftButton : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    [Header("Components")]
    [SerializeField] private Button Button;


    public Vector3 ItemSpawnPoint;

    public Image Renderer;

    private MaterialHandler MaterialHandler;

    public GameObject DroppedItem;

    public Sprite CantCraft;
    public Sprite CantCraftHover;
    public Sprite CanCraft;
    public Sprite CanCraftHover;

    public TextMeshProUGUI IngredientField;//Textfeld Eingangsressourcen
    public TextMeshProUGUI ResultField;//Textfeld Endressourcen
    public TextMeshProUGUI InInventoryField;//Textfeld Spieler hat wie viele im Inventar
    public TextMeshProUGUI IngredientField2;
    public TextMeshProUGUI InInventoryField2;


    public int DisplayedAmountIngredient; //Welche Zahl steht für die Eingangsressourcen im Textfeld
    public int DisplayedAmountResult;//Welche Zahl steht für die Endressourcen im Textfeld
    public int DisplayedAmountInInventory;//Welche Zahl steht für die Ressourcen im Inventar im Textfeld
    public int DisplayedAmountIngredient2; 
    public int DisplayedAmountInInventory2;

    //NeededIngredients
    public string CraftedResource; //Welche Ressource wird hergestellt
    public string Ingredient1;
    public string Ingredient2;
    public string Ingredient3;
    public string Ingredient4;
    public string Ingredient5;
    //NeededAmounts
    public int Amount1; //Wie viel von Ingredientx braucht es zum herstellen für 1 Endressource
    public int Amount2; //""
    public int Amount3; //""
    public int Amount4; //""
    public int Amount5; //""


    private void Awake()
    {
        MaterialHandler = FindFirstObjectByType<MaterialHandler>();
        Renderer = GetComponent<Image>();
        //RoomNpc = FindFirstObjectByType<RoomNPC>();
    }

    private void OnEnable()
    {
        DisplayedAmountIngredient = Amount1;
        DisplayedAmountIngredient2 = Amount2;
        DisplayedAmountInInventory = MaterialHandler.GetResourceCount(Ingredient1);
        DisplayedAmountInInventory2 = MaterialHandler.GetResourceCount(Ingredient2);
        DisplayedAmountResult = 1;
        UpdateNumbers();

        if (MaterialHandler.HasEnoughResources(Ingredient1, DisplayedAmountIngredient, Ingredient2, DisplayedAmountIngredient2, Ingredient3, Amount3, Ingredient4, Amount4, Ingredient5, Amount5))
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
        //Das alles in "CheckButtonState oder CheckButtonColor", um es nach dem buttonclick, also dem craften, wieder aufrufen zu können. Sonst muss man den button neu anwählen/abwählen, damit er checkt, dass nach dem craften nicht mehr genug ressourcen da sind.
        if(MaterialHandler.HasEnoughResources(Ingredient1, DisplayedAmountIngredient, Ingredient2, DisplayedAmountIngredient2, Ingredient3, Amount3, Ingredient4, Amount4, Ingredient5, Amount5))
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
        if (MaterialHandler.HasEnoughResources(Ingredient1, DisplayedAmountIngredient, Ingredient2, DisplayedAmountIngredient2, Ingredient3, Amount3, Ingredient4, Amount4, Ingredient5, Amount5))
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
        if(Renderer.sprite == CanCraftHover)
        {
            //Debug.Log("1");
            //MaterialHandler.IncreaseResourceCount(CraftedResource, DisplayedAmountResult);
            DropItems(DisplayedAmountResult);
            MaterialHandler.DecreaseResourceCount(Ingredient1, DisplayedAmountIngredient);
            if(Ingredient2 != "Nothing")
            {
                //Debug.Log("2");
                MaterialHandler.DecreaseResourceCount(Ingredient2, DisplayedAmountIngredient2);
            }
            //Debug.Log("3");
            UpdateNumbers();
            if (MaterialHandler.HasEnoughResources(Ingredient1, DisplayedAmountIngredient, Ingredient2, DisplayedAmountIngredient2, Ingredient3, Amount3, Ingredient4, Amount4, Ingredient5, Amount5))
            {
                //Debug.Log("4");
                Renderer.sprite = CanCraftHover;
            }
            else
            {
                Renderer.sprite = CantCraftHover;
            }
            //Debug.Log("Plus " + DisplayedAmountResult + " " + Ingredient1);
        }
    }

    public void UpdateNumbers()
    {
        DisplayedAmountInInventory = MaterialHandler.GetResourceCount(Ingredient1);
        DisplayedAmountIngredient = DisplayedAmountResult * Amount1;
        DisplayedAmountInInventory2 = MaterialHandler.GetResourceCount(Ingredient2);
        DisplayedAmountIngredient2 = DisplayedAmountResult * Amount2;
        if(IngredientField2)
        {
            IngredientField2.text = DisplayedAmountIngredient2.ToString();
            InInventoryField2.text = DisplayedAmountInInventory2.ToString();
        }
        if(IngredientField)
        {
            IngredientField.text = DisplayedAmountIngredient.ToString();
            ResultField.text = DisplayedAmountResult.ToString();
            InInventoryField.text = DisplayedAmountInInventory.ToString();
        }

    }

    public void NoHoverButtonCheck()
    {
        if (MaterialHandler.HasEnoughResources(Ingredient1, DisplayedAmountIngredient, Ingredient2, DisplayedAmountIngredient2, Ingredient3, Amount3, Ingredient4, Amount4, Ingredient5, Amount5))
        {
            Renderer.sprite = CanCraft;
        }
        else
        {
            Renderer.sprite = CantCraft;
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
