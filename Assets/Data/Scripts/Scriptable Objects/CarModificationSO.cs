using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ModType
{
    Exterior,
    Interior,
    Tyres,
    Glass
}

[CreateAssetMenu(fileName = "New Car Modification", menuName = "New Car Modification", order = 1)]
public class CarModificationSO : ScriptableObject
{
    public Material modificationMat;
    public ModType modType;
    public int modficationPrice;
    public string carModificationName;
    [Multiline]
    public string carModificationDescription;
}
