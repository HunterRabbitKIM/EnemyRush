using System.IO;
using UnityEngine;

public static class CSVManager
{
    private static string directoryPath = Application.dataPath + "/CSVFiles";
    private static string filePath = directoryPath + "/TensionData12.csv";

    // Append to the CSV file
    public static void AppendToCSV(string content)
    {
        // Ensure the directory exists
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
            Debug.Log("Directory created at: " + directoryPath);
        }
        else
        {
            Debug.Log("Directory already exists: " + directoryPath);
        }

        // Check if file exists, and create with headers if it doesn¡¯t
        if (!File.Exists(filePath))
        {
            try
            {
                File.WriteAllText(filePath, "Episode,Tactual,Tension,EnemyCount\n");
                Debug.Log("File created with headers at: " + filePath);
            }
            catch (IOException ex)
            {
                Debug.LogError("Error creating file: " + ex.Message);
                return;
            }
        }
        else
        {
            Debug.Log("File already exists: " + filePath);
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