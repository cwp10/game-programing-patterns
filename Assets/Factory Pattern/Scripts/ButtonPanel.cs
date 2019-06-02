using ReflectionFactoryStatic;
using UnityEngine;

public class ButtonPanel : MonoBehaviour
{
    [SerializeField]
    private AbilityButton buttonPrefab_ = null;

    private void OnEnable()
    {
        foreach (string name in AbilityFactory.GetAbilityNames())
        {
            var button = Instantiate(buttonPrefab_);
            button.gameObject.name = name + " Button";
            button.SetAbilityName(name);
            button.transform.SetParent(transform);
        }
    }
}
