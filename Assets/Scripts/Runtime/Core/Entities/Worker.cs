using HuntroxGames.Utils;
using UnityEngine;

namespace HuntroxGames
{
    public class Worker : Entity
    {
        [SerializeField,ReadOnly] private WorkerJob currentJob = WorkerJob.FreeLabor;
        public WorkerJob CurrentJob
        {
            get => currentJob;
            set => currentJob = value;
        }
        
    }

    public enum WorkerJob
    {
        FreeLabor,
        Lumberjack,
        Miner,
        Farmer,
        Scouter,
        Trainer,
    }
}