using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BOTTONE_CURSORE : MonoBehaviour
{
    public float costo = 20;
    public Button bottone;
    public UI_MANAGER ui;
    public RAYCAST_2D clicker;

    public GameObject prefabCursore;
    public POSIZIONE_CURSORE posizioni;


    private int indice = 0;

    public TextMeshProUGUI testocosto;

    void Update()
    {
        int costoInt = Mathf.FloorToInt(costo);

        bottone.interactable = clicker.biscotto >= costoInt;
        testocosto.text = costoInt.ToString();
    }

    public void CompraCursore()
    {
        int costoInt = Mathf.FloorToInt(costo);

        if (clicker.biscotto >= costoInt)
        {
            clicker.biscotto -= costoInt;
            ui.AggiornaTesto(Mathf.FloorToInt(clicker.biscotto));

            clicker.cursori++;

            costo = costo * 1.15f;


            if (indice >= posizioni.puntiSpawm.Count)
                indice = 0;

           
            Transform punto = posizioni.puntiSpawm[indice];

          
            Instantiate(prefabCursore, punto.position, Quaternion.identity);

           
            indice++;

         
            if (indice >= posizioni.puntiSpawm.Count)
                indice = 0;




        }
    }



}
