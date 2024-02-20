using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework4.Data
{
    [Serializable]
    public sealed class CharacterInfo
    {
        public event Action<CharacterStat> OnStatAdded;
        public event Action<CharacterStat> OnStatRemoved;

        [ShowInInspector, ReadOnly]
        private HashSet<CharacterStat> stats = new();

        [PropertySpace]

        [Button]
        public void AddStat(CharacterStat stat)
        {
            if (stats.Add(stat))
            {
                OnStatAdded?.Invoke(stat);
            }
        }

        [Button]
        public void RemoveStat(CharacterStat stat)
        {
            if (stats.Remove(stat))
            {
                OnStatRemoved?.Invoke(stat);
            }
        }

        public CharacterStat GetStat(string name)
        {
            foreach (var stat in stats)
            {
                if (stat.Name == name)
                {
                    return stat;
                }
            }

            throw new Exception($"Stat {name} is not found!");
        }

        public CharacterStat[] GetStats()
        {
            return stats.ToArray();
        }
    }
}