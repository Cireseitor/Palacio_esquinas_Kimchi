using System;
using UnityEngine;

[Serializable]
public class Player
{
    [SerializeField]
    public int id;
    [SerializeField]
    public GameObject ManoDerecha, ManoIzquierda, Torus;
    public GameObject[] Cabeza;
}

