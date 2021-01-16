using System.Collections;
using System.Collections.Generic;
using Iyourcar.Components.RecycleTableView;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace AppDebugger {	
	public class GyroscopeScrollRect : DebugScrollRect
	{
	    
	    private List<GyroscopePieceInfo> datas;
	
	    private GyroscopePieceInfo selectedLogNode;
	    
	    public void Init()
	    {
	        sectionHeaderIdentifier = "ConsoleScrollRect_sectionHeaderIdentifier";
	    }
	    
	    public void Show(List<GyroscopePieceInfo> data)
	    {
	        datas = data;
	        InnerShow();
	    }
	    
	    protected override int NumberOfSections(TableView tableView)
	    {
	        return datas.Count;
	    }
	    
	    protected override float HeightForHeaderInSection(TableView tableView, int sectionIndex)
	    {
	        return 120;
	    }
	
	
	    protected override TableViewCell HeaderForSection(TableView tableView, int sectionIndex)
	    {
	        GyroscopeCell cell = tableView.DequeueReusable(sectionHeaderIdentifier) as GyroscopeCell;
	        
	        if (cell != null)
	        {
	            cell.Init(datas[sectionIndex]);
	        }
	        
	        return cell;
	    }
	    
	}
}
