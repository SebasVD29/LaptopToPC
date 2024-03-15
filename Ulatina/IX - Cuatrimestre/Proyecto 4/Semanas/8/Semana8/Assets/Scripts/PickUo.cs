using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUo : MonoBehaviour
{
    public GameObject objectToPickUp;
    public GameObject pickedObject;

    public Transform interZone;
    private void Update()
    {
        if (objectToPickUp != null && 
            objectToPickUp.GetComponent<PickableObject>().isPickable == true && 
            pickedObject == null)
        {
            if (Input.GetAxis("Fire1") != 0)
            {
                pickedObject = objectToPickUp;
                pickedObject.GetComponent<PickableObject>().isPickable = false;
                pickedObject.transform.SetParent(interZone);
                pickedObject.GetComponent<Rigidbody>().useGravity = false;
                pickedObject.GetComponent <Rigidbody>().isKinematic = true;
                pickedObject.transform.position = interZone.transform.position;

            }
        }
        else if (pickedObject != null)
        {
            if (Input.GetAxis("Fire1") != 0)
            {
                pickedObject.GetComponent<PickableObject>().isPickable = true;
                pickedObject.transform.SetParent(null);
                pickedObject.GetComponent<Rigidbody>().useGravity = true;
                pickedObject.GetComponent<Rigidbody>().isKinematic = false;
               // pickedObject.transform.position = interZone.transform.position;
                pickedObject = null;

            }
        }
    }

}
