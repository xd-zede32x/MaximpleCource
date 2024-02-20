using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private int _numberCount;
    [SerializeField] private GameObject _template;

    private void OnValidate()
    {
        if (_numberCount <= 0)
            _numberCount = 1;
    }

    private void Update()
    {
        InputSpawnObject();
        InputDeleteObject();
    }

    private void InputSpawnObject()
    {
        if (Input.GetMouseButtonDown(0))
        {
            int currentChildCount = transform.childCount;

            for (int index = currentChildCount; index < currentChildCount + _numberCount; index++)
            {
                if (index % 2 == 0)
                    continue;

                GameObject spawnedObject = Instantiate(_template, transform);

                spawnedObject.transform.localPosition = new(0, index, 0);
                spawnedObject.transform.localRotation = Quaternion.Euler(0, index * 30, 0);
            }
        }
    }

    private void InputDeleteObject()
    {
        if (Input.GetMouseButtonDown(1))
        {
            int currentChildCount = transform.childCount;

            for (int index = currentChildCount - 1; index >= 0; index--)
                Destroy(transform.GetChild(index).gameObject);
        }
    }
}