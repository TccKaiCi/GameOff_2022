using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KaiCi
{
    public static class BetterAttibute
    {
        public static void SetDisplayChildObject(this Transform transform, int pos, int poss, bool status)
        {
            transform.GetChild(pos).SetDisplayChildObject(poss, status);
        }

        public static void SetDisplayChildObject(this Transform transform, int pos, bool status)
        {
            transform.GetChild(pos).gameObject.SetActive(status);
        }
    }

}
