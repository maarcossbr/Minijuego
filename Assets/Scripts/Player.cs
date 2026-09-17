using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public float thrustForce = 5f;
    public float rotationSpeed = 10f;

    public GameObject gun, bulletPrefab;

    private Rigidbody _rigid;

    public static int SCORE = 0;

    private float xBorderLimit;
    private float yBorderLimit;
    private Vector3 cameraCenter;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rigid = GetComponent<Rigidbody>();

        Camera cam = Camera.main;

        yBorderLimit = cam.orthographicSize + 1f;
        xBorderLimit = (cam.orthographicSize + 1f) * cam.aspect;

        cameraCenter = cam.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        float rotation = Input.GetAxis("Horizontal") * Time.deltaTime;
        float thrust = Input.GetAxis("Vertical") * Time.deltaTime;

        Vector3 thrustDirection = transform.right;

        _rigid.AddForce(thrustDirection * thrust * thrustForce);

        transform.Rotate(Vector3.forward, -rotation * rotationSpeed);

        Vector3 newPos = transform.position;

        float rightLimit = cameraCenter.x + xBorderLimit;
        float leftLimit = cameraCenter.x - xBorderLimit;
        float topLimit = cameraCenter.y + yBorderLimit;
        float bottomLimit = cameraCenter.y - yBorderLimit;

        // Derecha -> izquierda
        if (newPos.x > rightLimit)
        {
            newPos.x = leftLimit + 1f;
        }
        // Izquierda -> derecha
        else if (newPos.x < leftLimit)
        {
            newPos.x = rightLimit - 1f;
        }

        // Arriba -> abajo
        if (newPos.y > topLimit)
        {
            newPos.y = bottomLimit + 1f;
        }
        // Abajo -> arriba
        else if (newPos.y < bottomLimit)
        {
            newPos.y = topLimit - 1f;
        }

        transform.position = newPos;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate(bulletPrefab, gun.transform.position, Quaternion.identity);

            Bullet balaScript = bullet.GetComponent<Bullet>();

            balaScript.targetVector = transform.right;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            SCORE = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
}
