using System.Globalization;
using TMPro;
using UnityEngine;


public class ShowItemDetails : MonoBehaviour{
	[SerializeField] private TextMeshProUGUI[] texts;
	private void Awake(){
		Broker.Subscribe<ShowProductDetailsMessage>(OnShowProductDetailsMessageReceived);
	}

	private void OnDisable(){
		Broker.Unsubscribe<ShowProductDetailsMessage>(OnShowProductDetailsMessageReceived);
	}
	private void OnShowProductDetailsMessageReceived(ShowProductDetailsMessage obj){
		Debug.Log("ItemFound!");
		texts[0].text = obj.ItemName;
		texts[1].text = obj.ItemType.ToString();
		texts[2].text = obj.GreenScore.ToString(CultureInfo.InvariantCulture);
		texts[3].text = obj.Price.ToString(CultureInfo.InvariantCulture);
	}
}
