using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class InvisibleWall : MonoBehaviour, ICollidable
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        private void OnTriggerEnter(Collider other) {
            Collide();
        }


        public PlayerEvent Collide()
        {
            return PlayerEvent.InvisibleWallEvent;
        }
    }
}