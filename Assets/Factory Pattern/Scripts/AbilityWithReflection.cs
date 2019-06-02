using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ReflectionFactory
{
    public abstract class Ability
    {
        public abstract string Name { get; }
        public abstract void Process();
    }

    public class StartFireAbility : Ability
    {
        public override string Name => "fire";

        public override void Process()
        {

        }
    }

    public class HealSelfAbility : Ability
    {
        public override string Name => "heal";

        public override void Process()
        {

        }
    }

    public class AbilityFactory
    {
        private Dictionary<string, Type> _abilitiesByName = null;

        public AbilityFactory()
        {
            var abilityTypes = Assembly.GetAssembly(typeof(Ability)).GetTypes()
                .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(Ability)));

            _abilitiesByName = new Dictionary<string, Type>();

            foreach (var type in abilityTypes)
            {
                var tempEffect = Activator.CreateInstance(type) as Ability;
                _abilitiesByName.Add(tempEffect.Name, type);
            }
        }


        public Ability GetAbility(string abilityType)
        {
            if (_abilitiesByName.ContainsKey(abilityType))
            {
                Type type = _abilitiesByName[abilityType];
                var ability = Activator.CreateInstance(type) as Ability;
                return ability;
            }

            return null;
        }

        internal IEnumerable<string> GetAbilityNames()
        {
            return _abilitiesByName.Keys;
        }
    }
}
