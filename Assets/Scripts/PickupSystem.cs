using UnityEngine;

public class PickupSystem : MonoBehaviour
{
    public Transform playerCamera;      
    public float pickupRange = 3f;      
    public float throwForce = 5f;       
    private GameObject heldObject;      

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldObject == null)  
            {
                TryPickup();
            }
            else  
            {
                DropObject();
            }
        }
    }

    void TryPickup()
    {
        Ray ray = new Ray(playerCamera.position, playerCamera.forward);  
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, pickupRange))  
        {
            if (hit.collider.CompareTag("PickupItem"))  
            {
                heldObject = hit.collider.gameObject;
                heldObject.GetComponent<Rigidbody>().isKinematic = true;  
                heldObject.transform.SetParent(playerCamera);  
                heldObject.transform.localPosition = new Vector3(0, 0, 1);  
            }
        }
    }

    void DropObject()
    {
        heldObject.GetComponent<Rigidbody>().isKinematic = false;  
        heldObject.transform.SetParent(null);  

        Rigidbody rb = heldObject.GetComponent<Rigidbody>();
        rb.AddForce(playerCamera.forward * throwForce, ForceMode.VelocityChange);  

        heldObject = null; 
    }
}
