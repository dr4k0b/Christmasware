using UnityEngine;

public class HealthBar : MonoBehaviour
{
    GlobalInformation g;
    Animator ani;

    public int thisHealth;
    void Start()
    {
        g = FindAnyObjectByType<GlobalInformation>();
        ani = GetComponent<Animator>();
    }
    private void Update()
    {
        ani.SetBool("Hurt", (g.health < thisHealth));
    }
}
