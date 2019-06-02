using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace ReflectionFactoryStatic
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
            GameObject.FindObjectOfType<SimplePlayer>().ShowParticle(0);
        }
    }

    public class HealSelfAbility : Ability
    {
        public override string Name => "heal";

        public override void Process()
        {
            var player = GameObject.FindObjectOfType<SimplePlayer>();
            player.Health++;
            player.ShowParticle(1);
        }
    }

    public class DamageSelfAbility : Ability
    {
        public override string Name => "damage";

        public override void Process()
        {
            var player = GameObject.FindObjectOfType<SimplePlayer>();
            player.Health--;
            player.ShowParticle(0);
        }
    }

    public static class AbilityFactory
    {
        private static Dictionary<string, Type> _abilitiesByName = null;
        private static bool isInitialized_ => _abilitiesByName != null;

        private static void InitializeFactory()
        {
            if (isInitialized_)
            {
                return;
            }

            var abilityTypes = Assembly.GetAssembly(typeof(Ability)).GetTypes()
                .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(Ability)));

            _abilitiesByName = new Dictionary<string, Type>();

            foreach (var type in abilityTypes)
            {
                var tempEffect = Activator.CreateInstance(type) as Ability;
                _abilitiesByName.Add(tempEffect.Name, type);
            }
        }

        public static Ability GetAbility(string abilityType)
        {
            if (_abilitiesByName.ContainsKey(abilityType))
            {
                Type type = _abilitiesByName[abilityType];
                var ability = Activator.CreateInstance(type) as Ability;
                return ability;
            }

            return null;
        }

        internal static IEnumerable<string> GetAbilityNames()
        {
            UnityEngine.Debug.Log("Test");
            InitializeFactory();
            return _abilitiesByName.Keys;
        }
    }
}

