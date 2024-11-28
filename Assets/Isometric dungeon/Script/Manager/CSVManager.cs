using System.IO;
using UnityEngine;

public static class CSVManager
{
    private static string directoryPath = Application.dataPath + "/CSVFiles";
    private static string filePath;

    // Method to set a custom file path
    public static void SetFilePath(string customFileName)
    {
        // Ensure the directory exists
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
            Debug.Log("Directory created at: " + directoryPath);
        }

        // Set the file path with the custom file name
        filePath = Path.Combine(directoryPath, $"{customFileName}.csv");
        Debug.Log("Custom file path set to: " + filePath);

        // Optionally, create the file with headers if it doesn't exist
        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, "Episode,Tactual,Tension,EnemyCount\n");
            Debug.Log("File created with headers at: " + filePath);
        }
    }

    // Append to the CSV file
    public static void AppendToCSV(string content)
    {
        // Ensure the file path is set
        if (string.IsNullOrEmpty(filePath))
        {
            Debug.LogError("File path is not set. Please set a custom file name before appending.");
            return;
        }

        // Append content to the file
        try
        {
            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine(content);
                Debug.Log("Successfully wrote to file: " + content);
            }
        }
        catch (IOException ex)
        {
            Debug.LogError("Error writing to file: " + ex.Message);
        }
    }
}