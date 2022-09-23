using System;
using UnityEngine;

public class MockDatabase : MonoBehaviour{
	[SerializeField] private ItemDetails[] items;
	private ItemDetails foundItem;
	private ItemDetails pickedÍtem;
	private void Awake(){
		Broker.Subscribe<ProductScannedMessage>(OnProductScannedMessageReceived);
	}
	private void OnDisable(){
		Broker.Unsubscribe<ProductScannedMessage>(OnProductScannedMessageReceived);
	}

	public ItemDetails FindItemByID(int id){
		foreach (var item in items){
			if (item.id == id){
				pickedÍtem = item;
				break;
			}
		}
		return pickedÍtem;
	}
	
	private void OnProductScannedMessageReceived(ProductScannedMessage obj){
		foundItem = FindItemByID(obj.ScannedData);
		SendProductDetails(foundItem, 0); 
		FindBestItem();
	}
	
	private void FindBestItem(){
		foreach (var newItem in items){
			if (foundItem.itemType == newItem.itemType && newItem.greenScore > foundItem.greenScore){
				foundItem = newItem;
			}
		}
		SendProductDetails(foundItem, 1);
	}
	private void SendProductDetails(ItemDetails item, int displayIndex){
		ShowProductDetailsMessage showProductDetailsMessage = new(){
			displayIndex = displayIndex,
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