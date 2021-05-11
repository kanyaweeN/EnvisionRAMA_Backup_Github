using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Infragistics.Win;
using Infragistics.Win.FormattedLinkLabel;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinSpellChecker;
using RIS.BusinessLogic;
using RIS.Common.Common;
using RIS.Forms.GBLMessage;
using RIS.Operational.PACS;
using RIS.Common;
using Miracle.HL7.ORU;

namespace RIS.Forms.ResultEntry
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Addendum : System.Windows.Forms.Form
	{
		#region Private Members

		private System.Windows.Forms.Panel Form1_Fill_Panel;
		private Infragistics.Win.FormattedLinkLabel.UltraFormattedTextEditor ultraFormattedTextEditor1;
		private System.ComponentModel.IContainer components;
        private string lastCheckedText = null;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager ultraToolbarsManager1;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _Form1_Toolbars_Dock_Area_Top;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _Form1_Toolbars_Dock_Area_Bottom;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _Form1_Toolbars_Dock_Area_Left;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _Form1_Toolbars_Dock_Area_Right;
		private System.Windows.Forms.ImageList imageList1;
		private Infragistics.Win.UltraWinSpellChecker.UltraSpellChecker ultraSpellChecker1;
        private Label label2;
        private Label label1;
        private UltraFormattedTextEditor ultraFormattedTextEditor2;
		private string prePreviewStyle = null;
        private string _accno = "";
        private string _hn = "";
        private string _pname = "";
        private string _exam = "";
        private string _excode = "";
        private string _ord = "";

        private ProcessGetGBLLookup lkp;
		#endregion //Private Members

		#region Constructor

		public Addendum(string accno,string hn,string pname,string exam,string excode,string ord)
		{
			InitializeComponent();
            ApplyFont();
            _accno = accno;
            _hn = hn;
            _pname = pname;
            _exam = exam;
            _ord = ord;
            _excode = excode;
            ((TextBoxTool)ultraToolbarsManager1.Tools["PHN"]).Text = _hn;
            ((TextBoxTool)ultraToolbarsManager1.Tools["Name"]).Text = _pname;
            ((TextBoxTool)ultraToolbarsManager1.Tools["Exam"]).Text = _exam;
            FinalResultText();

        }

        public Addendum(string accno, string hn, string pname, string exam, string excode, string ord, bool a)
        {
            InitializeComponent();
            ApplyFont();
            _accno = accno;
            _hn = hn;
            _pname = pname;
            _exam = exam;
            _ord = ord;
            _excode = excode;
            ((TextBoxTool)ultraToolbarsManager1.Tools["PHN"]).Text = _hn;
            ((TextBoxTool)ultraToolbarsManager1.Tools["Name"]).Text = _pname;
            ((TextBoxTool)ultraToolbarsManager1.Tools["Exam"]).Text = _exam;
            FinalResultText();
            ultraFormattedTextEditor1.ReadOnly = a;

        }

        #region FinalResultText
        public void FinalResultText()
        {
            string finalresult = "";
            string newSql = "select RESULT_TEXT_HTML AS TEXT,TITLE_ENG,FNAME_ENG,LNAME_ENG,FINALIZED_ON  FROM GBLV_HISTORY WHERE HN='" + _hn + "' and ACCESSION_NO='" + _accno + "'";
            lkp = new ProcessGetGBLLookup(newSql);
            lkp.Invoke();
            DataTable dt = lkp.ResultSet.Tables[0];
            if(dt.Rows.Count>0)
            {
                int i = 0;
                string qry = "select NOTE_TEXT,NOTE_ON FROM RIS_EXAMRESULTNOTE WHERE ACCESSION_NO='" + _accno + "' ORDER BY NOTE_NO DESC";
                lkp = new ProcessGetGBLLookup(qry);
                lkp.Invoke();
                DataTable dt2 = lkp.ResultSet.Tables[0];
                while(i<dt2.Rows.Count)
                {
                    string txts=dt2.Rows[i]["NOTE_TEXT"].ToString().Trim();
                    string noteon = dt2.Rows[i]["NOTE_ON"].ToString().Trim();
                    finalresult = finalresult +  txts +  "<br/><br/>";
                    i++;
                }
                ultraFormattedTextEditor2.Value = finalresult + "<br/><br/>Final Result<br/><br/>" + dt.Rows[0]["TEXT"].ToString().Trim() + "<br/><br/>Written By<br/>" + dt.Rows[0]["TITLE_ENG"].ToString().Trim() + " " + dt.Rows[0]["FNAME_ENG"].ToString().Trim() + " " + dt.Rows[0]["LNAME_ENG"].ToString().Trim() + "<br/>Date<br/>" + dt.Rows[0]["FINALIZED_ON"].ToString().Trim();
            }

        }
        #endregion
        #endregion //Constructor

        #region ApplyFont
        public void ApplyFont()
        {

            this.ultraFormattedTextEditor1.EditInfo.ApplyStyle("Font-family: " + new GBLEnvVariable().FontName, false);
            this.ultraFormattedTextEditor1.EditInfo.ApplyStyle("Font-size: " + new GBLEnvVariable().FontSize + "pt", false);
        }
        #endregion

        #region Dispose

        /// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#endregion //Dispose

		#region Event Handlers

		#region ultraToolbarsManager1_ToolClick

		private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
		{
			switch(e.Tool.Key) 
			{
                case "Save":
                                       
                    MyMessageBox msg = new MyMessageBox();
                    GBLEnvVariable env=new GBLEnvVariable();
                    int noteby=env.UserID;
                    int orgid = env.OrgID;
                    string writeby = env.TitleEng+" "+env.FirstNameEng + " " + env.LastNameEng;

                    int nordid=Convert.ToInt32(_ord.ToString().Trim());
                    int nexid=Convert.ToInt32(_excode.ToString().Trim());
                    string notetext=ultraFormattedTextEditor1.Value.ToString().Trim();
                    if(notetext=="")
                    {
                        MessageBox.Show("Your note can't be blank !!");
                        return;
                    }
                    string fname = "";
                    string mname = "";
                    string lname = "";
                    string tfname = "";
                    string tlname = "";
                    string gender = "";
                    string addr = "";
                    string phone = "";
                    string dob = "";

                    ProcessGetPatientReg regs = new ProcessGetPatientReg(_hn);
                    regs.Invoke();
                    DataTable dt = regs.ResultSet.Tables[0];
                    int ii = 0;
                    if (ii < dt.Rows.Count)
                    {
                         fname = dt.Rows[ii]["FNAME_ENG"].ToString().Trim();
                         mname = dt.Rows[ii]["MNAME_ENG"].ToString().Trim();
                         lname = dt.Rows[ii]["LNAME_ENG"].ToString().Trim();
                         tfname = dt.Rows[ii]["FNAME"].ToString().Trim();
                         tlname = dt.Rows[ii]["LNAME"].ToString().Trim();
                         gender = dt.Rows[ii]["GENDER"].ToString().Trim();
                         addr = dt.Rows[ii]["ADDR1"].ToString().Trim();
                         phone = dt.Rows[ii]["PHONE1"].ToString().Trim();
                         dob = dt.Rows[ii]["DOB"].ToString().Trim();

                        
                        ii++;

                    }

                    DataTable dtMSG = new DataTable();
                    dtMSG.Columns.Add("HN");
                    dtMSG.Columns.Add("FNAME");
                    dtMSG.Columns.Add("MNAME");
                    dtMSG.Columns.Add("LNAME");
                    dtMSG.Columns.Add("THFNAME");
                    dtMSG.Columns.Add("THMNAME");
                    dtMSG.Columns.Add("GENDER");
                    dtMSG.Columns.Add("DOB");
                    dtMSG.Columns.Add("PHONE");
                    dtMSG.Columns.Add("ADDRESS");
                    dtMSG.Columns.Add("ACCESSION_NO");
                    dtMSG.Columns.Add("STATUS");
                    dtMSG.Columns.Add("EXAM_ID");
                    dtMSG.Columns.Add("EXAM_NAME");
                    dtMSG.Columns.Add("HL7TXT");
                    dtMSG.Columns.Add("ORDNO");
                   
                   
                    string _notetext = ultraFormattedTextEditor2.Value.ToString().Trim();
                    string _nttext = "Addendum<br/><br/>" + notetext + "<br/><br/>Written By<br/>" + writeby + "<br/>Date<br/>" + DateTime.Now.ToShortDateString();
                    _notetext = "Addendum<br/><br/>" + notetext + "<br/><br/>Written By<br/>" + writeby + "<br/>Date<br/>" + DateTime.Now.ToShortDateString() + "<br/><br/>" + _notetext;
                    
                    dtMSG.Rows.Add(_hn,
                                fname,
                                mname,
                                lname,
                                tfname,
                                tlname,
                                gender,
                                dob,
                                phone,
                                addr,
                                _accno,
                                "F",
                                _excode.ToString().Trim(),
                                _exam.ToString().Trim(),
                                _notetext.Replace("&edsp;"," "),
                                _ord.ToString().Trim());

                    GenerateORU oru = new GenerateORU();
                    string dtoru = "";
                    DataTable dttbl = oru.createMessage(dtMSG);
                    if (dttbl.Rows.Count > 0)
                    {
                        dtoru = dttbl.Rows[0]["HL7_TXT"].ToString();
                    }

                    ExamAddendum ad = new ExamAddendum();
                    ad.OrderID = nordid;
                    ad.ExamID = nexid;
                    ad.AccessionNo = _accno;
                    ad.NoteText = _nttext;
                    ad.NoteBy = noteby;
                    ad.OrgID = orgid;
                    ad.Hl7Text = dtoru;
                    ProcessAddAddendum padd = new ProcessAddAddendum();
                    padd.ExamAddendum = ad;
                    padd.Invoke();


                    string refreshtext = ultraFormattedTextEditor2.Value.ToString().Trim();
                    refreshtext = "Addendum<br/><br/>" + notetext + "<br/><br/>Written By<br/>" + writeby + "<br/>Date<br/>"+DateTime.Now.ToShortDateString()+"<br/><br/>" + refreshtext;
                    ultraFormattedTextEditor2.Value = "";
                    ultraFormattedTextEditor2.Value = refreshtext;
                    string id44 = msg.ShowAlert("UID005", new GBLEnvVariable().CurrentLanguageID);

                    SendToPacs send = new SendToPacs();
                    send.Set_ORUByAccessionNoQueue(_accno);

                    break;


				case "Bold":
					this.ultraFormattedTextEditor1.EditInfo.PerformAction(FormattedLinkEditorAction.ToggleBold);
					break;

				case "Italic":
					this.ultraFormattedTextEditor1.EditInfo.PerformAction(FormattedLinkEditorAction.ToggleItalics);
					break;

				case "Underline":
					this.ultraFormattedTextEditor1.EditInfo.PerformAction(FormattedLinkEditorAction.ToggleUnderline);
					break;

				case "Left":
				case "Center":
				case "Right":
				case "Justify":
					this.ultraFormattedTextEditor1.EditInfo.ApplyStyle("Text-align: " + e.Tool.Key, true);
					break;

				case "InsertPicture":
					this.ultraFormattedTextEditor1.EditInfo.ShowImageDialog();
					break;

				case "Hyperlink":
					this.ultraFormattedTextEditor1.EditInfo.ShowLinkDialog();
					break;

				case "ColorSchemeList":
					ListToolItem item = ((ListTool)e.Tool).SelectedItem;
					if(item != null)
						Office2007ColorTable.ColorScheme = (Office2007ColorScheme)item.Value;

					break;

				case "Paste":
					this.ultraFormattedTextEditor1.EditInfo.PerformAction(FormattedLinkEditorAction.Paste);
					break;

				case "Font Dialog":
					this.ultraFormattedTextEditor1.EditInfo.ShowFontDialog();
					break;

				case "FullSpellCheck":
					this.ultraSpellChecker1.ShowSpellCheckDialog(this, this.ultraFormattedTextEditor1);
					break;

				case "Check Selection":
					string selectedText = this.ultraFormattedTextEditor1.EditInfo.Editor.SelectedText;
					ErrorCollection errors = this.ultraSpellChecker1.CheckText(selectedText);
					
					break;

				case "ShowImageDialog":
					this.ultraFormattedTextEditor1.EditInfo.ShowImageDialog();
					break;

				case "FontHighlight":
					PopupColorPickerTool highlightTool = (PopupColorPickerTool)e.Tool;
					Color highlightColor = Color.White;

					if(highlightTool.Checked)
						highlightColor = highlightTool.SelectedColor;
					else 
					{
						Color editorBackColor = this.ultraFormattedTextEditor1.Appearance.BackColor;
						if(!editorBackColor.IsEmpty)
							highlightColor = this.ultraFormattedTextEditor1.Appearance.BackColor;
					}
					
					string hexHighlightColor = System.Drawing.ColorTranslator.ToHtml(highlightColor);
					this.ultraFormattedTextEditor1.EditInfo.ApplyStyle("Background-color: " + hexHighlightColor, false);
					
					break;

				case "FontColor":
					this.ApplyFontForeColor();

					break;

				case "Reset":
					this.Reset();

					break;

				case "AutoCorrect":

                    // Get the caret element so that we can check to see if there is an error at the specific location
                    CaretUIElement cElement = this.ultraFormattedTextEditor1.UIElement.GetDescendant(typeof(CaretUIElement)) as CaretUIElement;
                    if (cElement != null)
                    {
                        Error spellError = this.ultraSpellChecker1.GetErrorAtPoint(this.ultraFormattedTextEditor1, cElement.Rect.Location);
                        if (spellError != null)
                        {
                            // We want to select the word, delete it, then insert the first suggestion that is provided by the spell checker
                            this.ultraFormattedTextEditor1.EditInfo.SelectionStart = this.GetCurrentWordStartPosition();
                            this.ultraFormattedTextEditor1.EditInfo.SelectionLength = 1 + spellError.EndIndex - spellError.StartIndex;
                            this.ultraFormattedTextEditor1.EditInfo.PerformAction(FormattedLinkEditorAction.Delete);
                            this.ultraFormattedTextEditor1.EditInfo.InsertValue(spellError.Suggestions[0]);
                        }

                        // Since there isn't an at the current caret position, we can hide the spelling tab
                        this.ultraToolbarsManager1.Ribbon.Tabs["Spelling"].Visible = false;
                    }

					break;

				case "Exit":
					this.Close();

					break;

				case "Enable MiniToolbar on ContextMenu":
					this.ultraToolbarsManager1.MiniToolbar.AutoShow = ((StateButtonTool)e.Tool).Checked ? 
						MiniToolbarAutoShow.OnContextMenuClick :
						MiniToolbarAutoShow.Never;

					break;

				case "FormattedText":
					this.ultraFormattedTextEditor1.TreatValueAs = Infragistics.Win.FormattedLinkLabel.TreatValueAs.FormattedText;
					break;

				case "Auto":
					this.ultraFormattedTextEditor1.TreatValueAs = Infragistics.Win.FormattedLinkLabel.TreatValueAs.Auto;
					break;

				case "URL":
					this.ultraFormattedTextEditor1.TreatValueAs = Infragistics.Win.FormattedLinkLabel.TreatValueAs.URL;
					break;
			}
		}

		#endregion //ultraToolbarsManager1_ToolClick

		#region ultraFormattedTextEditor1_EditStateChanged

		private void ultraFormattedTextEditor1_EditStateChanged(object sender, Infragistics.Win.FormattedLinkLabel.EditStateChangedEventArgs e)
		{
			StyleInfo si = this.ultraFormattedTextEditor1.EditInfo.GetCurrentStyle();

			// We want to prevent any of the logic in the ToolClick event handler from executing, otherwise we'll
			// have an infinite loop.
			this.ultraToolbarsManager1.EventManager.SetEnabled(ToolbarEventIds.ToolClick, false);

			#region Update Format Button States

			((StateButtonTool)this.ultraToolbarsManager1.Tools["Bold"]).Checked = 
				si.Appearance.FontData.Bold == DefaultableBoolean.True ? true : false;

			((StateButtonTool)this.ultraToolbarsManager1.Tools["Italic"]).Checked = 
				si.Appearance.FontData.Italic == DefaultableBoolean.True ? true : false;

			((StateButtonTool)this.ultraToolbarsManager1.Tools["Underline"]).Checked = 
				si.Appearance.FontData.Underline == DefaultableBoolean.True ? true : false;

			((StateButtonTool)this.ultraToolbarsManager1.Tools["Left"]).Checked =
				si.LineAlignment == LineAlignment.Left || si.LineAlignment == LineAlignment.Default;

			((StateButtonTool)this.ultraToolbarsManager1.Tools["Center"]).Checked =
				si.LineAlignment == LineAlignment.Center;

			((StateButtonTool)this.ultraToolbarsManager1.Tools["Right"]).Checked =
				si.LineAlignment == LineAlignment.Right;

			((StateButtonTool)this.ultraToolbarsManager1.Tools["Justify"]).Checked =
				si.LineAlignment == LineAlignment.Justify;

			#endregion //Update Format Button States

			#region Contextual Tab Group Visibility

			bool isTextSelected = this.ultraFormattedTextEditor1.EditInfo.Editor.SelectedText.Length > 0;
			this.ultraToolbarsManager1.Ribbon.Tabs["TextTools"].Visible = isTextSelected;

			#endregion //Contextual Tab Group Visibility

            CaretUIElement cElement = this.ultraFormattedTextEditor1.UIElement.GetDescendant(typeof(CaretUIElement)) as CaretUIElement;
            if (cElement != null)
            {
                Error spellError = this.ultraSpellChecker1.GetErrorAtPoint(this.ultraFormattedTextEditor1, cElement.Rect.Location);
                if (spellError != null)
                {
                    this.ultraToolbarsManager1.Tools["AutoCorrect"].SharedProps.Caption = String.Format("AutoCorrect '{0}'", spellError.CheckedWord);
					this.ultraToolbarsManager1.Tools["AutoCorrect"].SharedProps.Enabled = spellError.Suggestions.Count > 0;
                    this.ultraToolbarsManager1.Ribbon.Tabs["Spelling"].Visible = true;
                }
                else
                {
                    this.ultraToolbarsManager1.Ribbon.Tabs["Spelling"].Visible = false;
                }
            }

			PopupGalleryTool gallery = (PopupGalleryTool)this.ultraToolbarsManager1.Tools["PresetsGallery"];
			string presetGroupKey;

			if(this.prePreviewStyle == null) 
			{
				if(IsPresetStyle(si, out presetGroupKey))
				{
					gallery.SelectedItemKey = presetGroupKey;
				}
				else
					gallery.SelectedItem = null;
			}


			this.ultraToolbarsManager1.EventManager.SetEnabled(ToolbarEventIds.ToolClick, true);
		}

		#endregion //ultraFormattedTextEditor1_EditStateChanged

        #region ultraSpellChecker1_SpellChecked

        private void ultraSpellChecker1_SpellChecked(object sender, SpellCheckedEventArgs e)
        {
            // Strip out the carriage return since it's not counted as a character in the selection positions
            this.lastCheckedText = e.Text.Replace("\r", "");
        }

        #endregion //ultraSpellChecker1_SpellChecked

        #region ultraToolbarsManager1_ToolValueChanged

        private void ultraToolbarsManager1_ToolValueChanged(object sender, Infragistics.Win.UltraWinToolbars.ToolEventArgs e)
		{
			switch(e.Tool.Key) 
			{
				case "FontName":
					string fontName = ((FontListTool)e.Tool).Text;
					this.ultraFormattedTextEditor1.EditInfo.ApplyStyle("Font-family: " + fontName, false);
					
					break;

				case "FontColor":
					this.ApplyFontForeColor();
					
					break;

				case "FontSize":
					string selectedSize = ((ComboBoxTool)e.Tool).Value.ToString();
					this.ultraFormattedTextEditor1.EditInfo.ApplyStyle("Font-size: " + selectedSize, false);
					
					break;
			}
			this.ultraFormattedTextEditor1.Focus();
		}

		#endregion //ultraToolbarsManager1_ToolValueChanged

		#region ultraToolbarsManager1_GalleryToolItemClick

		private void ultraToolbarsManager1_GalleryToolItemClick(object sender, Infragistics.Win.UltraWinToolbars.GalleryToolItemEventArgs e)
		{
			if(e.GalleryTool.Key == "PresetsGallery") 
			{
				// Before applying any presets, we want to clear the existing style attributes
				// so that none are merged with the presets (i.e. if 'underline' is checked and we select
				// a preset that does not have this attribute, we won't want it to remain)
				this.ultraFormattedTextEditor1.EditInfo.ClearAllStyleAttributes();

				string style = e.Item.Tag.ToString();
				this.ultraFormattedTextEditor1.EditInfo.ApplyStyle(style, false);

				// If the user has shown a live preview, but has selected this style, we don't want to undo that.
				if(this.prePreviewStyle == e.Item.Tag.ToString())
					this.prePreviewStyle = null;

				// Prevent the toolbars manager from firing any of the events that we're listening to
				// that have any logic that we don't want to execute at this state, since we're simply
				// syncing the buttons with the style in the gallery
				UltraToolbarsManager manager = sender as UltraToolbarsManager;
				manager.EventManager.SetEnabled(ToolbarEventIds.ToolClick, false);
				manager.EventManager.SetEnabled(ToolbarEventIds.ToolValueChanged, false);

				// Check each attribute in the style and sync the tool states as necessary.
				// Note that format buttons are automatically synced through the EditStateChanged event
				// of the formatted text editor
				string[] styleAttributes = style.Split(';');
				foreach(string attribute in styleAttributes) 
				{
					string[] propertyInfo = attribute.Split(':');
					switch(propertyInfo[0].Trim().ToLower())
					{
						case "font-size":
							((ComboBoxTool)manager.Tools["FontSize"]).Text = propertyInfo[1];
							break;

						case "font-family":
							((FontListTool)manager.Tools["FontName"]).Text = propertyInfo[1];
							break;
					}
				}

				// Allow the toolbars manager to fire the events that we disabled
				manager.EventManager.SetEnabled(ToolbarEventIds.ToolClick, true);
				manager.EventManager.SetEnabled(ToolbarEventIds.ToolValueChanged, true);
			}
		}

		#endregion //ultraToolbarsManager1_GalleryToolItemClick

		#region ultraToolbarsManager1_GalleryToolActiveItemChange

		// Peform the logic necessary for a live preview, which shows the effect that the preset style will have
		// on the selected text, but is undone if the user does not click on the tool.
		private void ultraToolbarsManager1_GalleryToolActiveItemChange(object sender, Infragistics.Win.UltraWinToolbars.GalleryToolItemEventArgs e)
		{
			// If nothing is selected, we want to apply the preview to all text
			bool applyToBlocks = this.ultraFormattedTextEditor1.EditInfo.SelectionLength == 0;

			if(e.Item == null) 
			{
				if(this.prePreviewStyle != null) 
				{
					this.ultraFormattedTextEditor1.EditInfo.ClearStyleAttributes(this.ultraFormattedTextEditor1.EditInfo.GetCurrentStyle().GetSetAttributes(), applyToBlocks);
					this.ultraFormattedTextEditor1.EditInfo.ApplyStyle(this.prePreviewStyle, applyToBlocks);
					this.prePreviewStyle = null;
				}
			}
			else 
			{
				// We don't want to overwrite the stored style with a preview style
				if(this.prePreviewStyle == null)
					this.prePreviewStyle = this.ultraFormattedTextEditor1.EditInfo.GetCurrentStyle().ToString();
				
				this.ultraFormattedTextEditor1.EditInfo.ApplyStyle(e.Item.Tag.ToString(), applyToBlocks);
			}
		}

		#endregion //ultraToolbarsManager1_GalleryToolActiveItemChange

		#region Form1_Load

		private void Form1_Load(object sender, System.EventArgs e)
		{
			this.Initialize();
		}

		#endregion //Form1_Load

		#endregion //Event Handlers

		#region Methods

		#region Reset

		// Reset text formatting
		private void Reset() 
		{
			// Font defaults
			((ComboBoxTool)this.ultraToolbarsManager1.Tools["FontSize"]).SelectedIndex = 2;
			((FontListTool)this.ultraToolbarsManager1.Tools["FontName"]).SelectedIndex = 0;

			((StateButtonTool)this.ultraToolbarsManager1.Tools["Left"]).Checked = true;
			((StateButtonTool)this.ultraToolbarsManager1.Tools["Bold"]).Checked = false;
			((StateButtonTool)this.ultraToolbarsManager1.Tools["Italic"]).Checked = false;
			((StateButtonTool)this.ultraToolbarsManager1.Tools["Underline"]).Checked = false;
		}
		#endregion //Reset

		#region Initialize

		private void Initialize() 
		{
			// Don't fire any toolbar events during initialization
			this.ultraToolbarsManager1.EventManager.AllEventsEnabled = false;

			// Set-up color scheme options for use in the ApplicationMenu on the Ribbon
			ListTool list = (ListTool)this.ultraToolbarsManager1.Tools["ColorSchemeList"];
			list.ListToolItems["Blue"].Value = Infragistics.Win.Office2007ColorScheme.Blue;
			list.ListToolItems["Black"].Value = Infragistics.Win.Office2007ColorScheme.Black;
			list.ListToolItems["Silver"].Value = Infragistics.Win.Office2007ColorScheme.Silver;
			list.SelectedItemIndex = list.ListToolItems["Blue"].Index;

			// Don't show any of the contextual tab groups on load
			this.ultraToolbarsManager1.Ribbon.Tabs["TextTools"].Visible = false;
			this.ultraToolbarsManager1.Ribbon.Tabs["Spelling"].Visible = false;

			this.Reset();

			this.ultraToolbarsManager1.EventManager.AllEventsEnabled = true;
		}

		#endregion //Initialize

        #region GetCurrentWordStartPosition

        private int GetCurrentWordStartPosition()
        {
            int cursorPosition = this.ultraFormattedTextEditor1.EditInfo.SelectionStart;
            if (cursorPosition == 0)
                return 0;

            for (int i = cursorPosition - 1; i >= 0; i--)
            {
                if (!Char.IsLetter(this.lastCheckedText[i]))
                    return i + 1;
            }

            return 0;
        }

        #endregion //GetCurrentWordStartPosition

		#region IsPresetStyle

		// Returns whether the provided style information matches with one of the presets in the gallery
		private bool IsPresetStyle(StyleInfo si, out string match) 
		{
			PopupGalleryTool presetGallery = (PopupGalleryTool)this.ultraToolbarsManager1.Tools["PresetsGallery"];

			// We don't want to worry about a string failing to match due to an extra space or case difference
			string styleAttributes = si.ToString().ToLower().Replace(" ", String.Empty);

			// Check each of the preset gallery tool items to see if the current style of the formatted text editor
			// is the same as the preset style
			foreach(GalleryToolItem item in presetGallery.Items) 
			{
				string itemAttributes = item.Tag.ToString().ToLower().Replace(" ", String.Empty);
				if(String.Equals(itemAttributes, styleAttributes))
				{
					match = item.Key;
					return true;
				}
			}

			match = String.Empty;
			return false;
		}

		#endregion //IsPresetStyle

		#region ApplyFontForeColor

		private void ApplyFontForeColor() 
		{
			Color fontColor = ((PopupColorPickerTool)this.ultraToolbarsManager1.Tools["FontColor"]).SelectedColor;
			string hexColor = System.Drawing.ColorTranslator.ToHtml(fontColor);
			this.ultraFormattedTextEditor1.EditInfo.ApplyStyle("Color: " + hexColor, false);
			this.ultraFormattedTextEditor1.EditInfo.ApplyStyle("Border-color: " + hexColor, false);
		}

		#endregion //ApplyFontForeColor

		#endregion //Methods

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinScrollBar.ScrollBarLook scrollBarLook1 = new Infragistics.Win.UltraWinScrollBar.ScrollBarLook();
            Infragistics.Win.UltraWinScrollBar.ScrollBarLook scrollBarLook2 = new Infragistics.Win.UltraWinScrollBar.ScrollBarLook();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Addendum));
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool1 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("Bold", "");
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool2 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("Italic", "");
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool3 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("Underline", "");
            Infragistics.Win.UltraWinToolbars.OptionSet optionSet1 = new Infragistics.Win.UltraWinToolbars.OptionSet("TreatValueAs");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Exit");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool1 = new Infragistics.Win.UltraWinToolbars.LabelTool("ColorScheme");
            Infragistics.Win.UltraWinToolbars.ListTool listTool1 = new Infragistics.Win.UltraWinToolbars.ListTool("ColorSchemeList");
            Infragistics.Win.UltraWinToolbars.ContextualTabGroup contextualTabGroup1 = new Infragistics.Win.UltraWinToolbars.ContextualTabGroup("Text");
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ContextualTabGroup contextualTabGroup2 = new Infragistics.Win.UltraWinToolbars.ContextualTabGroup("Spelling");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.RibbonTab ribbonTab1 = new Infragistics.Win.UltraWinToolbars.RibbonTab("Format");
            Infragistics.Win.UltraWinToolbars.RibbonGroup ribbonGroup1 = new Infragistics.Win.UltraWinToolbars.RibbonGroup("TextStyle");
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool4 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("Bold", "");
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool5 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("Italic", "");
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool6 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("Underline", "");
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Reset");
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool7 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("Left", "");
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool8 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("Center", "");
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool9 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("Right", "");
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool10 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("Justify", "");
            Infragistics.Win.UltraWinToolbars.RibbonGroup ribbonGroup2 = new Infragistics.Win.UltraWinToolbars.RibbonGroup("Font");
            Infragistics.Win.UltraWinToolbars.FontListTool fontListTool1 = new Infragistics.Win.UltraWinToolbars.FontListTool("FontName");
            Infragistics.Win.UltraWinToolbars.ComboBoxTool comboBoxTool1 = new Infragistics.Win.UltraWinToolbars.ComboBoxTool("FontSize");
            Infragistics.Win.UltraWinToolbars.PopupColorPickerTool popupColorPickerTool1 = new Infragistics.Win.UltraWinToolbars.PopupColorPickerTool("FontHighlight");
            Infragistics.Win.UltraWinToolbars.PopupColorPickerTool popupColorPickerTool2 = new Infragistics.Win.UltraWinToolbars.PopupColorPickerTool("FontColor");
            Infragistics.Win.UltraWinToolbars.RibbonGroup ribbonGroup3 = new Infragistics.Win.UltraWinToolbars.RibbonGroup("Presets");
            Infragistics.Win.UltraWinToolbars.PopupGalleryTool popupGalleryTool1 = new Infragistics.Win.UltraWinToolbars.PopupGalleryTool("PresetsGallery");
            Infragistics.Win.UltraWinToolbars.RibbonGroup ribbonGroup4 = new Infragistics.Win.UltraWinToolbars.RibbonGroup("Editor Options");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool22 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Save");
            Infragistics.Win.UltraWinToolbars.RibbonGroup ribbonGroup5 = new Infragistics.Win.UltraWinToolbars.RibbonGroup("ribbonGroup1");
            Infragistics.Win.UltraWinToolbars.TextBoxTool textBoxTool1 = new Infragistics.Win.UltraWinToolbars.TextBoxTool("PHN");
            Infragistics.Win.UltraWinToolbars.TextBoxTool textBoxTool3 = new Infragistics.Win.UltraWinToolbars.TextBoxTool("Name");
            Infragistics.Win.UltraWinToolbars.TextBoxTool textBoxTool4 = new Infragistics.Win.UltraWinToolbars.TextBoxTool("Exam");
            Infragistics.Win.UltraWinToolbars.RibbonTab ribbonTab2 = new Infragistics.Win.UltraWinToolbars.RibbonTab("Insert");
            Infragistics.Win.UltraWinToolbars.RibbonGroup ribbonGroup6 = new Infragistics.Win.UltraWinToolbars.RibbonGroup("Images");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("InsertPicture");
            Infragistics.Win.UltraWinToolbars.RibbonGroup ribbonGroup7 = new Infragistics.Win.UltraWinToolbars.RibbonGroup("Clipboard");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Paste");
            Infragistics.Win.UltraWinToolbars.RibbonGroup ribbonGroup8 = new Infragistics.Win.UltraWinToolbars.RibbonGroup("Hyperlink");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Hyperlink");
            Infragistics.Win.UltraWinToolbars.RibbonTab ribbonTab3 = new Infragistics.Win.UltraWinToolbars.RibbonTab("TextTools");
            Infragistics.Win.UltraWinToolbars.RibbonGroup ribbonGroup9 = new Infragistics.Win.UltraWinToolbars.RibbonGroup("FontDialog");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Font Dialog");
            Infragistics.Win.UltraWinToolbars.RibbonTab ribbonTab4 = new Infragistics.Win.UltraWinToolbars.RibbonTab("Tools");
            Infragistics.Win.UltraWinToolbars.RibbonGroup ribbonGroup10 = new Infragistics.Win.UltraWinToolbars.RibbonGroup("Spelling");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool7 = new Infragistics.Win.UltraWinToolbars.ButtonTool("FullSpellCheck");
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.RibbonTab ribbonTab5 = new Infragistics.Win.UltraWinToolbars.RibbonTab("Spelling");
            Infragistics.Win.UltraWinToolbars.RibbonGroup ribbonGroup11 = new Infragistics.Win.UltraWinToolbars.RibbonGroup("Spelling");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool8 = new Infragistics.Win.UltraWinToolbars.ButtonTool("AutoCorrect");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool9 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Paste");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool10 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool1");
            Infragistics.Win.UltraWinToolbars.FontListTool fontListTool2 = new Infragistics.Win.UltraWinToolbars.FontListTool("FontName");
            Infragistics.Win.UltraWinToolbars.PopupColorPickerTool popupColorPickerTool3 = new Infragistics.Win.UltraWinToolbars.PopupColorPickerTool("FontColor");
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool15 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("Bold", "");
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool16 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("Italic", "");
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool17 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("Underline", "");
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ComboBoxTool comboBoxTool2 = new Infragistics.Win.UltraWinToolbars.ComboBoxTool("FontSize");
            Infragistics.Win.ValueList valueList1 = new Infragistics.Win.ValueList(0);
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem7 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem8 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem9 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool11 = new Infragistics.Win.UltraWinToolbars.ButtonTool("InsertPicture");
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool12 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Paste");
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool2 = new Infragistics.Win.UltraWinToolbars.LabelTool("ColorScheme");
            Infragistics.Win.UltraWinToolbars.ListTool listTool2 = new Infragistics.Win.UltraWinToolbars.ListTool("ColorSchemeList");
            Infragistics.Win.UltraWinToolbars.ListToolItem listToolItem1 = new Infragistics.Win.UltraWinToolbars.ListToolItem("Black");
            Infragistics.Win.UltraWinToolbars.ListToolItem listToolItem2 = new Infragistics.Win.UltraWinToolbars.ListToolItem("Blue");
            Infragistics.Win.UltraWinToolbars.ListToolItem listToolItem3 = new Infragistics.Win.UltraWinToolbars.ListToolItem("Silver");
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool18 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("Left", "");
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool19 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("Center", "");
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool20 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("Right", "");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool13 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Font Dialog");
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.PopupGalleryTool popupGalleryTool2 = new Infragistics.Win.UltraWinToolbars.PopupGalleryTool("PresetsGallery");
            Infragistics.Win.UltraWinToolbars.GalleryToolItem galleryToolItem1 = new Infragistics.Win.UltraWinToolbars.GalleryToolItem("Normal", "");
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.GalleryToolItem galleryToolItem2 = new Infragistics.Win.UltraWinToolbars.GalleryToolItem("Heading1", "");
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.GalleryToolItem galleryToolItem3 = new Infragistics.Win.UltraWinToolbars.GalleryToolItem("Heading2", "");
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool14 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Check Selection");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool15 = new Infragistics.Win.UltraWinToolbars.ButtonTool("FullSpellCheck");
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool16 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ShowImageDialog");
            Infragistics.Win.UltraWinToolbars.PopupColorPickerTool popupColorPickerTool4 = new Infragistics.Win.UltraWinToolbars.PopupColorPickerTool("FontHighlight");
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool21 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("Justify", "");
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool17 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Reset");
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool18 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Hyperlink");
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool19 = new Infragistics.Win.UltraWinToolbars.ButtonTool("AutoCorrect");
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool20 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Exit");
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool21 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool1");
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool22 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("Enable MiniToolbar on ContextMenu", "");
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool23 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("FormattedText", "TreatValueAs");
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool24 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("Auto", "TreatValueAs");
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool25 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("StateButtonTool3", "TreatValueAs");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool23 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Save");
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool4 = new Infragistics.Win.UltraWinToolbars.LabelTool("HN");
            Infragistics.Win.UltraWinToolbars.TextBoxTool textBoxTool2 = new Infragistics.Win.UltraWinToolbars.TextBoxTool("PHN");
            Infragistics.Win.UltraWinToolbars.TextBoxTool textBoxTool5 = new Infragistics.Win.UltraWinToolbars.TextBoxTool("Name");
            Infragistics.Win.UltraWinToolbars.TextBoxTool textBoxTool6 = new Infragistics.Win.UltraWinToolbars.TextBoxTool("Exam");
            this.Form1_Fill_Panel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ultraFormattedTextEditor2 = new Infragistics.Win.FormattedLinkLabel.UltraFormattedTextEditor();
            this.ultraSpellChecker1 = new Infragistics.Win.UltraWinSpellChecker.UltraSpellChecker(this.components);
            this.ultraFormattedTextEditor1 = new Infragistics.Win.FormattedLinkLabel.UltraFormattedTextEditor();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this._Form1_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ultraToolbarsManager1 = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this._Form1_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._Form1_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._Form1_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.Form1_Fill_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraSpellChecker1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // Form1_Fill_Panel
            // 
            this.Form1_Fill_Panel.BackColor = System.Drawing.Color.White;
            this.Form1_Fill_Panel.Controls.Add(this.label2);
            this.Form1_Fill_Panel.Controls.Add(this.label1);
            this.Form1_Fill_Panel.Controls.Add(this.ultraFormattedTextEditor2);
            this.Form1_Fill_Panel.Controls.Add(this.ultraFormattedTextEditor1);
            this.Form1_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.Form1_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Form1_Fill_Panel.Location = new System.Drawing.Point(4, 181);
            this.Form1_Fill_Panel.Name = "Form1_Fill_Panel";
            this.Form1_Fill_Panel.Size = new System.Drawing.Size(765, 351);
            this.Form1_Fill_Panel.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Location = new System.Drawing.Point(3, 222);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Add Note";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(8, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Final Result Text";
            // 
            // ultraFormattedTextEditor2
            // 
            appearance41.BackColorDisabled = System.Drawing.Color.White;
            this.ultraFormattedTextEditor2.ActiveLinkAppearance = appearance41;
            appearance42.BackColor = System.Drawing.Color.White;
            appearance42.BackColor2 = System.Drawing.Color.White;
            appearance42.BackColorDisabled2 = System.Drawing.Color.White;
            this.ultraFormattedTextEditor2.Appearance = appearance42;
            this.ultraFormattedTextEditor2.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraToolbarsManager1.SetContextMenuUltra(this.ultraFormattedTextEditor2, "FontColor");
            this.ultraFormattedTextEditor2.Location = new System.Drawing.Point(2, 22);
            this.ultraFormattedTextEditor2.Name = "ultraFormattedTextEditor2";
            this.ultraFormattedTextEditor2.ReadOnly = true;
            scrollBarLook1.ViewStyle = Infragistics.Win.UltraWinScrollBar.ScrollBarViewStyle.Office2007;
            this.ultraFormattedTextEditor2.ScrollBarLook = scrollBarLook1;
            this.ultraFormattedTextEditor2.Size = new System.Drawing.Size(762, 198);
            this.ultraFormattedTextEditor2.SpellChecker = this.ultraSpellChecker1;
            this.ultraFormattedTextEditor2.TabIndex = 1;
            this.ultraFormattedTextEditor2.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.ultraFormattedTextEditor2.Value = "";
            // 
            // ultraSpellChecker1
            // 
            this.ultraSpellChecker1.ContainingControl = this;
            this.ultraSpellChecker1.Mode = Infragistics.Win.UltraWinSpellChecker.SpellCheckingMode.AsYouType;
            this.ultraSpellChecker1.SpellChecked += new Infragistics.Win.UltraWinSpellChecker.SpellCheckedEventHandler(this.ultraSpellChecker1_SpellChecked);
            // 
            // ultraFormattedTextEditor1
            // 
            this.ultraFormattedTextEditor1.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraToolbarsManager1.SetContextMenuUltra(this.ultraFormattedTextEditor1, "FontColor");
            this.ultraFormattedTextEditor1.Location = new System.Drawing.Point(2, 242);
            this.ultraFormattedTextEditor1.Name = "ultraFormattedTextEditor1";
            scrollBarLook2.ViewStyle = Infragistics.Win.UltraWinScrollBar.ScrollBarViewStyle.Office2007;
            this.ultraFormattedTextEditor1.ScrollBarLook = scrollBarLook2;
            this.ultraFormattedTextEditor1.Size = new System.Drawing.Size(762, 142);
            this.ultraFormattedTextEditor1.SpellChecker = this.ultraSpellChecker1;
            this.ultraFormattedTextEditor1.TabIndex = 0;
            this.ultraFormattedTextEditor1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.ultraFormattedTextEditor1.Value = "";
            this.ultraFormattedTextEditor1.EditStateChanged += new Infragistics.Win.FormattedLinkLabel.EditStateChangedEventHandler(this.ultraFormattedTextEditor1_EditStateChanged);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.White;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            this.imageList1.Images.SetKeyName(6, "");
            this.imageList1.Images.SetKeyName(7, "");
            this.imageList1.Images.SetKeyName(8, "");
            this.imageList1.Images.SetKeyName(9, "");
            this.imageList1.Images.SetKeyName(10, "");
            this.imageList1.Images.SetKeyName(11, "");
            this.imageList1.Images.SetKeyName(12, "");
            this.imageList1.Images.SetKeyName(13, "");
            this.imageList1.Images.SetKeyName(14, "");
            this.imageList1.Images.SetKeyName(15, "");
            this.imageList1.Images.SetKeyName(16, "");
            this.imageList1.Images.SetKeyName(17, "");
            this.imageList1.Images.SetKeyName(18, "");
            this.imageList1.Images.SetKeyName(19, "");
            this.imageList1.Images.SetKeyName(20, "");
            this.imageList1.Images.SetKeyName(21, "");
            this.imageList1.Images.SetKeyName(22, "");
            this.imageList1.Images.SetKeyName(23, "");
            this.imageList1.Images.SetKeyName(24, "");
            this.imageList1.Images.SetKeyName(25, "");
            this.imageList1.Images.SetKeyName(26, "");
            this.imageList1.Images.SetKeyName(27, "");
            this.imageList1.Images.SetKeyName(28, "");
            this.imageList1.Images.SetKeyName(29, "");
            this.imageList1.Images.SetKeyName(30, "");
            this.imageList1.Images.SetKeyName(31, "");
            this.imageList1.Images.SetKeyName(32, "");
            this.imageList1.Images.SetKeyName(33, "");
            this.imageList1.Images.SetKeyName(34, "");
            this.imageList1.Images.SetKeyName(35, "");
            this.imageList1.Images.SetKeyName(36, "");
            this.imageList1.Images.SetKeyName(37, "");
            this.imageList1.Images.SetKeyName(38, "");
            this.imageList1.Images.SetKeyName(39, "");
            this.imageList1.Images.SetKeyName(40, "");
            this.imageList1.Images.SetKeyName(41, "");
            this.imageList1.Images.SetKeyName(42, "");
            this.imageList1.Images.SetKeyName(43, "");
            this.imageList1.Images.SetKeyName(44, "");
            this.imageList1.Images.SetKeyName(45, "");
            this.imageList1.Images.SetKeyName(46, "");
            // 
            // _Form1_Toolbars_Dock_Area_Right
            // 
            this._Form1_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._Form1_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._Form1_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._Form1_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Form1_Toolbars_Dock_Area_Right.InitialResizeAreaExtent = 4;
            this._Form1_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(769, 181);
            this._Form1_Toolbars_Dock_Area_Right.Name = "_Form1_Toolbars_Dock_Area_Right";
            this._Form1_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(4, 351);
            this._Form1_Toolbars_Dock_Area_Right.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // ultraToolbarsManager1
            // 
            this.ultraToolbarsManager1.DesignerFlags = 1;
            this.ultraToolbarsManager1.DockWithinContainer = this;
            this.ultraToolbarsManager1.DockWithinContainerBaseType = typeof(System.Windows.Forms.Form);
            this.ultraToolbarsManager1.ImageListSmall = this.imageList1;
            this.ultraToolbarsManager1.MiniToolbar.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            stateButtonTool1,
            stateButtonTool2,
            stateButtonTool3});
            optionSet1.AllowAllUp = false;
            this.ultraToolbarsManager1.OptionSets.Add(optionSet1);
            this.ultraToolbarsManager1.Ribbon.ApplicationMenu.KeyTip = "M";
            this.ultraToolbarsManager1.Ribbon.ApplicationMenu.ToolAreaLeft.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1});
            this.ultraToolbarsManager1.Ribbon.ApplicationMenu.ToolAreaRight.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            labelTool1,
            listTool1});
            this.ultraToolbarsManager1.Ribbon.ApplicationMenu.ToolAreaRight.Settings.LabelDisplayStyle = Infragistics.Win.UltraWinToolbars.LabelMenuDisplayStyle.Header;
            this.ultraToolbarsManager1.Ribbon.ApplicationMenu.ToolAreaRight.Settings.ShowIconArea = Infragistics.Win.DefaultableBoolean.True;
            this.ultraToolbarsManager1.Ribbon.ApplicationMenuButtonImage = ((System.Drawing.Image)(resources.GetObject("ultraToolbarsManager1.Ribbon.ApplicationMenuButtonImage")));
            contextualTabGroup1.Caption = "Selected Text";
            appearance1.TextHAlignAsString = "Center";
            contextualTabGroup1.CaptionAppearance = appearance1;
            contextualTabGroup1.Key = "Text";
            contextualTabGroup2.Caption = "Spelling";
            appearance2.TextHAlignAsString = "Center";
            contextualTabGroup2.CaptionAppearance = appearance2;
            contextualTabGroup2.Key = "Spelling";
            this.ultraToolbarsManager1.Ribbon.NonInheritedContextualTabGroups.AddRange(new Infragistics.Win.UltraWinToolbars.ContextualTabGroup[] {
            contextualTabGroup1,
            contextualTabGroup2});
            ribbonGroup1.Caption = "Text Style";
            ribbonGroup1.LayoutDirection = Infragistics.Win.UltraWinToolbars.RibbonGroupToolLayoutDirection.Horizontal;
            appearance3.Image = 3;
            stateButtonTool4.InstanceProps.AppearancesSmall.Appearance = appearance3;
            stateButtonTool4.InstanceProps.ButtonGroup = "TextStyle";
            stateButtonTool4.InstanceProps.IsFirstInGroup = true;
            appearance4.Image = 5;
            stateButtonTool5.InstanceProps.AppearancesSmall.Appearance = appearance4;
            stateButtonTool5.InstanceProps.ButtonGroup = "TextStyle";
            appearance5.Image = 4;
            stateButtonTool6.InstanceProps.AppearancesSmall.Appearance = appearance5;
            stateButtonTool6.InstanceProps.ButtonGroup = "TextStyle";
            buttonTool2.InstanceProps.ButtonGroup = "Reset";
            stateButtonTool7.Checked = true;
            appearance6.Image = 0;
            stateButtonTool7.InstanceProps.AppearancesSmall.Appearance = appearance6;
            stateButtonTool7.InstanceProps.ButtonGroup = "TextAlign";
            appearance7.Image = 1;
            stateButtonTool8.InstanceProps.AppearancesSmall.Appearance = appearance7;
            stateButtonTool8.InstanceProps.ButtonGroup = "TextAlign";
            appearance8.Image = 2;
            stateButtonTool9.InstanceProps.AppearancesSmall.Appearance = appearance8;
            stateButtonTool9.InstanceProps.ButtonGroup = "TextAlign";
            stateButtonTool10.InstanceProps.ButtonGroup = "TextAlign";
            ribbonGroup1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            stateButtonTool4,
            stateButtonTool5,
            stateButtonTool6,
            buttonTool2,
            stateButtonTool7,
            stateButtonTool8,
            stateButtonTool9,
            stateButtonTool10});
            ribbonGroup2.Caption = "Font";
            ribbonGroup2.LayoutDirection = Infragistics.Win.UltraWinToolbars.RibbonGroupToolLayoutDirection.Horizontal;
            fontListTool1.InstanceProps.ButtonGroup = "FontCombo";
            fontListTool1.InstanceProps.IsFirstInGroup = true;
            fontListTool1.InstanceProps.Width = 128;
            comboBoxTool1.InstanceProps.Width = 55;
            popupColorPickerTool1.InstanceProps.ButtonGroup = "Colors";
            popupColorPickerTool1.InstanceProps.IsFirstInGroup = true;
            popupColorPickerTool2.InstanceProps.ButtonGroup = "Colors";
            ribbonGroup2.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            fontListTool1,
            comboBoxTool1,
            popupColorPickerTool1,
            popupColorPickerTool2});
            ribbonGroup3.Caption = "Presets";
            ribbonGroup3.PreferredToolSize = Infragistics.Win.UltraWinToolbars.RibbonToolSize.Large;
            ribbonGroup3.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupGalleryTool1});
            ribbonGroup4.Caption = "Save Note";
            ribbonGroup4.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool22});
            ribbonGroup5.Caption = "Patient Info";
            ribbonGroup5.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            textBoxTool1,
            textBoxTool3,
            textBoxTool4});
            ribbonTab1.Groups.AddRange(new Infragistics.Win.UltraWinToolbars.RibbonGroup[] {
            ribbonGroup1,
            ribbonGroup2,
            ribbonGroup3,
            ribbonGroup4,
            ribbonGroup5});
            ribbonTab1.KeyTip = "F";
            ribbonGroup6.Caption = "Images";
            buttonTool3.InstanceProps.MinimumSizeOnRibbon = Infragistics.Win.UltraWinToolbars.RibbonToolSize.Large;
            buttonTool3.InstanceProps.PreferredSizeOnRibbon = Infragistics.Win.UltraWinToolbars.RibbonToolSize.Large;
            ribbonGroup6.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool3});
            ribbonGroup7.Caption = "Clipboard";
            buttonTool4.InstanceProps.PreferredSizeOnRibbon = Infragistics.Win.UltraWinToolbars.RibbonToolSize.Large;
            ribbonGroup7.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool4});
            ribbonGroup8.Caption = "Links";
            buttonTool5.InstanceProps.PreferredSizeOnRibbon = Infragistics.Win.UltraWinToolbars.RibbonToolSize.Large;
            ribbonGroup8.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool5});
            ribbonTab2.Groups.AddRange(new Infragistics.Win.UltraWinToolbars.RibbonGroup[] {
            ribbonGroup6,
            ribbonGroup7,
            ribbonGroup8});
            ribbonTab2.KeyTip = "I";
            ribbonTab3.ContextualTabGroupKey = "Text";
            ribbonGroup9.Caption = "Font Dialog";
            buttonTool6.InstanceProps.MinimumSizeOnRibbon = Infragistics.Win.UltraWinToolbars.RibbonToolSize.ImageOnly;
            buttonTool6.InstanceProps.PreferredSizeOnRibbon = Infragistics.Win.UltraWinToolbars.RibbonToolSize.Large;
            ribbonGroup9.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool6});
            ribbonTab3.Groups.AddRange(new Infragistics.Win.UltraWinToolbars.RibbonGroup[] {
            ribbonGroup9});
            ribbonTab3.KeyTip = "TT";
            ribbonGroup10.Caption = "Spelling";
            appearance9.Image = ((object)(resources.GetObject("appearance9.Image")));
            buttonTool7.InstanceProps.AppearancesLarge.Appearance = appearance9;
            buttonTool7.InstanceProps.PreferredSizeOnRibbon = Infragistics.Win.UltraWinToolbars.RibbonToolSize.Large;
            ribbonGroup10.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool7});
            ribbonTab4.Groups.AddRange(new Infragistics.Win.UltraWinToolbars.RibbonGroup[] {
            ribbonGroup10});
            ribbonTab4.KeyTip = "T";
            ribbonTab5.ContextualTabGroupKey = "Spelling";
            ribbonGroup11.Caption = "Spelling";
            buttonTool8.InstanceProps.PreferredSizeOnRibbon = Infragistics.Win.UltraWinToolbars.RibbonToolSize.Large;
            ribbonGroup11.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool8});
            ribbonTab5.Groups.AddRange(new Infragistics.Win.UltraWinToolbars.RibbonGroup[] {
            ribbonGroup11});
            this.ultraToolbarsManager1.Ribbon.NonInheritedRibbonTabs.AddRange(new Infragistics.Win.UltraWinToolbars.RibbonTab[] {
            ribbonTab1,
            ribbonTab2,
            ribbonTab3,
            ribbonTab4,
            ribbonTab5});
            buttonTool9.InstanceProps.MinimumSizeOnRibbon = Infragistics.Win.UltraWinToolbars.RibbonToolSize.Large;
            buttonTool9.InstanceProps.PreferredSizeOnRibbon = Infragistics.Win.UltraWinToolbars.RibbonToolSize.Large;
            this.ultraToolbarsManager1.Ribbon.QuickAccessToolbar.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool9});
            this.ultraToolbarsManager1.Ribbon.TabItemToolbar.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool10});
            this.ultraToolbarsManager1.Ribbon.Visible = true;
            this.ultraToolbarsManager1.ShowFullMenusDelay = 500;
            this.ultraToolbarsManager1.ShowMenuShadows = Infragistics.Win.DefaultableBoolean.False;
            fontListTool2.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            popupColorPickerTool3.SelectedColor = System.Drawing.Color.Red;
            appearance10.Image = 41;
            popupColorPickerTool3.SharedProps.AppearancesSmall.Appearance = appearance10;
            appearance11.Image = 3;
            stateButtonTool15.SharedProps.AppearancesSmall.Appearance = appearance11;
            appearance12.Image = 5;
            stateButtonTool16.SharedProps.AppearancesSmall.Appearance = appearance12;
            appearance13.Image = 4;
            stateButtonTool17.SharedProps.AppearancesSmall.Appearance = appearance13;
            valueListItem1.DataValue = "10pt";
            valueListItem1.DisplayText = "10pt";
            valueListItem2.DataValue = "11pt";
            valueListItem2.DisplayText = "11pt";
            valueListItem3.DataValue = "12pt";
            valueListItem3.DisplayText = "12pt";
            valueListItem4.DataValue = "13pt";
            valueListItem4.DisplayText = "13pt";
            valueListItem5.DataValue = "14pt";
            valueListItem5.DisplayText = "14pt";
            valueListItem6.DataValue = "15pt";
            valueListItem6.DisplayText = "15pt";
            valueListItem7.DataValue = "16pt";
            valueListItem7.DisplayText = "16pt";
            valueListItem8.DataValue = "17pt";
            valueListItem8.DisplayText = "17pt";
            valueListItem9.DataValue = "18pt";
            valueListItem9.DisplayText = "18pt";
            valueList1.ValueListItems.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2,
            valueListItem3,
            valueListItem4,
            valueListItem5,
            valueListItem6,
            valueListItem7,
            valueListItem8,
            valueListItem9});
            comboBoxTool2.ValueList = valueList1;
            appearance14.Image = ((object)(resources.GetObject("appearance14.Image")));
            buttonTool11.SharedProps.AppearancesLarge.Appearance = appearance14;
            buttonTool11.SharedProps.Caption = "Picture";
            appearance15.Image = ((object)(resources.GetObject("appearance15.Image")));
            buttonTool12.SharedProps.AppearancesLarge.Appearance = appearance15;
            appearance16.Image = 14;
            buttonTool12.SharedProps.AppearancesSmall.Appearance = appearance16;
            buttonTool12.SharedProps.Caption = "Paste";
            labelTool2.SharedProps.Caption = "Color Scheme";
            listToolItem1.Key = "Black";
            listToolItem1.Text = "Black";
            listToolItem2.Key = "Blue";
            listToolItem2.Text = "Blue";
            listToolItem3.Key = "Silver";
            listToolItem3.Text = "Silver";
            listTool2.ListToolItemsInternal.Add(listToolItem1);
            listTool2.ListToolItemsInternal.Add(listToolItem2);
            listTool2.ListToolItemsInternal.Add(listToolItem3);
            stateButtonTool18.Checked = true;
            appearance17.Image = ((object)(resources.GetObject("appearance17.Image")));
            buttonTool13.SharedProps.AppearancesLarge.Appearance = appearance17;
            buttonTool13.SharedProps.Caption = "Show";
            appearance18.Image = ((object)(resources.GetObject("appearance18.Image")));
            galleryToolItem1.Settings.Appearance = appearance18;
            galleryToolItem1.Tag = "color:Black; font-family:Arial; font-weight:normal; font-size:12pt;";
            galleryToolItem1.ToolTipText = "Normal";
            appearance19.Image = ((object)(resources.GetObject("appearance19.Image")));
            galleryToolItem2.Settings.Appearance = appearance19;
            galleryToolItem2.Tag = "color:#025fa4; font-family:Arial;  font-weight:bold; font-size:18pt;";
            galleryToolItem2.ToolTipText = "Heading 1";
            appearance20.Image = ((object)(resources.GetObject("appearance20.Image")));
            galleryToolItem3.Settings.Appearance = appearance20;
            galleryToolItem3.Tag = "color:Maroon; font-family:Arial; font-weight:bold; text-decoration:underline; fon" +
                "t-size:16pt;";
            galleryToolItem3.ToolTipText = "Heading 2";
            popupGalleryTool2.ItemsInternal.AddRange(new Infragistics.Win.UltraWinToolbars.GalleryToolItem[] {
            galleryToolItem1,
            galleryToolItem2,
            galleryToolItem3});
            popupGalleryTool2.ItemStyle = Infragistics.Win.UltraWinToolbars.ItemStyle.StateButton;
            popupGalleryTool2.PreferredDropDownColumns = 2;
            popupGalleryTool2.SharedProps.Caption = "Presets";
            buttonTool14.SharedProps.Caption = "Check Selection";
            appearance21.Image = ((object)(resources.GetObject("appearance21.Image")));
            buttonTool15.SharedProps.AppearancesSmall.Appearance = appearance21;
            buttonTool15.SharedProps.Caption = "Check Document";
            buttonTool16.SharedProps.Caption = "Show";
            popupColorPickerTool4.DropDownArrowStyle = Infragistics.Win.UltraWinToolbars.DropDownArrowStyle.SegmentedStateButton;
            popupColorPickerTool4.ReplaceableColor = System.Drawing.Color.Yellow;
            popupColorPickerTool4.SelectedColor = System.Drawing.Color.Yellow;
            appearance22.Image = ((object)(resources.GetObject("appearance22.Image")));
            popupColorPickerTool4.SharedProps.AppearancesSmall.Appearance = appearance22;
            appearance23.Image = 42;
            stateButtonTool21.SharedProps.AppearancesSmall.Appearance = appearance23;
            appearance24.Image = ((object)(resources.GetObject("appearance24.Image")));
            buttonTool17.SharedProps.AppearancesSmall.Appearance = appearance24;
            appearance25.Image = ((object)(resources.GetObject("appearance25.Image")));
            buttonTool18.SharedProps.AppearancesLarge.Appearance = appearance25;
            buttonTool18.SharedProps.Caption = "Hyperlink";
            appearance26.Image = ((object)(resources.GetObject("appearance26.Image")));
            buttonTool19.SharedProps.AppearancesLarge.Appearance = appearance26;
            appearance27.Image = ((object)(resources.GetObject("appearance27.Image")));
            buttonTool19.SharedProps.AppearancesSmall.Appearance = appearance27;
            buttonTool19.SharedProps.Caption = "AutoCorrect";
            buttonTool19.SharedProps.ToolTipText = "Replace misspelled word at cursor position";
            appearance28.Image = ((object)(resources.GetObject("appearance28.Image")));
            buttonTool20.SharedProps.AppearancesLarge.Appearance = appearance28;
            buttonTool20.SharedProps.Caption = "Exit";
            buttonTool20.SharedProps.DescriptionOnMenu = "Close the application.";
            appearance29.Image = 39;
            buttonTool21.SharedProps.AppearancesSmall.Appearance = appearance29;
            buttonTool21.SharedProps.Caption = "ButtonTool1";
            stateButtonTool22.Checked = true;
            stateButtonTool22.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark;
            stateButtonTool22.SharedProps.Caption = "Enable MiniToolbar on ContextMenu";
            stateButtonTool22.ToolbarDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonToolbarDisplayStyle.Glyph;
            stateButtonTool23.Checked = true;
            stateButtonTool23.OptionSetKey = "TreatValueAs";
            stateButtonTool23.SharedProps.Caption = "FormattedText";
            stateButtonTool23.ToolbarDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonToolbarDisplayStyle.Glyph;
            stateButtonTool24.OptionSetKey = "TreatValueAs";
            stateButtonTool24.SharedProps.Caption = "Auto";
            stateButtonTool24.ToolbarDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonToolbarDisplayStyle.Glyph;
            stateButtonTool25.OptionSetKey = "TreatValueAs";
            stateButtonTool25.SharedProps.Caption = "URL";
            stateButtonTool25.ToolbarDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonToolbarDisplayStyle.Glyph;
            appearance43.Image = 17;
            buttonTool23.SharedProps.AppearancesSmall.Appearance = appearance43;
            buttonTool23.SharedProps.Caption = "Save Note";
            labelTool4.SharedProps.Caption = "HN";
            textBoxTool2.SharedProps.Caption = "     HN";
            textBoxTool2.SharedProps.Enabled = false;
            textBoxTool2.SharedProps.Width = 160;
            textBoxTool5.SharedProps.Caption = "Name";
            textBoxTool5.SharedProps.Enabled = false;
            textBoxTool5.SharedProps.Width = 160;
            textBoxTool6.SharedProps.Caption = " Exam";
            textBoxTool6.SharedProps.Enabled = false;
            textBoxTool6.SharedProps.Width = 160;
            this.ultraToolbarsManager1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            fontListTool2,
            popupColorPickerTool3,
            stateButtonTool15,
            stateButtonTool16,
            stateButtonTool17,
            comboBoxTool2,
            buttonTool11,
            buttonTool12,
            labelTool2,
            listTool2,
            stateButtonTool18,
            stateButtonTool19,
            stateButtonTool20,
            buttonTool13,
            popupGalleryTool2,
            buttonTool14,
            buttonTool15,
            buttonTool16,
            popupColorPickerTool4,
            stateButtonTool21,
            buttonTool17,
            buttonTool18,
            buttonTool19,
            buttonTool20,
            buttonTool21,
            stateButtonTool22,
            stateButtonTool23,
            stateButtonTool24,
            stateButtonTool25,
            buttonTool23,
            labelTool4,
            textBoxTool2,
            textBoxTool5,
            textBoxTool6});
            this.ultraToolbarsManager1.ToolValueChanged += new Infragistics.Win.UltraWinToolbars.ToolEventHandler(this.ultraToolbarsManager1_ToolValueChanged);
            this.ultraToolbarsManager1.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.ultraToolbarsManager1_ToolClick);
            this.ultraToolbarsManager1.GalleryToolActiveItemChange += new Infragistics.Win.UltraWinToolbars.GalleryToolItemEventHandler(this.ultraToolbarsManager1_GalleryToolActiveItemChange);
            this.ultraToolbarsManager1.GalleryToolItemClick += new Infragistics.Win.UltraWinToolbars.GalleryToolItemEventHandler(this.ultraToolbarsManager1_GalleryToolItemClick);
            // 
            // _Form1_Toolbars_Dock_Area_Left
            // 
            this._Form1_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._Form1_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._Form1_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._Form1_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Form1_Toolbars_Dock_Area_Left.InitialResizeAreaExtent = 4;
            this._Form1_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 181);
            this._Form1_Toolbars_Dock_Area_Left.Name = "_Form1_Toolbars_Dock_Area_Left";
            this._Form1_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(4, 351);
            this._Form1_Toolbars_Dock_Area_Left.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _Form1_Toolbars_Dock_Area_Top
            // 
            this._Form1_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._Form1_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._Form1_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._Form1_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Form1_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._Form1_Toolbars_Dock_Area_Top.Name = "_Form1_Toolbars_Dock_Area_Top";
            this._Form1_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(773, 181);
            this._Form1_Toolbars_Dock_Area_Top.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _Form1_Toolbars_Dock_Area_Bottom
            // 
            this._Form1_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._Form1_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._Form1_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._Form1_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Form1_Toolbars_Dock_Area_Bottom.InitialResizeAreaExtent = 4;
            this._Form1_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 532);
            this._Form1_Toolbars_Dock_Area_Bottom.Name = "_Form1_Toolbars_Dock_Area_Bottom";
            this._Form1_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(773, 4);
            this._Form1_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // Addendum
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(773, 536);
            this.Controls.Add(this.Form1_Fill_Panel);
            this.Controls.Add(this._Form1_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._Form1_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._Form1_Toolbars_Dock_Area_Top);
            this.Controls.Add(this._Form1_Toolbars_Dock_Area_Bottom);
            this.Name = "Addendum";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Addendum";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Form1_Fill_Panel.ResumeLayout(false);
            this.Form1_Fill_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraSpellChecker1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		
	}
}
