using TMPro;
using UnityEngine;

public class PasswordGame : MonoBehaviour
{
    public TMP_InputField inputField; // Tek bir metin kutusu

    private string correctPassword = "1512"; // Doğru şifre
    private string enteredPassword = ""; // Oyuncunun girdiği şifre

    public Animator doorAnim; // Kapı animasyonu

    void Update()
    {
        CheckInput();
    }

    void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            if (enteredPassword == correctPassword)
            {
                Debug.Log("Correct Password Entered!");
                GameManager.Instance.ComputerPanel.SetActive(false);
                doorAnim.SetBool("character_nearby", true);
                GameManager.Instance.infoCanvas.SetActive(true);
                Invoke("CanvasClose", 5f);
            }
            else
            {
                Debug.Log("Wrong Password! Try Again.");
                // Yanlış şifre girildiğinde yapılması gerekenler burada
                // Örneğin, oyuncuya yanlış girdiğini belirten bir mesaj göster
            }

            // Girilen şifreyi sıfırla
            enteredPassword = "";

            // Metin kutusunu temizle
            inputField.text = "";

            // Metin kutusuna odaklan
            inputField.Select();
            inputField.ActivateInputField();
        }
    }

    public void OnInputFieldValueChanged()
    {
        // Girilen değeri kontrol et
        if (inputField.text.Length > 0)
        {
            // Girilen değeri enteredPassword değişkenine ekle
            enteredPassword = inputField.text;
        }
    }

    private void CanvasClose()
    {
        GameManager.Instance.infoCanvas.SetActive(false);
        Time.timeScale = 1;
    }
}
