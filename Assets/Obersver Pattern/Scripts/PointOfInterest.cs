using UnityEngine;

public class PointOfInterest : Subject
{
    [SerializeField]
    private string _poiName = string.Empty;

    private void OnTriggerEnter(Collider other)
    {
        Notify(_poiName, NotificationType.AchievementUnlocked);
    }
}
