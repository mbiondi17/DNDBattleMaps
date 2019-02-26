using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraNavigationHighlight : MonoBehaviour
{

    private GameObject lastHighlighted;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray tryRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit thisHit;
        if (Physics.Raycast(tryRay, out thisHit, 5000))
        {
            if (thisHit.collider.gameObject.GetComponent<MeshRenderer>())
            {
                if (thisHit.collider.gameObject.GetComponent<MeshRenderer>().materials.Any(x => x.name.Contains("Outline")))
                {
                    if (thisHit.collider.gameObject != lastHighlighted)
                    {
                        thisHit.collider.gameObject.GetComponent<MeshRenderer>().enabled = true;
                        lastHighlighted = thisHit.collider.gameObject;
                    }
                    else
                    {
                        lastHighlighted.GetComponent<MeshRenderer>().enabled = false;
                        thisHit.collider.gameObject.GetComponent<MeshRenderer>().enabled = true;
                        lastHighlighted = thisHit.collider.gameObject;
                    }
                }
                else if(lastHighlighted)
                {
                    lastHighlighted.GetComponent<MeshRenderer>().enabled = false;
                    lastHighlighted = null;
                }
            }
            else if(lastHighlighted)
            {
                lastHighlighted.GetComponent<MeshRenderer>().enabled = false;
                lastHighlighted = null;
            }
        }
        else if(lastHighlighted)
        {
            lastHighlighted.GetComponent<MeshRenderer>().enabled = false;
            lastHighlighted = null;
        }

        if(lastHighlighted && Input.GetKey(KeyCode.N) && Input.GetMouseButtonDown(0)) {
            if(lastHighlighted.GetComponent<INavigable>() != null) {
                GameObject manager = GameObject.Find("GameManager");
                if(manager) 
                    manager.GetComponent<LevelManager>().LoadLevelByName(lastHighlighted.GetComponent<INavigable>().LevelName());
            }
        }
    }
}
