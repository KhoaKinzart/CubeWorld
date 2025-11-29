using UnityEngine;
using System;

public class GameTimeTracker : MonoBehaviour
{
    private static GameTimeTracker instance;
    private DateTime startTime;

    void Awake()
    {
        // Kiểm tra nếu đã có một GameTimeTracker khác
        if (instance == null)
        {
            // Nếu chưa có, set instance và không phá hủy GameObject này khi chuyển scene
            instance = this;
            DontDestroyOnLoad(gameObject); // Đảm bảo GameObject không bị hủy khi chuyển scene
            startTime = DateTime.Now;
            Debug.Log("Game started at: " + startTime);
        }
        else
        {
            // Nếu đã có, phá hủy GameObject này để không có nhiều hơn 1 instance
            Destroy(gameObject);
        }
    }

    void OnApplicationQuit()
    {
        // Ghi lại thời gian khi game tắt
        DateTime endTime = DateTime.Now;
        TimeSpan playTime = endTime - startTime;
        Debug.Log("Game ended at: " + endTime);
        Debug.Log("Total play time: " + playTime);
    }
}
