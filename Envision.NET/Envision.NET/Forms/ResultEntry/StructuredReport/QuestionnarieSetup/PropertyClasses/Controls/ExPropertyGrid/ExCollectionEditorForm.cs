using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using System.Collections;
using Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Controls.ExPropertyGrid.Enums;
using System.Reflection;
using Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnarieSetup.PropertyClasses.Controls;
using Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Controls.Child;

namespace Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Controls.ExPropertyGrid
{
    public partial class ExCollectionEditorForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public delegate void InstanceEventHandler(object sender, object instance);
        public event InstanceEventHandler InstanceCreated;
        public event InstanceEventHandler DestroyingInstance;
        public event InstanceEventHandler ItemRemoved;
        public event InstanceEventHandler ItemAdded;
        private IList _Collection = null;
        private Type lastItemType = null;
        private ArrayList backupList = null;
        private EditLevel _EditLevel = EditLevel.FullEdit;
        private Type[] SelectedTypeItem;
        private ExCollectionEditorBase attachedEditor = null;

        private bool _canMoveItem = true;
        public bool CanMoveItem
        {
            get { return _canMoveItem; }
            set 
            { 
                _canMoveItem = value;
                if (_canMoveItem)
                {
                    this.btn_Down.Visibility = BarItemVisibility.Always;
                    this.btn_Up.Visibility = BarItemVisibility.Always;
                }
                else
                {
                    this.btn_Down.Visibility = BarItemVisibility.Never;
                    this.btn_Up.Visibility = BarItemVisibility.Never;
                }
            }
        }

        public virtual IList Collection
        {
            get { return _Collection; }
            set
            {
                _Collection = value;
                backupList = new ArrayList(value);
                ProccessCollection(value);
                ProcesssCanMoveItem(value);
                RefreshValues();
            }
        }

        private void ProcesssCanMoveItem(IList value)
        {
            if (value.Count != 0)
            {
                if (value.GetType() == typeof(ExItemCollection))
                {
                    foreach (ExItem ctl in value)
                        if (ctl.Id != 0)
                        {
                            this.CanMoveItem = false;
                            return;
                        }
                    CanMoveItem = true;
                }
                if (value.GetType() == typeof(ExChildCollection))
                {
                    foreach (ExChild ctl in value)
                        if (ctl.Id != 0)
                        {
                            this.CanMoveItem = false;
                            return;
                        }
                    CanMoveItem = true;
                }
                else
                    CanMoveItem = true;
                return;
            }
            else
                CanMoveItem = true;
        }

        [Category("Behavior")]
        public EditLevel EditLevel
        {
            get { return _EditLevel; }
            set
            {
                if (value != _EditLevel)
                {
                    _EditLevel = value;
                    OnEditLevelChanged(new EventArgs());
                }
            }
        }

        [Category("Behavior")]
        public ImageList ImageList
        {
            get { return (ImageList)tv_Items.ImageList; }
            set { tv_Items.ImageList = value; }
        }


        public ExCollectionEditorForm()
        {
            InitializeComponent();
            RefreshValues();
            this.btn_Add.ItemClick += new ItemClickEventHandler(btn_Add_ItemClick);
            this.btn_Remove.ItemClick += new ItemClickEventHandler(btn_Remove_ItemClick);
            this.btn_Up.ItemClick += new ItemClickEventHandler(btn_Up_ItemClick);
            this.btn_Down.ItemClick += new ItemClickEventHandler(btn_Down_ItemClick);
            this.btn_OK.ItemClick += new ItemClickEventHandler(btn_OK_Click);
            this.btn_Cancel.ItemClick += new ItemClickEventHandler(btn_Cancel_Click);
            this.tv_Items.AfterSelect +=new TreeViewEventHandler(tv_Items_AfterSelect);
            this.tv_Items.BeforeSelect +=new TreeViewCancelEventHandler(tv_Items_BeforeSelect);
            this.propertyGridControl1.SelectedGridItemChanged += new SelectedGridItemChangedEventHandler(propertyGridControl1_SelectedGridItemChanged);
            this.propertyGridControl1.PropertyValueChanged += new PropertyValueChangedEventHandler(propertyGridControl1_PropertyValueChanged);
        }

        #region Implement
        private void RefreshValues()
        {
            tv_Items.BeginUpdate();
            tv_Items.Nodes.Clear();
            tv_Items.Nodes.AddRange(GenerateTItemArray(this.Collection));
            tv_Items.EndUpdate();
        }

        private void ProccessCollection(IList value)
        {
            this.SelectedTypeItem = this.CreateNewItemTypes(value);
        }

        protected virtual EditLevel SetEditLevel(IList collection)
        {
            return EditLevel.FullEdit;
        }

        private void SetCollectionEditLevel(IList collection)
        {
            EditLevel el = SetEditLevel(collection);

            switch (el)
            {
                case EditLevel.FullEdit:
                    {
                        this.btn_Remove.Enabled = Remove_CanEnable();
                        this.btn_Add.Enabled = Add_CanEnable();
                        break;
                    }
                case EditLevel.AddOnly:
                    {
                        this.btn_Remove.Enabled = Remove_CanEnable() && false;
                        this.btn_Add.Enabled = Add_CanEnable();
                        break;
                    }
                case EditLevel.RemoveOnly:
                    {
                        this.btn_Add.Enabled = Add_CanEnable() && false;
                        this.btn_Remove.Enabled = Remove_CanEnable();
                        break;
                    }
                case EditLevel.ReadOnly:
                    {
                        this.btn_Remove.Enabled = Remove_CanEnable() && false;
                        this.btn_Add.Enabled = Add_CanEnable() && false;
                        break;
                    }
            }


        }

        private bool Add_CanEnable()
        {
            if (this.EditLevel == EditLevel.FullEdit || this.EditLevel == EditLevel.AddOnly) { return true; }
            return false;
        }

        private bool Remove_CanEnable()
        {
            if (this.EditLevel == EditLevel.FullEdit || this.EditLevel == EditLevel.RemoveOnly) { return true; }
            return false;
        }

        private void btn_Add_ItemClick(object sender, ItemClickEventArgs e)
        {
            tv_Items.BeginUpdate();
            if (Collection != null && this.SelectedTypeItem[0] != null)
            {
                //create a new item to add to the Collection and a corespondent TItem to add to the treeview nodes
                Type type = this.SelectedTypeItem[0];
                object newCollItem = CreateInstance(type);
                TItem newTItem = CreateTItem(newCollItem);

                //get the current  possition  and the parent collections to insert into
                TItem selTItem = (TItem)tv_Items.SelectedNode;

                if (selTItem != null)
                {
                    int position = selTItem.Index + 1;

                    IList coll;
                    TreeNodeCollection TItemColl;

                    if (selTItem.Parent != null)
                    {
                        coll = (((TItem)selTItem.Parent).SubItems);
                        TItemColl = selTItem.Parent.Nodes;
                    }
                    else
                    {
                        coll = Collection;
                        TItemColl = tv_Items.Nodes;
                    }


                    coll.Insert(position, newCollItem);
                    TItemColl.Insert(position, newTItem);


                }
                else //empty collection
                {
                    Collection.Add(newCollItem);
                    tv_Items.Nodes.Add(newTItem);

                }

                OnItemAdded(newCollItem);
                tv_Items.SelectedNode = newTItem;

            }
            tv_Items.EndUpdate();	
        }

        private void btn_Remove_ItemClick(object sender, ItemClickEventArgs e)
        {
            tv_Items.BeginUpdate();
            TItem selTItem = (TItem)tv_Items.SelectedNode;
            if (selTItem != null)
            {
                int selIndex = selTItem.Index;
                TItem parentTitem = (TItem)selTItem.Parent;
                if (parentTitem != null)
                {
                    parentTitem.Nodes.Remove(selTItem);
                    parentTitem.SubItems.Remove(selTItem.Value);
                    if (parentTitem.Nodes.Count > selIndex) { tv_Items.SelectedNode = parentTitem.Nodes[selIndex]; }
                    else if (parentTitem.Nodes.Count > 0) { tv_Items.SelectedNode = parentTitem.Nodes[selIndex - 1]; }
                    else { tv_Items.SelectedNode = parentTitem; }
                }
                else
                {
                    tv_Items.Nodes.Remove(selTItem);
                    Collection.Remove(selTItem.Value);
                    if (tv_Items.Nodes.Count > selIndex) { tv_Items.SelectedNode = tv_Items.Nodes[selIndex]; }
                    else if (tv_Items.Nodes.Count > 0) { tv_Items.SelectedNode = tv_Items.Nodes[selIndex - 1]; }
                    else { this.propertyGridControl1.SelectedObject = null; }
                }

                OnItemRemoved(selTItem.Value);
            }
            tv_Items.EndUpdate();
        }

        private void btn_Down_ItemClick(object sender, ItemClickEventArgs e)
        {
            tv_Items.BeginUpdate();
            TItem selTItem = (TItem)tv_Items.SelectedNode;
            if (selTItem != null && selTItem.NextNode != null)
            {
                int nextIndex = selTItem.NextNode.Index;
                TItem fatherTitem = (TItem)selTItem.Parent;

                if (fatherTitem != null)
                {
                    MoveItem(fatherTitem.SubItems, fatherTitem.SubItems.IndexOf(selTItem.Value), 1);
                    SetProperties(fatherTitem, fatherTitem.Value);
                    tv_Items.SelectedNode = fatherTitem.Nodes[nextIndex];

                }
                else
                {
                    MoveItem(Collection, Collection.IndexOf(selTItem.Value), 1);
                    tv_Items.Nodes.Clear();
                    tv_Items.Nodes.AddRange(GenerateTItemArray(this.Collection));
                    tv_Items.SelectedNode = tv_Items.Nodes[nextIndex];
                }
            }
            tv_Items.EndUpdate();
        }

        private void btn_Up_ItemClick(object sender, ItemClickEventArgs e)
        {
            tv_Items.BeginUpdate();
            TItem selTItem = (TItem)tv_Items.SelectedNode;
            if (selTItem != null && selTItem.PrevNode != null)
            {
                int prevIndex = selTItem.PrevNode.Index;
                TItem fatherTitem = (TItem)selTItem.Parent;
                if (fatherTitem != null)
                {


                    MoveItem(fatherTitem.SubItems, fatherTitem.SubItems.IndexOf(selTItem.Value), -1);
                    SetProperties(fatherTitem, fatherTitem.Value);
                    tv_Items.SelectedNode = fatherTitem.Nodes[prevIndex];

                }
                else
                {

                    MoveItem(Collection, Collection.IndexOf(selTItem.Value), -1);
                    tv_Items.Nodes.Clear();
                    tv_Items.Nodes.AddRange(GenerateTItemArray(this.Collection));
                    tv_Items.SelectedNode = tv_Items.Nodes[prevIndex];
                }
            }
            tv_Items.EndUpdate();
        }

        private void tv_Items_BeforeSelect(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
        {
            this.propertyGridControl1.SelectedObject = ((TItem)e.Node).Value;
        }

        private void tv_Items_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            TItem ti = (TItem)e.Node;
            if (ti.Value.GetType() != lastItemType)
            {
                lastItemType = ti.Value.GetType();
                IList coll;
                if (ti.Parent != null) { coll = ((TItem)ti.Parent).SubItems; }
                else { coll = Collection; }
                ProccessCollection(coll);

            }
        }

        private void propertyGridControl1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            tv_Items.BeginUpdate();
            TItem selTItem = (TItem)tv_Items.SelectedNode;

            SetProperties(selTItem, selTItem.Value);

            tv_Items.EndUpdate();
        }

        private void propertyGridControl1_SelectedGridItemChanged(object sender, SelectedGridItemChangedEventArgs e)
        {
            if (attachedEditor != null)
            {
                attachedEditor.CollectionChanged -= new ExCollectionEditorBase.CollectionChangedEventHandler(ValChanged);
                attachedEditor = null;
            }

            if (e.NewSelection.Value is IList)
            {
                attachedEditor = (ExCollectionEditorBase)e.NewSelection.PropertyDescriptor.GetEditor(typeof(System.Drawing.Design.UITypeEditor)) as ExCollectionEditorBase;
                if (attachedEditor != null)
                {
                    attachedEditor.CollectionChanged += new ExCollectionEditorBase.CollectionChangedEventHandler(ValChanged);
                }
            }
        }

        private void ValChanged(object sender, object instance, object value)
        {
            tv_Items.BeginUpdate();
            TItem ti = (TItem)tv_Items.SelectedNode;
            SetProperties(ti, instance);
            tv_Items.EndUpdate();
        }

        private void btn_OK_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }


        private void btn_Cancel_Click(object sender, System.EventArgs e)
        {
            UndoChanges(backupList, Collection);
            this.Close();

        }

        private void UndoChanges(ArrayList source, IList dest)
        {
            foreach (object o in dest)
            {
                if (!source.Contains(o))
                {
                    DestroyInstance(o);
                    OnItemRemoved(o);
                }

            }

            dest.Clear();
            CopyItems(source, dest);
        }

        private void CopyItems(ArrayList source, IList dest)
        {
            foreach (object o in source)
            {
                dest.Add(o);
                OnItemAdded(o);
            }
        }

        //protected virtual void RefreshAvailableTypes(IList collection)
        //{
        //    btn_Add.List.Items.Clear();
        //    btn_Add.List.Items.AddRange(CreateNewItemTypes(collection));
        //    if (btn_Add.List.Items.Count < 2) { btn_Add.CanDropDown = false; }
        //    else { btn_Add.CanDropDown = true; }
        //    btn_Add.MinListWidth = CalculateDDListWidth();
        //}

        //private void ProccessCollection(IList collection)
        //{
        //    RefreshAvailableTypes(collection);
        //    SetCollectionEditLevel(collection);
        //}

        //private int CalculateDDListWidth()
        //{
        //    int width = 0;
        //    Graphics g = btn_Add.List.CreateGraphics();

        //    foreach (object item in this.btn_Add.List.Items)
        //    {
        //        int itemWidth = (int)g.MeasureString(item.ToString(), btn_Add.List.Font).Width;
        //        width = Math.Max(width, itemWidth);
        //    }
        //    width = Math.Max(width, btn_Add.Width + 20);
        //    return width;
        //}

        #endregion

        #region "Collection Item"

        /// <summary>
        /// Gets the data type of each item in the collection.
        /// </summary>
        /// <param name="coll"> The collection for which to get the item's type</param>
        /// <returns>The data type of the collection items.</returns>
        protected virtual Type GetItemType(IList coll)
        {
            PropertyInfo pi = coll.GetType().GetProperty("Item", new Type[] { typeof(int) });
            return pi.PropertyType;
        }

        /// <summary>
        /// Gets the data types that this collection editor can contain
        /// </summary>
        /// <param name="coll">The collection for which to return the available types</param>
        /// <returns>An array of data types that this collection can contain.</returns>
        protected virtual Type[] CreateNewItemTypes(IList coll)
        {
            return new Type[] { GetItemType(coll) };
        }

        /// <summary>
        /// Creates a new instance of the specified collection item type.
        /// </summary>
        /// <param name="itemType">The type of item to create. </param>
        /// <returns>A new instance of the specified object.</returns>
        protected virtual object CreateInstance(Type itemType)
        {

            /* 
            //This is just another way of how to remotely  create an object
			
            // Try to get a parameterless constructor
            ConstructorInfo ci = itemType.GetConstructor(new Type[0]);
            InstanceDescriptor id =  new InstanceDescriptor(ci,null,false);
            return id.Invoke();
            */


            object instance = Activator.CreateInstance(itemType, true);
            OnInstanceCreated(instance);
            return instance;
        }

        /// <summary>
        /// Destroys the specified instance of the object.
        /// </summary>
        /// <param name="instance">The object to destroy. </param>
        protected virtual void DestroyInstance(object instance)
        {
            OnDestroyingInstance(instance);
            if (instance is IDisposable) { ((IDisposable)instance).Dispose(); }
            instance = null;
        }


        protected virtual void OnDestroyingInstance(object instance)
        {
            if (DestroyingInstance != null)
            {
                DestroyingInstance(this, instance);
            }
        }


        protected virtual void OnInstanceCreated(object instance)
        {
            if (InstanceCreated != null)
            {
                InstanceCreated(this, instance);
            }
        }

        protected virtual void OnItemRemoved(object item)
        {
            if (ItemRemoved != null)
            {
                ItemRemoved(this, item);
            }
        }

        protected virtual void OnItemAdded(object Item)
        {
            if (ItemAdded != null)
            {
                ItemAdded(this, Item);
            }
        }


        #endregion

        #region "TItem Related"

        private void MoveItem(IList list, int index, int step)
        {

            if (index > -1 && index < list.Count && index + step > -1 && index + step < list.Count)
            {
                int poss = index + step;

                object possObject = list[poss];
                list[poss] = list[index];
                list[index] = possObject;
                possObject = null;
            }

        }


        protected internal TItem[] GenerateTItemArray(IList collection)
        {
            TItem[] ti = new TItem[0];

            if (collection != null && collection.Count > 0)
            {
                ti = new TItem[collection.Count];

                for (int i = 0; i < collection.Count; i++)
                {
                    ti[i] = CreateTItem(collection[i]);
                }
            }
            return ti;
        }

        /// <summary>
        /// Creates a new TItem objectfor a collection item.
        /// </summary>
        /// <param name="reffObject">The collection item for 'wich to create an TItem object.</param>
        /// <returns>A TItem object referencing the collection item received as parameter.</returns>
        protected virtual TItem CreateTItem(object reffObject)
        {
            TItem ti = new TItem(this, reffObject);
            SetProperties(ti, reffObject);
            return ti;
        }

        /// <summary>
        /// When implemented by a class, customize a TItem object in respect to it's corresponding collection item.
        /// </summary>
        /// <param name="titem">The TItem object to be customized in respect to it's corresponding collection item.</param>
        /// <param name="reffObject">The collection item for which it customizes the TItem object.</param>
        protected virtual void SetProperties(TItem titem, object reffObject)
        {
            // set the display name 
            PropertyInfo pi = titem.Value.GetType().GetProperty("Name");

            if (pi != null)
            {
                titem.Value = pi.GetValue(titem.Value, null).ToString();
            }
            else
            {
                titem.Value = titem.Value.GetType().Name;
            }

        }

        public void RefreshPropertyGrid()
        {
            this.propertyGridControl1.Refresh();
        }


        #endregion

        #region Events
        /// <summary>
        /// Edit level change
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnEditLevelChanged(EventArgs e)
        {
            switch (EditLevel)
            {
                case EditLevel.FullEdit:
                    {
                        this.btn_Add.Enabled = true;
                        this.btn_Remove.Enabled = true;
                        break;
                    }
                case EditLevel.AddOnly:
                    {
                        this.btn_Add.Enabled = true;
                        this.btn_Remove.Enabled = false;
                        break;
                    }
                case EditLevel.RemoveOnly:
                    {
                        this.btn_Add.Enabled = false;
                        this.btn_Remove.Enabled = true;
                        break;
                    }
                case EditLevel.ReadOnly:
                    {
                        this.btn_Add.Enabled = false;
                        this.btn_Remove.Enabled = false;
                        break;
                    }
            }
        }
        #endregion

        #region "TItem"

        public class TItem : TreeNode
        {
            private object _Value;
            private ExCollectionEditorForm ced = null;
            private IList _SubItems = null;


            public object Value
            {
                get { return _Value; }
                set { _Value = value; }
            }

            public IList SubItems
            {
                get { return _SubItems; }
                set
                {
                    _SubItems = value;
                    this.Nodes.Clear();
                    if (value != null)
                    {
                        this.Nodes.AddRange(ced.GenerateTItemArray(value));
                    }

                }
            }


            public TItem(ExCollectionEditorForm ced, object Value)
            {
                this.ced = ced;
                this._Value = Value;
            }


            public TItem(ExCollectionEditorForm ced, object Value, int ImageIndex)
            {
                this.ced = ced;
                this._Value = Value;
                this.ImageIndex = ImageIndex;
            }
            public TItem(ExCollectionEditorForm ced, object Value, int ImageIndex, int SelectedImageIndex)
            {
                this.ced = ced;
                this._Value = Value;
                this.ImageIndex = ImageIndex;
                this.SelectedImageIndex = SelectedImageIndex;
            }

        #endregion

        }
    }
}