using UnityEngine;

namespace HuntroxGames
{
    public class BuildingManager : MonoBehaviour
    {
        [SerializeField] private BuildingInfo[] buildingInfos;

        
        public BuildingInfo[] BuildingInfos => buildingInfos;
        public void OnBuildingClick(int index)
        {
            Debug.Log(buildingInfos[index].buildingName);
        }
        [ContextMenu("Test")]
        public void TestBuild()=> OnBuildingClick(0);
    }
}