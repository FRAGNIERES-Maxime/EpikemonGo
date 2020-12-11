using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : MonoBehaviour
{
    public Camera camera;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        int layerMask = 1 << 8;
        layerMask = ~layerMask;
        
        if (Physics.Raycast(transform.localPosition, transform.TransformDirection(camera.gameObject.transform.forward), out hit, Mathf.Infinity, layerMask))
        {
            if (hit.transform.tag == "Mob")
            {
                Debug.DrawRay(transform.localPosition, transform.TransformDirection(camera.gameObject.transform.forward) * hit.distance, Color.yellow);
                Debug.Log("Did Hit");
            }
        }
        else
        {
            Debug.DrawRay(transform.localPosition, transform.TransformDirection(new Vector3(camera.gameObject.transform.position.x, camera.gameObject.transform.position.y, camera.gameObject.transform.position.z + 100)), Color.green);
        }
    }
}

