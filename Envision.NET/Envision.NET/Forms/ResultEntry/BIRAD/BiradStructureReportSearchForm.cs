using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Envision.NET.Mammogram.ResultEntry.BIRAD.Helper;
using Envision.Common;
using Envision.BusinessLogic.ProcessRead;

namespace Envision.NET.Forms.ResultEntry.BIRAD
{
    public partial class BiradStructureReportSearchForm : Envision.NET.Forms.Main.MasterForm
    {
        private bool _isSearchByUltrasound = false;
        private bool _isSeatchAll = false;
        private DateTime _dtSearchFrom;
        private DateTime _dtSearchTo;
        private DataTable dtSearchResult;

        public BiradStructureReportSearchForm()
        {
            InitializeComponent();
            this.Load += BiradStructureReportSearchForm_Load;
            this.gbArchitecturalDistortion.Click += new EventHandler(gbArchitecturalDistortion_Click);
            this.gbAsscosiatieFinding.Click += new EventHandler(gbAsscosiatieFinding_Click);
            this.gbCalcificationFinding.Click += new EventHandler(gbCalcificationFinding_Click);
            this.gbFinding.Click += new EventHandler(gbFinding_Click);
            this.groupSignificantFinding.Click += new EventHandler(groupSignificantFinding_Click);
            this.Sign_rdMassViewType.EditValueChanged += new EventHandler(Sign_rdMassViewType_EditValueChanged);
            this.rdgRaportingSearchRange.EditValueChanged += new EventHandler(rdgRaportingSearchRange_EditValueChanged);
            this.Sign_cbFindingType.SelectedIndexChanged += new EventHandler(Sign_cbFindingType_SelectedIndexChanged);
            this.Sign_rdDensity.EditValueChanged += new EventHandler(Sign_rdDensity_EditValueChanged);
            this.Finding_rdPersonal_History_of_breast_cancer.EditValueChanged += new EventHandler(Finding_rdPersonal_History_of_breast_cancer_EditValueChanged);
            this.Finding_cbFinalassessment.SelectedIndexChanged += new EventHandler(Finding_cbFinalassessment_SelectedIndexChanged);

            this.dtSearchFrom.EditValueChanged += new EventHandler(dtSearchFrom_EditValueChanged);
            this.dtSearchTo.EditValueChanged += new EventHandler(dtSearchTo_EditValueChanged);
            //Hyper link event
            this.ilArchitectDisType.LinkClicked += HyperlinkClicked;
            this.ilArchObjectType.LinkClicked += HyperlinkClicked;
            this.ilAssociateFinding.LinkClicked += HyperlinkClicked;
            this.ilCalcificationObjectType.LinkClicked += HyperlinkClicked;
            this.ilMGDensity.LinkClicked += HyperlinkClicked;
            this.ilMGDensityWithFat.LinkClicked += HyperlinkClicked;
            this.ilMGMargin.LinkClicked += HyperlinkClicked;
            this.ilMGShape.LinkClicked += HyperlinkClicked;
            this.ilUSEchoPattern.LinkClicked += HyperlinkClicked;
            this.ilUSLesionBoundary.LinkClicked += HyperlinkClicked;
            this.ilUSMargin.LinkClicked += HyperlinkClicked;
            this.ilUSMassType.LinkClicked += HyperlinkClicked;
            this.ilUSOrientation.LinkClicked += HyperlinkClicked;
            this.ilUSPosteriorAcoustic.LinkClicked += HyperlinkClicked;

            this.btnClearall.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(btnClearall_ItemClick);
            this.btnClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(btnClose_ItemClick);
            this.btnSearch.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(btnSearch_ItemClick);

            this.repositoryItemImageComboBox1.Click += new EventHandler(repositoryItemImageComboBox1_Click);
        }

        #region Open pasc and preview
        /// <summary>
        /// Pasc and Preview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void repositoryItemImageComboBox1_Click(object sender, EventArgs e)
        {
            
        }
        #endregion

        #region Selected DateTime Search Changed
        /// <summary>
        /// To
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtSearchTo_EditValueChanged(object sender, EventArgs e)
        {
            this._dtSearchTo = new DateTime(this.dtSearchTo.DateTime.Year, this.dtSearchTo.DateTime.Month, this.dtSearchTo.DateTime.Day, 23, 59, 59);
        }
        /// <summary>
        /// From
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtSearchFrom_EditValueChanged(object sender, EventArgs e)
        {
            this._dtSearchFrom = new DateTime(this.dtSearchFrom.DateTime.Year, this.dtSearchFrom.DateTime.Month, this.dtSearchFrom.DateTime.Day, 0, 0, 0);
        }
        #endregion

       
        #region Tools Bar Menu Event
        /// <summary>
        /// Clear all
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearall_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ClearFindingGroup();
            this.SetVisibleUSMass(true);
            this.dtSearchFrom.DateTime = DateTime.Today;
            this.dtSearchTo.DateTime = DateTime.Today;
            this.Sign_cbFindingType.SelectedIndex = 0;
            this.rdgRaportingSearchRange.EditValue = "3M"; //default 3 months
            this.Sign_rdMassViewType.EditValue = "M";
        }

        /// <summary>
        /// Close from
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Search
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MG_BREASTEXAMRESULT mgBreastMarkResult = new MG_BREASTEXAMRESULT();
            MG_BREASTMASSDETAILS mgBreastMassDetail = new MG_BREASTMASSDETAILS();
            MG_BREASTUSMASSDETAILS mgBreastUSMassDetail = new MG_BREASTUSMASSDETAILS();
            ProcessGetMGStructuredReportSearch processSRSearch = new ProcessGetMGStructuredReportSearch();
            try
            {
                if (this.Finding_cbCinicalHistory.SelectedIndex == 1)
                    mgBreastMarkResult.CLINICAL_HISTORY_TYPE = "S";
                else if (this.Finding_cbCinicalHistory.SelectedIndex == 2)
                    mgBreastMarkResult.CLINICAL_HISTORY_TYPE = "D";
                if (this.Finding_rdFamily_history_of_breast_cancer.EditValue.ToString() != "N")
                {
                    mgBreastMarkResult.FAMILY_HISTORY_OF_BREAST_CANCER = "Y";
                    mgBreastMarkResult.FAMILY_HISTORY_OF_BREAST_CANCER_TYPE_DEGREE = this.Finding_rdFamily_history_of_breast_cancer.EditValue.ToString();
                }
                else
                    mgBreastMarkResult.FAMILY_HISTORY_OF_BREAST_CANCER = "Y";
                mgBreastMarkResult.FINAL_ASSESSMENT_TYPE = EditValueConvertor.GetFinalAssessmentTypeValue(this.Finding_cbFinalassessment.SelectedIndex);
                if (this.Finding_chkNvMG.Checked)
                    mgBreastMarkResult.IS_MG_NEGATIVE = "Y";
                else
                    mgBreastMarkResult.IS_MG_NEGATIVE = "N";
                if (this.Finding_chkNvUS.Checked)
                    mgBreastMarkResult.IS_US_NEGATIVE = "Y";
                else
                    mgBreastMarkResult.IS_US_NEGATIVE = "N";
                if (this.Finding_chkMultiple.Checked)
                    mgBreastMarkResult.IS_MULTIPLE_MASS = "Y";
                else
                    mgBreastMarkResult.IS_MULTIPLE_MASS = "N";

                if (!string.IsNullOrEmpty(this.Find_tbNumber_of_Masses.Text))
                    mgBreastMarkResult.NO_OF_MASS = Convert.ToInt32(this.Find_tbNumber_of_Masses.Text);
                mgBreastMarkResult.PATIENT_TYPE = EditValueConvertor.GetPatientTypeValue(this.Find_cbPatient_Type.SelectedIndex);
                mgBreastMarkResult.PERSONAL_HISTORY_OF_BREAST_CANCER = this.Finding_rdPersonal_History_of_breast_cancer.EditValue.ToString();
                mgBreastMarkResult.PERSONAL_HISTORY_OF_BREAST_CANCER_BREAST_SIDE = this.Finding_rdPersonal_History_of_breast_cancer_view.EditValue.ToString();
                mgBreastMarkResult.RECOMMENDATION_TYPE = EditValueConvertor.GetRecommendationTypeValue(this.Finding_cbRecommendation.SelectedIndex);

                mgBreastMassDetail.ARCHITECTURAL_DISTORTION_OBJECT_TYPE = this.Arch_rbObject_Type.EditValue.ToString();
                mgBreastMassDetail.ARCHITECTURAL_DISTORTION_TYPE = this.Arch_rdArchitectural_Distortion_Type.EditValue.ToString();
                mgBreastMassDetail.ASSOCIATE_FINDING_TYPE = this.Asso_rdFinding_Type.EditValue == null ? string.Empty : this.Asso_rdFinding_Type.EditValue.ToString();
                if (this.cbBreatView.SelectedIndex == 1)
                    mgBreastMassDetail.BREAST_TYPE = "L";
                else if (this.cbBreatView.SelectedIndex == 2)
                    mgBreastMassDetail.BREAST_TYPE = "R";
                mgBreastMassDetail.DISTRIBUTION_MODIFIER_DIFFUSE_SCATTERED = this.cal_chkDiffuse_Scattered.Checked == true ? "Y" : "N";
                mgBreastMassDetail.DISTRIBUTION_MODIFIER_GROUPED_OR_CLUSTERED = this.cal_chkGrouped_Clustered.Checked == true ? "Y" : "N";
                mgBreastMassDetail.DISTRIBUTION_MODIFIER_LINEAR = this.cal_chkLinear.Checked == true ? "Y" : "N";
                mgBreastMassDetail.DISTRIBUTION_MODIFIER_REGIONAL = this.cal_chkRegional.Checked == true ? "Y" : "N";
                mgBreastMassDetail.DISTRIBUTION_MODIFIER_SEGMENTAL = this.cal_chkSegmental.Checked == true ? "Y" : "N";

                mgBreastMassDetail.FINDING_TYPE = EditValueConvertor.GetFindingTypeValue(this.Sign_cbFindingType.SelectedIndex);

                mgBreastMassDetail.HIGHER_PROBABILITY_OF_MALIGNANCY_FINE_LINEAR = this.cal_chkFine_Linear_or_Fine_linear_Branching_Calcifications.Checked == true ? "Y" : "N";
                mgBreastMassDetail.HIGHER_PROBABILITY_OF_MALIGNANCY_FINE_PLEOMORPHIC = this.cal_chkFine_Pleomorphic_Calcification.Checked == true ? "Y" : "N";
                mgBreastMassDetail.INTERMEDIATE_CONCERN_SUSPICIOUS_AMORPHOUS_OR_INDISTINCT = this.cal_chkAmorphous_or_Indistinct_Calcifications.Checked == true ? "Y" : "N";
                mgBreastMassDetail.INTERMEDIATE_CONCERN_SUSPICIOUS_COARSE_HETEROGENOUS = this.cal_chkCoarse_Heterogeneous_Calcifications.Checked == true ? "Y" : "N";
                mgBreastMassDetail.MASS_DENSITY_TYPE = this.Sign_rdDensity.EditValue == null ? string.Empty : this.Sign_rdDensity.EditValue.ToString();
                mgBreastMassDetail.MASS_HAS_CALCIFICATION = this.Sign_rbWith_Calcification.EditValue == null ? string.Empty : this.Sign_rbWith_Calcification.EditValue.ToString();
                if (this.cbClockLocation.SelectedIndex != 0)
                    mgBreastMassDetail.MASS_LOCATION_CLOCK = this.cbClockLocation.SelectedIndex.ToString();
                else
                    mgBreastMassDetail.MASS_LOCATION_CLOCK = string.Empty;
                mgBreastMassDetail.MASS_MARGIN = this.Sign_rbMagin.EditValue == null ? string.Empty : this.Sign_rbMagin.EditValue.ToString();
                mgBreastMassDetail.MASS_SHAPE = this.Sign_rbShape.EditValue == null ? string.Empty : this.Sign_rbShape.EditValue.ToString();
                if (!string.IsNullOrEmpty(this.Arch_tbNumber_of_architectural_Distortion_objects.Text))
                    mgBreastMassDetail.NO_OF_ARCHITECTURAL_DISTORTION = this.Arch_tbNumber_of_architectural_Distortion_objects.Text;
                if (!string.IsNullOrEmpty(this.cal_tbNumberOfCalcificationObject.Text))
                    mgBreastMassDetail.NO_OF_CALCIFICATION_OBJECTS = this.cal_tbNumberOfCalcificationObject.Text;
                mgBreastMassDetail.TYPE_OF_CALCIFICATION_OBJECT = cal_rdCalObjType.EditValue.ToString();
                mgBreastMassDetail.TYPICALLY_BENIGN_COARSE_OR_POPCORN_LIKE = this.cal_chkCoarse_or_popcorn_like_Calcifications.Checked ? "Y" : "N";
                mgBreastMassDetail.TYPICALLY_BENIGN_DYSTROPHIC = this.cal_chkDystrophic_Calcifications.Checked ? "Y" : "N";
                mgBreastMassDetail.TYPICALLY_BENIGN_EGGSHELL_OR_RIM = this.cal_chkEggshell_or_Rim_Calcifications.Checked ? "Y" : "N";
                mgBreastMassDetail.TYPICALLY_BENIGN_LARGE_ROD_LIKE = this.cal_chkLarge_rod_like_Calcifications.Checked ? "Y" : "N";
                mgBreastMassDetail.TYPICALLY_BENIGN_LUCENT_CENTERED = this.cal_chkLucent_centered_Calcifications.Checked ? "Y" : "N";
                mgBreastMassDetail.TYPICALLY_BENIGN_MILK_OF_CALCIUM = this.cal_chkMilk_of_Calcium_Calcifications.Checked ? "Y" : "N";
                mgBreastMassDetail.TYPICALLY_BENIGN_ROUND = this.cal_chkRound_Calcifications.Checked ? "Y" : "N";
                mgBreastMassDetail.TYPICALLY_BENIGN_SKIN = this.cal_chkSkin_Calcifications.Checked ? "Y" : "N";
                mgBreastMassDetail.TYPICALLY_BENIGN_SUTURE = this.cal_chkSuture_Calcifications.Checked ? "Y" : "N";
                mgBreastMassDetail.TYPICALLY_BENIGN_VASCULAR = this.cal_chkVascular_Calcifications.Checked ? "Y" : "N";

                mgBreastUSMassDetail.MASS_CYST_TYPE = this.US_rdMassType.EditValue.ToString();
                mgBreastUSMassDetail.MASS_ECHO_PATTERN = this.radioGroup4.EditValue.ToString();
                mgBreastUSMassDetail.MASS_LESION_BOUNDARY = this.radioGroup5.EditValue.ToString();
                mgBreastUSMassDetail.MASS_MARGIN = this.US_rdMargin.EditValue.ToString();
                mgBreastUSMassDetail.MASS_ORIENTATION = this.US_rdOrientationOfMass.EditValue.ToString();
                mgBreastUSMassDetail.MASS_POSTERIOR_ACOUSTIC_FEATURES = this.US_rdPosteriorAcousticFeatures.EditValue.ToString();
                mgBreastUSMassDetail.MASS_TYPE = this.US_rdMassType.EditValue.ToString();
                processSRSearch.FROM_DT = _dtSearchFrom;
                processSRSearch.IS_SEARCH_BY_US = _isSearchByUltrasound;
                processSRSearch.IS_SEATCH_ALL = _isSeatchAll;
                processSRSearch.TO_DT = _dtSearchTo;
                processSRSearch.MG_BREASTEXAMRESULT = mgBreastMarkResult;
                processSRSearch.MG_BREASTMASSDETAILS = mgBreastMassDetail;
                processSRSearch.MG_BREASTUSMASSDETAILS = mgBreastUSMassDetail;
                processSRSearch.Invoke();

                DataSet ds = processSRSearch.Result;

                this.LoadSearchResult(ds); //Load search result

                ds = null;
                processSRSearch = null;
                mgBreastMarkResult = null;
                mgBreastMassDetail = null;
                mgBreastUSMassDetail = null; //Clear memory
            }
            catch(Exception ex){
                mgBreastMarkResult = null;
                mgBreastMassDetail = null;
                mgBreastUSMassDetail = null; //Clear memory
                MessageBox.Show(ex.Message);
            }

        }

        #endregion

        #region Group Panel Click Event
        private void groupSignificantFinding_Click(object sender, EventArgs e)
        {
            this.Sign_txtBreast.Focus();
        }

        private void gbFinding_Click(object sender, EventArgs e)
        {
            this.Find_txtPatient_Type.Focus();
        }

        private void gbCalcificationFinding_Click(object sender, EventArgs e)
        {
            this.cal_txtCalcificationType.Focus();
        }

        private void gbAsscosiatieFinding_Click(object sender, EventArgs e)
        {
            this.txtAssosiatefindingTitle.Focus();
        }

        private void gbArchitecturalDistortion_Click(object sender, EventArgs e)
        {
            this.Arch_txtArchitectural_Distortion_Type.Focus();
        }
        #endregion

        #region Frist Load
        private void BiradStructureReportSearchForm_Load(object sender, EventArgs e)
        {
            this.InitialEditors(); ;
            this.CloseWaitDialog();
        }

        /// <summary>
        /// This method use to intial editor
        /// </summary>
        private void InitialEditors()
        {
            this.dtSearchFrom.DateTime = DateTime.Today;
            this.dtSearchTo.DateTime = DateTime.Today;
            this.Sign_cbFindingType.SelectedIndex = 0;
            this.rdgRaportingSearchRange.EditValue = "3M"; //default 3 months
            this.Sign_rdMassViewType.EditValue = "M";
            //this.chkShowAllExam.Checked = true;
        }
        #endregion

        #region Editer Event
        /// <summary>
        /// Show all check box checkchange event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void rdgRaportingSearchRange_EditValueChanged(object sender, EventArgs e)
        {
            if (this.rdgRaportingSearchRange.EditValue.ToString() == "DR")
                this.SetActiveDateRangeEditor(true);
            else
                this.SetActiveDateRangeEditor(false);

            switch (rdgRaportingSearchRange.EditValue.ToString())
            {
                case "1W": 
                    this._dtSearchTo = DateTime.Today;
                    this._dtSearchFrom = this._dtSearchTo.AddDays(-7);
                    this._isSeatchAll = false;
                    break;
                case "1M":
                    this._dtSearchTo = DateTime.Today;
                    this._dtSearchFrom = this._dtSearchTo.AddMonths(-1);
                    this._isSeatchAll = false;
                    break;
                case "3M":
                    this._dtSearchTo = DateTime.Today;
                    this._dtSearchFrom = this._dtSearchTo.AddDays(-3);
                    this._isSeatchAll = false;
                    break;
                case "6M":
                    this._dtSearchTo = DateTime.Today;
                    this._dtSearchFrom = this._dtSearchTo.AddMonths(-6);
                    this._isSeatchAll = false;
                    break;
                case "1Y":
                    this._dtSearchTo = DateTime.Today;
                    this._dtSearchFrom = this._dtSearchTo.AddYears(-1);
                    this._isSeatchAll = false;
                    break;
                case "DR":
                    this._dtSearchTo = new DateTime(this.dtSearchTo.DateTime.Year, this.dtSearchTo.DateTime.Month, this.dtSearchTo.DateTime.Day, 23, 59, 59);
                    this._dtSearchFrom = new DateTime(this.dtSearchFrom.DateTime.Year, this.dtSearchFrom.DateTime.Month, this.dtSearchFrom.DateTime.Day, 0, 0, 0);
                    break;
                default: this._isSeatchAll = true; break;
            }
        }
        /// <summary>
        /// Mass view type edit value changed event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Sign_rdMassViewType_EditValueChanged(object sender, EventArgs e)
        {
            if (this.Sign_rdMassViewType.EditValue.Equals("M"))
            {
                this.SetVisibleUSMass(false);
                this.SetActiveCalcificationGroup(false);
                this.SetActiveArchitecturalDistortionGroup(false);
                this._isSearchByUltrasound = false;
            }
            else
            {
                this.SetVisibleUSMass(true);
                this.SetActiveCalcificationGroup(false);
                this.SetActiveArchitecturalDistortionGroup(false);
                this._isSearchByUltrasound = true;
            }
        }

        /// <summary>
        /// finding type selection changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Sign_cbFindingType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Select case
            switch (Sign_cbFindingType.SelectedIndex)
            {
                case 0: this.SetActiveMGMass(true);
                    this.SetActiveCalcificationGroup(false);
                    this.SetActiveArchitecturalDistortionGroup(false); break;
                case 1: this.SetActiveMGMass(false);
                    this.SetActiveCalcificationGroup(true);
                    this.SetActiveArchitecturalDistortionGroup(false); break;
                case 2: this.SetActiveMGMass(true);
                    this.SetActiveCalcificationGroup(true);
                    this.SetActiveArchitecturalDistortionGroup(false); break;
                case 3: this.SetActiveMGMass(false);
                    this.SetActiveCalcificationGroup(false);
                    this.SetActiveArchitecturalDistortionGroup(true); break;
                case 4: this.SetActiveMGMass(false);
                    this.SetActiveCalcificationGroup(false);
                    this.SetActiveArchitecturalDistortionGroup(false); break;
            }
        }

        /// <summary>
        /// denesity edivalue changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Sign_rdDensity_EditValueChanged(object sender, EventArgs e)
        {
            if (Sign_rdDensity.EditValue != null && Sign_rdDensity.EditValue.ToString() != string.Empty)
                this.Sign_rbWith_Calcification.Enabled = true;
            else
                this.Sign_rbWith_Calcification.Enabled = false;
        }

        /// <summary>
        /// Personl history of breast cancer value changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Finding_rdPersonal_History_of_breast_cancer_EditValueChanged(object sender, EventArgs e)
        {
            if (this.Finding_rdPersonal_History_of_breast_cancer.EditValue.ToString() == "Y")
                this.Finding_rdPersonal_History_of_breast_cancer_view.Visible = true;
            else
                this.Finding_rdPersonal_History_of_breast_cancer_view.Visible = false;
        }

        /// <summary>
        /// Final Assessment Selected Index Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Finding_cbFinalassessment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Finding_cbFinalassessment.SelectedIndex != 0)
                this.Finding_tbFinalAssessmentDesc.Text = TextGenerator.Final_assessmentSet[Finding_cbFinalassessment.SelectedIndex];
            else
                this.Finding_tbFinalAssessmentDesc.Text = string.Empty;
        }

        /// <summary>
        /// Default Hyper link clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HyperlinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Windows.Forms.LinkLabel hyperlink = sender as System.Windows.Forms.LinkLabel;
            if (hyperlink != null)
            {
                switch (hyperlink.Tag.ToString())
                {
                    case "ADT": this.Arch_rdArchitectural_Distortion_Type.EditValue = string.Empty; break;
                    case "ADO": this.Arch_rbObject_Type.EditValue = string.Empty; break;
                    case "ASF": this.Asso_rdFinding_Type.EditValue = string.Empty; break;
                    case "COT": this.cal_rdCalObjType.EditValue = string.Empty; break;
                    case "MG_D": this.Sign_rdDensity.EditValue = string.Empty; break;
                    case "MG_DWF": this.Sign_rbWith_Calcification.EditValue = string.Empty; break;
                    case "MG_M": this.Sign_rbMagin.EditValue = string.Empty; break;
                    case "MG_S": this.Sign_rbShape.EditValue = string.Empty; break;
                    case "US_EP": this.radioGroup4.EditValue = string.Empty; break;
                    case "US_LB": this.radioGroup5.EditValue = string.Empty; break;
                    case "US_M": this.US_rdMargin.EditValue = string.Empty; break;
                    case "US_MT": this.US_rdMassType.EditValue = string.Empty; break;
                    case "US_OFM": this.US_rdOrientationOfMass.EditValue = string.Empty; break;
                    case "US_PAF": this.US_rdPosteriorAcousticFeatures.EditValue = string.Empty; break;
                }
            }
        }
        #endregion

        #region Setter Event
        /// <summary>
        /// This method use to switch active us mass or mg mass
        /// </summary>
        /// <param name="active">boolean active</param>
        private void SetVisibleUSMass(bool active)
        {
            if (!active)
            {
                //Clear value
                this.US_rdMargin.EditValue = string.Empty;
                this.US_rdMassType.EditValue = string.Empty;
                this.US_rdOrientationOfMass.EditValue = string.Empty;
                this.US_rdPosteriorAcousticFeatures.EditValue = string.Empty;
                this.radioGroup4.EditValue = string.Empty;
                this.radioGroup5.EditValue = string.Empty;
            }
            else
            {
                this.Sign_cbFindingType.SelectedIndex = 0;
                this.Sign_rbMagin.EditValue = string.Empty;
                this.Sign_rbShape.EditValue = string.Empty;
                this.Sign_rbWith_Calcification.EditValue = string.Empty;
                this.Sign_rdDensity.EditValue = string.Empty;
            }
            this.US_rdMargin.Visible = active;
            this.US_rdMassType.Visible = active;
            this.US_rdOrientationOfMass.Visible = active;
            this.US_rdPosteriorAcousticFeatures.Visible = active;
            this.radioGroup4.Visible = active;
            this.radioGroup5.Visible = active;
            this.US_txtEchoPattern.Visible = active;
            this.US_txtLesionBoundary.Visible = active;
            this.US_txtMargin.Visible = active;
            this.US_txtMassType.Visible = active;
            this.US_txtOrientation.Visible = active;
            this.US_txtPosteriorAcousticfeatures.Visible = active;
            //Hyper link default
            this.ilUSEchoPattern.Visible = active;
            this.ilUSLesionBoundary.Visible = active;
            this.ilUSMargin.Visible = active;
            this.ilUSMassType.Visible = active;
            this.ilUSOrientation.Visible = active;
            this.ilUSPosteriorAcoustic.Visible = active;

            this.Sign_cbFindingType.Enabled = !active;
            this.Sign_rbMagin.Visible = !active;
            this.Sign_rbShape.Visible = !active;
            this.Sign_rbWith_Calcification.Visible = !active;
            this.Sign_rdDensity.Visible = !active;
            this.Sign_txtDensity.Visible = !active;
            this.Sign_txtMagin.Visible = !active;
            this.Sign_txtShape.Visible = !active;
            this.Sign_txtWith_Calcification.Visible = !active;

            this.ilMGDensity.Visible = !active;
            this.ilMGDensityWithFat.Visible = !active;
            this.ilMGMargin.Visible = !active;
            this.ilMGShape.Visible = !active;
        }

        /// <summary>
        /// This method use to set active MG Mass
        /// </summary>
        /// <param name="active">boolean active</param>
        private void SetActiveMGMass(bool active)
        {
            if (!active)
            {
                //Clear value
                //this.Sign_cbFindingType.SelectedIndex = 0;
                this.Sign_rbMagin.EditValue = string.Empty;
                this.Sign_rbShape.EditValue = string.Empty;
                this.Sign_rbWith_Calcification.EditValue = string.Empty;
                this.Sign_rdDensity.EditValue = string.Empty;
            }
            this.Sign_rbMagin.Enabled = active;
            this.Sign_rbShape.Enabled = active;
            this.Sign_rdDensity.Enabled = active;
            if(this.Sign_rdDensity.EditValue == null || this.Sign_rdDensity.EditValue.ToString() == string.Empty)
                this.Sign_rbWith_Calcification.Enabled = false;
            else
                this.Sign_rbWith_Calcification.Enabled = true;
        }
        /// <summary>
        /// this method use to set active calcification group
        /// </summary>
        /// <param name="active">boolean active</param>
        private void SetActiveCalcificationGroup(bool active)
        {
            if (!active)
            {
                //Clear value
                this.cal_chkAmorphous_or_Indistinct_Calcifications.Checked = false;
                this.cal_chkCoarse_Heterogeneous_Calcifications.Checked = false;
                this.cal_chkCoarse_or_popcorn_like_Calcifications.Checked = false;
                this.cal_chkDiffuse_Scattered.Checked = false;
                this.cal_chkDystrophic_Calcifications.Checked = false;
                this.cal_chkEggshell_or_Rim_Calcifications.Checked = false;
                this.cal_chkFine_Linear_or_Fine_linear_Branching_Calcifications.Checked = false;
                this.cal_chkFine_Pleomorphic_Calcification.Checked = false;
                this.cal_chkGrouped_Clustered.Checked = false;
                this.cal_chkLarge_rod_like_Calcifications.Checked = false;
                this.cal_chkLinear.Checked = false;
                this.cal_chkLucent_centered_Calcifications.Checked = false;
                this.cal_chkMilk_of_Calcium_Calcifications.Checked = false;
                this.cal_chkRegional.Checked = false;
                this.cal_chkRound_Calcifications.Checked = false;
                this.cal_chkSegmental.Checked = false;
                this.cal_chkSkin_Calcifications.Checked = false;
                this.cal_chkSuture_Calcifications.Checked = false;
                this.cal_chkVascular_Calcifications.Checked = false;
                this.cal_rdCalObjType.EditValue = string.Empty;
                this.cal_tbNumberOfCalcificationObject.Text = string.Empty;
            }
            this.cal_chkAmorphous_or_Indistinct_Calcifications.Enabled = active;
            this.cal_chkCoarse_Heterogeneous_Calcifications.Enabled = active;
            this.cal_chkCoarse_or_popcorn_like_Calcifications.Enabled = active;
            this.cal_chkDiffuse_Scattered.Enabled = active;
            this.cal_chkDystrophic_Calcifications.Enabled = active;
            this.cal_chkEggshell_or_Rim_Calcifications.Enabled = active;
            this.cal_chkFine_Linear_or_Fine_linear_Branching_Calcifications.Enabled = active;
            this.cal_chkFine_Pleomorphic_Calcification.Enabled = active;
            this.cal_chkGrouped_Clustered.Enabled = active;
            this.cal_chkLarge_rod_like_Calcifications.Enabled = active;
            this.cal_chkLinear.Enabled = active;
            this.cal_chkLucent_centered_Calcifications.Enabled = active;
            this.cal_chkMilk_of_Calcium_Calcifications.Enabled = active;
            this.cal_chkRegional.Enabled = active;
            this.cal_chkRound_Calcifications.Enabled = active;
            this.cal_chkSegmental.Enabled = active;
            this.cal_chkSkin_Calcifications.Enabled = active;
            this.cal_chkSuture_Calcifications.Enabled = active;
            this.cal_chkVascular_Calcifications.Enabled = active;
            this.cal_rdCalObjType.Enabled = active;
            this.cal_tbNumberOfCalcificationObject.Enabled = active;
            this.ilCalcificationObjectType.Enabled = active;
        }

        /// <summary>
        /// this method use to set active architectural distortion group
        /// </summary>
        /// <param name="active">boolean active</param>
        private void SetActiveArchitecturalDistortionGroup(bool active)
        {
            if (!active)
            {
                //Clear value
                this.Arch_rbObject_Type.EditValue = string.Empty;
                this.Arch_rdArchitectural_Distortion_Type.EditValue = string.Empty;
                this.Arch_tbNumber_of_architectural_Distortion_objects.Text = string.Empty;
            }
            this.Arch_rbObject_Type.Enabled = active;
            this.Arch_rdArchitectural_Distortion_Type.Enabled = active;
            this.Arch_tbNumber_of_architectural_Distortion_objects.Enabled = active;
            this.ilArchitectDisType.Enabled = active;
            this.ilArchObjectType.Enabled = active;
        }

        /// <summary>
        /// This method use to set actvie datetime editors
        /// </summary>
        /// <param name="active"></param>
        private void SetActiveDateRangeEditor(bool active)
        {
            this.dtSearchFrom.Enabled = active;
            this.dtSearchTo.Enabled = active;
        }

        /// <summary>
        /// 
        /// </summary>
        private void ClearFindingGroup()
        {
            this.Find_cbBreast_Composition.SelectedIndex = 0;
            this.Find_cbPatient_Type.SelectedIndex = 0;
            this.Find_tbNumber_of_Masses.Text = string.Empty;
            this.Finding_cbCinicalHistory.SelectedIndex = 0;
            this.Finding_cbFinalassessment.SelectedIndex = 0;
            this.Finding_cbRecommendation.SelectedIndex = 0;
            this.Finding_chkMultiple.Checked = false;
            this.Finding_chkNvMG.Checked = false;
            this.Finding_chkNvUS.Checked = false;
            this.Finding_rdFamily_history_of_breast_cancer.EditValue = "N";
            this.Finding_rdPersonal_History_of_breast_cancer.EditValue = "N";
            this.Finding_rdPersonal_History_of_breast_cancer_view.EditValue = "L";
            this.cbBreatView.SelectedIndex = 0;
            this.cbClockLocation.SelectedIndex = 0;
            this.Sign_cbFindingType.SelectedIndex = 0;
            
        }
        #endregion

        #region Load Search Result
        /// <summary>
        /// This method use to load search result
        /// </summary>
        /// <param name="ds"></param>
        private void LoadSearchResult(DataSet ds)
        {
            if (ds == null)
                return;
            else if (ds.Tables.Count == 0)
                return;
            else
            {
                this.dtSearchResult = ds.Tables[0];
                this.gridControl1.DataSource = this.dtSearchResult;
            }
        }
        #endregion
    }
}