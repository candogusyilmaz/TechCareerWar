using System.Collections.Generic;

namespace TechCareerWar.Utilities
{
    internal record Magazine<Type> where Type : new()
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
