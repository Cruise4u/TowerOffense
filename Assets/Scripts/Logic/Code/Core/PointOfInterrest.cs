using System;
using UnityEngine;

public enum POIEnum
{
    Entry,
    Exits
}

public interface IPointOfInterest
{
    POIEnum POIEnum { get; }
    Vector2 GetPosition();
}

public class PointOfInterrest : MonoBehaviour, IPointOfInterest
{
    public POIEnum poiEnum;
    public POIEnum POIEnum => poiEnum;

    public Vector2 GetPosition()
    {
        return new Vector2(transform.position.x, transform.position.y);
    }
}

