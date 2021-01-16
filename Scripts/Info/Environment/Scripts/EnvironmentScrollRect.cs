using System.Collections;
using System.Collections.Generic;
using Iyourcar.Components.RecycleTableView;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace AppDebugger {	
	public class EnvironmentScrollRect : DebugScrollRect
	{
	    
	    private List<EnvironmentPieceInfo> datas;
	
	    private EnvironmentPieceInfo selectedLogNode;
	    
	    public void Awake()
	    {
	        sectionHeaderIdentifier = "EnvironmentScrollRect_sectionHeaderIdentifier";
	    }
	    
	    public void Show(List<EnvironmentPieceInfo> data)
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
	        EnvironmentCell cell = tableView.DequeueReusable(sectionHeaderIdentifier) as EnvironmentCell;
	        
	        if (cell != null)
	        {
	            cell.Init(datas[sectionIndex]);
	        }
	        
	        return cell;
	    }
	    
	}
}
