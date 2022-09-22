using UnityEngine;

public class MockDatabase : MonoBehaviour{
	[SerializeField] private ItemDetails[] items;
	private ItemDetails foundItem;
	private void Awake(){
		Broker.Subscribe<ProductScannedMessage>(OnProductScannedMessageReceived);
	}
	private void OnDisable(){
		Broker.Unsubscribe<ProductScannedMessage>(OnProductScannedMessageReceived);
	}
	private void OnProductScannedMessageReceived(ProductScannedMessage obj){
		foreach (var item in items){
			if (item.id != obj.ScannedData)
				continue;
			foundItem = item;
			SendProductDetails(item, true);
			break;
		}
		FindBestItem();
	}
	private void FindBestItem(){
		foreach (var item in items){
			if (foundItem.itemType == item.itemType && foundItem.greenScore < item.greenScore){
				foundItem = item;
				FindBestItem();
			} else {
				SendProductDetails(foundItem, false);
			}
		}
	}
	private static void SendProductDetails(ItemDetails item, bool scannedItem){

		ShowProductDetailsMessage showProductDetailsMessage = new(){
			ScannedItem = scannedItem,
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
