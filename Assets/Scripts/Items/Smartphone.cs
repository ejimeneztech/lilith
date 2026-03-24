using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "Item/Smartphone")]
public class Smartphone :Item
{
    public override bool Use(int slotIndex)
    {
        SceneManager.LoadScene("End");
        return true;
    }
}
