using UnityEngine;
[CreateAssetMenu(fileName = "ChestInfo", menuName = "Gameplay/New ChestInfo", order = 1)]
public class ChestInfo : ScriptableObject
{
    [SerializeField] private string _id;
    [SerializeField] private int _capacity;

    public string id => _id;
    public int capacity => _capacity;
}
