using System;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace HuntroxGames
{
    public class Player : NetworkBehaviour
    {

        private readonly Dictionary<ResourceType, int> _resources = new Dictionary<ResourceType, int>
        {
            {ResourceType.Food, 200},
            {ResourceType.Wood, 200},
            {ResourceType.Metal, 200}
        };
        
        
        public event Action<ResourceType, int,bool> OnResourceChanged;
        
        
        
        
        
        
        
        
        public bool UpdateResource(ResourceType type, int amount)
        {
            if (!_resources.ContainsKey(type) || _resources[type] + amount < 0)
                return false;
            
            var negativeValue = amount < 0;
            _resources[type] += amount;
            OnResourceChanged?.Invoke(type, amount,negativeValue);
            return true;
        }


    }
}