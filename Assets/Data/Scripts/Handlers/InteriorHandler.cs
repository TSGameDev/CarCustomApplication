using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteriorHandler : MonoBehaviour
{
    [SerializeField] Transform carInteriorContent;
    [SerializeField] DatabaseSO database;

    private ApplicationManager manager;
    private List<CarModificationSO> carInteriorList;

    private void Awake()
    {
        manager = FindObjectOfType<ApplicationManager>();
    }

    private void OnEnable()
    {
        int currentCarindex = database.carModelDatabase.IndexOf(manager.currentSelectedCar);
        carInteriorList = database.carModelDatabase[currentCarindex].carInteriorModifications;
        manager.PopulateModificationSelectionList(carInteriorList, ModType.Interior, carInteriorContent);
    }
}
