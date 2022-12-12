using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class UISlider : MonoBehaviour
{
    private Slider slider;
    [SerializeField] private float maxValue = 100;
    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    public void UpdateSliderValue(float val)
    {
        slider.value = val / maxValue;
    }
}
