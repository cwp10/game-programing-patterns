using System;
using UnityEngine;

public class PointOfInterestWithEvents : MonoBehaviour
{
    public static event Action<PointOfInterestWithEvents> OnPointOfInterestEntered = null;

    [SerializeField]
    private string _poiName = string.Empty;

    public string PoiName { get { return _poiName; } }

    private void OnTriggerEnter(Collider other)
    {
        if (OnPointOfInterestEntered != null)
        {
            OnPointOfInterestEntered(this);
        }
    }
}
