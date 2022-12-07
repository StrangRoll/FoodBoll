using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private int[] _positions;

    public int[] ParticipatingStartPositions { get; private set; }

    private void Awake()
    {
        ParticipatingStartPositions = _positions;
    }
}
