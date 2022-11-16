using System.Collections;
using System.Collections.Generic;
using MyBox;
using UnityEngine;

namespace KaiCi
{
    [System.Serializable]
    public struct PatrolSetting
    {
        public WayPoint wayPoint;
        public int childPositionInParent;
    }

    [CreateAssetMenu(fileName = "PatrolSettings", menuName = "GameOff_2022/PatrolSettings", order = 0)]
    public class PatrolSettings : ScriptableObject
    {
        public PatrolSetting[] wayPoint;
        public int wayPointLength => wayPoint.Length;
    }
}
