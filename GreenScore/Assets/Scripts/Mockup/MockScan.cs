using System.Collections;
using UnityEngine;

public class MockScan : MonoBehaviour{
	[SerializeField] private int scanCode;
	
	public void Scan(){
		SceneChangeMessage sceneChangeMessage = new(){NewSceneNumber = 1};
		Broker.InvokeSubscribers(typeof(SceneChangeMessage), sceneChangeMessage);
		StartCoroutine(DelayLoad());
	}
	private IEnumerator DelayLoad(){
		yield return new WaitForSeconds(0.1f);
		ProductScannedMessage productScannedMessage = new(){ScannedData = scanCode};
		Broker.InvokeSubscribers(typeof(ProductScannedMessage), productScannedMessage);
	}
}