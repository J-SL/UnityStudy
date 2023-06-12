using UnityEngine;

public class BigMapControl : MonoBehaviour
{
    public static bool open;
    public GameObject BigMap;

    public void Update()
    {
        ControlBIgMap();
    }

    private void ControlBIgMap()
    {   
        BigMap.SetActive(open);
        if(Input.GetKeyDown("m"))
        {
            open = !open;
            BigMap.SetActive(open);
        }
    }
}
