using System;
using System.Collections;
using UnityEngine;

public class Profile : MonoBehaviour{
	private float totalGreenScore, averageGreenScore, totalProducts;

	private void Awake(){
		Broker.Subscribe<ProfileUpdateMessage>(OnProfileUpdateMessageReceived);
		Broker.Subscribe<SceneChangeMessage>(OnSceneChangedMessageReceived);
	}
	private void OnDisable(){
		Broker.Unsubscribe<ProfileUpdateMessage>(OnProfileUpdateMessageReceived);
		Broker.Unsubscribe<SceneChangeMessage>(OnSceneChangedMessageReceived);

	}
	private void OnSceneChangedMessageReceived(SceneChangeMessage obj){
		if (obj.NewSceneNumber == 5){
			StartCoroutine(DelayShowProfileMessage());
		}
	}

	private IEnumerator DelayShowProfileMessage(){
		yield return new WaitForSeconds(0.2f);
		ShowProfileMessage showProfileMessage = new(){
			GreenScore = averageGreenScore,
			TotalProducts = totalProducts
		};
		Broker.InvokeSubscribers(typeof(ShowProfileMessage), showProfileMessage);
	}

	private void OnProfileUpdateMessageReceived(ProfileUpdateMessage obj){
		totalGreenScore += obj.AddGreenScore;
		totalProducts += obj.AddProducts;
		averageGreenScore = totalGreenScore / totalProducts;
	}
}
