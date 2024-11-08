using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor;


public class NewBehaviourScript : MonoBehaviour
{


    public class JaggedArray{
        public string stringValue;
        public bool booleanValue;
    }

    private JaggedArray[][] ja;

    private void InitializeCombinedJaggedArray(){
        ja = new JaggedArray[25][];
    }

    private List<int> usedIndicies = new List<int>();

    public Button button, button1, button2;
    public Image imageComponent0, imageComponent1, imageComponent2;
    public List<string> imageListString = new List<string>();

    private List<Image> imageList = new List<Image>();

    void Start()
    {
        imageList.Add(imageComponent0);
        imageList.Add(imageComponent1);
        imageList.Add(imageComponent2);
        InitializeCombinedJaggedArray();

        BuildList2D();

        LoadImage(ja[0][0].stringValue, imageComponent0);
        LoadImage(ja[1][0].stringValue, imageComponent1);
        LoadImage(ja[2][0].stringValue, imageComponent2);
    }

    private void LoadImage(string imagePath, Image image)
    {
        Sprite loadedSprite = Resources.Load<Sprite>(imagePath);
        image.sprite = loadedSprite;
    }

    


    private void BuildList2D(){
        for (int i = 0; i <= 24; i++)
        {
            string image = "skill_alpha/skill_alpha_" + i;

            ja[i] = new JaggedArray[]{
            new JaggedArray {stringValue = image, booleanValue = true},
            };

            Debug.Log(ja[i][0].stringValue);

        }
    }

    private int GetRandom(){
        int randomNumber;
        do{
            randomNumber = UnityEngine.Random.Range(0, 24);
        }while(usedIndicies.Contains(randomNumber));

        usedIndicies.Add(randomNumber);
        return randomNumber;   
    }

    private void SetAllImages(){
        usedIndicies.Clear();

        for(int i = 0; i < 3; i++){
            int randomNumber = GetRandom();
            string path = ja[randomNumber][0].stringValue;
            LoadImage(path, imageList[i]);
        }

    }

    public void OnClicked(Image i)
    {
        string spritePath = AssetDatabase.GetAssetPath(i.sprite);
        Debug.Log("Button Sprite Path: " + spritePath + " " + i.name + " " + imageComponent0.name);

        SetAllImages();
        // Debug.Log("Clicked!\n" + ja[randomNumber][0].stringValue);

    }

}
