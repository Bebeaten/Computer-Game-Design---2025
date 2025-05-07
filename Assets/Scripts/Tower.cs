using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
	public GameObject SelectPoint;
	public GameObject SelectSpot;
	private bool isDragging = false;
    private Camera mainCamera;
	
	// Highlights towers when mouse hover overs
	void Awake(){
		Transform SelectPointTrans = transform.Find("SelectPoint");
		SelectPoint = SelectPointTrans.gameObject;
		SelectPoint.SetActive(false);
		Transform SelectSpotTrans = transform.Find("SelectSpot");
		//SelectSpot = SelectSpotTrans.gameObject;
		SelectSpot.SetActive(false);
		mainCamera = Camera.main;
	}

	void Start()
    {
        if (SelectSpot != null)
        {
            SelectSpot.SetActive(false);
        }
    }

    void Update()
    {
        if (isDragging)
        {
            DragWithMouse();
            
            if (Input.GetMouseButtonUp(0)) // Release left mouse button
            {
                isDragging = false;
                if (SelectSpot != null)
                {
                    SelectSpot.SetActive(false);
                }
            }
        }
    }
	
	void OnMouseEnter()
    {
        if (SelectPoint != null)
        {
            SelectPoint.SetActive(true);
        }
    }

    void OnMouseExit()
    {
        if (SelectPoint != null)
        {
            SelectPoint.SetActive(false);
        }
    }

    void OnMouseDown()
    {
        // When clicked, start dragging
        isDragging = true;

        SelectSpot.SetActive(true);
    }

    void DragWithMouse()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            // Move tower smoothly to mouse hit point
            Vector3 targetPos = hit.point;
            targetPos.y = transform.position.y; // Keep original Y for tower not jumping
            transform.position = targetPos;
        }
	}
}
