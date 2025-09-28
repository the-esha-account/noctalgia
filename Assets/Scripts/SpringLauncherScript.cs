using UnityEngine;

public class SpringLauncherScript : MonoBehaviour
{
    public Animator anim;

    public float launchForce = 10f;
    public Vector2 launchDirection = Vector2.up;
    public bool hasColided = false;

    private void Start() 
    {
        anim = GetComponent<Animator>();
    }

    void Update() 
    {
        anim.SetBool("hasColided", hasColided);
        Debug.Log(hasColided);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            hasColided = true; 
            Rigidbody2D playerRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            if (playerRigidbody != null)
            {
                playerRigidbody.AddForce(launchDirection * launchForce, ForceMode2D.Impulse);
            }
        }
        else if (!collision.gameObject.CompareTag("Player")) 
        {
            hasColided = false; 
        }
    }
}
