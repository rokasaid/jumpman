using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody characterObject;
        private bool flight;
        public bool killed { get; private set; }

        // Start is called before the first frame update
        void Start()
        {
            killed = false;
            flight = false;
            characterObject = this.gameObject.GetComponent<Rigidbody>();
            Physics.gravity *= 2;
        }

        // Update is called once per frame
        void LateUpdate()
        {
            Vector3 totalVector = Vector3.zero;

            if (Input.GetKeyDown(KeyCode.Space) && !flight)
            {
                Debug.Log("update" + Time.time + " ");
                totalVector += new Vector3(0, 10, 0);
            }
            if (characterObject.velocity.x > -5 && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)))
            {
                totalVector += new Vector3(-0.1f, 0, 0);
            }
            else if (characterObject.velocity.x < 5 && (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)))
            {
                totalVector += new Vector3(0.1f, 0, 0);
            }

            characterObject.velocity += totalVector;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.gameObject.GetComponent<MeshFilter>().mesh.name.Contains("Plane"))
            {
                flight = false;
                characterObject.velocity = new Vector3(characterObject.velocity.x, 0, characterObject.velocity.z);
            }

            if (PlayerEvent.HealthOrbEvent.Equals(collision.collider.gameObject.GetComponent<AbstractGameItem>()?.Collide()))
            {
                Controllers.GameStateController.instance.IncreaseHealth();
                GameObject.Destroy(collision.collider.gameObject);
            }
            else if (PlayerEvent.ObstacleEvent.Equals(collision.collider.gameObject.GetComponent<AbstractGameItem>()?.Collide()))
            {
                Controllers.GameStateController.instance.DecreaseHealth();
            }
            else if (PlayerEvent.InvisibleWallEvent.Equals(collision.collider.gameObject.GetComponent<InvisibleWall>()?.Collide())){
                float tempCharacterVelocityX = characterObject.velocity.x;
                characterObject.velocity = new Vector3(collision.relativeVelocity.x * -2, 0, 0);
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.collider.gameObject.GetComponent<MeshFilter>().mesh.name.Contains("Plane")) flight = true;
        }
    }
}

