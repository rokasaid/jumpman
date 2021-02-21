using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Controllers
{
    public class GameStateController : MonoBehaviour
    {
        // Heart sprite settings
        private Vector3 first = new Vector3(75, -75, 0);
        private const float nextX = 100;

        public static GameStateController instance { get; private set; }
        public GameObject player, text, healthSprite, healthAmountCanvas, invisibleWallL, invisibleWallR;
        private Stack<GameObject> healthSprites;
        private int playerHealth;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this);
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            Init();
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        private void Init()
        {
            ClearText();
            healthSprites = new Stack<GameObject>();
            playerHealth = player.GetComponent<Player>().health;
            RenderHealthSprites(playerHealth);
        }

        private void ClearText()
        {
            text.GetComponent<UnityEngine.UI.Text>().text = "";
        }


        public void IncreaseHealth()
        {
            int tempPlayerHealth = player.GetComponent<Player>().health;
            int healthLimit = player.GetComponent<Player>().healthLimit;
            if (tempPlayerHealth < healthLimit)
            {
                player.GetComponent<Player>().health += 1;
                playerHealth = player.GetComponent<Player>().health;
                RenderHealthSprites(playerHealth);
            }
        }

        public void DecreaseHealth()
        {
            int tempPlayerHealth = player.GetComponent<Player>().health;
            int healthLimit = 0;
            if (tempPlayerHealth > healthLimit)
            {
                player.GetComponent<Player>().health -= 1;
                playerHealth = player.GetComponent<Player>().health;
                RenderHealthSprites(playerHealth);
                ReinitialiseGame();
            }
        }

        private void RenderHealthSprites(int health)
        {
            // Remove old sprites.
            int originalCount = healthSprites.Count;
            for (int i = 0; i < originalCount; i++)
            {
                GameObject toRemove = healthSprites.Pop();
                GameObject.Destroy(toRemove);
            }

            // Add the new correct amount.
            for (int i = 0; i < health; i++)
            {
                GameObject newHealthSprite = GameObject.Instantiate(healthSprite, healthAmountCanvas.transform);
                newHealthSprite.SetActive(true);
                newHealthSprite.GetComponent<RectTransform>().anchoredPosition = new Vector2(
                    newHealthSprite.GetComponent<RectTransform>().anchoredPosition.x + (nextX * i),
                    newHealthSprite.GetComponent<RectTransform>().anchoredPosition.y);
                healthSprites.Push(newHealthSprite);
            }
        }

        public void ReinitialiseGame()
        {
            text.GetComponent<UnityEngine.UI.Text>().text = "YOU DIEDED!";
            Time.timeScale = 0;
            StartCoroutine(DoGameOverSequence());
        } 

        public IEnumerator DoGameOverSequence()
        {
            yield return new WaitForSecondsRealtime(2);
            RestartGame();
        }

        private void RestartGame()
        {
            instance.GetComponent<GameInitController>().InitScene();
            Time.timeScale = 1;
            ClearText();
        }
    }
}
