using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TemblorCamara : MonoBehaviour
{

    public static TemblorCamara Instance;
    private CinemachineVirtualCamera cinemachineVirtualCamera; //refe a la camara
    private CinemachineBasicMultiChannelPerlin ruido; //perfil de ruido agregado a la camara
    private float tiempoMov;
    private float tiempoMovTotal;
    private float desvanecerDuracion;
    private float intensidadInicial;


    private void Awake() {

        Instance = this;

        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
        ruido = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void MoverCamara (float intensidad, float frecuencia, float tiempo) 
    {
        ruido.m_AmplitudeGain = intensidad;
        ruido.m_FrequencyGain = frecuencia;
        intensidadInicial = intensidad;
        tiempoMovTotal = tiempo;
        tiempoMov = tiempo;
    }

    public void Update()
    {
        if (tiempoMov > 0)
        {
            tiempoMov -= Time.deltaTime;
            ruido.m_AmplitudeGain = Mathf.Lerp(intensidadInicial, 0, 1 -(tiempoMov / tiempoMovTotal) ); // reducir intensidad segun el tiempo del movimiento
        }
    }

}
