using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderView : MonoBehaviour
{
    [SerializeField] private MonoBehaviour _sliderCountChangerContainer;
    [SerializeField] private Slider _slider;

    private ISliderCountChanger _sliderCountChanger => (ISliderCountChanger)_sliderCountChangerContainer;

    private void OnValidate()
    {
        if (_sliderCountChangerContainer is ISliderCountChanger)
            return;

        Debug.LogError($"{_sliderCountChangerContainer.name} need to implement {nameof(ISliderCountChanger)}.");
        _sliderCountChangerContainer = null;
    }

    private void OnEnable()
    {
        _sliderCountChanger.SliderCountChanged += OnSliderCountChanged;
    }

    private void OnDisable()
    {
        _sliderCountChanger.SliderCountChanged -= OnSliderCountChanged;
    }

    private void OnSliderCountChanged(int count, int maxCount)
    {
        _slider.value = (float)count / maxCount;
    }
}
