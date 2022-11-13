using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class barravida : MonoBehaviour
{
    private Slider slider;


    public void Cambiarvidamaxima(float vidamaxima)
    {
        slider.maxValue = vidamaxima;
    }

    public void Cambiarvidaactual(float cantidadvida)
    {
        slider.value = cantidadvida;
    }

    public void Inicializarbarradevida(float cantidadvida)
    {
        slider = GetComponent<Slider>();
        Cambiarvidamaxima(cantidadvida);
        Cambiarvidaactual(cantidadvida);
    }
}
