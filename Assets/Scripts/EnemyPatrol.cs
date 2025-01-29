using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed = 3f;  // Geschwindigkeit des Gegners
    public Transform pointA;  // Startpunkt
    public Transform pointB;  // Endpunkt

    private Vector3 target;   // Zielpunkt

    void Start()
    {
        target = pointB.position; // Gegner startet in Richtung Punkt B
    }

    void Update()
    {
        // Bewegung des Gegners
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        // Prüfen, ob der Gegner das Ziel erreicht hat
        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            Flip(); // Gegner dreht sich
            target = (target == pointA.position) ? pointB.position : pointA.position;
        }
    }

    void Flip()
    {
        // Gegner umdrehen (X-Achse spiegeln)
        Vector3 scale = transform.localScale;
        scale.x *= 1;
        transform.localScale = scale;
    }
}
