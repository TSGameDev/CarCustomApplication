using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Car Modification", menuName = "New Car Modification", order = 1)]
public class CarModificationSO : ScriptableObject
{
    [SerializeField] Material modificationMat;
    [SerializeField] int modficationPrice;
    [SerializeField] string carModificationName;
    [Multiline]
    [SerializeField] string carModificationDescription;
}
