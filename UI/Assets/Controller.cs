using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class Controller : MonoBehaviour
{
    [Header("Read Only values")]
    [SerializeField][Range(-1, 1)] private float _f;
    [SerializeField] private string _s;
    
    [Header("Document")]
    [SerializeField] private UIDocument _uiDocument;
    
    private Button _button;
    private Slider _slider;
    private Label _label;

    private int _clickCount;

    //Add logic that interacts with the UI controls in the `OnEnable` methods
    private void OnEnable()
    {
        VisualElement panel = _uiDocument.rootVisualElement.Q("MainPanel");
        
        TextField textField = _uiDocument.rootVisualElement.Q("TextInput") as TextField;
        textField?.RegisterCallback<ChangeEvent<string>>(FieldChange);
        
        if(panel != null)                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           
        {
            // The UXML is already instantiated by the UIDocument component
            _button = panel.Q("DebugLogButton") as Button;
            _slider = panel.Q("FloatSlider") as Slider;
            _label = panel.Q("StringLabel") as Label;

            _button?.RegisterCallback<ClickEvent>(PrintClickMessage);
            _slider?.RegisterCallback<ChangeEvent<float>>(SliderChange);
        }
    }

    private void SliderChange(ChangeEvent<float> evt)
    {
        Debug.Log($"{evt.newValue} -> {evt.target}");
        _f = evt.newValue;
    }

    private void OnDisable()
    {
        _button?.UnregisterCallback<ClickEvent>(PrintClickMessage);
    }

    private void PrintClickMessage(ClickEvent evt)
    {
        ++_clickCount;

        Debug.Log("button" + _button.name + " was clicked!");
    }

    private void FieldChange(ChangeEvent<string> evt)
    {
        Debug.Log($"{evt.newValue} -> {evt.target}");
        _s = evt.newValue;
        _label.text = _s;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
