using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ApplicationManager : MonoBehaviour
{
    public CarModelSO currentSelectedCar;

    [SerializeField] GameObject selectionPrefab;
    [SerializeField] Transform carModelSpawnPoint;

    [SerializeField] List<GameObject> uiMenus;
    [SerializeField] GameObject currentUI;
    public int menuNumber = 0;

    private GameObject currentCarModel;
    private GameObject currentCarExterior;
    private GameObject currentCarInterior;
    private GameObject currentCarGlass;
    private List<GameObject> currentCarTyres = new();

    public void PopulateCarSelectionList(List<CarModelSO> carList, Transform content)
    {
        for (int i = 0; i <= carList.Count - 1; i++)
        {
            CarModelSO carModel = carList[i];
            GameObject creation = Instantiate(selectionPrefab, content);

            creation.GetComponentInChildren<TextMeshProUGUI>().text = carModel.carName;
            creation.GetComponent<Button>().onClick.AddListener(() =>
            {
                GameObject Temp = Instantiate(carModel.carModlePrefab, carModelSpawnPoint);
                Destroy(currentCarModel);
                currentCarModel = Temp;
                currentSelectedCar = carModel;
                DefiningCarParts();
            });
        }
    }

    private void DefiningCarParts()
    {
        List<Transform> carParts = currentCarModel.GetComponentsInChildren<Transform>().ToList();
        foreach (Transform carPart in carParts)
        {
            string carPartTag = carPart.gameObject.tag;
            switch(carPartTag)
            {
                case "CarBody":
                    currentCarExterior = carPart.gameObject;
                    break;
                case "CarInterior":
                    currentCarInterior = carPart.gameObject;
                    break;
                case "CarGlass":
                    currentCarGlass = carPart.gameObject;
                    break;
                case "CarTyre":
                    currentCarTyres.Add(carPart.gameObject);
                    break;
            }
        }
    }

    public void PopulateModificationSelectionList(List<CarModificationSO> carModificationList, ModType mod, Transform content)
    {
        foreach(CarModificationSO carMod in carModificationList)
        {
            GameObject creation = Instantiate(selectionPrefab, content);
            creation.GetComponentInChildren<TextMeshProUGUI>().text = carMod.carModificationName;
            creation.GetComponent<Button>().onClick.AddListener(() =>
            {
                MeshRenderer currentCarRenderer;
                switch (mod)
                {
                    case ModType.Exterior:
                        currentCarRenderer = currentCarExterior.GetComponent<MeshRenderer>();
                        currentCarRenderer.material = carMod.modificationMat;
                        break;
                    case ModType.Interior:
                        currentCarRenderer = currentCarInterior.GetComponent<MeshRenderer>();
                        currentCarRenderer.material = carMod.modificationMat;
                        break;
                    case ModType.Tyres:
                        foreach(GameObject tyre in currentCarTyres)
                        {
                            currentCarRenderer = tyre.GetComponent<MeshRenderer>();
                            currentCarRenderer.material = carMod.modificationMat;
                        }
                        break;
                    case ModType.Glass:
                        currentCarRenderer = currentCarGlass.GetComponent<MeshRenderer>();
                        currentCarRenderer.material = carMod.modificationMat;
                        break;
                }
                
            });
        }
    }

    public void NextMenu()
    {
        if (menuNumber == 4 || currentSelectedCar == null)
            return;
        Debug.Log(menuNumber);
        menuNumber++;
        ChangeMenus(menuNumber);
    }

    public void PreviousMenu()
    {
        if (menuNumber == 0 || currentSelectedCar == null)
            return;
        Debug.Log(menuNumber);
        menuNumber--;
        ChangeMenus(menuNumber);
    }

    private void ChangeMenus(int menuNumber)
    {
        currentUI.SetActive(false);
        Debug.Log(menuNumber);
        switch(menuNumber)
        {
            case 0:
                uiMenus[0].SetActive(true);
                currentUI = uiMenus[0];
                break;
            case 1:
                uiMenus[1].SetActive(true);
                currentUI = uiMenus[1];
                break;
            case 2:
                uiMenus[2].SetActive(true);
                currentUI = uiMenus[2];
                break;
            case 3:
                uiMenus[3].SetActive(true);
                currentUI = uiMenus[3];
                break;
            case 4:
                uiMenus[4].SetActive(true);
                currentUI = uiMenus[4];
                break;
        }
    }
}
