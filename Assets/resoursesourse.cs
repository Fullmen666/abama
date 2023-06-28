using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resoursesourse : MonoBehaviour
{
    public string resourceName;
    public float value;

    public void CollectResorce(bool destroyObject)
    {
        PlayerResource.Find(resourceName).ChangeValue(value);
        if (destroyObject)
        {
            Destroy(gameObject);
        }
    }
}
 