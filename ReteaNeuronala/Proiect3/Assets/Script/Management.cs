using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Management : MonoBehaviour
{
    [SerializeField] private GameObject pag1, pag2, pag3;

    private void Awake()
    {
        pag1.SetActive(true);
        pag2.SetActive(false);
        pag3.SetActive(false);
    }
}
