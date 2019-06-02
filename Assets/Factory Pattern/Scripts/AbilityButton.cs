using ReflectionFactoryStatic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityButton : MonoBehaviour
{
    [SerializeField]
    private Text nameText_ = null;

    private string name_ = string.Empty;

    private void Awake()
    {
        this.GetComponent<Button>().onClick.AddListener(OnClick);
    }

    public void SetAbilityName(string name)
    {
        this.name_ = name;
        nameText_.text = this.name_;
    }

    public void OnClick()
    {
        Ability ability = AbilityFactory.GetAbility(this.name_);
        ability.Process();
    }
}
