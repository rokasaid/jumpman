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
            InitSpawner();
        }

        // Update is called once per frame
        void Update()
        {

        }

        void InitSpawner()
        {
            // Initialises game item spawner to a location relative to the plane.
            Vector3 groundPos = ground.transform.position;
            Vector3 groundScale = ground.transform.localScale;

            this.transform.position = new Vector3(
                groundPos.x,
                groundPos.y,
                //Mathf.Pow(groundPos.z, 2) * (groundScale.z)
                (groundPos.z + groundScale.z) * 2
            );

            this.transform.localScale = new Vector3(
                1.5f,
                1,
                0.1f
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