using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class CameraFocusController : MonoBehaviour
{
    private bool mVuforiaStarted = false;

    void Start()
    {
        VuforiaARController vuforia = VuforiaARController.Instance;

        if (vuforia != null)
            vuforia.RegisterVuforiaStartedCallback(StartAfterVuforia);
    }

    private void StartAfterVuforia()
    {
        mVuforiaStarted = true;
        SetAutofocus();
    }

    void OnApplicationPause(bool pause)
    {
        if (!pause)
        {
            // Aplicacion reanudada
            if (mVuforiaStarted)
            {
                SetAutofocus(); // Esto se hace porque algunos dispositivos Android pierden el autofocus cuando se reaunda la aplicacion
            }
        }
    }

    private void SetAutofocus()
    {
        if (CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO))
        {
            Debug.Log("Autofocus activado");
        }
        else
        {
            Debug.Log("Este dispositivo no permite autofocus");
        }
    }
}
