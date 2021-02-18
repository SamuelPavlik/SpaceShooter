using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour {

    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Bolt"))
        {
            col.gameObject.SetActive(false);
        }
        else
        {
            Destroy(col.gameObject);
        }
    }
}
