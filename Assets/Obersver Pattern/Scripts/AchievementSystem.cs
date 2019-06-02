using UnityEngine;

public class AchievementSystem : Observer
{
    private void Start()
    {
        PlayerPrefs.DeleteAll();

        foreach (var poi in FindObjectsOfType<PointOfInterest>())
        {
            poi.RegisterObserver(this);
        }
    }

    public override void OnNotify(object value, NotificationType notificationType)
    {
        if (notificationType == NotificationType.AchievementUnlocked)
        {
            string achievementKey = "achivement-" + value;

            if (PlayerPrefs.GetInt(achievementKey) == 1)
            {
                return;
            }

            PlayerPrefs.SetInt(achievementKey, 1);
            Debug.Log("Unlocked " + value);
        }
    }
}