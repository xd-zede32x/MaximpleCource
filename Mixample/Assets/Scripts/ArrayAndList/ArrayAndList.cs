using UnityEngine;

public class ArrayAndList : MonoBehaviour
{
    [SerializeField] private int[,] _array;

    private void Start()
    {
        _array = new int[10, 10];

        for (int i = 0; i < _array.GetLength(0); i++)
        {
            for (int j = 0; j < _array.GetLength(1); j++)
            {
                _array[i, j] = i * _array.GetLength(0) + j;
                Debug.Log(_array[i, j]);
            }
        }
    }
}