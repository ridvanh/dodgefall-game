
using UnityEngine;
using UnityEngine.UI;

public class Health : MovementController
{

    public GameOverScreen goScreen;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Fall Detector")
        {
            animController.PlayDeathAnim();
            Destroy(gameObject);
            goScreen.Setup();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.tag == "Fireball") && Health == 1)
        {
            animController.PlayDeathAnim();
            Destroy(gameObject);
            goScreen.Setup();
        }
        else if ((other.gameObject.tag == "Fireball"))
        {
            Health = Health - 1;
        }
    }
}
