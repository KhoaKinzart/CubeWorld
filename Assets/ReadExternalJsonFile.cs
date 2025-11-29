using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class ReadExternalJsonFile : MonoBehaviour
{
    // Struct để khớp với định dạng JSON
    [System.Serializable]
    public class User
    {
        public string Id;
        public string ID; // Phân biệt tên lớn nhỏ
        public string Name;
        public string Password;
        public string Email;
        public int Role;
    }

    void Start()
    {
        // Đường dẫn tới file JSON trên ổ D
        string filePath = @"D:/userInfo.json";

        // Kiểm tra nếu file tồn tại
        if (File.Exists(filePath))
        {
            // Đọc nội dung file
            string jsonContent = File.ReadAllText(filePath);

            // Deserialize JSON thành đối tượng C#
            User userData = JsonUtility.FromJson<User>(jsonContent);

            // Debug thông tin
            Debug.Log("Id: " + userData.Id);
            Debug.Log("ID: " + userData.ID);
            Debug.Log("Name: " + userData.Name);
            Debug.Log("Password: " + userData.Password);
            Debug.Log("Email: " + userData.Email);
            Debug.Log("Role: " + userData.Role);
        }
        else
        {
            Debug.LogError("File not found!");
        }

        // Chuyển cảnh (nếu cần)
        SceneManager.LoadScene(1);
    }
}
