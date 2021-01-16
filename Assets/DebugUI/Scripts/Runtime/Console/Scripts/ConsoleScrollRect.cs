using System.Collections;
using System.Collections.Generic;
using Iyourcar.Components.RecycleTableView;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace AppDebugger {	
	public class ConsoleScrollRect : DebugScrollRect
	{
	    [SerializeField]
	    private RectTransform _scrollRect;
	
	    private ConsoleCell curSelected;
	
	    private List<ConsoleNode> datas;
	
	    private UnityAction<ConsoleNode> onSelect;
	
	    private UnityAction<ConsoleNode> onHandleDeselect;
	    
	    private ConsoleNode _selectedConsoleNode;
	        
	    
	    [SerializeField]
	    private RectTransform bgRect;
	    
	    [SerializeField]
	    private RectTransform toggleRect;
	
	    [SerializeField]
	    private RectTransform selectedRect;
	    
	    
	    public void Init(UnityAction<ConsoleNode> onSelect, UnityAction<ConsoleNode> onDeselect)
	    {
	        sectionHeaderIdentifier = "ConsoleScrollRect_sectionHeaderIdentifier";
	        this.onSelect = onSelect;
	        onHandleDeselect = onDeselect;
	        
	    }
	    
	    public void Show(List<ConsoleNode> data)
	    {
	        datas = data;
	        InnerShow();
	    }
	
	
	    public void SetFull(bool isFull)
	    {
	        if (isFull)
	        {
	            _scrollRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 
	                bgRect.rect.height  - toggleRect.rect.height );
	        }
	        else
	        {
	            _scrollRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 
	                bgRect.rect.height - toggleRect.rect.height - selectedRect.rect.height  - 10);
	        }
	    }
	    
	    protected override int NumberOfSections(TableView tableView)
	    {
	        return datas.Count;
	    }
	    
	    protected override float HeightForHeaderInSection(TableView tableView, int sectionIndex)
	    {
	        return 144;
	    }
	
	    protected override TableViewCell HeaderForSection(TableView tableView, int sectionIndex)
	    {
	        
	        ConsoleCell cell = tableView.DequeueReusable(sectionHeaderIdentifier) as ConsoleCell;
	        
	        if (cell != null)
	        {
	            cell.Init(
	                datas[sectionIndex],
	                OnSelect,
	                OnHandleDeselect);
	            
	            cell.SwitchToggle(false);
	            
	            if (datas[sectionIndex] == _selectedConsoleNode)
	            {
	                cell.SwitchToggle(true);
	                curSelected = cell;
	            }
	        }
	        
	        return cell;
	    }
	
	
	    void OnSelect(ConsoleCell cell, ConsoleNode consoleNode)
	    {
	        onSelect?.Invoke(consoleNode);
	        _selectedConsoleNode = consoleNode;
	        
	        // print(" ConsoleScrollRect OnSelect curSelected != null " +
	        //         (curSelected != null));
	        
	        if (curSelected != null)
	        {
	            curSelected.SwitchToggle(false);
	        }
	        
	        curSelected = cell;
	        
	        // print(" ConsoleScrollRect OnSelect curSelected Set");
	        
	    }
	
	    
	    void OnHandleDeselect(ConsoleCell cell, ConsoleNode consoleNode)
	    {
	        //手动取消勾选当前已选的某项
	        if (_selectedConsoleNode == consoleNode)
	        {
	            onHandleDeselect?.Invoke(consoleNode);
	            
	            curSelected = null;
	            _selectedConsoleNode = null;

	        }
	    }
	    
	    
	}
}
