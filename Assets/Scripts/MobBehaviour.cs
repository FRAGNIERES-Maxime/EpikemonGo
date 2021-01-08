using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Cryptography;
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
        public string name = "Undefined";
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

        #endregion

        #region Private props

        /// <summary>
        /// Get initial life
        /// </summary>
        private int initialLife => (int)(level * 50 * size);
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
            gameObject.transform.localScale = new Vector3(size, size, size);
        }

        /// <summary>
        /// Update is called once per frame to move mob into player position
        /// </summary>
        void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            transform.LookAt(target);
            //transform.Rotate() = new Vector3(transform.eulerAngles.x - 90, transform.eulerAngles.y, transform.eulerAngles.z);
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
            if (currentLife <= 0)
            {
                //gameObject.SetActive(false);
                gameObject.Destroy();
            }
        }
    }
}
