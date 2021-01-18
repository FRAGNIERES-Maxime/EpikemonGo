using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public GameObject camera;

    private bool StartHit;
    private float TimeLeft = 2f;
    void Start()
    {
        
    }

    // Start is called before the first frame update
    void Update()
    {
        RaycastHit hit;
        int layerMask = 1 << 8;
        layerMask = ~layerMask;
        Ray ray = new Ray(camera.transform.position, camera.transform.forward * 100);

        if (Physics.Raycast(ray, out hit))
        {
            switch (hit.transform.tag)
            {
                case "Start":
                StartHit = true;
                TimeLeft -= Time.deltaTime;
                if (TimeLeft <= 0)
                {
                   SceneManager.LoadScene(1);
                }
                break;
            }
        }
        else
        {
            StartHit = false;
            TimeLeft = 2f;
        }
    }
}
