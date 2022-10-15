using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassHandler : MonoBehaviour
{
    [SerializeField] Transform carGlassContent;
    [SerializeField] DatabaseSO database;

    private ApplicationManager manager;
    private List<CarModificationSO> carGlassList;

    private void Awake()
    {
        manager = FindObjectOfType<ApplicationManager>();
        carGlassList = database.carTyreDatabase;
    }

    private void OnEnable()
    {
        manager.PopulateModificationSelectionList(carGlassList, ModType.Glass, carGlassContent);
    }
}
