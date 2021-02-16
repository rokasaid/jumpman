using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public abstract class ObservableBase : MonoBehaviour
    {

        public abstract void Attach(IObserver observer);
        public abstract void Detach(IObserver observer);
        public abstract void Notify(GameObject toDestroy);

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}