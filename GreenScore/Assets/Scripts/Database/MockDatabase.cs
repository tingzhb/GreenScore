using UnityEngine;

public class MockDatabase : MonoBehaviour{
	[SerializeField] private ItemDetails[] items;

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
			ShowProductDetailsMessage showProductDetailsMessage = new(){
				ItemName = item.itemName,
				ItemType = item.itemType,
				Id = item.id,
				SpriteIndex = item.spriteIndex,
				GreenScore = item.greenScore,
				Price = item.price
			};
			Broker.InvokeSubscribers(typeof(ShowProductDetailsMessage), showProductDetailsMessage);
			break;
		}
	}
}
