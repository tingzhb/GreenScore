using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCart : MonoBehaviour{
	[SerializeField] private Cart cart;
	[SerializeField] private GameObject itemPrefab;
	private void Awake(){
		foreach (var item in cart.cartList){
			
			
		}
	}
}
