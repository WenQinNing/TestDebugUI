using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace AppDebugger {	
	public class QualityHeader : MonoBehaviour
	{
    #region 变量
	
	    [SerializeField]
	    private Toggle fastestToggle;
	    
	    [SerializeField]
	    private Toggle fastToggle;
	    
	    [SerializeField]
	    private Toggle simpleToggle;
	    
	    [SerializeField]
	    private Toggle goodToggle;
	    
	    [SerializeField]
	    private Toggle beautifulToggle;
	    
	    [SerializeField]
	    private Toggle fantasticToggle;
	 
	    [SerializeField]
	    private Toggle expensiveToggle;
	
	    [SerializeField]
	    private CanvasGroup _canvasGroup;
	
	    private UnityAction<bool> onFastestToggle;
	    private UnityAction<bool> onFastToggle;
	    private UnityAction<bool> onSimpleToggle;
	    private UnityAction<bool> onGoodToggle;
	    private UnityAction<bool> onBeautifulToggle;
	    private UnityAction<bool> onFantasticToggle;
	    private UnityAction<bool> onExpansiveToggle;
	    
    #endregion
	    
	    private void Awake()
	    {
	        expensiveToggle.onValueChanged.AddListener(OnExpensiveToggleSwitch);
	        fastestToggle.onValueChanged.AddListener(OnFastestToggleSwitch);
	        fastToggle.onValueChanged.AddListener(OnFastToggleSwitch);
	        simpleToggle.onValueChanged.AddListener(OnSimpleToggleSwitch);
	        goodToggle.onValueChanged.AddListener(OnGoodToggleSwitch);
	        beautifulToggle.onValueChanged.AddListener(OnBeautifulToggleSwitch);
	        fantasticToggle.onValueChanged.AddListener(OnFantisticToggleSwitch);
	
	    }
	
	    private void Start()
	    {
	        _canvasGroup = GetComponent<CanvasGroup>();
	        _canvasGroup.blocksRaycasts = true;
	        _canvasGroup.interactable = true;
	        transform.localScale = Vector3.one;
	    }
	
	
	    public void SetOnFastestToggle(UnityAction<bool> onFastestToggle)
	    {
	        this.onFastestToggle = onFastestToggle;
	    }
	    
	    public void SetOnFastToggle(UnityAction<bool> onFastToggle)
	    {
	        this.onFastToggle = onFastToggle;
	    }
	    
	    public void SetOnSimpleToggle(UnityAction<bool> onSimpleToggle)
	    {
	        this.onSimpleToggle = onSimpleToggle;
	    }
	    
	    public void SetOnGoodToggle(UnityAction<bool> onGoodToggle)
	    {
	        this.onGoodToggle = onGoodToggle;
	    }
	    
	    public void SetOnBeautifulToggle(UnityAction<bool> onBeautifulToggle)
	    {
	        this.onBeautifulToggle = onBeautifulToggle;
	    }
	    
	    public void SetOnFantasticToggle(UnityAction<bool> onFantasticToggle)
	    {
	        this.onFantasticToggle = onFantasticToggle;
	    }
	    
	    public void SetOnExpensiveToggle(UnityAction<bool> onExpansiveToggle)
	    {
	        this.onExpansiveToggle = onExpansiveToggle;
	    }
	
	    
	    public void InitToggle()
	    {
	        switch (QualitySettings.GetQualityLevel())
	        {
	            case 0:
	                fastestToggle.isOn = true;
	                break;
	
	            case 1:
	                fastToggle.isOn = true;
	                break;
	
	            case 2:
	                simpleToggle.isOn = true;
	                break;
	
	            case 3:
	                goodToggle.isOn = true;
	                break;
	
	            case 4:
	                beautifulToggle.isOn = true;
	                break;
	
	            case 5:
	                fantasticToggle.isOn = true;
	                break;
	        }
	    }
	
	    public void OnExpensiveToggleSwitch(bool isOn)
	    {
	        onExpansiveToggle?.Invoke(isOn);
	    }
	
	    public void OnFastestToggleSwitch(bool isOn)
	    {
	        onFastestToggle?.Invoke(isOn);
	    }
	    
	    public void OnFastToggleSwitch(bool isOn)
	    {
	        onFastToggle?.Invoke(isOn);
	    }
	
	    public void OnSimpleToggleSwitch(bool isOn)
	    {
	        onSimpleToggle?.Invoke(isOn);
	    }
	    
	    public void OnGoodToggleSwitch(bool isOn)
	    {
	        onGoodToggle?.Invoke(isOn);
	    }
	    
	    public void OnBeautifulToggleSwitch(bool isOn)
	    {
	        onBeautifulToggle?.Invoke(isOn);
	    }
	    
	    public void OnFantisticToggleSwitch(bool isOn)
	    {
	        onFantasticToggle?.Invoke(isOn);
	    }
	    
	
	}
}
