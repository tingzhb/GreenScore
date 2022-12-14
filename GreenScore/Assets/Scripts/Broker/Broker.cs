using System;
using System.Collections.Generic;

public static class Broker {
	private static readonly Dictionary<Type, Delegate> listeners = new();
	public static event Action<IMessage> AnyMessageReceived;

	public static void Subscribe<IMessage>(Action<IMessage> onMessageReceived){
		if (listeners.TryGetValue(typeof(IMessage), out var del)){
			listeners[typeof(IMessage)] = Delegate.Combine(del, onMessageReceived);
		}
		else{
			listeners[typeof(IMessage)] = onMessageReceived;
		}
	}
	public static void Unsubscribe<IMessage>(Action<IMessage> onMessageReceived) {
		if (listeners.TryGetValue(typeof(IMessage), out var del)){
			listeners[typeof(IMessage)] = Delegate.Remove(del, onMessageReceived);
		}
	}
	public static void InvokeSubscribers(Type type, IMessage data) {
		if (listeners.TryGetValue(type, out var listener)) {
			listener?.DynamicInvoke(data);
            
		}
		AnyMessageReceived?.Invoke(data);
	}
}
