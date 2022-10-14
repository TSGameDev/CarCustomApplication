using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Car Model", menuName = "New Car Model", order = 0)]
public class CarModelSO : ScriptableObject
{
    [SerializeField] GameObject carModlePrefab;
    [SerializeField] int price;
    [SerializeField] string carName;
    [Multiline]
    [SerializeField] string carDescription;
    [Multiline]
    [SerializeField] string carStats;
}
