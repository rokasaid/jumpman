using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public interface ICollidable
    {
        PlayerEvent Collide();
    }
}