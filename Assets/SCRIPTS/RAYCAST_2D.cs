using UnityEngine;
using UnityEngine.InputSystem;

public class RAYCAST_2D : MonoBehaviour
{

    public Camera mainCamera;
    public InputAction click;
    public float biscotto = 0;
    public int cursori = 0;


    public float biscottiPerSecondo = 0f;

    public UI_MANAGER UImanager;
    private void OnEnable()
    {
        click.Enable();
        click.performed += ClickAttivo;
    }



    private void OnDisable()
    {
        click.Disable();
        click.performed -= ClickAttivo;
    }


    public void ClickAttivo(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            Debug.Log("HO COLPITO QUALCOSA");


            Vector3 mouseViewPosition = Mouse.current.position.ReadValue();
            mouseViewPosition.z = 10f;
            Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(mouseViewPosition);

            RaycastHit2D colpito = Physics2D.Raycast(mouseWorldPosition, Vector3.zero, 500f);


            if(colpito.collider != null  && colpito.collider.CompareTag("BISCOTTO"))
            {
                Debug.Log("colpito" + colpito.collider.name);


                biscotto++;
                UImanager.AggiornaTesto(Mathf.FloorToInt(biscotto));




            }

            




        }
    }

    void Update()
    {
        biscottiPerSecondo = cursori * 0.1f;

        biscotto += biscottiPerSecondo * Time.deltaTime;

        UImanager.AggiornaTesto(Mathf.FloorToInt(biscotto));
    }


}
