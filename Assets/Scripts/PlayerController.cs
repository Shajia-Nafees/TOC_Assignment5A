using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Text;
using System;
using JetBrains.Annotations;
using System.Linq;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText1;
    public Text player;
    public Text countText;
    private int count; 
    private Rigidbody rb;


    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        
        countText1.text = "";
    }

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
        rb.AddForce (movement * speed);
    }
    void OnTriggerEnter(Collider other)
    {
        string palString = other.GetComponentInChildren<TextMesh>().text;
        bool flg = IsPalindrome(palString);
        if (flg.Equals(true) && other.gameObject.CompareTag("Pick Up"))
        {        
            other.gameObject.SetActive(false);
            count = count + 1;
            player.text = count.ToString();
            SetCountText();
            
        }
    }

    void SetCountText()
    {
        countText.text = "Total Palindrome: " + count.ToString();

        if (count >= 3)
        {

            countText1.text = "Maximum Collected Palindromes Successfully are:" + count;

        }

    }
   
    public bool IsPalindrome(string string1)
    {
        char[] ch = string1.ToCharArray();
        Array.Reverse(ch);
        string rev = new string(ch);
        bool b = string1.Equals(rev, StringComparison.OrdinalIgnoreCase);
        if (b == true)
        {
           
            return true;
        }
        return false;
    }
    
}
