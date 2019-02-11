using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
                    List<Renderer> rends = new List<Renderer>();
                    if(this.GetComponent<Renderer>() != null) 
                            rends.Add(this.GetComponent<Renderer>());
                    if(this.GetComponentsInChildren<Renderer>().Any()) 
                        rends.AddRange(this.GetComponentsInChildren<Renderer>());
                    
                    if(visible) {
                        rends.ForEach(x => x.enabled = false);
                        visible = false;
                    }
                    else {
                        rends.ForEach(x => x.enabled = true);
                        visible = true;
                    }
                }
			}
		}
    }
}
