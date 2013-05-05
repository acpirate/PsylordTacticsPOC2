using UnityEngine;
using System.Collections;

public class Log {
	
	public static void Print(Object inObject, string message) {
		Debug.Log(System.DateTime.Now.ToString("HH:mm:ss")+ "[" +inObject.GetType().Name+ "] "+ message);  	
	}	
}
