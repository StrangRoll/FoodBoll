using UnityEngine;
using UnityEngine.UI;

public class WayFinderAnimation : MonoBehaviour
{
    [SerializeField] private RawImage _wayImage;
    [SerializeField] private float _animationSpeed;

    void Update()
    {
        var imageUVRect = new Rect(_wayImage.uvRect.x, _wayImage.uvRect.y - _animationSpeed * Time.deltaTime, _wayImage.uvRect.width, _wayImage.uvRect.height);
        _wayImage.uvRect = imageUVRect;
    }
}
