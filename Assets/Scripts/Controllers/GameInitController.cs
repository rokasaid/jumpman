using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Controllers
{
    public class GameInitController : MonoBehaviour
    {
        public GameObject character, gameItemSpawner, gameItemDespawner, ground, invisibleWall, text;

        private readonly Vector3 characterPosition = new Vector3(2.88f, 1.4f, -9.99f);

        // Start is called before the first frame update
        void Start()
        {
            InitScene();
            // Attach observers.
            gameItemDespawner.GetComponent<ObservableBase>().Attach(gameItemSpawner.GetComponent<IObserver>());
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void InitScene()
        {
            InitInvisibleWalls();
            character.transform.position = characterPosition;       // Reset character position
            gameItemSpawner.GetComponent<GameItemSpawner>().CleanGameItems();     // Remove all boxes
            text.GetComponent<UnityEngine.UI.Text>().text = "";     // Reset UI text
        }

        private void InitInvisibleWalls()
        {
            Vector3 groundPos = ground.transform.position;
            Vector3 groundScale = ground.transform.localScale;
            float wallThickness = 1;
            float wallHeight = 10;

            GameObject invisibleWallL = GameObject.Instantiate(invisibleWall);
            GameObject invisibleWallR = GameObject.Instantiate(invisibleWall);

            invisibleWallL.SetActive(true);
            invisibleWallR.SetActive(true);

            // Position and scale LEFT wall relative to the ground.
            invisibleWallL.transform.localScale = new Vector3(
                wallThickness,      // Thickness    
                wallHeight,         // Height
                groundScale.z * 10  // Width 
            );

            invisibleWallL.transform.position = new Vector3(
                -(groundPos.x + ((groundScale.x * 10) / 2) + (wallThickness / 2)),
                groundPos.y + (wallHeight / 2),
                groundPos.z
            );

            // Position and scale RIGHT wall relative to the ground.
            invisibleWallR.transform.localScale = new Vector3(
                wallThickness,      // Thickness    
                wallHeight,         // Height
                groundScale.z * 10  // Width 
            );

            invisibleWallR.transform.position = new Vector3(
                groundPos.x + ((groundScale.x * 10) / 2) + (wallThickness / 2),
                groundPos.y + (wallHeight / 2),
                groundPos.z
            );
        }
    }
}