using System.Collections;
using System.Collections.Generic;
using Iyourcar.Components.RecycleTableView;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace AppDebugger {	
	public class QualityScrollRect : DebugScrollRect
	{
	    
	    private List<QualitySectionInfo> datas;
	
	    private QualitySectionInfo selectedLogNode;
	
	    private UnityAction<GameObject> onSetHeader;
	    
	    public void Init(UnityAction<GameObject> onSetHeader)
	    {
	        sectionHeaderIdentifier = "ConsoleScrollRect_sectionHeaderIdentifier";
	        cellIdentifier = "ConsoleScrollRect_cellIdentifier";
	        this.onSetHeader = onSetHeader;
	    }
	    
	    public void Show(List<QualitySectionInfo> data)
	    {
	        datas = data;
	        InnerShow();
	    }
	    
	    protected override int NumberOfSections(TableView tableView)
	    {
	        return datas.Count;
	    }
	
	    protected override int NumberOfRowsInSection(TableView tableView, int sectionIndex)
	    {
	        return datas[sectionIndex].Infos.Count;
	    }
	
	    protected override float HeightForHeaderInSection(TableView tableView, int sectionIndex)
	    {
	        return 200;
	    }
	
	    protected override float HeightForRowSection(TableView tableView, int sectionIndex, int cellIndex)
	    {
	        return 120;
	    }
	
	    protected override TableViewCell HeaderForSection(TableView tableView, int sectionIndex)
	    {
	        QualitySection cell = tableView.DequeueReusable(sectionHeaderIdentifier) as QualitySection;
	        
	        if (cell != null)
	        {
	            cell.Init(datas[sectionIndex]);
	        }
	        
	        return cell;
	    }
	
	    protected override TableViewCell CellForRow(TableView tableView, int sectionIndex, int cellIndex)
	    {
	         QualityCell cell = tableView.DequeueReusable(cellIdentifier) as QualityCell;
	                
	        if (cell != null)
	        {
	            cell.Init(datas[sectionIndex].Infos[cellIndex]);
	        }
	                
	         return cell;
	    }
	
	    protected override void SetHeader()
	    {
	        //设置Header View
	        tableView.headerHeight = headerBarHeight;
	        GameObject headerViewObj = Instantiate(headerListPrefab) ;
	        TableViewHeader header = headerViewObj.GetComponent<TableViewHeader>();
	        tableView.SetHeaderView(header);
	        tableView.SetHeaderViewGanveGroupActive(false);
	        onSetHeader?.Invoke(headerViewObj);
	        
	    }
	    
	}
}
