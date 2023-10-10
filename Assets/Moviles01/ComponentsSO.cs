using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ControlTap", menuName = "ScriptableObjects/Figuras")]
public class ComponentsSO : ScriptableObject
{
    //*****Propiedades*****

    public GameObject circlePrefab; 
    public GameObject squarePrefab;
    public GameObject tiangulePrefab;

    public Color blueColor = Color.blue; 
    public Color redColor = Color.red; 
    public Color greenColor = Color.green; 

}
