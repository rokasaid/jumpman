using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Controllers
{
    public class GameInitController : MonoBehaviour
    {
        public GameObject character, gameItemSpawner, gameItemDespawner, text;

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
            character.transform.position = characterPosition;       // Reset character position
            gameItemSpawner.GetComponent<GameItemSpawner>().CleanGameItems();     // Remove all boxes
            text.GetComponent<UnityEngine.UI.Text>().text = "";     // Reset UI text
        }
    }
}