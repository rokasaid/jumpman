using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public interface IObserver
    {
        void Update(GameObject gameItem);
    }
}