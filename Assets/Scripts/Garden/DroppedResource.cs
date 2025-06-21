using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class DroppedResource : MonoBehaviour
{
    public GameObject Player;
    private Rigidbody2D rb;
    private MaterialHandler MaterialHandler;
    private float CollectDistance = 0.25f;
    private float CollectSpeed = 0.9f;
    private float FollowDistance = 0.55f;

    public string ResourceName;
    public int ResourceAmount;
    
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();   
        MaterialHandler = FindFirstObjectByType<MaterialHandler>();  
    }

    
    void Update()
    {
        if(Vector2.Distance(Player.transform.position, this.gameObject.transform.position) < FollowDistance)
        {
            if(Vector2.Distance(Player.transform.position, this.gameObject.transform.position) > 0.15f)
            {
                Vector2 Direction = (Player.transform.position - transform.position).normalized;
                rb.linearVelocity = Direction * CollectSpeed;
                //transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, 0.5f * Time.deltaTime);
            }

            if (Vector2.Distance(Player.transform.position, this.gameObject.transform.position) < CollectDistance)
            {
                transform.localScale -=  Vector3.one * Time.deltaTime * 2f;
                if(transform.localScale.x <0.2f || Vector2.Distance(Player.transform.position, this.gameObject.transform.position) < 0.15f)
                {
                    Collect();
                }
                
            }
        }
    }

    private void Collect()
    {
        Debug.Log(ResourceName + " +1");
        MaterialHandler.IncreaseResourceCount(ResourceName, ResourceAmount);
        Destroy(gameObject);
    }
}
