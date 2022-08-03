using System.Collections;
using System.Collections.Generic;
using HuntroxGames.Utils;
using UnityEngine;

namespace HuntroxGames
{
    public abstract class Entity : MonoBehaviour
    {

        [SerializeField,ReadOnly]protected string entityId;
        
        public string EntityId
        {
            get => entityId;
            set => entityId = value;
        }
        
        
        public virtual void MoveTo(Vector3 position)
        {
            
        }
        
    }
    
}
