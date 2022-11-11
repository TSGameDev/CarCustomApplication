using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum MenuType 
{
    CarModel,
    CarExterior,
    CarInteriror,
    CarGlass,
    CarTypes
}

public class ApplicationManager : MonoBehaviour
{
    [HideInInspector]
    public CarModelSO currentSelectedCar;
    [HideInInspector]
    public CarModificationSO currentSelectedExterior;
    [HideInInspector]
    public CarModificationSO currentSelectedInterior;
    [HideInInspector]
    public CarModificationSO currentSelectedGlass;
    [HideInInspector]
    public CarModificationSO currentSelectedTyres;

    [Tooltip("The prefab of the button that is used to select an option")]
    [SerializeField] GameObject selectionPrefab;
    [Tooltip("The spawnpoint for car models")]
    [SerializeField] Transform carModelSpawnPoint;
    [Space(10)]
    [Tooltip("Menu of Car Models")]
    [SerializeField] GameObject carModelMenu;
    [Tooltip("Menu of Car Models")]
    [SerializeField] GameObject carExteriorMenu;
    [Tooltip("Menu of Car Models")]
    [SerializeField] GameObject carInteriorMenu;
    [Tooltip("Menu of Car Models")]
    [SerializeField] GameObject carGlassMenu;
    [Tooltip("Menu of Car Models")]
    [SerializeField] GameObject carTyreMenu;
    [Space(10)]
    [Tooltip("The starting active UI")]
    [SerializeField] GameObject currentUI;
    [Tooltip("The title text for hovering a selection")]
    [SerializeField] TextMeshProUGUI itemTitle;
    [Tooltip("The description text for hovering a selection")]
    [SerializeField] TextMeshProUGUI itemDescription;
    [Tooltip("Cost Handler script reliable for updating costs")]
    [SerializeField] CostHandler costHandler;
    [Tooltip("Manager of the camera to change camera prio for different menus")]
    [SerializeField] CameraManager cameraManager;

    private MenuType selectedMenu = MenuType.CarModel;

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
                costHandler.UpdateCarCost(carModel);
            });

            OnPointerEnterExit pointerEvent = creation.GetComponent<OnPointerEnterExit>();
            pointerEvent.PointerEnterDelegate += () =>
            {
                itemTitle.text = $"{carModel.carName} - ${carModel.price}";
                itemDescription.text = $"{carModel.carDescription}.{Environment.NewLine}{carModel.carStats}."; 
            };
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
                        costHandler.UpdateModificationCost(carMod, mod);
                        currentSelectedExterior = carMod;
                        break;
                    case ModType.Interior:
                        currentCarRenderer = currentCarInterior.GetComponent<MeshRenderer>();
                        currentCarRenderer.material = carMod.modificationMat;
                        costHandler.UpdateModificationCost(carMod, mod);
                        currentSelectedInterior = carMod;
                        break;
                    case ModType.Tyres:
                        foreach(GameObject tyre in currentCarTyres)
                        {
                            currentCarRenderer = tyre.GetComponent<MeshRenderer>();
                            currentCarRenderer.material = carMod.modificationMat;
                            costHandler.UpdateModificationCost(carMod, mod);
                            currentSelectedTyres = carMod;
                        }
                        break;
                    case ModType.Glass:
                        currentCarRenderer = currentCarGlass.GetComponent<MeshRenderer>();
                        currentCarRenderer.material = carMod.modificationMat;
                        costHandler.UpdateModificationCost(carMod, mod);
                        currentSelectedGlass = carMod;
                        break;
                }
                
            });
            OnPointerEnterExit pointerEvent = creation.GetComponent<OnPointerEnterExit>();
            pointerEvent.PointerEnterDelegate += () =>
            {
                itemTitle.text = $"{carMod.carModificationName} - ${carMod.modficationPrice}";
                itemDescription.text = $"{carMod.carModificationDescription}";
            };
        }
    }

    public void NextMenu()
    {
        if (selectedMenu == MenuType.CarTypes || currentSelectedCar == null)
            return;
        selectedMenu++;
        ChangeMenus(selectedMenu);
    }

    public void PreviousMenu()
    {
        if (selectedMenu == MenuType.CarModel || currentSelectedCar == null)
            return;
        selectedMenu--;
        ChangeMenus(selectedMenu);
    }

    private void ChangeMenus(MenuType menu)
    {
        currentUI.SetActive(false);
        switch(menu)
        {
            case MenuType.CarModel:
                carModelMenu.SetActive(true);
                currentUI = carModelMenu;
                break;
            case MenuType.CarExterior:
                carExteriorMenu.SetActive(true);
                currentUI = carExteriorMenu;
                break;
            case MenuType.CarInteriror:
                carInteriorMenu.SetActive(true);
                currentUI = carInteriorMenu;
                break;
            case MenuType.CarGlass:
                carGlassMenu.SetActive(true);
                currentUI = carGlassMenu;
                break;
            case MenuType.CarTypes:
                carTyreMenu.SetActive(true);
                currentUI = carTyreMenu;
                break;
        }
        cameraManager.ChangeCamera(menu);
    }
}
