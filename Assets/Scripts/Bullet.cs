using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{

    public float speed = 10f;
    public float maxLifeTime = 3f;
    public Vector3 targetVector;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        CancelInvoke();
        Invoke(nameof(VolverAlPool), maxLifeTime);
    }

    void OnDisable()
    {
        CancelInvoke();
    }

    void VolverAlPool()
    {
        PoolManager.Instance.ReturnBullet(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * targetVector * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            IncreaseScore();
            Asteroid asteroid = collision.gameObject.GetComponent<Asteroid>();

            if (asteroid != null)
            {
                asteroid.RecibirDisparo(-targetVector);
                PoolManager.Instance.ReturnBullet(gameObject);
            }

        }
    }

    private void IncreaseScore()
    {
        Player.SCORE++;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        GameObject go = GameObject.FindGameObjectWithTag("UI");
        go.GetComponent<Text>().text = "Puntos: " + Player.SCORE;
    }
}
