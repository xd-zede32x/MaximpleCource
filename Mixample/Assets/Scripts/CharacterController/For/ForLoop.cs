using UnityEngine;

public class ForLoop : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            for (int index = 0; index < 11; index++)
            {
                if (index == 10)
                    continue;

                Debug.Log("Цикл for работает нормально! " + index);
            }

            Debug.Log("For loop has been finished");
        }
    }
}