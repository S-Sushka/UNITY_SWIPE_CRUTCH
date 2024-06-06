using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// >>> WHATS_DOING_ON
// 'T' - Просто нажатие
// 'U' - Свайп вверх
// 'D' - Свайп вниз
// 'R' - Свайп вправо
// 'L' - Свайп влево

// >>> ACTION_AVAILABLE
// TRUE - Устанавливается сама когда было совершено новое действие
// FALSE - Сбрасывается при использовании - вне класса

public class SWIPE_CRUTCH : MonoBehaviour
{
    Touch touch;
    float X_remember = 0.0f;
    float Y_remember = 0.0f;

    public char WHATS_GOING_ON = ' ';
    public bool ACTION_AVAILABLE = false;

    float accuracy_forDetectTouch = 0.3f;

    void Start()
    {
        
    }
    
    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                X_remember = touch.position.x;
                Y_remember = touch.position.y;
            }

            if (touch.phase == TouchPhase.Ended)
            {
                if (get_DeltaX() > get_DeltaY())
                {
                    // HORIZONTAL SWIPE
                    if (X_remember < touch.position.x)
                    {
                        WHATS_GOING_ON = 'R';
                        ACTION_AVAILABLE = true;
                    }

                    else if (X_remember > touch.position.x)
                    {
                        WHATS_GOING_ON = 'L';
                        ACTION_AVAILABLE = true;
                    }
                }
                else if (get_DeltaX() < get_DeltaY())
                {
                    // VERTICAL SWIPE
                    if (Y_remember < touch.position.y)
                    {
                        WHATS_GOING_ON = 'U';
                        ACTION_AVAILABLE = true;
                    }

                    else if (Y_remember > touch.position.y)
                    {
                        WHATS_GOING_ON = 'D';
                        ACTION_AVAILABLE = true;
                    }
                }
                else if (get_DeltaX() <= accuracy_forDetectTouch && get_DeltaY() <= accuracy_forDetectTouch) 
                {
                    WHATS_GOING_ON = 'T';
                    ACTION_AVAILABLE = true;
                }
            }            
        }
    }

    float get_DeltaX() 
    {
        return abs(touch.position.x - X_remember);
    }
    float get_DeltaY()
    {
        return abs(touch.position.y - Y_remember);
    }

    float abs(float number)
    {
        if (number < 0)
            return number * -1;
        else
            return number;
    }
}
