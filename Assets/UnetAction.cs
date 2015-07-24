using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class UnetAction : NetworkBehaviour {

	#region utils
	/// <summary>
	/// Strings the color of the to. colorString: RRGGBBAA
	/// </summary>
	/// <returns>The to color.</returns>
	/// <param name="colorString">Color string. RRGGBBAA</param>
	public static Color StringToColor(string colorString)
	{
		int color32 =System.Convert.ToInt32(colorString, 16);
		int red = color32 >> 24 & 0xFF;
		int green = color32 >> 16 & 0xFF;
		int blue = color32 >> 8  & 0xFF;
		int alpha = color32 & 0xFF;
		return new Color(red/255.0f, green/255.0f, blue/255.0f, alpha/255.0f);
	}

	public static string ColorToString(Color color)
	{
		int color32 = ( (int)(color.r*255) << 24 | (int)(color.g*255) << 16 | (int)(color.b*255) << 8 | (int)(color.a*255) );
		return color32.ToString("X");
	}
	#endregion

	public enum SendMode
	{
		OnlyClients, All
	}

	public static UnetAction instance;
	
	void Awake ()
	{
		if(instance == null){
			instance = this;
		}else{
			Debug.LogWarning(this.name + " is Singleton");
		}
	}
	
	public void SendNetMessage(string sendGameObjectName, string methodName, SendMode mode = SendMode.All)
	{
		if(isServer){
			RpcRunFunction(sendGameObjectName, methodName, mode);
		}
	}

	[ClientRpc]
	void RpcRunFunction(string sendGameObjectName, string methodName, SendMode mode)
	{
		if(mode == SendMode.OnlyClients && isServer){
			return;
		}

		GameObject _refGObj = GameObject.Find(sendGameObjectName);

		if(_refGObj != null){
			_refGObj.SendMessage(methodName);
		}
	}


	public void SendNetMessageWithString(string sendGameObjectName, string methodName, string str, SendMode mode = SendMode.All)
	{
		if(isServer){
			RpcRunFunctionWithString(sendGameObjectName, methodName, str, mode);
		}
	}
	
	[ClientRpc]
	void RpcRunFunctionWithString(string sendGameObjectName, string methodName, string str, SendMode mode)
	{
		if(mode == SendMode.OnlyClients && isServer){
			return;
		}

		GameObject _refGObj = GameObject.Find(sendGameObjectName);
		if(_refGObj != null){
			_refGObj.SendMessage(methodName, str);
		}
	}

	public void SendNetMessageWithFloat(string sendGameObjectName, string methodName, float v, SendMode mode = SendMode.All)
	{
		if(isServer){
			RpcRunFunctionWithFloat(sendGameObjectName, methodName, v, mode);
		}
	}
	
	[ClientRpc]
	void RpcRunFunctionWithFloat(string sendGameObjectName, string methodName, float v, SendMode mode)
	{
		if(mode == SendMode.OnlyClients && isServer){
			return;
		}
		
		GameObject _refGObj = GameObject.Find(sendGameObjectName);
		if(_refGObj != null){
			_refGObj.SendMessage(methodName, v);
		}
	}

	public void SendNetMessageWithInt(string sendGameObjectName, string methodName, int v, SendMode mode = SendMode.All)
	{
		if(isServer){
			RpcRunFunctionWithInt(sendGameObjectName, methodName, v, mode);
		}
	}
	
	[ClientRpc]
	void RpcRunFunctionWithInt(string sendGameObjectName, string methodName, int v, SendMode mode)
	{
		if(mode == SendMode.OnlyClients && isServer){
			return;
		}
		
		GameObject _refGObj = GameObject.Find(sendGameObjectName);
		if(_refGObj != null){
			_refGObj.SendMessage(methodName, v);
		}
	}

}
