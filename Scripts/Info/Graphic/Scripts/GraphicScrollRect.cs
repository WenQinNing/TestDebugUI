using System.Collections;
using System.Collections.Generic;
using Iyourcar.Components.RecycleTableView;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace AppDebugger {	
	public class GraphicScrollRect : DebugScrollRect
	{
	    
	    private List<GraphicPieceInfo> datas;
	
	    private GraphicPieceInfo selectedLogNode;
	    
	    public void Init()
	    {
	        sectionHeaderIdentifier = "ConsoleScrollRect_sectionHeaderIdentifier";
	    }
	    
	    public void Show(List<GraphicPieceInfo> data)
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
	        GraphicCell cell = tableView.DequeueReusable(sectionHeaderIdentifier) as GraphicCell;
	        
	        if (cell != null)
	        {
	            cell.Init(datas[sectionIndex]);
	        }
	        
	        return cell;
	    }
	    
	}
}
