using DockVision.Core;
using DockVision.Inspect;
using SaigeVision.Net.V2;
using SaigeVision.Net.V2.Classification;
using SaigeVision.Net.V2.Detection;
using SaigeVision.Net.V2.IAD;
using SaigeVision.Net.V2.IEN;
using SaigeVision.Net.V2.OCR;
using SaigeVision.Net.V2.Segmentation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DockVision.Property
{
    public partial class AIModuleProp : UserControl
    {
        SaigeAI _saigeAI;
        string _modelPath = string.Empty;
        AIEngineType _engineType;

        public AIModuleProp()
        {
            InitializeComponent();

            lv_Result.HideSelection = false;


            cbAIModelType.DataSource = Enum.GetValues(typeof(AIEngineType)).Cast<AIEngineType>().ToList();
            cbAIModelType.SelectedIndex = 0;

            lv_Result.View = View.Details;
            lv_Result.FullRowSelect = true;
            lv_Result.GridLines = true;

            lv_Result.Columns.Clear();
            lv_Result.Columns.Add("Class", 120);
            lv_Result.Columns.Add("Count", 60);
        }

        private void btnSelAIModel_Click(object sender, EventArgs e)
        {
            string filter = "AI Files|*.*;";

            switch (_engineType)
            {
                case AIEngineType.AnomalyDetection:
                    filter = "Anomaly Detection Files|*.saigeiad;";
                    break;
                case AIEngineType.Segmentation:
                    filter = "Segmentation Files|*.saigeseg;";
                    break;
                case AIEngineType.Detection:
                    filter = "Detection Files|*.saigedet;";
                    break;
            }

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "AI 모델 파일 선택";
                openFileDialog.Filter = filter;
                openFileDialog.Multiselect = false;
                openFileDialog.InitialDirectory = @"C:\Saige\SaigeVision\engine\Examples\data\sfaw2023\models";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _modelPath = openFileDialog.FileName;
                    txtAIModelPath.Text = _modelPath;
                }
            }
        }

        private void btnLoadModel_Click(object sender, EventArgs e)
        {
            // SaigeAI가 null이면 초기화
            if (_saigeAI == null)
            {
                _saigeAI = Global.Inst.InspStage.AIModule;
            }

            if (string.IsNullOrEmpty(_modelPath))
            {
                MessageBox.Show("모델 파일을 선택해주세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // 모델 로딩
                _saigeAI.LoadEngine(_modelPath, _engineType); // 예외가 발생할 수 있음

                // 모델 정보 가져오기
                var modelInfo = _saigeAI.GetModelInfo();

                if (modelInfo == null)
                {
                    MessageBox.Show("모델 정보가 null입니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 모델 정보 출력
                UpdateModelInfoUI();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                if (ex.InnerException != null)
                    msg += "\nInner: " + ex.InnerException.Message;

                MessageBox.Show(msg, "모델 로딩 실패");
            }
        }

        private void btnInspAI_Click(object sender, EventArgs e)
        {
            Bitmap bmp = Global.Inst.InspStage.GetCurrentImage();
            if (bmp == null) return;

            _saigeAI.InspAIModule(bmp);   // 1. 검사
            Global.Inst.InspStage.UpdateDisplay(_saigeAI.GetResultImage()); // 2. 이미지
            UpdateResultUI();             // 3. 예제 UI 출력
            UpdateClassInfoResultUI(); //4. 검사 결과 기반으로 ClassInfos IsNG 업데이트
        }

        private void cbAIModelType_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            AIEngineType engineType = (AIEngineType)cbAIModelType.SelectedItem;

            if (engineType != _engineType)
            {
                if (_saigeAI != null)
                {
                    _saigeAI.Dispose();
                    _saigeAI = null;
                }

                // 모델 경로 초기화
                _modelPath = string.Empty;
                txtAIModelPath.Clear();

                // 모델 정보 UI 초기화
                lbx_ModelInformation.Items.Clear();
                lv_ClassInfos.Items.Clear();
                Txt_ModuleInfo.Clear();

                // 결과 UI 초기화
                lv_Result.Items.Clear();
                lbx_ResultDetail.Items.Clear();
            }
            _engineType = engineType;
        }
        private void SetModelInfo(ModelInfo model, string module)
        {
            if (model.InputDataProcessingMode != null)
            {
                lbx_ModelInformation.Items.Add($"{model.InputDataProcessingMode} (Rows X Cols) : {model.CropNumOfRows}x{model.CropNumOfCols}");
            }
            lbx_ModelInformation.Items.Add($"Target Text Shape : {model.TargetTextShape}");

            lv_ClassInfos.Items.Clear();
            for (int i = 0; i < model.ClassInfos.Length; i++)
            {
                string[] row = { model.ClassInfos[i].Name, "", model.ClassIsNG[i].ToString() };
                var listViewItem = new ListViewItem(row);
                listViewItem.SubItems[1].BackColor = model.ClassInfos[i].Color;
                listViewItem.UseItemStyleForSubItems = false;
                lv_ClassInfos.Items.Add(listViewItem);
            }

            Txt_ModuleInfo.Text = module;
        }
        private void Lv_Result_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (!e.IsSelected) return;

            lbx_ResultDetail.Items.Clear();

            var result = _saigeAI.GetResult();
            if (result == null) return;

            string className = e.Item.Text.Trim();

            switch (_engineType)
            {
                case AIEngineType.Detection:
                    ShowDetectionDetail(result as DetectionResult, className);
                    break;

                case AIEngineType.Segmentation:
                    ShowSegmentationDetail(result as SegmentationResult, className);
                    break;

                case AIEngineType.AnomalyDetection:
                    ShowIADDetail(result as IADResult, className);
                    break;
            }
        }

        private void ShowDetectionDetail(DetectionResult result, string className)
        {
            lbx_ResultDetail.Items.Clear();

            if (result == null) return;

            var objects = result.DetectedObjects
                .Where(o => string.Equals(o.ClassInfo.Name, className, StringComparison.OrdinalIgnoreCase));

            var classObjects = result.DetectedObjects
                .Where(o => o.ClassInfo.Name == className)
                .ToArray();


            lbx_ResultDetail.Items.Clear();
            lbx_ResultDetail.Items.Add($"Class : {className}");
            lbx_ResultDetail.Items.Add($"Object Count : {classObjects.Length}");
            lbx_ResultDetail.Items.Add($"ImreadTime : {result.InspectionTime.ImreadTime}");
            lbx_ResultDetail.Items.Add($"InferenceTime : {result.InspectionTime.InferenceTime}");
            lbx_ResultDetail.Items.Add($"PostProcessingTime : {result.InspectionTime.PostProcessingTime}");
            lbx_ResultDetail.Items.Add("--------------------------------------");




            foreach (var obj in objects)
            {
                lbx_ResultDetail.Items.Add($"Name : {obj.ClassInfo.Name}");
                lbx_ResultDetail.Items.Add($"Area : {obj.Area}");
                lbx_ResultDetail.Items.Add($"Score : {obj.Score}");
                lbx_ResultDetail.Items.Add("--------------------------------------");
            }
        }


        private void ShowSegmentationDetail(SegmentationResult result, string className)
        {
            lbx_ResultDetail.Items.Clear();

            if (result == null) return;

            var objects = result.SegmentedObjects
                .Where(o => string.Equals(o.ClassInfo.Name, className, StringComparison.OrdinalIgnoreCase));

            var classObjects = result.SegmentedObjects
                .Where(o => o.ClassInfo.Name == className)
                .ToArray();

            lbx_ResultDetail.Items.Clear();
            lbx_ResultDetail.Items.Add($"Class : {className}");
            lbx_ResultDetail.Items.Add($"Contour Count : {classObjects.Length}");
            lbx_ResultDetail.Items.Add($"ImreadTime : {result.InspectionTime.ImreadTime}");
            lbx_ResultDetail.Items.Add($"InferenceTime : {result.InspectionTime.InferenceTime}");
            lbx_ResultDetail.Items.Add($"PostProcessingTime : {result.InspectionTime.PostProcessingTime}");
            lbx_ResultDetail.Items.Add("--------------------------------------");

            foreach (var obj in objects)
            {
                lbx_ResultDetail.Items.Add($"Name : {obj.ClassInfo.Name}");
                lbx_ResultDetail.Items.Add($"Area : {obj.Area}");
                lbx_ResultDetail.Items.Add($"Score : {obj.Score}");
                lbx_ResultDetail.Items.Add(
                    $"Center : ({obj.BoundingRotBox.Center.X}, {obj.BoundingRotBox.Center.Y})");
                lbx_ResultDetail.Items.Add("--------------------------------------");
            }
        }

        private void ShowIADDetail(IADResult result, string className)
        {
            lbx_ResultDetail.Items.Clear();

            if (result == null) return;

            lbx_ResultDetail.Items.Add("RESULT : " + (result.IsNG ? "NG" : "OK"));
            lbx_ResultDetail.Items.Add($"Anomaly Score : {result.AnomalyScore.Score:N3}");
            lbx_ResultDetail.Items.Add("--------------------------------------");

            var objects = result.SegmentedObjects
                .Where(o => string.Equals(o.ClassInfo.Name, className, StringComparison.OrdinalIgnoreCase));

            var classObjects = result.SegmentedObjects
                .Where(o => o.ClassInfo.Name == className)
                .ToArray();

            lbx_ResultDetail.Items.Clear();
            lbx_ResultDetail.Items.Add($"Class : {className}");
            lbx_ResultDetail.Items.Add($"Contour Count : {classObjects.Length}");
            lbx_ResultDetail.Items.Add($"ImreadTime : {result.InspectionTime.ImreadTime}");
            lbx_ResultDetail.Items.Add($"InferenceTime : {result.InspectionTime.InferenceTime}");
            lbx_ResultDetail.Items.Add($"PostProcessingTime : {result.InspectionTime.PostProcessingTime}");
            lbx_ResultDetail.Items.Add("--------------------------------------");


            foreach (var obj in objects)
            {
                lbx_ResultDetail.Items.Add($"Name : {obj.ClassInfo.Name}");
                lbx_ResultDetail.Items.Add($"Area : {obj.Area}");
                lbx_ResultDetail.Items.Add($"Score : {obj.Score}");
                lbx_ResultDetail.Items.Add("--------------------------------------");
            }
        }


        private void UpdateModelInfoUI()
        {
            lbx_ModelInformation.Items.Clear();
            lv_ClassInfos.Items.Clear();
            Txt_ModuleInfo.Clear();

            var modelInfo = _saigeAI.GetModelInfo(); // SaigeAI 인스턴스로 모델 정보 가져오기
            if (modelInfo == null)
            {
                lbx_ModelInformation.Items.Add("모델 정보가 없습니다.");
                return;
            }

            lbx_ModelInformation.Items.Add($"EngineType : {_engineType}");
            lbx_ModelInformation.Items.Add($"ModelPath : {_modelPath}");
            lbx_ModelInformation.Items.Add($"ModelInfo Type: {modelInfo.GetType().Name}");

            // 모델 속성 동적 확인
            var properties = modelInfo.GetType().GetProperties();
            foreach (var property in properties)
            {
                lbx_ModelInformation.Items.Add($"Property: {property.Name} | Value: {property.GetValue(modelInfo)}");
            }

            lbx_ModelInformation.Refresh();
            SetModelInfo(modelInfo, _engineType.ToString());

        }


        private void UpdateResultUI()
        {
            lv_Result.Items.Clear();
            lbx_ResultDetail.Items.Clear();

            var result = _saigeAI.GetResult();
            if (result == null) return;

            switch (_engineType)
            {
                case AIEngineType.Detection:
                    UpdateDetectionResult(result as DetectionResult);
                    break;

                case AIEngineType.Segmentation:
                    UpdateSegmentationResult(result as SegmentationResult);
                    break;

                case AIEngineType.AnomalyDetection:
                    UpdateIADResult(result as IADResult);
                    break;
            }

        }

        private void UpdateDetectionResult(DetectionResult detResult)
        {
            if (detResult == null) return;

            var groups = detResult.DetectedObjects
                .GroupBy(o => o.ClassInfo);

            foreach (var g in groups)
            {
                var item = new ListViewItem(g.Key.Name);
                item.SubItems.Add(g.Count().ToString());

                item.UseItemStyleForSubItems = false;
                item.SubItems[0].BackColor = g.Key.Color;

                lv_Result.Items.Add(item);
            }
        }

        private void UpdateSegmentationResult(SegmentationResult segResult)
        {
            if (segResult == null) return;

            var groups = segResult.SegmentedObjects
                .GroupBy(o => o.ClassInfo);

            foreach (var g in groups)
            {
                var item = new ListViewItem(g.Key.Name);
                item.SubItems.Add(g.Count().ToString());

                item.UseItemStyleForSubItems = false;
                item.SubItems[0].BackColor = g.Key.Color;

                lv_Result.Items.Add(item);
            }
        }

        private void UpdateIADResult(IADResult iadResult)
        {
            if (iadResult == null) return;

            var groups = iadResult.SegmentedObjects
                .GroupBy(o => o.ClassInfo);

            foreach (var g in groups)
            {
                var item = new ListViewItem(g.Key.Name);
                item.SubItems.Add(g.Count().ToString());

                item.UseItemStyleForSubItems = false;
                item.SubItems[0].BackColor = g.Key.Color;

                lv_Result.Items.Add(item);
            }
        }

        private void UpdateClassInfoResultUI()
        {
            if (_saigeAI == null) return;

            var result = _saigeAI.GetResult();
            if (result == null) return;

            switch (_engineType)
            {
                case AIEngineType.AnomalyDetection:
                    UpdateIADClassInfo(result as IADResult);
                    break;

                case AIEngineType.Detection:
                    UpdateDetectionClassInfo(result as DetectionResult);
                    break;

                case AIEngineType.Segmentation:
                    UpdateSegmentationClassInfo(result as SegmentationResult);
                    break;
            }
        }

        private void UpdateIADClassInfo(IADResult iadResult)
        {
            if (iadResult == null || lv_ClassInfos.Items.Count == 0) return;

            for (int i = 0; i < lv_ClassInfos.Items.Count; i++)
            {
                var item = lv_ClassInfos.Items[i];
                string className = item.Text;

                bool hasNG = iadResult.SegmentedObjects.Any(o =>
                    string.Equals(o.ClassInfo.Name, className, StringComparison.OrdinalIgnoreCase));

                item.SubItems[2].Text = hasNG ? "True" : "False";
            }
        }

        private void UpdateDetectionClassInfo(DetectionResult detResult)
        {
            if (detResult == null || lv_ClassInfos.Items.Count == 0) return;

            for (int i = 0; i < lv_ClassInfos.Items.Count; i++)
            {
                var item = lv_ClassInfos.Items[i];
                string className = item.Text;

                bool hasNG = detResult.DetectedObjects.Any(o =>
                    string.Equals(o.ClassInfo.Name, className, StringComparison.OrdinalIgnoreCase));

                item.SubItems[2].Text = hasNG ? "True" : "False";
            }
        }

        private void UpdateSegmentationClassInfo(SegmentationResult segResult)
        {
            if (segResult == null || lv_ClassInfos.Items.Count == 0) return;

            for (int i = 0; i < lv_ClassInfos.Items.Count; i++)
            {
                var item = lv_ClassInfos.Items[i];
                string className = item.Text;

                bool hasNG = segResult.SegmentedObjects.Any(o =>
                    string.Equals(o.ClassInfo.Name, className, StringComparison.OrdinalIgnoreCase));

                item.SubItems[2].Text = hasNG ? "True" : "False";
            }
        }
    }
}


