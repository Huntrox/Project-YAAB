namespace HuntroxGames
{
    [System.Serializable]
    public struct BuildingResource
    {
        public ResourceType type;
        public int amount;

        public BuildingResource(ResourceType resourceType, int a)
        {
            type = resourceType;
            amount = a;
        }
    }
}