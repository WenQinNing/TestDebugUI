using System.Collections;
using System.Collections.Generic;
using Iyourcar.Components.RecycleTableView;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace AppDebugger {	
	public class ProfilerSummaryScrollRect : DebugScrollRect
	{
	    
	    private List<ProfilerSummaryPieceInfo> datas;
	
	    private ProfilerSummaryPieceInfo selectedLogNode;
	    
	    public void Init()
	    {
	        sectionHeaderIdentifier = "ProfilerSummaryScrollRect_sectionHeaderIdentifier";
	    }
	    
	    public void Show(List<ProfilerSummaryPieceInfo> data)
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
	        ProfilerSummaryCell cell = tableView.DequeueReusable(sectionHeaderIdentifier) as ProfilerSummaryCell;
	        
	        if (cell != null)
	        {
	            cell.Init(datas[sectionIndex]);
	        }
	        
	        return cell;
	    }
	    
	}
}
