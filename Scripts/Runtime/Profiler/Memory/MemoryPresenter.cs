using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace AppDebugger {	
	public class MemoryPresenter : DebugBasePresenter
	{
     #region 变量
	
	     [SerializeField] 
	     protected CustomButton _allViewButton;
	     
	     [SerializeField]
	    protected AllViewPresenter _allViewPresenter;
	
	    [SerializeField]
	    protected CustomButton _audioClipButton;
	    
	    [SerializeField]
	    protected AudioClipPresenter _audioClipPresenter;
	
	
	    
	    [SerializeField]
	    protected CustomButton _materialButton;
	    
	    [SerializeField]
	    protected MaterialPresenter _materialPresenter;
	
	    [SerializeField]
	    protected CustomButton _meshButton;
	    
	    [SerializeField]
	    private MeshPresenter _meshPresenter;
	    
	    [SerializeField]
	    protected CustomButton _scriptableObjectButton;
	    
	    [SerializeField]
	    protected ScriptableObjectPresenter _scriptableObjectPresenter;
	
	     
	    [SerializeField]
	    protected CustomButton _shaderButton;
	    
	    [SerializeField]
	    private ShaderPresenter _shaderPresenter;
	    
	    [SerializeField]
	    protected CustomButton _summaryButton;
	    
	    [SerializeField]
	    protected MemSummaryPresenter _summaryPresenter;
	
	    [SerializeField]
	    protected CustomButton _textAssetButton;
	    
	    [SerializeField]
	    private TextAssetPresenter _textAssetPresenter;
	    
	    [SerializeField]
	    protected CustomButton _textureButton;
	    
	    [SerializeField]
	    private TexturePresenter _texturePresenter;
	
	    [SerializeField]
	    protected CustomButton _fontButton;
	
	    [SerializeField]
	    private FontPresenter _fontPresenter;
	
	    [SerializeField]
	    protected CustomButton _animationButton;
	
	    [SerializeField]
	    private AnimationClipPresenter _animationClipPresenter;
	
	
    #endregion
	
	
	    public override void Init()
	    {
	        base.Init();
	        
	        _allViewPresenter.Init();
	        _meshPresenter.Init();
	        _shaderPresenter.Init();
	        _textAssetPresenter.Init();
	        _texturePresenter.Init();
	        _audioClipPresenter.Init();
	        _materialPresenter.Init();
	        _scriptableObjectPresenter.Init();
	        _summaryPresenter.Init();
	        _fontPresenter.Init();
	        _animationClipPresenter.Init();
	
	        _fontButton.onClick = OnFontClick;
	        _animationButton.onClick = OnAnimationClick;
	        _audioClipButton.onClick = OnAudioClick;
	        _materialButton.onClick = OnMaterialClick;
	        _scriptableObjectButton.onClick = OnScriptableObjectClick;
	        _summaryButton.onClick = OnSummaryClick;
	        _allViewButton.onClick = OnAllViewClick;
	        _meshButton.onClick = OnMeshClick;
	        _shaderButton.onClick = OnShaderClick;
	        _textAssetButton.onClick = OnTextAssetClick;
	        _textureButton.onClick = OnTextureClick;
	    }
	
	    void OnAllViewClick(CustomButton button)
	    {
	        RefreshCurSelected(button, _allViewPresenter);
	    }
	
	    void OnFontClick(CustomButton button)
	    {
	        RefreshCurSelected(button, _fontPresenter);
	    }
	
	    void OnAnimationClick(CustomButton button)
	    {
	        RefreshCurSelected(button, _animationClipPresenter);
	    }
	
	
	    void OnMeshClick(CustomButton button)
	    {
	        RefreshCurSelected(button, _meshPresenter);
	    }
	    
	    void OnShaderClick(CustomButton button)
	    {
	        RefreshCurSelected(button, _shaderPresenter);
	    }
	    
	    void OnTextAssetClick(CustomButton button)
	    {
	        RefreshCurSelected(button, _textAssetPresenter);
	    }
	    
	    void OnMaterialClick(CustomButton button)
	    {
	        RefreshCurSelected(button, _materialPresenter);
	    }
	    
	    void OnScriptableObjectClick(CustomButton button)
	    {
	        RefreshCurSelected(button, _scriptableObjectPresenter);
	    }
	
	    void OnSummaryClick(CustomButton button)
	    {
	        RefreshCurSelected(button, _summaryPresenter);
	    }
	    
	    void OnAudioClick(CustomButton button)
	    {
	        RefreshCurSelected(button, _audioClipPresenter);
	    }
	    
	    void OnTextureClick(CustomButton button)
	    {
	        RefreshCurSelected(button, _texturePresenter);
	    }
	
	    public override void Show()
	    {
	        base.Show();
	        if (_curSelected == null)
	        {
	            RefreshCurSelected(_summaryButton, _summaryPresenter);
	        }
	    }
	}
}
