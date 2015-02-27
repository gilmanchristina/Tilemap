using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	public string IP = "127.0.0.1";
	public int Port = 25001;
	public string username = "";
	bool RegisterUI = false;
	bool LoginUI = false;
	bool LogoutUI = false;

	void OnGUI (){
		if (Network.peerType == NetworkPeerType.Disconnected) {
			if (GUI.Button (new Rect (100, 100, 100, 25), "Start Client")) {
					Network.Connect (IP, Port);
			}
			if (GUI.Button (new Rect (100, 125, 100, 25), "Start Server")) {
					Network.InitializeServer (10, Port, false);
			}
		} 
		else {
			if (Network.peerType == NetworkPeerType.Client){

				if(RegisterUI == true && LoginUI == false && LogoutUI == false){
					username = GUI.TextArea(new Rect(100,125,100,25), username);
					if(GUI.Button(new Rect(100,150,100,25),"Register")){
						networkView.RPC ("Register",RPCMode.Server,username);
						RegisterUI = false;
					}
				}
				else if(LoginUI == true && RegisterUI == false && LogoutUI == false){
					username = GUI.TextArea(new Rect(100,125,100,25), username);
					if(GUI.Button(new Rect(100,150,100,25),"Login")){
						networkView.RPC ("Login",RPCMode.Server,username);
						LoginUI = false;
						LogoutUI = true;
					}
				}
				else if(LogoutUI == true && LoginUI == false){
					username = GUI.TextArea(new Rect(100,125,100,25), username);
					if(GUI.Button(new Rect(100,175,100,25),"Logout")){
						Debug.Log("Button was clicked");
						networkView.RPC ("Logout",RPCMode.Server);
					}
				}
					else{
					GUI.Label(new Rect(100,100,100,25),"Client");

					if(GUI.Button(new Rect(100,125,100,25),"Login")){
						LoginUI = true;
					}
					if(GUI.Button(new Rect(100,150,100,25),"Register")){
						RegisterUI = true;
					}
					if(GUI.Button(new Rect(100,175,100,25),"Logout")){
						networkView.RPC ("Logout",RPCMode.Others);
						Network.Disconnect(250);
					}
				}
			}
			if (Network.peerType == NetworkPeerType.Server){
				GUI.Label(new Rect(100,100,100,25),"Server");
				GUI.Label(new Rect(100,125,100,25),"Connections: " + Network.connections.Length);
				if(GUI.Button(new Rect(100,150,100,25),"Logout")){
					Network.Disconnect(250);
				}
			}
		}
	}
	[RPC]
	void Register(string username){
		if(Network.isServer){
			PlayerPrefs.SetString(username,username);
		}
	}
	[RPC]
	void Login(string username){
		if(Network.isServer){
			bool checkUsername = PlayerPrefs.HasKey(username);
			if (checkUsername == true){
				networkView.RPC ("LoadLevel",RPCMode.Others);
			}
		}
	}
	[RPC]
	void Logout(){
		if(Network.isClient){
			Debug.Log("Attempting to Logout");
			Application.LoadLevel(0);
			Network.Disconnect(250);
			Debug.Log("Successfully logged out");
		}
	}
	[RPC]
	void LoadLevel(){
		if(Network.isClient){
			if(Application.loadedLevel == 0){
				Application.LoadLevel(1);
			}
		}
	}
//	[RPC]
//	void AskForColor(){
//		if(Network.isServer){
//			networkView.RPC ("ChangeColor",RPCMode.All);
//		}
//	}
//
//	[RPC]
//	void ChangeColor(){
//		Debug.Log ("Color has been changed");
//	}

	//NetworkView.RPC("function name",RPCMode.All);
}
