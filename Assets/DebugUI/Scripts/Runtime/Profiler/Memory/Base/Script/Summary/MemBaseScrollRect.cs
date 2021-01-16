using System.Collections;
using System.Collections.Generic;
using Iyourcar.Components.RecycleTableView;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace AppDebugger {	
	public class MemBaseScrollRect : DebugScrollRect
	{
	    
	    private List<MemBaseSectionInfo> datas;
	
	    private MemBaseSectionInfo selectedLogNode;
	
	    private UnityAction<GameObject> onSetHeader;
	
	  
	    public void Init(UnityAction<GameObject> onSetHeader)
	    {
	        sectionHeaderIdentifier = "MemBaseScrollRect_sectionHeaderIdentifier";
	        cellIdentifier = "MemBaseScrollRect_cellIdentifier";
	        this.onSetHeader = onSetHeader;
	    }
	    
	    public void Show(List<MemBaseSectionInfo> data)
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
	        MemBaseSection cell = tableView.DequeueReusable(sectionHeaderIdentifier) as MemBaseSection;
	        
	        if (cell != null)
	        {
	            cell.Init(datas[sectionIndex]);
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
