using UnityEngine;

namespace HuntroxGames
{
    [CreateAssetMenu(menuName = "HuntroxGames/new Building", order = 1)]
    public class BuildingInfo : ScriptableObject
    {
        public string buildingName;
        public Sprite icon;
        public string description;
        public BuildingResource[] cost;
        public Building buildingPrefab;
        public GameObject buildingPreview;
        public string id;
    }
}