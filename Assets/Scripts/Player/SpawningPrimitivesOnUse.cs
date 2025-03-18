using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningPrimitivesOnUse : MonoBehaviour, IUsingControllable
{
    public void Use()
    {
        GameObject newGO = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        newGO.transform.position = transform.position;
    }
}
