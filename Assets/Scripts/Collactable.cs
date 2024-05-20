using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public float radius = 5f; // Sphere'in yarıçapı

    // Update is called once per frame
    void Update()
    {
        CheckSphere();
    }

    void CheckSphere()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.CompareTag("Player"))
            {
                if (Input.GetKeyDown(KeyCode.E) && gameObject.CompareTag("Password"))
                {
                    GameManager.Instance.passwordCount--;
                    Destroy(gameObject);
                }

                if (gameObject.CompareTag("Mission1") && Input.GetKeyDown(KeyCode.E) && GameManager.Instance.passwordCount == 0)
                {
                    GameManager.Instance.ComputerPanel.SetActive(true);
                }

                if (gameObject.CompareTag("Key") && Input.GetKeyDown(KeyCode.E))
                {
                    Destroy(gameObject);
                    GameManager.Instance.keyCollected = true;
                }

                if (gameObject.CompareTag("Mission2") && GameManager.Instance.keyCollected)
                {
                    GameManager.Instance.key.SetActive(true);
                    Invoke("LoadFinalScene", 3f);
                }
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    void LoadFinalScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("FinishScene");
    }
}
