using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public Slider slider;
    public HealthSystem hs;

    void Update()
    {
        slider.value = hs.playerHealth;
    }
}
