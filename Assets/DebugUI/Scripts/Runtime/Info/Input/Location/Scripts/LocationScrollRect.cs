using System.Collections;
using System.Collections.Generic;
using Iyourcar.Components.RecycleTableView;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace AppDebugger {	
	public class LocationScrollRect : DebugScrollRect
	{
	    
	    private List<LocationPieceInfo> datas;
	
	    private LocationPieceInfo selectedLogNode;
	    
	    public void Awake()
	    {
	        sectionHeaderIdentifier = "LocationScrollRect_sectionHeaderIdentifier";
	    }
	    
	    public void Show(List<LocationPieceInfo> data)
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
	        LocationCell cell = tableView.DequeueReusable(sectionHeaderIdentifier) as LocationCell;
	        
	        if (cell != null)
	        {
	            cell.Init(datas[sectionIndex]);
	        }
	        
	        return cell;
	    }
	    
	}
}
