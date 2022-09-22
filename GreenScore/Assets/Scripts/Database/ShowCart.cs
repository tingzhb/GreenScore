using System;
using UnityEngine;

public class ShowCart : MonoBehaviour{
	[SerializeField] private GameObject itemPrefab, content;

	private void Awake(){
		Broker.Subscribe<CartMessage>(OnCartMessageReceived);
	}
	private void OnDisable(){
		Broker.Unsubscribe<CartMessage>(OnCartMessageReceived);
	}
	private void OnCartMessageReceived(CartMessage obj){
		Debug.Log("CardMessage");
		foreach (var item in obj.ItemDetailsList){
			Instantiate(itemPrefab, content.transform);
			ShowProductDetailsMessage showProductDetailsMessage = new(){
				ItemName = item.itemName,
				ItemType = item.itemType,
				Id = item.id,
				SpriteIndex = item.spriteIndex,
				GreenScore = item.greenScore,
				Price = item.price,
				WPrice = item.wPrice,
				Address = item.address,
				PlaceName = item.placeName
			};
			Broker.InvokeSubscribers(typeof(ShowProductDetailsMessage), showProductDetailsMessage);
		}
	}
}
