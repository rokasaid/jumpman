using UnityEditor;
using UnityEngine;

namespace Assets.Scripts
{
    public class HealhOrbFactory : IGameItemFactory
    {
        public AbstractGameItem FactoryMethod()
        {
            return new HealthOrb();
        }
    }
}