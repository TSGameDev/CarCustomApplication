using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TyreHandler : MonoBehaviour
{
    [SerializeField] Transform carTyreContent;
    [SerializeField] DatabaseSO database;

    private ApplicationManager manager;
    private List<CarModificationSO> carTyreList;

    private void Awake()
    {
        manager = FindObjectOfType<ApplicationManager>();
        carTyreList = database.carTyreDatabase;
    }

    private void OnEnable()
    {
        manager.PopulateModificationSelectionList(carTyreList, ModType.Tyres, carTyreContent);
    }
}
