using UnityEngine;
using Cinemachine;

 public class CameraManager : MonoBehaviour
 {
    [Tooltip("Camera for the car Exterior menu")]
    [SerializeField] CinemachineVirtualCamera carExteriorCamera;
    [Tooltip("Camera for the car Exterior menu")]
    [SerializeField] CinemachineVirtualCamera carInteriorCamera;
    [Tooltip("Camera for the car Exterior menu")]
    [SerializeField] CinemachineVirtualCamera carGlassCamera;
    [Tooltip("Camera for the car Exterior menu")]
    [SerializeField] CinemachineVirtualCamera carTyreCamera;

    public void ChangeCamera(MenuType menu)
    {
        carExteriorCamera.Priority = 1;
        carInteriorCamera.Priority = 1;
        carGlassCamera.Priority = 1;
        carTyreCamera.Priority = 1;

        switch (menu)
        {
            case MenuType.CarModel:
            case MenuType.CarExterior:
                carExteriorCamera.Priority = 2;
                break;
            case MenuType.CarInteriror:
                carInteriorCamera.Priority = 2;
                break;
            case MenuType.CarGlass:
                carGlassCamera.Priority = 2;
                break;
            case MenuType.CarTypes:
                carTyreCamera.Priority = 2;
                break;
        }
    }
}
