using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.NET.Mammogram.ResultEntry.BIRAD.Common;
using System.Data;
using Miracle.RtfDocumentBuilder;

namespace Envision.NET.Mammogram.ResultEntry.BIRAD.Helper
{
    public class TextGenerator
    {
        public static string[] Verbs = { "is", "am", "are", "was", "were", "has", "have", "had", "will", "would" };
        public static string[] PatientTypeSet = {
                                                "(Select)",
                                                "Routine Screening",
                                                "Additional evaluation follow up for a recent routine screening exam",
                                                "Evaluation of a symptom or a finding at clinical examination",
                                                "Follow-up at short interval(<9 months) from prior exam",
                                                "History of breast augmentation (No current complaints)",
                                                "Prior to breast reduction surgery",
                                                "Prior to radiation therapy",
                                                "Additional evaluation as follow-up for a non-screening exam from another facility",
                                                "Other"
                                         };
        public static string[] BreastCompositionSet = {
                                                "(Select)",
                                                "Almost Entirely Flat (<25% glandular)",
                                                "Scattered Fibroglandular Densities (25-50%)",
                                                "Heterogeneously Dense Breast Tissue (51-75%)",
                                                "Extremely Dense (> 75% glandular)",
                                            };
        public static string[] FindingTypeSet = {
                                                "Mass",
                                                "Calcification",
                                                //"Mass and calcification",
                                                "Architectural distortion",
                                                "Asymmetric density",
                                         };
        public static string[] ReportGroupCaptionSet = {
                                                        "DEMOGRAPHIC:",
                                                        "CLINICAL HISTORY:",
                                                        "COMPARISON:",
                                                        "MAMMOGRAM FINDING:",
                                                        "ULTRASOUND FINDING:",
                                                        "IMPRESSION:",
                                                        "FINAL ASSESSMENT:",
                                                        "RECOMMENDATION:"
                                                    };
        public static string[] Final_assessmentSet = {
                                                          "(Select)",
                                                          "1:Negative, Biopsy should be considered",
                                                          "2:Benign Finding(s), Biopsy should be considered",
                                                          "3:Probably Benign finding – Initial short interval follow-up suggested, Biopsy should be considered",
                                                          "4A:Low suspicion for malignancy, Biopsy should be considered",
                                                          "4B:Intermediate Concern of malignancy, Biopsy should be considered",
                                                          "4C:Mediate Concern , but not elastic for malignancy, Biopsy should be considered",
                                                          "5:Highly suggestive of malignancy – Appropriate action should be taken",
                                                          "6:Known biopsy – Proven malignancy – Appropriate action should be taken"
                                                  };
        public static string[] RecommendationSet = { 
                                                        "(Select)",
                                                        "Annual mammogram",
                                                        "Annual mammogram and Ultrasound",
                                                        "Mammogram 6 months for left breast",
                                                        "Mammogram 6 months for right breast",
                                                        "Ultrasound 6 months for left breast",
                                                        "Ultrasound 6 months for right breast",
                                                        "Other"
                                                   };

        public static Dictionary<string, string> ShapeDictionary = new Dictionary<string, string>();
        public static Dictionary<string, string> MarginDictionary = new Dictionary<string, string>();
        public static Dictionary<string, string> DensityDictionary = new Dictionary<string, string>();
        public static Dictionary<string, string> DensityWithCalcDictionary = new Dictionary<string, string>();
        public static Dictionary<string, string> AssociateDictionary = new Dictionary<string, string>();
        public static Dictionary<string, string> MassCystsDictionary = new Dictionary<string, string>();
        public static Dictionary<string, string> OrientationOfMassDictionary = new Dictionary<string, string>();
        public static Dictionary<string, string> MarginOfUSDictionary = new Dictionary<string, string>();
        public static Dictionary<string, string> LesionBoundaryDictionary = new Dictionary<string, string>();
        public static Dictionary<string, string> EchoPatternDictionary = new Dictionary<string, string>();
        public static Dictionary<string, string> PosteriorAcousticFeaturesDictionary = new Dictionary<string, string>();
        private static Miracle.RtfDocumentBuilder.RTFDocument document;

        static TextGenerator()
        {
            //Shape
            ShapeDictionary.Add("R", "Round");
            ShapeDictionary.Add("O", "Oval");
            ShapeDictionary.Add("L", "Lobular");
            ShapeDictionary.Add("I", "Irregular");
            //Margin
            MarginDictionary.Add("C", "Circumscribed");
            MarginDictionary.Add("S", "Spiculated");
            MarginDictionary.Add("I", "Indistinct");
            MarginDictionary.Add("O", "Obscured");
            MarginDictionary.Add("M", "Microlobulated");
            //Density type
            DensityDictionary.Add("Y", "Hyperdense");
            DensityDictionary.Add("H", "Hypodense");
            DensityDictionary.Add("I", "Isodense");
            DensityDictionary.Add("M", "Mixed fat density");
            DensityDictionary.Add("P", "Pure fat density");
            //Density With Fat
            DensityWithCalcDictionary.Add("B", "Benign");
            DensityWithCalcDictionary.Add("M", "Malignant");
            DensityWithCalcDictionary.Add("I", "Indetermine");
            //Associate Dictionary
            AssociateDictionary.Add("A", "Skin Retraction");
            AssociateDictionary.Add("B", "Nipple Retraction");
            AssociateDictionary.Add("C", "Skin Thickening");
            AssociateDictionary.Add("D", "Trabecular Thickening");
            AssociateDictionary.Add("E", "Skin Lesion");
            AssociateDictionary.Add("F", "Axillary");
            AssociateDictionary.Add("G", "Other");

            //Cysts
            MassCystsDictionary.Add("A", "Simple Cyst");
            MassCystsDictionary.Add("B", "Complicated Cyst");
            MassCystsDictionary.Add("C", "Complex Cyst");
            MassCystsDictionary.Add("D", "Solid Mass");
            
            //Orientation Of Mass
            OrientationOfMassDictionary.Add("P", "Parallel to skin");
            OrientationOfMassDictionary.Add("N", "Not parallel to skin");

            //Margin Of US Dictionary
            MarginOfUSDictionary.Add("C", "Circumscribed");
            MarginOfUSDictionary.Add("M", "Mircrolobulated");
            MarginOfUSDictionary.Add("I", "Indistinct");
            MarginOfUSDictionary.Add("A", "Angular");
            MarginOfUSDictionary.Add("S", "Spiculated");

            //Lesion Boundary
            LesionBoundaryDictionary.Add("A", "Abrupt interface");
            LesionBoundaryDictionary.Add("E", "Echogenic halo");

            //Echo Pattern
            EchoPatternDictionary.Add("A", "Anechoic");
            EchoPatternDictionary.Add("B", "Hyperechoic");
            EchoPatternDictionary.Add("C", "Isoechoic");
            EchoPatternDictionary.Add("D", "Hypoechoic");
            EchoPatternDictionary.Add("E", "Complex");

            //Posterior Acoustic Features
            PosteriorAcousticFeaturesDictionary.Add("A", "No");
            PosteriorAcousticFeaturesDictionary.Add("B", "Enchancement ");
            PosteriorAcousticFeaturesDictionary.Add("C", "Shadowing");
            PosteriorAcousticFeaturesDictionary.Add("D", "Combined ");
        }

        /// <summary>
        /// This method use to genarate rtf text
        /// </summary>
        /// <param name="patientTypeIndex">patient type index</param>
        /// <param name="patientTypeText">patient type text ( case:Other )</param>
        /// <param name="breastCompsIndex">breast composition index</param>
        /// <param name="finalassessmentIndex">final assessment index</param>
        /// <param name="recommendationIndex">recommendation index</param>
        /// <param name="nvMG">is negative for mammogram flag</param>
        /// <param name="nvUS">is negative for ultrasound flag</param>
        /// <param name="recommendationText">recommendation text (case:Other)</param>
        /// <param name="familyHistoryOfBreastCancerValue">family history of breast cancer value</param>
        /// <param name="PersonalHistoryOfBreastCancerValue">Personal History OF Breast Cancer value</param>
        /// <param name="PersonalHistoryOfBreastCancerViewValue">Personal History Of Breast Cancer view value</param>
        /// <param name="clinicalHistoryIndex">Clinical History index</param>
        /// <param name="isMultipleMass">is multiple mass flag</param>
        /// <param name="dsDominantCysts">Dominant Cysts dataset</param>
        /// <param name="summaryText">summary text</param>
        /// <param name="drComparsion">Comparsion DataRows</param>
        /// <param name="comparsionText">Compasion Text (case:Free text)</param>
        /// <param name="markList">Marker List</param>
        /// <param name="dsDemograhic">Demographic DataSet</param>
        /// <returns></returns>
        /// 
        public static string GenerateRTFText(int patientTypeIndex
            , string patientTypeText
            , int breastCompsIndex
            , int finalassessmentIndex
            , int recommendationIndex
            , string recommendationIndexText
            , bool nvMG
            , bool nvUS
            , string recommendationText
            , string familyHistoryOfBreastCancerValue
            , string PersonalHistoryOfBreastCancerValue
            , string PersonalHistoryOfBreastCancerViewValue
            , int clinicalHistoryIndex
            , bool isMultipleMass
            , DataSet dsDominantCysts
            , string summaryText
            , DataRow[] drComparsion
            , string comparsionText
            , List<MarkStruct> markList
            , DataRow dsDemograhic
            , string LeftStream
            , string RightStrem
            , bool isShowLeftImage
            , bool isShowRightImage
            , string associateText
            , string comment)
        {
            summaryText = summaryText.Replace("Times New Roman", "Microsoft Sans Serif");
            string _str_rtf = string.Empty;
            document = new Miracle.RtfDocumentBuilder.RTFDocument();
            //Clinical History Caption
            //document.Add(new RTFParagraph(ReportGroupCaptionSet[1], new RTFFont(true), 0, 1));
            document.AddParagraph(new Miracle.RtfDocumentBuilder.RTFParagraph(ReportGroupCaptionSet[1], Miracle.RtfDocumentBuilder.Core.FontStyles.Bold));
            Miracle.RtfDocumentBuilder.RTFParagraph pg = new Miracle.RtfDocumentBuilder.RTFParagraph();
            //Personal History of Breast Cancer
            if (PersonalHistoryOfBreastCancerValue != string.Empty)
            {
                if (PersonalHistoryOfBreastCancerValue == "N")
                {
                    pg.AddContent(Miracle.RtfDocumentBuilder.RTFText.ParseToRtf("Patient with no personal history of breast cancer "));
                    //document.Add(new RTFParagraph("Patient with no personal history of breast cancer "));
                    //document.Add(new RTFParagraph(PersonalHistoryOfBreastCancerViewValue == "L" ? "Left" : "Right"));
                    //document.Add(new RTFParagraph("  breast"));
                }
                else
                {

                    pg.AddContent(Miracle.RtfDocumentBuilder.RTFText.ParseToRtf("Patient with personal history of breast cancer on "));
                    pg.AddContent(Miracle.RtfDocumentBuilder.RTFText.ParseToRtf(PersonalHistoryOfBreastCancerViewValue == "L" ? "left" : "right"));
                    pg.AddContent(Miracle.RtfDocumentBuilder.RTFText.ParseToRtf("  breast "));
                    //document.AddParagraph(pg);
                    //document.Add(new RTFParagraph("Patient with personal history of breast cancer on "));
                    //document.Add(new RTFParagraph(PersonalHistoryOfBreastCancerViewValue == "L" ? "left" : "right"));
                    //document.Add(new RTFParagraph("  breast "));
                }
            }
            if (familyHistoryOfBreastCancerValue != string.Empty)
            {
                if (familyHistoryOfBreastCancerValue == "N")
                {
                    pg.AddContent(Miracle.RtfDocumentBuilder.RTFText.ParseToRtf(" and no family history of breast cancer is "));
                    //document.Add(new RTFParagraph(" and no family history of breast cancer is "));
                    //text += "\r\n";
                }
                else
                {
                    //Miracle.RtfDocumentBuilder.RTFParagraph pg = new Miracle.RtfDocumentBuilder.RTFParagraph();
                    pg.AddContent(Miracle.RtfDocumentBuilder.RTFText.ParseToRtf(" and family history of "));
                    pg.AddContent(Miracle.RtfDocumentBuilder.RTFText.ParseToRtf(familyHistoryOfBreastCancerValue == "1" ? " 1st degree " : " 2nd degree "));
                    pg.AddContent(Miracle.RtfDocumentBuilder.RTFText.ParseToRtf(" of breast cancer is "));
                    //document.AddParagraph(pg);
                    //document.Add(new RTFParagraph(" and family history of "));
                    //document.Add(new RTFParagraph(familyHistoryOfBreastCancerValue == "1" ? " 1st degree " : " 2nd degree "));
                    //document.Add(new RTFParagraph(" of breast cancer is "));
                }
                //document.Add(new RTFParagraph(string.Empty, 0, 1));
            }
            if (clinicalHistoryIndex > 0)
            {
                //Miracle.RtfDocumentBuilder.RTFParagraph pg = new Miracle.RtfDocumentBuilder.RTFParagraph();
                if (clinicalHistoryIndex == 1)
                    pg.AddContent(Miracle.RtfDocumentBuilder.RTFText.ParseToRtf(" screened for "));
                //document.Add(new RTFParagraph(" screened for "));
                else
                    pg.AddContent(Miracle.RtfDocumentBuilder.RTFText.ParseToRtf(" diagnosed for "));
                    //document.AddParagraph(" diagnosed for ");
                    //document.Add(new RTFParagraph(" diagnosed for "));

                if (patientTypeIndex != 0)
                {
                    if (patientTypeIndex == PatientTypeSet.Length - 1)
                    {
                        if (patientTypeText.Trim().Length > 0)
                            pg.AddContent(Miracle.RtfDocumentBuilder.RTFText.ParseToRtf(patientTypeText + "."));
                            //document.Add(new RTFParagraph(patientTypeText + "."));
                        //text += " : " + patientTypeText + "\r\n";
                    }
                    else
                    {
                        pg.AddContent(Miracle.RtfDocumentBuilder.RTFText.ParseToRtf(PatientTypeSet[patientTypeIndex] + "."));
                        //document.Add(new RTFParagraph(PatientTypeSet[patientTypeIndex] + "."));
                        //text += " : " + PatientTypeSet[patientTypeIndex] + "\r\n";
                    }
                }
                document.AddParagraph(pg);
                document.AddParagraph(string.Empty);
                //document.Add(new RTFParagraph(string.Empty, 0, 2));
            }
            //else
            //{
            //    if (familyHistoryOfBreastCancerValue != "N")
            //    {
            //        document.Add(new RTFParagraph("  has a family history of breat cancer in "));
            //        document.Add(new RTFParagraph(familyHistoryOfBreastCancerValue == "1" ? "frist degee" : "second degee" ,0 ,1));
            //        //text += "\r\n";
            //    }
            //    else
            //        document.Add(new RTFParagraph(string.Empty, 0, 1));
            //}

            if (drComparsion != null)
            {
                if (drComparsion.Length > 0)
                {
                    Miracle.RtfDocumentBuilder.RTFParagraph pg1 = new Miracle.RtfDocumentBuilder.RTFParagraph();
                    //Comparison Caption
                    document.AddParagraph(new Miracle.RtfDocumentBuilder.RTFParagraph(ReportGroupCaptionSet[2], Miracle.RtfDocumentBuilder.Core.FontStyles.Bold));
                    //document.Add(new RTFParagraph(ReportGroupCaptionSet[2], new RTFFont(true), 0, 1));

                    if (drComparsion.Length == 1)
                        pg1.AddContent(Miracle.RtfDocumentBuilder.RTFText.ParseToRtf("Compared with the study "));
                    //document.Add(new RTFParagraph("Compared with the study "));
                    else
                        pg1.AddContent(Miracle.RtfDocumentBuilder.RTFText.ParseToRtf("Compared with studies "));
                        //document.Add(new RTFParagraph("Compared with studies "));
                    for (int i = 0; i < drComparsion.Length; i++)
                    {
                        pg1.AddContent(Miracle.RtfDocumentBuilder.RTFText.ParseToRtf(drComparsion[i]["EXAM_NAME"] + " dated " + Convert.ToDateTime(drComparsion[i]["EXAM_DT"]).ToShortDateString()));
                        //document.Add(new RTFParagraph(drComparsion[i]["EXAM_NAME"] + " dated " + Convert.ToDateTime(drComparsion[i]["EXAM_DT"]).ToShortDateString()));
                        if (i + 1 == drComparsion.Length - 1)
                            pg1.AddContent(Miracle.RtfDocumentBuilder.RTFText.ParseToRtf("  and "));
                        //document.Add(new RTFParagraph("  and "));
                        else if (i + 1 == drComparsion.Length)
                            //document.Add(new RTFParagraph(".", 0, 2));
                            pg1.AddContent(Miracle.RtfDocumentBuilder.RTFText.ParseToRtf("."));
                        else
                            pg1.AddContent(Miracle.RtfDocumentBuilder.RTFText.ParseToRtf(", "));
                            //document.Add(new RTFParagraph(", "));
                    }
                    document.AddParagraph(pg1);
                    document.AddParagraph(string.Empty);
                }
                else if (comparsionText.Length > 0)
                {
                    //Comparison Caption
                    //document.Add(new RTFParagraph(ReportGroupCaptionSet[2], new RTFFont(true), 0, 1));
                    document.AddParagraph(new Miracle.RtfDocumentBuilder.RTFParagraph(ReportGroupCaptionSet[2], Miracle.RtfDocumentBuilder.Core.FontStyles.Bold));
                    //document.Add(new RTFParagraph(comparsionText + ".", 0, 2));
                    document.AddParagraph(comparsionText + ".");
                    document.AddParagraph(string.Empty);
                }
                //else
                //    document.Add(new RTFParagraph(string.Empty, 0, 1));
            }
            else if (comparsionText.Length > 0)
            {
                //Comparison Caption
                document.AddParagraph(new Miracle.RtfDocumentBuilder.RTFParagraph(ReportGroupCaptionSet[2], Miracle.RtfDocumentBuilder.Core.FontStyles.Bold));
                //document.Add(new RTFParagraph(ReportGroupCaptionSet[2], new RTFFont(true), 0, 1));
                //document.Add(new RTFParagraph(comparsionText + ".", new RTFFont(true), 0, 2));
                document.AddParagraph(comparsionText + ".");
                document.AddParagraph(string.Empty);
            }
            //else
            //{
            //    document.Add(new RTFParagraph(string.Empty, 0, 1));
            //}
            //Mammographic Finding Caption
            //RTFParagraph mmParagraph = new RTFParagraph(ReportGroupCaptionSet[3], new RTFFont(true), 0, 1);
            //document.Add(mmParagraph);
            document.AddParagraph(new Miracle.RtfDocumentBuilder.RTFParagraph(ReportGroupCaptionSet[3], Miracle.RtfDocumentBuilder.Core.FontStyles.Bold));
            if (breastCompsIndex != 0)
            {
                //document.Add(new RTFParagraph("Breast Composition: " + BreastCompositionSet[breastCompsIndex] + ".", 0, 2));
                document.AddParagraph("Breast Composition: " + BreastCompositionSet[breastCompsIndex] + ".");
            }
            if (nvMG)
            {
                //Negative for Mammogram
                //document.Add(new RTFParagraph("No mass, Suspicious calcification or focal architectural distortion are observed.", 0, 2));
                document.AddParagraph("No mass, Suspicious calcification or focal architectural distortion are observed.");
                document.AddParagraph(string.Empty);
            }
            else
            {
                //Detail
                if (markList != null)
                {
                    if (isMultipleMass)
                    {
                        //Multiple mass
                        if (dsDominantCysts != null)
                        {
                            if (dsDominantCysts.Tables.Count > 0)
                            {
                                if (dsDominantCysts.Tables[0].Rows.Count > 0)
                                {
                                    //Miracle.RtfDocumentBuilder.RTFParagraph pg = new Miracle.RtfDocumentBuilder.RTFParagraph();
                                    foreach (DataRow dr in dsDominantCysts.Tables[0].Rows)
                                    {
                                        if (dr["MASS_NO"].ToString().Trim().Length == 0)
                                            continue;
                                        document.AddParagraph("The dominant cyst in the " + dr["BREAST_VIEW"].ToString().ToLower()
                                            + " breast is at clock location " + dr["LOCATION"] + ", measuring " + dr["SIZE"].ToString().ToLower() + ".");
                                        //document.Add(new RTFParagraph("The dominant cyst in the " + dr["BREAST_VIEW"].ToString().ToLower()
                                        //    + " breast is at clock location " + dr["LOCATION"] + ", measuring " + dr["SIZE"].ToString().ToLower() + ".", 0, 1));
                                    }
                                    //document.Add(new RTFParagraph(string.Empty, 0, 1));
                                    document.AddParagraph(string.Empty);
                                }
                            }
                        }
                    }
                    #region MASS DETAIL
                    else
                    {
                        //text += "\r\n\r\nNumber of mass(es) found is : " + markList.Count + "\r\n";
                        if (markList.Count > 0)
                        {
                            string _subTextLeft = @"\ul LEFT BREAST:\ulnone\par";
                            string _subTextRight = @"\ul RIGHT BREAST:\ulnone\par";
                            string _mass_subTextLeft = @"\i Mass:\i0\par";
                            string _calcification_subTextLeft = @"\i Calcification:\i0\par";
                            string _mass_and_calcification_subTextLeft = @"\i Mass and Calcification :\i0\par";
                            string _architectural_distortion_subTextLeft = @"\i Architectural Distortion :\i0\par";
                            string _asymmetric_density_subTextLeft = @"\i Asymmetric Density:\i0\par";
                            string _mass_subTextRight = @"\i Mass:\i0\par";
                            string _calcification_subTextRight = @"\i Calcification:\i0\par";
                            string _mass_and_calcification_subTextRight = @"\i Mass and Calcification :\i0\par"; ;
                            string _architectural_distortion_subTextRight = @"\i Architectural Distortion :\i0\par";
                            string _asymmetric_density_subTextRight = @"\i Asymmetric Density:\i0\par";
                            //Keep Lenght
                            int lenght_mass_subTextLeft = _mass_subTextLeft.Length;
                            int lenght_calcification_subTextLeft = _calcification_subTextLeft.Length;
                            int lenght_mass_and_calcification_subTextLeft = _mass_and_calcification_subTextLeft.Length;
                            int lenght_architectural_distortion_subTextLeft = _architectural_distortion_subTextLeft.Length;
                            int lenght_asymmetric_density_subTextLeft = _asymmetric_density_subTextLeft.Length;
                            int lenght_mass_subTextRight = _mass_subTextRight.Length;
                            int lenght_calcification_subTextRight = _calcification_subTextRight.Length;
                            int lenght_mass_and_calcification_subTextRight = _mass_and_calcification_subTextRight.Length;
                            int lenght_architectural_distortion_subTextRight = _architectural_distortion_subTextRight.Length;
                            int lenght_asymmetric_density_subTextright = _asymmetric_density_subTextRight.Length;
                            for (int i = 0; i < markList.Count; i++)
                            {
                                if (markList[i].IsUsMassDetail == "Y")
                                    continue;
                                EnvisionBreastControl.Lib.CShapeControl control = markList[i].MarkObject as EnvisionBreastControl.Lib.CShapeControl;
                                if (control.Name.Contains("Left"))
                                {
                                    string _subText = string.Empty;
                                    //text += "\r\n\tMass : " + (i + 1) + ".";
                                    //text += " Finding type is ";
                                    int finding_type_index = EditValueConvertor.GetFindingTypeIndex(markList[i].MassDetail.FINDING_TYPE);
                                    switch (finding_type_index)
                                    {
                                        case 0: _subText = _mass_subTextLeft; break;
                                        case 1: _subText = _calcification_subTextLeft; break;
                                        //case 2: _subText = _mass_and_calcification_subTextLeft; break;
                                        case 2: _subText = _architectural_distortion_subTextLeft; break;
                                        case 3: _subText = _asymmetric_density_subTextLeft; break;
                                    }
                                    //mark no and location
                                    _subText += "\t Mark " + markList[i].MassDetail.MASS_NO 
                                        +  " at clock location " + markList[i].MassDetail.MASS_LOCATION_CLOCK;
                                    if (finding_type_index == 0)
                                    {
                                        _subText += " has ";
                                        //shape and margin
                                        if (markList[i].MassDetail.MASS_SHAPE.Trim().Length > 0)
                                        {
                                            try
                                            {
                                                _subText += ShapeDictionary[markList[i].MassDetail.MASS_SHAPE] + " shape";
                                                if (markList[i].MassDetail.MASS_MARGIN.Trim().Length > 0)
                                                    _subText += " and " + MarginDictionary[markList[i].MassDetail.MASS_MARGIN] + @" margin.";
                                                else
                                                {
                                                    if (markList[i].MassDetail.MASS_DENSITY_TYPE.Trim().Length > 0)
                                                        _subText += @".";
                                                    else
                                                    {
                                                        _subText += @".\par";
                                                    }
                                                }
                                            }
                                            catch 
                                            {
                                                if (markList[i].MassDetail.MASS_DENSITY_TYPE.Trim().Length > 0)
                                                    _subText += @" and Circumscribed margin."; 
                                                else
                                                    _subText += @" and Circumscribed margin.\par"; 

                                            }
                                        }
                                        else
                                        {
                                            try
                                            {
                                                if (markList[i].MassDetail.MASS_MARGIN.Trim().Length > 0)
                                                    _subText += MarginDictionary[markList[i].MassDetail.MASS_MARGIN] + " margin.";
                                                if (markList[i].MassDetail.MASS_DENSITY_TYPE.Trim().Length == 0)
                                                    _subText += @"\par";
                                            }
                                            catch { }
                                        }
                                        //density
                                        if (markList[i].MassDetail.MASS_DENSITY_TYPE.Trim().Length > 0)
                                        {
                                            _subText += "Density type is " + DensityDictionary[markList[i].MassDetail.MASS_DENSITY_TYPE];
                                            if (markList[i].MassDetail.MASS_DENSITY.Trim().Length > 0 && markList[i].MassDetail.MASS_HAS_CALCIFICATION.Trim().Length > 0)
                                                _subText += " with " + DensityWithCalcDictionary[markList[i].MassDetail.MASS_HAS_CALCIFICATION] + @" calcification.\par";
                                        }
                                    }
                                    //_subText += @"\par";
                                    //_subText += markList[i].MassDetail.BREAST_TYPE == "L" ? "Left" : "Right";
                                    //_subText += " Breast.";

                                    //Calcification
                                    if (finding_type_index == 1)
                                    {
                                        _subText += " Number of calcification is " + markList[i].MassDetail.NO_OF_CALCIFICATION_OBJECTS + " with ";
                                        _subText += markList[i].MassDetail.TYPE_OF_CALCIFICATION_OBJECT == "M" ? "Multiple" : "Single/A Few";
                                        _subText += " calcification objects.";
                                        _subText += " Calcification types are";
                                        _subText += GetCalcificationString(markList[i].MassDetail) + @".\par";
                                    }
                                    if (finding_type_index == 2)
                                    {
                                        _subText += " Number of Architectural Distortion is " + markList[i].MassDetail.NO_OF_ARCHITECTURAL_DISTORTION + " with ";
                                        _subText += markList[i].MassDetail.ARCHITECTURAL_DISTORTION_OBJECT_TYPE == "M" ? "Multiple" : "Single/A Few";
                                        _subText += " objects and type is ";
                                        if (markList[i].MassDetail.ARCHITECTURAL_DISTORTION_TYPE == "S")
                                            _subText += "Post Operative Change." + @".\par";
                                        else
                                            _subText += "Suspicious Abnormality." + @".\par";
                                    }
                                    //if (markList[i].MassDetail.ASSOCIATE_FINDING_TYPE.Trim().Length > 0)
                                    //{
                                    //    _subText += " Associate Finding is ";
                                    //    _subText += AssociateDictionary[markList[i].MassDetail.ASSOCIATE_FINDING_TYPE] + @".\par";
                                    //}

                                    if (markList[i].MassDetail.ASSOCIATE_FINDING_TYPE.Trim().Length > 0)
                                    {
                                        _subText += " Associate Finding is ";
                                        if (markList[i].MassDetail.ASSOCIATE_FINDING_TYPE.Trim() == "G")
                                            _subText += associateText;
                                        else
                                            _subText += AssociateDictionary[markList[i].MassDetail.ASSOCIATE_FINDING_TYPE] + @".\par";
                                    }

                                    switch (finding_type_index)
                                    {
                                        case 0: _mass_subTextLeft = _subText; break;
                                        case 1: _calcification_subTextLeft = _subText; break;
                                        //case 2: _mass_and_calcification_subTextLeft = _subText; break;
                                        case 2: _architectural_distortion_subTextLeft = _subText; break;
                                        case 3: _asymmetric_density_subTextLeft = _subText; break;
                                    }
                                }
                                else
                                {
                                    string _subText = string.Empty;
                                    //text += "\r\n\tMass : " + (i + 1) + ".";
                                    //text += " Finding type is ";
                                    int finding_type_index = EditValueConvertor.GetFindingTypeIndex(markList[i].MassDetail.FINDING_TYPE);
                                    switch (finding_type_index)
                                    {
                                        case 0: _subText = _mass_subTextRight; break;
                                        case 1: _subText = _calcification_subTextRight; break;
                                        //case 2: _subText = _mass_and_calcification_subTextRight; break;
                                        case 2: _subText = _architectural_distortion_subTextRight; break;
                                        case 3: _subText = _asymmetric_density_subTextRight; break;
                                    }
                                    _subText += "\t Mark " + markList[i].MassDetail.MASS_NO
                                        + " at clock location " + markList[i].MassDetail.MASS_LOCATION_CLOCK;
                                    if (finding_type_index == 0 || finding_type_index == 2)
                                    {
                                        _subText += " has ";
                                        //shape and margin
                                        if (markList[i].MassDetail.MASS_SHAPE.Trim().Length > 0)
                                        {
                                            try
                                            {
                                                _subText += ShapeDictionary[markList[i].MassDetail.MASS_SHAPE] + " shape";
                                                if (markList[i].MassDetail.MASS_MARGIN.Trim().Length > 0)
                                                    _subText += " and " + MarginDictionary[markList[i].MassDetail.MASS_MARGIN] + @" margin.";
                                                else
                                                {
                                                    if (markList[i].MassDetail.MASS_DENSITY_TYPE.Trim().Length > 0)
                                                        _subText += @".";
                                                    else
                                                    {
                                                        _subText += @".\par";
                                                    }
                                                }
                                            }
                                            catch
                                            {
                                                if (markList[i].MassDetail.MASS_DENSITY_TYPE.Trim().Length > 0)
                                                    _subText += @" and Circumscribed margin.";
                                                else
                                                    _subText += @" and Circumscribed margin.\par";

                                            }
                                        }
                                        else
                                        {
                                            try
                                            {
                                                if (markList[i].MassDetail.MASS_MARGIN.Trim().Length > 0)
                                                    _subText += MarginDictionary[markList[i].MassDetail.MASS_MARGIN] + " margin.";
                                                if (markList[i].MassDetail.MASS_DENSITY_TYPE.Trim().Length == 0)
                                                    _subText += @"\par";
                                            }
                                            catch { }
                                        }
                                        //density
                                        if (markList[i].MassDetail.MASS_DENSITY_TYPE.Trim().Length > 0)
                                        {
                                            _subText += "Density type is " + DensityDictionary[markList[i].MassDetail.MASS_DENSITY_TYPE];
                                            if (markList[i].MassDetail.MASS_DENSITY.Trim().Length > 0)
                                                _subText += " with " + DensityWithCalcDictionary[markList[i].MassDetail.MASS_HAS_CALCIFICATION] + @" calcification.\par";
                                        }
                                    }
                                    //location
                                    //_subText += "\r\n";
                                    //_subText += markList[i].MassDetail.BREAST_TYPE == "L" ? "Left" : "Right";
                                    //_subText += " Breast.";

                                    //Calcification
                                    if (finding_type_index == 1 || finding_type_index == 2)
                                    {
                                        _subText += " Number of calcification is " + markList[i].MassDetail.NO_OF_CALCIFICATION_OBJECTS + " with ";
                                        _subText += markList[i].MassDetail.TYPE_OF_CALCIFICATION_OBJECT == "M" ? "Multiple" : "Single/A Few";
                                        _subText += " Calcification Objects. ";
                                        _subText += " Calcification types are ";
                                        _subText += GetCalcificationString(markList[i].MassDetail) + @".\par";
                                    }
                                    if (finding_type_index == 3)
                                    {
                                        _subText += " Number of Architectural Distortion is " + markList[i].MassDetail.NO_OF_ARCHITECTURAL_DISTORTION + " with ";
                                        _subText += markList[i].MassDetail.ARCHITECTURAL_DISTORTION_OBJECT_TYPE == "M" ? "Multiple" : "Single/A Few";
                                        _subText += " and type is ";
                                        if (markList[i].MassDetail.ARCHITECTURAL_DISTORTION_TYPE == "S")
                                            _subText += "Post Operative Change." + @".\par";
                                        else
                                            _subText += "Suspicious Abnormality." + @".\par";
                                    }
                                    if (markList[i].MassDetail.ASSOCIATE_FINDING_TYPE.Trim().Length > 0)
                                    {
                                        _subText += " Associate Finding is ";
                                        if (markList[i].MassDetail.ASSOCIATE_FINDING_TYPE.Trim() == "G")
                                            _subText += associateText;
                                        else
                                            _subText += AssociateDictionary[markList[i].MassDetail.ASSOCIATE_FINDING_TYPE] + @".\par";
                                    }

                                    switch (finding_type_index)
                                    {
                                        case 0: _mass_subTextRight = _subText; break;
                                        case 1: _calcification_subTextRight = _subText; break;
                                        //case 2: _mass_and_calcification_subTextRight = _subText; break;
                                        case 2: _architectural_distortion_subTextRight = _subText; break;
                                        case 3: _asymmetric_density_subTextRight = _subText; break;
                                    }
                                }
                            }
                            //Get text Left
                            string _str_detail_left = _subTextLeft;
                            if (_mass_subTextLeft.Length != lenght_mass_subTextLeft)
                                _str_detail_left += _mass_subTextLeft;
                            if (_calcification_subTextLeft.Length != lenght_calcification_subTextLeft)
                                _str_detail_left += _calcification_subTextLeft;
                            if (_mass_and_calcification_subTextLeft.Length != lenght_mass_and_calcification_subTextLeft)
                                _str_detail_left += _mass_and_calcification_subTextLeft;
                            if (_architectural_distortion_subTextLeft.Length != lenght_architectural_distortion_subTextLeft)
                                _str_detail_left += _architectural_distortion_subTextLeft;
                            if (_asymmetric_density_subTextLeft.Length != lenght_asymmetric_density_subTextLeft)
                                _str_detail_left += _asymmetric_density_subTextLeft;

                            if (_str_detail_left.Length != _subTextLeft.Length)
                            {
                                document.AddParagraph(Miracle.RtfDocumentBuilder.RTFText.ParseToRtf(RTFConverter.Convert(_str_detail_left)));
                            }

                            //Get text Right
                            string _str_detail_right = _subTextRight;
                            if (_mass_subTextRight.Length != lenght_mass_subTextRight)
                                _str_detail_right += _mass_subTextRight;
                            if (_calcification_subTextRight.Length != lenght_calcification_subTextRight)
                                _str_detail_right += _calcification_subTextRight;
                            if (_mass_and_calcification_subTextRight.Length != lenght_mass_and_calcification_subTextRight)
                                _str_detail_right += _mass_and_calcification_subTextRight;
                            if (_architectural_distortion_subTextRight.Length != lenght_architectural_distortion_subTextRight)
                                _str_detail_right += _architectural_distortion_subTextRight;
                            if (_asymmetric_density_subTextRight.Length != lenght_asymmetric_density_subTextright)
                                _str_detail_right += _asymmetric_density_subTextRight;

                            if (_str_detail_right.Length != _subTextRight.Length)
                            {
                                document.AddParagraph(Miracle.RtfDocumentBuilder.RTFText.ParseToRtf(RTFConverter.Convert(_str_detail_right)));

                                //document.Add(new RTFParagraph(RTFConverter.Convert(_str_detail_right), 0, 1));
                            }
                        }
                    }
                    #endregion
                }
            }

            #region US MASS DETAIL

            Miracle.RtfDocumentBuilder.RTFParagraph usParagraph = new Miracle.RtfDocumentBuilder.RTFParagraph(ReportGroupCaptionSet[4], Miracle.RtfDocumentBuilder.Core.FontStyles.Bold);

            if (nvUS)
            {
                //US Caption
                //document.Add(usParagraph);
                document.AddParagraph(usParagraph);

                //Negative for Ultrasound
                document.AddParagraph("No mass or cyst is detected in both breast.");
                //document.Add(new RTFParagraph("No mass or cyst is detected in both breast.", 0, 2));
            }
            else
            {
                if (markList != null)
                {
                    if (markList.Count > 0)
                    {
                        string _subTextLeft = @"\ul LEFT BREAST:\ulnone\par";
                        string _subTextRight = @"\ul RIGHT BREAST:\ulnone\par";
                        string _simpleCyst_subTextLeft = string.Empty;
                        string _complicatedCyst_subTextLeft = string.Empty;
                        string _complex_subTextLeft = string.Empty;
                        string _solid_mass_subTextLeft = string.Empty;
                        string _simpleCyst_subTextRight = string.Empty;
                        string _complicatedCyst_subTextRight = string.Empty;
                        string _complex_subTextRight = string.Empty;
                        string _solid_mass_subTextRight = string.Empty;
                        string _cal_subTextRight = string.Empty;
                        string _cal_subTextLeft = string.Empty;
                        string _arch_subTextRight = string.Empty;
                        string _arch_subTextLeft = string.Empty;
                        int lenght_subTextLeft = _subTextLeft.Length;
                        int lenght_subTextRight = _subTextRight.Length;

                        for (int i = 0; i < markList.Count; i++)
                        {
                            if (markList[i].IsUsMassDetail == "N")
                                continue;
                            EnvisionBreastControl.Lib.CShapeControl control = markList[i].MarkObject as EnvisionBreastControl.Lib.CShapeControl;
                            int finding_type_index = EditValueConvertor.GetFindingTypeIndex(markList[i].MassUSDetail.FINDING_TYPE);

                            if (control.Name.Contains("Left"))
                            {
                                string _subText = string.Empty;
                                //text += "\r\n\tMass : " + (i + 1) + ".";
                                //text += " Finding type is ";
                                //int finding_type_index = EditValueConvertor.GetFindingTypeIndex(markList[i].MassDetail.FINDING_TYPE);
                                switch (markList[i].MassUSDetail.MASS_CYST_TYPE)
                                {
                                    case "A": _subText = _simpleCyst_subTextLeft; break;
                                    case "B": _subText = _complicatedCyst_subTextLeft; break;
                                    case "C": _subText = _complex_subTextLeft; break;
                                    case "D": _subText = _solid_mass_subTextLeft; break;
                                }
                                if (markList[i].MassUSDetail.MASS_CYST_TYPE.Length > 0)
                                {
                                    if (markList[i].MassUSDetail.MASS_CYST_TYPE != "D")
                                    {
                                        _subText += "\t Mark " + markList[i].MassUSDetail.MASS_NO
                                                    + " at clock location " + markList[i].MassUSDetail.MASS_LOCATION_CLOCK + " has "
                                                    + MassCystsDictionary[markList[i].MassUSDetail.MASS_CYST_TYPE] + @".\par";
                                    }
                                    else
                                    {
                                        _subText += "\t Mark " + markList[i].MassUSDetail.MASS_NO
                                            + " at clock location " + markList[i].MassUSDetail.MASS_LOCATION_CLOCK + " has "
                                            + MassCystsDictionary[markList[i].MassUSDetail.MASS_CYST_TYPE];
                                        _subText += GetSoildMassDetail(markList[i]) + @".\par";
                                        //_subText += " found at " + markList[i].MassDetail.MASS_LOCATION_CLOCK + "'s clock location\r\n";
                                    }
                                }
                                //Calcification
                                if (finding_type_index == 1 || finding_type_index == 2)
                                {
                                    _subText += " Number of calcification is " + markList[i].MassUSDetail.NO_OF_CALCIFICATION_OBJECTS + " with ";
                                    _subText += markList[i].MassUSDetail.TYPE_OF_CALCIFICATION_OBJECT == "M" ? "Multiple" : "Single/A Few";
                                    _subText += " Calcification Objects. ";
                                    _subText += " Calcification types are ";
                                    _subText += GetCalcificationString(markList[i].MassUSDetail) + @".\par";
                                }
                                if (finding_type_index == 3)
                                {
                                    _subText += " Number of Architectural Distortion is " + markList[i].MassUSDetail.NO_OF_ARCHITECTURAL_DISTORTION + " with ";
                                    _subText += markList[i].MassUSDetail.ARCHITECTURAL_DISTORTION_OBJECT_TYPE == "M" ? "Multiple" : "Single/A Few";
                                    _subText += " and type is ";
                                    if (markList[i].MassUSDetail.ARCHITECTURAL_DISTORTION_TYPE == "S")
                                        _subText += "Post Operative Change." + @".\par";
                                    else
                                        _subText += "Suspicious Abnormality." + @".\par";
                                }
                                //if (markList[i].MassDetail.ASSOCIATE_FINDING_TYPE.Trim().Length > 0)
                                //{
                                //    _subText += " Associate Finding is ";
                                //    if (markList[i].MassDetail.ASSOCIATE_FINDING_TYPE.Trim() == "G")
                                //        _subText += associateText;
                                //    else
                                //        _subText += AssociateDictionary[markList[i].MassDetail.ASSOCIATE_FINDING_TYPE] + @".\par";
                                //}

                               
                                if (markList[i].MassUSDetail.ASSOCIATE_FINDING_TYPE.Trim().Length > 0)
                                {
                                    _subText += " Associate Finding is ";
                                    if (markList[i].MassUSDetail.ASSOCIATE_FINDING_TYPE.Trim() == "G")
                                        _subText += associateText;
                                    else
                                        _subText += AssociateDictionary[markList[i].MassUSDetail.ASSOCIATE_FINDING_TYPE] + @".\par";
                                }
                                //if (markList[i].MassUSDetail.MASS_CYST_TYPE != "D")
                                //{
                                //    _subText += " found at " + markList[i].MassDetail.MASS_LOCATION_CLOCK + "'s clock location\r\n";
                                //}
                                 switch (finding_type_index)
                                {
                                    //case 0: _mass_subTextRight = _subText; break;
                                    case 1: _cal_subTextLeft = _subText; break;
                                    //case 2: _mass_and_calcification_subTextRight = _subText; break;
                                    case 2: _arch_subTextLeft = _subText; break;
                                    //case 3: _asymmetric_density_subTextRight = _subText; break;
                                }

                                switch (markList[i].MassUSDetail.MASS_CYST_TYPE)
                                {
                                    case "A": _simpleCyst_subTextLeft = _subText; break;
                                    case "B": _complicatedCyst_subTextLeft = _subText; break;
                                    case "C": _complex_subTextLeft = _subText; break;
                                    case "D": _solid_mass_subTextLeft = _subText; break;
                                }
                            }
                            else
                            {
                                string _subText = string.Empty;
                                //text += "\r\n\tMass : " + (i + 1) + ".";
                                //text += " Finding type is ";
                                //int finding_type_index = EditValueConvertor.GetFindingTypeIndex(markList[i].MassDetail.FINDING_TYPE);
                                switch (markList[i].MassUSDetail.MASS_CYST_TYPE)
                                {
                                    case "A": _subText = _simpleCyst_subTextRight; break;
                                    case "B": _subText = _complicatedCyst_subTextRight; break;
                                    case "C": _subText = _complex_subTextRight; break;
                                    case "D": _subText = _solid_mass_subTextRight; break;
                                }
                                if (markList[i].MassUSDetail.MASS_CYST_TYPE.Length > 0)
                                {
                                    if (markList[i].MassUSDetail.MASS_CYST_TYPE != "D")
                                    {
                                        _subText += "\t Mark " + markList[i].MassUSDetail.MASS_NO
                                                    + " at clock location " + markList[i].MassUSDetail.MASS_LOCATION_CLOCK + " has "
                                                    + MassCystsDictionary[markList[i].MassUSDetail.MASS_CYST_TYPE] + @".\par";
                                    }
                                    else
                                    {
                                        _subText += "\t Mark " + markList[i].MassUSDetail.MASS_NO
                                            + " at clock location " + markList[i].MassUSDetail.MASS_LOCATION_CLOCK + " has "
                                            + MassCystsDictionary[markList[i].MassUSDetail.MASS_CYST_TYPE];
                                        _subText += GetSoildMassDetail(markList[i]) + @".\par";
                                        //_subText += " found at " + markList[i].MassDetail.MASS_LOCATION_CLOCK + "'s clock location\r\n";
                                    }
                                }

                                if (markList[i].MassUSDetail.ASSOCIATE_FINDING_TYPE.Trim().Length > 0)
                                {
                                    _subText += " Associate Finding is ";
                                    if (markList[i].MassUSDetail.ASSOCIATE_FINDING_TYPE.Trim() == "G")
                                        _subText += associateText;
                                    else
                                        _subText += AssociateDictionary[markList[i].MassUSDetail.ASSOCIATE_FINDING_TYPE] + @".\par";
                                }

                                 //Calcification
                                if (finding_type_index == 1 || finding_type_index == 2)
                                {
                                    _subText += " Number of calcification is " + markList[i].MassUSDetail.NO_OF_CALCIFICATION_OBJECTS + " with ";
                                    _subText += markList[i].MassUSDetail.TYPE_OF_CALCIFICATION_OBJECT == "M" ? "Multiple" : "Single/A Few";
                                    _subText += " Calcification Objects. ";
                                    _subText += " Calcification types are ";
                                    _subText += GetCalcificationString(markList[i].MassUSDetail) + @".\par";
                                }
                                if (finding_type_index == 3)
                                {
                                    _subText += " Number of Architectural Distortion is " + markList[i].MassUSDetail.NO_OF_ARCHITECTURAL_DISTORTION + " with ";
                                    _subText += markList[i].MassUSDetail.ARCHITECTURAL_DISTORTION_OBJECT_TYPE == "M" ? "Multiple" : "Single/A Few";
                                    _subText += " and type is ";
                                    if (markList[i].MassUSDetail.ARCHITECTURAL_DISTORTION_TYPE == "S")
                                        _subText += "Post Operative Change." + @".\par";
                                    else
                                        _subText += "Suspicious Abnormality." + @".\par";
                                }

                                switch (markList[i].MassUSDetail.MASS_CYST_TYPE)
                                {
                                    case "A": _simpleCyst_subTextRight = _subText; break;
                                    case "B": _complicatedCyst_subTextRight = _subText; break;
                                    case "C": _complex_subTextRight = _subText; break;
                                    case "D": _solid_mass_subTextRight = _subText; break;
                                }

                                switch (finding_type_index)
                                {
                                    //case 0: _mass_subTextRight = _subText; break;
                                    case 1: _cal_subTextRight = _subText; break;
                                    //case 2: _mass_and_calcification_subTextRight = _subText; break;
                                    case 2: _arch_subTextRight = _subText; break;
                                    //case 3: _asymmetric_density_subTextRight = _subText; break;
                                }
                            }
                        }

                        string text_left = _simpleCyst_subTextLeft + _complicatedCyst_subTextLeft
                                + _complex_subTextLeft + _solid_mass_subTextLeft + _cal_subTextLeft + _arch_subTextLeft;
                        string text_right = _simpleCyst_subTextRight + _complicatedCyst_subTextRight
                                + _complex_subTextRight + _solid_mass_subTextRight + _cal_subTextRight + _arch_subTextRight;

                        if (text_left.Length > 0 || text_right.Length > 0)
                        {
                            //document.Add(usParagraph);
                            document.AddParagraph(usParagraph);
                            if (text_left.Length > 0)
                            {
                                document.AddParagraph(RTFConverter.Convert(_subTextLeft + _simpleCyst_subTextLeft + _complicatedCyst_subTextLeft
                                    + _complex_subTextLeft + _solid_mass_subTextLeft));
                                //document.Add(new RTFParagraph(RTFConverter.Convert(_subTextLeft + _simpleCyst_subTextLeft + _complicatedCyst_subTextLeft
                                //    + _complex_subTextLeft + _solid_mass_subTextLeft), 0, 1));
                            }

                            if (text_right.Length > 0)
                            {
                                document.AddParagraph(RTFConverter.Convert(_subTextRight + _simpleCyst_subTextRight + _complicatedCyst_subTextRight
                                    + _complex_subTextRight + _solid_mass_subTextRight));
                                //document.Add(new RTFParagraph(RTFConverter.Convert(_subTextRight + _simpleCyst_subTextRight + _complicatedCyst_subTextRight
                                //    + _complex_subTextRight + _solid_mass_subTextRight), 0, 1));
                            }
                        }
                        else
                        {
                            document.RemoveParagraph(usParagraph);
                        }
                    }
                }
            }
            #endregion

            #region Impression
            //Impression 
            //document.Add(new RTFParagraph(ReportGroupCaptionSet[5], new RTFFont(true), 0, 1));
            document.AddParagraph(new Miracle.RtfDocumentBuilder.RTFParagraph(ReportGroupCaptionSet[5], Miracle.RtfDocumentBuilder.Core.FontStyles.Bold));

            if (summaryText.Length > 0)
            {
                document.AddParagraph(summaryText);
                //document.Add(new RTFParagraph(summaryText, 0, 1));
            }
            #endregion

            #region Final assessment
            //Final Asse
            //document.Add(new RTFParagraph(ReportGroupCaptionSet[6], new RTFFont(true), 0, 1));
            document.AddParagraph(new Miracle.RtfDocumentBuilder.RTFParagraph(ReportGroupCaptionSet[6], Miracle.RtfDocumentBuilder.Core.FontStyles.Bold));

            if (finalassessmentIndex > 0 && finalassessmentIndex <= Final_assessmentSet.Length - 1)
            {
                //document.Add(new RTFParagraph(Final_assessmentSet[finalassessmentIndex] + ".", 0, 2));
                document.AddParagraph(Final_assessmentSet[finalassessmentIndex] + ".");
                document.AddParagraph(string.Empty);
            }
            #endregion

            #region Recommendation
            //Recommendation
            //document.Add(new RTFParagraph(ReportGroupCaptionSet[7], new RTFFont(true), 0, 1));
            document.AddParagraph(new Miracle.RtfDocumentBuilder.RTFParagraph(ReportGroupCaptionSet[7], Miracle.RtfDocumentBuilder.Core.FontStyles.Bold));

            //text += "\r\n" + ReportGroupCaptionSet[7] + "\r\n";
            if (finalassessmentIndex > 0)
            {
                if (recommendationIndex == RecommendationSet.Length - 1 && recommendationText.Trim().Length > 0)
                    //document.Add(new RTFParagraph(recommendationText + ".", 0, 2));
                    document.AddParagraph(recommendationText + ".");
                else
                    //document.Add(new RTFParagraph(RecommendationSet[recommendationIndex] + ".", 0, 2));
                    document.AddParagraph(recommendationIndexText + ".");
                document.AddParagraph(string.Empty);
            }
            #endregion

            #region Image
            if (isShowLeftImage || isShowRightImage)
            {
                document.AddParagraph(new Miracle.RtfDocumentBuilder.RTFParagraph("BREAST LEFT & RIGHT", Miracle.RtfDocumentBuilder.Core.FontStyles.Bold));

                Miracle.RtfDocumentBuilder.RTFParagraph paragraph = new Miracle.RtfDocumentBuilder.RTFParagraph(Miracle.RtfDocumentBuilder.Core.ParagraphAlignments.Center);
                if (isShowLeftImage)
                    paragraph.AddContent(Miracle.RtfDocumentBuilder.RTFImage.ParseToRtf(LeftStream));
                if (isShowRightImage)
                    paragraph.AddContent(Miracle.RtfDocumentBuilder.RTFImage.ParseToRtf(RightStrem));
                document.AddParagraph(paragraph);
            }
            #endregion

            //_str_rtf = document.GetRTFDocument();
            _str_rtf = document.Document;
            return _str_rtf;
        }

        /// <summary>
        /// Get generate text
        /// </summary>
        /// <param name="patientTypeIndex">Patient Type Index</param>
        /// <param name="breastCompsIndex">Breast Compasion Index</param>
        /// <param name="drComparsion">Comparsion DataRow</param>
        /// <param name="comparsionText">Comparsion Text</param>
        /// <param name="markList">Marker List</param>
        /// <param name="dsDemograhic">Demographic DataRow</param>
        /// <returns></returns>
        public static string GeneratePlanText
            (int patientTypeIndex
            , string patientTypeText
            , int breastCompsIndex
            , int finalassessmentIndex
            , int recommendationIndex
            , bool nvMG
            , bool nvUS
            , string recommendationText
            , string fimailyHistoryOfBreastCancerValue
            , string PersonalHistoryOfBreastCancerValue
            , string PersonalHistoryOfBreastCancerViewValue
            , int clinicalHistoryIndex
            , bool isMultipleMass
            , DataSet dsDominantCysts
            , string summaryText
            , DataRow[] drComparsion
            , string comparsionText
            , List<MarkStruct> markList
            , DataRow dsDemograhic)
        {
            string text = string.Empty;
            //Demograhic
            text += ReportGroupCaptionSet[0] + "\r\n";
            text += "\tHN " + dsDemograhic["HN"] + " patient name is " + dsDemograhic["PATIENT_NAME"] + ", " + dsDemograhic["GENDER"]
                + ", " + dsDemograhic["AGE"] + " years old.";
            //Personal History of Breast Cancer
            if (PersonalHistoryOfBreastCancerValue != "N")
            {
                text += " has a person history of breast cancer at ";
                text += PersonalHistoryOfBreastCancerViewValue == "L" ? "Left" : "Right";
                text += " breast";
                if (fimailyHistoryOfBreastCancerValue != "N")
                {
                    text += " and family history of breat cancer in ";
                    text += fimailyHistoryOfBreastCancerValue == "1" ? "frist degee" : "second degee";
                    text += "\r\n";
                }
                else
                    text += "\r\n";
            }
            else
            {
                if (fimailyHistoryOfBreastCancerValue != "N")
                {
                    text += " has a family history of breat cancer in ";
                    text += fimailyHistoryOfBreastCancerValue == "1" ? "frist degee" : "second degee";
                    text += "\r\n";
                }
                else
                    text += "\r\n";
            }
            //Clinical history
            text += "\r\n" + ReportGroupCaptionSet[1] + "\r\n";
            if (clinicalHistoryIndex > 0)
            {
                if (clinicalHistoryIndex == 1)
                    text += "\tScreening";
                else
                    text += "\tDiagnostic";

                if (patientTypeIndex != 0)
                {
                    if (patientTypeIndex == PatientTypeSet.Length - 1)
                    {
                        if (patientTypeText.Trim().Length > 0)
                            text += " : " + patientTypeText + "\r\n";
                    }
                    text += " : " + PatientTypeSet[patientTypeIndex] + "\r\n";
                }
            }
            else
            {
                if (patientTypeIndex != 0)
                {
                    if (patientTypeIndex == PatientTypeSet.Length - 1)
                    {
                        if (patientTypeText.Trim().Length > 0)
                            text += "\t" + patientTypeText + "\r\n";
                    }
                    text += "\t" + PatientTypeSet[patientTypeIndex] + "\r\n";
                }
            }
            //Finding

            //Comparison
            text += "\r\n" + ReportGroupCaptionSet[2] + "\r\n";
            if (drComparsion != null)
            {
                if (drComparsion.Length > 0)
                {
                    if(drComparsion.Length == 1)
                        text += "\tthis exam is compared with the ";
                    else
                        text += "\tthis exam is compared with ";
                    for (int i = 0; i < drComparsion.Length; i++)
                    {
                        text += drComparsion[i]["STUDY"] + " on " + Convert.ToDateTime(drComparsion[i]["EXAM_DT"]).ToShortDateString();
                        if (i + 1 == drComparsion.Length -1)
                            text += " and ";
                        else if (i + 1 == drComparsion.Length)
                            text += ".\r\n";
                        else
                            text += ", ";
                    }
                }
            }
            //Mammographic Finding 
            text += "\r\n" + ReportGroupCaptionSet[3] + "\r\n";
            if (breastCompsIndex != 0)
                text += "\tBreast Composition : " + BreastCompositionSet[breastCompsIndex] + "\r\n";

            if (nvMG)
            {
                //Negative for Mammogram
                text += "\tNo mass, Suspicious calcification or focal architectural distortion are deserved.\r\n";
            }
            else
            {
                //Detail
                if (markList != null)
                {
                    if (isMultipleMass)
                    {
                        //Multiple mass
                        if (dsDominantCysts != null)
                        {
                            if (dsDominantCysts.Tables.Count > 0)
                            {
                                if (dsDominantCysts.Tables[0].Rows.Count > 0)
                                {
                                    foreach (DataRow dr in dsDominantCysts.Tables[0].Rows)
                                    {
                                        if (dr["MASS_NO"].ToString().Trim().Length == 0)
                                            continue;
                                        text += "\tThe dominant cyst in the " + dr["BREAST_VIEW"].ToString().ToLower()
                                            + " breast clock location at " + dr["LOCATION"] + ", measuring " + dr["SIZE"].ToString().ToLower() + "\r\n";
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        //text += "\r\n\r\nNumber of mass(es) found is : " + markList.Count + "\r\n";
                        if (markList.Count > 0)
                        {
                            string _subTextLeft = "\tLeft :\r\n";
                            string _subTextRight = "\tRight :\r\n";
                            string _mass_subTextLeft = string.Empty;
                            string _calcification_subTextLeft = string.Empty;
                            string _mass_and_calcification_subTextLeft = string.Empty;
                            string _architectural_distortion_subTextLeft = string.Empty;
                            string _asymmetric_density_subTextLeft = string.Empty;
                            string _mass_subTextRight = string.Empty;
                            string _calcification_subTextRight = string.Empty;
                            string _mass_and_calcification_subTextRight = string.Empty;
                            string _architectural_distortion_subTextRight = string.Empty;
                            string _asymmetric_density_subTextRight = string.Empty;
                            for (int i = 0; i < markList.Count; i++)
                            {
                                if (markList[i].IsUsMassDetail == "Y")
                                    continue;
                                EnvisionBreastControl.Lib.CShapeControl control = markList[i].MarkObject as EnvisionBreastControl.Lib.CShapeControl;
                                if (control.Name.Contains("Left"))
                                {
                                    string _subText = string.Empty;
                                    //text += "\r\n\tMass : " + (i + 1) + ".";
                                    //text += " Finding type is ";
                                    int finding_type_index = EditValueConvertor.GetFindingTypeIndex(markList[i].MassDetail.FINDING_TYPE);
                                    switch (finding_type_index)
                                    {
                                        case 0: _subText = _mass_subTextLeft; break;
                                        case 1: _subText = _calcification_subTextLeft; break;
                                        case 2: _subText = _mass_and_calcification_subTextLeft; break;
                                        case 3: _subText = _architectural_distortion_subTextLeft; break;
                                        case 4: _subText = _asymmetric_density_subTextLeft; break;
                                    }
                                    _subText += "\t\t" + FindingTypeSet[finding_type_index] + ":" + markList[i].MassDetail.MASS_NO + " ";
                                    if (finding_type_index == 0 || finding_type_index == 2)
                                    {
                                        //shape and margin
                                        if (markList[i].MassDetail.MASS_SHAPE.Trim().Length > 0)
                                        {
                                            try
                                            {
                                                _subText += ShapeDictionary[markList[i].MassDetail.MASS_SHAPE] + " shape ";
                                                if (markList[i].MassDetail.MASS_MARGIN.Trim().Length > 0)
                                                    _subText += " and " + MarginDictionary[markList[i].MassDetail.MASS_MARGIN] + " margin ";
                                            }
                                            catch { _subText += " and Circumscribe margin "; }
                                        }
                                        else
                                        {
                                            try
                                            {
                                                if (markList[i].MassDetail.MASS_MARGIN.Trim().Length > 0)
                                                    _subText += MarginDictionary[markList[i].MassDetail.MASS_MARGIN] + " margin ";
                                            }
                                            catch { }
                                        }
                                        //density
                                        if (markList[i].MassDetail.MASS_DENSITY_TYPE.Trim().Length > 0)
                                        {
                                            _subText += " Density type is " + DensityDictionary[markList[i].MassDetail.MASS_DENSITY_TYPE];
                                            if (markList[i].MassDetail.MASS_DENSITY.Trim().Length > 0)
                                                _subText += " with " + DensityWithCalcDictionary[markList[i].MassDetail.MASS_HAS_CALCIFICATION] + " calcification. ";
                                        }
                                    }
                                    //location
                                    _subText += " at " + markList[i].MassDetail.MASS_LOCATION_CLOCK + "'s clock location\r\n";
                                    //_subText += markList[i].MassDetail.BREAST_TYPE == "L" ? "Left" : "Right";
                                    //_subText += " Breast.";

                                    //Calcification
                                    if (finding_type_index == 1 || finding_type_index == 2)
                                    {
                                        _subText += "\t\t\tNumber of calcification is " + markList[i].MassDetail.NO_OF_CALCIFICATION_OBJECTS + " with ";
                                        _subText += markList[i].MassDetail.TYPE_OF_CALCIFICATION_OBJECT == "M" ? "multiple" : "single";
                                        _subText += " calcification.";
                                        _subText += "\r\n\t\t\tThe calcification(s) type is \r\n";
                                        _subText += GetCalcificationString(markList[i].MassDetail);
                                    }
                                    if (finding_type_index == 3)
                                    {
                                        _subText += "\t\t\tNumber of Architectural Distortion is " + markList[i].MassDetail.NO_OF_ARCHITECTURAL_DISTORTION + " with ";
                                        _subText += markList[i].MassDetail.ARCHITECTURAL_DISTORTION_OBJECT_TYPE == "M" ? "multiple" : "single";
                                        _subText += " and Architectural Distortion type is ";
                                        if (markList[i].MassDetail.ARCHITECTURAL_DISTORTION_TYPE == "S")
                                            _subText += "Post Operative Change";
                                        else
                                            _subText += "Suspicious Abnormality";
                                    }
                                    if (markList[i].MassDetail.ASSOCIATE_FINDING_TYPE.Trim().Length > 0)
                                    {
                                        _subText += "\r\n\t\t\tAssociate Finding is ";
                                        _subText += AssociateDictionary[markList[i].MassDetail.ASSOCIATE_FINDING_TYPE] + ".";
                                    }

                                    switch (finding_type_index)
                                    {
                                        case 0: _mass_subTextLeft = _subText; break;
                                        case 1: _calcification_subTextLeft = _subText; break;
                                        case 2: _mass_and_calcification_subTextLeft = _subText; break;
                                        case 3: _architectural_distortion_subTextLeft = _subText; break;
                                        case 4: _asymmetric_density_subTextLeft = _subText; break;
                                    }
                                }
                                else
                                {
                                    string _subText = string.Empty;
                                    //text += "\r\n\tMass : " + (i + 1) + ".";
                                    //text += " Finding type is ";
                                    int finding_type_index = EditValueConvertor.GetFindingTypeIndex(markList[i].MassDetail.FINDING_TYPE);
                                    switch (finding_type_index)
                                    {
                                        case 0: _subText = _mass_subTextRight; break;
                                        case 1: _subText = _calcification_subTextRight; break;
                                        case 2: _subText = _mass_and_calcification_subTextRight; break;
                                        case 3: _subText = _architectural_distortion_subTextRight; break;
                                        case 4: _subText = _asymmetric_density_subTextRight; break;
                                    }
                                    _subText += "\t\t" + FindingTypeSet[finding_type_index] + ":" + markList[i].MassDetail.MASS_NO + " ";
                                    if (finding_type_index == 0)
                                    {
                                        //shape and margin
                                        if (markList[i].MassDetail.MASS_SHAPE.Trim().Length > 0)
                                        {
                                            try
                                            {
                                                _subText += ShapeDictionary[markList[i].MassDetail.MASS_SHAPE] + " shape ";
                                                if (markList[i].MassDetail.MASS_MARGIN.Trim().Length > 0)
                                                    _subText += " and " + MarginDictionary[markList[i].MassDetail.MASS_MARGIN] + " margin ";
                                            }
                                            catch { _subText += " and Circumscribe margin "; }
                                        }
                                        else
                                        {
                                            try
                                            {
                                                if (markList[i].MassDetail.MASS_MARGIN.Trim().Length > 0)
                                                    _subText += MarginDictionary[markList[i].MassDetail.MASS_MARGIN] + " margin ";
                                            }
                                            catch { }
                                        }
                                        //density
                                        if (markList[i].MassDetail.MASS_DENSITY_TYPE.Trim().Length > 0)
                                        {
                                            _subText += " Density type is " + DensityDictionary[markList[i].MassDetail.MASS_DENSITY_TYPE];
                                            if (markList[i].MassDetail.MASS_DENSITY.Trim().Length > 0)
                                                _subText += " with " + DensityWithCalcDictionary[markList[i].MassDetail.MASS_HAS_CALCIFICATION] + " calcification. ";
                                        }
                                    }
                                    //location
                                    _subText += " at " + markList[i].MassDetail.MASS_LOCATION_CLOCK + "'s clock location\r\n";
                                    //_subText += markList[i].MassDetail.BREAST_TYPE == "L" ? "Left" : "Right";
                                    //_subText += " Breast.";

                                    //Calcification
                                    if (finding_type_index == 1)
                                    {
                                        _subText += "\t\t\tNumber of calcification is " + markList[i].MassDetail.NO_OF_CALCIFICATION_OBJECTS + " with ";
                                        _subText += markList[i].MassDetail.TYPE_OF_CALCIFICATION_OBJECT == "M" ? "multiple" : "single";
                                        _subText += " calcification.";
                                        _subText += "\r\n\t\t\tThe calcification(s) type is \r\n";
                                        _subText += GetCalcificationString(markList[i].MassDetail);
                                    }
                                    if (finding_type_index == 2)
                                    {
                                        _subText += "\t\t\tNumber of Architectural Distortion is " + markList[i].MassDetail.NO_OF_ARCHITECTURAL_DISTORTION + " with ";
                                        _subText += markList[i].MassDetail.ARCHITECTURAL_DISTORTION_OBJECT_TYPE == "M" ? "multiple" : "single";
                                        _subText += " and Architectural Distortion type is ";
                                        if (markList[i].MassDetail.ARCHITECTURAL_DISTORTION_TYPE == "S")
                                            _subText += "Post Operative Change";
                                        else
                                            _subText += "Suspicious Abnormality";
                                    }
                                    if (markList[i].MassDetail.ASSOCIATE_FINDING_TYPE.Trim().Length > 0)
                                    {
                                        _subText += "\r\n\t\t\tAssociate Finding is ";
                                        _subText += AssociateDictionary[markList[i].MassDetail.ASSOCIATE_FINDING_TYPE] + ".";
                                    }

                                    switch (finding_type_index)
                                    {
                                        case 0: _mass_subTextRight = _subText; break;
                                        case 1: _calcification_subTextRight = _subText; break;
                                        case 2: _mass_and_calcification_subTextRight = _subText; break;
                                        case 3: _architectural_distortion_subTextRight = _subText; break;
                                        case 4: _asymmetric_density_subTextRight = _subText; break;
                                    }
                                }
                            }

                            text += _subTextLeft + _mass_subTextLeft + _calcification_subTextLeft
                                + _mass_and_calcification_subTextLeft + _architectural_distortion_subTextLeft
                                + _asymmetric_density_subTextLeft + "\r\n";

                            text += _subTextRight + _mass_subTextRight + _calcification_subTextRight
                                + _mass_and_calcification_subTextRight + _architectural_distortion_subTextRight
                                + _asymmetric_density_subTextRight;
                        }
                    }
                }
            }
            //Ultrasound Finding 
            text += "\r\n" + ReportGroupCaptionSet[4] + "\r\n";

            if (nvUS)
            {
                //Negative for Ultrasound
                text += "\tNo mass or cyst is detected in both breast.\r\n"; 
            }
            else
            {
                if (markList != null)
                {
                    if (markList.Count > 0)
                    {
                        string _subTextLeft = "\tLeft :\r\n";
                        string _subTextRight = "\tRight :\r\n";
                        string _simpleCyst_subTextLeft = string.Empty;
                        string _complicatedCyst_subTextLeft = string.Empty;
                        string _complex_subTextLeft = string.Empty;
                        string _solid_mass_subTextLeft = string.Empty;
                        string _simpleCyst_subTextRight = string.Empty;
                        string _complicatedCyst_subTextRight = string.Empty;
                        string _complex_subTextRight = string.Empty;
                        string _solid_mass_subTextRight = string.Empty;
                        for (int i = 0; i < markList.Count; i++)
                        {
                            if (markList[i].IsUsMassDetail == "N")
                                continue;
                            EnvisionBreastControl.Lib.CShapeControl control = markList[i].MarkObject as EnvisionBreastControl.Lib.CShapeControl;
                            if (control.Name.Contains("Left"))
                            {
                                string _subText = string.Empty;
                                //text += "\r\n\tMass : " + (i + 1) + ".";
                                //text += " Finding type is ";
                                //int finding_type_index = EditValueConvertor.GetFindingTypeIndex(markList[i].MassDetail.FINDING_TYPE);
                                switch (markList[i].MassUSDetail.MASS_CYST_TYPE)
                                {
                                    case "A": _subText = _simpleCyst_subTextLeft; break;
                                    case "B": _subText = _complicatedCyst_subTextLeft; break;
                                    case "C": _subText = _complex_subTextLeft; break;
                                    case "D": _subText = _solid_mass_subTextLeft; break;
                                }
                                if(markList[i].MassUSDetail.MASS_CYST_TYPE.Length > 0)
                                    _subText += "\t\t" + MassCystsDictionary[markList[i].MassUSDetail.MASS_CYST_TYPE] + ":" + markList[i].MassDetail.MASS_NO + " ";
                                if (markList[i].MassUSDetail.MASS_CYST_TYPE != "D")
                                {
                                    _subText += " found at " + markList[i].MassDetail.MASS_LOCATION_CLOCK + "'s clock location\r\n";
                                }
                                else
                                {
                                    _subText += GetSoildMassDetail(markList[i]);
                                    _subText += " found at " + markList[i].MassDetail.MASS_LOCATION_CLOCK + "'s clock location\r\n";
                                }

                                switch (markList[i].MassUSDetail.MASS_CYST_TYPE)
                                {
                                    case "A": _simpleCyst_subTextLeft = _subText; break;
                                    case "B": _complicatedCyst_subTextLeft = _subText; break;
                                    case "C": _complex_subTextLeft = _subText; break;
                                    case "D": _solid_mass_subTextLeft = _subText; break;
                                }
                            }
                            else
                            {
                                string _subText = string.Empty;
                                //text += "\r\n\tMass : " + (i + 1) + ".";
                                //text += " Finding type is ";
                                //int finding_type_index = EditValueConvertor.GetFindingTypeIndex(markList[i].MassDetail.FINDING_TYPE);
                                switch (markList[i].MassUSDetail.MASS_CYST_TYPE)
                                {
                                    case "A": _subText = _simpleCyst_subTextRight; break;
                                    case "B": _subText = _complicatedCyst_subTextRight; break;
                                    case "C": _subText = _complex_subTextRight; break;
                                    case "D": _subText = _solid_mass_subTextRight; break;
                                }
                                if (markList[i].MassUSDetail.MASS_CYST_TYPE.Length > 0)
                                    _subText += "\t\t" + MassCystsDictionary[markList[i].MassUSDetail.MASS_CYST_TYPE] + ":" + markList[i].MassDetail.MASS_NO + " ";
                                if (markList[i].MassUSDetail.MASS_CYST_TYPE != "D")
                                {
                                    _subText += " found at " + markList[i].MassDetail.MASS_LOCATION_CLOCK + "'s clock location\r\n";
                                }
                                else
                                {
                                    _subText += GetSoildMassDetail(markList[i]);
                                    _subText += " found at " + markList[i].MassDetail.MASS_LOCATION_CLOCK + "'s clock location\r\n";
                                }

                                switch (markList[i].MassUSDetail.MASS_CYST_TYPE)
                                {
                                    case "A": _simpleCyst_subTextRight = _subText; break;
                                    case "B": _complicatedCyst_subTextRight = _subText; break;
                                    case "C": _complex_subTextRight = _subText; break;
                                    case "D": _solid_mass_subTextRight = _subText; break;
                                }
                            }
                        }

                        text += _subTextLeft + _simpleCyst_subTextLeft + _complicatedCyst_subTextLeft
                            + _complex_subTextLeft + _solid_mass_subTextLeft + "\r\n";

                        text += _subTextRight + _simpleCyst_subTextRight + _complicatedCyst_subTextRight
                            + _complex_subTextRight + _solid_mass_subTextRight;
                    }
                }
            }

            //Impression 
            text += "\r\n" + ReportGroupCaptionSet[5] + "\r\n";
            if (summaryText.Length > 0)
            {
                text += "\t" + summaryText + "\r\n";
            }

            //Final Asse
            text += "\r\n" + ReportGroupCaptionSet[6] + "\r\n";
            if (finalassessmentIndex > 0 && finalassessmentIndex <= Final_assessmentSet.Length - 1)
            {
                text += "\t" + Final_assessmentSet[finalassessmentIndex] + "\r\n";
            }

            //Recommendation
            text += "\r\n" + ReportGroupCaptionSet[7] + "\r\n";
            if (recommendationIndex > 0 && recommendationIndex <= RecommendationSet.Length - 1)
            {
                if (recommendationIndex == RecommendationSet.Length - 1 && recommendationText.Trim().Length > 0)
                    text += "\t" + recommendationText + "\r\n";
                else
                    text += "\t" + RecommendationSet[recommendationIndex] + "\r\n";
            }

            return text;
        }

        private static string GetSoildMassDetail(MarkStruct markStruct)
        {
            string _subText = string.Empty;
            //margin of US
            if (markStruct.MassUSDetail.MASS_MARGIN.Length > 0)
            {
                _subText += " " + MarginOfUSDictionary[markStruct.MassUSDetail.MASS_MARGIN] + " Margin";
            }
            //orientation
            if (markStruct.MassUSDetail.MASS_ORIENTATION.Length > 0)
            {
                _subText += ", " + OrientationOfMassDictionary[markStruct.MassUSDetail.MASS_ORIENTATION] + " Orientation";
            }
            //lesion boundary
            if (markStruct.MassUSDetail.MASS_LESION_BOUNDARY.Length > 0)
            {
                _subText += ", " + LesionBoundaryDictionary[markStruct.MassUSDetail.MASS_LESION_BOUNDARY] + " Lesion Boundary";
            }
            //echo pattarn
            if (markStruct.MassUSDetail.MASS_ECHO_PATTERN.Length > 0)
            {
                _subText += ", " + EchoPatternDictionary[markStruct.MassUSDetail.MASS_ECHO_PATTERN] + " Echo Pattern";
            }
            //Posterior acoustic features
            if (markStruct.MassUSDetail.MASS_POSTERIOR_ACOUSTIC_FEATURES.Length > 0)
            {
                _subText += ", " + PosteriorAcousticFeaturesDictionary[markStruct.MassUSDetail.MASS_POSTERIOR_ACOUSTIC_FEATURES] + " Posterior Acoustic Features";
            }
            _subText = _subText.Trim().TrimStart(',');

            string[] _subTextPart = _subText.Split(',');
            _subText = string.Empty;
            for(int i = 0; i < _subTextPart.Length; i ++)
            {
                if (i == 0)
                    _subText += _subTextPart[i].Trim();
                else if (i == _subTextPart.Length - 1)
                    _subText += " and " + _subTextPart[i].Trim();
                else
                    _subText += ", " + _subTextPart[i].Trim();
            }
            return " with " + _subText;
        }
        private static string GetCalcificationString(Envision.Common.MG_BREASTUSMASSDETAILS mDtl)
        {
            string calStr = string.Empty;

            //string _group_typically_benign = "\t\t\t\t\t Typically Benign : ";
            //Typical
            string typical = string.Empty; ;
            if (mDtl.TYPICALLY_BENIGN_COARSE_OR_POPCORN_LIKE == "Y")
                typical += ", Coarse or \"popcorn-like\"";
            if (mDtl.TYPICALLY_BENIGN_DYSTROPHIC == "Y")
                typical += ", Dystrophic";
            if (mDtl.TYPICALLY_BENIGN_EGGSHELL_OR_RIM == "Y")
                typical += ", Eggshell or Rim";
            if (mDtl.TYPICALLY_BENIGN_LARGE_ROD_LIKE == "Y")
                typical += ", Large rod-like";
            if (mDtl.TYPICALLY_BENIGN_LUCENT_CENTERED == "Y")
                typical += ", Lucent-centered";
            if (mDtl.TYPICALLY_BENIGN_MILK_OF_CALCIUM == "Y")
                typical += ", Milk of Calcium";
            if (mDtl.TYPICALLY_BENIGN_ROUND == "Y")
                typical += ", Round";
            if (mDtl.TYPICALLY_BENIGN_SKIN == "Y")
                typical += ", Skin";
            if (mDtl.TYPICALLY_BENIGN_SUTURE == "Y")
                typical += ", Suture";
            if (mDtl.TYPICALLY_BENIGN_VASCULAR == "Y")
                typical += ", Vascular";
            if (typical.Length > 0)
            {
                //calStr += "\t\t\t\t\t  : ";
                calStr += typical.Trim().TrimStart(',');
                calStr += " of Typically Benign Calcification";
            }
            string Intermediate = string.Empty;
            if (mDtl.INTERMEDIATE_CONCERN_SUSPICIOUS_AMORPHOUS_OR_INDISTINCT == "Y")
                Intermediate += ", Amorphous or Indistinct";
            if (mDtl.INTERMEDIATE_CONCERN_SUSPICIOUS_COARSE_HETEROGENOUS == "Y")
                Intermediate += ", Coarse Heterogeneous";
            if (Intermediate.Length > 0)
            {
                //calStr += "\t\t\t\t\t Intermediate Concern, Suspicious Calcifications : ";
                calStr += Intermediate.Trim().TrimStart(',');
                calStr += " of Intermediate Concern, Suspicious Calcifications";
            }
            string Higher = string.Empty;
            if (mDtl.HIGHER_PROBABILITY_OF_MALIGNANCY_FINE_LINEAR == "Y")
                Higher += ", Fine Linear or Fine-linear Branching";
            if (mDtl.HIGHER_PROBABILITY_OF_MALIGNANCY_FINE_PLEOMORPHIC == "Y")
                Higher += ", Fine Pleomorphic";
            if (Higher.Length > 0)
            {
                //calStr += "\t\t\t\t\t Higher Probability of Malignancy : ";
                calStr += Higher.Trim().TrimStart(',');
                calStr += " of Higher Probability of Malignancy Calcification";
            }
            string Distribution = string.Empty;
            if (mDtl.DISTRIBUTION_MODIFIER_DIFFUSE_SCATTERED == "Y")
                Distribution += ", Diffuse/Scattered";
            if (mDtl.DISTRIBUTION_MODIFIER_GROUPED_OR_CLUSTERED == "Y")
                Distribution += ", Grouped or Clustered";
            if (mDtl.DISTRIBUTION_MODIFIER_LINEAR == "Y")
                Distribution += ", Liner";
            if (mDtl.DISTRIBUTION_MODIFIER_REGIONAL == "Y")
                Distribution += ", Regional";
            if (mDtl.DISTRIBUTION_MODIFIER_SEGMENTAL == "Y")
                Distribution += ", Segmental";
            if (Distribution.Length > 0)
            {
                //calStr += "\t\t\t\t\t Distribution Modifier : ";
                calStr += Distribution.Trim().TrimStart(',') + " of Distribution Modifier";
            }
            return calStr;
        }

        private static string GetCalcificationString(Envision.Common.MG_BREASTMASSDETAILS mDtl)
        {
            string calStr = string.Empty;

            //string _group_typically_benign = "\t\t\t\t\t Typically Benign : ";
            //Typical
            string typical = string.Empty; ;
            if (mDtl.TYPICALLY_BENIGN_COARSE_OR_POPCORN_LIKE == "Y")
                typical += ", Coarse or \"popcorn-like\"";
            if (mDtl.TYPICALLY_BENIGN_DYSTROPHIC == "Y")
                typical += ", Dystrophic";
            if (mDtl.TYPICALLY_BENIGN_EGGSHELL_OR_RIM == "Y")
                typical += ", Eggshell or Rim";
            if (mDtl.TYPICALLY_BENIGN_LARGE_ROD_LIKE == "Y")
                typical += ", Large rod-like";
            if (mDtl.TYPICALLY_BENIGN_LUCENT_CENTERED == "Y")
                typical += ", Lucent-centered";
            if (mDtl.TYPICALLY_BENIGN_MILK_OF_CALCIUM == "Y")
                typical += ", Milk of Calcium";
            if (mDtl.TYPICALLY_BENIGN_ROUND == "Y")
                typical += ", Round";
            if (mDtl.TYPICALLY_BENIGN_SKIN == "Y")
                typical += ", Skin";
            if (mDtl.TYPICALLY_BENIGN_SUTURE == "Y")
                typical += ", Suture";
            if (mDtl.TYPICALLY_BENIGN_VASCULAR == "Y")
                typical += ", Vascular";
            if (typical.Length > 0)
            {
                //calStr += "\t\t\t\t\t  : ";
                calStr += typical.Trim().TrimStart(',');
                calStr += " of Typically Benign Calcification";
            }
            string Intermediate = string.Empty;
            if (mDtl.INTERMEDIATE_CONCERN_SUSPICIOUS_AMORPHOUS_OR_INDISTINCT == "Y")
                Intermediate += ", Amorphous or Indistinct";
            if (mDtl.INTERMEDIATE_CONCERN_SUSPICIOUS_COARSE_HETEROGENOUS == "Y")
                Intermediate += ", Coarse Heterogeneous";
            if (Intermediate.Length > 0)
            {
                //calStr += "\t\t\t\t\t Intermediate Concern, Suspicious Calcifications : ";
                calStr += Intermediate.Trim().TrimStart(',');
                calStr += " of Intermediate Concern, Suspicious Calcifications";
            }
            string Higher = string.Empty;
            if (mDtl.HIGHER_PROBABILITY_OF_MALIGNANCY_FINE_LINEAR == "Y")
                Higher += ", Fine Linear or Fine-linear Branching";
            if (mDtl.HIGHER_PROBABILITY_OF_MALIGNANCY_FINE_PLEOMORPHIC == "Y")
                Higher += ", Fine Pleomorphic";
            if (Higher.Length > 0)
            {
                //calStr += "\t\t\t\t\t Higher Probability of Malignancy : ";
                calStr += Higher.Trim().TrimStart(',');
                calStr += " of Higher Probability of Malignancy Calcification";
            }
            string Distribution = string.Empty;
            if (mDtl.DISTRIBUTION_MODIFIER_DIFFUSE_SCATTERED == "Y")
                Distribution += ", Diffuse/Scattered";
            if (mDtl.DISTRIBUTION_MODIFIER_GROUPED_OR_CLUSTERED == "Y")
                Distribution += ", Grouped or Clustered";
            if (mDtl.DISTRIBUTION_MODIFIER_LINEAR == "Y")
                Distribution += ", Liner";
            if (mDtl.DISTRIBUTION_MODIFIER_REGIONAL == "Y")
                Distribution += ", Regional";
            if (mDtl.DISTRIBUTION_MODIFIER_SEGMENTAL == "Y")
                Distribution += ", Segmental";
            if (Distribution.Length > 0)
            {
                //calStr += "\t\t\t\t\t Distribution Modifier : ";
                calStr += Distribution.Trim().TrimStart(',') + " of Distribution Modifier";
            }
            return calStr;
        }
    }
}
