using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{

    private Animator playerAnim; //this stores teh players animator component

    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>(); //sets playerAnim to the attached animator component on the player
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)) //detects if the player is walkign if so play walk animation if not play idle animation
        {
            playerAnim.SetBool("isWalking", true);
        }
        else
        {
            playerAnim.SetBool("isWalking", false);

        }
    }
}
