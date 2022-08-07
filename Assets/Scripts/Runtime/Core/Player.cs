using System;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace HuntroxGames
{
    public class Player : NetworkBehaviour
    {

        [SerializeField] private int workersCapacity = 3;
        [SerializeField] private int herosCapacity = 3;

        private readonly Dictionary<ResourceType, int> resources = new Dictionary<ResourceType, int>
        { { ResourceType.Food, 200 },
            { ResourceType.Wood, 200 },
            { ResourceType.Metal, 200 }
        };


        public int WorkersCapacity
        {
            get => workersCapacity;
            set => workersCapacity = value;
        }
        public int HerosCapacity
        {
            get => herosCapacity;
            set => herosCapacity = value;
        }
        
        public event Action<ResourceType, int, bool> OnResourceChanged;

        public bool HasEnoughResources (ResourceType type, int amount) 
            => resources[type] >= amount;

        public bool UpdateResource (ResourceType type, int amount)
        {
            if (!resources.ContainsKey (type) || resources[type] + amount < 0)
                return false;

            var negativeValue = amount < 0;
            resources[type] += amount;
            OnResourceChanged?.Invoke (type, amount, negativeValue);
            return true;
        }

    }
}