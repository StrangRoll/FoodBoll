using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class FoodBlockPositionsInstaller : MonoInstaller
{
    [SerializeField] private Transform _firstPosition;
    [SerializeField] private Transform _lastPosition;
    [SerializeField] private int _blocksInLine;
    [SerializeField] private int _blocksInColumn;

    private List<Vector2> _startPositions;
    private Vector2 _blockDimensions;

    public override void InstallBindings()
    {
        var deltaPositionX = _lastPosition.position.x - _firstPosition.position.x;
        var deltaPositionZ = _firstPosition.position.z - _lastPosition.position.z;
        var blockWidth = deltaPositionX / _blocksInLine;
        var blockHeight = deltaPositionZ / _blocksInColumn;
        _startPositions = new List<Vector2>();
        _blockDimensions = new Vector2(blockWidth, blockHeight);

        for (int i = 0; i < _blocksInLine; i++)
        {
            for (int j = 0; j < _blocksInColumn; j++)
            {
                var xStartPosition = _firstPosition.position.x + blockWidth * i;
                var zStartPosition = _firstPosition.position.z - blockHeight * j;
                _startPositions.Add(new Vector2(xStartPosition, zStartPosition));
            }
        }

        Container
            .Bind<Vector2[]>()
            .WithId(ZenjectId.FoodPosition)
            .FromInstance(_startPositions.ToArray());

        Container
            .Bind<Vector2>()
            .WithId(ZenjectId.FoodPosition)
            .FromInstance(_blockDimensions);
    }
}

