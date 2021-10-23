using System;
using UnityEngine;

public class Commander : MonoBehaviour
{
    public GUIUnitPanel guiUnitPanel;
    public PointOfInterrest[] poiArray;

    public void Start()
    {
        guiUnitPanel.SpawnRequest += SpawnAtPoint;
    }
    public void SpawnAtPoint(string unitName)
    {
        var random = Mathematics.GetRandomValue(poiArray.Length);
        IPointOfInterest poi = poiArray[random];
        if(poi.POIEnum == POIEnum.Entry)
        {
            ObjectPool.Instance.SpawnFromPool(unitName, poi.GetPosition());
        }
    } 
}