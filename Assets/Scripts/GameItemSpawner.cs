using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameItemSpawner : MonoBehaviour
    {
        public GameObject ground, obstacle, healthOrb, player;
        private List<GameObject> gameItems = new List<GameObject>();

        // Start is called before the first frame update
        void Start()
        {
            InitSpawner();
            StartCoroutine(StartSpawningGameItems());
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
                groundPos.y + 1.5f,
                groundPos.z * Mathf.Pow(groundScale.z, 2)
            );

            this.transform.localScale = new Vector3(
                groundScale.x,
                1,
                0.1f
            );
        }

        private List<GameObject> SpawnGameItems(List<GameObject> gameItems, GameObject gameItemToSpawn)
        {
            Vector3 spawnerPos = this.transform.position;
            Vector3 spawnerScale = this.transform.localScale;

            GameObject spawnedGameItem = GameObject.Instantiate(gameItemToSpawn);
            spawnedGameItem.SetActive(true);

            // Randomise x position of spawned game item.
            spawnedGameItem.transform.position = new Vector3(
                Random.Range(-(spawnerPos.x * Mathf.Pow(spawnerScale.x, 2)), (spawnerPos.x * Mathf.Pow(spawnerScale.x, 2))) + spawnedGameItem.transform.localScale.x,
                spawnerPos.y,
                spawnerPos.z
            );

            gameItems.Add(spawnedGameItem);
            return gameItems.Where(gameItem => gameItem != null).ToList();
        }

        public List<GameObject> CleanGameItems()
        {
            gameItems.ForEach(gameItem => GameObject.Destroy(gameItem));
            gameItems = new List<GameObject>();
            return gameItems;
        }

        
        IEnumerator StartSpawningGameItems()
        {
            while (true)
            {
                // Randomly decide what to spawn.
                float rnJesus = Random.Range(0, 10);

                if (rnJesus < 9)
                    // Spawn Obstacle.
                    gameItems = SpawnGameItems(gameItems, obstacle);                
                else
                    // Spawn Health orb
                    gameItems = SpawnGameItems(gameItems, healthOrb);
                
                yield return new WaitForSeconds(1.5f);
            }

        }
    }
}