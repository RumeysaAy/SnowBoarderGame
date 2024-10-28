using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 3f; // oyuncunun dönmesi için
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float baseSpeed = 20f;

    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;

    bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // ölürse yani kafası yere çarparsa hareket ettirilmesini engelleyeceğim
        if (canMove)
        {
            RotatePlayer(); // döndürmek için
            RespondToBoost(); // hızlandırmak için
        }
    }

    public void DisableControls()
    {
        // bu fonksiyonu CrashDetector.cs dosyasından çağıracağım
        canMove = false;
    }

    private void RotatePlayer()
    {
        // eğer klavye sol tuşa basılmışsa
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            // eğer klavye sağ tuşa basılmışsa
            rb2d.AddTorque(-torqueAmount);
        }
    }

    private void RespondToBoost()
    {
        // klavyedeki yukarı yön tuşuna basıldığında
        if (Input.GetKey(KeyCode.UpArrow))
        {
            // hızlansın
            surfaceEffector2D.speed = boostSpeed;
        }
        else
        {
            surfaceEffector2D.speed = baseSpeed;
        }
    }
}
