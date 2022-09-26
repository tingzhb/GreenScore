using UnityEngine;

public class AddItem : MonoBehaviour{
	private int itemID;
	private void Awake(){
		Broker.Subscribe<ShowProductDetailsMessage>(OnShowProductDetailsMessageReceived);
	}
	
	private void OnDisable() {
		Broker.Unsubscribe<ShowProductDetailsMessage>(OnShowProductDetailsMessageReceived);
	}
	private void OnShowProductDetailsMessageReceived(ShowProductDetailsMessage obj){
		if (obj.DisplayIndex == 0){
			itemID = obj.Id;
		}
	}

	public void Add(){
		ItemAddMessage itemAddMessage = new(){ ID = itemID};
		Broker.InvokeSubscribers(typeof(ItemAddMessage), itemAddMessage);
	}
}
