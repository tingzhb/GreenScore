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
		var contextChanger = 0;
		var starChanger = 0;
		if (!obj.ScannedItem){
			contextChanger += 7;
			starChanger += 5;
		}
			
		var greenScore = obj.GreenScore;
		
		texts[0 + contextChanger].text = obj.ItemName;
		texts[1 + contextChanger].text = obj.ItemType.ToString();
		texts[2 + contextChanger].text = "GreenScore: " + greenScore.ToString(CultureInfo.InvariantCulture);
		texts[3 + contextChanger].text = "Price: " + obj.Price.ToString(CultureInfo.InvariantCulture) + "kr";
		texts[4 + contextChanger].text = "(" + obj.WPrice.ToString(CultureInfo.InvariantCulture) + "/kg)";
		texts[5 + contextChanger].text = obj.PlaceName.ToString(CultureInfo.InvariantCulture);
		texts[6 + contextChanger].text = obj.Address.ToString(CultureInfo.InvariantCulture);
		
		for (var i = 0  + starChanger; i < Mathf.Ceil(greenScore) + starChanger; i++){
			stars[i].SetActive(true);
		}
	}
}
