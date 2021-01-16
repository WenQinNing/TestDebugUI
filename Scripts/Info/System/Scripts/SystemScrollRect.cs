using System.Collections;
using System.Collections.Generic;
using Iyourcar.Components.RecycleTableView;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace AppDebugger {	
	public class SystemScrollRect : DebugScrollRect
	{
	    
	    private List<SystemPieceInfo> datas;
	
	    private SystemPieceInfo selectedLogNode;
	    
	    public void Init()
	    {
	        sectionHeaderIdentifier = "ConsoleScrollRect_sectionHeaderIdentifier";
	    }
	    
	    public void Show(List<SystemPieceInfo> data)
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
	        SystemCell cell = tableView.DequeueReusable(sectionHeaderIdentifier) as SystemCell;
	        
	        if (cell != null)
	        {
	            cell.Init(datas[sectionIndex]);
	        }
	        
	        return cell;
	    }
	    
	}
}
