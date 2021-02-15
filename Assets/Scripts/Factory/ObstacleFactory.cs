using UnityEditor;
using UnityEngine;

namespace Assets.Scripts
{
    public class ObstacleFactory : IGameItemFactory
    {
        public AbstractGameItem FactoryMethod()
        {
            return new Obstacle();
        }
    }
}