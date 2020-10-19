using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Classes;
using UnityEngine;

public class WavesBehaviour : MonoBehaviour
{
    public GameObject prefab;
    public float minRadius = 10f;
    public float maxRadius = 15f;
    private int actualLevel = 10;

    /// <summary>
    /// List of waves
    /// </summary>
    private List<Wave> Waves = new List<Wave>();

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        for (int i = 0; i < actualLevel; i++)
        {
            var player = GameObject.FindGameObjectsWithTag("Player")[0].transform;
            Vector3 point = RandomPointInAnnulus(player.position, minRadius, maxRadius);
            var mobBehaviour = prefab.GetComponent<MobBehaviour>();
            mobBehaviour.target = player;
            Instantiate(prefab, point, prefab.transform.rotation);
        }
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        
    }

    /// <summary>
    /// Generate a wave with game seconds
    /// </summary>
    /// <param name="seconds"></param>
    public void AddNewWave(int seconds)
    {

    }

    public Vector3 RandomPointInAnnulus(Vector2 origin, float minRadius, float maxRadius)
    {
        var randomDirection = (Random.insideUnitCircle * origin).normalized;
        var randomDistance = Random.Range(minRadius, maxRadius);
        var point = origin + randomDirection * randomDistance;
        return new Vector3(point.x, 1, point.y);
    }
}
