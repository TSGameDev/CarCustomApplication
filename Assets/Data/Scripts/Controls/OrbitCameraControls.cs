using Cinemachine;
using UnityEngine;

[RequireComponent(typeof(CinemachineFreeLook))]
 public class OrbitCameraControls: MonoBehaviour
 {
    [SerializeField] ApplicationManager applicationManager;

    private CameraControls cameraControls;
    private CinemachineFreeLook orbitCam;

    private bool lookToogle = false;

    private void Awake()
    {
        cameraControls = new();

        orbitCam = GetComponent<CinemachineFreeLook>();
        orbitCam.m_XAxis.m_InputAxisName = "";
        orbitCam.m_YAxis.m_InputAxisName = "";
    }

    private void OnEnable()
    {
        cameraControls.Enable();
        cameraControls.OrbitControls.Enable();

        cameraControls.OrbitControls.EnableMovement.performed += ctx => { lookToogle = !lookToogle; };
        cameraControls.OrbitControls.ToggleOrbitMode.performed += ctx => ToggleOrbitMode();
    }

    private void Update()
    {
        if(lookToogle)
        {
            Vector2 mouseDelta = cameraControls.OrbitControls.MouseDelta.ReadValue<Vector2>();
            orbitCam.m_XAxis.m_InputAxisValue = mouseDelta.x;
            orbitCam.m_YAxis.m_InputAxisValue = mouseDelta.y;
        }
        else
        {
            orbitCam.m_XAxis.m_InputAxisValue = 0;
            orbitCam.m_XAxis.m_InputAxisValue = 0;
        }
    }

    private void ToggleOrbitMode()
    {
        orbitCam.Priority = orbitCam.Priority == 10 ? 0 : 10;
        applicationManager.ToggleCanvas();
    }
}

