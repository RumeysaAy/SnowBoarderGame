using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float loadDelay = 0.5f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;

    bool hasCrashed = false; // düştü mü?

    private void OnTriggerEnter2D(Collider2D other)
    {
        // oyuncunun kafası (Circle Collider 2D) zemine çarparsa
        if (other.tag == "Ground" && hasCrashed == false)
        {
            hasCrashed = true; // ilk kez düştü
            FindObjectOfType<PlayerController>().DisableControls(); // oyuncu karakteri yönlendirmesin
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            // loadDelay saniye sonra seviye/sahne yeniden başlar
            Invoke(nameof(ReloadScene), loadDelay);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
