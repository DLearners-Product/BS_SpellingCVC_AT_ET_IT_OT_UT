using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class EnablerCmtsDB
{
    public string welcome;
    public string intro;
    public string purple_palace;
    public string slot_machine;
    public string identify_word_family;
    public string unscramble_words;
    public string word_puzzle;
    public string spin_wheel;
    public string goodbye;

    public EnablerCmtsDB()
    {
        welcome = Main_Blended.OBJ_main_blended.enablerComments[0];
        intro = Main_Blended.OBJ_main_blended.enablerComments[1];
        purple_palace = Main_Blended.OBJ_main_blended.enablerComments[2];
        slot_machine = Main_Blended.OBJ_main_blended.enablerComments[3];
        identify_word_family = Main_Blended.OBJ_main_blended.enablerComments[4];
        unscramble_words = Main_Blended.OBJ_main_blended.enablerComments[5];
        word_puzzle = Main_Blended.OBJ_main_blended.enablerComments[6];
        spin_wheel = Main_Blended.OBJ_main_blended.enablerComments[7];
        goodbye = Main_Blended.OBJ_main_blended.enablerComments[8];
       
    }
}