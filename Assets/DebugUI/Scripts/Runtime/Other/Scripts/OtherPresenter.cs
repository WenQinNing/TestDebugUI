using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AppDebugger {	
	public class OtherPresenter : DebugBasePresenter
	{
	    private OtherModel _otherModel = new OtherModel();
	
	    [SerializeField]
	    private int maxDataCount = 50;
	
	    [SerializeField]
	    private OtherView _otherView;
	
	    float counter;
	
	    public override void Init()
	    {
	        base.Init();
	
	        if (_view != null)
	        {
	            _otherView = _view as OtherView;
	        }
	
	        _otherModel.Init(maxDataCount);
	    }
	
	
	    protected override  void UpdateShow()
	    {
	        base.UpdateShow();
	        
	        #if UNITY_EDITOR
	        counter += Time.deltaTime;
	
	        if (counter >= 0.5)
	        {
	            counter = 0;
	            float f = Random.Range(100000f, 1000000000f);
	            DebuggerUtil.LogSpecial(f.ToString() + "阿斯顿强哥答复鬼地方个人头热任天堂" +
	                                    "人与人特utyutydsfsddsfsdfew werwer" +
	                                    "werwerwer" +
	                                    "w wer");
	        }
	        
	        
	        #endif

		    string str = _otherModel.GetToShow();
		    _otherView.RefreshText(str);
	    }
	    
	    
	
	 
	}
}
