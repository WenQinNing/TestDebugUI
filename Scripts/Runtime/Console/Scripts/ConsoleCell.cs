using System;
using System.Collections;
using System.Collections.Generic;
using Iyourcar.Components.RecycleTableView;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace AppDebugger {	
	public class ConsoleCell : TableViewCell
	{
	    [SerializeField]
	    private  Toggle _selected;
	
	    [SerializeField]
	    private Text _text;
	    
	    private ConsoleNode data;
	
	    private UnityAction<ConsoleCell, ConsoleNode> onSelect;
	    private UnityAction<ConsoleCell, ConsoleNode> onDeselect;
	
	    [SerializeField]
	    CanvasGroup selfCanvas;
	
	    [SerializeField]
	    private Image backGroundImg;
	    
	    // Start is called before the first frame update
	    void Start()
	    {
	        selfCanvas = GetComponent<CanvasGroup>();
	        _selected.onValueChanged .AddListener(OnValueChanged);
	    }
	
	    private void Update()
	    {
	        if (backGroundImg.rectTransform.rect.width != backGroundImg.rectTransform.rect.height)
	        {
	            backGroundImg.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,
	               backGroundImg.rectTransform.rect.height );
	            Show();
	        }
	        
	        
	    }
	
	    public virtual void Hide()
	    {
	        selfCanvas.alpha = 0;
	        selfCanvas.interactable = false;
	        selfCanvas.blocksRaycasts = false;
	    }
	
	    public virtual void Show()
	    {
	        selfCanvas.alpha = 1;
	        selfCanvas.interactable = true;
	        selfCanvas.blocksRaycasts = true;
	    }
	
	    public void SwitchToggle(bool isOn)
	    {
	        if (isOn)
	        {
	            // print(" ConsoleCell SwitchToggle isOn " + isOn);
	        }
	        
	        _selected.SetIsOnWithoutNotify(isOn);
	    }
	
	    void OnValueChanged(bool isOn)
	    {
	        if (isOn)
	        {
	            onSelect?.Invoke(this, data);
	        }
	        else
	        {
	            
	            
	            onDeselect?.Invoke(this, data);
	        }
	    }
	    
	    private string GetLogString(ConsoleNode consoleNode)
	    {
	        return $"[{consoleNode.LogTime.ToString("HH:mm:ss.fff")}][{consoleNode.LogFrameCount.ToString()}] {consoleNode.LogMessage}";
	    }
	    
	    public virtual void Init(ConsoleNode data, 
	        UnityAction<ConsoleCell, ConsoleNode> onSelect,
	        UnityAction<ConsoleCell, ConsoleNode> onDeselect)
	    {
	        this.data = data;
	        this.onSelect = onSelect;
	        this.onDeselect = onDeselect;
	        _text.text = GetLogString(data);
	        _text.color = data.Color;
	    }
	    
	    
	}
}
