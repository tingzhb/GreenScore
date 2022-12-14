using System;
using System.Globalization;
using TMPro;
using UnityEngine;

public class ShowProfile : MonoBehaviour{
	[SerializeField] private TextMeshProUGUI[] textFields;
	[SerializeField] private GameObject[] stars;
	private void Awake(){
		Broker.Subscribe<ShowProfileMessage>(OnShowProfileMessageReceived);
	}
	private void OnDisable(){
		Broker.Unsubscribe<ShowProfileMessage>(OnShowProfileMessageReceived);
	}
	private void OnShowProfileMessageReceived(ShowProfileMessage obj){
		var greenScore = obj.GreenScore;
		textFields[0].text = greenScore.ToString("#.##");
		textFields[1].text = obj.TotalProducts.ToString(CultureInfo.InvariantCulture) + " products";

		for (var i = 0; i < Mathf.Ceil(greenScore); i++){
			stars[i].SetActive(true);
		}
	}
}
