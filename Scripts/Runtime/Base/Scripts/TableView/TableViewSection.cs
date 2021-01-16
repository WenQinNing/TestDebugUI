
using System.Collections.Generic;
using Iyourcar;

namespace Iyourcar.Components.RecycleTableView
{
    public class TableViewSection
    {
        public int index = 0;
        
        public float headerHeight = 0.0f;
        
        public int numberOfRowsInSection = 0;
        public List<float> rowHeights;
        public float rowsHeight;
        
        public TableViewCell header;
        public Dictionary<int, TableViewCell> cellDict;
    }
}

