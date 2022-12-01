using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KaiCi
{
    public class PlayerSystem : Singleton<PlayerSystem>
    {
        public HealthBar healthBar;

        public void AddOneHearth()
        {
            healthBar.AddOneHearth();
        }

        public void DeleteOneHearth()
        {
            healthBar.DeleteOneHearth();
        }
    }
}
