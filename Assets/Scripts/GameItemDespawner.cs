using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameItemDespawner : MonoBehaviour
    {
        public GameObject ground;
        private List<GameObject> gameItems = new List<GameObject>();

        // Start is called before the first frame update
        void Start()
        {
            InitDespawner();
        }

        // Update is called once per frame
        void Update()
        {

        }

        void InitDespawner()
        {
            /* Initialises game item spawner to a location relative to the plane.
             * 
             * WARNING, UNITY MAKES AN ARBITRATY DECISION FOR PLANE SCALING AND 
             * DOES NOT ATTEMPT TO NOTIFY YOU ABOUT IT.
             * 
             * Scaling a unit on a plane is 10x the scale on a 3d object like a cube, meaning
             * if we want to place a 3d object to a position relative of a plane, we must take
             * into account that the units are 10x greater.
             * 
             * Tl;dr - use groundScale * 5 to position the spawner.
             */
            Vector3 groundPos = ground.transform.position;
            Vector3 groundScale = ground.transform.localScale;
            float despawnerScaleY = 5;

            this.transform.position = new Vector3(
                groundPos.x,
                groundPos.y + (despawnerScaleY / 2),
                -groundScale.z * (10 / 2) // ???
            );
            this.transform.localScale = new Vector3(
                groundScale.x * 10,
                despawnerScaleY,
                1
            );
        }


        public List<GameObject> CleanGameItems()
        {
            gameItems.ForEach(gameItem => GameObject.Destroy(gameItem));
            gameItems = new List<GameObject>();
            return gameItems;
        }
    }
}