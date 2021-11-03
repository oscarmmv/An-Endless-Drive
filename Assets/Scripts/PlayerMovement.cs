using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour{

    bool alive = true;
    public float speed = 150;
    public Rigidbody rb;

    float horizontalInput;
    public float horizontalMultiplier = 0.75f;

    private void FixedUpdate() {
        if (!alive) return; 
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        
        if(transform.position.y < -5) {
            Die();
        }
    }

    public void Die () {
        alive = false;
        Invoke("Restart", 1);
    }

    void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
