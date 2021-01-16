using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Object = System.Object;

namespace Iyourcar.Components.RecycleTableView
{
    [RequireComponent(typeof(ScrollRect))]
    public class TableView : MonoBehaviour
    {
        private RectTransform _rectTransform;
        
        public delegate int NumberOfSectionsDelegate(TableView tableView);
        public delegate TableViewCell HeaderForSectionDelegate(TableView tableView, int sectionIndex);

        public delegate int NumberOfRowsInSectionDelegate(TableView tableView, int sectionIndex);
        public delegate TableViewCell CellForRowDelegate(TableView tableView, int sectionIndex, int cellIndex);
        
        public delegate float HeightForHeaderInSectionDelegate(TableView tableView, int sectionIndex);
        public delegate float HeightForRowDelegate(TableView tableView, int sectionIndex, int cellIndex);
        
        // public delegate void DidSelectRowDelegate(TableView tableView, int section, int index);

        public NumberOfSectionsDelegate numberOfSectionsDelegate;
        public NumberOfRowsInSectionDelegate numberOfRowsInSectionDelegate;
        
        public CellForRowDelegate cellForRowDelegate;
        public HeaderForSectionDelegate headerForSectionDelegate;
        // public DidSelectRowDelegate didSelectRowDelegate;
        
        public HeightForHeaderInSectionDelegate heightForHeaderInSectionDelegate;
        public HeightForRowDelegate heightForRowDelegate;
        
        public ScrollRect scrollRect { get; private set; }
        private RectTransform _scrollRectTransform;
        private RectTransform _contentTransform;

        public float headerHeight = 0;
        public TableViewHeader headerView { get; private set; }
        
        public CanvasGroup headerViewGanveGroup { get; private set; }

        [SerializeField]
        private bool isGotoTopAfterReload;
        
        public float rowHeight = 0;
        public float sectionHeaderHeight = 0;

        private List<TableViewSection> _sections = new List<TableViewSection>();
        
        //Cell注册器
        private Dictionary<string, GameObject> _cellRegister;
        //未显示在界面的复用池里的Cell
        private Dictionary<string, List<TableViewCell>> _reusableCells;
        
        public void Init()
        {
            scrollRect = GetComponent<ScrollRect>();
            scrollRect.onValueChanged.AddListener(DidScroll);
            
            _scrollRectTransform = scrollRect.transform as RectTransform;
            _contentTransform = scrollRect.content;
            
            _rectTransform = GetComponent<RectTransform>();
            _reusableCells = new Dictionary<string, List<TableViewCell>>();
            _cellRegister = new Dictionary<string, GameObject>();
        }

        /// <summary>
        /// 注册Cell复用的预置体
        /// </summary>
        /// <param name="prefab">具有TableViewCell脚本的预置体</param>
        /// <param name="identifier">唯一的复用标识符</param>
        public void RegisterPrefabForReuse(string identifier, GameObject prefab)
        {
            _cellRegister[identifier] = prefab;
        }

        /// <summary>
        /// 根据唯一的复用标识符从缓冲中取出Cell
        /// </summary>
        /// <param name="identifier">唯一的复用标识符</param>
        /// <returns>TableViewCell</returns>
        public TableViewCell DequeueReusable(string identifier)
        {
            //首先根据唯一的复用标识符从缓冲中取出Cell
            if (_reusableCells.ContainsKey(identifier))
            {
                List<TableViewCell> cells = _reusableCells[identifier];
                if (cells != null && cells.Count > 0)
                {
                    TableViewCell cell = cells[0];
                    cell.Show();
                    cells.Remove(cell);
                    return cell;
                }
            }

            //如果缓冲中没有，则从注册器中实例化一个Cell
            if (_cellRegister.ContainsKey(identifier))
            {
                GameObject prefab = _cellRegister[identifier];
                GameObject obj = GameObject.Instantiate(prefab);
                obj.name = identifier;
                TableViewCell cell = obj.GetComponent<TableViewCell>();
                cell.identifier = identifier;
                return cell;
            }

            //如果注册器中没有以identifier注册的Cell，则返回null
#if UNITY_EDITOR
            Debug.LogError($"{identifier} 没有注册Cell");
#endif
            return null;
        }

        private void QueueReusable(TableViewCell cell)
        {
            cell.Hide();
            
            string identifier = cell.identifier;
            List<TableViewCell> cells = null;
            if (_reusableCells.ContainsKey(identifier))
            {
                cells = _reusableCells[identifier];
            }

            if (cells == null)
            {
                cells = new List<TableViewCell>();
            }
            cells.Add(cell);
            _reusableCells[identifier] = cells;
        }
        
        /// <summary>
        /// 重新加载数据
        /// </summary>
        public void ReloadData()
        {
            Clear();
            UpdateSectionsCache();
            UpdateContentSize();
            LayoutTableView();
            GoToTopAfterReload();
        }
        
        /// <summary>
        /// 清除数据
        /// </summary>
        public void Clear()
        {
            //把所有的Section Header、 Cell销毁
            float count = _sections.Count;
            for (int i = 0; i < count; i++)
            {
                TableViewSection section = _sections[i];
                TableViewCell header = section.header;
                
                if (header != null)
                {
                    Destroy(header.gameObject);
                    section.header = null;
                }

                Dictionary<int, TableViewCell> cellDict = section.cellDict;
                if (cellDict != null && cellDict.Count > 0)
                {
                    int cellsCount = section.numberOfRowsInSection;
                    for (int j = 0; j < cellsCount; j++)
                    {
                        TableViewCell cell = cellDict[j];
                        if (cell != null)
                        {
                            cellDict[j] = null;
                            Destroy(cell.gameObject);
                        }
                    }
                }
            }
            
            //清空Sections
            if (_sections != null && _sections.Count > 0)
            {
                _sections.Clear();
            }
            else
            {
                _sections = new List<TableViewSection>();
            }
            //清空缓冲
            if (_reusableCells != null && _reusableCells.Count > 0)
            {
                foreach (var cells in _reusableCells)
                {
                    foreach (var cell in cells.Value)
                    {
                        if (cell != null)
                        {
                            Destroy(cell.gameObject);
                        }
                    }
                }
                _reusableCells.Clear();
            }
            else
            {
                _reusableCells = new Dictionary<string, List<TableViewCell>>();
            }
        }

        public void SetHeaderView(TableViewHeader header)
        {
            if (headerView != null)
            {
                Destroy(headerView.gameObject);
            }
            if (header != null)
            {
                RectTransform trans = header.transform as RectTransform;
                trans.SetParent(scrollRect.content);
                trans.name = "HeaderView";
                trans.anchorMin = Vector2.up;
                trans.anchorMax = Vector2.one;
                trans.pivot = Vector2.up;
                trans.sizeDelta = new Vector2(0, headerHeight);
                trans.anchoredPosition = new Vector2(0, 0);
            }
            headerView = header;
            
            if (headerView)
            {
                headerViewGanveGroup = headerView.GetComponent<CanvasGroup>();
            }
            else
            {
                headerViewGanveGroup = null;
            }
            ReloadData();
        }

        public void SetHeaderViewGanveGroupActive(bool isActive)
        {
            if (isActive)
            {
                if (headerViewGanveGroup != null)
                {
                    headerViewGanveGroup.alpha = 1;
                    headerViewGanveGroup.blocksRaycasts = true;
                    headerViewGanveGroup.interactable = true;
                }
            }
            else
            {
                if (headerViewGanveGroup != null)
                {
                    headerViewGanveGroup.alpha = 0;
                    headerViewGanveGroup.blocksRaycasts = false;
                    headerViewGanveGroup.interactable = false;
                }
            }
        }

        private void DidScroll(Vector2 value)
        {
            LayoutTableView();
        }

        /// <summary>
        /// 计算Section Cell的高度
        /// </summary>
        private void UpdateSectionsCache()
        {
            if (numberOfSectionsDelegate != null)
            {
                int sections = numberOfSectionsDelegate(this);
                for (int i = 0; i < sections; i++)
                {
                    TableViewSection section = new TableViewSection();
                    section.index = i;
                    section.headerHeight = sectionHeaderHeight;

                    if (heightForHeaderInSectionDelegate != null)
                    {
                        section.headerHeight = heightForHeaderInSectionDelegate(this, i);
                    }
                    
                    int cells = 0;
                    if (numberOfRowsInSectionDelegate != null)
                    {
                        cells = numberOfRowsInSectionDelegate(this, i);
                    }
                    section.numberOfRowsInSection = cells;
                    section.cellDict = new Dictionary<int, TableViewCell>();
                
                    float cellsHeight = 0.0f;
                    section.rowHeights = new List<float>();
                    for (int j = 0; j < cells; j++)
                    {
                        float cellHeight = rowHeight;
                        if (heightForRowDelegate != null)
                        {
                            cellHeight = heightForRowDelegate(this, i, j);
                        }

                        cellsHeight += cellHeight;
                        section.rowHeights.Add(cellHeight);
                        section.cellDict[j] = null;
                    }

                    section.rowsHeight = cellsHeight;
                    _sections.Add(section);
                }
            }
        }

        private void UpdateContentSize()
        {
            float height = 0;
            if (headerView != null)
            {
                height += headerHeight;
            }
            float count = _sections.Count;
            for (int i = 0; i < count; i++)
            {
                TableViewSection section = _sections[i];
                height += section.headerHeight;
                height += section.rowsHeight;
            }
            
            _contentTransform.anchorMin = Vector2.up;
            _contentTransform.anchorMax = Vector2.one;
            _contentTransform.pivot = Vector2.up;
            _contentTransform.sizeDelta = new Vector2(0, height);
        }

        public void GoToTopAfterReload()
        {
            if (isGotoTopAfterReload)
            {
                _contentTransform.anchoredPosition = Vector2.zero;
            }
        }

        public void SetCanScroll(bool verticalScroll = true,
            bool horizontalScroll = true)
        {
            scrollRect.vertical = verticalScroll;
            scrollRect.horizontal = horizontalScroll;

        }
        
        private void LayoutTableView()
        {
            float offset = _contentTransform.anchoredPosition.y;
            float contentHeight = _scrollRectTransform.rect.height;
            float top = 0.0f;

            if (headerView != null)
            {
                if (top + headerHeight < offset)
                {
                    headerView.Hide();
                }
                else
                {
                    headerView.Show();
                }
                top += headerHeight;
            }
            
            float count = _sections.Count;
            for (int i = 0; i < count; i++)
            {
                //判断Section是否在可视区域内
                TableViewSection section = _sections[i];
                float sectionHeight = section.headerHeight + section.rowsHeight;
                if (top + sectionHeight < offset || top > offset + contentHeight)
                {
                    //不在可视区域内，则把Section放回缓冲
                    TableViewCell header = section.header;
                    if (header != null)
                    {
                        section.header = null;
                        QueueReusable(header);
                    }

                    Dictionary<int, TableViewCell> cellDict = section.cellDict;
                    if (cellDict != null && cellDict.Count > 0)
                    {
                        int cellsCount = section.numberOfRowsInSection;
                        for (int j = 0; j < cellsCount; j++)
                        {
                            TableViewCell cell = cellDict[j];
                            if (cell != null)
                            {
                                cellDict[j] = null;
                                
                                QueueReusable(cell);
                            }
                        }
                    }
                }
                else
                {
                    //在可视区域内
                    //判断Section Header是否在可视区域内
                    TableViewCell header = section.header;
                    float sectionHeaderHeight = section.headerHeight;
                    if (top + sectionHeaderHeight < offset)
                    {
                        //Section Header不在可视区域，则把Section Header放回缓冲
                        if (header != null)
                        {
                            section.header = null;
                            QueueReusable(header);
                        }
                    }
                    else
                    {
                        //Section Header在可视区域，则判断Section Header是否存在，不存在的化就从代理中创建一个
                        if (header == null && headerForSectionDelegate != null)
                        {
                            header = headerForSectionDelegate(this, i);
                            header.sectionIndex = i;
                            header.cellIndex = 0;
                            
                            section.header = header;
                            RectTransform trans = header.transform as RectTransform;
                            trans.SetParent(scrollRect.content);
                            trans.anchorMin = Vector2.up;
                            trans.anchorMax = Vector2.one;
                            trans.pivot = Vector2.up;
                            trans.sizeDelta = new Vector2(0, sectionHeaderHeight);
                            trans.anchoredPosition = new Vector2(0, -top);
                            trans.localScale = Vector3.one;
                        }
                    }
                    
                    float cellTop = top + sectionHeaderHeight;
                    //判断每个Cell是否在可视区域内
                    int rows = section.numberOfRowsInSection;
                    for (int j = 0; j < rows; j++)
                    {
                        float cellHeight = section.rowHeights[j];
                        if (cellTop + cellHeight < offset || cellTop > offset + contentHeight)
                        {
                            //Cell不在可视区域内，则把Cell放回缓冲
                            if (section.cellDict.ContainsKey(j))
                            {
                                TableViewCell cell = section.cellDict[j];
                                section.cellDict[j] = null;
                                if (cell != null)
                                {
                                    QueueReusable(cell);
                                }
                            }
                        }
                        else
                        {
                            //Cell在可视区域，则判断Cell是否存在，不存在的化就从代理中创建一个
                            TableViewCell cell = null;
                            if (section.cellDict.ContainsKey(j))
                            {
                                cell = section.cellDict[j];
                            }
                            
                            if (cell == null && cellForRowDelegate != null)
                            {
                                cell = cellForRowDelegate(this, i, j);
                                cell.sectionIndex = i;
                                cell.cellIndex = j;
                                section.cellDict[j] = cell;
                                
                                RectTransform trans = cell.transform as RectTransform;
                                trans.SetParent(scrollRect.content);
                                trans.anchorMin = Vector2.up;
                                trans.anchorMax = Vector2.one;
                                trans.pivot = Vector2.up;
                                trans.sizeDelta = new Vector2(0, cellHeight);
                                trans.anchoredPosition = new Vector2(0, -cellTop);
                                cell.transform.localScale = Vector3.one;
                            }
                        }
                        cellTop += cellHeight;
                    }
                }
                top += sectionHeight;
            }

        }

        public float GetSectionOffset(int sectionIndex)
        {
            float offset = 0.0f;
            if (headerView != null)
            {
                offset += headerHeight;
            }

            int index = Mathf.Clamp(sectionIndex, 0, _sections.Count - 1);
            for (int i = 0; i < index; i++)
            {
                TableViewSection section = _sections[i];
                offset += section.headerHeight;
                offset += section.rowsHeight;
            }

            return offset;
        }
        
        public float GetCellOffset(int sectionIndex, int cellIndex)
        {
            float offset = GetSectionOffset(sectionIndex);

            int index = Mathf.Clamp(sectionIndex, 0, _sections.Count - 1);
            index = index < 0 ? 0 : index;
            
            TableViewSection section = _sections[index];
            offset += section.headerHeight;
            
            int index2 = Mathf.Clamp(cellIndex, 0, section.numberOfRowsInSection - 1);
            for (int i = 0; i < index2; i++)
            {
                offset += section.rowHeights[i];
            }

            float max = _contentTransform.sizeDelta.y - _scrollRectTransform.rect.height;
            offset = offset > max ? max : offset;
            return offset;
        }

        public TableViewCell GetSectionHeader(int sectionIndex)
        {
            if (sectionIndex < _sections.Count)
            {
                TableViewSection record = _sections[sectionIndex];
                return record.header;
            }
            return null;
        }
        

        public TableViewCell GetCell(int sectionIndex, int cellIndex)
        {
            if (sectionIndex < _sections.Count)
            {
                TableViewSection record = _sections[sectionIndex];
                
                if (cellIndex < record.numberOfRowsInSection)
                {
                    return record.cellDict[cellIndex];
                }
            }
            return null;
        }

        public void SetScrollOffset(float offset)
        {
            scrollRect.content.anchoredPosition = new Vector2(0, offset);
        }
    }
}
