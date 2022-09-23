using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cart : MonoBehaviour{
	[SerializeField] private MockDatabase database;
	private List<ItemDetails> cartList;
	private void Awake(){
		cartList = new List<ItemDetails>();
		Broker.Subscribe<ItemAddMessage>(OnItemAddMessageReceived);
		Broker.Subscribe<SceneChangeMessage>(OnSceneChangedMessageReceived);
		Broker.Subscribe<CheckoutMessage>(OnCheckoutMessageReceived);
	}


	private void OnDisable(){
		Broker.Unsubscribe<ItemAddMessage>(OnItemAddMessageReceived);
		Broker.Unsubscribe<SceneChangeMessage>(OnSceneChangedMessageReceived);
		Broker.Unsubscribe<CheckoutMessage>(OnCheckoutMessageReceived);
	}
	
	private void OnCheckoutMessageReceived(CheckoutMessage obj){
		var additionalGreenScore = 0f;
		foreach (var item in cartList){
			additionalGreenScore += item.greenScore;
		}

		ProfileUpdateMessage profileUpdateMessage = new(){
			AddGreenScore = additionalGreenScore,
			AddProducts = cartList.Count
		};
		Broker.InvokeSubscribers(typeof(ProfileUpdateMessage), profileUpdateMessage);
		cartList.Clear();
	}
	
	private void OnSceneChangedMessageReceived(SceneChangeMessage obj){
		if (obj.NewSceneNumber == 4){
			StartCoroutine(DelayCartMessage());
		}
	}
	private IEnumerator DelayCartMessage(){
		yield return new WaitForSeconds(0.1f);
		CartMessage cartMessage = new(){ItemDetailsList = cartList};
		Broker.InvokeSubscribers(typeof(CartMessage), cartMessage);
	}
	
	private void OnItemAddMessageReceived(ItemAddMessage obj){
		var foundItem = database.FindItemByID(obj.ID);
		Debug.Log(foundItem.id);
		cartList.Add(foundItem);
	}
}
