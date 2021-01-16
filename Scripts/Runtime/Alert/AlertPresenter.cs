using System.Collections;
using System.Collections.Generic;
using AppDebugger;
using UnityEngine;

public class AlertPresenter : DebugBasePresenter
{
   private AlertView _alertView;

   public override void Init()
   {
      base.Init();
      if (_view != null)
      {
         _alertView = _view as AlertView;
      }
      Hide();
   }

   public void ShowStr(string toShowStr)
   {
      _view.Show();
      _alertView.RefreshStr(toShowStr);
   }
   
   
       
}
