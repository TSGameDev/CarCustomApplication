using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Car Model", menuName = "New Car Model", order = 0)]
public class CarModelSO : ScriptableObject
{
    public GameObject carModlePrefab;
    public int price;
    public string carName;
    [Multiline]
    public string carDescription;
    [Multiline]
    public string carStats;
    public List<CarModificationSO> carExteriorModifications;
    public List<CarModificationSO> carInteriorModifications;

}
