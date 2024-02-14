using UnityEngine;

public class Moneda : MonoBehaviour
{
    [SerializeField] private GameObject efecto;
    [SerializeField] private float cantidadPuntos;
    [SerializeField] private Puntajes puntajes;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            puntajes.SumarPuntos(cantidadPuntos);
            Instantiate(efecto, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
