using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {
	private void Awake(){
		DontDestroyOnLoad(gameObject);
		Broker.Subscribe<SceneChangeMessage>(OnSceneChangeMessageReceived);
	}

	private void OnDisable(){
		Broker.Unsubscribe<SceneChangeMessage>(OnSceneChangeMessageReceived);
	}
	
	private void OnSceneChangeMessageReceived(SceneChangeMessage obj){
		SceneManager.LoadScene(sceneBuildIndex: obj.SceneNumber);
	}
}
