using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject[] slots;
    public GameObject[] backPack;
    private bool isInstantiated;

    public Dictionary<string, int> inventoryItems = new Dictionary<string, int>();

    public void CheckSlotsAvailability(GameObject itemToAdd, string itemName, int itemAmount){
        isInstantiated = false;
        for(int i= 0; i < slots.Length; i++){
            if(slots[i].GetComponent<SlotsScript>().isUsed){
                
            }else{
                if(!inventoryItems.ContainsKey(itemName)){
                    GameObject item= Instantiate(itemToAdd, slots[i].transform.position,
                        Quaternion.identity);
                        item.transform.SetParent(slots[i].transform, false);
                        item.transform.localPosition = new Vector3(0,0,0);
                        item.name=item.name.Replace("(Clone)","");
                        isInstantiated=true;
                        slots[i].GetComponent<SlotsScript>().isUsed = true;
                        inventoryItems.Add(itemName, itemAmount);
                }
            }
        }

    }
}
