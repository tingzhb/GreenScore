using System;
using System.Collections.Generic;
using UnityEngine;

public class Cart : MonoBehaviour{
	[SerializeField] private MockDatabase database;
	private List<ItemDetails> cartList;
	private void Awake(){
		cartList = new List<ItemDetails>();
		Broker.Subscribe<ItemAddMessage>(OnItemAddMessageReceived);
	}
	private void OnDisable(){
		Broker.Unsubscribe<ItemAddMessage>(OnItemAddMessageReceived);
	}

	private void OnItemAddMessageReceived(ItemAddMessage obj){
		var foundItem = database.FindItemByID(obj.ID);
		Debug.Log(foundItem.id);
		cartList.Add(foundItem);
	}
}
