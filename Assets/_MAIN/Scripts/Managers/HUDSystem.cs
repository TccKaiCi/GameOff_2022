using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyBox;

namespace KaiCi
{
    public class HUDSystem : Singleton<HUDSystem>
    {
        [MustBeAssigned] public HealthBar healthBar;
        [MustBeAssigned] public GameObject gameWinPanel;

        public void ShowGameWinPanel()
        {
            gameWinPanel.SetActive(true);
        }

    }
}