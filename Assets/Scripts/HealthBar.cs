using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxHealth(float max) => slider.maxValue = max;
    public void SetHealth(float value) => slider.value = value;

}