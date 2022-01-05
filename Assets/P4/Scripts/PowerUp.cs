using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowerUpType { None,Pushback,Rockets,Smash } //None - бездействие, Pushback - отталкивание врага, Rockets - запуск самонаводящихся ракет во врага, Smash - прыжок персонажа игрока, который отталкивает близ находящихся врагов

public class PowerUp : MonoBehaviour
{
    public PowerUpType powerUpType;
}
