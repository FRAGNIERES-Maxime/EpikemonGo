using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    /// <summary>
    /// Property to store player life points
    /// </summary>
    public int life = 10;

    /// <summary>
    /// Method called when Player object is loaded
    /// </summary>
    void Start()
    {
        
    }

    /// <summary>
    /// Method to trigger when enemy hit
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Mob"))
        {
            var mob = other.GetComponent<BasicMob>();
            if (mob != null)
            {
                GetDamage(mob);
            }
            other.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// Get damage from mob
    /// </summary>
    /// <param name="mob">Mob hited by</param>
    private void GetDamage(BasicMob mob)
    {
        life -= mob.damage;
    }
}
