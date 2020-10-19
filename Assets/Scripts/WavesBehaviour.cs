using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Classes;
using UnityEngine;
using Random = UnityEngine.Random;

public class WavesBehaviour : MonoBehaviour
{
    #region Public props

    /// <summary>
    /// Prefab to create mobs
    /// </summary>
    public GameObject prefab;
    /// <summary>
    /// Min radius for spawn mobs
    /// </summary>
    public float minRadius = 10f;
    /// <summary>
    /// Max radius for spawn mobs
    /// </summary>
    public float maxRadius = 15f;
    /// <summary>
    /// Time (in seconds) between two waves
    /// </summary>
    public int secondsBetweenWave = 15;

    #endregion

    #region Private props

    private int actualLevel = 1;
    private DateTime lastSpawnTime;

    #endregion

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        AddNewWave(GameObject.FindGameObjectsWithTag("Player")[0].transform);
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        var players = GameObject.FindGameObjectsWithTag("Player");
        if (players.Length == 0)
        {
            return;
        }
        var difficulty = secondsBetweenWave - actualLevel;
        if ((DateTime.Now - lastSpawnTime).TotalSeconds >= (difficulty < 3 ? 3 : difficulty))
        {
            AddNewWave(players[0].transform);
        }
    }

    /// <summary>
    /// Generate a wave with game seconds
    /// </summary>
    /// <param name="target">Target for new wave</param>
    public void AddNewWave(Transform target)
    {
        lastSpawnTime = DateTime.Now;
        for (int i = 0; i < actualLevel; i++)
        {
            Vector3 point = RandomPointInAnnulus(target.position, minRadius, maxRadius);
            var mobBehaviour = prefab.GetComponent<MobBehaviour>();
            mobBehaviour.target = target;
            mobBehaviour.level = actualLevel;
            Instantiate(prefab, point, prefab.transform.rotation);
        }

        actualLevel++;
    }

    /// <summary>
    /// Generate a point in annulus
    /// </summary>
    /// <param name="origin">Vector2 of player position</param>
    /// <param name="minRadius">Min radius arround player</param>
    /// <param name="maxRadius">Max radius arround player</param>
    /// <returns></returns>
    public Vector3 RandomPointInAnnulus(Vector2 origin, float minRadius, float maxRadius)
    {
        var randomDirection = (Random.insideUnitCircle * origin).normalized;
        var randomDistance = Random.Range(minRadius, maxRadius);
        var point = origin + randomDirection * randomDistance;
        return new Vector3(point.x, 1, point.y);
    }
}
