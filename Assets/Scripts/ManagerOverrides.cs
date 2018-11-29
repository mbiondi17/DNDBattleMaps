using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Linq;


public class ManagerOverrides : NetworkManager {

	public override void OnServerConnect(NetworkConnection conn) {
		PlayerControl localPlayer = GameObject.FindObjectsOfType<PlayerControl>().FirstOrDefault(x => x.GetComponentInParent<UnityEngine.Networking.NetworkIdentity>().isLocalPlayer);
		if(localPlayer.GetComponentInParent<UnityEngine.Networking.NetworkIdentity>().isServer) {
			localPlayer.SetAssigningUnit(true);
			GameObject canvas = GameObject.Find ("Canvas");
			GameObject overlay = canvas.transform.Find("AssignUnit").gameObject;
			overlay.GetComponent<RectTransform>().localPosition = new Vector3(0f,0f,0f);
		}
	}
}
