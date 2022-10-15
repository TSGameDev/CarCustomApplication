using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Database", menuName = "New Database", order = 2)]
public class DatabaseSO : ScriptableObject
{
    public List<CarModelSO> carModelDatabase;
    public List<CarModificationSO> carTyreDatabase;
    public List<CarModificationSO> carGlassDatabase;
}
