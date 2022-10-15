using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExteriorHandler : MonoBehaviour
{
    [SerializeField] Transform carExteriorContent;
    [SerializeField] DatabaseSO database;

    private ApplicationManager manager;
    private List<CarModificationSO> carExteriorList;

    private void Awake()
    {
        manager = FindObjectOfType<ApplicationManager>();
    }

    private void OnEnable()
    {
        int currentCarindex = database.carModelDatabase.IndexOf(manager.currentSelectedCar);
        carExteriorList = database.carModelDatabase[currentCarindex].carExteriorModifications;
        manager.PopulateModificationSelectionList(carExteriorList, ModType.Exterior, carExteriorContent);
    }
}
