using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SwipeTrial : MonoBehaviour
{
   private GameManager gameManager;
    private void Start()
    {
       gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    //GameObject gObj = null;
    public void TouchReader()
    {
        while (true/*!gameManager.isGameOver /*&& !gameManager.isGamePaused*/)
        {        
                if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetMouseButton(0))
                {
                    Plane objPlane = new Plane(Camera.main.transform.forward * -1, this.transform.position);
                    Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                    float rayDistance;
                    if (objPlane.Raycast(mRay, out rayDistance))
                    {
                        this.transform.position = mRay.GetPoint(rayDistance);
                    }
                    Ray mouseRay = GenrateMouseRay(Input.mousePosition);
                    RaycastHit hit;
                    if (Physics.Raycast(mouseRay.origin, mouseRay.direction, out hit))
                    {
                        Destroy(hit.transform.gameObject);
                        //  gObj = hit.transform.gameObject;
                    }
                }
        }
    }

    Ray GenrateMouseRay(Vector3 touchPos)
    {
        Vector3 mousePosFar = new Vector3(touchPos.x, touchPos.y, Camera.main.farClipPlane);
        Vector3 mousePosNear = new Vector3(touchPos.x, touchPos.y, Camera.main.nearClipPlane);
        Vector3 mousePosf = Camera.main.ScreenToWorldPoint(mousePosFar);
        Vector3 mousePosN = Camera.main.ScreenToWorldPoint(mousePosNear);
        Ray mr = new Ray(mousePosN, mousePosf - mousePosN);
        return mr;
    }
}



