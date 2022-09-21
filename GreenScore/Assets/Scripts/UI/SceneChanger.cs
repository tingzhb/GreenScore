using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour{

	private void Awake(){
		DontDestroyOnLoad(gameObject);
		Broker.Subscribe<SceneChangeMessage>(OnSceneChangeMessageReceived);
	}

	private void OnDisable(){
		Broker.Unsubscribe<SceneChangeMessage>(OnSceneChangeMessageReceived);
	}
	
	private void OnSceneChangeMessageReceived(SceneChangeMessage obj){
		if (obj.NewSceneNumber > 0){
			SceneManager.LoadSceneAsync(sceneBuildIndex: obj.NewSceneNumber, LoadSceneMode.Additive);
		}
		if (obj.CurrentSceneNumber > 0){
			SceneManager.UnloadSceneAsync(sceneBuildIndex: obj.CurrentSceneNumber);
		}
	}
}