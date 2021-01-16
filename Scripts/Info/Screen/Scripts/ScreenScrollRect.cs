using System.Collections;
using System.Collections.Generic;
using Iyourcar.Components.RecycleTableView;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace AppDebugger {	
	public class ScreenScrollRect : DebugScrollRect
	{
	    
	    private List<ScreenPieceInfo> datas;
	
	    private ScreenPieceInfo selectedLogNode;
	    
	    public void Init()
	    {
	        sectionHeaderIdentifier = "EnvironmentScrollRect_sectionHeaderIdentifier";
	    }
	    
	    public void Show(List<ScreenPieceInfo> data)
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
	        return 220;
	    }
	
	    protected override TableViewCell HeaderForSection(TableView tableView, int sectionIndex)
	    {
	        ScreenCell cell = tableView.DequeueReusable(sectionHeaderIdentifier) as ScreenCell;
	        
	        if (cell != null)
	        {
	            cell.Init(datas[sectionIndex]);
	        }
	        
	        return cell;
	    }
	    
	}
}
