using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public static float bottomY = -20f;

    void Update()
    {
        if (transform.position.y < bottomY)
        {
            Destroy(gameObject);

            ApplePicker ap = Camera.main.GetComponent<ApplePicker>();
            if (ap != null)
            {
                ap.AppleDestroyed();
            }
            else
            {
                Debug.LogError("ApplePicker component not found on Camera.");
            }
        }
    }
}
