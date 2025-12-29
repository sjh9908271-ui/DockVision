namespace DockVision.Property
{
    partial class AIModuleProp
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbAIModelType = new System.Windows.Forms.ComboBox();
            this.btnInspAI = new System.Windows.Forms.Button();
            this.btnLoadModel = new System.Windows.Forms.Button();
            this.btnSelAIModel = new System.Windows.Forms.Button();
            this.txtAIModelPath = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Txt_ModuleInfo = new System.Windows.Forms.TextBox();
            this.Lbl_ModuleInfo = new System.Windows.Forms.Label();
            this.lbx_ModelInformation = new System.Windows.Forms.ListBox();
            this.lv_ClassInfos = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label24 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lbx_ResultDetail = new System.Windows.Forms.ListBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.lv_Result = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbAIModelType
            // 
            this.cbAIModelType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAIModelType.FormattingEnabled = true;
            this.cbAIModelType.Location = new System.Drawing.Point(156, 90);
            this.cbAIModelType.Name = "cbAIModelType";
            this.cbAIModelType.Size = new System.Drawing.Size(162, 20);
            this.cbAIModelType.TabIndex = 5;
            this.cbAIModelType.SelectedIndexChanged += new System.EventHandler(this.cbAIModelType_SelectedIndexChanged_1);
            // 
            // btnInspAI
            // 
            this.btnInspAI.Location = new System.Drawing.Point(205, 185);
            this.btnInspAI.Name = "btnInspAI";
            this.btnInspAI.Size = new System.Drawing.Size(113, 26);
            this.btnInspAI.TabIndex = 9;
            this.btnInspAI.Text = "AI 검사";
            this.btnInspAI.UseVisualStyleBackColor = true;
            this.btnInspAI.Click += new System.EventHandler(this.btnInspAI_Click);
            // 
            // btnLoadModel
            // 
            this.btnLoadModel.Location = new System.Drawing.Point(205, 150);
            this.btnLoadModel.Name = "btnLoadModel";
            this.btnLoadModel.Size = new System.Drawing.Size(113, 29);
            this.btnLoadModel.TabIndex = 8;
            this.btnLoadModel.Text = "모델 로딩";
            this.btnLoadModel.UseVisualStyleBackColor = true;
            this.btnLoadModel.Click += new System.EventHandler(this.btnLoadModel_Click);
            // 
            // btnSelAIModel
            // 
            this.btnSelAIModel.Location = new System.Drawing.Point(205, 116);
            this.btnSelAIModel.Name = "btnSelAIModel";
            this.btnSelAIModel.Size = new System.Drawing.Size(116, 28);
            this.btnSelAIModel.TabIndex = 7;
            this.btnSelAIModel.Text = "AI모델 선택";
            this.btnSelAIModel.UseVisualStyleBackColor = true;
            this.btnSelAIModel.Click += new System.EventHandler(this.btnSelAIModel_Click);
            // 
            // txtAIModelPath
            // 
            this.txtAIModelPath.Location = new System.Drawing.Point(24, 63);
            this.txtAIModelPath.Name = "txtAIModelPath";
            this.txtAIModelPath.ReadOnly = true;
            this.txtAIModelPath.Size = new System.Drawing.Size(297, 21);
            this.txtAIModelPath.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cbAIModelType);
            this.panel1.Controls.Add(this.btnInspAI);
            this.panel1.Controls.Add(this.txtAIModelPath);
            this.panel1.Controls.Add(this.btnLoadModel);
            this.panel1.Controls.Add(this.btnSelAIModel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(356, 262);
            this.panel1.TabIndex = 10;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(14, 15);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.90723F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.09277F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(362, 539);
            this.tableLayoutPanel2.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.Txt_ModuleInfo);
            this.panel2.Controls.Add(this.Lbl_ModuleInfo);
            this.panel2.Controls.Add(this.lbx_ModelInformation);
            this.panel2.Controls.Add(this.lv_ClassInfos);
            this.panel2.Controls.Add(this.label24);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 271);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(356, 265);
            this.panel2.TabIndex = 21;
            // 
            // Txt_ModuleInfo
            // 
            this.Txt_ModuleInfo.Location = new System.Drawing.Point(5, 239);
            this.Txt_ModuleInfo.Name = "Txt_ModuleInfo";
            this.Txt_ModuleInfo.Size = new System.Drawing.Size(346, 21);
            this.Txt_ModuleInfo.TabIndex = 27;
            // 
            // Lbl_ModuleInfo
            // 
            this.Lbl_ModuleInfo.AutoSize = true;
            this.Lbl_ModuleInfo.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Lbl_ModuleInfo.Location = new System.Drawing.Point(3, 224);
            this.Lbl_ModuleInfo.Name = "Lbl_ModuleInfo";
            this.Lbl_ModuleInfo.Size = new System.Drawing.Size(131, 12);
            this.Lbl_ModuleInfo.TabIndex = 26;
            this.Lbl_ModuleInfo.Text = "Module Information";
            // 
            // lbx_ModelInformation
            // 
            this.lbx_ModelInformation.FormattingEnabled = true;
            this.lbx_ModelInformation.ItemHeight = 12;
            this.lbx_ModelInformation.Location = new System.Drawing.Point(3, 22);
            this.lbx_ModelInformation.Name = "lbx_ModelInformation";
            this.lbx_ModelInformation.Size = new System.Drawing.Size(348, 100);
            this.lbx_ModelInformation.TabIndex = 24;
            // 
            // lv_ClassInfos
            // 
            this.lv_ClassInfos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lv_ClassInfos.GridLines = true;
            this.lv_ClassInfos.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lv_ClassInfos.HideSelection = false;
            this.lv_ClassInfos.Location = new System.Drawing.Point(3, 128);
            this.lv_ClassInfos.MultiSelect = false;
            this.lv_ClassInfos.Name = "lv_ClassInfos";
            this.lv_ClassInfos.Size = new System.Drawing.Size(348, 93);
            this.lv_ClassInfos.TabIndex = 25;
            this.lv_ClassInfos.UseCompatibleStateImageBehavior = false;
            this.lv_ClassInfos.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Name";
            this.columnHeader3.Width = 158;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Color";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "IsNG";
            this.columnHeader5.Width = 50;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label24.Location = new System.Drawing.Point(3, 7);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(123, 12);
            this.label24.TabIndex = 20;
            this.label24.Text = "Model Information";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lv_Result, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(379, 18);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 86.66666F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 272F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(301, 536);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.lbx_ResultDetail);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 266);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(295, 267);
            this.panel5.TabIndex = 16;
            // 
            // lbx_ResultDetail
            // 
            this.lbx_ResultDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbx_ResultDetail.FormattingEnabled = true;
            this.lbx_ResultDetail.ItemHeight = 12;
            this.lbx_ResultDetail.Location = new System.Drawing.Point(0, 0);
            this.lbx_ResultDetail.Name = "lbx_ResultDetail";
            this.lbx_ResultDetail.Size = new System.Drawing.Size(293, 265);
            this.lbx_ResultDetail.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label9);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(295, 29);
            this.panel3.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(108, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 12);
            this.label9.TabIndex = 14;
            this.label9.Text = "Result";
            // 
            // lv_Result
            // 
            this.lv_Result.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7});
            this.lv_Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_Result.GridLines = true;
            this.lv_Result.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lv_Result.HideSelection = false;
            this.lv_Result.Location = new System.Drawing.Point(3, 38);
            this.lv_Result.MultiSelect = false;
            this.lv_Result.Name = "lv_Result";
            this.lv_Result.Size = new System.Drawing.Size(295, 222);
            this.lv_Result.TabIndex = 17;
            this.lv_Result.UseCompatibleStateImageBehavior = false;
            this.lv_Result.View = System.Windows.Forms.View.Details;
            this.lv_Result.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.Lv_Result_ItemSelectionChanged);
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "FileName";
            this.columnHeader6.Width = 200;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Result";
            // 
            // AIModuleProp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "AIModuleProp";
            this.Size = new System.Drawing.Size(695, 570);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbAIModelType;
        private System.Windows.Forms.Button btnInspAI;
        private System.Windows.Forms.Button btnLoadModel;
        private System.Windows.Forms.Button btnSelAIModel;
        private System.Windows.Forms.TextBox txtAIModelPath;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.ListView lv_ClassInfos;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ListBox lbx_ModelInformation;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox Txt_ModuleInfo;
        private System.Windows.Forms.Label Lbl_ModuleInfo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ListView lv_Result;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ListBox lbx_ResultDetail;
    }
}
