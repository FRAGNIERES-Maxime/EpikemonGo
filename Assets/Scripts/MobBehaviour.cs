﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Classes
{
    public class MobBehaviour : MonoBehaviour
    {
        #region Public props

        /// <summary>
        /// Name of mob
        /// </summary>
        public new string name = "Undefined";
        /// <summary>
        /// Speed of mob
        /// </summary>
        public float speed = 1;
        /// <summary>
        /// Size of mob
        /// </summary>
        public float size = 0.75f;
        /// <summary>
        /// Level of mob (impact damage and life)
        /// </summary>
        public int level = 1;
        /// <summary>
        /// Set target of mob
        /// </summary>
        public Transform target;
        /// <summary>
        /// Represent the game health bar
        /// </summary>
        public HealthBar healthBar;

        #endregion

        #region Private props

        /// <summary>
        /// Get initial life
        /// </summary>
        private int initialLife => (int)(level * 2 * size);
        /// <summary>
        /// Get currentLife
        /// </summary>
        private int currentLife { get; set; }

        #endregion

        /// <summary>
        /// Start is called before the first frame update
        /// </summary>
        void Start()
        {
            currentLife = initialLife;
            healthBar.SetMaxHealth(initialLife);
            gameObject.transform.localScale = new Vector3(size, size, size);
        }

        /// <summary>
        /// Update is called once per frame to move mob into player position
        /// </summary>
        void Update()
        {
            if (target != null)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
        }

        /// <summary>
        /// Generate damage of 
        /// </summary>
        /// <returns></returns>
        public int GetDamage()
        {
            return (int)(level * size);
        }

        /// <summary>
        /// Method to lose life of a value
        /// </summary>
        /// <param name="value">Value to lose</param>
        public void LoseLife(int value)
        {
            currentLife -= value;
            healthBar.SetHealth(currentLife);
            if (currentLife <= 0)
            {
                gameObject.SetActive(false);
                Destroy(gameObject);
            }
        }
    }
}
