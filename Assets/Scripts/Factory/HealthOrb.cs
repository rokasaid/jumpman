using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    
    public class HealthOrb : AbstractGameItem
    {
        public override PlayerEvent Collide()
        {
            return PlayerEvent.HealthOrbEvent;
        }

        public override void PlaySound()
        {
            throw new System.NotImplementedException();
        }
    }
}