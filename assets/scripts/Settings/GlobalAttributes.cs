using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* Delete Slider related objects AND UnityEngine.UI.
 */
namespace ChargedUp.Settings
{
    public class GlobalAttributes
    {

        public static float Difficulty;
        public static MageType PlayerMage;

        public static void setPlayerMage(MageType mage){
            PlayerMage = mage;
        }

        public static void SetDifficulty(float dif){
            Difficulty = dif;
        }
    }
}
