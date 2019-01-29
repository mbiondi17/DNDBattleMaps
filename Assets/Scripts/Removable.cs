using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Removable : MonoBehaviour
{
    private bool visible = true;

    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.V) && Input.GetMouseButtonDown(0)) {
			Ray tryRay = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit thisHit;
			if (Physics.Raycast (tryRay, out thisHit, 5000)) {
				if(thisHit.transform.gameObject == this.gameObject) {
                    Renderer rend;
                    if(this.GetComponent<Renderer>() != null) 
                            rend = this.GetComponent<Renderer>();
                    else rend = this.GetComponentInChildren<Renderer>();
                    
                    if(visible) {
                        rend.enabled = false;
                        visible = false;
                    }
                    else {
                        rend.enabled = true;
                        visible = true;
                    }
                }
			}
		}
    }
}
