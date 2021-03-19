using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeViewForString.Models
{
    class TreeView
    {
        public List<TreeView> subItems = new List<TreeView>();

        private string nodeName { get; set; }

        private string childsValue { get; set; }

        public TreeView(string nodeName, string childsValue)
        {
            this.nodeName = nodeName;
            this.childsValue = childsValue;

            PrepareTreeView();
        }

        public void RenderView(ref int tabLevel)
        {
            string tabLevelIndicator = "";
            for (int i = 0; i < tabLevel; i++) tabLevelIndicator += "-";
            string result = String.Format("{0}{1}",tabLevelIndicator,nodeName);

            Console.WriteLine(result);

            //this.subItems.ForEach(x => x.RenderView(tabLevel + 1));
            int tabLevelT = tabLevel + 1;
            foreach(var items in subItems)
            {
                items.RenderView(ref tabLevelT);
            }

        }

        /// <summary>
        /// ChildsValue propertysine göre viewları hazırlar. Her harfin sadece birer kere kullanıldığı aşamalar için geçerli
        /// </summary>
        private void PrepareTreeView()
        {
            string tempValues = this.childsValue;
            if(this.childsValue.Length > 2)
            {
                do
                {
                    string firstChar = tempValues.First().ToString();
                    int closedIndex = FindClosedIndex(firstChar, tempValues);
                    tempValues = tempValues.Remove(0, 1);

                    string childrens = tempValues.Substring(0, closedIndex);
                    tempValues = tempValues.Remove(0, closedIndex + 1);
                    this.subItems.Add(new TreeView(firstChar, childrens));

                } while (tempValues.Length > 0);
            }
            else if(this.childsValue.Length > 0)
            {
                this.subItems.Add(new TreeView(childsValue.First().ToString(), ""));
            }
        }

        /// <summary>
        /// Childs içerisindeki "s" değerinin başlangıç pozisyonunu silerek bir sonraki aşamadaki pozisyonu alır.
        /// </summary>
        /// <param name="s">Value of string</param>
        /// <param name="childs">Childrens as string</param>
        /// <returns>String içindeki next indexi döner.</returns>
        private int FindClosedIndex(string s,string childs)
        {
            string tempValues = childs.Remove(childs.IndexOf(s), 1);

            int lastIndex = tempValues.IndexOf(s);

            return lastIndex;

        }


    }
}
