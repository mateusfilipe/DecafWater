using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WaterController : MonoBehaviour
{
    public TMP_Text QtdAguaOntemText;
    int QtdAguaOntemNum;
    public TMP_Text QtdAguaHojeText;
    int QtdAguaHojeNum;

    // Start is called before the first frame update
    void Start()
    {
        QtdAguaOntemNum = PlayerPrefs.GetInt("QtdAguaOntemPrefs");
        QtdAguaHojeNum = PlayerPrefs.GetInt("QtdAguaHojePrefs");
        Debug.Log("Hoje:" + QtdAguaHojeNum);
        Debug.Log("Ontem:" + QtdAguaOntemNum);
        QtdAguaOntemText.text = QtdAguaOntemNum.ToString();
        QtdAguaHojeText.text = QtdAguaHojeNum.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Drink()
    {
        QtdAguaHojeNum++;
        QtdAguaHojeText.text = QtdAguaHojeNum.ToString();
        Debug.Log("QtdHoje:" + QtdAguaHojeNum);
    }

    public void ChangeScene()
    {
        PlayerPrefs.SetInt("QtdAguaHojePrefs", QtdAguaHojeNum);
        if (SceneManager.GetActiveScene().name == "CoffeeScene")
        {
            SceneManager.LoadScene("WaterScene");
        }
        else if (SceneManager.GetActiveScene().name == "WaterScene")
        {
            SceneManager.LoadScene("CoffeeScene");
        }
    }

    public void StartDay()
    {
        PlayerPrefs.SetInt("QtdAguaOntemPrefs", QtdAguaHojeNum);
        PlayerPrefs.SetInt("QtdAguaHojePrefs", 0);
        QtdAguaOntemNum = PlayerPrefs.GetInt("QtdAguaOntemPrefs");
        QtdAguaHojeNum = PlayerPrefs.GetInt("QtdAguaHojePrefs");
        QtdAguaOntemText.text = QtdAguaOntemNum.ToString();
        QtdAguaHojeText.text = QtdAguaHojeNum.ToString();
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("QtdAguaHojePrefs", QtdAguaHojeNum);
        PlayerPrefs.SetInt("QtdAguaOntemPrefs", QtdAguaOntemNum);
        PlayerPrefs.Save();
    }
}
