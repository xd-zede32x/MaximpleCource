using UnityEngine;
using System.Linq;
using System.Collections.Generic;

namespace Foreach
{
    public class ForeachLoop : MonoBehaviour
    {
        [SerializeField] private List<int> _integerList;
        [SerializeField] private int[] _integerArray = new int[] { 6, 7, 8, 9, 10 };

        private void Start()
        {
            _integerList.Clear();
            _integerList = new List<int>(Enumerable.Range(1, 10));
            _integerList.Add(5);
            _integerList.AddRange(_integerList);
            _integerList.Remove(5);
            _integerList.RemoveAt(2);
            _integerList.Clear();

            for (int index = _integerList.Count - 1; index >= 0; index--)
                _integerList.Remove(_integerList[index]);

            foreach (int integer in _integerList)
                Debug.Log(integer);
        }
    }
}