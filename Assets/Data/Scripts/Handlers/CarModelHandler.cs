using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarModelHandler : MonoBehaviour
{
    [SerializeField] Transform carListContents;
    [SerializeField] DatabaseSO database;

    private ApplicationManager manager;
    private List<CarModelSO> carList;

    private void Awake()
    {
        manager = FindObjectOfType<ApplicationManager>();
        carList = database.carModelDatabase;

        manager.PopulateCarSelectionList(carList, carListContents);
    }
}
