using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MoneyCellsInstaller : MonoInstaller
{
    [SerializeField] private Transform _firstPosition;
    [SerializeField] private int _lineCount;
    [SerializeField] private float _spaceBetweenLines;
    [SerializeField] private int _columnCount;
    [SerializeField] private float _spaceBetweenColumns;
    [SerializeField] private int _levelCount;
    [SerializeField] private float _spaceBetweenLevels;

    private List<MoneyCell> _moneyCells = new List<MoneyCell>();

    public override void InstallBindings()
    {
        var currentPosition = _firstPosition.position;

        for (int l = 0; l < _levelCount; l++)
        {
            for (int i = 0; i < _lineCount; i++)
            {
                for (int j = 0; j < _columnCount; j++)
                {
                    var newCell = new MoneyCell(currentPosition);
                    _moneyCells.Add(newCell);
                    currentPosition.x += _spaceBetweenLines;
                }

                currentPosition.z -= _spaceBetweenColumns;
                currentPosition.x = _firstPosition.position.x;
            }

            currentPosition.y += _spaceBetweenLevels;
            currentPosition.x = _firstPosition.position.x;
            currentPosition.z = _firstPosition.position.z;
        }

        Container
            .Bind<IEnumerable<MoneyCell>>()
            .FromInstance(_moneyCells)
            .AsSingle();
    }
}