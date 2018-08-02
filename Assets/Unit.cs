using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {

	private bool selected;

	// Use this for initialization
	void Start () {
		this.selected = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)) {
			Ray tryRay = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit thisHit;
			if(selected) {
				if (Physics.Raycast (tryRay, out thisHit, 5000)) {
					float terrainHeightAtHit = Terrain.activeTerrain.SampleHeight(thisHit.point);
					this.GetComponent<Transform>().position = new Vector3(thisHit.point.x, terrainHeightAtHit, thisHit.point.z);
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
