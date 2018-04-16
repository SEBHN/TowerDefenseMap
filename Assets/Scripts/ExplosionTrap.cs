using UnityEngine;

public class ExplosionTrap : Trap
{
    public GameObject stunArea;
    private bool isActive;

    public override void TrapTriggered(GameObject enemy)
    {
        if (!isActive)
        {
            if (enemy.tag == "Enemy")
            {
                stunArea.SetActive(false);
                // Start timer
                Invoke("DeactivateTrap", duration);
            }
        }
    }

    private void DeactivateTrap()
    {
        stunArea.SetActive(false);
        foreach (EnemyAI enemy in FindObjectsOfType<EnemyAI>())
        {
            enemy.ResetSpeed();
        }
        Invoke("ResetTrap", cooldown);
    }

    private void ResetTrap()
    {
        isActive = false;
    }

    // Use this for initialization
    void Start()
    {
        isActive = false;
        if (duration <= 0.0f)
        {
            duration = 2.5f;
        }
        if (cooldown <= 0.0f)
        {
            cooldown = 4.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}