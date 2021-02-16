using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public abstract class AbstractGameItem : MonoBehaviour
    {
        private float speed = -5f;
        public abstract PlayerEvent Collide();
        public abstract void PlaySound();

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            MoveGameItem(speed);
        }

        /*
         TEMPLATE METHOD.
         */
        private void OnTriggerEnter(Collider other)
        {
            Collide();
            PlaySound();
            GameObject.Destroy(this.gameObject);
        }


        private void MoveGameItem(float speed)
        {
            var direction = new Vector3(0, 0, speed * Time.deltaTime);
            this.gameObject.transform.position += direction;
        }
        
        public void UpdateSpeed(float amount)
        {
            speed -= amount;
        }
    }
}