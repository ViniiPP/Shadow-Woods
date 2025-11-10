using UnityEngine;

public class ManageMap
{
    private static ManageMap _instance;
    public static ManageMap Instance
    {
        get
        {
            if (_instance == null)
                _instance = new ManageMap();

            return _instance;
        }
    }

    private MapList currentMap = MapList.FirstMap;

    public void SetCurrentMap(MapList map)
    {
        currentMap = map;
    }

    public MapList GetCurrentMap()
    {
        return currentMap;
    }
}
