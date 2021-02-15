using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public interface IGameItemFactory
    {
        AbstractGameItem FactoryMethod();
    }
}