using System;
using System.Collections.Generic;
using HuntroxGames.Utils;
using UnityEngine;
using UnityEngine.Events;

namespace HuntroxGames
{
    public class Building : MonoBehaviour
    {

        [SerializeField, ReadOnly] protected string id;
        [SerializeField] protected int maxWorkers = 1;
        [SerializeField] protected float buildTime = 2f;
        [SerializeField, ReadOnly] protected List<Worker> currentWorkers = new List<Worker> ();
        [SerializeField] protected WorkerJob buildingJob;

        protected bool isActive = false;

        public bool IsActive => isActive;
        public string ID
        {
            get => id;
            set => id = value;
        }

        public event UnityAction OnBuildingStarted;
        public event UnityAction OnBuildingComplete;

        public virtual bool AssignWorker (Worker worker)
        {
            if (currentWorkers.Count >= maxWorkers || currentWorkers.Contains (worker)) return false;
            currentWorkers.Add (worker);
            return true;
        }
        public virtual bool RemoveWorker (Worker worker)
        {
            if (!currentWorkers.Contains (worker)) return false;
            currentWorkers.Remove (worker);
            return true;
        }

        public virtual void StartPreview ()
        {

        }
        public virtual bool Construct ()
        {
            Debug.Log ("Building Constructed");
            return true;
        }

        public virtual void Destroy ()
        {
            Debug.Log ("Building Destroyed");
        }

        public virtual void Update ()
        {

        }

        private void OnValidate ()
        {
            if (id.IsNullOrEmpty ())
                id = Utils.Utils.GenGuid ();
        }
    }
    public enum ResourceType
    {
        Wood,
        Metal,
        Food
    }
}