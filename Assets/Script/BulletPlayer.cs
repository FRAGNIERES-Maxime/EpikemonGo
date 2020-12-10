using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : MonoBehaviour
{
    public Camera camera = new Camera();
    private Vector3 pos = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        pos = new Vector3(camera.gameObject.transform.position.x, camera.gameObject.transform.position.y, camera.gameObject.transform.position.z + 100);
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 fwd = transform.TransformDirection(camera.gameObject.transform.forward);
        //Debug.DrawRay(camera.gameObject.transform.position, fwd, Color.red);
        RaycastHit hit;
        int layerMask = 1 << 8;
        layerMask = ~layerMask;

        /*if (Physics.Raycast(transform.position, fwd, Mathf.Infinity))
        {
            print("There is something in front of the object!");
        }*/
        
        if (Physics.Raycast(transform.localPosition, transform.TransformDirection(camera.gameObject.transform.forward), out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(transform.localPosition, transform.TransformDirection(camera.gameObject.transform.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
        }
        else
        {
            //Debug.DrawRay(transform.localPosition, transform.TransformDirection(camera.gameObject.transform.forward), Color.green);
            Debug.DrawRay(transform.localPosition, transform.TransformDirection(new Vector3(camera.gameObject.transform.position.x, camera.gameObject.transform.position.y, camera.gameObject.transform.position.z + 100)), Color.green);
        }
    }
}

