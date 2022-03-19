using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;

public class WireTask : MonoBehaviour
{
    public List<Color> _wireColors = new List<Color>();
    public List<Wire> _leftWires = new List<Wire>();
    public List<Wire> _rightWires = new List<Wire>();

    private List<Color> _availableColors;
    private List<int> _availableLeftWireIndex;
    private List<int> _availableRightWireIndex;
    public Wire CurrentDraggedwire;
    public Wire CurrentHoveredWire;
    public bool gameComplete = false;
    public string nextScene;
    public Text success;
    public int helpTime = 5;
    public float helpStartTime;

    private void Start()
    {
        helpStartTime = Time.time;
        _availableColors = new List<Color>(_wireColors);
        _availableLeftWireIndex = new List<int>();
        _availableRightWireIndex = new List<int>();

        for(int i = 0; i<_leftWires.Count; i++)
        {
            _availableLeftWireIndex.Add(i);
        }

        for (int i = 0; i < _rightWires.Count; i++)
        {
            _availableRightWireIndex.Add(i);
        }

        while(_availableColors.Count > 0 && _availableLeftWireIndex.Count > 0 && _availableRightWireIndex.Count > 0)
        {
            Color pickedColor = _availableColors[Random.Range(0, _availableColors.Count)];
            int pickedLeftWireIndex = Random.Range(0, _availableLeftWireIndex.Count);
            int pickedRightWireIndex = Random.Range(0, _availableRightWireIndex.Count);

            _leftWires[_availableLeftWireIndex[pickedLeftWireIndex]].SetColor(pickedColor);
            _rightWires[_availableRightWireIndex[pickedRightWireIndex]].SetColor(pickedColor);

            _availableColors.Remove(pickedColor);
            _availableLeftWireIndex.RemoveAt(pickedLeftWireIndex);
            _availableRightWireIndex.RemoveAt(pickedRightWireIndex);
        }
    }

    private void Update()
    {

        if (gameComplete)
        {
            success.text = "Success!";
            Invoke("switchScene", 2);
        }
        if ((Time.time - helpStartTime) > helpTime)
        {
            // EditorUtility.DisplayDialog("Are you stuck?", "Drag the left color to it's matching color on the right.", "OK");
            helpStartTime = Time.time;
        }
    }

    private void switchScene()
    {
        SceneManager.LoadScene(nextScene);
    }

}
