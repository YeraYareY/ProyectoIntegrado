using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoreItems : MonoBehaviour
{
   public string itemName;
   public int itemSellPrice;
   public int itemBuyPrice;
   public static int healthToGive=1;
   public static float speedBoost=100f;
   public static float jumpBoost=100f;
   TextMeshProUGUI buyPriceText;

   public player player;

   void Start(){
      
      buyPriceText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
      buyPriceText.text = "$ "+itemBuyPrice.ToString();
   }

   public void BuyItem(){
      if(itemName=="Manzana"){
         if(itemBuyPrice<=player.puntos){
         player.puntos-=itemSellPrice;
         player.vida+=healthToGive;
         Debug.Log("Vidas:"+player.vida);
         Destroy(gameObject);
         }
      }else if(itemName=="Berenjena"){
         if(itemBuyPrice<=player.puntos){
         player.puntos-=itemSellPrice;
         player.velocidadMovimiento+=speedBoost;
         Destroy(gameObject);
         }
      }else if(itemName=="Pineapple"){
         if(itemBuyPrice<=player.puntos){
         player.puntos-=itemSellPrice;
         player.fuerzaSalto+=jumpBoost;
         Destroy(gameObject);
         }
      }
      
   }

}
