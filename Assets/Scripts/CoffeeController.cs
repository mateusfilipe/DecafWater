using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CoffeeController : MonoBehaviour
{
    public TMP_Text QtdCafeOntemText;
    int QtdCafeOntemNum;
    public TMP_Text QtdCafeHojeText;
    int QtdCafeHojeNum;

    // Start is called before the first frame update
    void Start()
    {
        QtdCafeOntemNum = PlayerPrefs.GetInt("QtdCafeOntemPrefs");
        QtdCafeHojeNum = PlayerPrefs.GetInt("QtdCafeHojePrefs");
        Debug.Log("Hoje:" + QtdCafeHojeNum);
        Debug.Log("Ontem:" + QtdCafeOntemNum);
        QtdCafeOntemText.text = QtdCafeOntemNum.ToString();
        QtdCafeHojeText.text = QtdCafeHojeNum.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Drink()
    {
        QtdCafeHojeNum++;
        QtdCafeHojeText.text = QtdCafeHojeNum.ToString();
        Debug.Log("QtdHoje:" + QtdCafeHojeNum);
    }

    public void ChangeScene()
    {
        PlayerPrefs.SetInt("QtdCafeHojePrefs", QtdCafeHojeNum);
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
        PlayerPrefs.SetInt("QtdCafeOntemPrefs", QtdCafeHojeNum);
        PlayerPrefs.SetInt("QtdCafeHojePrefs", 0);
        QtdCafeOntemNum = PlayerPrefs.GetInt("QtdCafeOntemPrefs");
        QtdCafeHojeNum = PlayerPrefs.GetInt("QtdCafeHojePrefs");
        QtdCafeOntemText.text = QtdCafeOntemNum.ToString();
        QtdCafeHojeText.text = QtdCafeHojeNum.ToString();
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("QtdCafeHojePrefs", QtdCafeHojeNum);
        PlayerPrefs.SetInt("QtdCafeOntemPrefs", QtdCafeOntemNum);
        PlayerPrefs.Save();
    }
}
