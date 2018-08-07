using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerControl : NetworkBehaviour {

	private List<Unit> playersUnits = new List<Unit>();
	private bool assigningUnit = false;
	private bool iAmServer = false;

	// Use this for initialization
	void Start () {
		iAmServer = GetComponentInParent<UnityEngine.Networking.NetworkIdentity>().isServer;
		if(iAmServer) {
			GameObject[] allUnits = GameObject.FindGameObjectsWithTag("Selectable");
			Debug.Log(allUnits.Length);
			foreach(GameObject unit in allUnits) {
				if(unit.GetComponent<Unit>() != null)
					this.playersUnits.Add(unit.GetComponent<Unit>());
					unit.GetComponent<Unit>().SetControllingPlayer(this);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(IsAssigningUnit()) {
			SetAssigningUnit(false);
		}
	}

	/// <summary>
	/// Called on the server whenever a new player has successfully connected.
	/// </summary>
	/// <param name="player">The NetworkPlayer which just connected.</param>
	void OnPlayerConnected(UnityEngine.Networking.NetworkIdentity player)
	{
		Debug.Log("Hello");
		if(iAmServer) {
			SetAssigningUnit(true);
			GameObject canvas = GameObject.Find ("Canvas");
			GameObject overlay = canvas.transform.Find("AssignUnit").gameObject;
			overlay.GetComponent<RectTransform>().localPosition = new Vector3(0f,0f,0f);
		}
	}

	public void AddUnit(GameObject newUnit) {
		if(newUnit.GetComponent<Unit>() != null) {
			this.playersUnits.Add(newUnit.GetComponent<Unit>());
		}
	}

	public void RemoveUnit( GameObject unitToRemove) {
		if(unitToRemove.GetComponent<Unit>() != null)
			this.playersUnits.Remove(unitToRemove.GetComponent<Unit>());
	}

	public void transferUnit(GameObject unit, GameObject otherPlayer) {
		if(otherPlayer.GetComponent<PlayerControl>() != null) {
			otherPlayer.GetComponent<PlayerControl>().AddUnit(unit);
			RemoveUnit(unit);
		}
	}

	public bool IsAssigningUnit() {
		return this.assigningUnit;
	}

	public void SetAssigningUnit(bool assigning) {
		this.assigningUnit = assigning;
	}
}
