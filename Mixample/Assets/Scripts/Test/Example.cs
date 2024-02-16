using UnityEngine;
using System.Collections;

public class Example : MonoBehaviour
{
    private void Start() => StartCoroutine(PrintHello());
    private void Update() => Debug.Log(Time.deltaTime);

    private IEnumerator PrintHello()
    {
        yield return new WaitForSeconds(3);
        Debug.Log("Hello");
    }
}