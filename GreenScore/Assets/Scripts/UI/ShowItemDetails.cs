using System.Globalization;
using TMPro;
using UnityEngine;


public class ShowItemDetails : MonoBehaviour{
	[SerializeField] private TextMeshProUGUI[] texts;
	[SerializeField] private GameObject[] stars;
	private void Awake(){
		Broker.Subscribe<ShowProductDetailsMessage>(OnShowProductDetailsMessageReceived);
	}

	private void OnDisable(){
		Broker.Unsubscribe<ShowProductDetailsMessage>(OnShowProductDetailsMessageReceived);
	}
	private void OnShowProductDetailsMessageReceived(ShowProductDetailsMessage obj){

		var greenScore = obj.GreenScore;
		
		texts[0].text = obj.ItemName;
		texts[1].text = obj.ItemType.ToString();
		texts[2].text = greenScore.ToString(CultureInfo.InvariantCulture);
		texts[3].text = obj.Price.ToString(CultureInfo.InvariantCulture);

		for (var i = 0; i < Mathf.Ceil(greenScore); i++){
			stars[i].SetActive(true);
		}
	}
}
