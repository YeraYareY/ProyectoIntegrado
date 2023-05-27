using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoreItems : MonoBehaviour
{
   public string itenName;
   public int itemSellPrice;
   public int itemBuyPrice;
   public static int healthToGive=1; 
   TextMeshProUGUI buyPriceText;

   public player player;

   void Start(){
      
      buyPriceText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
      buyPriceText.text = "$ "+itemBuyPrice.ToString();
   }

   public void BuyItem(){
      Debug.Log("HOLA");
      if(itemBuyPrice<=player.puntos){
         player.puntos-=itemSellPrice;
         player.vida+=healthToGive;
         Debug.Log("Vidas:"+player.vida);
      }
   }

}
