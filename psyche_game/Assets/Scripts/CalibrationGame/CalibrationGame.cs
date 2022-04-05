using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CalibrationGame : MonoBehaviour
{

    private LineRenderer _lineRender;
    // Start is called before the first frame update
    float x_value;
    int line_state;
    int wins;
    bool valid;
    List<Vector2> points;
    private BoxCollider2D col;
    public string nextScene;
    // -3.8 to -8

    float line_speed;
    void Start()
    {
        Application.targetFrameRate = 60;
        _lineRender = GetComponent<LineRenderer>();
        line_state = 0;
        x_value = 0.0f;
        line_speed = 0.1f;
        wins = 0;
        valid = false;

    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (line_state < 2)
            {
                line_state = 2;

                if (isValid())
                {
                    wins += 1;
                    line_speed += .05f;
                    Debug.Log("Wins " + wins);
                    if (wins == 3)
                    {
                        Invoke("switchScene", 2);
                    }
                }
            }
            else if (line_state == 2)
            {
                if (wins != 3)
                {
                    line_state = 0;
                    x_value = 0;
                }
                
                
            }

        }

        if (line_state == 0)
        {
            if (x_value < 15)
            {
                x_value += line_speed;
            }
            else
            {
                line_state = 1;
            }
            _lineRender.SetPosition(0, new Vector3(x_value, 10, 0));


        }
        else if (line_state == 1)
        {
            if (x_value > -15)
            {
                x_value -= line_speed;
            }
            else
            {
                line_state = 0;
            }
            _lineRender.SetPosition(0, new Vector3(x_value, 10, 0));

        }

    }

    private bool isValid()
    {
        if (x_value < -3.8 && x_value > -8)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void switchScene()
    {
        SceneManager.LoadScene(nextScene);
    }

}
