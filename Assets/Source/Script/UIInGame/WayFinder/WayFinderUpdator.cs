using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class WayFinderUpdator : MonoBehaviour
{
    [Inject] private SphereMovier _sphere;

    [SerializeField] private RawImage _wayImage;
    [SerializeField] private Transform _target;

    private Vector3 _targetPosition;
    private Quaternion _startRotation;
    private float _imageHeight;

    private void Awake()
    {
        _targetPosition = _target.position;
        _imageHeight = _wayImage.GetComponent<RectTransform>().sizeDelta.y;
        Quaternion myRotation = Quaternion.identity;
        _startRotation = _wayImage.transform.localRotation;
    }

    private void Update()
    {
        var way = UpdatePositionAndGetWay();
        UpdateRotation(way);
        UpdateUVRect(way);
        UpdateImageHeight(way);
    }

    private Vector3 UpdatePositionAndGetWay()
    {
        Vector3 wayImagePosition = new Vector3(_sphere.transform.position.x, _wayImage.transform.position.y, _sphere.transform.position.z);
        _wayImage.transform.position = wayImagePosition;
        Vector3 way = _targetPosition - wayImagePosition;
        return way;
    }

    private void UpdateRotation(Vector3 way)
    {
        float imageRotationZ = Mathf.Atan2(way.z, way.x) * Mathf.Rad2Deg;
        Vector3 wayImageRotation = new Vector3(_wayImage.transform.localRotation.x, _wayImage.transform.localRotation.y, imageRotationZ);
        _wayImage.transform.localRotation = Quaternion.Euler(wayImageRotation);
        _wayImage.transform.localRotation *= _startRotation;
    }

    private void UpdateUVRect(Vector3 way)
    {
        var imageUVRect = new Rect(_wayImage.uvRect.x, _wayImage.uvRect.y, _wayImage.uvRect.width, way.magnitude / _imageHeight);
        _wayImage.uvRect = imageUVRect;
    }

    private void UpdateImageHeight(Vector3 way)
    {
        var rectTransfom = _wayImage.GetComponent<RectTransform>();
        var newSize = new Vector2(rectTransfom.sizeDelta.x, way.magnitude);
        rectTransfom.sizeDelta = newSize;
    }
}
