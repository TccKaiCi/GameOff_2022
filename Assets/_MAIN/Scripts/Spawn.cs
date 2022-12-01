using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KaiCi
{
    public class Spawn : MonoBehaviour
    {
        public static Spawn instance;

        private void Awake()
        {
            instance = this;
        }
    }
}