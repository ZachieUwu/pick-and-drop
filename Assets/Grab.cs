using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    [SerializeField] private Transform grabPoint;

    [SerializeField] private Transform rayPoint;

    [SerializeField] private float rayDistance;

    private GameObject grabObject;
    private int layerIndex;

    // Start is called before the first frame update
    void Start()
    {
        layerIndex = LayerMask.NameToLayer("Objects");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 rayDirection = (grabPoint.position - rayPoint.position).normalized;

        RaycastHit2D hitInfo = Physics2D.Raycast(rayPoint.position, rayDirection, rayDistance);

        if (hitInfo.collider != null && hitInfo.collider.gameObject.layer == layerIndex)
        {
            if (grabObject != null)
            {
                grabObject.transform.position = grabPoint.position;
            }

            if (Input.GetKeyDown(KeyCode.E) && grabObject == null)
            {
                grabObject = hitInfo.collider.gameObject;
                grabObject.GetComponent<Rigidbody2D>().isKinematic = true;
                grabObject.transform.position = grabPoint.position;
                grabObject.transform.SetParent(transform);
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                grabObject.GetComponent<Rigidbody2D>().isKinematic = false;
                grabObject.transform.SetParent(null);
                grabObject = null;
            }
        }

        Debug.DrawRay(rayPoint.position, rayDirection * rayDistance, Color.red);
    }
}
