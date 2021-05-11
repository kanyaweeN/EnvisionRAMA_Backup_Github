using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
//using WPFControl2;
//using EnvisionBreastControl.Lib;
using EnvisionBreastControl;
using EnvisionBreastControl.Lib;
using Envision.BusinessLogic.ProcessRead;
using Envision.NET.Mammogram.ResultEntry.BIRAD.Popup;
using Envision.NET.Mammogram.ResultEntry.BIRAD.Common;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.BusinessLogic.ProcessCreate;
using Envision.BusinessLogic.ProcessUpdate;
using Envision.BusinessLogic.ProcessDelete;
using Envision.NET.Mammogram.ResultEntry.BIRAD.Helper;
using Envision.NET.Mammogram.StructureReport;
using DevExpress.XtraRichEdit.API.Native;
using Envision.NET.Forms.Dialog;
using Miracle.RtfDocumentBuilder;

namespace Envision.NET.Forms.ResultEntry
{
    public partial class BiradStructureReport : Envision.NET.Forms.Main.MasterForm
    {
        private const string  TEMP_PART_1 = @"D:\bl.png";
        private const string TEMP_PART_2 = @"D:\br.png";
        private BreastControl breastControl_Left;
        private BreastControl breastControl_Right;
        private popupProperties _popupProperties;
        private BiradGenerateTextViewer viwer;
        private BiradDominantCystList dominantCystList;
        private DataSet dsDemographic;
        private DataSet dsExamResultHistory;
        private DataSet dsDominantList;
        private DataTable dtRadiologistGroup;
        private DataTable dtMergeData;
        private DataTable dtSendToPascAccession;
        private DataRow drCaseData;
        private int regId;
        private int empId = 7640;
        private int language = 2;
        private int orgId = 1;
        private GBLEnvVariable env;
        private List<MarkStruct> markerList;
        private List<MarkStruct> markerRemoverList;
        private MarkStruct current_markStruct;
        private MG_BREASTMASSDETAILS current_mass_detail;
        private MG_BREASTUSMASSDETAILS current_mass_us_detail;
        private MyMessageBox myMessageBox;
        private CProperties _properties;
        private CShapeControl _selectedShapeControl;
        private int current_marker_index = 0;
        private int current_marker_count = 0;
        public string accession = string.Empty; //"20090623MG0012"
        private string exam_code = string.Empty;
        private string exam_name = string.Empty;
        private Envision.BusinessLogic.ResultEntry resultEntry;
        private bool IsLoading = false;
        private bool _IsReadOnly = false;
        private int _radfinalizeId = 0;
        private bool IsReadOnly
        {
            get { return _IsReadOnly; }
            set 
            {
                _IsReadOnly = value;
                this.SetReadOnlyForm();
            }
        }

        #region Ctr
        /// <summary>
        /// Constructor with accession no
        /// </summary>
        /// <param name="AccessionNo">accession number</param>
        public BiradStructureReport(string AccessionNo)
        {
            InitializeComponent();
            this.accession = AccessionNo;
            this.InitializeForm();
        }

        /// <summary>
        /// Constructor with data row 
        /// </summary>
        /// <param name="drDataFromWorkList">data row form double click radiologist worklist</param>
        public BiradStructureReport(DataRow drDataFromWorkList)
        {
            InitializeComponent();
            this.drCaseData = drDataFromWorkList;
            this.accession = this.drCaseData["ACCESSION_NO"].ToString();
            this.InitializeForm();
        }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public BiradStructureReport()
            : this("20090623MG0012") { }

        /// <summary>
        /// This method use to initialize form
        /// </summary>
        private void InitializeForm()
        {
            this.myMessageBox = new MyMessageBox();
            this.env = new GBLEnvVariable();
            this.empId = env.UserID;
            this.orgId = env.OrgID;
            this.language = env.CurrentLanguageID;
            this.markerList = new List<MarkStruct>();
            this.resultEntry = new Envision.BusinessLogic.ResultEntry();
            this.markerRemoverList = new List<MarkStruct>();
            this.breastControl_Left = new BreastControl();
            this.breastControl_Right = new BreastControl();
            this.dominantCystList = new BiradDominantCystList();
            this._popupProperties = new popupProperties(empId, language);
            this.breastControl_Left.RelativeTo = this.breastControl_Right;
            this.breastControl_Left.View = BreastControl.Views.Left;
            this.breastControl_Right.View = BreastControl.Views.Right;
            this.Load += new EventHandler(BiradForm1_Load);
            this.elementHost1.Child = this.breastControl_Left;
            this.elementHost2.Child = this.breastControl_Right;
            this.btnMark.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(btnMark_ItemClick);
            this.btnSelect.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(btnSelect_ItemClick);
            this.btnProperties.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(btnProperties_ItemClick);
            this.RadiologistUserGallery.Gallery.ItemClick += RadiologistUserGalleryItemClick;
            this.breastControl_Left.OnAddItemCompleted += new BreastControl.onAddItemCompleted(breastControl_OnAddItemCompleted);
            this.breastControl_Right.OnAddItemCompleted += new BreastControl.onAddItemCompleted(breastControl_OnAddItemCompleted);
            this.breastControl_Left.OnMenuContextSelected += new BreastControl.onMenuContextSelected(breastControl_OnMenuContextSelected);
            this.breastControl_Right.OnMenuContextSelected += new BreastControl.onMenuContextSelected(breastControl_OnMenuContextSelected);
            this.breastControl_Left.OnSelectedItemChanged += new BreastControl.onSelectedItemChanged(breastControl_OnSelectedItemChanged);
            this.breastControl_Right.OnSelectedItemChanged += new BreastControl.onSelectedItemChanged(breastControl_OnSelectedItemChanged);
            this.breastControl_Left.OnRemoveItemCompleted += new BreastControl.onRemoveItemCompleted(breastControl_OnRemoveItemCompleted);
            this.breastControl_Right.OnRemoveItemCompleted += new BreastControl.onRemoveItemCompleted(breastControl_OnRemoveItemCompleted);

            this.btnBack.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(btnBack_ItemClick);
            this.btnNext.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(btnNext_ItemClick);
            this.btnFixSize.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(btnFixSize_ItemClick);
            this.ShapeGallery.GalleryItemClick += new DevExpress.XtraBars.Ribbon.GalleryItemClickEventHandler(ShapeGallery_GalleryItemClick);
            this.ShapeUSGallery.GalleryItemClick += new DevExpress.XtraBars.Ribbon.GalleryItemClickEventHandler(ShapeGallery_GalleryItemClick);
            this.btnDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(btnDelete_ItemClick);
            this.btnClear.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(btnClear_ItemClick);
            this.contextmenuToPanel.ItemClicked += new ToolStripItemClickedEventHandler(contextmenuToPanel_ItemClicked);

            //Compare Grid click
            this.gridCompareView.DoubleClick += new EventHandler(gridCompareView_DoubleClick);
            //Panel Click
            this.pnArchitecturalDistortion.Click += new EventHandler(pnArchitecturalDistortion_Click);
            this.pnAssociateFinding.Click += new EventHandler(pnAssociateFinding_Click);
            this.pnCalcification.Click += new EventHandler(pnCalcification_Click);
            this.Find_scFinding.Click += new EventHandler(Find_pnFinding_Click);
            this.panelContFind_pnFindingrol2.Click += new EventHandler(panelContFind_pnFindingrol2_Click);
            this.pnSignificateFinding.Click += new EventHandler(pnSignificateFinding_Click);
            this.Sign_pnForUSDtl.Click += new EventHandler(pnSignificateFinding_Click);
            //this.pnSpecialCase.Click += new EventHandler(pnSpecialCase_Click);

            //Close form
            this.btnClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(btnClose_ItemClick);
            this.rdConpareType.SelectedIndexChanged += new EventHandler(rdConpareType_SelectedIndexChanged);

            //Editer
            this.Find_cbPatient_Type.SelectedIndexChanged += new EventHandler(Find_cbPatient_Type_SelectedIndexChanged);
            this.cal_chkAmorphous_or_Indistinct_Calcifications.CheckedChanged += new EventHandler(cal_chkAmorphous_or_Indistinct_Calcifications_CheckedChanged);
            this.cal_chkCoarse_Heterogeneous_Calcifications.CheckedChanged += new EventHandler(cal_chkCoarse_Heterogeneous_Calcifications_CheckedChanged);
            this.cal_chkCoarse_or_popcorn_like_Calcifications.CheckedChanged += new EventHandler(cal_chkCoarse_or_popcorn_like_Calcifications_CheckedChanged);
            this.cal_chkDiffuse_Scattered.CheckedChanged += new EventHandler(cal_chkDiffuse_Scattered_CheckedChanged);
            this.cal_chkDystrophic_Calcifications.CheckedChanged += new EventHandler(cal_chkDystrophic_Calcifications_CheckedChanged);
            this.cal_chkEggshell_or_Rim_Calcifications.CheckedChanged += new EventHandler(cal_chkEggshell_or_Rim_Calcifications_CheckedChanged);
            this.cal_chkFine_Linear_or_Fine_linear_Branching_Calcifications.CheckedChanged += new EventHandler(cal_chkFine_Linear_or_Fine_linear_Branching_Calcifications_CheckedChanged);
            this.cal_chkFine_Pleomorphic_Calcification.CheckedChanged += new EventHandler(cal_chkFine_Pleomorphic_Calcification_CheckedChanged);
            this.cal_chkGrouped_Clustered.CheckedChanged += new EventHandler(cal_chkGrouped_Clustered_CheckedChanged);
            this.cal_chkLarge_rod_like_Calcifications.CheckedChanged += new EventHandler(cal_chkLarge_rod_like_Calcifications_CheckedChanged);
            this.cal_chkLinear.CheckedChanged += new EventHandler(cal_chkLinear_CheckedChanged);
            this.cal_chkLucent_centered_Calcifications.CheckedChanged += new EventHandler(cal_chkLucent_centered_Calcifications_CheckedChanged);
            this.cal_chkMilk_of_Calcium_Calcifications.CheckedChanged += new EventHandler(cal_chkMilk_of_Calcium_Calcifications_CheckedChanged);
            this.cal_chkRegional.CheckedChanged += new EventHandler(cal_chkRegional_CheckedChanged);
            this.cal_chkRound_Calcifications.CheckedChanged += new EventHandler(cal_chkRound_Calcifications_CheckedChanged);
            this.cal_chkSegmental.CheckedChanged += new EventHandler(cal_chkSegmental_CheckedChanged);
            this.cal_chkSkin_Calcifications.CheckedChanged += new EventHandler(cal_chkSkin_Calcifications_CheckedChanged);
            this.cal_chkSuture_Calcifications.CheckedChanged += new EventHandler(cal_chkSuture_Calcifications_CheckedChanged);
            this.cal_chkVascular_Calcifications.CheckedChanged += new EventHandler(cal_chkVascular_Calcifications_CheckedChanged);
            this.cal_rdCalObjType.EditValueChanged += new EventHandler(cal_rdCalObjType_EditValueChanged);
            this.cal_tbNumberOfCalcificationObject.TextChanged += new EventHandler(cal_tbNumberOfCalcificationObject_TextChanged);
            this.Arch_rbObject_Type.EditValueChanged += new EventHandler(Arch_rbObject_Type_EditValueChanged);
            this.Arch_rdArchitectural_Distortion_Type.EditValueChanged += new EventHandler(Arch_rdArchitectural_Distortion_Type_EditValueChanged);
            this.Arch_tbNumber_of_architectural_Distortion_objects.TextChanged += new EventHandler(Arch_tbNumber_of_architectural_Distortion_objects_TextChanged);
            this.Asso_rdFinding_Type.EditValueChanged += new EventHandler(Asso_rdFinding_Type_EditValueChanged);
            this.Sign_rbMagin.EditValueChanged += new EventHandler(Sign_rbMagin_EditValueChanged);
            this.Sign_rdDensity.EditValueChanged += new EventHandler(Sign_rdDensity_EditValueChanged);
            this.Sign_rbShape.EditValueChanged += new EventHandler(Sign_rbShape_EditValueChanged);
            this.Sign_cbFindingType.SelectedIndexChanged += new EventHandler(Sign_cbFindingType_SelectedIndexChanged);
            this.Sign_rbWith_Calcification.EditValueChanged += new EventHandler(Sign_rbWith_Calcification_EditValueChanged);
            this.repositoryItemCheckEdit1.Click += new EventHandler(repositoryItemCheckEdit1_Click);

            this.btnSaveDraft.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(btnSaveDraft_ItemClick);
            this.btnSaveFinalize.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(btnSaveFinalize_ItemClick);
            this.btnSavePrelim.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(btnSavePrelim_ItemClick);
            this.btnViewReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(btnViewReport_ItemClick);

            this.Sign_rdMassViewType.EditValueChanged += new EventHandler(Sign_rdMassViewType_EditValueChanged);
            this.Finding_rdPersonal_History_of_breast_cancer.EditValueChanged += new EventHandler(Finding_rdPersonal_History_of_breast_cancer_EditValueChanged);
            this.Finding_cbRecommendation.SelectedIndexChanged += new EventHandler(Finding_cbRecommendation_SelectedIndexChanged);
            this.Finding_btnDominantCysts.Click += new EventHandler(Finding_btnDominantCysts_Click);
            //this.multiChk_mass.CheckedChanged += new EventHandler(multiChk_Mass_CheckedChanged);
            //this.multiChk_Cyst.CheckedChanged += new EventHandler(multiChk_Cyst_CheckedChanged);
            this.multiChk_Cyst.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(multiChk_Cyst_EditValueChanging);
            this.multiChk_mass.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(multiChk_mass_EditValueChanging);

            this.Finding_btnDominantCysts.Enabled = false;
            //this.Finding_cbFinalassessment.SelectedIndexChanged += new EventHandler(Finding_cbFinalassessment_SelectedIndexChanged);
            //US Mass
            this.US_rdEchoPattern.EditValueChanged += new EventHandler(US_rdEchoPattern_EditValueChanged);
            this.US_rdLesionBoundary.EditValueChanged += new EventHandler(US_rdLesionBoundary_EditValueChanged);
            this.US_rdMargin.EditValueChanged += new EventHandler(US_rdMargin_EditValueChanged);
            this.US_rdMassType.EditValueChanged += new EventHandler(US_rdMassType_EditValueChanged);
            this.US_rdOrientationOfMass.EditValueChanged += new EventHandler(US_rdOrientationOfMass_EditValueChanged);
            this.US_rdPosteriorAcousticFeatures.EditValueChanged += new EventHandler(US_rdPosteriorAcousticFeatures_EditValueChanged);

            this.memoSummary.GotFocus += new EventHandler(memoSummary_GotFocus);
            this.memoSummary.LostFocus += new EventHandler(memoSummary_LostFocus);

            this.btnAddUser.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(btnAddUser_ItemClick);
            //Mark size (W&L)
            this.MG_tbSizeX.TextChanged += new EventHandler(MG_tbSizeX_TextChanged);
            this.MG_tbSizeY.TextChanged += new EventHandler(MG_tbSizeY_TextChanged);
            this.US_tbSizeX.TextChanged += new EventHandler(US_tbSizeX_TextChanged);
            this.US_tbSizeY.TextChanged += new EventHandler(US_tbSizeY_TextChanged);
            this.MG_tbSizeZ.TextChanged += new EventHandler(MG_tbSizeZ_TextChanged);
            this.US_tbSizeZ.TextChanged += new EventHandler(US_tbSizeZ_TextChanged);
            this.tbAssociate_freeText.Properties.ReadOnly = true;
            this.tbAssociate_freeText.TextChanged += new EventHandler(tbAssociate_freeText_TextChanged);
            this.Finding_cbFinalassessment.SelectedIndexChanged += new EventHandler(Finding_cbFinalassessment_SelectedIndexChanged);
        }

        private void tbAssociate_freeText_TextChanged(object sender, EventArgs e)
        {
            if(this.current_mass_detail != null)
                this.current_mass_detail.ASSOCIATE_FINDING_TYPE_TEXT = tbAssociate_freeText.Text;
            if(this.current_mass_us_detail != null)
                this.current_mass_us_detail.ASSOCIATE_FINDING_TYPE_TEXT = tbAssociate_freeText.Text;

        }

        #region Mark size Textchanged
        private void US_tbSizeY_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.US_tbSizeY.Text))
                this.current_mass_us_detail.SIZE_Y = Convert.ToInt32(this.US_tbSizeY.Text);
        }

        private void US_tbSizeX_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.US_tbSizeX.Text))
            {
                (this.current_markStruct.MarkObject as CShapeControl).Diameter = Convert.ToInt32(this.US_tbSizeX.Text);
                this.current_mass_us_detail.SIZE_X = Convert.ToInt32(this.US_tbSizeX.Text);
            }
        }

        private void MG_tbSizeY_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.MG_tbSizeY.Text))
                this.current_mass_detail.SIZE_Y = Convert.ToInt32(this.MG_tbSizeY.Text);
        }

        private void MG_tbSizeX_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.MG_tbSizeX.Text))
            {
                (this.current_markStruct.MarkObject as CShapeControl).Diameter = Convert.ToInt32(this.MG_tbSizeX.Text);
                this.current_mass_detail.SIZE_X = Convert.ToInt32(this.MG_tbSizeX.Text);
            }
        }

        private void US_tbSizeZ_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.US_tbSizeZ.Text))
                this.current_mass_us_detail.SIZE_Z = Convert.ToInt32(this.US_tbSizeZ.Text);
        }

        private void MG_tbSizeZ_TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(this.MG_tbSizeZ.Text))
                this.current_mass_detail.SIZE_Z = Convert.ToInt32(this.MG_tbSizeZ.Text);
        }
        #endregion

        #region Rich Editer
        /// <summary>
        /// Lost focus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void memoSummary_LostFocus(object sender, EventArgs e)
        {
            this.ribbonControl1.SelectedPage = this.ribbonPage1;
        }
        /// <summary>
        /// Got Focus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void memoSummary_GotFocus(object sender, EventArgs e)
        {
            this.ribbonControl1.SelectedPage = this.homeRibbonPage1;
        }
        #endregion

        #endregion

        #region Grid Event
        private void repositoryItemCheckEdit1_Click(object sender, EventArgs e)
        {
            this.SelectRow();
        }

        private void SelectRow()
        {
            if (this.gridCompareView.FocusedRowHandle >= 0)
            {
                DataRow dr = this.gridCompareView.GetDataRow(this.gridCompareView.FocusedRowHandle);
                if (dr["SELECT"].ToString() == "Y")
                    dr["SELECT"] = "N";
                else
                    dr["SELECT"] = "Y";
            }
        }

        /// <summary>
        /// double Click Grid view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridCompareView_DoubleClick(object sender, EventArgs e)
        {
            this.SelectRow();
        }
        #endregion

        #region Save Event
        /// <summary>
        /// Save Prelim
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSavePrelim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.SaveStructuredResult("P");
            this.SaveRadiologistGroup();
            this.SaveResultEntry("P");
            //this.SendToPasc();
        }

        /// <summary>
        /// Save Finalize
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveFinalize_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this._radfinalizeId = this.GetRadiologistFinalizedId();
            if (this._radfinalizeId != 0)
            {
                this.SaveStructuredResult("F");
                this.SaveRadiologistGroup();
                this.SaveResultEntry("F");
                //this.SendToPasc();
            }
        }

        /// <summary>
        /// Save Draft
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveDraft_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.SaveStructuredResult("D");
            this.SaveRadiologistGroup();
            this.SaveResultEntry("D");
        }

        /// <summary>
        /// This method use to send to pasc with accession no
        /// </summary>
        private void SendToPasc()
        {
            if (this.dtSendToPascAccession != null)
            {
                if (this.dtSendToPascAccession.Rows.Count > 0)
                {
                    Envision.Operational.PACS.SendToPacs pacs = new Envision.Operational.PACS.SendToPacs();
                    foreach (DataRow row in this.dtSendToPascAccession.Rows)
                    {
                        pacs.Set_ORUByAccessionNoQueue(row["ACCESSION_NO"].ToString().Trim());
                    }
                    this.dtSendToPascAccession = null; //Clear memory
                }
            }
        }

        /// <summary>
        /// This method use to save radiologist group
        /// </summary>
        private void SaveRadiologistGroup()
        {
            ProcessGetRISExamresultrads processGetRISExamResultRads = new ProcessGetRISExamresultrads();

            //Get Lastest saved from database
            processGetRISExamResultRads.RIS_EXAMRESULTRADS.ACCESSION_NO = this.accession;
            processGetRISExamResultRads.RIS_EXAMRESULTRADS.ORG_ID = this.orgId;
            processGetRISExamResultRads.Invoke();
            DataTable dtGetExamResultRads = processGetRISExamResultRads.Result.Tables[0];

            //Check Row, it have last saved or not
            if (dtGetExamResultRads.Rows.Count > 0)
            {
                this.DeleteGroup();
                this.InsertGroup();
            }
            else
            {
                this.InsertGroup();
            }
        }

        /// <summary>
        /// This method use to clear all old group from database
        /// </summary>
        private void DeleteGroup()
        {
            ProcessDeleteRISExamresultrads processDeleteRISExamResultRads = new ProcessDeleteRISExamresultrads();
            //Delete all last saved
            processDeleteRISExamResultRads.RIS_EXAMRESULTRADS.ACCESSION_NO = this.accession;
            processDeleteRISExamResultRads.RIS_EXAMRESULTRADS.MODE = "Clear";
            processDeleteRISExamResultRads.Invoke();
            //Delete with merger exam
            if (this.dtMergeData != null)
            {
                //Delete all to merger exam
                foreach (DataRow dr in this.dtMergeData.Rows)
                {
                    if (dr["ACCESSION_NO"].ToString() != this.accession)
                    {
                        processDeleteRISExamResultRads.RIS_EXAMRESULTRADS.ACCESSION_NO = dr["ACCESSION_NO"].ToString();
                        processDeleteRISExamResultRads.RIS_EXAMRESULTRADS.MODE = "Clear";
                        processDeleteRISExamResultRads.Invoke();
                    }
                }
            }
            processDeleteRISExamResultRads = null; //Clear memmory
        }

        /// <summary>
        /// This method use to insert new group to database
        /// </summary>
        private void InsertGroup()
        {
            if (this.dtRadiologistGroup.Rows.Count < 0)
                return;

            ProcessAddRISExamresultrads processAddRISExamResultRads = new ProcessAddRISExamresultrads();

            //Insert New Data from new datatable (from radiologist gallery)
            foreach (DataRow dr in this.dtRadiologistGroup.Rows)
            {
                processAddRISExamResultRads.RIS_EXAMRESULTRADS.ACCESSION_NO = this.accession;
                processAddRISExamResultRads.RIS_EXAMRESULTRADS.SL_NO = (byte)dr["SL_NO"];
                processAddRISExamResultRads.RIS_EXAMRESULTRADS.RAD_ID = Convert.ToInt32(dr["RAD_ID"]);
                processAddRISExamResultRads.RIS_EXAMRESULTRADS.CAN_PRELIM = Convert.ToBoolean(dr["CAN_PRELIM"]);
                processAddRISExamResultRads.RIS_EXAMRESULTRADS.CAN_FINALIZE = Convert.ToBoolean(dr["CAN_FINALIZE"]);
                processAddRISExamResultRads.RIS_EXAMRESULTRADS.CREATED_BY = env.UserID;
                processAddRISExamResultRads.Invoke();
            }

            //Insert with Merge Data
            if (this.dtMergeData != null)
            {
                foreach (DataRow dr in this.dtMergeData.Rows)
                {
                    if (dr["ACCESSION_NO"].ToString() != this.accession)
                    {
                        foreach (DataRow dr2 in this.dtRadiologistGroup.Rows)
                        {
                            processAddRISExamResultRads.RIS_EXAMRESULTRADS.ACCESSION_NO = dr["ACCESSION_NO"].ToString();
                            processAddRISExamResultRads.RIS_EXAMRESULTRADS.SL_NO = (byte)dr2["SL_NO"];
                            processAddRISExamResultRads.RIS_EXAMRESULTRADS.RAD_ID = Convert.ToInt32(dr2["RAD_ID"]);
                            processAddRISExamResultRads.RIS_EXAMRESULTRADS.CAN_PRELIM = Convert.ToBoolean(dr2["CAN_PRELIM"]);
                            processAddRISExamResultRads.RIS_EXAMRESULTRADS.CAN_FINALIZE = Convert.ToBoolean(dr2["CAN_FINALIZE"]);
                            processAddRISExamResultRads.RIS_EXAMRESULTRADS.CREATED_BY = env.UserID;
                            processAddRISExamResultRads.Invoke();
                        }
                    }
                }//end looping
            }
            processAddRISExamResultRads = null; //Clear memmory
        }

        /// <summary>
        /// This method use to save data into RIS_EXAMRESULT
        /// </summary>
        /// <param name="report_status">Save Status (D, P, F)</param>
        private void SaveResultEntry(string report_status)
        {
            if (this.drCaseData != null)
            {
                int severityId = 0;
                string alertUid = "";
                //Get serverity id when save by prelim or finalize
                if (report_status != "D")
                {
                    severityId = this.ShowSeverityLookUp();
                    if (severityId == 0)//cancel by user
                        return;
                    //create sendToPasc Table
                    this.dtSendToPascAccession = new DataTable();
                    this.dtSendToPascAccession.Columns.Add("ACCESSION_NO", typeof(string));
                    this.dtSendToPascAccession.AcceptChanges();
                }

                alertUid = string.IsNullOrEmpty(this.drCaseData["MERGE"].ToString())
                    ? "UID1129" : this.drCaseData["MERGE"].ToString().ToLower() == "spt" ? "UID1129" : "UID1132";

                string msgresult = "2";
                //Show alert when save prelim or finalize
                if(report_status != "D")
                    msgresult = myMessageBox.ShowAlert(alertUid, env.CurrentLanguageID);

                if (msgresult != "1")
                {
                    //when save prelim or finalize , recomfirm password
                    if (report_status != "D")
                    {
                        if (env.ReconfirmPassword == "Y")
                        {
                            Dialog.frmConfirmPassword dlgPass = new frmConfirmPassword();
                            dlgPass.ShowDialog();
                            if (dlgPass.DialogResult == DialogResult.Cancel)
                                return;
                        }
                    }

                    string rtf = this.GetGenerateResult();
                    string groupName = this.GetRadGroupName();

                    //Genarate RTF With group radiologist name and build html format
                    RichTextBox rt = new RichTextBox();
                    rt.Rtf = rtf;
                    rt.AppendText("\r\n\r\n" + groupName);
                    Miracle.Translator.TransRtf tran = new Miracle.Translator.TransRtf(rt.Rtf);
                    string rejectImg = "<img	src=\"none\" />";
                    string html = tran.Translator();
                    html = html.Replace(rejectImg, "");
                    string wrongText = @"\X000d\";
                    html = html.Replace(wrongText, "<br>");
                    //Set parameters
                    this.resultEntry.RISExamresult.ACCESSION_NO = drCaseData["ACCESSION_NO"].ToString();
                    this.resultEntry.RISExamresult.ORDER_ID = Convert.ToInt32(drCaseData["ORDER_ID"].ToString());
                    this.resultEntry.RISExamresult.EXAM_ID = Convert.ToInt32(drCaseData["EXAM_ID"].ToString());
                    this.resultEntry.RISExamresult.RESULT_TEXT_HTML = html;
                    this.resultEntry.RISExamresult.RESULT_TEXT_PLAIN = rt.Text;
                    this.resultEntry.RISExamresult.RESULT_TEXT_RTF = rtf;
                    this.resultEntry.RISExamresult.RESULT_STATUS = Convert.ToChar(report_status);
                    this.resultEntry.RISExamresult.HL7_TEXT = string.Empty;//hl7;
                    this.resultEntry.RISExamresult.HL7_SEND = Convert.ToChar("N");
                    this.resultEntry.RISExamresult.RELEASED_BY = env.UserID;
                    this.resultEntry.RISExamresult.FINALIZED_BY = 0;
                    this.resultEntry.RISExamresult.CREATED_BY = env.UserID;
                    this.resultEntry.RISExamresult.ORG_ID = env.OrgID;
                    

                    if (report_status != "D")
                    {
                        if(report_status == "F")
                            this.resultEntry.RISExamresult.ASSIGNED_TO = env.AuthLevelID == "3" ? this.CheckAssignTo("FINALIZE") : this._radfinalizeId;
                        else
                            this.resultEntry.RISExamresult.ASSIGNED_TO = this.CheckAssignTo("PRELIM");

                        this.resultEntry.RISExamresult.SEVERITY_ID = severityId;
                        //Add Accession no to sentopasc datatable
                        if (this.dtSendToPascAccession != null)
                        {
                            DataRow rowMsg = this.dtSendToPascAccession.NewRow();
                            rowMsg["ACCESSION_NO"] = drCaseData["ACCESSION_NO"].ToString();
                            this.dtSendToPascAccession.Rows.Add(rowMsg);
                            this.dtSendToPascAccession.AcceptChanges();
                        }
                    }
                    else
                    { //Draft
                        this.resultEntry.RISExamresult.ASSIGNED_TO = this.CheckAssignTo("DRAFT");
                        this.resultEntry.RISExamresult.SEVERITY_ID = 1;
                    }
                    this.resultEntry.Reporting();
                    //this.resultEntry.Reporting();
                    //Save with merge exam
                    if (this.dtMergeData != null)
                    {
                        foreach (DataRow dr in this.dtMergeData.Rows)
                        {
                            if (dr["ACCESSION_NO"].ToString() != this.accession)
                            {
                                this.resultEntry.RISExamresult.ACCESSION_NO = dr["ACCESSION_NO"].ToString();
                                this.resultEntry.RISExamresult.ORDER_ID = Convert.ToInt32(dr["ORDER_ID"].ToString());
                                this.resultEntry.RISExamresult.EXAM_ID = Convert.ToInt32(dr["EXAM_ID"].ToString());
                                this.resultEntry.RISExamresult.RESULT_TEXT_HTML = html;
                                this.resultEntry.RISExamresult.RESULT_TEXT_PLAIN = rt.Text;
                                this.resultEntry.RISExamresult.RESULT_TEXT_RTF = rtf;
                                this.resultEntry.RISExamresult.RESULT_STATUS = Convert.ToChar(report_status);
                                this.resultEntry.RISExamresult.RELEASED_BY = 0;
                                this.resultEntry.RISExamresult.FINALIZED_BY = 0;
                                this.resultEntry.RISExamresult.CREATED_BY = env.UserID;
                                this.resultEntry.RISExamresult.ORG_ID = env.OrgID;
                                if (report_status != "D")
                                {
                                    if (report_status == "F")
                                        this.resultEntry.RISExamresult.ASSIGNED_TO = env.AuthLevelID == "3" ? this.CheckAssignTo("FINALIZE") : this._radfinalizeId;
                                    else
                                        this.resultEntry.RISExamresult.ASSIGNED_TO = this.CheckAssignTo("PRELIM");

                                    this.resultEntry.RISExamresult.SEVERITY_ID = severityId;
                                    //Add Accession no to sentopasc datatable
                                    if (this.dtSendToPascAccession != null)
                                    {
                                        DataRow rowMsg = this.dtSendToPascAccession.NewRow();
                                        rowMsg["ACCESSION_NO"] = dr["ACCESSION_NO"].ToString();
                                        this.dtSendToPascAccession.Rows.Add(rowMsg);
                                        this.dtSendToPascAccession.AcceptChanges();
                                    }
                                }
                                else
                                { //Draft
                                    this.resultEntry.RISExamresult.ASSIGNED_TO = this.CheckAssignTo("DRAFT");
                                    this.resultEntry.RISExamresult.SEVERITY_ID = 1;
                                }
                                this.resultEntry.Reporting();
                            }
                        }
                    }

                    //Print report
                    if (msgresult == "3")
                    {
                        int id = 0;
                        int.TryParse(env.AuthLevelID, out id);

                        Envision.Plugin.DirectPrint.DirectPrint rpt = new Envision.Plugin.DirectPrint.DirectPrint();
                        rpt.ResultEntryDirectPrintA4(this.accession, id);
                    }
                }
                severityId = 0;
                alertUid = null;
                msgresult = null; //Clear memory
            }
        }

        /// <summary>
        /// Save Result
        /// </summary>
        /// <param name="status">Report Status</param>
        private void SaveStructuredResult(string status)
        {
            //Load for check have row or not
            ProcessGetMGBreastExamResult processGetMGBreastExamResult = new ProcessGetMGBreastExamResult();
            processGetMGBreastExamResult.MG_BREASTEXAMRESULT.ACCESSION_NO = this.accession;
            processGetMGBreastExamResult.MG_BREASTEXAMRESULT.ORG_ID = this.orgId;
            processGetMGBreastExamResult.Mode = 1;
            processGetMGBreastExamResult.Invoke();
            DataSet ds = processGetMGBreastExamResult.Result;
            if (this.HasDataRow(ds))
            {
                this.UpdateStructuredResult(status); //move to update result
                return;
            }

            //Envision.DataAccess
            Envision.DataAccess.DataAccessBase dbBase = new Envision.DataAccess.DataAccessBase();
            System.Data.Common.DbConnection connection = dbBase.Connection();
            connection.Open();
            System.Data.Common.DbTransaction transaction = connection.BeginTransaction();
            try
            {
                ProcessAddMGBreastExamResult processAddMgBreastExamResult = new ProcessAddMGBreastExamResult();
                processAddMgBreastExamResult.UseTransaction = true;
                processAddMgBreastExamResult.Transaction = transaction;
                processAddMgBreastExamResult.MG_BREASTEXAMRESULT.ACCESSION_NO = this.accession;
                processAddMgBreastExamResult.MG_BREASTEXAMRESULT.PATIENT_TYPE = EditValueConvertor.GetPatientTypeValue(this.Find_cbPatient_Type.SelectedIndex);
                processAddMgBreastExamResult.MG_BREASTEXAMRESULT.BREAST_COMPOSITION = EditValueConvertor.GetBreastCompositionValue(this.Find_cbBreast_Composition.SelectedIndex);
                processAddMgBreastExamResult.MG_BREASTEXAMRESULT.ORG_ID = this.orgId;
                processAddMgBreastExamResult.MG_BREASTEXAMRESULT.NO_OF_MASS = Convert.ToInt32(this.Find_tbNumber_of_Masses.Text);
                processAddMgBreastExamResult.MG_BREASTEXAMRESULT.PATIENT_TYPE_TEXT = this.Finding_tbPatientTypeOther.Text;
                processAddMgBreastExamResult.MG_BREASTEXAMRESULT.REPORT_STATUS = status;
                processAddMgBreastExamResult.MG_BREASTEXAMRESULT.REPORTING_DATE = DateTime.Today;
                if (status == "P")
                    processAddMgBreastExamResult.MG_BREASTEXAMRESULT.PRELIM_BY = this.empId;
                else if (status == "F")
                    processAddMgBreastExamResult.MG_BREASTEXAMRESULT.FINALIZED_BY = this.empId;
                processAddMgBreastExamResult.MG_BREASTEXAMRESULT.CREATED_BY = this.empId;
                if (this.Finding_cbCinicalHistory.SelectedIndex == 1)
                    processAddMgBreastExamResult.MG_BREASTEXAMRESULT.CLINICAL_HISTORY_TYPE = "S";
                else
                    processAddMgBreastExamResult.MG_BREASTEXAMRESULT.CLINICAL_HISTORY_TYPE = "D";
                processAddMgBreastExamResult.MG_BREASTEXAMRESULT.FINAL_ASSESSMENT_TYPE = EditValueConvertor.GetFinalAssessmentTypeValue(this.Finding_cbFinalassessment.SelectedIndex);
                if (multiChk_mass.Checked)
                {
                    processAddMgBreastExamResult.MG_BREASTEXAMRESULT.IS_MULTIPLE_MASS = "Y";
                    if (dsDominantList != null)
                        if (dsDominantList.Tables.Count > 0)
                            if (dsDominantList.Tables[0].Rows.Count > 0)
                                processAddMgBreastExamResult.MG_BREASTEXAMRESULT.HAS_DOMINANT_CYST = "Y";
                            else
                                processAddMgBreastExamResult.MG_BREASTEXAMRESULT.HAS_DOMINANT_CYST = "N";
                        else
                            processAddMgBreastExamResult.MG_BREASTEXAMRESULT.HAS_DOMINANT_CYST = "N";
                    else
                        processAddMgBreastExamResult.MG_BREASTEXAMRESULT.HAS_DOMINANT_CYST = "N";
                }
                else
                {
                    processAddMgBreastExamResult.MG_BREASTEXAMRESULT.HAS_DOMINANT_CYST = "N";
                    processAddMgBreastExamResult.MG_BREASTEXAMRESULT.IS_MULTIPLE_MASS = "N";
                }
                if (multiChk_Cyst.Checked)
                {
                    processAddMgBreastExamResult.MG_BREASTEXAMRESULT.HAS_DOMINANT_CYST = "Y";
                    processAddMgBreastExamResult.MG_BREASTEXAMRESULT.IS_MULTIPLE_CYST = "Y";
                }
                else
                {
                    processAddMgBreastExamResult.MG_BREASTEXAMRESULT.HAS_DOMINANT_CYST = "N";
                    processAddMgBreastExamResult.MG_BREASTEXAMRESULT.IS_MULTIPLE_CYST = "N";
                }

                processAddMgBreastExamResult.MG_BREASTEXAMRESULT.IMPRESSION_TEXT = this.memoSummary.Document.RtfText;
                if (this.Finding_chkNvMG.Checked)
                    processAddMgBreastExamResult.MG_BREASTEXAMRESULT.IS_MG_NEGATIVE = "Y";
                else
                    processAddMgBreastExamResult.MG_BREASTEXAMRESULT.IS_MG_NEGATIVE = "N";
                if (this.Finding_chkNvUS.Checked)
                    processAddMgBreastExamResult.MG_BREASTEXAMRESULT.IS_US_NEGATIVE = "Y";
                else
                    processAddMgBreastExamResult.MG_BREASTEXAMRESULT.IS_US_NEGATIVE = "N";
                processAddMgBreastExamResult.MG_BREASTEXAMRESULT.PERSONAL_HISTORY_OF_BREAST_CANCER = this.Finding_rdPersonal_History_of_breast_cancer.EditValue.ToString();
                processAddMgBreastExamResult.MG_BREASTEXAMRESULT.PERSONAL_HISTORY_OF_BREAST_CANCER_BREAST_SIDE = this.Finding_rdPersonal_History_of_breast_cancer_view.EditValue.ToString();
                processAddMgBreastExamResult.MG_BREASTEXAMRESULT.RECOMMENDATION_TYPE = EditValueConvertor.GetRecommendationTypeValue(this.Finding_cbRecommendation.SelectedIndex);
                processAddMgBreastExamResult.MG_BREASTEXAMRESULT.RECOMMENDATION_TYPE_TEXT = this.Finding_tbRecommendationOther.Text;
                if (this.Finding_rdFamily_history_of_breast_cancer.EditValue.ToString() == "N")
                    processAddMgBreastExamResult.MG_BREASTEXAMRESULT.FAMILY_HISTORY_OF_BREAST_CANCER = "N";
                else
                {
                    processAddMgBreastExamResult.MG_BREASTEXAMRESULT.FAMILY_HISTORY_OF_BREAST_CANCER = "Y";
                    processAddMgBreastExamResult.MG_BREASTEXAMRESULT.FAMILY_HISTORY_OF_BREAST_CANCER_TYPE_DEGREE = this.Finding_rdFamily_history_of_breast_cancer.EditValue.ToString();
                }
                //Image 
                processAddMgBreastExamResult.MG_BREASTEXAMRESULT.BREAST_IMAGE_LEFT = ((System.IO.MemoryStream)this.breastControl_Left.ExportImageToStream()).ToArray();
                processAddMgBreastExamResult.MG_BREASTEXAMRESULT.BREAST_IMAGE_RIGHT = ((System.IO.MemoryStream)this.breastControl_Right.ExportImageToStream()).ToArray();
                processAddMgBreastExamResult.MG_BREASTEXAMRESULT.SHOW_BREAST_IMAGE_LEFT = this.Img_chkLeft.Checked == true ? "Y" : "N";
                processAddMgBreastExamResult.MG_BREASTEXAMRESULT.SHOW_BREAST_IMAGE_RIGHT = this.Img_chkRight.Checked == true ? "Y" : "N";
                processAddMgBreastExamResult.MG_BREASTEXAMRESULT.COMMENT = this.mmComment.Text;
                processAddMgBreastExamResult.Invoke();

                //Breast MArk
                ProcessAddMGBreastMark processAddMGBreastMark = new ProcessAddMGBreastMark();
                processAddMGBreastMark.Transaction = transaction;
                processAddMGBreastMark.UseTransaction = true;
                processAddMGBreastMark.MG_BREASTMARK.ACCESSION_NO = this.accession;
                processAddMGBreastMark.MG_BREASTMARK.BREAST_SCREEN_HIGHT = (int)this.breastControl_Left.ScreenLenght;
                processAddMGBreastMark.MG_BREASTMARK.BREAST_SCREEN_WIDTH = (int)this.breastControl_Left.ScreenLenght;
                processAddMGBreastMark.MG_BREASTMARK.BREAST_SCREEN_SCALE = 1;
                processAddMGBreastMark.MG_BREASTMARK.NO_OF_MASS = Convert.ToInt32(this.Find_tbNumber_of_Masses.Text);
                processAddMGBreastMark.MG_BREASTMARK.ORG_ID = this.orgId;
                processAddMGBreastMark.MG_BREASTMARK.CREATED_BY = this.empId;
                processAddMGBreastMark.Invoke();

                //Breast Mark detail
                ProcessAddMGBreastMarkDtl processAddMGBreastDtl = new ProcessAddMGBreastMarkDtl();
                processAddMGBreastDtl.UseTransaction = true;
                processAddMGBreastDtl.Transaction = transaction;

                //Breast mass detail
                ProcessAddMGBreastMassDetails processAddMGBreastMassDetails = new ProcessAddMGBreastMassDetails();
                processAddMGBreastMassDetails.UseTransaction = true;
                processAddMGBreastMassDetails.Transaction = transaction;

                //Breast mass detail
                ProcessAddMGBreastUSMassDetails processAddMGBreastUSMassDetails = new ProcessAddMGBreastUSMassDetails();
                processAddMGBreastUSMassDetails.UseTransaction = true;
                processAddMGBreastUSMassDetails.Transaction = transaction;

                foreach (MarkStruct ms in this.markerList)
                {
                    //Mark Detail
                    CShapeControl control = ms.MarkObject as CShapeControl;
                    processAddMGBreastDtl.MG_BREASTMARKDTL.BREAST_MARK_ID = processAddMGBreastMark.MG_BREASTMARK.BREAST_MARK_ID;
                    processAddMGBreastDtl.MG_BREASTMARKDTL.BREAST_VIEW = ms.MassDetail.BREAST_TYPE;
                    processAddMGBreastDtl.MG_BREASTMARKDTL.CLOCK_NO = Convert.ToInt32(ms.MassDetail.MASS_LOCATION_CLOCK);
                    processAddMGBreastDtl.MG_BREASTMARKDTL.DIMENSION = (int)control.Diameter;
                    processAddMGBreastDtl.MG_BREASTMARKDTL.FILL_COLOR = control.ShapeBackground.ToString();
                    processAddMGBreastDtl.MG_BREASTMARKDTL.ORG_ID = this.orgId;
                    processAddMGBreastDtl.MG_BREASTMARKDTL.ORIGIN_X = (int)control.CenterPos.X;
                    processAddMGBreastDtl.MG_BREASTMARKDTL.ORIGIN_Y = (int)control.CenterPos.Y;
                    processAddMGBreastDtl.MG_BREASTMARKDTL.LOCATION_X = (int)control.ShapeLocation.Coordinate.X;
                    processAddMGBreastDtl.MG_BREASTMARKDTL.LOCATION_Y = (int)control.ShapeLocation.Coordinate.Y;
                    if (ms.IsUsMassDetail == "Y")
                    {
                        processAddMGBreastDtl.MG_BREASTMARKDTL.IS_US_FINDING = "Y";
                        processAddMGBreastDtl.MG_BREASTMARKDTL.MASS_NO = ms.MassUSDetail.MASS_NO;
                    }
                    else
                    {
                        processAddMGBreastDtl.MG_BREASTMARKDTL.IS_US_FINDING = "N";
                        processAddMGBreastDtl.MG_BREASTMARKDTL.MASS_NO = ms.MassDetail.MASS_NO;
                    }
                    switch (control.Shape)
                    {
                        case CShapeControl.Shapes.Architectural: processAddMGBreastDtl.MG_BREASTMARKDTL.SHAPE = "A"; break;
                        case CShapeControl.Shapes.Asymmetric: processAddMGBreastDtl.MG_BREASTMARKDTL.SHAPE = "B"; break;
                        case CShapeControl.Shapes.Calcification: processAddMGBreastDtl.MG_BREASTMARKDTL.SHAPE = "C"; break;
                        case CShapeControl.Shapes.Circumscribed: processAddMGBreastDtl.MG_BREASTMARKDTL.SHAPE = "D"; break;
                        case CShapeControl.Shapes.Indistinct: processAddMGBreastDtl.MG_BREASTMARKDTL.SHAPE = "E"; break;
                        case CShapeControl.Shapes.Microlobulated: processAddMGBreastDtl.MG_BREASTMARKDTL.SHAPE = "F"; break;
                        case CShapeControl.Shapes.Obscured: processAddMGBreastDtl.MG_BREASTMARKDTL.SHAPE = "G"; break;
                        case CShapeControl.Shapes.Spiculated: processAddMGBreastDtl.MG_BREASTMARKDTL.SHAPE = "H"; break;
                        case CShapeControl.Shapes.Angular: processAddMGBreastDtl.MG_BREASTMARKDTL.SHAPE = "I"; break;
                    }
                    processAddMGBreastDtl.MG_BREASTMARKDTL.STROKE_COLOR = control.ShapeStrokeColor.ToString();
                    if (control.ShapeBackground == System.Windows.Media.Brushes.Transparent)
                        processAddMGBreastDtl.MG_BREASTMARKDTL.STYLE = "O";
                    else
                        processAddMGBreastDtl.MG_BREASTMARKDTL.STYLE = "F";
                    processAddMGBreastDtl.MG_BREASTMARKDTL.CREATED_BY = this.empId;
                    processAddMGBreastDtl.MG_BREASTMARKDTL.MARK_ID = control.Name;
                    processAddMGBreastDtl.MG_BREASTMARKDTL.THICKNESS = (int)control.ShapeStrokeThickness;
                    processAddMGBreastDtl.Invoke();

                    //Mass Details
                    if (ms.IsUsMassDetail == "Y")
                    {
                        processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.ACCESSION_NO = this.accession;
                        processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.ARCHITECTURAL_DISTORTION_OBJECT_TYPE = ms.MassUSDetail.ARCHITECTURAL_DISTORTION_OBJECT_TYPE;
                        processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.ARCHITECTURAL_DISTORTION_TYPE = ms.MassUSDetail.ARCHITECTURAL_DISTORTION_TYPE;
                        processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.ASSOCIATE_FINDING_TYPE = ms.MassUSDetail.ASSOCIATE_FINDING_TYPE;
                        processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.BREAST_TYPE = ms.MassUSDetail.BREAST_TYPE;
                        processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.CREATED_BY = this.empId;
                        processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.DISTRIBUTION_MODIFIER_DIFFUSE_SCATTERED = ms.MassUSDetail.DISTRIBUTION_MODIFIER_DIFFUSE_SCATTERED;
                        processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.DISTRIBUTION_MODIFIER_GROUPED_OR_CLUSTERED = ms.MassUSDetail.DISTRIBUTION_MODIFIER_GROUPED_OR_CLUSTERED;
                        processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.DISTRIBUTION_MODIFIER_LINEAR = ms.MassUSDetail.DISTRIBUTION_MODIFIER_LINEAR;
                        processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.DISTRIBUTION_MODIFIER_REGIONAL = ms.MassUSDetail.DISTRIBUTION_MODIFIER_REGIONAL;
                        processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.DISTRIBUTION_MODIFIER_SEGMENTAL = ms.MassUSDetail.DISTRIBUTION_MODIFIER_SEGMENTAL;
                        processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.FINDING_TYPE = ms.MassUSDetail.FINDING_TYPE;
                        processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.HIGHER_PROBABILITY_OF_MALIGNANCY_FINE_LINEAR = ms.MassUSDetail.HIGHER_PROBABILITY_OF_MALIGNANCY_FINE_LINEAR;
                        processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.HIGHER_PROBABILITY_OF_MALIGNANCY_FINE_PLEOMORPHIC = ms.MassUSDetail.HIGHER_PROBABILITY_OF_MALIGNANCY_FINE_PLEOMORPHIC;
                        processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.INTERMEDIATE_CONCERN_SUSPICIOUS_AMORPHOUS_OR_INDISTINCT = ms.MassUSDetail.INTERMEDIATE_CONCERN_SUSPICIOUS_AMORPHOUS_OR_INDISTINCT;
                        processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.INTERMEDIATE_CONCERN_SUSPICIOUS_COARSE_HETEROGENOUS = ms.MassUSDetail.INTERMEDIATE_CONCERN_SUSPICIOUS_COARSE_HETEROGENOUS;
                        processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.MASS_TYPE = ms.MassUSDetail.MASS_TYPE;
                        processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.MASS_CYST_TYPE = ms.MassUSDetail.MASS_CYST_TYPE;
                        processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.MASS_POSTERIOR_ACOUSTIC_FEATURES = ms.MassUSDetail.MASS_POSTERIOR_ACOUSTIC_FEATURES;
                        processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.MASS_LOCATION_CLOCK = ms.MassUSDetail.MASS_LOCATION_CLOCK;
                        processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.MASS_LOCATION_ON_IMAGE = ms.MassUSDetail.MASS_LOCATION_ON_IMAGE;
                        processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.MASS_MARGIN = ms.MassUSDetail.MASS_MARGIN;
                        processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.MASS_NO = ms.MassUSDetail.MASS_NO;
                        processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.MASS_ORIENTATION = ms.MassUSDetail.MASS_ORIENTATION;
                        processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.MASS_ECHO_PATTERN = ms.MassUSDetail.MASS_ECHO_PATTERN;
                        processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.MASS_LESION_BOUNDARY = ms.MassUSDetail.MASS_LESION_BOUNDARY;
                        processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.NO_OF_ARCHITECTURAL_DISTORTION = ms.MassUSDetail.NO_OF_ARCHITECTURAL_DISTORTION;
                        processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.NO_OF_CALCIFICATION_OBJECTS = ms.MassUSDetail.NO_OF_CALCIFICATION_OBJECTS;
                        processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.ORG_ID = this.orgId;
                        processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.SPECIAL_CASE_NO_OF_ARCHITECTURAL_DISTORTION = ms.MassUSDetail.SPECIAL_CASE_NO_OF_ARCHITECTURAL_DISTORTION;
                        processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.SPECIAL_CASE_TYPE = ms.MassUSDetail.SPECIAL_CASE_TYPE;
                        processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.TYPE_OF_CALCIFICATION_OBJECT = ms.MassUSDetail.TYPE_OF_CALCIFICATION_OBJECT;
                        processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.TYPICALLY_BENIGN_COARSE_OR_POPCORN_LIKE = ms.MassUSDetail.TYPICALLY_BENIGN_COARSE_OR_POPCORN_LIKE;
                        processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.TYPICALLY_BENIGN_DYSTROPHIC = ms.MassUSDetail.TYPICALLY_BENIGN_DYSTROPHIC;
                        processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.TYPICALLY_BENIGN_EGGSHELL_OR_RIM = ms.MassUSDetail.TYPICALLY_BENIGN_EGGSHELL_OR_RIM;
                        processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.TYPICALLY_BENIGN_LARGE_ROD_LIKE = ms.MassUSDetail.TYPICALLY_BENIGN_LARGE_ROD_LIKE;
                        processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.TYPICALLY_BENIGN_LUCENT_CENTERED = ms.MassUSDetail.TYPICALLY_BENIGN_LUCENT_CENTERED;
                        processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.TYPICALLY_BENIGN_MILK_OF_CALCIUM = ms.MassUSDetail.TYPICALLY_BENIGN_MILK_OF_CALCIUM;
                        processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.TYPICALLY_BENIGN_ROUND = ms.MassUSDetail.TYPICALLY_BENIGN_ROUND;
                        processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.TYPICALLY_BENIGN_SKIN = ms.MassUSDetail.TYPICALLY_BENIGN_SKIN;
                        processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.TYPICALLY_BENIGN_SUTURE = ms.MassUSDetail.TYPICALLY_BENIGN_SUTURE;
                        processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.TYPICALLY_BENIGN_VASCULAR = ms.MassUSDetail.TYPICALLY_BENIGN_VASCULAR;
                        processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.SIZE_X = ms.MassUSDetail.SIZE_X;
                        processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.SIZE_Y = ms.MassUSDetail.SIZE_Y;
                        processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.SIZE_Z = ms.MassUSDetail.SIZE_Z;
                        processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.ASSOCIATE_FINDING_TYPE_TEXT = ms.MassUSDetail.ASSOCIATE_FINDING_TYPE_TEXT;
                        processAddMGBreastUSMassDetails.Invoke();
                    }
                    else
                    {
                        processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.ACCESSION_NO = this.accession;
                        processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.ARCHITECTURAL_DISTORTION_OBJECT_TYPE = ms.MassDetail.ARCHITECTURAL_DISTORTION_OBJECT_TYPE;
                        processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.ARCHITECTURAL_DISTORTION_TYPE = ms.MassDetail.ARCHITECTURAL_DISTORTION_TYPE;
                        processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.ASSOCIATE_FINDING_TYPE = ms.MassDetail.ASSOCIATE_FINDING_TYPE;
                        processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.BREAST_TYPE = ms.MassDetail.BREAST_TYPE;
                        processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.CREATED_BY = this.empId;
                        processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.DISTRIBUTION_MODIFIER_DIFFUSE_SCATTERED = ms.MassDetail.DISTRIBUTION_MODIFIER_DIFFUSE_SCATTERED;
                        processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.DISTRIBUTION_MODIFIER_GROUPED_OR_CLUSTERED = ms.MassDetail.DISTRIBUTION_MODIFIER_GROUPED_OR_CLUSTERED;
                        processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.DISTRIBUTION_MODIFIER_LINEAR = ms.MassDetail.DISTRIBUTION_MODIFIER_LINEAR;
                        processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.DISTRIBUTION_MODIFIER_REGIONAL = ms.MassDetail.DISTRIBUTION_MODIFIER_REGIONAL;
                        processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.DISTRIBUTION_MODIFIER_SEGMENTAL = ms.MassDetail.DISTRIBUTION_MODIFIER_SEGMENTAL;
                        processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.FINDING_TYPE = ms.MassDetail.FINDING_TYPE;
                        processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.HIGHER_PROBABILITY_OF_MALIGNANCY_FINE_LINEAR = ms.MassDetail.HIGHER_PROBABILITY_OF_MALIGNANCY_FINE_LINEAR;
                        processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.HIGHER_PROBABILITY_OF_MALIGNANCY_FINE_PLEOMORPHIC = ms.MassDetail.HIGHER_PROBABILITY_OF_MALIGNANCY_FINE_PLEOMORPHIC;
                        processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.INTERMEDIATE_CONCERN_SUSPICIOUS_AMORPHOUS_OR_INDISTINCT = ms.MassDetail.INTERMEDIATE_CONCERN_SUSPICIOUS_AMORPHOUS_OR_INDISTINCT;
                        processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.INTERMEDIATE_CONCERN_SUSPICIOUS_COARSE_HETEROGENOUS = ms.MassDetail.INTERMEDIATE_CONCERN_SUSPICIOUS_COARSE_HETEROGENOUS;
                        processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.MASS_DENSITY = ms.MassDetail.MASS_DENSITY;
                        processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.MASS_DENSITY_TYPE = ms.MassDetail.MASS_DENSITY_TYPE;
                        processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.MASS_HAS_CALCIFICATION = ms.MassDetail.MASS_HAS_CALCIFICATION;
                        processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.MASS_LOCATION_CLOCK = ms.MassDetail.MASS_LOCATION_CLOCK;
                        processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.MASS_LOCATION_ON_IMAGE = ms.MassDetail.MASS_LOCATION_ON_IMAGE;
                        processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.MASS_MARGIN = ms.MassDetail.MASS_MARGIN;
                        processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.MASS_NO = ms.MassDetail.MASS_NO;
                        processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.MASS_SHAPE = ms.MassDetail.MASS_SHAPE;
                        processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.NO_OF_ARCHITECTURAL_DISTORTION = ms.MassDetail.NO_OF_ARCHITECTURAL_DISTORTION;
                        processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.NO_OF_CALCIFICATION_OBJECTS = ms.MassDetail.NO_OF_CALCIFICATION_OBJECTS;
                        processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.ORG_ID = this.orgId;
                        processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.SPECIAL_CASE_NO_OF_ARCHITECTURAL_DISTORTION = ms.MassDetail.SPECIAL_CASE_NO_OF_ARCHITECTURAL_DISTORTION;
                        processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.SPECIAL_CASE_TYPE = ms.MassDetail.SPECIAL_CASE_TYPE;
                        processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.TYPE_OF_CALCIFICATION_OBJECT = ms.MassDetail.TYPE_OF_CALCIFICATION_OBJECT;
                        processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.TYPICALLY_BENIGN_COARSE_OR_POPCORN_LIKE = ms.MassDetail.TYPICALLY_BENIGN_COARSE_OR_POPCORN_LIKE;
                        processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.TYPICALLY_BENIGN_DYSTROPHIC = ms.MassDetail.TYPICALLY_BENIGN_DYSTROPHIC;
                        processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.TYPICALLY_BENIGN_EGGSHELL_OR_RIM = ms.MassDetail.TYPICALLY_BENIGN_EGGSHELL_OR_RIM;
                        processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.TYPICALLY_BENIGN_LARGE_ROD_LIKE = ms.MassDetail.TYPICALLY_BENIGN_LARGE_ROD_LIKE;
                        processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.TYPICALLY_BENIGN_LUCENT_CENTERED = ms.MassDetail.TYPICALLY_BENIGN_LUCENT_CENTERED;
                        processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.TYPICALLY_BENIGN_MILK_OF_CALCIUM = ms.MassDetail.TYPICALLY_BENIGN_MILK_OF_CALCIUM;
                        processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.TYPICALLY_BENIGN_ROUND = ms.MassDetail.TYPICALLY_BENIGN_ROUND;
                        processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.TYPICALLY_BENIGN_SKIN = ms.MassDetail.TYPICALLY_BENIGN_SKIN;
                        processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.TYPICALLY_BENIGN_SUTURE = ms.MassDetail.TYPICALLY_BENIGN_SUTURE;
                        processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.TYPICALLY_BENIGN_VASCULAR = ms.MassDetail.TYPICALLY_BENIGN_VASCULAR;
                        processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.SIZE_X = ms.MassDetail.SIZE_X;
                        processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.SIZE_Y = ms.MassDetail.SIZE_Y;
                        processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.SIZE_Z = ms.MassDetail.SIZE_Z;
                        processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.ASSOCIATE_FINDING_TYPE_TEXT = ms.MassDetail.ASSOCIATE_FINDING_TYPE_TEXT;
                        processAddMGBreastMassDetails.Invoke();
                    }
                }
                
                //Comparison Study
                ProcessAddMGPatientHistoryComparison processAddMgPatientHistoryComparison = new ProcessAddMGPatientHistoryComparison();
                processAddMgPatientHistoryComparison.UseTransaction = true;
                processAddMgPatientHistoryComparison.Transaction = transaction;
                if (this.rdConpareType.EditValue.ToString() == "S")
                {
                    DataRow[] compasionRows = this.dsExamResultHistory.Tables[0].Select("SELECT = 'Y'");
                    foreach (DataRow dr in compasionRows)
                    {
                        processAddMgPatientHistoryComparison.MG_PATIENTHISTORYCOMPARISON.COMPARED_TYPE = "S";
                        processAddMgPatientHistoryComparison.MG_PATIENTHISTORYCOMPARISON.COMPARED_BY = this.empId;
                        //processAddMgPatientHistoryComparison.MG_PATIENTHISTORYCOMPARISON.COMPARED_TEXT = this.mmComparisonText.Text;
                        processAddMgPatientHistoryComparison.MG_PATIENTHISTORYCOMPARISON.COMPARED_WITH = dr["ACCESSION_NO"].ToString();
                        processAddMgPatientHistoryComparison.MG_PATIENTHISTORYCOMPARISON.COMPARING_EXAM = this.accession; 
                        processAddMgPatientHistoryComparison.MG_PATIENTHISTORYCOMPARISON.CREATED_BY = this.empId;
                        processAddMgPatientHistoryComparison.MG_PATIENTHISTORYCOMPARISON.ORG_ID = this.orgId;
                        processAddMgPatientHistoryComparison.MG_PATIENTHISTORYCOMPARISON.REG_ID = Convert.ToInt32(this.dsDemographic.Tables[0].Rows[0]["REG_ID"]);
                        processAddMgPatientHistoryComparison.Invoke();
                    }
                }
                else
                {
                    processAddMgPatientHistoryComparison.MG_PATIENTHISTORYCOMPARISON.COMPARED_TYPE = "F";
                    processAddMgPatientHistoryComparison.MG_PATIENTHISTORYCOMPARISON.COMPARED_BY = this.empId;
                    processAddMgPatientHistoryComparison.MG_PATIENTHISTORYCOMPARISON.COMPARED_TEXT = this.mmComparisonText.Text;
                    processAddMgPatientHistoryComparison.MG_PATIENTHISTORYCOMPARISON.COMPARING_EXAM = this.accession;
                    //processAddMgPatientHistoryComparison.MG_PATIENTHISTORYCOMPARISON.COMPARING_EXAM = dr["ACCESSION_NO"].ToString();
                    processAddMgPatientHistoryComparison.MG_PATIENTHISTORYCOMPARISON.CREATED_BY = this.empId;
                    processAddMgPatientHistoryComparison.MG_PATIENTHISTORYCOMPARISON.ORG_ID = this.orgId;
                    processAddMgPatientHistoryComparison.MG_PATIENTHISTORYCOMPARISON.REG_ID = Convert.ToInt32(this.dsDemographic.Tables[0].Rows[0]["REG_ID"]);
                    processAddMgPatientHistoryComparison.Invoke();
                }

                ProcessAddMGMassDominantCyst _processAddMGMassDominantCyst = new ProcessAddMGMassDominantCyst();
                _processAddMGMassDominantCyst.UseTransaction = true;
                _processAddMGMassDominantCyst.Transaction = transaction;

                if (this.multiChk_mass.Checked)
                {
                    if (this.dsDominantList != null)
                        if (this.dsDominantList.Tables.Count > 0)
                        {
                            for (int i = 0; i < this.dsDominantList.Tables[0].Rows.Count; i++)
                            {
                                _processAddMGMassDominantCyst.MG_MASSDOMINANTCYST.ACCESSION_NO = this.accession;
                                _processAddMGMassDominantCyst.MG_MASSDOMINANTCYST.MASS_NO = Convert.ToInt32(this.dsDominantList.Tables[0].Rows[i]["MASS_NO"]);
                                _processAddMGMassDominantCyst.MG_MASSDOMINANTCYST.CLOCK_LOCATION = Convert.ToInt32(this.dsDominantList.Tables[0].Rows[i]["LOCATION"]);
                                _processAddMGMassDominantCyst.MG_MASSDOMINANTCYST.DIAMETER = Convert.ToInt32(this.dsDominantList.Tables[0].Rows[i]["SIZE"]);
                                _processAddMGMassDominantCyst.MG_MASSDOMINANTCYST.SIDE = this.dsDominantList.Tables[0].Rows[0]["BREAST_VIEW"].ToString();
                                _processAddMGMassDominantCyst.MG_MASSDOMINANTCYST.IS_DOMINANT_CYST = "N";
                                //_processAddMGMassDominantCyst.MG_MASSDOMINANTCYST.BREAST_MARKDTL_ID = processAddMGBreastMark.MG_BREASTMARK.BREAST_MARK_ID;
                                _processAddMGMassDominantCyst.MG_MASSDOMINANTCYST.ORG_ID = this.orgId;
                                _processAddMGMassDominantCyst.MG_MASSDOMINANTCYST.CREATED_BY = this.empId;
                                _processAddMGMassDominantCyst.Invoke();
                            }

                            for (int i = 0; i < this.dsDominantList.Tables[1].Rows.Count; i++)
                            {
                                _processAddMGMassDominantCyst.MG_MASSDOMINANTCYST.ACCESSION_NO = this.accession;
                                _processAddMGMassDominantCyst.MG_MASSDOMINANTCYST.MASS_NO = Convert.ToInt32(this.dsDominantList.Tables[1].Rows[i]["MASS_NO"]);
                                _processAddMGMassDominantCyst.MG_MASSDOMINANTCYST.CLOCK_LOCATION = Convert.ToInt32(this.dsDominantList.Tables[1].Rows[i]["LOCATION"]);
                                _processAddMGMassDominantCyst.MG_MASSDOMINANTCYST.DIAMETER = Convert.ToInt32(this.dsDominantList.Tables[1].Rows[i]["SIZE"]);
                                _processAddMGMassDominantCyst.MG_MASSDOMINANTCYST.SIDE = this.dsDominantList.Tables[1].Rows[0]["BREAST_VIEW"].ToString();
                                _processAddMGMassDominantCyst.MG_MASSDOMINANTCYST.IS_DOMINANT_CYST = "Y";
                                //_processAddMGMassDominantCyst.MG_MASSDOMINANTCYST.BREAST_MARKDTL_ID = processAddMGBreastMark.MG_BREASTMARK.BREAST_MARK_ID;
                                _processAddMGMassDominantCyst.MG_MASSDOMINANTCYST.ORG_ID = this.orgId;
                                _processAddMGMassDominantCyst.MG_MASSDOMINANTCYST.CREATED_BY = this.empId;
                                _processAddMGMassDominantCyst.Invoke();
                            }
                        }
                }
                transaction.Commit();
                connection.Close();

                //MessageBox.Show("Saved");
            }
            catch (Exception ex) 
            {
                transaction.Rollback();
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// This method use to update structured report result
        /// </summary>
        /// <param name="status">report status</param>
        private void UpdateStructuredResult(string status)
        {
            Envision.DataAccess.DataAccessBase dbBase = new Envision.DataAccess.DataAccessBase();
            System.Data.Common.DbConnection connection = dbBase.Connection();
            connection.Open();
            System.Data.Common.DbTransaction transaction = connection.BeginTransaction();
            try
            {
                #region Breast Exam Result
                ProcessUpdateMGBreastExamResult _processUpdateMGBreastResult = new ProcessUpdateMGBreastExamResult();
                _processUpdateMGBreastResult.UseTransaction = true;
                _processUpdateMGBreastResult.Transaction = transaction;
                _processUpdateMGBreastResult.MG_BREASTEXAMRESULT.ACCESSION_NO = this.accession;
                _processUpdateMGBreastResult.MG_BREASTEXAMRESULT.PATIENT_TYPE = EditValueConvertor.GetPatientTypeValue(this.Find_cbPatient_Type.SelectedIndex);
                _processUpdateMGBreastResult.MG_BREASTEXAMRESULT.BREAST_COMPOSITION = EditValueConvertor.GetBreastCompositionValue(this.Find_cbBreast_Composition.SelectedIndex);
                _processUpdateMGBreastResult.MG_BREASTEXAMRESULT.ORG_ID = this.orgId;
                _processUpdateMGBreastResult.MG_BREASTEXAMRESULT.NO_OF_MASS = Convert.ToInt32(this.Find_tbNumber_of_Masses.Text);
                _processUpdateMGBreastResult.MG_BREASTEXAMRESULT.PATIENT_TYPE_TEXT = this.Finding_tbPatientTypeOther.Text;
                _processUpdateMGBreastResult.MG_BREASTEXAMRESULT.REPORT_STATUS = status;
                _processUpdateMGBreastResult.MG_BREASTEXAMRESULT.REPORTING_DATE = DateTime.Today;
                if (status == "P")
                    _processUpdateMGBreastResult.MG_BREASTEXAMRESULT.PRELIM_BY = this.empId;
                else if (status == "F")
                    _processUpdateMGBreastResult.MG_BREASTEXAMRESULT.FINALIZED_BY = this.empId;
                _processUpdateMGBreastResult.MG_BREASTEXAMRESULT.CREATED_BY = this.empId;
                if (this.Finding_cbCinicalHistory.SelectedIndex == 1)
                    _processUpdateMGBreastResult.MG_BREASTEXAMRESULT.CLINICAL_HISTORY_TYPE = "S";
                else
                    _processUpdateMGBreastResult.MG_BREASTEXAMRESULT.CLINICAL_HISTORY_TYPE = "D";
                _processUpdateMGBreastResult.MG_BREASTEXAMRESULT.FINAL_ASSESSMENT_TYPE = EditValueConvertor.GetFinalAssessmentTypeValue(this.Finding_cbFinalassessment.SelectedIndex);
                if (multiChk_mass.Checked)
                {
                    _processUpdateMGBreastResult.MG_BREASTEXAMRESULT.IS_MULTIPLE_MASS = "Y";
                    if (dsDominantList != null)
                        if (dsDominantList.Tables.Count > 0)
                            if (dsDominantList.Tables[0].Rows.Count > 0)
                                _processUpdateMGBreastResult.MG_BREASTEXAMRESULT.HAS_DOMINANT_CYST = "Y";
                            else
                                _processUpdateMGBreastResult.MG_BREASTEXAMRESULT.HAS_DOMINANT_CYST = "N";
                        else
                            _processUpdateMGBreastResult.MG_BREASTEXAMRESULT.HAS_DOMINANT_CYST = "N";
                    else
                        _processUpdateMGBreastResult.MG_BREASTEXAMRESULT.HAS_DOMINANT_CYST = "N";
                }
                else
                {
                    _processUpdateMGBreastResult.MG_BREASTEXAMRESULT.HAS_DOMINANT_CYST = "N";
                    _processUpdateMGBreastResult.MG_BREASTEXAMRESULT.IS_MULTIPLE_MASS = "N";
                }
                if (multiChk_Cyst.Checked)
                {
                    _processUpdateMGBreastResult.MG_BREASTEXAMRESULT.HAS_DOMINANT_CYST = "Y";
                    _processUpdateMGBreastResult.MG_BREASTEXAMRESULT.IS_MULTIPLE_CYST = "Y";
                }
                else
                {
                    _processUpdateMGBreastResult.MG_BREASTEXAMRESULT.HAS_DOMINANT_CYST = "N";
                    _processUpdateMGBreastResult.MG_BREASTEXAMRESULT.IS_MULTIPLE_CYST = "N";
                }
                _processUpdateMGBreastResult.MG_BREASTEXAMRESULT.IMPRESSION_TEXT = this.memoSummary.Document.RtfText;
                if (this.Finding_chkNvMG.Checked)
                    _processUpdateMGBreastResult.MG_BREASTEXAMRESULT.IS_MG_NEGATIVE = "Y";
                else
                    _processUpdateMGBreastResult.MG_BREASTEXAMRESULT.IS_MG_NEGATIVE = "N";
                if (this.Finding_chkNvUS.Checked)
                    _processUpdateMGBreastResult.MG_BREASTEXAMRESULT.IS_US_NEGATIVE = "Y";
                else
                    _processUpdateMGBreastResult.MG_BREASTEXAMRESULT.IS_US_NEGATIVE = "N";
                _processUpdateMGBreastResult.MG_BREASTEXAMRESULT.PERSONAL_HISTORY_OF_BREAST_CANCER = this.Finding_rdPersonal_History_of_breast_cancer.EditValue.ToString();
                _processUpdateMGBreastResult.MG_BREASTEXAMRESULT.PERSONAL_HISTORY_OF_BREAST_CANCER_BREAST_SIDE = this.Finding_rdPersonal_History_of_breast_cancer_view.EditValue.ToString();
                _processUpdateMGBreastResult.MG_BREASTEXAMRESULT.RECOMMENDATION_TYPE = EditValueConvertor.GetRecommendationTypeValue(this.Finding_cbRecommendation.SelectedIndex);
                _processUpdateMGBreastResult.MG_BREASTEXAMRESULT.RECOMMENDATION_TYPE_TEXT = this.Finding_tbRecommendationOther.Text;
                if (this.Finding_rdFamily_history_of_breast_cancer.EditValue.ToString() == "N")
                    _processUpdateMGBreastResult.MG_BREASTEXAMRESULT.FAMILY_HISTORY_OF_BREAST_CANCER = "N";
                else
                {
                    _processUpdateMGBreastResult.MG_BREASTEXAMRESULT.FAMILY_HISTORY_OF_BREAST_CANCER = "Y";
                    _processUpdateMGBreastResult.MG_BREASTEXAMRESULT.FAMILY_HISTORY_OF_BREAST_CANCER_TYPE_DEGREE = this.Finding_rdFamily_history_of_breast_cancer.EditValue.ToString();
                }
                _processUpdateMGBreastResult.MG_BREASTEXAMRESULT.BREAST_IMAGE_LEFT = ((System.IO.MemoryStream)this.breastControl_Left.ExportImageToStream()).ToArray();
                _processUpdateMGBreastResult.MG_BREASTEXAMRESULT.BREAST_IMAGE_RIGHT = ((System.IO.MemoryStream)this.breastControl_Right.ExportImageToStream()).ToArray();
                _processUpdateMGBreastResult.MG_BREASTEXAMRESULT.SHOW_BREAST_IMAGE_LEFT = this.Img_chkLeft.Checked == true ? "Y" : "N";
                _processUpdateMGBreastResult.MG_BREASTEXAMRESULT.SHOW_BREAST_IMAGE_RIGHT = this.Img_chkRight.Checked == true ? "Y" : "N";
                _processUpdateMGBreastResult.MG_BREASTEXAMRESULT.COMMENT = this.mmComment.Text;
                _processUpdateMGBreastResult.Invoke();

                #endregion

                #region Breast Mark and Mass Detail
                //Update MG Breast Mark
                ProcessUpdateMGBreastMark _processUpdateMGBreastMark = new ProcessUpdateMGBreastMark();
                _processUpdateMGBreastMark.UseTransaction = true;
                _processUpdateMGBreastMark.Transaction = transaction;
                _processUpdateMGBreastMark.MG_BREASTMARK.ACCESSION_NO = this.accession;
                _processUpdateMGBreastMark.MG_BREASTMARK.BREAST_SCREEN_HIGHT = (int)this.breastControl_Left.ScreenLenght;
                _processUpdateMGBreastMark.MG_BREASTMARK.BREAST_SCREEN_WIDTH = (int)this.breastControl_Left.ScreenLenght;
                _processUpdateMGBreastMark.MG_BREASTMARK.BREAST_SCREEN_SCALE = 1;
                _processUpdateMGBreastMark.MG_BREASTMARK.NO_OF_MASS = Convert.ToInt32(this.Find_tbNumber_of_Masses.Text);
                _processUpdateMGBreastMark.MG_BREASTMARK.ORG_ID = this.orgId;
                _processUpdateMGBreastMark.MG_BREASTMARK.CREATED_BY = this.empId;
                
                _processUpdateMGBreastMark.Invoke();

                ProcessDeleteMGBreastMarkDtl _processDeleteMGBreastMarkDtl = new ProcessDeleteMGBreastMarkDtl();
                _processDeleteMGBreastMarkDtl.UserTransaction = true;
                _processDeleteMGBreastMarkDtl.Transaction = transaction;
                _processDeleteMGBreastMarkDtl.Mode = 2;
                _processDeleteMGBreastMarkDtl.MG_BREASTMARKDTL.BREAST_MARK_ID = _processUpdateMGBreastMark.MG_BREASTMARK.BREAST_MARK_ID;
                _processDeleteMGBreastMarkDtl.Invoke();

                ProcessAddMGBreastMarkDtl _processAddMGBreastMarkDtl = new ProcessAddMGBreastMarkDtl();
                _processAddMGBreastMarkDtl.UseTransaction = true;
                _processAddMGBreastMarkDtl.Transaction = transaction;

                ProcessDeleteMGBreastMassDetails _processDeleteMGBreastMassDetails = new ProcessDeleteMGBreastMassDetails();
                _processDeleteMGBreastMassDetails.UseTransaction = true;
                _processDeleteMGBreastMassDetails.Transaction = transaction;
                _processDeleteMGBreastMassDetails.MG_BREASTMASSDETAILS.ACCESSION_NO = this.accession;
                _processDeleteMGBreastMassDetails.Invoke();

                ProcessDeleteMGBreastUSMassDetails _processDeleteMGBreastUSMassDetails = new ProcessDeleteMGBreastUSMassDetails();
                _processDeleteMGBreastUSMassDetails.UseTransaction = true;
                _processDeleteMGBreastUSMassDetails.Transaction = transaction;
                _processDeleteMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.ACCESSION_NO = this.accession;
                _processDeleteMGBreastUSMassDetails.Invoke();

                ProcessAddMGBreastMassDetails _processAddMGBreastMassDetails = new ProcessAddMGBreastMassDetails();
                _processAddMGBreastMassDetails.UseTransaction = true;
                _processAddMGBreastMassDetails.Transaction = transaction;
                ProcessAddMGBreastUSMassDetails _processAddMGBreastUSMassDetails = new ProcessAddMGBreastUSMassDetails();
                _processAddMGBreastUSMassDetails.UseTransaction = true;
                _processAddMGBreastUSMassDetails.Transaction = transaction;

                foreach (MarkStruct ms in this.markerList)
                {
                    //Mark Detail
                    CShapeControl control = ms.MarkObject as CShapeControl;
                    _processAddMGBreastMarkDtl.MG_BREASTMARKDTL.BREAST_MARK_ID = _processUpdateMGBreastMark.MG_BREASTMARK.BREAST_MARK_ID;
                    _processAddMGBreastMarkDtl.MG_BREASTMARKDTL.BREAST_VIEW = ms.MassDetail.BREAST_TYPE;
                    _processAddMGBreastMarkDtl.MG_BREASTMARKDTL.CLOCK_NO = Convert.ToInt32(ms.MassDetail.MASS_LOCATION_CLOCK);
                    _processAddMGBreastMarkDtl.MG_BREASTMARKDTL.DIMENSION = (int)control.Diameter;
                    _processAddMGBreastMarkDtl.MG_BREASTMARKDTL.FILL_COLOR = control.ShapeBackground.ToString();
                    _processAddMGBreastMarkDtl.MG_BREASTMARKDTL.ORG_ID = this.orgId;
                    _processAddMGBreastMarkDtl.MG_BREASTMARKDTL.ORIGIN_X = (int)control.CenterPos.X;
                    _processAddMGBreastMarkDtl.MG_BREASTMARKDTL.ORIGIN_Y = (int)control.CenterPos.Y;
                    _processAddMGBreastMarkDtl.MG_BREASTMARKDTL.LOCATION_X = (int)control.ShapeLocation.Coordinate.X;
                    _processAddMGBreastMarkDtl.MG_BREASTMARKDTL.LOCATION_Y = (int)control.ShapeLocation.Coordinate.Y;
                    if (ms.IsUsMassDetail == "Y")
                    {
                        _processAddMGBreastMarkDtl.MG_BREASTMARKDTL.IS_US_FINDING = "Y";
                        _processAddMGBreastMarkDtl.MG_BREASTMARKDTL.MASS_NO = ms.MassUSDetail.MASS_NO;
                    }
                    else
                    {
                        _processAddMGBreastMarkDtl.MG_BREASTMARKDTL.IS_US_FINDING = "N";
                        _processAddMGBreastMarkDtl.MG_BREASTMARKDTL.MASS_NO = ms.MassDetail.MASS_NO;
                    }
                    switch (control.Shape)
                    {
                        case CShapeControl.Shapes.Architectural: _processAddMGBreastMarkDtl.MG_BREASTMARKDTL.SHAPE = "A"; break;
                        case CShapeControl.Shapes.Asymmetric: _processAddMGBreastMarkDtl.MG_BREASTMARKDTL.SHAPE = "B"; break;
                        case CShapeControl.Shapes.Calcification: _processAddMGBreastMarkDtl.MG_BREASTMARKDTL.SHAPE = "C"; break;
                        case CShapeControl.Shapes.Circumscribed: _processAddMGBreastMarkDtl.MG_BREASTMARKDTL.SHAPE = "D"; break;
                        case CShapeControl.Shapes.Indistinct: _processAddMGBreastMarkDtl.MG_BREASTMARKDTL.SHAPE = "E"; break;
                        case CShapeControl.Shapes.Microlobulated: _processAddMGBreastMarkDtl.MG_BREASTMARKDTL.SHAPE = "F"; break;
                        case CShapeControl.Shapes.Obscured: _processAddMGBreastMarkDtl.MG_BREASTMARKDTL.SHAPE = "G"; break;
                        case CShapeControl.Shapes.Spiculated: _processAddMGBreastMarkDtl.MG_BREASTMARKDTL.SHAPE = "H"; break;
                        case CShapeControl.Shapes.Angular: _processAddMGBreastMarkDtl.MG_BREASTMARKDTL.SHAPE = "I"; break;
                    }
                    _processAddMGBreastMarkDtl.MG_BREASTMARKDTL.STROKE_COLOR = control.ShapeStrokeColor.ToString();
                    if (control.ShapeBackground == System.Windows.Media.Brushes.Transparent)
                        _processAddMGBreastMarkDtl.MG_BREASTMARKDTL.STYLE = "O";
                    else
                        _processAddMGBreastMarkDtl.MG_BREASTMARKDTL.STYLE = "F";
                    _processAddMGBreastMarkDtl.MG_BREASTMARKDTL.CREATED_BY = this.empId;
                    _processAddMGBreastMarkDtl.MG_BREASTMARKDTL.MARK_ID = control.Name;
                    _processAddMGBreastMarkDtl.MG_BREASTMARKDTL.THICKNESS = (int)control.ShapeStrokeThickness;
                    _processAddMGBreastMarkDtl.Invoke();

                    //Mass Details
                    if (ms.IsUsMassDetail == "Y")
                    {
                        _processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.ACCESSION_NO = this.accession;
                        _processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.ARCHITECTURAL_DISTORTION_OBJECT_TYPE = ms.MassUSDetail.ARCHITECTURAL_DISTORTION_OBJECT_TYPE;
                        _processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.ARCHITECTURAL_DISTORTION_TYPE = ms.MassUSDetail.ARCHITECTURAL_DISTORTION_TYPE;
                        _processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.ASSOCIATE_FINDING_TYPE = ms.MassUSDetail.ASSOCIATE_FINDING_TYPE;
                        _processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.BREAST_TYPE = ms.MassUSDetail.BREAST_TYPE;
                        _processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.CREATED_BY = this.empId;
                        _processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.DISTRIBUTION_MODIFIER_DIFFUSE_SCATTERED = ms.MassUSDetail.DISTRIBUTION_MODIFIER_DIFFUSE_SCATTERED;
                        _processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.DISTRIBUTION_MODIFIER_GROUPED_OR_CLUSTERED = ms.MassUSDetail.DISTRIBUTION_MODIFIER_GROUPED_OR_CLUSTERED;
                        _processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.DISTRIBUTION_MODIFIER_LINEAR = ms.MassUSDetail.DISTRIBUTION_MODIFIER_LINEAR;
                        _processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.DISTRIBUTION_MODIFIER_REGIONAL = ms.MassUSDetail.DISTRIBUTION_MODIFIER_REGIONAL;
                        _processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.DISTRIBUTION_MODIFIER_SEGMENTAL = ms.MassUSDetail.DISTRIBUTION_MODIFIER_SEGMENTAL;
                        _processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.FINDING_TYPE = ms.MassUSDetail.FINDING_TYPE;
                        _processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.HIGHER_PROBABILITY_OF_MALIGNANCY_FINE_LINEAR = ms.MassUSDetail.HIGHER_PROBABILITY_OF_MALIGNANCY_FINE_LINEAR;
                        _processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.HIGHER_PROBABILITY_OF_MALIGNANCY_FINE_PLEOMORPHIC = ms.MassUSDetail.HIGHER_PROBABILITY_OF_MALIGNANCY_FINE_PLEOMORPHIC;
                        _processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.INTERMEDIATE_CONCERN_SUSPICIOUS_AMORPHOUS_OR_INDISTINCT = ms.MassUSDetail.INTERMEDIATE_CONCERN_SUSPICIOUS_AMORPHOUS_OR_INDISTINCT;
                        _processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.INTERMEDIATE_CONCERN_SUSPICIOUS_COARSE_HETEROGENOUS = ms.MassUSDetail.INTERMEDIATE_CONCERN_SUSPICIOUS_COARSE_HETEROGENOUS;
                        _processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.MASS_TYPE = ms.MassUSDetail.MASS_TYPE;
                        _processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.MASS_CYST_TYPE = ms.MassUSDetail.MASS_CYST_TYPE;
                        _processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.MASS_POSTERIOR_ACOUSTIC_FEATURES = ms.MassUSDetail.MASS_POSTERIOR_ACOUSTIC_FEATURES;
                        _processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.MASS_LOCATION_CLOCK = ms.MassUSDetail.MASS_LOCATION_CLOCK;
                        _processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.MASS_LOCATION_ON_IMAGE = ms.MassUSDetail.MASS_LOCATION_ON_IMAGE;
                        _processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.MASS_MARGIN = ms.MassUSDetail.MASS_MARGIN;
                        _processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.MASS_NO = ms.MassUSDetail.MASS_NO;
                        _processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.MASS_ORIENTATION = ms.MassUSDetail.MASS_ORIENTATION;
                        _processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.MASS_ECHO_PATTERN = ms.MassUSDetail.MASS_ECHO_PATTERN;
                        _processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.MASS_LESION_BOUNDARY = ms.MassUSDetail.MASS_LESION_BOUNDARY;
                        _processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.NO_OF_ARCHITECTURAL_DISTORTION = ms.MassUSDetail.NO_OF_ARCHITECTURAL_DISTORTION;
                        _processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.NO_OF_CALCIFICATION_OBJECTS = ms.MassUSDetail.NO_OF_CALCIFICATION_OBJECTS;
                        _processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.ORG_ID = this.orgId;
                        _processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.SPECIAL_CASE_NO_OF_ARCHITECTURAL_DISTORTION = ms.MassUSDetail.SPECIAL_CASE_NO_OF_ARCHITECTURAL_DISTORTION;
                        _processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.SPECIAL_CASE_TYPE = ms.MassUSDetail.SPECIAL_CASE_TYPE;
                        _processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.TYPE_OF_CALCIFICATION_OBJECT = ms.MassUSDetail.TYPE_OF_CALCIFICATION_OBJECT;
                        _processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.TYPICALLY_BENIGN_COARSE_OR_POPCORN_LIKE = ms.MassUSDetail.TYPICALLY_BENIGN_COARSE_OR_POPCORN_LIKE;
                        _processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.TYPICALLY_BENIGN_DYSTROPHIC = ms.MassUSDetail.TYPICALLY_BENIGN_DYSTROPHIC;
                        _processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.TYPICALLY_BENIGN_EGGSHELL_OR_RIM = ms.MassUSDetail.TYPICALLY_BENIGN_EGGSHELL_OR_RIM;
                        _processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.TYPICALLY_BENIGN_LARGE_ROD_LIKE = ms.MassUSDetail.TYPICALLY_BENIGN_LARGE_ROD_LIKE;
                        _processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.TYPICALLY_BENIGN_LUCENT_CENTERED = ms.MassUSDetail.TYPICALLY_BENIGN_LUCENT_CENTERED;
                        _processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.TYPICALLY_BENIGN_MILK_OF_CALCIUM = ms.MassUSDetail.TYPICALLY_BENIGN_MILK_OF_CALCIUM;
                        _processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.TYPICALLY_BENIGN_ROUND = ms.MassUSDetail.TYPICALLY_BENIGN_ROUND;
                        _processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.TYPICALLY_BENIGN_SKIN = ms.MassUSDetail.TYPICALLY_BENIGN_SKIN;
                        _processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.TYPICALLY_BENIGN_SUTURE = ms.MassUSDetail.TYPICALLY_BENIGN_SUTURE;
                        _processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.TYPICALLY_BENIGN_VASCULAR = ms.MassUSDetail.TYPICALLY_BENIGN_VASCULAR;
                        _processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.SIZE_X = ms.MassUSDetail.SIZE_X;
                        _processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.SIZE_Y = ms.MassUSDetail.SIZE_Y;
                        _processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.SIZE_Z = ms.MassUSDetail.SIZE_Z;
                        _processAddMGBreastUSMassDetails.MG_BREASTUSMASSDETAILS.ASSOCIATE_FINDING_TYPE_TEXT = ms.MassUSDetail.ASSOCIATE_FINDING_TYPE_TEXT;
                        _processAddMGBreastUSMassDetails.Invoke();
                    }
                    else
                    {
                        _processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.ACCESSION_NO = this.accession;
                        _processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.ARCHITECTURAL_DISTORTION_OBJECT_TYPE = ms.MassDetail.ARCHITECTURAL_DISTORTION_OBJECT_TYPE;
                        _processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.ARCHITECTURAL_DISTORTION_TYPE = ms.MassDetail.ARCHITECTURAL_DISTORTION_TYPE;
                        _processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.ASSOCIATE_FINDING_TYPE = ms.MassDetail.ASSOCIATE_FINDING_TYPE;
                        _processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.BREAST_TYPE = ms.MassDetail.BREAST_TYPE;
                        _processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.CREATED_BY = this.empId;
                        _processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.DISTRIBUTION_MODIFIER_DIFFUSE_SCATTERED = ms.MassDetail.DISTRIBUTION_MODIFIER_DIFFUSE_SCATTERED;
                        _processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.DISTRIBUTION_MODIFIER_GROUPED_OR_CLUSTERED = ms.MassDetail.DISTRIBUTION_MODIFIER_GROUPED_OR_CLUSTERED;
                        _processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.DISTRIBUTION_MODIFIER_LINEAR = ms.MassDetail.DISTRIBUTION_MODIFIER_LINEAR;
                        _processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.DISTRIBUTION_MODIFIER_REGIONAL = ms.MassDetail.DISTRIBUTION_MODIFIER_REGIONAL;
                        _processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.DISTRIBUTION_MODIFIER_SEGMENTAL = ms.MassDetail.DISTRIBUTION_MODIFIER_SEGMENTAL;
                        _processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.FINDING_TYPE = ms.MassDetail.FINDING_TYPE;
                        _processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.HIGHER_PROBABILITY_OF_MALIGNANCY_FINE_LINEAR = ms.MassDetail.HIGHER_PROBABILITY_OF_MALIGNANCY_FINE_LINEAR;
                        _processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.HIGHER_PROBABILITY_OF_MALIGNANCY_FINE_PLEOMORPHIC = ms.MassDetail.HIGHER_PROBABILITY_OF_MALIGNANCY_FINE_PLEOMORPHIC;
                        _processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.INTERMEDIATE_CONCERN_SUSPICIOUS_AMORPHOUS_OR_INDISTINCT = ms.MassDetail.INTERMEDIATE_CONCERN_SUSPICIOUS_AMORPHOUS_OR_INDISTINCT;
                        _processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.INTERMEDIATE_CONCERN_SUSPICIOUS_COARSE_HETEROGENOUS = ms.MassDetail.INTERMEDIATE_CONCERN_SUSPICIOUS_COARSE_HETEROGENOUS;
                        _processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.MASS_DENSITY = ms.MassDetail.MASS_DENSITY;
                        _processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.MASS_DENSITY_TYPE = ms.MassDetail.MASS_DENSITY_TYPE;
                        _processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.MASS_HAS_CALCIFICATION = ms.MassDetail.MASS_HAS_CALCIFICATION;
                        _processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.MASS_LOCATION_CLOCK = ms.MassDetail.MASS_LOCATION_CLOCK;
                        _processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.MASS_LOCATION_ON_IMAGE = ms.MassDetail.MASS_LOCATION_ON_IMAGE;
                        _processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.MASS_MARGIN = ms.MassDetail.MASS_MARGIN;
                        _processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.MASS_NO = ms.MassDetail.MASS_NO;
                        _processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.MASS_SHAPE = ms.MassDetail.MASS_SHAPE;
                        _processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.NO_OF_ARCHITECTURAL_DISTORTION = ms.MassDetail.NO_OF_ARCHITECTURAL_DISTORTION;
                        _processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.NO_OF_CALCIFICATION_OBJECTS = ms.MassDetail.NO_OF_CALCIFICATION_OBJECTS;
                        _processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.ORG_ID = this.orgId;
                        _processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.SPECIAL_CASE_NO_OF_ARCHITECTURAL_DISTORTION = ms.MassDetail.SPECIAL_CASE_NO_OF_ARCHITECTURAL_DISTORTION;
                        _processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.SPECIAL_CASE_TYPE = ms.MassDetail.SPECIAL_CASE_TYPE;
                        _processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.TYPE_OF_CALCIFICATION_OBJECT = ms.MassDetail.TYPE_OF_CALCIFICATION_OBJECT;
                        _processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.TYPICALLY_BENIGN_COARSE_OR_POPCORN_LIKE = ms.MassDetail.TYPICALLY_BENIGN_COARSE_OR_POPCORN_LIKE;
                        _processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.TYPICALLY_BENIGN_DYSTROPHIC = ms.MassDetail.TYPICALLY_BENIGN_DYSTROPHIC;
                        _processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.TYPICALLY_BENIGN_EGGSHELL_OR_RIM = ms.MassDetail.TYPICALLY_BENIGN_EGGSHELL_OR_RIM;
                        _processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.TYPICALLY_BENIGN_LARGE_ROD_LIKE = ms.MassDetail.TYPICALLY_BENIGN_LARGE_ROD_LIKE;
                        _processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.TYPICALLY_BENIGN_LUCENT_CENTERED = ms.MassDetail.TYPICALLY_BENIGN_LUCENT_CENTERED;
                        _processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.TYPICALLY_BENIGN_MILK_OF_CALCIUM = ms.MassDetail.TYPICALLY_BENIGN_MILK_OF_CALCIUM;
                        _processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.TYPICALLY_BENIGN_ROUND = ms.MassDetail.TYPICALLY_BENIGN_ROUND;
                        _processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.TYPICALLY_BENIGN_SKIN = ms.MassDetail.TYPICALLY_BENIGN_SKIN;
                        _processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.TYPICALLY_BENIGN_SUTURE = ms.MassDetail.TYPICALLY_BENIGN_SUTURE;
                        _processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.TYPICALLY_BENIGN_VASCULAR = ms.MassDetail.TYPICALLY_BENIGN_VASCULAR;
                        _processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.SIZE_X = ms.MassDetail.SIZE_X;
                        _processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.SIZE_Y = ms.MassDetail.SIZE_Y;
                        _processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.SIZE_Z = ms.MassDetail.SIZE_Z;
                        _processAddMGBreastMassDetails.MG_BREASTMASSDETAILS.ASSOCIATE_FINDING_TYPE_TEXT = ms.MassDetail.ASSOCIATE_FINDING_TYPE_TEXT;
                        _processAddMGBreastMassDetails.Invoke();
                    }
                }
                #endregion

                #region Comparison
                //comparison
                ProcessDeleteMGPatientHistoryComparison _processDeleteComparison = new ProcessDeleteMGPatientHistoryComparison();
                _processDeleteComparison.UseTransaction = true;
                _processDeleteComparison.Transaction = transaction;
                _processDeleteComparison.MG_PATIENTHISTORYCOMPARISON.COMPARING_EXAM = this.accession;
                _processDeleteComparison.Invoke();

                ProcessAddMGPatientHistoryComparison _processAddComparison = new ProcessAddMGPatientHistoryComparison();
                _processAddComparison.UseTransaction = true;
                _processAddComparison.Transaction = transaction;
                if (this.rdConpareType.EditValue.ToString() == "S")
                {
                    DataRow[] compasionRows = this.dsExamResultHistory.Tables[0].Select("SELECT = 'Y'");
                    foreach (DataRow dr in compasionRows)
                    {
                        _processAddComparison.MG_PATIENTHISTORYCOMPARISON.COMPARED_TYPE = "S";
                        _processAddComparison.MG_PATIENTHISTORYCOMPARISON.COMPARED_BY = this.empId;
                        //processAddMgPatientHistoryComparison.MG_PATIENTHISTORYCOMPARISON.COMPARED_TEXT = this.mmComparisonText.Text;
                        _processAddComparison.MG_PATIENTHISTORYCOMPARISON.COMPARED_WITH = dr["ACCESSION_NO"].ToString();
                        _processAddComparison.MG_PATIENTHISTORYCOMPARISON.COMPARING_EXAM = this.accession;
                        _processAddComparison.MG_PATIENTHISTORYCOMPARISON.CREATED_BY = this.empId;
                        _processAddComparison.MG_PATIENTHISTORYCOMPARISON.ORG_ID = this.orgId;
                        _processAddComparison.MG_PATIENTHISTORYCOMPARISON.REG_ID = Convert.ToInt32(this.dsDemographic.Tables[0].Rows[0]["REG_ID"]);
                        _processAddComparison.Invoke();
                    }
                }
                else
                {
                    _processAddComparison.MG_PATIENTHISTORYCOMPARISON.COMPARED_TYPE = "F";
                    _processAddComparison.MG_PATIENTHISTORYCOMPARISON.COMPARED_BY = this.empId;
                    _processAddComparison.MG_PATIENTHISTORYCOMPARISON.COMPARED_TEXT = this.mmComparisonText.Text;
                    _processAddComparison.MG_PATIENTHISTORYCOMPARISON.COMPARING_EXAM = this.accession;
                    //processAddMgPatientHistoryComparison.MG_PATIENTHISTORYCOMPARISON.COMPARING_EXAM = dr["ACCESSION_NO"].ToString();
                    _processAddComparison.MG_PATIENTHISTORYCOMPARISON.CREATED_BY = this.empId;
                    _processAddComparison.MG_PATIENTHISTORYCOMPARISON.ORG_ID = this.orgId;
                    _processAddComparison.MG_PATIENTHISTORYCOMPARISON.REG_ID = Convert.ToInt32(this.dsDemographic.Tables[0].Rows[0]["REG_ID"]);
                    _processAddComparison.Invoke();
                }
                #endregion

                #region Dominant Cysts
                ProcessDeleteMGMassDominantCyst _processDeleteDominantCyst = new ProcessDeleteMGMassDominantCyst();
                _processDeleteDominantCyst.UseTransaction = true;
                _processDeleteDominantCyst.Transaction = transaction;
                _processDeleteDominantCyst.MG_MASSDOMINANTCYST.ACCESSION_NO = this.accession;
                _processDeleteDominantCyst.MG_MASSDOMINANTCYST.ORG_ID = this.orgId;
                _processDeleteDominantCyst.Invoke();

                ProcessAddMGMassDominantCyst _processAddMGMassDominantCyst = new ProcessAddMGMassDominantCyst();
                _processAddMGMassDominantCyst.UseTransaction = true;
                _processAddMGMassDominantCyst.Transaction = transaction;

                if (this.multiChk_mass.Checked)
                {
                    if (this.dsDominantList != null)
                        if (this.dsDominantList.Tables.Count > 0)
                        {
                            for (int i = 0; i < this.dsDominantList.Tables[0].Rows.Count; i++)
                            {
                                _processAddMGMassDominantCyst.MG_MASSDOMINANTCYST.ACCESSION_NO = this.accession;
                                _processAddMGMassDominantCyst.MG_MASSDOMINANTCYST.MASS_NO = Convert.ToInt32(this.dsDominantList.Tables[0].Rows[i]["MASS_NO"]);
                                _processAddMGMassDominantCyst.MG_MASSDOMINANTCYST.CLOCK_LOCATION = Convert.ToInt32(this.dsDominantList.Tables[0].Rows[i]["LOCATION"]);
                                _processAddMGMassDominantCyst.MG_MASSDOMINANTCYST.DIAMETER = Convert.ToInt32(this.dsDominantList.Tables[0].Rows[i]["SIZE"]);
                                _processAddMGMassDominantCyst.MG_MASSDOMINANTCYST.SIDE = this.dsDominantList.Tables[0].Rows[0]["BREAST_VIEW"].ToString();
                                _processAddMGMassDominantCyst.MG_MASSDOMINANTCYST.IS_DOMINANT_CYST = "N";
                                _processAddMGMassDominantCyst.MG_MASSDOMINANTCYST.ORG_ID = this.orgId;
                                _processAddMGMassDominantCyst.MG_MASSDOMINANTCYST.CREATED_BY = this.empId;
                                _processAddMGMassDominantCyst.Invoke();
                            }

                            for (int i = 0; i < this.dsDominantList.Tables[1].Rows.Count; i++)
                            {
                                _processAddMGMassDominantCyst.MG_MASSDOMINANTCYST.ACCESSION_NO = this.accession;
                                _processAddMGMassDominantCyst.MG_MASSDOMINANTCYST.MASS_NO = Convert.ToInt32(this.dsDominantList.Tables[1].Rows[i]["MASS_NO"]);
                                _processAddMGMassDominantCyst.MG_MASSDOMINANTCYST.CLOCK_LOCATION = Convert.ToInt32(this.dsDominantList.Tables[1].Rows[i]["LOCATION"]);
                                _processAddMGMassDominantCyst.MG_MASSDOMINANTCYST.DIAMETER = Convert.ToInt32(this.dsDominantList.Tables[1].Rows[i]["SIZE"]);
                                _processAddMGMassDominantCyst.MG_MASSDOMINANTCYST.SIDE = this.dsDominantList.Tables[1].Rows[0]["BREAST_VIEW"].ToString();
                                _processAddMGMassDominantCyst.MG_MASSDOMINANTCYST.IS_DOMINANT_CYST = "Y";
                                //_processAddMGMassDominantCyst.MG_MASSDOMINANTCYST.BREAST_MARKDTL_ID = processAddMGBreastMark.MG_BREASTMARK.BREAST_MARK_ID;
                                _processAddMGMassDominantCyst.MG_MASSDOMINANTCYST.ORG_ID = this.orgId;
                                _processAddMGMassDominantCyst.MG_MASSDOMINANTCYST.CREATED_BY = this.empId;
                                _processAddMGMassDominantCyst.Invoke();
                            }
                        }
                }
                #endregion

                transaction.Commit();
                connection.Close();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// This method use to get radiologist assigned id 
        /// </summary>
        /// <param name="reportStatusText"></param>
        /// <returns></returns>
        private int CheckAssignTo(string reportStatusText)
        {
            int _assigned_to = 0;
            //Get User Authentication
            DataTable dtAssign = this.GetAuthenticationDataTable(env.UserID);
            dtAssign.AcceptChanges();
            if (dtAssign.Rows.Count > 0)
                if (dtAssign.Rows[0]["AUTH_LEVEL_ID"].ToString() == "3")
                {
                    if (reportStatusText == "FINALIZE")
                    {
                        if (dtAssign.Rows[0]["JOB_TITLE_UID"].ToString() == "RAD001")
                            _assigned_to = env.UserID;
                        else if (dtAssign.Rows[0]["JOB_TITLE_UID"].ToString() == "FEL001")
                            _assigned_to = env.UserID;
                        else if (dtAssign.Rows[0]["JOB_TITLE_UID"].ToString() == "FEL002")
                            _assigned_to = env.UserID;
                        else if (dtAssign.Rows[0]["JOB_TITLE_UID"].ToString() == "DEN003")
                            _assigned_to = env.UserID;
                    }
                    else
                    {
                        if (dtAssign.Rows[0]["JOB_TITLE_UID"].ToString() == "RAD001")
                            _assigned_to = env.UserID;
                        else if (dtAssign.Rows[0]["JOB_TITLE_UID"].ToString() == "FEL001")
                            _assigned_to = env.UserID;
                        else if (dtAssign.Rows[0]["JOB_TITLE_UID"].ToString() == "FEL002")
                            _assigned_to = env.UserID;
                    }
                }
            dtAssign = null;
            return _assigned_to;
        }

        /// <summary>
        /// This method use to get radiologist finalized id
        /// </summary>
        /// <returns>finalize id</returns>
        private int GetRadiologistFinalizedId()
        {
            int finalizeId = env.UserID;
            if (env.AuthLevelID != "3")
            {
                RadioFinal radio = new RadioFinal();
                if (DialogResult.Cancel == radio.ShowDialog())
                    return 0;
                //insertIntoSetupTemp2(radio.FinalizeID);
                finalizeId = radio.FinalizeID;
                //finalName = radio.FinalizedName;
                //finalName = finalName + "\r\n" + radio.FinalizedName + ",M.D.(" + radio.Finalized_UID + ")" + "\r\n Radiologist";
                radio.Dispose();
            }
            return finalizeId;
        }

        /// <summary>
        /// This method use to get radiologist group
        /// </summary>
        /// <returns>radiologist group name</returns>
        private string GetRadGroupName()
        {
            string _groupName = string.Empty;
            string _finalName = string.Empty;

            ProcessGetHREmp geHr = new ProcessGetHREmp();
            geHr.HR_EMP.MODE = "select_All_Active";
            geHr.Invoke();
            DataTable dtHr = new DataTable();
            dtHr = geHr.Result.Tables[0];

            if (this.dtRadiologistGroup.Rows.Count > 0)
            {
                foreach (DataRow dr in this.dtRadiologistGroup.Rows)
                {
                    DataTable dtAuthe = this.GetAuthenticationDataTable(Convert.ToInt32(dr["RAD_ID"]));
                    if (dtAuthe.Rows.Count > 0)
                    {
                        if (dtAuthe.Rows[0]["AUTH_LEVEL_ID"].ToString() == "3")
                        {
                            DataRow[] drAssign = dtHr.Select("EMP_ID=" + dr["RAD_ID"].ToString());
                            _finalName = string.IsNullOrEmpty(drAssign[0]["FNAME_ENG"].ToString()) ? drAssign[0]["FNAME"].ToString().Trim() : drAssign[0]["FNAME_ENG"].ToString().Trim();
                            _finalName += " ";
                            _finalName += string.IsNullOrEmpty(drAssign[0]["LNAME_ENG"].ToString()) ? drAssign[0]["LNAME"].ToString().Trim() : drAssign[0]["LNAME_ENG"].ToString().Trim();
                            _finalName += ", M.D.(" + drAssign[0]["EMP_UID"].ToString() + ")";

                            if (dtAuthe.Rows[0]["JOB_TITLE_UID"].ToString() == "RAD001")
                                _groupName += _finalName + " Radiologist\r\n";
                            else if (dtAuthe.Rows[0]["JOB_TITLE_UID"].ToString() == "FEL001")
                                _groupName += _finalName + " Radiologist\r\n";
                            else if (dtAuthe.Rows[0]["JOB_TITLE_UID"].ToString() == "FEL002")
                                _groupName += _finalName + " Radiologist\r\n";
                            else
                                _groupName += _finalName + "\r\n";
                        }
                        else
                        {
                            DataRow[] drAssign = dtHr.Select("EMP_ID=" + dr["RAD_ID"].ToString());
                            _finalName = string.IsNullOrEmpty(drAssign[0]["FNAME_ENG"].ToString()) ? drAssign[0]["FNAME"].ToString().Trim() : drAssign[0]["FNAME_ENG"].ToString().Trim();
                            _finalName += " ";
                            _finalName += string.IsNullOrEmpty(drAssign[0]["LNAME_ENG"].ToString()) ? drAssign[0]["LNAME"].ToString().Trim() : drAssign[0]["LNAME_ENG"].ToString().Trim();
                            _finalName += ", M.D.(" + drAssign[0]["EMP_UID"].ToString() + ")";
                            _groupName += _finalName + "\r\n";
                        }

                    }
                }
            }

            return _groupName;
        }

        /// <summary>
        /// This method use to set up serverity form with unit and exam id
        /// </summary>
        /// <returns></returns>
        private int ShowSeverityLookUp()
        {
            int severityId = 0;
            int unit_id = 1; //default unit id
            //Get unit id by exam id
            DataRow[] drEx = RISBaseData.Ris_Exam().Select("EXAM_ID=" + this.drCaseData["EXAM_ID"].ToString());
            if (drEx.Length > 0)
                unit_id = string.IsNullOrEmpty(drEx[0]["UNIT_ID"].ToString()) ? 1 : Convert.ToInt32(drEx[0]["UNIT_ID"].ToString());
            
            ProcessGetRISExamresultseverity prc = new ProcessGetRISExamresultseverity();
            prc.RIS_EXAMRESULTSEVERITY.UNIT_ID = unit_id;
            prc.Invoke();
            DataSet dsSeverity = prc.Result;
            LookupData lv = new LookupData();

            lv.ValueUpdated += (s, e) => {
                string[] value = e.NewValue.Split(new Char[] { '^' });
                if (value.Length > 0)
                    severityId = Convert.ToInt32(value[0]);
            };
            lv.AddColumn("SEVERITY_ID", "SEVERITY_ID", false, true);
            lv.AddColumn("SEVERITY_NAME", "Severity Name", true, true);
            lv.AddColumn("SEVERITY_LABEL", "Severity Lable", true, true);
            lv.Text = "Severity List";
            lv.Data = dsSeverity.Tables[0];

            Size ss = new Size(510, 300);
            lv.Size = ss;
            lv.StartPosition = FormStartPosition.CenterScreen;
            lv.ShowBox();

            return severityId;
        }

        #endregion

        #region Editer Event

        #region Significant For US
        /// <summary>
        /// Posterior Acoustic Features
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void US_rdPosteriorAcousticFeatures_EditValueChanged(object sender, EventArgs e)
        {
            if (this.current_mass_us_detail != null)
                this.current_mass_us_detail.MASS_POSTERIOR_ACOUSTIC_FEATURES = this.US_rdPosteriorAcousticFeatures.EditValue.ToString();
        }

        /// <summary>
        /// Orientation of Mass
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void US_rdOrientationOfMass_EditValueChanged(object sender, EventArgs e)
        {
            if (this.current_mass_us_detail != null)
                this.current_mass_us_detail.MASS_ORIENTATION = this.US_rdOrientationOfMass.EditValue.ToString();
        }

        /// <summary>
        /// Mass Type for US
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void US_rdMassType_EditValueChanged(object sender, EventArgs e)
        {
            if (this.current_mass_us_detail != null)
                this.current_mass_us_detail.MASS_CYST_TYPE = this.US_rdMassType.EditValue.ToString();
            if (this.US_rdMassType.EditValue == null || this.US_rdMassType.EditValue.Equals(string.Empty) || !this.US_rdMassType.EditValue.Equals("D"))
                this.SetGroupOfSoildMassEnable(false);
            else
                this.SetGroupOfSoildMassEnable(true);
        }

        /// <summary>
        /// Margin For US
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void US_rdMargin_EditValueChanged(object sender, EventArgs e)
        {
            if (this.current_mass_us_detail != null)
                this.current_mass_us_detail.MASS_MARGIN = this.US_rdMargin.EditValue.ToString();
            switch (this.current_mass_us_detail.MASS_MARGIN)
            {
                case "C": this._selectedShapeControl.Shape = CShapeControl.Shapes.Circumscribed; break;
                case "O": this._selectedShapeControl.Shape = CShapeControl.Shapes.Obscured; break;
                case "S": this._selectedShapeControl.Shape = CShapeControl.Shapes.Spiculated; break;
                case "M": this._selectedShapeControl.Shape = CShapeControl.Shapes.Microlobulated; break;
                case "I": this._selectedShapeControl.Shape = CShapeControl.Shapes.Indistinct; break;
                case "A": this._selectedShapeControl.Shape = CShapeControl.Shapes.Circumscribed; break;
            }
        }



        /// <summary>
        /// Lesion Boundary 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void US_rdLesionBoundary_EditValueChanged(object sender, EventArgs e)
        {
            if (this.current_mass_us_detail != null)
                this.current_mass_us_detail.MASS_LESION_BOUNDARY = this.US_rdLesionBoundary.EditValue.ToString();
        }

        /// <summary>
        /// Echo Pattern 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void US_rdEchoPattern_EditValueChanged(object sender, EventArgs e)
        {
            if (this.current_mass_us_detail != null)
                this.current_mass_us_detail.MASS_ECHO_PATTERN = this.US_rdEchoPattern.EditValue.ToString();
        }
        #endregion

        #region  Significant For Mammogram

        /// <summary>
        /// Shape
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Sign_rbShape_EditValueChanged(object sender, EventArgs e)
        {
            if (this.current_mass_detail != null)
                this.current_mass_detail.MASS_SHAPE = this.Sign_rbShape.EditValue.ToString();
        }

        /// <summary>
        /// Density Type
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Sign_rdDensity_EditValueChanged(object sender, EventArgs e)
        {
            if (this.current_mass_detail != null)
            {
                this.current_mass_detail.MASS_DENSITY_TYPE = this.Sign_rdDensity.EditValue.ToString();
                if (this.current_mass_detail.MASS_DENSITY_TYPE != string.Empty)
                    this.current_mass_detail.MASS_DENSITY = "Y";
            }
            if (this.Sign_rdDensity.EditValue == null || this.Sign_rdDensity.EditValue.Equals(string.Empty))
                this.Sign_rbWith_Calcification.Enabled = false;
            else
                this.Sign_rbWith_Calcification.Enabled = true;
        }

        /// <summary>
        /// Density with fat
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Sign_rbWith_Calcification_EditValueChanged(object sender, EventArgs e)
        {
            if (this.current_mass_detail != null)
            {
                this.current_mass_detail.MASS_HAS_CALCIFICATION = this.Sign_rbWith_Calcification.EditValue.ToString();
            }
        }

        /// <summary>
        /// Margin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Sign_rbMagin_EditValueChanged(object sender, EventArgs e)
        {
            if (this.current_mass_detail != null)
            {
                this.current_mass_detail.MASS_MARGIN = this.Sign_rbMagin.EditValue.ToString();
                switch (this.current_mass_detail.MASS_MARGIN)
                {
                    case "C": this._selectedShapeControl.Shape = CShapeControl.Shapes.Circumscribed; break;
                    case "O": this._selectedShapeControl.Shape = CShapeControl.Shapes.Obscured; break;
                    case "S": this._selectedShapeControl.Shape = CShapeControl.Shapes.Spiculated; break;
                    case "M": this._selectedShapeControl.Shape = CShapeControl.Shapes.Microlobulated; break;
                    case "I": this._selectedShapeControl.Shape = CShapeControl.Shapes.Indistinct; break;
                }
            }
        }
        #endregion

        #region Multiple
        /// <summary>
        /// Multiple cyst
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void multiChk_Cyst_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (IsLoading)
                return;
            string msg = string.Empty;
            if (!(bool)e.NewValue)
            {
                msg = myMessageBox.ShowAlert("UID6052", language);
                if (msg == "2")
                { 
                    //ok
                    if(this.dominantCystList != null)
                        this.dsDominantList.Tables[1].Rows.Clear();
                }
                else
                    e.Cancel = true;
            }
            else
            {
                DialogResult dlg = this.dominantCystList.ShowDialog(this.markerList
                    , this.dsDominantList
                    , this.IsReadOnly
                    , BiradDominantCystList.DominantTypes.Cyst);
                if (dlg == DialogResult.OK)
                {
                    this.dsDominantList = this.dominantCystList.GetDominantDataSet();
                    this.Finding_btnDominantCysts.Enabled = true;
                }
                //else
                //{
                //    if (this.dsDominantList.Tables[1].Rows.Count == 0)
                //        this.multiChk_Cyst.Checked = false;
                //}
            }
        }

        /// <summary>
        /// Multiple item click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void multiChk_mass_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (IsLoading)
                return;
            string msg = string.Empty;
            if (!(bool)e.NewValue)
            {
                msg = myMessageBox.ShowAlert("UID6051", language);
                if (msg == "2")
                {
                    if(this.dsDominantList != null)
                    //ok
                        this.dsDominantList.Tables[0].Rows.Clear();
                }
                else
                    e.Cancel = true;
            }
            else
            {
                DialogResult dlg = this.dominantCystList.ShowDialog(this.markerList
                    , this.dsDominantList
                    , this.IsReadOnly
                    , BiradDominantCystList.DominantTypes.Mass);
                if (dlg == DialogResult.OK)
                {
                    this.dsDominantList = this.dominantCystList.GetDominantDataSet();
                    this.Finding_btnDominantCysts.Enabled = true;
                }
                //else
                //{
                //    if (this.dsDominantList.Tables[0].Rows.Count == 0)
                //        this.multiChk_Cyst.Checked = false;
                //}
            }
        }

        /// <summary>
        /// Show dominant Cysts Dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Finding_btnDominantCysts_Click(object sender, EventArgs e)
        {
            if (this.dominantCystList != null)
            {
                if (this.dsDominantList != null)
                {
                    if (this.dsDominantList.Tables.Count > 0)
                    {
                        if (this.dsDominantList.Tables[0].Rows.Count > 0)
                        {
                            DialogResult result = this.dominantCystList.ShowDialog(markerList, this.dsDominantList, this.IsReadOnly, BiradDominantCystList.DominantTypes.Mass);
                            if (result == DialogResult.OK)
                            {
                                this.dsDominantList = this.dominantCystList.GetDominantDataSet();
                            }
                        }
                        else
                        {
                            this.ShowDominantDialogWithOutOldData();
                        }
                    }
                    else
                        this.ShowDominantDialogWithOutOldData();
                }
                else
                    this.ShowDominantDialogWithOutOldData();
            }
        }
        #endregion

        #region MG or US
        /// <summary>
        /// Switch to mammogram or ultrasould detail
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Sign_rdMassViewType_EditValueChanged(object sender, EventArgs e)
        {
            if (Sign_rdMassViewType.EditValue.ToString() == "M")
            {
                this.layoutForSignificant.MinSize = new Size(980, 120);
                this.layoutForSignificant.MaxSize = new Size(980, 120);
                this.Sign_pnForUSDtl.MinimumSize = new Size(973, 58);
                this.Sign_pnForUSDtl.Visible = false;
                this.current_markStruct.IsUsMassDetail = "N";
                this.txtMassViewType.Caption = "For: MG";
                this.rbPageGroupForMammogram.Visible = true;
                this.rbPageGroupUltrasound.Visible = false;
                //this.SetFindingTypeEnable(true); //enable finding Type combobox
            }
            else
            {
                this.layoutForSignificant.MinSize = new Size(980, 150);
                this.layoutForSignificant.MaxSize = new Size(980, 150);
                this.Sign_pnForUSDtl.MinimumSize = new Size(973, 118);
                this.Sign_pnForUSDtl.Visible = true;
                this.current_markStruct.IsUsMassDetail = "Y";
                this.txtMassViewType.Caption = "For: US";
                this.rbPageGroupForMammogram.Visible = false;
                this.rbPageGroupUltrasound.Visible = true;
                //this.SetFindingTypeEnable(false); //disable finding Type combobox
            }
        }
        #endregion

        #region Finding
        /// <summary>
        /// Finding Type
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Sign_cbFindingType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SetFindingType(this.Sign_cbFindingType.SelectedIndex);
        }

        private void SetFindingType(int p)
        {
            if (this.current_mass_detail != null || this.current_mass_us_detail != null)
            {
                if (this.current_markStruct.IsUsMassDetail != "Y")
                {
                    this.current_mass_detail.FINDING_TYPE = EditValueConvertor.GetFindingTypeValue(this.Sign_cbFindingType.SelectedIndex);
                    if (this.current_mass_detail.FINDING_TYPE == "B")
                    {
                        this._selectedShapeControl.Shape = CShapeControl.Shapes.Calcification;
                        this.groupMass.Expanded = false;
                        this.groupCalcification.Expanded = true;
                        this.groupArchiteturalDistortion.Expanded = false;
                        this.Sign_rbMagin.EditValue = string.Empty;

                        this.SetGroupOfMGMassEnable(false); //disable MG Mass group
                        this.SetGroupOfCalcificationEnable(true, false); //enable calcification group
                        this.SetGroupOfArchitecturalEnable(false, false); //disable group of architech

                    }
                    else if (this.current_mass_detail.FINDING_TYPE == "D")
                    {
                        this._selectedShapeControl.Shape = CShapeControl.Shapes.Architectural;
                        this.groupMass.Expanded = false;
                        this.groupCalcification.Expanded = false;
                        this.groupArchiteturalDistortion.Expanded = true;
                        this.Sign_rbMagin.EditValue = string.Empty;

                        this.SetGroupOfMGMassEnable(false); //disable MG Mass group
                        this.SetGroupOfCalcificationEnable(false, false); //disable calcification group
                        this.SetGroupOfArchitecturalEnable(true, true); //enable group of architech
                    }
                    else if (this.current_mass_detail.FINDING_TYPE == "E")
                    {
                        this._selectedShapeControl.Shape = CShapeControl.Shapes.Asymmetric;
                        this.groupMass.Expanded = false;
                        this.groupCalcification.Expanded = false;
                        this.groupArchiteturalDistortion.Expanded = false;
                        this.Sign_rbMagin.EditValue = string.Empty;

                        this.SetGroupOfMGMassEnable(false); //disable MG Mass group
                        this.SetGroupOfCalcificationEnable(false, false); //disable calcification group
                        this.SetGroupOfArchitecturalEnable(false, false); //disable group of architech
                    }
                    else
                    {
                        switch (this.current_mass_detail.MASS_MARGIN)
                        {
                            case "D": _selectedShapeControl.Shape = CShapeControl.Shapes.Circumscribed; break;
                            case "F": _selectedShapeControl.Shape = CShapeControl.Shapes.Microlobulated; break;
                            case "G": _selectedShapeControl.Shape = CShapeControl.Shapes.Obscured; break;
                            case "H": _selectedShapeControl.Shape = CShapeControl.Shapes.Spiculated; break;
                            case "E": _selectedShapeControl.Shape = CShapeControl.Shapes.Indistinct; break;
                            default: _selectedShapeControl.Shape = CShapeControl.Shapes.Circumscribed; break;
                        }
                        this.groupMass.Expanded = true;
                        this.groupCalcification.Expanded = false;
                        this.SetGroupOfCalcificationEnable(false, false); //disable calcification group
                        this.groupArchiteturalDistortion.Expanded = false;
                        this.SetGroupOfMGMassEnable(true); //enable MG Mass group
                        this.SetGroupOfArchitecturalEnable(false, false); //disable group of architech
                    }
                }
                else
                {
                    this.current_mass_us_detail.FINDING_TYPE = EditValueConvertor.GetFindingTypeValue(this.Sign_cbFindingType.SelectedIndex);
                    if (this.current_mass_us_detail.FINDING_TYPE == "B")
                    {
                        this._selectedShapeControl.Shape = CShapeControl.Shapes.Calcification;
                        this.groupMass.Expanded = false;
                        this.groupCalcification.Expanded = true;
                        this.groupArchiteturalDistortion.Expanded = false;
                        this.Sign_rbMagin.EditValue = string.Empty;

                        this.SetGroupOfMGMassEnable(false); //disable MG Mass group
                        this.SetGroupOfCalcificationEnable(true, false); //enable calcification group
                        this.SetGroupOfArchitecturalEnable(false, false); //disable group of architech

                    }
                    else if (this.current_mass_us_detail.FINDING_TYPE == "D")
                    {
                        this._selectedShapeControl.Shape = CShapeControl.Shapes.Architectural;
                        this.groupMass.Expanded = false;
                        this.groupCalcification.Expanded = false;
                        this.groupArchiteturalDistortion.Expanded = true;
                        this.Sign_rbMagin.EditValue = string.Empty;

                        this.SetGroupOfMGMassEnable(false); //disable MG Mass group
                        this.SetGroupOfCalcificationEnable(false, false); //disable calcification group
                        this.SetGroupOfArchitecturalEnable(true, true); //enable group of architech
                    }
                    else if (this.current_mass_us_detail.FINDING_TYPE == "E")
                    {
                        this._selectedShapeControl.Shape = CShapeControl.Shapes.Asymmetric;
                        this.groupMass.Expanded = false;
                        this.groupCalcification.Expanded = false;
                        this.groupArchiteturalDistortion.Expanded = false;
                        this.Sign_rbMagin.EditValue = string.Empty;

                        this.SetGroupOfMGMassEnable(false); //disable MG Mass group
                        this.SetGroupOfCalcificationEnable(false, false); //disable calcification group
                        this.SetGroupOfArchitecturalEnable(false, false); //disable group of architech
                    }
                    else
                    {
                        this._selectedShapeControl.Shape = CShapeControl.Shapes.Circumscribed;
                        this.groupMass.Expanded = true;
                        this.groupCalcification.Expanded = false;
                        this.SetGroupOfCalcificationEnable(false, false); //disable calcification group
                        this.groupArchiteturalDistortion.Expanded = false;
                        this.SetGroupOfMGMassEnable(true); //enable MG Mass group
                        this.SetGroupOfArchitecturalEnable(false, false); //disable group of architech
                    }
                }
            }
        }

        /// <summary>
        /// Show Diminant Dialog with out old data()
        /// </summary>
        private void ShowDominantDialogWithOutOldData()
        {
            DialogResult result = this.dominantCystList.ShowDialog(markerList, this.IsReadOnly, BiradDominantCystList.DominantTypes.Mass);
            if (result == DialogResult.OK)
            {
                this.dsDominantList = this.dominantCystList.GetDominantDataSet();
            }
        }

        /// <summary>
        /// Recommendation Combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Finding_cbRecommendation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Finding_cbRecommendation.SelectedIndex == 7)
            {
                this.Finding_cbRecommendation.Size = new Size(70, 20);
                this.Finding_tbRecommendationOther.Focus();
            }
            else
            {
                this.Finding_cbRecommendation.Size = new Size(242, 20);
            }
        }

        private void Finding_cbFinalassessment_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Finding_cbRecommendation.Properties.Items.Clear();

            //Switch Case
            switch (this.Finding_cbFinalassessment.SelectedIndex)
            {
                case 1: this.Finding_cbRecommendation.Properties.Items.AddRange(new string[] 
                {
                    "Appropriate Action Should Be Taken"
                }); 
                break;
                case 2: this.Finding_cbRecommendation.Properties.Items.AddRange(new string[] 
                {
                    "Annual Mammogram"
                    , "Annual Mammogram and Ultrasound"
                });
                break;
                case 3: this.Finding_cbRecommendation.Properties.Items.AddRange(new string[] 
                {
                    "Annual Mammogram"
                    , "Annual Mammogram and Ultrasound"
                });
                break;
                case 4: this.Finding_cbRecommendation.Properties.Items.AddRange(new string[] 
                {
                    "Mammogram 6 Months"
                    , "Ultrasound 6 Months"
                    , "Mammogram and Ultrasound 6 Months"
                });
                break;
                case 5: this.Finding_cbRecommendation.Properties.Items.AddRange(new string[] 
                {
                    "Biopsy Should be Considered"
                    //, "Annual Mammogram and Ultrasound"
                });
                break;
                case 6: this.Finding_cbRecommendation.Properties.Items.AddRange(new string[] 
                {
                    "Biopsy Should be Considered"
                });
                break;
                case 7: this.Finding_cbRecommendation.Properties.Items.AddRange(new string[] 
                {
                    "Biopsy Should be Considered"
                });
                break;
                case 8: this.Finding_cbRecommendation.Properties.Items.AddRange(new string[] 
                {
                    "Appropriate Action Should Be Taken"
                });
                break;
                case 9: this.Finding_cbRecommendation.Properties.Items.AddRange(new string[] 
                {
                    "Appropriate Action Should Be Taken"
                });
                break;
                default: this.Finding_cbRecommendation.Properties.Items.Add("(Select)"); break;
            }
            this.Finding_cbRecommendation.SelectedIndex = 0;
            if (this.Finding_cbFinalassessment.SelectedIndex == 7 || this.Finding_cbFinalassessment.SelectedIndex == 8)
            {
                this.Img_chkLeft.Checked = true;
                this.Img_chkRight.Checked = true;
            }
            else
            {
                this.Img_chkLeft.Checked = false;
                this.Img_chkRight.Checked = false;
            }
        }

        /// <summary>
        /// Personal History of breast cancer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Finding_rdPersonal_History_of_breast_cancer_EditValueChanged(object sender, EventArgs e)
        {
            if (this.Finding_rdPersonal_History_of_breast_cancer.EditValue.ToString() == "N")
                this.Finding_rdPersonal_History_of_breast_cancer_view.Visible = false;
            else
                this.Finding_rdPersonal_History_of_breast_cancer_view.Visible = true;
        }


        /// <summary>
        /// final asscessment selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void Finding_cbFinalassessment_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (Finding_cbFinalassessment.SelectedIndex != 0)
        //        this.Finding_tbFinalAssessmentDesc.Text = TextGenerator.Final_assessmentSet[Finding_cbFinalassessment.SelectedIndex];
        //}
        #endregion

        #region Patient Type
        /// <summary>
        /// Patient Type
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Find_cbPatient_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Find_cbPatient_Type.SelectedIndex == 9)
            {
                this.Find_cbPatient_Type.Size = new Size(70, 20);
                this.Finding_tbPatientTypeOther.Focus();
            }
            else
            {
                this.Find_cbPatient_Type.Size = new Size(242, 20);
                this.Find_txtPatient_Type.Focus();
            }

        }
        #endregion

        #region Associate Finding
        /// <summary>
        /// Associate finding type
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Asso_rdFinding_Type_EditValueChanged(object sender, EventArgs e)
        {
            if (this.current_mass_detail != null)
                this.current_mass_detail.ASSOCIATE_FINDING_TYPE = this.Asso_rdFinding_Type.EditValue.ToString();
            if (this.current_mass_us_detail != null)
                this.current_mass_us_detail.ASSOCIATE_FINDING_TYPE = this.Asso_rdFinding_Type.EditValue.ToString();
            if (this.Asso_rdFinding_Type.EditValue.ToString() == "G")
                this.tbAssociate_freeText.Properties.ReadOnly = false;
            else
            {
                this.tbAssociate_freeText.Text = string.Empty;
                this.tbAssociate_freeText.Properties.ReadOnly = true;
            }
        }
        #endregion

        #region Architectural Distortion
        /// <summary>
        /// Number of architectural distortion objects 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Arch_tbNumber_of_architectural_Distortion_objects_TextChanged(object sender, EventArgs e)
        {
            if (this.current_mass_detail != null)
                this.current_mass_detail.NO_OF_ARCHITECTURAL_DISTORTION = this.Arch_tbNumber_of_architectural_Distortion_objects.Text;
            if (this.current_mass_us_detail != null)
                this.current_mass_us_detail.NO_OF_ARCHITECTURAL_DISTORTION = this.Arch_tbNumber_of_architectural_Distortion_objects.Text;
            if (this.Arch_tbNumber_of_architectural_Distortion_objects.Text.Trim() != string.Empty && this.Arch_tbNumber_of_architectural_Distortion_objects.Text.Trim() != "0")
            {
                this.SetGroupOfArchitecturalEnable(true, true); //enable group of architech
            }
            else
            {
                this.SetGroupOfArchitecturalEnable(false, true); //disable group of architech
            }
        }

        /// <summary>
        /// Architectural Distortion Type
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Arch_rdArchitectural_Distortion_Type_EditValueChanged(object sender, EventArgs e)
        {
            if (this.current_mass_detail != null)
                this.current_mass_detail.ARCHITECTURAL_DISTORTION_TYPE = this.Arch_rdArchitectural_Distortion_Type.EditValue.ToString();
            
            if (this.current_mass_us_detail != null)
                this.current_mass_us_detail.ARCHITECTURAL_DISTORTION_TYPE = this.Arch_rdArchitectural_Distortion_Type.EditValue.ToString();
        }

        /// <summary>
        /// Architectural object type 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Arch_rbObject_Type_EditValueChanged(object sender, EventArgs e)
        {
            if (this.current_mass_detail != null)
                this.current_mass_detail.ARCHITECTURAL_DISTORTION_OBJECT_TYPE = this.Arch_rbObject_Type.EditValue.ToString();
            if (this.current_mass_us_detail != null)
                this.current_mass_us_detail.ARCHITECTURAL_DISTORTION_OBJECT_TYPE = this.Arch_rbObject_Type.EditValue.ToString();
        }
        #endregion

        #region Calcification Finding
        /// <summary>
        /// Number of Calcification Object
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cal_tbNumberOfCalcificationObject_TextChanged(object sender, EventArgs e)
        {
            if (this.current_mass_detail != null)
                this.current_mass_detail.NO_OF_CALCIFICATION_OBJECTS = this.cal_tbNumberOfCalcificationObject.Text;
            if (this.current_mass_us_detail != null)
                this.current_mass_us_detail.NO_OF_CALCIFICATION_OBJECTS = this.cal_tbNumberOfCalcificationObject.Text;
            if (cal_tbNumberOfCalcificationObject.Text.Trim() != string.Empty && cal_tbNumberOfCalcificationObject.Text.Trim() != "0")
            {
                this.SetGroupOfCalcificationEnable(true, true);
            }
            else
            {
                this.SetGroupOfCalcificationEnable(false, true);
            }
            
        }

        /// <summary>
        /// Calcification object type
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cal_rdCalObjType_EditValueChanged(object sender, EventArgs e)
        {
            if (this.current_mass_detail != null)
                this.current_mass_detail.TYPE_OF_CALCIFICATION_OBJECT = this.cal_rdCalObjType.EditValue.ToString();
            if (this.current_mass_detail != null)
                this.current_mass_detail.TYPE_OF_CALCIFICATION_OBJECT = this.cal_rdCalObjType.EditValue.ToString();
        }

        /// <summary>
        /// Vascular Calc.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cal_chkVascular_Calcifications_CheckedChanged(object sender, EventArgs e)
        {
            if (this.current_mass_detail != null)
                if (this.cal_chkVascular_Calcifications.Checked)
                    this.current_mass_detail.TYPICALLY_BENIGN_VASCULAR = "Y";
                else
                    this.current_mass_detail.TYPICALLY_BENIGN_VASCULAR = "N";

            if (this.current_mass_us_detail != null)
                if (this.cal_chkVascular_Calcifications.Checked)
                    this.current_mass_us_detail.TYPICALLY_BENIGN_VASCULAR = "Y";
                else
                    this.current_mass_us_detail.TYPICALLY_BENIGN_VASCULAR = "N";
        }

        /// <summary>
        /// Suture Calc.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cal_chkSuture_Calcifications_CheckedChanged(object sender, EventArgs e)
        {
            if (this.current_mass_detail != null)
                if (this.cal_chkSuture_Calcifications.Checked)
                    this.current_mass_detail.TYPICALLY_BENIGN_SUTURE = "Y";
                else
                    this.current_mass_detail.TYPICALLY_BENIGN_SUTURE = "N";

            if (this.current_mass_us_detail != null)
                if (this.cal_chkSuture_Calcifications.Checked)
                    this.current_mass_us_detail.TYPICALLY_BENIGN_SUTURE = "Y";
                else
                    this.current_mass_us_detail.TYPICALLY_BENIGN_SUTURE = "N";
        }

        /// <summary>
        /// Skin Calc.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cal_chkSkin_Calcifications_CheckedChanged(object sender, EventArgs e)
        {
            if (this.current_mass_detail != null)
                if (this.cal_chkSkin_Calcifications.Checked)
                    this.current_mass_detail.TYPICALLY_BENIGN_SKIN = "Y";
                else
                    this.current_mass_detail.TYPICALLY_BENIGN_SKIN = "N";

            if (this.current_mass_us_detail != null)
                if (this.cal_chkSkin_Calcifications.Checked)
                    this.current_mass_us_detail.TYPICALLY_BENIGN_SKIN = "Y";
                else
                    this.current_mass_us_detail.TYPICALLY_BENIGN_SKIN = "N";
        }

        /// <summary>
        /// Segmental
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cal_chkSegmental_CheckedChanged(object sender, EventArgs e)
        {
            if (this.current_mass_detail != null)
                if (this.cal_chkSegmental.Checked)
                    this.current_mass_detail.DISTRIBUTION_MODIFIER_SEGMENTAL = "Y";
                else
                    this.current_mass_detail.DISTRIBUTION_MODIFIER_SEGMENTAL = "N";

            if (this.current_mass_us_detail != null)
                if (this.cal_chkSegmental.Checked)
                    this.current_mass_us_detail.DISTRIBUTION_MODIFIER_SEGMENTAL = "Y";
                else
                    this.current_mass_us_detail.DISTRIBUTION_MODIFIER_SEGMENTAL = "N";
        }

        /// <summary>
        /// Round Calc.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cal_chkRound_Calcifications_CheckedChanged(object sender, EventArgs e)
        {
            if (this.current_mass_detail != null)
                if (this.cal_chkRound_Calcifications.Checked)
                    this.current_mass_detail.TYPICALLY_BENIGN_ROUND = "Y";
                else
                    this.current_mass_detail.TYPICALLY_BENIGN_ROUND = "N";

            if (this.current_mass_us_detail != null)
                if (this.cal_chkRound_Calcifications.Checked)
                    this.current_mass_us_detail.TYPICALLY_BENIGN_ROUND = "Y";
                else
                    this.current_mass_us_detail.TYPICALLY_BENIGN_ROUND = "N";
        }

        /// <summary>
        /// Regional
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cal_chkRegional_CheckedChanged(object sender, EventArgs e)
        {
            if (this.current_mass_detail != null)
                if (this.cal_chkRegional.Checked)
                    this.current_mass_detail.DISTRIBUTION_MODIFIER_REGIONAL = "Y";
                else
                    this.current_mass_detail.DISTRIBUTION_MODIFIER_REGIONAL = "N";

            if (this.current_mass_us_detail != null)
                if (this.cal_chkRegional.Checked)
                    this.current_mass_us_detail.DISTRIBUTION_MODIFIER_REGIONAL = "Y";
                else
                    this.current_mass_us_detail.DISTRIBUTION_MODIFIER_REGIONAL = "N";
        }

        /// <summary>
        /// Milk of Calcium Calc.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cal_chkMilk_of_Calcium_Calcifications_CheckedChanged(object sender, EventArgs e)
        {
            if (this.current_mass_detail != null)
                if (this.cal_chkMilk_of_Calcium_Calcifications.Checked)
                    this.current_mass_detail.TYPICALLY_BENIGN_MILK_OF_CALCIUM = "Y";
                else
                    this.current_mass_detail.TYPICALLY_BENIGN_MILK_OF_CALCIUM = "N";

            if (this.current_mass_us_detail != null)
                if (this.cal_chkMilk_of_Calcium_Calcifications.Checked)
                    this.current_mass_us_detail.TYPICALLY_BENIGN_MILK_OF_CALCIUM = "Y";
                else
                    this.current_mass_us_detail.TYPICALLY_BENIGN_MILK_OF_CALCIUM = "N";
        }

        /// <summary>
        /// Lucent centered Calc.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cal_chkLucent_centered_Calcifications_CheckedChanged(object sender, EventArgs e)
        {
            if (this.current_mass_detail != null)
                if (this.cal_chkLucent_centered_Calcifications.Checked)
                    this.current_mass_detail.TYPICALLY_BENIGN_LUCENT_CENTERED = "Y";
                else
                    this.current_mass_detail.TYPICALLY_BENIGN_LUCENT_CENTERED = "N";

            if (this.current_mass_us_detail != null)
                if (this.cal_chkLucent_centered_Calcifications.Checked)
                    this.current_mass_us_detail.TYPICALLY_BENIGN_LUCENT_CENTERED = "Y";
                else
                    this.current_mass_us_detail.TYPICALLY_BENIGN_LUCENT_CENTERED = "N";
        }

        /// <summary>
        /// Linear
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cal_chkLinear_CheckedChanged(object sender, EventArgs e)
        {
            if (this.current_mass_detail != null)
                if (this.cal_chkLinear.Checked)
                    this.current_mass_detail.DISTRIBUTION_MODIFIER_LINEAR = "Y";
                else
                    this.current_mass_detail.DISTRIBUTION_MODIFIER_LINEAR = "N";

            if (this.current_mass_us_detail != null)
                if (this.cal_chkLinear.Checked)
                    this.current_mass_us_detail.DISTRIBUTION_MODIFIER_LINEAR = "Y";
                else
                    this.current_mass_us_detail.DISTRIBUTION_MODIFIER_LINEAR = "N";
        }

        /// <summary>
        /// Large rod like Calc.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cal_chkLarge_rod_like_Calcifications_CheckedChanged(object sender, EventArgs e)
        {
            if (this.current_mass_detail != null)
                if (this.cal_chkLarge_rod_like_Calcifications.Checked)
                    this.current_mass_detail.TYPICALLY_BENIGN_LARGE_ROD_LIKE = "Y";
                else
                    this.current_mass_detail.TYPICALLY_BENIGN_LARGE_ROD_LIKE = "N";

            if (this.current_mass_us_detail != null)
                if (this.cal_chkLarge_rod_like_Calcifications.Checked)
                    this.current_mass_us_detail.TYPICALLY_BENIGN_LARGE_ROD_LIKE = "Y";
                else
                    this.current_mass_us_detail.TYPICALLY_BENIGN_LARGE_ROD_LIKE = "N";
        }
        /// <summary>
        /// Grouped Clustered
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cal_chkGrouped_Clustered_CheckedChanged(object sender, EventArgs e)
        {
            if (this.current_mass_detail != null)
                if (this.cal_chkGrouped_Clustered.Checked)
                    this.current_mass_detail.DISTRIBUTION_MODIFIER_GROUPED_OR_CLUSTERED = "Y";
                else
                    this.current_mass_detail.DISTRIBUTION_MODIFIER_GROUPED_OR_CLUSTERED = "N";

            if (this.current_mass_us_detail != null)
                if (this.cal_chkGrouped_Clustered.Checked)
                    this.current_mass_us_detail.DISTRIBUTION_MODIFIER_GROUPED_OR_CLUSTERED = "Y";
                else
                    this.current_mass_us_detail.DISTRIBUTION_MODIFIER_GROUPED_OR_CLUSTERED = "N";
        }
        /// <summary>
        /// Fine Pleomorphic Calc.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cal_chkFine_Pleomorphic_Calcification_CheckedChanged(object sender, EventArgs e)
        {
            if (this.current_mass_detail != null)
                if (this.cal_chkFine_Pleomorphic_Calcification.Checked)
                    this.current_mass_detail.HIGHER_PROBABILITY_OF_MALIGNANCY_FINE_PLEOMORPHIC = "Y";
                else
                    this.current_mass_detail.HIGHER_PROBABILITY_OF_MALIGNANCY_FINE_PLEOMORPHIC = "N";

            if (this.current_mass_us_detail != null)
                if (this.cal_chkFine_Pleomorphic_Calcification.Checked)
                    this.current_mass_us_detail.HIGHER_PROBABILITY_OF_MALIGNANCY_FINE_PLEOMORPHIC = "Y";
                else
                    this.current_mass_us_detail.HIGHER_PROBABILITY_OF_MALIGNANCY_FINE_PLEOMORPHIC = "N";
        }

        /// <summary>
        /// Fine Linear or Fine Linear Branching Calc.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cal_chkFine_Linear_or_Fine_linear_Branching_Calcifications_CheckedChanged(object sender, EventArgs e)
        {
            if (this.current_mass_detail != null)
                if (this.cal_chkFine_Linear_or_Fine_linear_Branching_Calcifications.Checked)
                    this.current_mass_detail.HIGHER_PROBABILITY_OF_MALIGNANCY_FINE_LINEAR = "Y";
                else
                    this.current_mass_detail.HIGHER_PROBABILITY_OF_MALIGNANCY_FINE_LINEAR = "N";

            if (this.current_mass_us_detail != null)
                if (this.cal_chkFine_Linear_or_Fine_linear_Branching_Calcifications.Checked)
                    this.current_mass_us_detail.HIGHER_PROBABILITY_OF_MALIGNANCY_FINE_LINEAR = "Y";
                else
                    this.current_mass_us_detail.HIGHER_PROBABILITY_OF_MALIGNANCY_FINE_LINEAR = "N";
        }

        /// <summary>
        /// Eggshell or Rim Calc.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cal_chkEggshell_or_Rim_Calcifications_CheckedChanged(object sender, EventArgs e)
        {
            if (this.current_mass_detail != null)
                if (this.cal_chkEggshell_or_Rim_Calcifications.Checked)
                    this.current_mass_detail.TYPICALLY_BENIGN_EGGSHELL_OR_RIM = "Y";
                else
                    this.current_mass_detail.TYPICALLY_BENIGN_EGGSHELL_OR_RIM = "N";

            if (this.current_mass_us_detail != null)
                if (this.cal_chkEggshell_or_Rim_Calcifications.Checked)
                    this.current_mass_us_detail.TYPICALLY_BENIGN_EGGSHELL_OR_RIM = "Y";
                else
                    this.current_mass_us_detail.TYPICALLY_BENIGN_EGGSHELL_OR_RIM = "N";
        }

        /// <summary>
        /// Dystrophic Calc.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cal_chkDystrophic_Calcifications_CheckedChanged(object sender, EventArgs e)
        {
            if (this.current_mass_detail != null)
                if (this.cal_chkDystrophic_Calcifications.Checked)
                    this.current_mass_detail.TYPICALLY_BENIGN_DYSTROPHIC = "Y";
                else
                    this.current_mass_detail.TYPICALLY_BENIGN_DYSTROPHIC = "N";

            if (this.current_mass_us_detail != null)
                if (this.cal_chkDystrophic_Calcifications.Checked)
                    this.current_mass_us_detail.TYPICALLY_BENIGN_DYSTROPHIC = "Y";
                else
                    this.current_mass_us_detail.TYPICALLY_BENIGN_DYSTROPHIC = "N";
        }

        /// <summary>
        /// Diffuse Scattered
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cal_chkDiffuse_Scattered_CheckedChanged(object sender, EventArgs e)
        {
            if (this.current_mass_detail != null)
                if (this.cal_chkDiffuse_Scattered.Checked)
                    this.current_mass_detail.DISTRIBUTION_MODIFIER_DIFFUSE_SCATTERED = "Y";
                else
                    this.current_mass_detail.DISTRIBUTION_MODIFIER_DIFFUSE_SCATTERED = "N";

            if (this.current_mass_us_detail != null)
                if (this.cal_chkDiffuse_Scattered.Checked)
                    this.current_mass_us_detail.DISTRIBUTION_MODIFIER_DIFFUSE_SCATTERED = "Y";
                else
                    this.current_mass_us_detail.DISTRIBUTION_MODIFIER_DIFFUSE_SCATTERED = "N";
        }

        /// <summary>
        /// Coarse or PopConrn Like Calc.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cal_chkCoarse_or_popcorn_like_Calcifications_CheckedChanged(object sender, EventArgs e)
        {
            if (this.current_mass_detail != null)
                if (this.cal_chkCoarse_or_popcorn_like_Calcifications.Checked)
                    this.current_mass_detail.TYPICALLY_BENIGN_COARSE_OR_POPCORN_LIKE = "Y";
                else
                    this.current_mass_detail.TYPICALLY_BENIGN_COARSE_OR_POPCORN_LIKE = "N";

            if (this.current_mass_us_detail != null)
                if (this.cal_chkCoarse_or_popcorn_like_Calcifications.Checked)
                    this.current_mass_us_detail.TYPICALLY_BENIGN_COARSE_OR_POPCORN_LIKE = "Y";
                else
                    this.current_mass_us_detail.TYPICALLY_BENIGN_COARSE_OR_POPCORN_LIKE = "N";
        }


        /// <summary>
        /// Coarse Heterogeneous Calc.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cal_chkCoarse_Heterogeneous_Calcifications_CheckedChanged(object sender, EventArgs e)
        {
            if (this.current_mass_detail != null)
                if (this.cal_chkCoarse_Heterogeneous_Calcifications.Checked)
                    this.current_mass_detail.INTERMEDIATE_CONCERN_SUSPICIOUS_COARSE_HETEROGENOUS = "Y";
                else
                    this.current_mass_detail.INTERMEDIATE_CONCERN_SUSPICIOUS_COARSE_HETEROGENOUS = "N";

            if (this.current_mass_us_detail != null)
                if (this.cal_chkCoarse_Heterogeneous_Calcifications.Checked)
                    this.current_mass_us_detail.INTERMEDIATE_CONCERN_SUSPICIOUS_COARSE_HETEROGENOUS = "Y";
                else
                    this.current_mass_us_detail.INTERMEDIATE_CONCERN_SUSPICIOUS_COARSE_HETEROGENOUS = "N";
        }

        /// <summary>
        /// Amorphous or Indistinct Calc.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cal_chkAmorphous_or_Indistinct_Calcifications_CheckedChanged(object sender, EventArgs e)
        {
            if (this.current_mass_detail != null)
                if (this.cal_chkAmorphous_or_Indistinct_Calcifications.Checked)
                    this.current_mass_detail.INTERMEDIATE_CONCERN_SUSPICIOUS_AMORPHOUS_OR_INDISTINCT = "Y";
                else
                    this.current_mass_detail.INTERMEDIATE_CONCERN_SUSPICIOUS_AMORPHOUS_OR_INDISTINCT = "N";

            if (this.current_mass_us_detail != null)
                if (this.cal_chkAmorphous_or_Indistinct_Calcifications.Checked)
                    this.current_mass_us_detail.INTERMEDIATE_CONCERN_SUSPICIOUS_AMORPHOUS_OR_INDISTINCT = "Y";
                else
                    this.current_mass_us_detail.INTERMEDIATE_CONCERN_SUSPICIOUS_AMORPHOUS_OR_INDISTINCT = "N";
        }
        #endregion

        #region Compare Type (List or Free Text)
        private void rdConpareType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.rdConpareType.EditValue.ToString() == "S")
                this.xtraTabControl1.SelectedTabPageIndex = 0;
            else
                this.xtraTabControl1.SelectedTabPageIndex = 1;
        }
        
        #endregion

        #region Preview Report
        /// <summary>
        /// View Report
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnViewReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.viwer.ShowDialog(this.GetGenerateResult(), true);
            //if (this.CheckMandatoryField())
            //{
            //    this.viwer.ShowDialog(this.GetGenerateResult(), true);
            //}
            //else
            //{
            //    myMessageBox.ShowAlert("UID6046", this.language);
            //}
        }
        /// <summary>
        /// This method use to generate result
        /// </summary>
        /// <returns></returns>
        private string GetGenerateResult()
        {
            this.breastControl_Left.ExportToPng(@"D:\bl.png");
            this.breastControl_Right.ExportToPng(@"D:\br.png");

            return TextGenerator.GenerateRTFText(Find_cbPatient_Type.SelectedIndex,
                    Finding_tbPatientTypeOther.Text,
                    Find_cbBreast_Composition.SelectedIndex,
                    Finding_cbFinalassessment.SelectedIndex,
                    Finding_cbRecommendation.SelectedIndex,
                    Finding_cbRecommendation.Text,
                    Finding_chkNvMG.Checked,
                    Finding_chkNvUS.Checked,
                    Finding_tbRecommendationOther.Text,
                    Finding_rdFamily_history_of_breast_cancer.EditValue.ToString(),
                    Finding_rdPersonal_History_of_breast_cancer.EditValue.ToString(),
                    Finding_rdPersonal_History_of_breast_cancer_view.EditValue.ToString(),
                    Finding_cbCinicalHistory.SelectedIndex,
                    multiChk_mass.Checked,
                    this.dsDominantList,
                    this.memoSummary.Document.RtfText,
                    dsExamResultHistory.Tables[0].Select("SELECT = 'Y'"),
                    mmComparisonText.Text,
                    this.markerList,
                    dsDemographic.Tables[0].Rows[0],
                    @"D:\bl.png",
                    @"D:\br.png",
                    Img_chkLeft.Checked,
                    Img_chkRight.Checked,
                    this.tbAssociate_freeText.Text,
                    this.mmComment.Text
            );
        }
        #endregion

        #endregion

        #region Panel Click
        //private void pnSpecialCase_Click(object sender, EventArgs e)
        //{
        //    this.Spec_tbNumber_of_Special_Case.Focus();
        //}

        private void pnSignificateFinding_Click(object sender, EventArgs e)
        {
            this.Sign_txtMass_No.Focus();
        }

        private void pnFinding_Click(object sender, EventArgs e)
        {
            this.Find_txtNumber_of_Masses.Focus();
        }

        private void pnCalcification_Click(object sender, EventArgs e)
        {
            this.cal_tbNumberOfCalcificationObject.Focus();
        }

        private void pnAssociateFinding_Click(object sender, EventArgs e)
        {
            this.Asso_txtFinding_Type.Focus();
        }

        private void pnArchitecturalDistortion_Click(object sender, EventArgs e)
        {
            this.Arch_tbNumber_of_architectural_Distortion_objects.Focus();

        }
        private void Find_pnFinding_Click(object sender, EventArgs e)
        {
            this.Find_txtPatient_Type.Focus();
        }
        private void panelContFind_pnFindingrol2_Click(object sender, EventArgs e)
        {
            this.Find_txtPatient_Type.Focus();
        }
        #endregion

        #region Remove marker complated
        /// <summary>
        /// Remove
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void breastControl_OnRemoveItemCompleted(object sender, EnvisionBreastControl.Events.ItemsArgs args)
        {
            //this.current_marker_count--;
            this.Find_tbNumber_of_Masses.Text = this.current_marker_count.ToString();
            //MarkStruct remove_ms = new MarkStruct();
            foreach (MarkStruct ms in this.markerList)
            {
                if ((ms.MarkObject as CShapeControl).Name == (args.RemovedItem as CShapeControl).Name)
                {
                    this.current_marker_count--;
                    this.markerList.Remove(ms);
                    break;
                }
            }

            if (this.current_marker_count <= 0)
            {
                this.ClearForm(false);
            }
        }
        /// <summary>
        /// Clear Form
        /// </summary>
        private void ClearForm(bool isClearAll)
        {
            this.IsLoading = true;
            if (isClearAll)
            {
                if (this.markerList.Count > 0)
                {
                    while (this.current_marker_count > 0)
                    {
                        for (int i = 0; i < this.markerList.Count; i++)
                        {
                            CShapeControl cs = this.markerList[i].MarkObject as CShapeControl;
                            //if (cs.Name.Contains("Left"))
                            this.breastControl_Left.DeleteItem(cs);
                            //else
                            this.breastControl_Right.DeleteItem(cs);
                        }
                    }
                    //this.markerList.Clear();
                }
            }
            if (this.current_marker_count == 0)
                this.markerList.Clear();
            this.txtBreast_Side_Text.Caption = "Breast: -";
            this.txtCurrentMass_Text.Caption = "Mark: -";
            this.txtMassViewType.Caption = "For: -";
            this.current_marker_count = 0;
            this.current_marker_index = 0;
            this.current_mass_detail = null;

            this.markerRemoverList.Clear();
            try
            {
                this.dsDominantList.Tables[0].Rows.Clear();
                this.dsDominantList.Tables[1].Rows.Clear();
            }
            catch { }
            //Finding
            this.Find_tbNumber_of_Masses.Text = "0";
            this.Find_cbPatient_Type.SelectedIndex = 0;
            this.Find_cbBreast_Composition.SelectedIndex = 0;
            this.Finding_cbCinicalHistory.SelectedIndex = 0;
            this.Finding_cbFinalassessment.SelectedIndex = 0;
            this.Finding_cbRecommendation.SelectedIndex = 0;
            this.Finding_chkNvMG.Checked = false;
            this.Finding_chkNvUS.Checked = false;
            this.multiChk_Cyst.Checked = false;
            this.multiChk_mass.Checked = false;
            this.Finding_rdFamily_history_of_breast_cancer.EditValue = "N";
            this.Finding_rdPersonal_History_of_breast_cancer.EditValue = "N";
            this.Finding_rdPersonal_History_of_breast_cancer_view.EditValue = "L";
            this.Finding_tbPatientTypeOther.Text = string.Empty;
            this.Finding_tbRecommendationOther.Text = string.Empty;

            //clear selected history
            foreach (DataRow dr in this.dsExamResultHistory.Tables[0].Rows)
            {
                dr["SELECT"] = "N";
            }

            this.mmComparisonText.Text = string.Empty;
            this.rdConpareType.EditValue = "S";
            

            //Significant
            //this.Sign_chkWith_Fat.Checked = false;
            this.Sign_rbMagin.EditValue = string.Empty;
            this.Sign_rbShape.EditValue = string.Empty;
            this.Sign_rbWith_Calcification.EditValue = string.Empty;
            this.Sign_tbBreastView.Text = string.Empty;
            this.Sign_tbMass_Clock_Location.Text = string.Empty;
            this.Sign_tbMass_No.Text = "";
            //this.Sign_tbMassLocation.Text = string.Empty;
            this.Sign_cbFindingType.SelectedIndex = 0;
            this.Sign_rdDensity.EditValue = string.Empty;
            this.Sign_rdMassViewType.EditValue = "M";
            this.Sign_rbWith_Calcification.EditValue = string.Empty;
            this.US_rdEchoPattern.EditValue = string.Empty;
            this.US_rdLesionBoundary.EditValue = string.Empty;
            this.US_rdMargin.EditValue = string.Empty;
            this.US_rdMassType.EditValue = string.Empty;
            this.US_rdOrientationOfMass.EditValue = string.Empty;
            this.US_rdPosteriorAcousticFeatures.EditValue = string.Empty;

            //size
            this.MG_tbSizeX.Text = string.Empty;
            this.MG_tbSizeY.Text = string.Empty;
            this.MG_tbSizeZ.Text = string.Empty;
            this.US_tbSizeX.Text = string.Empty;
            this.US_tbSizeY.Text = string.Empty;
            this.US_tbSizeZ.Text = string.Empty;

            //comemnt
            this.mmComment.Text = string.Empty;
            this.memoSummary.Text = string.Empty;
            this.tbAssociate_freeText.Text = string.Empty;
            this.groupComment.Expanded = false;

            this.Img_chkLeft.Checked = false;
            this.Img_chkRight.Checked = false;

            this.cal_chkAmorphous_or_Indistinct_Calcifications.EditValue = string.Empty;
            this.cal_chkCoarse_Heterogeneous_Calcifications.EditValue = string.Empty;
            this.cal_chkCoarse_or_popcorn_like_Calcifications.EditValue = string.Empty;
            this.cal_chkDiffuse_Scattered.EditValue = string.Empty;
            this.cal_chkDystrophic_Calcifications.EditValue = string.Empty;
            this.cal_chkEggshell_or_Rim_Calcifications.EditValue = string.Empty;
            this.cal_chkFine_Linear_or_Fine_linear_Branching_Calcifications.EditValue = string.Empty;
            this.cal_chkFine_Pleomorphic_Calcification.EditValue = string.Empty;
            this.cal_chkGrouped_Clustered.EditValue = string.Empty;
            this.cal_chkLarge_rod_like_Calcifications.EditValue = string.Empty;
            this.cal_chkLinear.EditValue = string.Empty;
            this.cal_chkLucent_centered_Calcifications.EditValue = string.Empty;
            this.cal_chkMilk_of_Calcium_Calcifications.EditValue = string.Empty;
            this.cal_chkRegional.EditValue = string.Empty;
            this.cal_chkRound_Calcifications.EditValue = string.Empty;
            this.cal_chkSegmental.EditValue = string.Empty;
            this.cal_chkSkin_Calcifications.EditValue = string.Empty;
            this.cal_chkSuture_Calcifications.EditValue = string.Empty;
            this.cal_chkVascular_Calcifications.EditValue = string.Empty;
            this.cal_rdCalObjType.EditValue = "M";
            this.cal_tbNumberOfCalcificationObject.Text = "0";
            this.Arch_rbObject_Type.EditValue = "M";
            this.Arch_rdArchitectural_Distortion_Type.EditValue = string.Empty;
            this.Arch_tbNumber_of_architectural_Distortion_objects.Text = "0";
            this.Asso_rdFinding_Type.EditValue = string.Empty;

            this.IsLoading = false;
            this.Finding_btnDominantCysts.Enabled = false;
            this.SetEnableForm(false);
        }
        #endregion
      
        #region Mass Navigator
        /// <summary>
        /// Move Next
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.current_marker_index + 1 > this.current_marker_count - 1)
                this.current_marker_index = 0;
            else
                this.current_marker_index++;
            this.breastControl_Left.SelectedItem = this.markerList[this.current_marker_index].MarkObject;
            this.breastControl_Right.SelectedItem = this.markerList[this.current_marker_index].MarkObject;
        }
        /// <summary>
        /// Move Back
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.current_marker_index - 1 < 0)
                this.current_marker_index = this.current_marker_count - 1;
            else
                this.current_marker_index--;
            this.breastControl_Left.SelectedItem = this.markerList[this.current_marker_index].MarkObject;
            this.breastControl_Right.SelectedItem = this.markerList[this.current_marker_index].MarkObject;
        }
        #endregion

        #region Selection Changed Event
        /// <summary>
        /// Selection Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void breastControl_OnSelectedItemChanged(object sender, EnvisionBreastControl.Events.ItemsArgs args)
        {
            EnvisionBreastControl.Lib.CShapeControl control = args.NewItem as EnvisionBreastControl.Lib.CShapeControl;
            string text = "Breast: ";
            if (control.Name.Contains("Left"))
                text += "Left";
            else
                text += "Right";
            int i = 0;
            _selectedShapeControl = null;
            foreach (MarkStruct markObj in this.markerList)
            {
                CShapeControl csc = markObj.MarkObject as CShapeControl;
                if (csc.Name == control.Name)
                {
                    this.current_mass_detail = markObj.MassDetail;
                    this.current_mass_us_detail = markObj.MassUSDetail;
                    this._selectedShapeControl = csc;
                    this.current_markStruct = markObj;
                    if (markObj.IsUsMassDetail == "N")
                        this.txtMassViewType.Caption = "For: MG";
                    else
                        this.txtMassViewType.Caption = "For: US";
                    break;
                }
                i++;
            }
            if (this.current_mass_detail != null && this.current_mass_us_detail != null)
            {
                this.current_marker_index = i;
                this.txtBreast_Side_Text.Caption = text;
                this.txtCurrentMass_Text.Caption = "Mark: " + (this.current_marker_index + 1);
                this.current_mass_detail.MASS_NO = this.current_marker_index + 1;
                this.current_mass_us_detail.MASS_NO = this.current_marker_index + 1;
                this.LoadMassDetail(ref this.current_markStruct, this._selectedShapeControl);
            }
        }
        /// <summary>
        /// Load Mass Detail
        /// </summary>
        /// <param name="_massDetail"></param>
        private void LoadMassDetail(ref MarkStruct _markStruck, CShapeControl _control)
        {
            if(_markStruck.IsUsMassDetail == "Y")
                this.Sign_cbFindingType.SelectedIndex = EditValueConvertor.GetFindingTypeIndex(_markStruck.MassUSDetail.FINDING_TYPE);
            else
                this.Sign_cbFindingType.SelectedIndex = EditValueConvertor.GetFindingTypeIndex(_markStruck.MassDetail.FINDING_TYPE);

            switch (_control.Shape)
            {
                case CShapeControl.Shapes.Circumscribed: this.Sign_rbMagin.EditValue = "C"; break;
                case CShapeControl.Shapes.Microlobulated: this.Sign_rbMagin.EditValue = "M"; break;
                case CShapeControl.Shapes.Indistinct: this.Sign_rbMagin.EditValue = "I"; break;
                case CShapeControl.Shapes.Obscured: this.Sign_rbMagin.EditValue = "O"; break;
                case CShapeControl.Shapes.Spiculated: this.Sign_rbMagin.EditValue = "S"; break;
            }
            if(this.Sign_rbMagin.EditValue != null)
                _markStruck.MassDetail.MASS_MARGIN = this.Sign_rbMagin.EditValue.ToString();
            if(_markStruck.IsUsMassDetail == "Y")
                this.Sign_tbMass_No.Text = _markStruck.MassUSDetail.MASS_NO.ToString();
            else
                this.Sign_tbMass_No.Text = _markStruck.MassDetail.MASS_NO.ToString();

            //this.Sign_tbMassLocation.Text = string.Format("({0},{1})"
            //    , _control.ShapeLocation.Coordinate.X
            //    , _control.ShapeLocation.Coordinate.Y);

            //set diameter dimension
            this.US_tbSizeX.Text = _control.Diameter.ToString();
            this.MG_tbSizeX.Text = _control.Diameter.ToString();
            this.US_tbSizeY.Text = _markStruck.MassUSDetail.SIZE_Y.ToString();
            this.MG_tbSizeY.Text = _markStruck.MassDetail.SIZE_Y.ToString();
            this.US_tbSizeZ.Text = _markStruck.MassUSDetail.SIZE_Z.ToString();
            this.MG_tbSizeZ.Text = _markStruck.MassDetail.SIZE_Z.ToString();

            _markStruck.MassUSDetail.SIZE_X = (int)_control.Diameter;
            _markStruck.MassDetail.SIZE_X = (int)_control.Diameter;
            

            //_markStruck.MassDetail.MASS_LOCATION_ON_IMAGE = this.Sign_tbMassLocation.Text;
            //_markStruck.MassUSDetail.MASS_LOCATION_ON_IMAGE = this.Sign_tbMassLocation.Text;
            this.Sign_tbMass_Clock_Location.Text = _control.ShapeLocation.Clock.ToString();
            _markStruck.MassDetail.MASS_LOCATION_CLOCK = this.Sign_tbMass_Clock_Location.Text;
            _markStruck.MassUSDetail.MASS_LOCATION_CLOCK = this.Sign_tbMass_Clock_Location.Text;
            this.Sign_tbBreastView.Font = new Font("Tahoma", 10, FontStyle.Bold);
            if (_control.Name.Contains("Left"))
            {
                this.Sign_tbBreastView.Text = "Left";
                this.Sign_tbBreastView.ForeColor = Color.Red;
            }
            else
            {
                this.Sign_tbBreastView.Text = "Right";
                this.Sign_tbBreastView.ForeColor = Color.Blue;
            }
            _markStruck.MassDetail.BREAST_TYPE = this.Sign_tbBreastView.Text == "Left" ? "L" : "R";
            
            //Calcification
            this.cal_chkAmorphous_or_Indistinct_Calcifications.EditValue = _markStruck.MassDetail.INTERMEDIATE_CONCERN_SUSPICIOUS_AMORPHOUS_OR_INDISTINCT;
            this.cal_chkCoarse_Heterogeneous_Calcifications.EditValue = _markStruck.MassDetail.INTERMEDIATE_CONCERN_SUSPICIOUS_COARSE_HETEROGENOUS;
            this.cal_chkCoarse_or_popcorn_like_Calcifications.EditValue = _markStruck.MassDetail.TYPICALLY_BENIGN_COARSE_OR_POPCORN_LIKE;
            this.cal_chkDiffuse_Scattered.EditValue = _markStruck.MassDetail.DISTRIBUTION_MODIFIER_DIFFUSE_SCATTERED;
            this.cal_chkDystrophic_Calcifications.EditValue = _markStruck.MassDetail.TYPICALLY_BENIGN_DYSTROPHIC;
            this.cal_chkEggshell_or_Rim_Calcifications.EditValue = _markStruck.MassDetail.TYPICALLY_BENIGN_EGGSHELL_OR_RIM;
            this.cal_chkFine_Linear_or_Fine_linear_Branching_Calcifications.EditValue = _markStruck.MassDetail.HIGHER_PROBABILITY_OF_MALIGNANCY_FINE_LINEAR;
            this.cal_chkFine_Pleomorphic_Calcification.EditValue = _markStruck.MassDetail.HIGHER_PROBABILITY_OF_MALIGNANCY_FINE_PLEOMORPHIC;
            this.cal_chkGrouped_Clustered.EditValue = _markStruck.MassDetail.DISTRIBUTION_MODIFIER_GROUPED_OR_CLUSTERED;
            this.cal_chkLarge_rod_like_Calcifications.EditValue = _markStruck.MassDetail.TYPICALLY_BENIGN_LARGE_ROD_LIKE;
            this.cal_chkLinear.EditValue = _markStruck.MassDetail.DISTRIBUTION_MODIFIER_LINEAR;
            this.cal_chkLucent_centered_Calcifications.EditValue = _markStruck.MassDetail.TYPICALLY_BENIGN_LUCENT_CENTERED;
            this.cal_chkMilk_of_Calcium_Calcifications.EditValue = _markStruck.MassDetail.TYPICALLY_BENIGN_MILK_OF_CALCIUM;
            this.cal_chkRegional.EditValue = _markStruck.MassDetail.DISTRIBUTION_MODIFIER_REGIONAL;
            this.cal_chkRound_Calcifications.EditValue = _markStruck.MassDetail.TYPICALLY_BENIGN_ROUND;
            this.cal_chkSegmental.EditValue = _markStruck.MassDetail.DISTRIBUTION_MODIFIER_SEGMENTAL;
            this.cal_chkSkin_Calcifications.EditValue = _markStruck.MassDetail.TYPICALLY_BENIGN_SKIN;
            this.cal_chkSuture_Calcifications.EditValue = _markStruck.MassDetail.TYPICALLY_BENIGN_SUTURE;
            this.cal_chkVascular_Calcifications.EditValue = _markStruck.MassDetail.TYPICALLY_BENIGN_VASCULAR;
            this.cal_rdCalObjType.EditValue = _markStruck.MassDetail.TYPE_OF_CALCIFICATION_OBJECT;
            this.cal_tbNumberOfCalcificationObject.Text = _markStruck.MassDetail.NO_OF_CALCIFICATION_OBJECTS;

            //Significant Finding
            //this.Sign_rbShape.EditValue = _massDetail.MASS_MARGIN;
            this.Sign_rbShape.EditValue = _markStruck.MassDetail.MASS_SHAPE;
            this.Sign_rbWith_Calcification.EditValue = _markStruck.MassDetail.MASS_HAS_CALCIFICATION;
            this.Sign_rdDensity.EditValue = _markStruck.MassDetail.MASS_DENSITY_TYPE;
            //this.Sign_rdBreast.EditValue = _massDetail.BREAST_TYPE;


            //Architectural distrotion
            this.Arch_rbObject_Type.EditValue = _markStruck.MassDetail.ARCHITECTURAL_DISTORTION_OBJECT_TYPE;
            this.Arch_rdArchitectural_Distortion_Type.EditValue = _markStruck.MassDetail.ARCHITECTURAL_DISTORTION_TYPE;
            this.Arch_tbNumber_of_architectural_Distortion_objects.Text = _markStruck.MassDetail.NO_OF_ARCHITECTURAL_DISTORTION;
            
            //Associate finding
            this.Asso_rdFinding_Type.EditValue = _markStruck.MassDetail.ASSOCIATE_FINDING_TYPE;
            this.tbAssociate_freeText.Text = _markStruck.MassDetail.ASSOCIATE_FINDING_TYPE_TEXT;
            
            //Special case
            //this.Spec_rdSpecial_Case_Type.EditValue = _markStruck.MassDetail.SPECIAL_CASE_TYPE;
            //this.Spec_tbFocal_Asmmetry_Location
            //this.Spec_tbNumber_of_Special_Case.Text = _markStruck.MassDetail.SPECIAL_CASE_NO_OF_ARCHITECTURAL_DISTORTION;
            
            //US
            this.US_rdEchoPattern.EditValue = _markStruck.MassUSDetail.MASS_ECHO_PATTERN;
            this.US_rdLesionBoundary.EditValue = _markStruck.MassUSDetail.MASS_LESION_BOUNDARY;
            this.US_rdMargin.EditValue = _markStruck.MassUSDetail.MASS_MARGIN;
            this.US_rdMassType.EditValue = _markStruck.MassUSDetail.MASS_CYST_TYPE;
            this.US_rdOrientationOfMass.EditValue = _markStruck.MassUSDetail.MASS_ORIENTATION;
            this.US_rdPosteriorAcousticFeatures.EditValue = _markStruck.MassUSDetail.MASS_POSTERIOR_ACOUSTIC_FEATURES;

            if (_markStruck.IsUsMassDetail == "N")
            {
                this.Sign_rdMassViewType.EditValue = "M";
            }
            else
            {
                this.Sign_rdMassViewType.EditValue = "U";
            }
            
        }
        #endregion

        #region Menu Context
        /// <summary>
        /// Breast Left And Right Menu Context 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void breastControl_OnMenuContextSelected(object sender, EnvisionBreastControl.Events.ItemEventArgs args)
        {
            this.SelectMenuContext(args.Item as EnvisionBreastControl.Lib.CShapeControl, args.ContextMenuItem as System.Windows.Controls.MenuItem);
        }

        /// <summary>
        /// Menu Context Selector
        /// </summary>
        /// <param name="cShapeControl"></param>
        /// <param name="menuItem"></param>
        private void SelectMenuContext(EnvisionBreastControl.Lib.CShapeControl control, System.Windows.Controls.MenuItem menuItem)
        {
            System.Windows.Controls.TextBlock txt = menuItem.Header as System.Windows.Controls.TextBlock;
            this.breastControl_Left.SelectedItem = control; //Set selected item
            this.breastControl_Right.SelectedItem = control; //Set Selected item
            switch (txt.Text.Trim())
            {
                case "Properties": this.MenuProperties(control); break;
                case "Fix Size": this.MenuFixSize(); break;
                case "Delete": this.MenuDelete(control); break;
                //case "Significant Finding": this.Sign_tbMass_No.Focus(); break;
                case "Calcification": this.cal_tbNumberOfCalcificationObject.Focus(); break;
                case "Associate Finding": this.Asso_txtFinding_Type.Focus(); break;
                case "Impression": this.memoSummary.Focus(); break;
                case "Significant Finding": this.Sign_tbMass_No.Focus(); break;
                case "Architectural Distortion": this.Arch_tbNumber_of_architectural_Distortion_objects.Focus(); break;
            }
        }
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="control"></param>
        private void MenuDelete(CShapeControl control)
        {
            if (this.current_marker_count <= 0)
                return;
            if(control.Name.Contains("Left"))
                this.breastControl_Left.DeleteItem(control);
            else
                this.breastControl_Right.DeleteItem(control);
        }
        /// <summary>
        /// Fix Size
        /// </summary>
        private void MenuFixSize()
        {
            if (this.current_marker_count <= 0)
                return;
            CShapeControl cs = this.markerList[this.current_marker_index].MarkObject as CShapeControl;
            if (cs.CanExpand == System.Windows.Visibility.Collapsed && !this.IsReadOnly)
                cs.CanExpand = System.Windows.Visibility.Visible;
            else
                cs.CanExpand = System.Windows.Visibility.Collapsed;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        private void MenuProperties(EnvisionBreastControl.Lib.CShapeControl control)
        {
            CProperties properties = new CProperties();
            properties.BackgroundColor = control.ShapeBackground;
            properties.BorderColor = control.LineScaleColor;
            properties.BorderThickness = (int)control.ShapeStrokeThickness;
            properties.Diameter = (int)control.Diameter;
            properties.FontColor = control.LineScaleTextForeground;
            properties.FontFamily = control.LineScaleTextFontFamily.Source;
            properties.FontSize = (int)control.LineScaleTextFontSize;
            properties.IsFixSize = control.CanExpand == System.Windows.Visibility.Visible ? true: false;
            properties.Shape = control.Shape;
            properties.ShowBorder = control.ShowBounder == System.Windows.Visibility.Visible ? true : false;
            properties.StrokeColor = control.ShapeStrokeColor;
            properties.Style = control.ShapeBackground == System.Windows.Media.Brushes.Transparent ? CStyles.Outline : CStyles.Fill;
            properties.Unit = control.Unit;

            DialogResult result = this._popupProperties.ShowDialog(true, properties);
            if (result == DialogResult.OK)
            {
                control.Diameter = this._popupProperties.Properties.Diameter;
                control.Shape = this._popupProperties.Properties.Shape;
                control.ShapeBackground = this._popupProperties.Properties.BackgroundColor;
                control.ShapeStrokeColor = this._popupProperties.Properties.StrokeColor;
                control.ShapeStrokeThickness = this._popupProperties.Properties.BorderThickness;
                control.Unit = this._popupProperties.Properties.Unit;
                control.LineScaleColor = this._popupProperties.Properties.BorderColor;
                control.LineScaleTextFontFamily = new System.Windows.Media.FontFamily(this._popupProperties.Properties.FontFamily);
                control.LineScaleTextFontSize = this._popupProperties.Properties.FontSize;
                control.LineScaleTextForeground = this._popupProperties.Properties.FontColor;
                if (this._popupProperties.Properties.IsFixSize && !this.IsReadOnly)
                    control.CanExpand = System.Windows.Visibility.Visible;
                else
                    control.CanExpand = System.Windows.Visibility.Collapsed;
                this.LoadMassDetail(ref this.current_markStruct, control);
            }
        }

        /// <summary>
        /// Panel Context Menu Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextmenuToPanel_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "Significant Finding": this.Sign_tbMass_No.Focus(); break;
                case "Calcification": this.cal_tbNumberOfCalcificationObject.Focus(); break;
                case "Associate Finding": this.Asso_txtFinding_Type.Focus(); break;
                case "Impression": this.memoSummary.Focus(); break;
                //case "Significant Finding": this.Sign_tbMass_No.Focus(); break;
                case "Architectural Distortion": this.Arch_tbNumber_of_architectural_Distortion_objects.Focus(); break;
            }
        }
        #endregion

        #region Add Mark Complated
        /// <summary>
        /// Breast Right added marker event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void breastControl_OnAddItemCompleted(object sender, EnvisionBreastControl.Events.ItemsArgs args)
        {
            MarkStruct ms = new MarkStruct();
            ms.MarkObject = args.AddedItem;
            ms.MassDetail = new MG_BREASTMASSDETAILS();
            ms.MassUSDetail = new MG_BREASTUSMASSDETAILS();
            this.markerList.Add(ms);
            this.current_marker_count++;
            this.Find_tbNumber_of_Masses.Text = this.current_marker_count.ToString();
            this.SetEnableForm(true);
            this.breastControl_Left.Mode = Modes.Selection;
            this.breastControl_Right.Mode = Modes.Selection;
        }
        #endregion

        #region Ribbon Item Click Event

        /// <summary>
        /// Set Marker Properties
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// /// <summary>
        /// Clear 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ClearForm(true);
        }
        private void btnProperties_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this._popupProperties != null)
            {
                DialogResult result = this._popupProperties.ShowDialog(true);
                if (result == DialogResult.OK)
                {
                    this._properties = this._popupProperties.Properties;
                    this.LoadMarkerStyle(this._properties);
                }
            }
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.current_marker_count <= 0)
                return;
            CShapeControl cs = this.markerList[this.current_marker_index].MarkObject as CShapeControl;
            this.MenuDelete(cs);
        }

        /// <summary>
        /// Margin Gallery Item click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShapeGallery_GalleryItemClick(object sender, DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs e)
        {
            if (this.current_marker_count <= 0)
                return;
            CShapeControl cs = this.markerList[this.current_marker_index].MarkObject as CShapeControl;
            switch (e.Item.Caption.Trim())
            {
                case "Circumscibled": cs.Shape = CShapeControl.Shapes.Circumscribed; break;
                case "Microlobulated": cs.Shape = CShapeControl.Shapes.Microlobulated; break;
                case "Obscured": cs.Shape = CShapeControl.Shapes.Obscured; break;
                case "Indistinct": cs.Shape = CShapeControl.Shapes.Indistinct; break;
                case "Spiculated": cs.Shape = CShapeControl.Shapes.Spiculated; break;
                case "Angular": cs.Shape = CShapeControl.Shapes.Angular; break;
            }
            this.LoadMassDetail(ref this.current_markStruct, cs);
        }

        /// <summary>
        /// Fix Size
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFixSize_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.MenuFixSize();
        }
        //Close form
        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Select mark
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.breastControl_Left != null && this.breastControl_Right != null)
            {
                this.breastControl_Left.Mode = Modes.Selection;
                this.breastControl_Right.Mode = Modes.Selection;
            }
        }
        /// <summary>
        /// Add mark
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMark_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.breastControl_Left != null && this.breastControl_Right != null)
            {
                this.breastControl_Left.Mode = Modes.Marking;
                this.breastControl_Right.Mode = Modes.Marking;
            }
        }

        #endregion

        #region First Load
        /// <summary>
        /// First Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BiradForm1_Load(object sender, EventArgs e)
        {
            this.LoadDemographic();
            if (this.HasDataRow(dsDemographic))
            {
                if (this.drCaseData == null)
                    this.drCaseData = this.LoadSelectedCaseDataRow(); //create datarow
                this.IsLoading = true;
                this.LoadMergeData();
                this.LoadRadiologistGroup();
                this.LoadExamResultHistory();
                this.LoadInformation();
                this.IsLoading = false;
            }
            this.LoadMarkerStyle();
            this.LoadDefaultFont();
            this.CloseWaitDialog();
        }
        #endregion

        #region Radiologist Group
        /// <summary>
        /// This method use to load radiologist group
        /// </summary>
        private void LoadRadiologistGroup()
        {
            //Load saved Group from database
            ProcessGetRISExamresultrads getGpRad = new ProcessGetRISExamresultrads();
            getGpRad.RIS_EXAMRESULTRADS.ACCESSION_NO = drCaseData["ACCESSION_NO"].ToString();
            getGpRad.Invoke();
            DataTable dtGpRad = getGpRad.Result.Tables[0];
            
            //Create Datatable
            if (this.dtRadiologistGroup == null)
            {
                this.dtRadiologistGroup = new DataTable();
                this.dtRadiologistGroup.Columns.Add("SL_NO", typeof(byte));
                this.dtRadiologistGroup.Columns.Add("RADNAME", typeof(string));
                this.dtRadiologistGroup.Columns.Add("CAN_PRELIM", typeof(bool));
                this.dtRadiologistGroup.Columns.Add("CAN_FINALIZE", typeof(bool));
                this.dtRadiologistGroup.Columns.Add("DEL", typeof(string));
                this.dtRadiologistGroup.Columns.Add("ACCESSION_NO", typeof(string));
                this.dtRadiologistGroup.Columns.Add("RAD_ID", typeof(int));
                this.dtRadiologistGroup.Columns.Add("JOBTITLE_ID", typeof(int));
                this.dtRadiologistGroup.AcceptChanges();
            }
            //add last user with new row to datatable
            if (dtGpRad.Rows.Count > 0)
            {
                int sl_no_count = 1;
                foreach (DataRow drGpRad in dtGpRad.Rows)
                {
                    DataRow drAddTemp = this.dtRadiologistGroup.NewRow();
                    drAddTemp["SL_NO"] = sl_no_count++;
                    drAddTemp["RADNAME"] = drGpRad["RADNAME"].ToString();
                    drAddTemp["CAN_PRELIM"] = drGpRad["CAN_PRELIM"];
                    drAddTemp["CAN_FINALIZE"] = drGpRad["CAN_FINALIZE"];
                    drAddTemp["DEL"] = "";
                    drAddTemp["ACCESSION_NO"] = "";
                    drAddTemp["RAD_ID"] = drGpRad["RAD_ID"];
                    drAddTemp["JOBTITLE_ID"] = drGpRad["JOBTITLE_ID"];
                    this.dtRadiologistGroup.Rows.Add(drAddTemp);
                }
                this.dtRadiologistGroup.AcceptChanges();
                sl_no_count = 0;//Clear memory
            }
            //add current user to datatable
            this.AddUserToGroup(env.UserID);
            //add to toolbar gallery control
            this.UpdateRadiologistGroupGallery();
        }

        /// <summary>
        /// This method use to update radiologist group gallery
        /// </summary>
        private void UpdateRadiologistGroupGallery()
        {
            //Clear old data
            this.RadiologistUserGallery.Gallery.Groups.Clear();
            //Build new data
            DevExpress.XtraBars.Ribbon.GalleryItemGroup _group = new DevExpress.XtraBars.Ribbon.GalleryItemGroup();

            foreach (DataRow drUser in dtRadiologistGroup.Rows)
            {
                DevExpress.XtraBars.Ribbon.GalleryItem item = new DevExpress.XtraBars.Ribbon.GalleryItem();
                item.Image = global::Envision.NET.Properties.Resources.icon_add;
                item.Tag = drUser["RAD_ID"].ToString(); //Add Rad id to item tag
                item.Caption = drUser["RADNAME"].ToString();
                switch (drUser["JOBTITLE_ID"].ToString())
                {
                    case "1": item.Description = "Radiologist"; break;
                    case "2": item.Description = "Fellow"; break;
                    case "3": item.Description = "Fellow"; break;
                    default: item.Description = "Dent"; break;
                }

                _group.Items.Add(item);
            }

            this.RadiologistUserGallery.Gallery.Groups.Add(_group);
        }

        /// <summary>
        /// Add User Item Click Event ( Show lookup form )
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddUser_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Envision.NET.Forms.Dialog.LookupData lv = new Envision.NET.Forms.Dialog.LookupData();
            lv.ValueUpdated += new Envision.NET.Forms.Dialog.ValueUpdatedEventHandler(Radiologist_name);
            lv.AddColumn("EMP_ID", "Doctor ID", false, true);
            lv.AddColumn("EMP_UID", "Doctor Code", true, true);
            lv.AddColumn("RadioName", "Doctor Name", true, true);
            lv.Text = "Doctor Search";

            LookUpSelect lvS = new LookUpSelect();
            lv.Data = lvS.SelectOrderFrom("ResultRads").Tables[0];
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }

        /// <summary>
        /// Get Radiologist name from LookUp form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Radiologist_name(object sender, Envision.NET.Forms.Dialog.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            //add current user to datatable
            this.AddUserToGroup(Convert.ToInt32(retValue[0]));
            //add to toolbar gallery control
            this.UpdateRadiologistGroupGallery();
        }

        /// <summary>
        /// this method use to delete user from group
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadiologistUserGalleryItemClick(object sender, DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs e)
        {
            DevExpress.XtraBars.Ribbon.GalleryItem selectedItem = e.Item;
            if (selectedItem != null)
            {
                if (selectedItem.Tag.ToString() != env.UserID.ToString())
                {
                    string strResult = myMessageBox.ShowAlert("UID6050", env.CurrentLanguageID);
                    //Confrim delete
                    if (strResult == "2")
                    {
                        //Remove item from gallery
                        DevExpress.XtraBars.Ribbon.GalleryItemGroup group = this.RadiologistUserGallery.Gallery.Groups[0];
                        group.Items.Remove(selectedItem);
                        //Remove from datatable
                        DataRow[] drResult = this.dtRadiologistGroup.Select("RAD_ID = '" + selectedItem.Tag  + "'");
                        if (drResult.Length > 0)
                        {
                            foreach (DataRow dr in drResult)
                            {
                                dr.Delete();
                            }
                            this.dtRadiologistGroup.AcceptChanges();
                            this.SortUserSLNo(); //Re-Sort SL NO
                        }
                    }
                }
            }
        }

        /// <summary>
        /// This method use to sort SL NO
        /// </summary>
        private void SortUserSLNo()
        {
            for (int i = 0; i < this.dtRadiologistGroup.Rows.Count; i++)
            {
                this.dtRadiologistGroup.Rows[i]["SL_NO"] = i + 1;
            }
            this.dtRadiologistGroup.AcceptChanges();
        }

        /// <summary>
        /// This method use to check and add user to radiologist group
        /// </summary>
        /// <param name="empId">User Id</param>
        private void AddUserToGroup(int empId)
        {
            DataTable dtAuth = this.GetAuthenticationDataTable(empId);
            if (dtAuth.Rows.Count <= 0)
                return;
            else
            {
                DataRow[] drAuthenByUserRole = dtRadiologistGroup.Select("RAD_ID = '" + empId + "'");
                if (drAuthenByUserRole.Length > 0)
                    return; // this id is already in datatable
                else
                {
                    this.AddUser(dtAuth, empId); //add this user
                }
            }
        }

        /// <summary>
        /// Add this user to datatable
        /// </summary>
        /// <param name="dtAuth">authen datatable</param>
        private void AddUser(DataTable dtAuth, int empId)
        {
            DataRow drAddTemp = this.dtRadiologistGroup.NewRow();
            drAddTemp["SL_NO"] = this.dtRadiologistGroup.Rows.Count + 1;
            drAddTemp["RADNAME"] = dtAuth.Rows[0]["FNAME"].ToString() + " " + dtAuth.Rows[0]["LNAME"].ToString();
            drAddTemp["CAN_PRELIM"] = Convert.ToInt32(dtAuth.Rows[0]["AUTH_LEVEL_ID"]) >= 2 ? Convert.ToBoolean(1) : Convert.ToBoolean(0); ;
            drAddTemp["CAN_FINALIZE"] = Convert.ToInt32(dtAuth.Rows[0]["AUTH_LEVEL_ID"]) == 3 ? Convert.ToBoolean(1) : Convert.ToBoolean(0);
            drAddTemp["DEL"] = "";
            drAddTemp["ACCESSION_NO"] = "";//drData["ACCESSION_NO"].ToString();
            drAddTemp["RAD_ID"] = empId;
            drAddTemp["JOBTITLE_ID"] = dtAuth.Rows[0]["JOB_TITLE_ID"];
            this.dtRadiologistGroup.Rows.Add(drAddTemp);
            this.dtRadiologistGroup.AcceptChanges();
        }

        /// <summary>
        /// This method use to get authentication data table with user id
        /// </summary>
        /// <param name="EMP_ID">User Id</param>
        /// <returns>Authen Role Datatable</returns>
        private DataTable GetAuthenticationDataTable(int EMP_ID)
        {
            ProcessGetHREmp hr = new ProcessGetHREmp();
            hr.HR_EMP.MODE = "check_Auther";
            hr.HR_EMP.EMP_ID = EMP_ID;
            hr.Invoke();
            DataTable dtAuth = hr.Result.Tables[0];
            dtAuth.AcceptChanges();
            return dtAuth;
        }

        #endregion

        #region Selected Case By WorkList
        /// <summary>
        /// this method use to load selected case datarow
        /// </summary>
        /// <returns>data row from worklist</returns>
        private DataRow LoadSelectedCaseDataRow()
        {
            ProcessGetRISExamResultWorkListByAccessionNo processGetRISExamWL = new ProcessGetRISExamResultWorkListByAccessionNo();
            processGetRISExamWL.ACCESSION_NO = this.accession;
            processGetRISExamWL.EMP_ID = env.UserID;
            processGetRISExamWL.Invoke();
            DataSet result = processGetRISExamWL.Result;
            if (result.Tables.Count > 0)
            {
                if (result.Tables[0].Rows.Count > 0)
                    return result.Tables[0].Rows[0];
                else if (result.Tables[1].Rows.Count > 0)
                    return result.Tables[1].Rows[0];
                else
                    return null;
            }

            return null;
        }

        #endregion

        #region Merge Data
        /// <summary>
        /// This method use to get merge data
        /// </summary>
        private void LoadMergeData()
        {
            //Get Merge Data
            if (this.drCaseData["MERGE"].ToString().Length > 0 && this.drCaseData["MERGE"].ToString().ToLower() != "spt")
            {
                this.resultEntry.RISExamresult.MERGE = this.drCaseData["MERGE"].ToString();
                this.resultEntry.RISExamresult.ACCESSION_NO = this.drCaseData["ACCESSION_NO"].ToString();
                this.resultEntry.RISExamresult.MERGE_WITH = this.drCaseData["MERGE_WITH"].ToString();
                this.dtMergeData = this.resultEntry.GetMergeData();
            }
            else
            {
                this.dtMergeData = null;
            }
        }
        #endregion

        #region Information
        /// <summary>
        /// Load last saved by this accession
        /// </summary>
        private void LoadInformation()
        {
            //Load for check have row or not
            ProcessGetMGBreastExamResult processGetMGBreastExamResult = new ProcessGetMGBreastExamResult();
            processGetMGBreastExamResult.MG_BREASTEXAMRESULT.ACCESSION_NO = this.accession;
            processGetMGBreastExamResult.MG_BREASTEXAMRESULT.ORG_ID = this.orgId;
            processGetMGBreastExamResult.Mode = 1;
            processGetMGBreastExamResult.Invoke();
            DataSet ds = processGetMGBreastExamResult.Result;
            if (!this.HasDataRow(ds))
            {
                this.SetEnableForm(false);
                return;
            }
            else
            {
                #region Initialize Manadatory Data
                //Initialize Mandatory Data
                this.Finding_cbRecommendation.Properties.Items.Clear();
                this.Find_cbPatient_Type.SelectedIndex = EditValueConvertor.GetPatientTypeIndex(ds.Tables[0].Rows[0]["PATIENT_TYPE"].ToString()); //patient type
                if (ds.Tables[0].Rows[0]["PATIENT_TYPE_TEXT"].ToString().Trim().Length > 0) // patient type text
                    this.Finding_tbPatientTypeOther.Text = ds.Tables[0].Rows[0]["PATIENT_TYPE_TEXT"].ToString().Trim();
                this.Find_cbBreast_Composition.SelectedIndex = EditValueConvertor.GetBreastCompositionIndex(ds.Tables[0].Rows[0]["BREAST_COMPOSITION"].ToString()); //breast composition
                this.Find_tbNumber_of_Masses.Text = ds.Tables[0].Rows[0]["NO_OF_MASS"].ToString();
                this.Finding_cbFinalassessment.SelectedIndex = EditValueConvertor.GetFinalAssessmentTypeIndex(ds.Tables[0].Rows[0]["FINAL_ASSESSMENT_TYPE"].ToString()); //final assessment type
                this.Finding_cbRecommendation.SelectedIndex = EditValueConvertor.GetRecommendationTypeeIndex(ds.Tables[0].Rows[0]["RECOMMENDATION_TYPE"].ToString()); // recommendation type
                if (ds.Tables[0].Rows[0]["RECOMMENDATION_TYPE_TEXT"].ToString().Trim().Length > 0) //recommendation type text
                    this.Finding_tbRecommendationOther.Text = ds.Tables[0].Rows[0]["RECOMMENDATION_TYPE_TEXT"].ToString().Trim();
                if (ds.Tables[0].Rows[0]["CLINICAL_HISTORY_TYPE"].Equals("S")) //Clinical history
                    this.Finding_cbCinicalHistory.SelectedIndex = 1;
                else
                    this.Finding_cbCinicalHistory.SelectedIndex = 2;
                this.Finding_rdPersonal_History_of_breast_cancer.EditValue = ds.Tables[0].Rows[0]["PERSONAL_HISTORY_OF_BREAST_CANCER"].ToString(); //Personal history of breast cancer
                if (ds.Tables[0].Rows[0]["FAMILY_HISTORY_OF_BREAST_CANCER"].Equals("N"))
                    this.Finding_rdFamily_history_of_breast_cancer.EditValue = "N";
                else
                    this.Finding_rdFamily_history_of_breast_cancer.EditValue = ds.Tables[0].Rows[0]["FAMILY_HISTORY_OF_BREAST_CANCER_TYPE_DEGREE"].ToString(); //Family history of breast cancer
                this.memoSummary.Document.RtfText = ds.Tables[0].Rows[0]["IMPRESSION_TEXT"].ToString(); //Impression
                this.mmComment.Text = ds.Tables[0].Rows[0]["COMMENT"].ToString();
                if (!string.IsNullOrEmpty(this.mmComment.Text))
                { this.groupComment.Expanded = true; }
                #endregion

                #region Initialize Negative MG & US, Multiple Mass
                if (ds.Tables[0].Rows[0]["IS_MG_NEGATIVE"].Equals("Y"))
                    this.Finding_chkNvMG.Checked = true; //Negative MG
                if (ds.Tables[0].Rows[0]["IS_US_NEGATIVE"].Equals("Y"))
                    this.Finding_chkNvUS.Checked = true; //Negative US
                if (ds.Tables[0].Rows[0]["IS_MULTIPLE_MASS"].Equals("Y") ||
                    ds.Tables[0].Rows[0]["IS_MULTIPLE_CYST"].Equals("Y"))
                {
                    if(ds.Tables[0].Rows[0]["IS_MULTIPLE_MASS"].Equals("Y"))
                        this.multiChk_mass.Checked = true; // Mutiple Mass
                    if (ds.Tables[0].Rows[0]["IS_MULTIPLE_CYST"].Equals("Y"))
                        this.multiChk_Cyst.Checked = true; // Mutiple Cyst
                    //dominant cysts
                    if (ds.Tables[0].Rows[0]["IS_MULTIPLE_MASS"].Equals("Y")
                        || ds.Tables[0].Rows[0]["IS_MULTIPLE_CYST"].Equals("Y"))
                    {
                        ProcessGetMGMassDominantCyst processGetMGMassDominantCyst = new ProcessGetMGMassDominantCyst();
                        processGetMGMassDominantCyst.MG_MASSDOMINANTCYST.ACCESSION_NO = this.accession;
                        processGetMGMassDominantCyst.MG_MASSDOMINANTCYST.ORG_ID = this.orgId;
                        processGetMGMassDominantCyst.Invoke();

                        DataSet dsDominantCyst = processGetMGMassDominantCyst.Result;

                        if (this.HasDataRow(dsDominantCyst))
                        {
                            this.Finding_btnDominantCysts.Enabled = true;
                            if (this.dsDominantList == null)
                                this.dsDominantList = this.dominantCystList.CreateMarkForDominantDataSet();

                            for (int i = 0; i < ds.Tables.Count; i++)
                            {
                                foreach (DataRow dr in dsDominantCyst.Tables[i].Rows)
                                {
                                    if(dr["IS_DOMINANT_CYST"].ToString() != "Y")
                                        this.dsDominantList.Tables[0].Rows.Add(dr["MASS_NO"].ToString()
                                            , dr["SIDE"].ToString() == "L" ? "Left" : "Right"
                                            , dr["CLOCK_LOCATION"].ToString()
                                            , dr["DIAMETER"].ToString());
                                    else
                                        this.dsDominantList.Tables[1].Rows.Add(dr["MASS_NO"].ToString()
                                            , dr["SIDE"].ToString() == "L" ? "Left" : "Right"
                                            , dr["CLOCK_LOCATION"].ToString()
                                            , dr["DIAMETER"].ToString());
                                }
                            }
                        }
                    }
                }
                if (ds.Tables[0].Rows[0]["SHOW_BREAST_IMAGE_LEFT"].Equals("Y"))
                {
                    this.Img_chkLeft.Checked = true;
                }
                if (ds.Tables[0].Rows[0]["SHOW_BREAST_IMAGE_RIGHT"].Equals("Y"))
                {
                    this.Img_chkRight.Checked = true;
                }
                #endregion

                #region Initialize Compared Exam History
                //Load Selected Compared Exam History Selected
                ProcessGetMGPatientHistoryComparison processGetMGPatientHistoryComparsion = new ProcessGetMGPatientHistoryComparison();
                processGetMGPatientHistoryComparsion.MG_PATIENTHISTORYCOMPARISON.COMPARING_EXAM = this.accession;
                processGetMGPatientHistoryComparsion.MG_PATIENTHISTORYCOMPARISON.ORG_ID = this.orgId;
                processGetMGPatientHistoryComparsion.Mode = 3;
                processGetMGPatientHistoryComparsion.MG_PATIENTHISTORYCOMPARISON.REG_ID = Convert.ToInt32(this.dsDemographic.Tables[0].Rows[0]["REG_ID"]);
                processGetMGPatientHistoryComparsion.Invoke();
                DataSet dsComparedExam = processGetMGPatientHistoryComparsion.Result;
                foreach (DataRow dr in dsComparedExam.Tables[0].Rows)
                {
                    if (dr["COMPARED_WITH"].ToString().Length > 0)
                    {
                        DataRow[] drSelectedRows = dsExamResultHistory.Tables[0].Select("ACCESSION_NO = '" + dr["COMPARED_WITH"] + "'");
                        if (drSelectedRows.Length > 0)
                        {
                            drSelectedRows[0]["SELECT"] = "Y";
                        }
                    }
                    else
                    {
                        this.mmComparisonText.Text += dr["COMPARED_TEXT"].ToString();
                    }
                }
                #endregion

                #region Initialize Breast Screen
                if (ds.Tables[0].Rows[0]["REPORT_STATUS"].Equals("F"))
                {
                    this.IsReadOnly = true;
                    this.breastControl_Left.IsReadOnly = this.IsReadOnly;
                    this.breastControl_Right.IsReadOnly = this.IsReadOnly;
                    this.SetEnableForm(false);
                }
                else
                {
                    this.SetEnableForm(true);
                }
                #endregion

                #region Initial Marker and Mass Detail
                //Load Mass, Mass US Detail and marker
                ProcessGetMGBreastMassDetail processGetMgBreastMassDetail = new ProcessGetMGBreastMassDetail();
                processGetMgBreastMassDetail.MG_BREASTMASSDETAILS.ACCESSION_NO = this.accession;
                processGetMgBreastMassDetail.MG_BREASTMASSDETAILS.ORG_ID = this.orgId;
                processGetMgBreastMassDetail.Invoke();

                DataSet dsMGMassDetail = processGetMgBreastMassDetail.Result;

                ProcessGetMGBreastUSMassDetail processGetMgBreastUSMassDetail = new ProcessGetMGBreastUSMassDetail();
                processGetMgBreastUSMassDetail.MG_BREASTUSMASSDETAILS.ACCESSION_NO = this.accession;
                processGetMgBreastUSMassDetail.MG_BREASTUSMASSDETAILS.ORG_ID = this.orgId;
                processGetMgBreastUSMassDetail.Invoke();

                DataSet dsUSMassDetail = processGetMgBreastUSMassDetail.Result;

                ProcessGetMGBreastMark processGetMgBreastMark = new ProcessGetMGBreastMark();
                processGetMgBreastMark.AccessionNo = this.accession;
                processGetMgBreastMark.OrgId = this.orgId;
                processGetMgBreastMark.Invoke();

                DataSet dsMarker = processGetMgBreastMark.Result;

                //Create mark structured list
                if (this.markerList == null)
                    this.markerList = new List<MarkStruct>();

                if (this.HasDataRow(dsMarker))
                {
                    MarkStruct mks = null;
                    List<CShapeControl> shapeControlList = new List<CShapeControl>();
                    foreach (DataRow drRows in dsMarker.Tables[0].Rows)
                    {
                        mks = new MarkStruct();
                        mks.MassDetail = new MG_BREASTMASSDETAILS();
                        mks.MassUSDetail = new MG_BREASTUSMASSDETAILS();

                        CShapeControl control = new CShapeControl();
                        control.Name = drRows["MARK_ID"].ToString();
                        control.Diameter = Convert.ToInt32(drRows["DIMENSION"]);
                        CShapeControl.Location location = new CShapeControl.Location();
                        location.Coordinate = new System.Windows.Point(Convert.ToInt32(drRows["LOCATION_X"]), Convert.ToInt32(drRows["LOCATION_Y"]));
                        location.Clock = Convert.ToInt32(drRows["CLOCK_NO"]);
                        control.ShapeLocation = location;
                        if (drRows["STYLE"].Equals("F"))
                            control.ShapeBackground = new System.Windows.Media.SolidColorBrush(ColorHelper.ColorFromDrawingColor(drRows["FILL_COLOR"].ToString()));
                        else
                            control.ShapeBackground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Transparent); //Transparent
                        control.ShapeStrokeColor = new System.Windows.Media.SolidColorBrush(ColorHelper.ColorFromDrawingColor(drRows["STROKE_COLOR"].ToString()));
                        control.ShapeStrokeThickness = Convert.ToDouble(drRows["THICKNESS"]);
                        control.CanExpand = System.Windows.Visibility.Collapsed;
                        control.ShowBounder = System.Windows.Visibility.Collapsed;


                        if (drRows["IS_US_FINDING"].Equals("Y"))
                        {
                            mks.IsUsMassDetail = "Y";
                            DataRow[] drUsMass = dsUSMassDetail.Tables[0].Select("MASS_NO = '" + drRows["MASS_NO"] + "'");
                            if (drUsMass.Length > 0)
                            {
                                mks.MassUSDetail.MASS_NO = Convert.ToInt32(drUsMass[0]["MASS_NO"].ToString());
                                mks.MassUSDetail.MASS_CYST_TYPE = drUsMass[0]["MASS_CYST_TYPE"].ToString();
                                mks.MassUSDetail.MASS_ECHO_PATTERN = drUsMass[0]["MASS_ECHO_PATTERN"].ToString();
                                mks.MassUSDetail.MASS_LESION_BOUNDARY = drUsMass[0]["MASS_LESION_BOUNDARY"].ToString();
                                mks.MassUSDetail.MASS_ORIENTATION = drUsMass[0]["MASS_ORIENTATION"].ToString();
                                mks.MassUSDetail.MASS_POSTERIOR_ACOUSTIC_FEATURES = drUsMass[0]["MASS_POSTERIOR_ACOUSTIC_FEATURES"].ToString();
                                mks.MassUSDetail.BREAST_TYPE = drUsMass[0]["BREAST_TYPE"].ToString();
                                mks.MassUSDetail.FINDING_TYPE = drUsMass[0]["FINDING_TYPE"].ToString();
                                mks.MassUSDetail.MASS_MARGIN = drUsMass[0]["MASS_MARGIN"].ToString();
                                mks.MassUSDetail.MASS_LOCATION_CLOCK = drUsMass[0]["MASS_LOCATION_CLOCK"].ToString();
                                //mks.MassDetail.MASS_HAS_CALCIFICATION = drUsMass[0]["MASS_HAS_CALCIFICATION"].ToString();
                                mks.MassDetail.NO_OF_ARCHITECTURAL_DISTORTION = drUsMass[0]["NO_OF_ARCHITECTURAL_DISTORTION"].ToString();
                                mks.MassDetail.NO_OF_CALCIFICATION_OBJECTS = drUsMass[0]["NO_OF_CALCIFICATION_OBJECTS"].ToString();
                                mks.MassDetail.TYPE_OF_CALCIFICATION_OBJECT = drUsMass[0]["TYPE_OF_CALCIFICATION_OBJECT"].ToString();
                                mks.MassDetail.TYPICALLY_BENIGN_COARSE_OR_POPCORN_LIKE = drUsMass[0]["TYPICALLY_BENIGN_COARSE_OR_POPCORN_LIKE"].ToString();
                                mks.MassDetail.TYPICALLY_BENIGN_DYSTROPHIC = drUsMass[0]["TYPICALLY_BENIGN_DYSTROPHIC"].ToString();
                                mks.MassDetail.TYPICALLY_BENIGN_EGGSHELL_OR_RIM = drUsMass[0]["TYPICALLY_BENIGN_EGGSHELL_OR_RIM"].ToString();
                                mks.MassDetail.TYPICALLY_BENIGN_LARGE_ROD_LIKE = drUsMass[0]["TYPICALLY_BENIGN_LARGE_ROD_LIKE"].ToString();
                                mks.MassDetail.TYPICALLY_BENIGN_LUCENT_CENTERED = drUsMass[0]["TYPICALLY_BENIGN_LUCENT_CENTERED"].ToString();
                                mks.MassDetail.TYPICALLY_BENIGN_MILK_OF_CALCIUM = drUsMass[0]["TYPICALLY_BENIGN_MILK_OF_CALCIUM"].ToString();
                                mks.MassDetail.TYPICALLY_BENIGN_ROUND = drUsMass[0]["TYPICALLY_BENIGN_ROUND"].ToString();
                                mks.MassDetail.TYPICALLY_BENIGN_SKIN = drUsMass[0]["TYPICALLY_BENIGN_SKIN"].ToString();
                                mks.MassDetail.TYPICALLY_BENIGN_SUTURE = drUsMass[0]["TYPICALLY_BENIGN_SUTURE"].ToString();
                                mks.MassDetail.TYPICALLY_BENIGN_VASCULAR = drUsMass[0]["TYPICALLY_BENIGN_VASCULAR"].ToString();
                                mks.MassDetail.ARCHITECTURAL_DISTORTION_OBJECT_TYPE = drUsMass[0]["ARCHITECTURAL_DISTORTION_OBJECT_TYPE"].ToString();
                                mks.MassDetail.ARCHITECTURAL_DISTORTION_TYPE = drUsMass[0]["ARCHITECTURAL_DISTORTION_TYPE"].ToString();
                                //mks.MassDetail.ASSOCIATE_FINDING_TYPE = drMass[0]["ASSOCIATE_FINDING_TYPE"].ToString();
                                mks.MassDetail.AUXILIARY_LYMPH_NODE_SIDE = drUsMass[0]["AUXILIARY_LYMPH_NODE_SIDE"].ToString();
                                mks.MassDetail.AUXILIARY_LYMPH_NODE_SIZE = Convert.ToInt32(drUsMass[0]["AUXILIARY_LYMPH_NODE_SIZE"].ToString());
                                mks.MassDetail.AUXILIARY_LYMPH_NODE_TYPE = drUsMass[0]["AUXILIARY_LYMPH_NODE_TYPE"].ToString();
                                mks.MassDetail.DISTRIBUTION_MODIFIER_DIFFUSE_SCATTERED = drUsMass[0]["DISTRIBUTION_MODIFIER_DIFFUSE_SCATTERED"].ToString();
                                mks.MassDetail.DISTRIBUTION_MODIFIER_GROUPED_OR_CLUSTERED = drUsMass[0]["DISTRIBUTION_MODIFIER_GROUPED_OR_CLUSTERED"].ToString();
                                mks.MassDetail.DISTRIBUTION_MODIFIER_LINEAR = drUsMass[0]["DISTRIBUTION_MODIFIER_LINEAR"].ToString();
                                mks.MassDetail.DISTRIBUTION_MODIFIER_REGIONAL = drUsMass[0]["DISTRIBUTION_MODIFIER_REGIONAL"].ToString();
                                mks.MassDetail.DISTRIBUTION_MODIFIER_SEGMENTAL = drUsMass[0]["DISTRIBUTION_MODIFIER_SEGMENTAL"].ToString();
                                mks.MassDetail.FINDING_TYPE = drUsMass[0]["FINDING_TYPE"].ToString();
                                mks.MassDetail.HIGHER_PROBABILITY_OF_MALIGNANCY_FINE_LINEAR = drUsMass[0]["HIGHER_PROBABILITY_OF_MALIGNANCY_FINE_LINEAR"].ToString();
                                mks.MassDetail.HIGHER_PROBABILITY_OF_MALIGNANCY_FINE_PLEOMORPHIC = drUsMass[0]["HIGHER_PROBABILITY_OF_MALIGNANCY_FINE_PLEOMORPHIC"].ToString();
                                mks.MassDetail.INTERMEDIATE_CONCERN_SUSPICIOUS_AMORPHOUS_OR_INDISTINCT = drUsMass[0]["INTERMEDIATE_CONCERN_SUSPICIOUS_AMORPHOUS_OR_INDISTINCT"].ToString();
                                mks.MassDetail.INTERMEDIATE_CONCERN_SUSPICIOUS_COARSE_HETEROGENOUS = drUsMass[0]["INTERMEDIATE_CONCERN_SUSPICIOUS_COARSE_HETEROGENOUS"].ToString();
                                if (drUsMass[0]["SIZE_X"] != null && drUsMass[0]["SIZE_X"] != DBNull.Value)
                                    mks.MassUSDetail.SIZE_X = Convert.ToInt32(drUsMass[0]["SIZE_X"]);
                                if (drUsMass[0]["SIZE_Y"] != null && drUsMass[0]["SIZE_Y"] != DBNull.Value)
                                    mks.MassUSDetail.SIZE_Y = Convert.ToInt32(drUsMass[0]["SIZE_Y"]);
                                if (drUsMass[0]["SIZE_Z"] != null && drUsMass[0]["SIZE_Z"] != DBNull.Value)
                                    mks.MassUSDetail.SIZE_Z = Convert.ToInt32(drUsMass[0]["SIZE_Z"]);
                                mks.MassUSDetail.ASSOCIATE_FINDING_TYPE = drUsMass[0]["ASSOCIATE_FINDING_TYPE"].ToString();
                                mks.MassUSDetail.ASSOCIATE_FINDING_TYPE_TEXT = drUsMass[0]["ASSOCIATE_FINDING_TYPE_TEXT"].ToString();
                            }
                        }
                        else
                        {
                            DataRow[] drMass = dsMGMassDetail.Tables[0].Select("MASS_NO = '" + drRows["MASS_NO"] + "'");
                            if (drMass.Length > 0)
                            {
                                mks.MassDetail.MASS_NO = Convert.ToInt32(drMass[0]["MASS_NO"].ToString());
                                mks.MassDetail.MASS_SHAPE = drMass[0]["MASS_SHAPE"].ToString();
                                mks.MassDetail.MASS_MARGIN = drMass[0]["MASS_MARGIN"].ToString();
                                mks.MassDetail.MASS_DENSITY = drMass[0]["MASS_DENSITY"].ToString();
                                mks.MassDetail.MASS_DENSITY_TYPE = drMass[0]["MASS_DENSITY_TYPE"].ToString();
                                mks.MassDetail.MASS_LOCATION_CLOCK = drMass[0]["MASS_LOCATION_CLOCK"].ToString();
                                mks.MassDetail.MASS_HAS_CALCIFICATION = drMass[0]["MASS_HAS_CALCIFICATION"].ToString();
                                mks.MassDetail.NO_OF_ARCHITECTURAL_DISTORTION = drMass[0]["NO_OF_ARCHITECTURAL_DISTORTION"].ToString();
                                mks.MassDetail.NO_OF_CALCIFICATION_OBJECTS = drMass[0]["NO_OF_CALCIFICATION_OBJECTS"].ToString();
                                mks.MassDetail.TYPE_OF_CALCIFICATION_OBJECT = drMass[0]["TYPE_OF_CALCIFICATION_OBJECT"].ToString();
                                mks.MassDetail.TYPICALLY_BENIGN_COARSE_OR_POPCORN_LIKE = drMass[0]["TYPICALLY_BENIGN_COARSE_OR_POPCORN_LIKE"].ToString();
                                mks.MassDetail.TYPICALLY_BENIGN_DYSTROPHIC = drMass[0]["TYPICALLY_BENIGN_DYSTROPHIC"].ToString();
                                mks.MassDetail.TYPICALLY_BENIGN_EGGSHELL_OR_RIM = drMass[0]["TYPICALLY_BENIGN_EGGSHELL_OR_RIM"].ToString();
                                mks.MassDetail.TYPICALLY_BENIGN_LARGE_ROD_LIKE = drMass[0]["TYPICALLY_BENIGN_LARGE_ROD_LIKE"].ToString();
                                mks.MassDetail.TYPICALLY_BENIGN_LUCENT_CENTERED = drMass[0]["TYPICALLY_BENIGN_LUCENT_CENTERED"].ToString();
                                mks.MassDetail.TYPICALLY_BENIGN_MILK_OF_CALCIUM = drMass[0]["TYPICALLY_BENIGN_MILK_OF_CALCIUM"].ToString();
                                mks.MassDetail.TYPICALLY_BENIGN_ROUND = drMass[0]["TYPICALLY_BENIGN_ROUND"].ToString();
                                mks.MassDetail.TYPICALLY_BENIGN_SKIN = drMass[0]["TYPICALLY_BENIGN_SKIN"].ToString();
                                mks.MassDetail.TYPICALLY_BENIGN_SUTURE = drMass[0]["TYPICALLY_BENIGN_SUTURE"].ToString();
                                mks.MassDetail.TYPICALLY_BENIGN_VASCULAR = drMass[0]["TYPICALLY_BENIGN_VASCULAR"].ToString();
                                mks.MassDetail.ARCHITECTURAL_DISTORTION_OBJECT_TYPE = drMass[0]["ARCHITECTURAL_DISTORTION_OBJECT_TYPE"].ToString();
                                mks.MassDetail.ARCHITECTURAL_DISTORTION_TYPE = drMass[0]["ARCHITECTURAL_DISTORTION_TYPE"].ToString();
                                mks.MassDetail.ASSOCIATE_FINDING_TYPE = drMass[0]["ASSOCIATE_FINDING_TYPE"].ToString();
                                mks.MassDetail.AUXILIARY_LYMPH_NODE_SIDE = drMass[0]["AUXILIARY_LYMPH_NODE_SIDE"].ToString();
                                mks.MassDetail.AUXILIARY_LYMPH_NODE_SIZE = Convert.ToInt32(drMass[0]["AUXILIARY_LYMPH_NODE_SIZE"].ToString());
                                mks.MassDetail.AUXILIARY_LYMPH_NODE_TYPE = drMass[0]["AUXILIARY_LYMPH_NODE_TYPE"].ToString();
                                mks.MassDetail.DISTRIBUTION_MODIFIER_DIFFUSE_SCATTERED = drMass[0]["DISTRIBUTION_MODIFIER_DIFFUSE_SCATTERED"].ToString();
                                mks.MassDetail.DISTRIBUTION_MODIFIER_GROUPED_OR_CLUSTERED = drMass[0]["DISTRIBUTION_MODIFIER_GROUPED_OR_CLUSTERED"].ToString();
                                mks.MassDetail.DISTRIBUTION_MODIFIER_LINEAR = drMass[0]["DISTRIBUTION_MODIFIER_LINEAR"].ToString();
                                mks.MassDetail.DISTRIBUTION_MODIFIER_REGIONAL = drMass[0]["DISTRIBUTION_MODIFIER_REGIONAL"].ToString();
                                mks.MassDetail.DISTRIBUTION_MODIFIER_SEGMENTAL = drMass[0]["DISTRIBUTION_MODIFIER_SEGMENTAL"].ToString();
                                mks.MassDetail.FINDING_TYPE = drMass[0]["FINDING_TYPE"].ToString();
                                mks.MassDetail.HIGHER_PROBABILITY_OF_MALIGNANCY_FINE_LINEAR = drMass[0]["HIGHER_PROBABILITY_OF_MALIGNANCY_FINE_LINEAR"].ToString();
                                mks.MassDetail.HIGHER_PROBABILITY_OF_MALIGNANCY_FINE_PLEOMORPHIC = drMass[0]["HIGHER_PROBABILITY_OF_MALIGNANCY_FINE_PLEOMORPHIC"].ToString();
                                mks.MassDetail.INTERMEDIATE_CONCERN_SUSPICIOUS_AMORPHOUS_OR_INDISTINCT = drMass[0]["INTERMEDIATE_CONCERN_SUSPICIOUS_AMORPHOUS_OR_INDISTINCT"].ToString();
                                mks.MassDetail.INTERMEDIATE_CONCERN_SUSPICIOUS_COARSE_HETEROGENOUS = drMass[0]["INTERMEDIATE_CONCERN_SUSPICIOUS_COARSE_HETEROGENOUS"].ToString();
                                Sign_cbFindingType.SelectedIndex = EditValueConvertor.GetFindingTypeIndex(mks.MassDetail.FINDING_TYPE);
                                if (drMass[0]["SIZE_X"] != null && drMass[0]["SIZE_X"] != DBNull.Value)
                                    mks.MassDetail.SIZE_X = Convert.ToInt32(drMass[0]["SIZE_X"]);
                                if (drMass[0]["SIZE_Y"] != null && drMass[0]["SIZE_Y"] != DBNull.Value)
                                    mks.MassDetail.SIZE_Y = Convert.ToInt32(drMass[0]["SIZE_Y"]);
                                if (drMass[0]["SIZE_Z"] != null && drMass[0]["SIZE_Z"] != DBNull.Value)
                                    mks.MassDetail.SIZE_Z = Convert.ToInt32(drMass[0]["SIZE_Z"]);
                                mks.MassDetail.ASSOCIATE_FINDING_TYPE_TEXT = drMass[0]["ASSOCIATE_FINDING_TYPE_TEXT"].ToString();
                            }
                        }
                        //Margin and shape
                        if (mks.MassDetail.FINDING_TYPE == "A" || mks.MassDetail.FINDING_TYPE == "C")
                        {
                            switch (drRows["SHAPE"].ToString())
                            {
                                case "D": control.Shape = CShapeControl.Shapes.Circumscribed; break;
                                case "F": control.Shape = CShapeControl.Shapes.Microlobulated; break;
                                case "G": control.Shape = CShapeControl.Shapes.Obscured; break;
                                case "H": control.Shape = CShapeControl.Shapes.Spiculated; break;
                                case "E": control.Shape = CShapeControl.Shapes.Indistinct; break;
                            }
                            if (mks.MassDetail.FINDING_TYPE == "A")
                                this.Sign_cbFindingType.SelectedIndex = 0;
                            else
                                this.Sign_cbFindingType.SelectedIndex = 2;
                            //this.SetFindingType(this.Sign_cbFindingType.SelectedIndex);
                        }
                        else if (mks.MassDetail.FINDING_TYPE == "B")
                        {
                            control.Shape = CShapeControl.Shapes.Calcification;
                            this.Sign_cbFindingType.SelectedIndex = 1;
                            //this.SetFindingType(this.Sign_cbFindingType.SelectedIndex);
                        }
                        else if (mks.MassDetail.FINDING_TYPE == "D")
                        {
                            control.Shape = CShapeControl.Shapes.Architectural;
                            this.Sign_cbFindingType.SelectedIndex = 3;
                            //this.SetFindingType(this.Sign_cbFindingType.SelectedIndex);
                        }
                        else if (mks.MassDetail.FINDING_TYPE == "E")
                        {
                            control.Shape = CShapeControl.Shapes.Asymmetric;
                            this.Sign_cbFindingType.SelectedIndex = 4;
                        }
                        else
                        {
                            control.Shape = CShapeControl.Shapes.Circumscribed;
                            this.Sign_cbFindingType.SelectedIndex = 0;
                        }
                        this.SetFindingType(this.Sign_cbFindingType.SelectedIndex);

                        shapeControlList.Add(control);
                        mks.MarkObject = control;

                        this.markerList.Add(mks);
                    }

                    this.breastControl_Left.LoadMarker(shapeControlList);
                    this.breastControl_Right.LoadMarker(shapeControlList);
                    this.SelectFirstMark();
                }
                #endregion

            }
        }

        /// <summary>
        /// This method use to select first marker
        /// </summary>
        private void SelectFirstMark()
        {
            if (this.markerList.Count == 0)
                return;
            else
            {
                string name = (this.markerList[0].MarkObject as CShapeControl).Name;
                if (name.Contains("Left"))
                    this.breastControl_Left.SelectedItem = this.markerList[0].MarkObject;
                else
                    this.breastControl_Right.SelectedItem = this.markerList[0].MarkObject;
                this.current_marker_count = this.markerList.Count;
                this.current_marker_index = 0;
                this.current_markStruct = this.markerList[0];
                this.current_mass_detail = this.markerList[0].MassDetail;
                this.current_mass_us_detail = this.markerList[0].MassUSDetail;
                this.SetFindingType(EditValueConvertor.GetFindingTypeIndex(this.current_mass_us_detail.FINDING_TYPE));
                this.SetFindingType(EditValueConvertor.GetFindingTypeIndex(this.current_mass_detail.FINDING_TYPE));
            }
        }
        #endregion

        #region Default Font
        /// <summary>
        /// This method use to load default font
        /// </summary>
        private void LoadDefaultFont()
        {
            CharacterProperties charProperties = this.memoSummary.Document.BeginUpdateCharacters(this.memoSummary.Document.Range);
            charProperties.FontName = "Microsoft Sans Serif";
            charProperties.FontSize = 10;
            this.memoSummary.Document.EndUpdateCharacters(charProperties);
        }

        #endregion
                                         
        #region Demographic
        /// <summary>
        /// Load Demographic
        /// </summary>
        private void LoadDemographic()
        {
            ProcessMGGetDemographic processorGetDemographic = new ProcessMGGetDemographic();
            processorGetDemographic.AccessionNo = this.accession;
            processorGetDemographic.Invoke();
            this.dsDemographic = processorGetDemographic.Result;
            //Fill Data to form
            this.Demo_tbAccession_No.Text = this.accession;
            if (this.dsDemographic != null)
            {
                if (this.dsDemographic.Tables.Count > 0)
                {
                    if (this.dsDemographic.Tables[0].Rows.Count > 0)
                    {
                        this.regId = Convert.ToInt32(this.dsDemographic.Tables[0].Rows[0]["REG_ID"].ToString()); // Set Reg Id to Global
                        this.Demo_tbAge.Text = this.dsDemographic.Tables[0].Rows[0]["AGE"].ToString(); //Age
                        this.Demo_tbGender.Text = this.dsDemographic.Tables[0].Rows[0]["GENDER"].ToString(); // Gender
                        this.Demo_tbHN.Text = this.dsDemographic.Tables[0].Rows[0]["HN"].ToString(); // HN
                        this.Demo_tbName.Text = this.dsDemographic.Tables[0].Rows[0]["PATIENT_NAME"].ToString();// Patient Name
                        this.Demo_tbRef_Doc.Text = this.dsDemographic.Tables[0].Rows[0]["REF_DOC_NAME"].ToString(); //Ref Doctor Name
                        this.Demo_tbRef_Unit.Text = this.dsDemographic.Tables[0].Rows[0]["REF_UNIT_NAME"].ToString(); //Ref unit Name
                        this.Demo_tbReport_Date.Text = DateTime.Now.ToShortDateString(); //Report Date
                        this.Demo_tbStudy.Text = this.dsDemographic.Tables[0].Rows[0]["STUDY"].ToString(); // Study
                        this.Demo_tbStudy_DateTime.Text = this.dsDemographic.Tables[0].Rows[0]["EXAM_DT"].ToString(); // Exam Datetime
                        this.exam_code = this.dsDemographic.Tables[0].Rows[0]["EXAM_CODE"].ToString(); //exam code
                        this.exam_name = this.dsDemographic.Tables[0].Rows[0]["EXAM_NAME"].ToString(); //exam name
                        this.viwer = new BiradGenerateTextViewer(accession, exam_code, exam_name, env);
                    }
                }
            }
        }
        #endregion

        #region History
        /// <summary>
        /// Load Exam History
        /// </summary>
        private void LoadExamResultHistory()
        {
            if (this.regId == 0)
                return;
            ProcessGetMGResultHistory processorGetHistory = new ProcessGetMGResultHistory();
            processorGetHistory.RegId = this.regId;
            processorGetHistory.Invoke();
            this.dsExamResultHistory = processorGetHistory.Result;
            //Binding To Grid Control
            if (this.dsExamResultHistory != null)
            {
                if (this.dsExamResultHistory.Tables.Count > 0)
                {
                    this.gridCompareControl.DataSource = this.dsExamResultHistory.Tables[0];
                }
            }
        }
        #endregion

        #region Set Marker Style
        /// <summary>
        /// This method use to set marker style to control
        /// </summary>
        /// <param name="properties">properties</param>
        private void LoadMarkerStyle()
        {
            this._properties = this._popupProperties.GetProperties(true);
            this.SetMarkerStyleToControl(breastControl_Left, _properties); //Set to breast left
            this.SetMarkerStyleToControl(breastControl_Right, _properties); //Set to breast right
        }
        /// <summary>
        /// This method use to set marker style to control with user properties
        /// </summary>
        /// <param name="properties">properties</param>
        private void LoadMarkerStyle(CProperties properties)
        {
            if (properties == null)
                properties = this._popupProperties.GetProperties(true);
            //this._properties = properties;
            this.SetMarkerStyleToControl(breastControl_Left, properties); //Set to breast left
            this.SetMarkerStyleToControl(breastControl_Right, properties); //Set to breast right
        }
        /// <summary>
        /// This method use to set marker style to each control
        /// </summary>
        /// <param name="breastControl_Left"></param>
        /// <param name="properties"></param>
        private void SetMarkerStyleToControl(BreastControl control, CProperties properties)
        {
            if (control != null)
            {
                control.Properties.Diameter = properties.Diameter;
                control.Properties.BackgroundColor = properties.BackgroundColor;
                control.Properties.BorderColor = properties.BorderColor;
                control.Properties.BorderThickness = properties.BorderThickness;
                control.Properties.FontColor = properties.FontColor;
                control.Properties.FontFamily = properties.FontFamily;
                control.Properties.FontSize = properties.FontSize;
                control.Properties.IsFixSize = properties.IsFixSize;
                control.Properties.Shape = properties.Shape;
                control.Properties.OvalWidth = properties.Diameter * 0.8;
                control.Properties.ShowBorder = properties.ShowBorder;
                control.Properties.StrokeColor = properties.StrokeColor;
                if (properties.Style == CStyles.Fill)
                    control.Properties.Style = ShapeStyles.Fill;
                else
                    control.Properties.Style = ShapeStyles.Outline;
                control.Properties.Unit = properties.Unit;
            }
        }
        #endregion

        #region Form Setter
        /// <summary>
        /// Set enable form state
        /// </summary>
        /// <param name="enable">enable value</param>
        public void SetEnableForm(bool enable)
        {
            this.cal_chkAmorphous_or_Indistinct_Calcifications.Enabled = enable;
            this.cal_chkCoarse_Heterogeneous_Calcifications.Enabled = enable;
            this.cal_chkCoarse_or_popcorn_like_Calcifications.Enabled = enable;
            this.cal_chkDiffuse_Scattered.Enabled = enable;
            this.cal_chkDystrophic_Calcifications.Enabled = enable;
            this.cal_chkEggshell_or_Rim_Calcifications.Enabled = enable;
            this.cal_chkFine_Linear_or_Fine_linear_Branching_Calcifications.Enabled = enable;
            this.cal_chkFine_Pleomorphic_Calcification.Enabled = enable;
            this.cal_chkGrouped_Clustered.Enabled = enable;
            this.cal_chkLarge_rod_like_Calcifications.Enabled = enable;
            this.cal_chkLinear.Enabled = enable;
            this.cal_chkLucent_centered_Calcifications.Enabled = enable;
            this.cal_chkMilk_of_Calcium_Calcifications.Enabled = enable;
            this.cal_chkRegional.Enabled = enable;
            this.cal_chkRound_Calcifications.Enabled = enable;
            this.cal_chkSegmental.Enabled = enable;
            this.cal_chkSkin_Calcifications.Enabled = enable;
            this.cal_chkSuture_Calcifications.Enabled = enable;
            this.cal_chkVascular_Calcifications.Enabled = enable;
            this.cal_rdCalObjType.Enabled = enable;
            this.cal_tbNumberOfCalcificationObject.Enabled = enable;
            this.Arch_rbObject_Type.Enabled = enable;
            this.Arch_rdArchitectural_Distortion_Type.Enabled = enable;
            this.Arch_tbNumber_of_architectural_Distortion_objects.Enabled = enable;
            this.Asso_rdFinding_Type.Enabled = enable;
            this.Sign_rbMagin.Enabled = enable;
            this.Sign_rbShape.Enabled = enable;
            this.Sign_rbWith_Calcification.Enabled = enable;
            this.Sign_tbBreastView.Enabled = true;
            this.Sign_tbMass_Clock_Location.Enabled = true;
            this.Sign_tbMass_No.Enabled = true;
            //this.Sign_tbMassLocation.Enabled = true;
            this.Sign_rdDensity.Enabled = enable;
            this.Sign_rdMassViewType.Enabled = enable;
            this.Sign_cbFindingType.Enabled = enable;
            this.MG_tbSizeX.Enabled = enable;
            this.MG_tbSizeY.Enabled = enable;
            this.MG_tbSizeZ.Enabled = enable;
            this.US_tbSizeX.Enabled = enable;
            this.US_tbSizeY.Enabled = enable;
            this.US_tbSizeZ.Enabled = enable;
            this.tbAssociate_freeText.Enabled = enable;
            //this.mmComment.Enabled = enable;
            //this.mmComparisonText.Enabled = enable;
            //this.memoSummary.Enabled = enable;
        }

        /// <summary>
        /// This method use to set finding type combobox enable
        /// </summary>
        /// <param name="enable"></param>
        private void SetFindingTypeEnable(bool enable)
        {
            this.Sign_cbFindingType.Enabled = enable;
        }

        /// <summary>
        /// This method use to set group of mass enable
        /// </summary>
        /// <param name="enable"></param>
        private void SetGroupOfMGMassEnable(bool enable)
        {
            this.Sign_rbMagin.Enabled = enable;
            this.Sign_rbShape.Enabled = enable;
            this.Sign_rbWith_Calcification.Enabled = enable;
            this.Sign_rdDensity.Enabled = enable;
            this.MG_tbSizeX.Enabled = enable;
            this.MG_tbSizeY.Enabled = enable;
            this.MG_tbSizeZ.Enabled = enable;
        }

        /// <summary>
        /// this method use to set group of calcification enable
        /// </summary>
        /// <param name="enable"></param>
        private void SetGroupOfCalcificationEnable(bool enable, bool isCheckFromNumberOfCal)
        {
            if (!enable)
            {
                //if (!isCheckFromNumberOfCal)
                //{
                //    this.cal_tbNumberOfCalcificationObject.Enabled = enable;
                //}
                this.cal_tbNumberOfCalcificationObject.Enabled = true;
                this.cal_chkAmorphous_or_Indistinct_Calcifications.Enabled = enable;
                this.cal_chkCoarse_Heterogeneous_Calcifications.Enabled = enable;
                this.cal_chkCoarse_or_popcorn_like_Calcifications.Enabled = enable;
                this.cal_chkDiffuse_Scattered.Enabled = enable;
                this.cal_chkDystrophic_Calcifications.Enabled = enable;
                this.cal_chkEggshell_or_Rim_Calcifications.Enabled = enable;
                this.cal_chkFine_Linear_or_Fine_linear_Branching_Calcifications.Enabled = enable;
                this.cal_chkFine_Pleomorphic_Calcification.Enabled = enable;
                this.cal_chkGrouped_Clustered.Enabled = enable;
                this.cal_chkLarge_rod_like_Calcifications.Enabled = enable;
                this.cal_chkLinear.Enabled = enable;
                this.cal_chkLucent_centered_Calcifications.Enabled = enable;
                this.cal_chkMilk_of_Calcium_Calcifications.Enabled = enable;
                this.cal_chkRegional.Enabled = enable;
                this.cal_chkRound_Calcifications.Enabled = enable;
                this.cal_chkSegmental.Enabled = enable;
                this.cal_chkSkin_Calcifications.Enabled = enable;
                this.cal_chkSuture_Calcifications.Enabled = enable;
                this.cal_chkVascular_Calcifications.Enabled = enable;
                this.cal_rdCalObjType.Enabled = enable;
            }
            else
            {
                if (cal_tbNumberOfCalcificationObject.Text.Trim() != string.Empty && cal_tbNumberOfCalcificationObject.Text.Trim() != "0")
                {
                    this.cal_tbNumberOfCalcificationObject.Enabled = enable;
                    this.cal_chkAmorphous_or_Indistinct_Calcifications.Enabled = enable;
                    this.cal_chkCoarse_Heterogeneous_Calcifications.Enabled = enable;
                    this.cal_chkCoarse_or_popcorn_like_Calcifications.Enabled = enable;
                    this.cal_chkDiffuse_Scattered.Enabled = enable;
                    this.cal_chkDystrophic_Calcifications.Enabled = enable;
                    this.cal_chkEggshell_or_Rim_Calcifications.Enabled = enable;
                    this.cal_chkFine_Linear_or_Fine_linear_Branching_Calcifications.Enabled = enable;
                    this.cal_chkFine_Pleomorphic_Calcification.Enabled = enable;
                    this.cal_chkGrouped_Clustered.Enabled = enable;
                    this.cal_chkLarge_rod_like_Calcifications.Enabled = enable;
                    this.cal_chkLinear.Enabled = enable;
                    this.cal_chkLucent_centered_Calcifications.Enabled = enable;
                    this.cal_chkMilk_of_Calcium_Calcifications.Enabled = enable;
                    this.cal_chkRegional.Enabled = enable;
                    this.cal_chkRound_Calcifications.Enabled = enable;
                    this.cal_chkSegmental.Enabled = enable;
                    this.cal_chkSkin_Calcifications.Enabled = enable;
                    this.cal_chkSuture_Calcifications.Enabled = enable;
                    this.cal_chkVascular_Calcifications.Enabled = enable;
                    this.cal_rdCalObjType.Enabled = enable;
                }
            }
        }

        /// <summary>
        /// This method use to set architectural enable
        /// </summary>
        /// <param name="enable"></param>
        private void SetGroupOfArchitecturalEnable(bool enable, bool isCheckNumberofArch)
        {
            this.Arch_rbObject_Type.Enabled = enable;
            this.Arch_rdArchitectural_Distortion_Type.Enabled = enable;
            this.Arch_tbNumber_of_architectural_Distortion_objects.Enabled = isCheckNumberofArch;
            if (this.Arch_tbNumber_of_architectural_Distortion_objects.Text.Trim() == string.Empty || this.Arch_tbNumber_of_architectural_Distortion_objects.Text.Trim() == "0")
            {
                this.Arch_rbObject_Type.Enabled = false;
                this.Arch_rdArchitectural_Distortion_Type.Enabled = false;
            }
            else
            {
                this.Arch_rbObject_Type.Enabled = true;
                this.Arch_rdArchitectural_Distortion_Type.Enabled = true;
            }
        }

        /// <summary>
        /// this method use to set group of soild mass enable
        /// </summary>
        /// <param name="enable"></param>
        private void SetGroupOfSoildMassEnable(bool enable)
        {
            this.US_rdEchoPattern.Enabled = enable;
            this.US_rdLesionBoundary.Enabled = enable;
            this.US_rdMargin.Enabled = enable;
            this.US_rdOrientationOfMass.Enabled = enable;
            this.US_rdPosteriorAcousticFeatures.Enabled = enable;
            //this.US_tbSizeX.Enabled = enable;
            //this.US_tbSizeY.Enabled = enable;
            //this.US_tbSizeZ.Enabled = enable;
        }

        private void SetReadOnlyForm()
        {
            //Master
            this.Find_cbBreast_Composition.Properties.ReadOnly = this.IsReadOnly;
            this.Find_cbPatient_Type.Properties.ReadOnly = this.IsReadOnly;
            this.Finding_cbCinicalHistory.Properties.ReadOnly = this.IsReadOnly;
            this.Finding_cbFinalassessment.Properties.ReadOnly = this.IsReadOnly;
            this.Finding_cbRecommendation.Properties.ReadOnly = this.IsReadOnly;
            this.multiChk_mass.Properties.ReadOnly = this.IsReadOnly;
            this.multiChk_Cyst.Properties.ReadOnly = this.IsReadOnly;
            this.Finding_chkNvMG.Properties.ReadOnly = this.IsReadOnly;
            this.Finding_chkNvUS.Properties.ReadOnly = this.IsReadOnly;
            this.Finding_rdFamily_history_of_breast_cancer.Properties.ReadOnly = this.IsReadOnly;
            this.Finding_rdPersonal_History_of_breast_cancer.Properties.ReadOnly = this.IsReadOnly;
            this.Finding_rdPersonal_History_of_breast_cancer_view.Properties.ReadOnly = this.IsReadOnly;
            this.Finding_tbPatientTypeOther.Properties.ReadOnly = this.IsReadOnly;
            this.Finding_tbRecommendationOther.Properties.ReadOnly = this.IsReadOnly;
            this.gridColumn4.OptionsColumn.AllowEdit = !this.IsReadOnly;
            this.mmComparisonText.Properties.ReadOnly = this.IsReadOnly;
            this.memoSummary.ReadOnly = this.IsReadOnly;
            this.mmComment.Properties.ReadOnly = this.IsReadOnly;
            this.tbAssociate_freeText.Properties.ReadOnly = this.IsReadOnly;
            this.MG_tbSizeX.Properties.ReadOnly = this.IsReadOnly;
            this.MG_tbSizeY.Properties.ReadOnly = this.IsReadOnly;
            this.MG_tbSizeZ.Properties.ReadOnly = this.IsReadOnly;
            this.US_tbSizeX.Properties.ReadOnly = this.IsReadOnly;
            this.US_tbSizeY.Properties.ReadOnly = this.IsReadOnly;
            this.US_tbSizeZ.Properties.ReadOnly = this.IsReadOnly;

            //Mass Detail
            this.Sign_cbFindingType.Properties.ReadOnly = this.IsReadOnly;
            this.Sign_rbMagin.Properties.ReadOnly = this.IsReadOnly;
            this.Sign_rbShape.Properties.ReadOnly = this.IsReadOnly;
            this.Sign_rbWith_Calcification.Properties.ReadOnly = this.IsReadOnly;
            this.Sign_rdDensity.Properties.ReadOnly = this.IsReadOnly;
            this.Sign_rdMassViewType.Properties.ReadOnly = this.IsReadOnly;
            this.US_rdEchoPattern.Properties.ReadOnly = this.IsReadOnly;
            this.US_rdLesionBoundary.Properties.ReadOnly = this.IsReadOnly;
            this.US_rdMargin.Properties.ReadOnly = this.IsReadOnly;
            this.US_rdMassType.Properties.ReadOnly = this.IsReadOnly;
            this.US_rdOrientationOfMass.Properties.ReadOnly = this.IsReadOnly;
            this.US_rdPosteriorAcousticFeatures.Properties.ReadOnly = this.IsReadOnly;
            //calcification
            this.cal_chkAmorphous_or_Indistinct_Calcifications.Properties.ReadOnly = this.IsReadOnly;
            this.cal_chkCoarse_Heterogeneous_Calcifications.Properties.ReadOnly = this.IsReadOnly;
            this.cal_chkCoarse_or_popcorn_like_Calcifications.Properties.ReadOnly = this.IsReadOnly;
            this.cal_chkDiffuse_Scattered.Properties.ReadOnly = this.IsReadOnly;
            this.cal_chkDystrophic_Calcifications.Properties.ReadOnly = this.IsReadOnly;
            this.cal_chkEggshell_or_Rim_Calcifications.Properties.ReadOnly = this.IsReadOnly;
            this.cal_chkFine_Linear_or_Fine_linear_Branching_Calcifications.Properties.ReadOnly = this.IsReadOnly;
            this.cal_chkFine_Pleomorphic_Calcification.Properties.ReadOnly = this.IsReadOnly;
            this.cal_chkGrouped_Clustered.Properties.ReadOnly = this.IsReadOnly;
            this.cal_chkLarge_rod_like_Calcifications.Properties.ReadOnly = this.IsReadOnly;
            this.cal_chkLinear.Properties.ReadOnly = this.IsReadOnly;
            this.cal_chkLucent_centered_Calcifications.Properties.ReadOnly = this.IsReadOnly;
            this.cal_chkMilk_of_Calcium_Calcifications.Properties.ReadOnly = this.IsReadOnly;
            this.cal_chkRegional.Properties.ReadOnly = this.IsReadOnly;
            this.cal_chkRound_Calcifications.Properties.ReadOnly = this.IsReadOnly;
            this.cal_chkSegmental.Properties.ReadOnly = this.IsReadOnly;
            this.cal_chkSkin_Calcifications.Properties.ReadOnly = this.IsReadOnly;
            this.cal_chkSuture_Calcifications.Properties.ReadOnly = this.IsReadOnly;
            this.cal_chkVascular_Calcifications.Properties.ReadOnly = this.IsReadOnly;
            this.cal_rdCalObjType.Properties.ReadOnly = this.IsReadOnly;
            this.cal_tbNumberOfCalcificationObject.Properties.ReadOnly = this.IsReadOnly;
            //architectural distortion
            this.Arch_rbObject_Type.Properties.ReadOnly = this.IsReadOnly;
            this.Arch_rdArchitectural_Distortion_Type.Properties.ReadOnly = this.IsReadOnly;
            this.Arch_tbNumber_of_architectural_Distortion_objects.Properties.ReadOnly = this.IsReadOnly;

            this.Asso_rdFinding_Type.Properties.ReadOnly = this.IsReadOnly;
            
        }
        #endregion

        #region Check Mandatory Field
        /// <summary>
        /// This method use to check mandatory field
        /// </summary>
        /// <returns>boolean</returns>
        private bool CheckMandatoryField()
        {
            return this.Find_cbBreast_Composition.SelectedIndex != 0 
                && this.Find_cbPatient_Type.SelectedIndex != 0
                && this.Finding_cbCinicalHistory.SelectedIndex != 0
                && this.Finding_cbFinalassessment.SelectedIndex != 0
                && this.Finding_cbRecommendation.SelectedIndex != 0
                && this.memoSummary.Text.Trim() != string.Empty;
        }
        #endregion

        private void emptySpaceItem2_Click(object sender, EventArgs e)
        {
            gridCompareControl.Focus();
        }

        private void groupSignificantFinding_Click(object sender, EventArgs e)
        {
            this.Sign_txtMass_No.Focus();
        }

        #region Helper

        /// <summary>
        /// this method use to check row from dataset
        /// </summary>
        /// <param name="ds">dataset</param>
        /// <returns>has row (boolean)</returns>
        private bool HasDataRow(DataSet ds)
        {
            if (ds != null)
                if (ds.Tables.Count > 0)
                    if (ds.Tables[0].Rows.Count > 0)
                        return true;
            return false;
        }
        #endregion
    }
}