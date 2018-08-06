using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	private List<Unit> playersUnits;

	// Use this for initialization
	void Start () {
		if(GetComponentInParent<UnityEngine.Networking.NetworkIdentity>().isServer) {
			Debug.Log("I am a server!");
			GameObject[] allUnits = GameObject.FindGameObjectsWithTag("Selectable");
			foreach(GameObject unit in allUnits) {
				if(unit.GetComponent<Unit>() != null)
					this.playersUnits.Add(unit.GetComponent<Unit>());
					unit.GetComponent<Unit>().SetControllingPlayer(this);
			}
		}
		else {
			Debug.Log("I am a client!");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
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
}
