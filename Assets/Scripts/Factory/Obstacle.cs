using UnityEditor;
using UnityEngine;

namespace Assets.Scripts
{
    public class Obstacle : AbstractGameItem
    {
        public override PlayerEvent Collide()
        {
            return PlayerEvent.ObstacleEvent;
        }

        public override void PlaySound()
        {
            // Added a comment.
            throw new System.NotImplementedException();
        }
    }
}