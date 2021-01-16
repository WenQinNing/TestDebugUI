using System.Collections;
using System.Collections.Generic;
using Iyourcar.Components.RecycleTableView;
using UnityEngine;
using UnityEngine.Serialization;
using Object = System.Object;

namespace AppDebugger {	
	public class DebugScrollRect : MonoBehaviour
	{ 
	    protected string sectionHeaderIdentifier = "";
	    protected string cellIdentifier = "";
	
	   [SerializeField]
	   protected TableView tableView;
	    
	    protected bool _init;
	
	    [SerializeField]
	    protected GameObject sectionPrefab;
	    
	    [SerializeField]
	    protected GameObject cellPrefab;
	
	    [SerializeField]
	    protected GameObject headerListPrefab;
	    
	    [SerializeField]
	    protected float headerBarHeight;
	
	    [SerializeField]
	    private bool isSummary;
	    protected  void InnerShow()
	    {
	        InitRecycleTableView();
	    }
	
	    public void ClearShow()
	    {
	        tableView.Clear();
	    }


	    void GetTableView()
	    {
		    if (tableView == null)
		    {
			    tableView = transform.Find("Scroll View").GetComponent<TableView>();
		    }
		    
	    }
	    
     #region 设置循环view
	        protected void InitRecycleTableView()
	        {
		        GetTableView();
	            if (!_init)
	            {
	                _init = true;
	                
	                //初始化TableView
	                tableView.Init();
	            
	                //Section的数量
	                tableView.numberOfSectionsDelegate += NumberOfSections;
	            
	                //每个Section中Cell的数量
	                tableView.numberOfRowsInSectionDelegate += NumberOfRowsInSection;
	            
	                //自定义每个Section Header的高度
	                tableView.heightForHeaderInSectionDelegate += HeightForHeaderInSection;
	                
	                //自定义每个Cell的高度
	                tableView.heightForRowDelegate += HeightForRowSection;
	                
	                //设置每个Section的头部
	                tableView.headerForSectionDelegate += HeaderForSection;
	                
	                //注册复用的 Section Header
	                tableView.RegisterPrefabForReuse(sectionHeaderIdentifier, sectionPrefab);
	
	                if (cellPrefab != null)
	                {
	                    //注册复用的 Cell
	                    tableView.RegisterPrefabForReuse(cellIdentifier, cellPrefab);
	                    
	                    //设置每个Cell的头部
	                    tableView.cellForRowDelegate += CellForRow;
	                }
	             
	                
	                //设置顶部特殊的非滑动区域
	                SetHeader();
	            }
	            
	            //刷新列表数据
	            tableView.ReloadData();
	        }
	        
	        
	        protected  virtual void SetHeader()
	        {
	            return;
	            
	           
	        }
	
	        protected virtual int NumberOfSections(TableView tableView)
	        {
	            return 0;
	        }
	
	        protected virtual int NumberOfRowsInSection(TableView tableView, int sectionIndex)
	        {
	            return 0;
	        }
	
	        protected virtual float HeightForHeaderInSection(TableView tableView, int sectionIndex)
	        {
	            return 0;
	        }
	    
	        protected virtual float HeightForRowSection(TableView tableView, int sectionIndex, int cellIndex)
	        {
	            return 0;
	        }
	        
	       
	        
	        protected virtual TableViewCell HeaderForSection(TableView tableView,
	            int sectionIndex)
	        {
	            return null;
	        }
	        
	        protected virtual TableViewCell CellForRow(TableView tableView,
	            int sectionIndex, int cellIndex)
	        {
	            return null;
	        }
	        
        #endregion
	    
	}
}
