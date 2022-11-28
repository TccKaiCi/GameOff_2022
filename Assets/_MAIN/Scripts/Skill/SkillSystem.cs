using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KaiCi
{
    public class SkillSystem : MonoBehaviour
    {
        public Skill[] listSkill;

        private void Update()
        {
            GatherInput();
        }

        private void GatherInput()
        {
            for (int i = 0; i < Memory.skillKeyCode.slots.Length; i++)
            {
                if (Input.GetKeyDown(Memory.skillKeyCode.slots[i]))
                {
                    UseSkill(i);
                }
            }
        }

        private void UseSkill(int position)
        {
            if (listSkill[position] is null) return;

            listSkill[position].Use();
        }
    }
}
