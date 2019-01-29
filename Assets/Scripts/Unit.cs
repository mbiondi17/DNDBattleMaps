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
			if (Physics.Raycast (tryRay, out thisHit, 5000)) {
				if(selected) {
					float gridSnapX = (int)thisHit.point.x % 2 == 0 ? Mathf.Ceil(thisHit.point.x) : Mathf.Floor(thisHit.point.x);
					float gridSnapZ = (int)thisHit.point.z % 2 == 0 ? Mathf.Ceil(thisHit.point.z) : Mathf.Floor(thisHit.point.z);
					this.GetComponent<Transform>().position = new Vector3(gridSnapX, thisHit.point.y, gridSnapZ);
					this.selected = false;
				}
				else if(thisHit.transform.gameObject == this.gameObject) {
					if(Input.GetKey(KeyCode.LeftShift)) {
						Camera.main.transform.position = new Vector3(this.transform.position.x, GetComponent<Renderer>().bounds.max.y, this.transform.position.z);
						Camera.main.transform.forward = Vector3.zero;
					}
					else {
						this.selected = true;
					}
				}
			}
		}
	}
}


// if(Input.GetKey(KeyCode.LeftShift)) {
// 				Camera.main.transform.position = this.transform.position;
// 				Camera.main.transform.forward = this.transform.forward;
// 			}