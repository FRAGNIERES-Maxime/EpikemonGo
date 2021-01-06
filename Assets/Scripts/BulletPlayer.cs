using System.Collections;
using System.Collections.Generic;
using Assets.Classes;
using UnityEngine;

public class BulletPlayer : MonoBehaviour
{
    public Camera camera;
    public GameObject EndPointLightning;
    public GameObject Lightning;
    private bool canDamage = false;
    private GameObject CurrentMob;

    // Start is called before the first frame update
    void Start()
    {
        Lightning.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        int layerMask = 1 << 8;
        layerMask = ~layerMask;
        Ray ray = camera.ViewportPointToRay(new Vector3(0, 0, 200f));

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.tag == "Mob")
            {
                Debug.Log("Did Hit");
                CurrentMob = hit.transform.gameObject;
                canDamage = true;
                EndPointLightning.gameObject.transform.position = hit.transform.gameObject.transform.position;
                Lightning.gameObject.SetActive(true);
            }
        }
        else
        {
            canDamage = false;
            CurrentMob = null;
            Lightning.gameObject.SetActive(false);
        }
    }

    IEnumerator TouchMob()
    {
        while (canDamage)
        {
            CurrentMob.gameObject.GetComponent<MobBehaviour>().LoseLife(10);
            yield return new WaitForSeconds(0.1f);
        }
        yield return null;
    }
}

