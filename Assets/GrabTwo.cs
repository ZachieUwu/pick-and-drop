using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrabTwo : MonoBehaviour
{
    bool Pressed = false;
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
        hoverTextInstance.transform.position = mousePos + new Vector2(0, 20);
    }

    private void OnMouseExit()
    {
        isHovering = false;
        hoverTextInstance.SetActive(false);
    }

    private void OnMouseDown()
    {
        Pressed = true;
        isHovering = false;
        hoverTextInstance.SetActive(false);
        GetComponent<Rigidbody2D>().isKinematic = true;
    }

    private void OnMouseUp()
    {
        Pressed = false;
        GetComponent<Rigidbody2D>().isKinematic = false;
    }

    void Update()
    {
        if (Pressed)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePos;
        }

        if (isHovering && hoverTextInstance != null)
        {
            Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
            hoverTextInstance.transform.position = screenPosition + new Vector2(0, 20);
        }
    }
}