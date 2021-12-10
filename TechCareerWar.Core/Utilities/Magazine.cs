using System.Collections.Generic;

using TechCareerWar.Core.Models.Ammos.Abstract;

namespace TechCareerWar.Core.Utilities
{
    public class Magazine<Type> where Type : IAmmo, new()
    {
        public int AmmoCount => _ammos.Count;

        public int Capacity { get; init; }

        private readonly Queue<Type> _ammos;

        public Magazine(int capacity)
        {
            _ammos = new Queue<Type>();

            Capacity = capacity;

            for (int i = 0; i < Capacity; i++)
                _ammos.Enqueue(new Type());
        }

        public void LoadToChamber(int count)
        {
            for (int i = 0; i < count; i++)
                _ammos.Dequeue();
        }
    }
}
