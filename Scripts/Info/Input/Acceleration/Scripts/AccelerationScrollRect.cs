using System.Collections;
using System.Collections.Generic;
using Iyourcar.Components.RecycleTableView;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace AppDebugger {	
	public class AccelerationScrollRect : DebugScrollRect
	{
	    
	    private List<AccelerationPieceInfo> datas;
	
	    private AccelerationPieceInfo selectedLogNode;
	    
	    public void Init()
	    {
	        sectionHeaderIdentifier = "ConsoleScrollRect_sectionHeaderIdentifier";
	    }
	    
	    public void Show(List<AccelerationPieceInfo> data)
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
	        return 130;
	    }
	
	
	    protected override TableViewCell HeaderForSection(TableView tableView, int sectionIndex)
	    {
	        AccelerationCell cell = tableView.DequeueReusable(sectionHeaderIdentifier) as AccelerationCell;
	        
	        if (cell != null)
	        {
	            cell.Init(datas[sectionIndex]);
	        }
	        
	        return cell;
	    }
	    
	}
}
