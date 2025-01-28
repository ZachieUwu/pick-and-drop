using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrabTwo : MonoBehaviour
{
    bool isHolding = false;
    public GameObject hoverTextPrefab;
    private GameObject hoverTextInstance;
    private bool isHovering = false;
    private Canvas canvas;

    private void Start()
    {
        canvas = FindObjectOfType<Canvas>();

        hoverTextInstance = Instantiate(hoverTextPrefab, canvas.transform);
        hoverTextInstance.SetActive(false);
    }

    private void OnMouseEnter()
    {
        isHovering = true;
        hoverTextInstance.SetActive(true);

        Vector2 mousePos = Input.mousePosition;
        hoverTextInstance.transform.position = mousePos + new Vector2(0, 100);
    }

    private void OnMouseExit()
    {
        isHovering = false;
        hoverTextInstance.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (!isHolding)
        {
            PickUpObject();
        }
        else
        {
            DropObject();
        }
    }

    private void PickUpObject()
    {
        isHolding = true;
        isHovering = false;
        hoverTextInstance.SetActive(false);
        GetComponent<Rigidbody2D>().isKinematic = true;
    }

    private void DropObject()
    {
        isHolding = false;
        GetComponent<Rigidbody2D>().isKinematic = false;
    }

    private void Update()
    {
        if (isHolding)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePos;
        }

        if (isHovering && hoverTextInstance != null)
        {
            Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
            hoverTextInstance.transform.position = screenPosition + new Vector2(0, 100);
        }
    }
}
