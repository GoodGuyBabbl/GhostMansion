using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;



public class CraftButton : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    [Header("Components")]
    [SerializeField] private Button Button;

    private bool EnoughResources;

    private Image Renderer;

    private MaterialHandler MaterialHandler;

    public Sprite CantCraft;
    public Sprite CantCraftHover;
    public Sprite CanCraft;
    public Sprite CanCraftHover;

    public TextMeshProUGUI TextMeshPro;


    public string CraftedResource;
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


    private void Start()
    {
        MaterialHandler = FindFirstObjectByType<MaterialHandler>();
        Renderer = GetComponent<Image>();


        //RoomNpc = FindFirstObjectByType<RoomNPC>();
    }




    public void SelectButton()
    {
        Button.Select();
    }

    public void OnSelect(BaseEventData eventData)
    {
        if(MaterialHandler.HasEnoughResources(Ingredient1, Amount1, Ingredient2, Amount2, Ingredient3, Amount3, Ingredient4, Amount4, Ingredient5, Amount5))
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
        if(Renderer.sprite == CanCraftHover)
        {

        }
    }
}
