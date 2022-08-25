
using UnityEngine;
using UnityEngine.UI;

public class Health : MovementController
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Fall Detector")
        {
            animController.PlayDeathAnim();
            Destroy(gameObject);
            GameManager.Instance.ChangeGameState(GameState.EndGame);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.tag == "Fireball") && Health == 1)
        {
            animController.PlayDeathAnim();
            Destroy(gameObject);
            GameManager.Instance.ChangeGameState(GameState.EndGame);
        }
        else if ((other.gameObject.tag == "Fireball"))
        {
            animController.PlayHurtAnim();
            Health = Health - 1;
        }
        else if (other.gameObject.tag == "Heart" && Health != 5)
        {
            Health++;
        }
    }
}
