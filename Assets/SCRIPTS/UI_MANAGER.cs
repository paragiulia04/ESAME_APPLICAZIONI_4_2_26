using TMPro;
using UnityEngine;

public class UI_MANAGER : MonoBehaviour
{

    public TextMeshProUGUI testoBiscotti;

    public void AggiornaTesto(int valore)
    {
        testoBiscotti.text = valore.ToString();
    }








}
