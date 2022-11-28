using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KaiCi
{
    public class Memory
    {
        public static KeyCode interactKey = KeyCode.E;

        public static MoveKeyCode moveKeyCode = new MoveKeyCode();
        public static SkillKeyCode skillKeyCode = new SkillKeyCode();

        public static KeyCode jump = KeyCode.Space;

        public static string playerTag = "Player";
        public static string playerHidingTag = "PlayerHiding";

        public static string AnimationWalkName = "Walk";
        public static string AnimationIdleName = "Idle";
        public static string AnimationMorphingName = "Morphing";
        public static string AnimationExitMorphingName = "ExitMorphing";
    }

    public class MoveKeyCode
    {
        public KeyCode moveLeft = KeyCode.A;
        public KeyCode moveRight = KeyCode.D;
        public KeyCode moveUp = KeyCode.W;
        public KeyCode moveDown = KeyCode.S;
    }

    public class SkillKeyCode
    {
        public KeyCode[] slots = { KeyCode.Mouse0, KeyCode.Mouse1 };
    }
}