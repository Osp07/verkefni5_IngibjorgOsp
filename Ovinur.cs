using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ovinur : MonoBehaviour
{
    public Transform player;
    public static int count=0;
    // breyta sem heldur utan um hversu mörg stig leikmaður hefur
    private TextMeshProUGUI countText;
    // textin sem að kemur upp og segir leikmanni hve mörg stig hann hefur


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        countText = GameObject.Find("Text").GetComponent<TextMeshProUGUI>();
        // setjum inn virkni textans
        count = 0;
        // núllstillum stigin
        SetCountText();
        // köllum í breytuna sem að setur textan á skjáin
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnCollisionEnter(Collision collision)
    {
        // það sem að kemur við kassan
        if (collision.collider.tag == "Player")
        // ef að það sem kemur við kassann er kúla
        {
            count = count + 1;
            // leikmaður fær eitt stig
            SetCountText();
            // köllum í fallið sem að setur stigafjöldan á skjáin
            Destroy(gameObject);
            gameObject.SetActive(false);
            // eyðum við kassanum
             Debug.Log("varð fyrir kúlu");
            
        }
    }
    void SetCountText()//hér er aðferðin
    {
        countText.text = "Stig: " + count.ToString();
        // uppfærum stigafjöldan á skjánum
    }
}
