using UnityEngine.Events;

public interface ISliderCountChanger
{
    public event UnityAction<int, int> SliderCountChanged;
}