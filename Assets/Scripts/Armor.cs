using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Armor : MonoBehaviour
{
    public Slider slider;

    public void setArmor(float armor) {
        slider.value = armor;
    }
}
