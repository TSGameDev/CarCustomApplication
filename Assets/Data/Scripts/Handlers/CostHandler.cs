using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CostHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI carCostTxt;
    [SerializeField] TextMeshProUGUI modificationCostTxt;
    [SerializeField] TextMeshProUGUI totalCostTxt;

    private ApplicationManager manager;
    private int carCost;
    private int modificationCost;
    private int totalCost;

    private void Awake()
    {
        manager = FindObjectOfType<ApplicationManager>();
    }

    public void UpdateCarCost(CarModelSO newCar)
    {
        carCost = newCar.price;
        carCostTxt.text = $"Car Cost: ${carCost}";
        UpdateTotalCost();
    }

    public void UpdateModificationCost(CarModificationSO newMod, ModType mod)
    {
        switch(mod)
        {
            case ModType.Exterior:
                if (manager.currentSelectedExterior != null)
                    modificationCost -= manager.currentSelectedExterior.modficationPrice;
                modificationCost += newMod.modficationPrice;
                break;
            case ModType.Interior:
                if (manager.currentSelectedInterior != null)
                    modificationCost -= manager.currentSelectedInterior.modficationPrice;
                modificationCost += newMod.modficationPrice;
                break;
            case ModType.Tyres:
                if (manager.currentSelectedTyres != null)
                    modificationCost -= manager.currentSelectedTyres.modficationPrice;
                modificationCost += newMod.modficationPrice;
                break;
            case ModType.Glass:
                if (manager.currentSelectedGlass != null)
                    modificationCost -= manager.currentSelectedGlass.modficationPrice;
                modificationCost += newMod.modficationPrice;
                break;
        }
        modificationCostTxt.text = $"Modification Cost: ${modificationCost}";
        UpdateTotalCost();
    }

    private void UpdateTotalCost()
    {
        totalCost = carCost + modificationCost;
        totalCostTxt.text = $"Total Cost: ${totalCost}";
    }
}
