using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMob : MonoBehaviour
{
    /// <summary>
    /// Property to know mob speed
    /// </summary>
    public float speed;

    /// <summary>
    /// Property to know how much damage does mob
    /// </summary>
    public int damage = 1;

    /// <summary>
    /// Property to know mob life (second to kill)
    /// </summary>
    public float life = 1;

    /// <summary>
    /// Property to get target (player or other)
    /// </summary>
    public Transform target;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        
    }

    /// <summary>
    /// Update is called once per frame to move mob into player position
    /// </summary>
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }
}
