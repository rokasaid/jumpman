using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Player : MonoBehaviour
    {
        public int health { get; set; }
        public int healthLimit { get; private set; }

        void Awake()
        {
            health = 3;
            healthLimit = 5;
        }
        
        // Use this for initialization
        void Start()
        {
           
        }

        // Update is called once per frame
        void Update()
        {

        }

        
    }
}