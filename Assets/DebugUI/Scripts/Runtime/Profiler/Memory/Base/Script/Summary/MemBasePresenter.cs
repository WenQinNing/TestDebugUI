using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AppDebugger {	
	public class MemBasePresenter<T> : DebugBasePresenter where T : Object
	{
	    protected MemBaseModel<T> _model = new MemBaseModel<T>();
	
	    private MemBaseView<T> _memBaseView;
	
	    public override void Init()
	    {
	        base.Init();
	        if (_view != null)
	        {
	            _memBaseView = _view as MemBaseView<T>; 
	        }
	        
	        if (_memBaseView != null)
	        {
	            _memBaseView.SetOnButtonClick(OnButtonClick);
	        }
	    }
	
	    void OnButtonClick()
	    {
	        List<MemBaseSectionInfo> toShows = _model.GetData();
	        // Debug.Log("  MemBaseView  OnButtonClick ");
	       
	        _memBaseView.RefreshData(toShows);
	        _memBaseView.SetSumText(_model.GetSummStr());
	    }
	    
	    public override void Show()
	    {
	        base.Show();
	        List<MemBaseSectionInfo> toShows = _model.GetData();
	
	        if (_memBaseView != null)
	        {
	            _memBaseView .RefreshData(toShows);
	            _memBaseView.SetSumText(_model.GetSummStr());
	        }
	        
	    }
	}
}
