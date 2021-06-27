using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calculation : MonoBehaviour
{
    public static Vector3 Addition(int maxSum)
    {
        int z = Random.Range(1, maxSum);
        int x = Random.Range(1, z - 1);
        int y = z - x;
        return new Vector3(x, y, z);
    }
}
