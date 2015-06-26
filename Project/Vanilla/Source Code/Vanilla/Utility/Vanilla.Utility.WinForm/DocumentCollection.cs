using System;
using System.Collections;
using System.Collections.Generic;

namespace Vanilla.Utility.WinForm
{

    public class DocumentCollection : ICollection<Document>, IList<Document>
    {

        private List<Document> items;

        public Document Current { get; set; }

        public int Count
        {
            get { return this.items.Count; }
        }

        public Boolean IsReadOnly { get; set; }

        public Boolean IsAdded { get; private set; }

        public delegate void OnAdded(Document item);
        public event OnAdded Added;

        public delegate void OnActiveClosed(Document item);
        public event OnActiveClosed ActiveClosed;

        public delegate void OnClosed();
        public event OnClosed Closed;

        public delegate void OnSelected(Document item);
        public event OnSelected Selected;

        public DocumentCollection()
        {
            this.items = new List<Document>();
        }

        public void Add(Document item)
        {
            this.IsAdded = false;

            //Check if the document is already open or not
            Document existing = this.Find((p) =>
            {
                if (item.formDto != null && item.formDto.Document != null)
                {
                    return item.formDto.Document.Id == p.formDto.Document.Id;
                }
                return false;
            });
            if (existing == null)
            {
                this.items.Add(item);
                this.Activate(item);
                this.IsAdded = true;
                if (this.Added != null) this.Added(item);
            }
            else
            {
                this.Activate(existing);
                item.Dispose();
                if (this.Selected != null) this.Selected(this.Current);
            }
            item.FormClosed += delegate(object sender, System.Windows.Forms.FormClosedEventArgs e)
            {
                this.items.Remove(sender as Document);
                if (this.items.Count > 0 && this.Current == sender as Document)
                {
                    this.Activate(this.items[this.Count - 1]);
                    if (this.ActiveClosed != null) this.ActiveClosed(this.items[this.Count - 1] as Document);
                }
                (sender as Document).Heading.Dispose();
                if (this.Closed != null) this.Closed();
            };
            item.HeadingClicked += delegate(object sender1, EventArgs e1)
            {
                if (this.Current.Heading != sender1)
                {
                    this.Activate((sender1 as DocumentHeading).Document);
                    this.Current = (sender1 as DocumentHeading).Document;
                    if (this.Selected != null) this.Selected(this.Current);
                }
            };
        }

        private void Activate(Document item)
        {
            item.MakeActive();
            if (this.Current != null)
            {
                this.Current.MakeInactivate();
            }
            this.Current = item;
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