using UnityEngine;

public class Checkout : MonoBehaviour{
	public void CheckoutButton(){
		CheckoutMessage checkoutMessage = new();
		Broker.InvokeSubscribers(typeof(CheckoutMessage), checkoutMessage);
	}
}
