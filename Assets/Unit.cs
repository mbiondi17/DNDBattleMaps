using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {

	private bool selected;
	private PlayerControl controllingPlayer;

	// Use this for initialization
	void Start () {
		this.selected = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(controllingPlayer != null && !controllingPlayer.IsAssigningUnit()) {
			if(Input.GetMouseButtonDown(0)) {
				Ray tryRay = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit thisHit;
				if(selected) {
					if (Physics.Raycast (tryRay, out thisHit, 5000)) {
						float terrainHeightAtHit = Terrain.activeTerrain.SampleHeight(thisHit.point);
						float gridSnapX = (int)thisHit.point.x % 2 == 0 ? Mathf.Ceil(thisHit.point.x) : Mathf.Floor(thisHit.point.x);
						float gridSnapZ = (int)thisHit.point.z % 2 == 0 ? Mathf.Ceil(thisHit.point.z) : Mathf.Floor(thisHit.point.z);
						this.GetComponent<Transform>().position = new Vector3(gridSnapX, terrainHeightAtHit, gridSnapZ);
					}
					this.selected = false;
				}
				else {
					if (Physics.Raycast (tryRay, out thisHit, 5000)) {
						if(thisHit.transform.gameObject == this.gameObject) {
							this.selected = true;
						}
					}
				}
			}
		}
	}

	public void SetControllingPlayer(PlayerControl player) {
		this.controllingPlayer = player;
	}
}
