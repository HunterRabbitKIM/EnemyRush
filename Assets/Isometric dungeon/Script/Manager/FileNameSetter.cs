using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class FileNameSetter : MonoBehaviour
{
    public InputField fileNameInput; // Input field for the custom file name
    public Button setFileNameButton; // Button to set the file name

    private void Start()
    {
        // Add a listener to the button to set the file path
        setFileNameButton.onClick.AddListener(OnSetFileNameButtonClicked);
    }
    public void OnSetFileNameButtonClicked()
    {
        string customFileName = fileNameInput.text;

        if (!string.IsNullOrEmpty(customFileName))
        {
            // Set the custom file path in CSVManager
            CSVManager.SetFilePath(customFileName);
            Debug.Log("Custom file name set to: " + customFileName);

            SceneManager.LoadScene("Forest");
        }
        else
        {
            Debug.LogWarning("File name cannot be empty.");
        }
    }
}

