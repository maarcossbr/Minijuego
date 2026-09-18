using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public bool esFragmento = false;

    public float escalaFragmento = 0.5f;
    public float velocidadFragmento = 2f;
    public float anguloSeparacion = 30f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 velocidad = rb.linearVelocity;

        if (velocidad.magnitude > 0.1f)
        {
            float angulo =
                Mathf.Atan2(velocidad.y, velocidad.x)
                * Mathf.Rad2Deg;

            transform.rotation =
                Quaternion.Euler(0, 0, angulo + 90f);
        }

        if (transform.position.x > 11.5f || transform.position.x < -11.5f || transform.position.y > 8.5f || transform.position.y < -8.5f)
        {
            rb.linearVelocity = Vector3.zero;
            PoolManager.Instance.ReturnAsteroid(gameObject);
        }
    }

    public void RecibirDisparo(Vector3 direccionBala)
    {
        if (esFragmento)
        {
            VolverAlPool();
            return;
        }

        CrearFragmento(direccionBala, anguloSeparacion);
        CrearFragmento(direccionBala, -anguloSeparacion);

        VolverAlPool();
    }

    void CrearFragmento(Vector3 direccionBala, float angulo)
    {
        GameObject mini = PoolManager.Instance.GetAsteroid();

        mini.transform.position = transform.position;
        mini.transform.rotation = Quaternion.identity;

        mini.transform.localScale = transform.localScale * escalaFragmento;

        Asteroid asteroid = mini.GetComponent<Asteroid>();
        asteroid.esFragmento = true;

        Vector3 direccion = Quaternion.Euler(0, 0, angulo) * direccionBala.normalized;

        Rigidbody rbMini = mini.GetComponent<Rigidbody>();

        rbMini.mass = rb.mass * escalaFragmento;
        rbMini.linearVelocity = direccion * velocidadFragmento;
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            if (esFragmento)
            {
                return;
            }

            Vector3 direccion = (transform.position - collision.transform.position).normalized;

            RecibirDisparo(direccion);

        }
    }

    void VolverAlPool()
    {
        rb.linearVelocity = Vector3.zero;
        PoolManager.Instance.ReturnAsteroid(gameObject);
    }
}
