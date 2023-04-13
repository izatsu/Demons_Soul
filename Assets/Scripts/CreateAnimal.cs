using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateAnimal : MonoBehaviour
{
    [SerializeField] GameObject animal;

    private void Start()
    {
        Invoke("on", 0.5f);
    }

    void on()
    {
        animal.SetActive(true);

    }
}
