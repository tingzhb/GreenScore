using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ShowImage : MonoBehaviour{
	[SerializeField] private GameObject[] photos;
	
	private void Awake(){
		Broker.Subscribe<ShowProductDetailsMessage>(OnShowProductDetailsMessageReceived);
	}

	private void OnDisable(){
		Broker.Unsubscribe<ShowProductDetailsMessage>(OnShowProductDetailsMessageReceived);
	}
	private void OnShowProductDetailsMessageReceived(ShowProductDetailsMessage obj){
		photos[obj.SpriteIndex].SetActive(true);
		Broker.Unsubscribe<ShowProductDetailsMessage>(OnShowProductDetailsMessageReceived);
	}
}
