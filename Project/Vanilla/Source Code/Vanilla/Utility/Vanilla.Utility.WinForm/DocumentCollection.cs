using System;
using System.Collections;
using System.Collections.Generic;

namespace Vanilla.Utility.WinForm
{

    public class DocumentCollection : ICollection<Document>, IList<Document>
    {

        private List<Document> items = new List<Document>();

        public Document Current { get; set; }

        public int Count
        {
            get { return this.items.Count; }
        }

        public Boolean IsReadOnly { get; set; }

        public void Activate(Document item)
        {
            item.MakeActive();
            if (this.Current != null)
            {
                this.Current.MakeInactivate();
            }
            this.Current = item;
        }

        public void Add(Document item)
        {
            this.Current = item;
            this.items.Add(item);
        }

        public void Clear()
        {
            if (this.IsReadOnly) return;
            this.items.Clear();
        }

        public Boolean Contains(Document item)
        {
            return this.items.Contains(item);
        }

        public void CopyTo(Document[] array, int arrayIndex)
        {
            this.items.CopyTo(array, arrayIndex);
        }

        public Boolean Remove(Document item)
        {
            if (this.IsReadOnly) return false;
            return this.items.Remove(item);
        }

        public IEnumerator<Document> GetEnumerator()
        {
            return this.items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.items.GetEnumerator();
        }

        public Document Find(Predicate<Document> match)
        {
            return this.items.Find(match);
        }

        public Int32 IndexOf(Document item)
        {
            return this.items.IndexOf(item);
        }

        public void Insert(Int32 index, Document item)
        {
            this.items.Insert(index, item);
        }

        public void RemoveAt(Int32 index)
        {
            this.items.RemoveAt(index);
        }

        public Document this[Int32 index]
        {
            get
            {
                return this.items[index];
            }
            set
            {
                this.items[index] = value;
            }
        }

    }

}