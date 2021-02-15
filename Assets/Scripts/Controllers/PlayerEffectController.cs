using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class PlayerEffectController : MonoBehaviour
    {
        public static PlayerEffectController instance { get; private set; }
        public GameObject player, text;

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
            
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}