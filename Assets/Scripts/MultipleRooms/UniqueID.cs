using System;
using UnityEngine;
using UnityEditor;


public class UniqueID : MonoBehaviour
{
    [SerializeField]
    private string uniqueID; 

    public string ID => uniqueID; //unique ID-getter, damit uniqueID private und unveränderbar bleibt, aber trotzdem gelesen werden kann;; Zugriff von außen also über Variable "ID"

    private void OnValidate()
    {
        uniqueID = $"{transform.position.x}_{transform.position.z}_{gameObject.name}";
        
    }

}
