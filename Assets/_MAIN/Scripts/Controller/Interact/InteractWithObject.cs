using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KaiCi
{
    public abstract class InteractWithObject : MonoBehaviour
    {
        protected bool isIntractable;

        protected void Start()
        {
            isIntractable = false;
        }

        private void Update()
        {
            if (!isIntractable) return;

            if (Input.GetKeyDown(Memory.interactKey))
            {
                PLayInteraction();
            }
        }

        protected abstract void PLayInteraction();
    }
}
