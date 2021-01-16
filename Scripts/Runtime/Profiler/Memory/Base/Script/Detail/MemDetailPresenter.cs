using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AppDebugger {	
	public class MemDetailPresenter<T> : DebugBasePresenter where T : Object
	{
	    protected MemDetailBaseModel<T> _model = new MemDetailBaseModel<T>();
	
	    private MemDetailView<T> _memBaseView;
	
	    public override void Init()
	    {
	        base.Init();
	        if (_view != null)
	        {
	            _memBaseView = _view as MemDetailView<T>; 
	        }
	        
	        if (_memBaseView != null)
	        {
	            _memBaseView.SetOnButtonClick(OnButtonClick);
	        }
	    }
	
	    void OnButtonClick()
	    {
	        List<MemDetailInfo> toShows = _model.GetData();
	        // Debug.Log("  MemBaseView  OnButtonClick ");
	       
	        _memBaseView.RefreshData(toShows);
	        _memBaseView.SetSumText(_model.GetSummStr());
	    }
	    
	    public override void Show()
	    {
	        base.Show();
	        List<MemDetailInfo> toShows = _model.GetData();
	
	        if (_memBaseView != null)
	        {
	            _memBaseView .RefreshData(toShows);
	            _memBaseView.SetSumText(_model.GetSummStr());
	        }
	        
	    }
	}
}
