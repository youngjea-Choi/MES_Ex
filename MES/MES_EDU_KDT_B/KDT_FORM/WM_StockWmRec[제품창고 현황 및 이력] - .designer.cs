﻿namespace KDT_Form
{
    partial class WM_StockWmRec
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

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			Infragistics.Win.Appearance appearance85 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
			this.lblPlantCode = new DC00_Component.SLabel();
			this.lblItemCode = new DC00_Component.SLabel();
			this.cboPlantCode = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
			this.grid1 = new DC00_Component.Grid(this.components);
			this.cboItemCode = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
			this.txtLotNo = new System.Windows.Forms.TextBox();
			this.sLabel3 = new DC00_Component.SLabel();
			this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
			this.ultraSplitter1 = new Infragistics.Win.Misc.UltraSplitter();
			this.ultraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
			this.grid2 = new DC00_Component.Grid(this.components);
			((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).BeginInit();
			this.gbxHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gbxBody)).BeginInit();
			this.gbxBody.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cboPlantCode)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cboItemCode)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
			this.ultraGroupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
			this.ultraGroupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grid2)).BeginInit();
			this.SuspendLayout();
			// 
			// gbxHeader
			// 
			this.gbxHeader.ContentPadding.Bottom = 2;
			this.gbxHeader.ContentPadding.Left = 2;
			this.gbxHeader.ContentPadding.Right = 2;
			this.gbxHeader.ContentPadding.Top = 4;
			this.gbxHeader.Controls.Add(this.txtLotNo);
			this.gbxHeader.Controls.Add(this.sLabel3);
			this.gbxHeader.Controls.Add(this.cboItemCode);
			this.gbxHeader.Controls.Add(this.cboPlantCode);
			this.gbxHeader.Controls.Add(this.lblItemCode);
			this.gbxHeader.Controls.Add(this.lblPlantCode);
			this.gbxHeader.Location = new System.Drawing.Point(3, 3);
			this.gbxHeader.Size = new System.Drawing.Size(1292, 83);
			// 
			// gbxBody
			// 
			this.gbxBody.ContentPadding.Bottom = 4;
			this.gbxBody.ContentPadding.Left = 4;
			this.gbxBody.ContentPadding.Right = 4;
			this.gbxBody.ContentPadding.Top = 6;
			this.gbxBody.Controls.Add(this.ultraGroupBox2);
			this.gbxBody.Controls.Add(this.ultraSplitter1);
			this.gbxBody.Controls.Add(this.ultraGroupBox1);
			this.gbxBody.Location = new System.Drawing.Point(3, 86);
			this.gbxBody.Size = new System.Drawing.Size(1292, 689);
			// 
			// lblPlantCode
			// 
			appearance85.FontData.BoldAsString = "False";
			appearance85.FontData.UnderlineAsString = "False";
			appearance85.ForeColor = System.Drawing.Color.Black;
			appearance85.TextHAlignAsString = "Right";
			appearance85.TextVAlignAsString = "Middle";
			this.lblPlantCode.Appearance = appearance85;
			this.lblPlantCode.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
			this.lblPlantCode.DbField = null;
			this.lblPlantCode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lblPlantCode.Location = new System.Drawing.Point(23, 22);
			this.lblPlantCode.Name = "lblPlantCode";
			this.lblPlantCode.RequireFlag = DC00_Component.SLabel.RequireFlagEnum.NO;
			this.lblPlantCode.Size = new System.Drawing.Size(83, 23);
			this.lblPlantCode.TabIndex = 181;
			this.lblPlantCode.Text = "공장";
			// 
			// lblItemCode
			// 
			appearance4.FontData.BoldAsString = "False";
			appearance4.FontData.UnderlineAsString = "False";
			appearance4.ForeColor = System.Drawing.Color.Black;
			appearance4.TextHAlignAsString = "Right";
			appearance4.TextVAlignAsString = "Middle";
			this.lblItemCode.Appearance = appearance4;
			this.lblItemCode.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
			this.lblItemCode.DbField = null;
			this.lblItemCode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lblItemCode.Location = new System.Drawing.Point(793, 29);
			this.lblItemCode.Name = "lblItemCode";
			this.lblItemCode.RequireFlag = DC00_Component.SLabel.RequireFlagEnum.NO;
			this.lblItemCode.Size = new System.Drawing.Size(83, 23);
			this.lblItemCode.TabIndex = 184;
			this.lblItemCode.Text = "품목";
			// 
			// cboPlantCode
			// 
			this.cboPlantCode.Font = new System.Drawing.Font("맑은 고딕", 10F);
			this.cboPlantCode.Location = new System.Drawing.Point(112, 21);
			this.cboPlantCode.Name = "cboPlantCode";
			this.cboPlantCode.Size = new System.Drawing.Size(145, 32);
			this.cboPlantCode.TabIndex = 0;
			// 
			// grid1
			// 
			this.grid1.AutoResizeColumn = true;
			this.grid1.AutoUserColumn = true;
			this.grid1.ContextMenuCopyEnabled = true;
			this.grid1.ContextMenuDeleteEnabled = true;
			this.grid1.ContextMenuExcelEnabled = true;
			this.grid1.ContextMenuInsertEnabled = true;
			this.grid1.ContextMenuPasteEnabled = true;
			this.grid1.DeleteButtonEnable = true;
			appearance2.BackColor = System.Drawing.SystemColors.Window;
			appearance2.BorderColor = System.Drawing.SystemColors.InactiveCaption;
			this.grid1.DisplayLayout.Appearance = appearance2;
			this.grid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
			this.grid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
			this.grid1.DisplayLayout.DefaultSelectedBackColor = System.Drawing.Color.Empty;
			appearance3.BackColor = System.Drawing.SystemColors.ActiveBorder;
			appearance3.BackColor2 = System.Drawing.SystemColors.ControlDark;
			appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			appearance3.BorderColor = System.Drawing.SystemColors.Window;
			this.grid1.DisplayLayout.GroupByBox.Appearance = appearance3;
			appearance5.ForeColor = System.Drawing.SystemColors.GrayText;
			this.grid1.DisplayLayout.GroupByBox.BandLabelAppearance = appearance5;
			this.grid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
			this.grid1.DisplayLayout.GroupByBox.Hidden = true;
			appearance6.BackColor = System.Drawing.SystemColors.ControlLightLight;
			appearance6.BackColor2 = System.Drawing.SystemColors.Control;
			appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
			appearance6.ForeColor = System.Drawing.SystemColors.GrayText;
			this.grid1.DisplayLayout.GroupByBox.PromptAppearance = appearance6;
			this.grid1.DisplayLayout.MaxColScrollRegions = 1;
			this.grid1.DisplayLayout.MaxRowScrollRegions = 1;
			appearance7.BackColor = System.Drawing.SystemColors.Window;
			appearance7.ForeColor = System.Drawing.SystemColors.ControlText;
			this.grid1.DisplayLayout.Override.ActiveCellAppearance = appearance7;
			appearance8.BackColor = System.Drawing.SystemColors.Highlight;
			appearance8.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.grid1.DisplayLayout.Override.ActiveRowAppearance = appearance8;
			this.grid1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
			this.grid1.DisplayLayout.Override.AllowMultiCellOperations = ((Infragistics.Win.UltraWinGrid.AllowMultiCellOperation)((((((((Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Copy | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.CopyWithHeaders) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Cut) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Delete) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Paste) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Undo) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Redo) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Reserved)));
			this.grid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
			this.grid1.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
			appearance9.BackColor = System.Drawing.SystemColors.Window;
			this.grid1.DisplayLayout.Override.CardAreaAppearance = appearance9;
			appearance10.BorderColor = System.Drawing.Color.Silver;
			appearance10.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
			this.grid1.DisplayLayout.Override.CellAppearance = appearance10;
			this.grid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
			this.grid1.DisplayLayout.Override.CellPadding = 0;
			appearance11.BackColor = System.Drawing.SystemColors.Control;
			appearance11.BackColor2 = System.Drawing.SystemColors.ControlDark;
			appearance11.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
			appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
			appearance11.BorderColor = System.Drawing.SystemColors.Window;
			this.grid1.DisplayLayout.Override.GroupByRowAppearance = appearance11;
			this.grid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
			this.grid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
			appearance12.BackColor = System.Drawing.SystemColors.Window;
			appearance12.BorderColor = System.Drawing.Color.Silver;
			this.grid1.DisplayLayout.Override.RowAppearance = appearance12;
			this.grid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
			appearance13.BackColor = System.Drawing.SystemColors.ControlLight;
			this.grid1.DisplayLayout.Override.TemplateAddRowAppearance = appearance13;
			this.grid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
			this.grid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
			this.grid1.DisplayLayout.SelectionOverlayBorderThickness = 2;
			this.grid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
			this.grid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grid1.EnterNextRowEnable = true;
			this.grid1.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.grid1.Location = new System.Drawing.Point(3, 30);
			this.grid1.Name = "grid1";
			this.grid1.Size = new System.Drawing.Size(1274, 305);
			this.grid1.TabIndex = 6;
			this.grid1.TabStop = false;
			this.grid1.Text = "grid1";
			this.grid1.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
			this.grid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChange;
			this.grid1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
			this.grid1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
			this.grid1.AfterRowActivate += new System.EventHandler(this.grid1_AfterRowActivate);
			// 
			// cboItemCode
			// 
			this.cboItemCode.Font = new System.Drawing.Font("맑은 고딕", 10F);
			this.cboItemCode.Location = new System.Drawing.Point(882, 26);
			this.cboItemCode.Name = "cboItemCode";
			this.cboItemCode.Size = new System.Drawing.Size(375, 32);
			this.cboItemCode.TabIndex = 187;
			// 
			// txtLotNo
			// 
			this.txtLotNo.Font = new System.Drawing.Font("맑은 고딕", 10F);
			this.txtLotNo.Location = new System.Drawing.Point(405, 22);
			this.txtLotNo.Name = "txtLotNo";
			this.txtLotNo.Size = new System.Drawing.Size(313, 30);
			this.txtLotNo.TabIndex = 237;
			// 
			// sLabel3
			// 
			appearance29.FontData.BoldAsString = "False";
			appearance29.FontData.UnderlineAsString = "False";
			appearance29.ForeColor = System.Drawing.Color.Black;
			appearance29.TextHAlignAsString = "Right";
			appearance29.TextVAlignAsString = "Middle";
			this.sLabel3.Appearance = appearance29;
			this.sLabel3.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
			this.sLabel3.DbField = null;
			this.sLabel3.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.sLabel3.Location = new System.Drawing.Point(316, 26);
			this.sLabel3.Name = "sLabel3";
			this.sLabel3.RequireFlag = DC00_Component.SLabel.RequireFlagEnum.NO;
			this.sLabel3.Size = new System.Drawing.Size(83, 23);
			this.sLabel3.TabIndex = 238;
			this.sLabel3.Text = "LOT NO";
			// 
			// ultraGroupBox1
			// 
			this.ultraGroupBox1.Controls.Add(this.grid1);
			this.ultraGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.ultraGroupBox1.Location = new System.Drawing.Point(6, 6);
			this.ultraGroupBox1.Name = "ultraGroupBox1";
			this.ultraGroupBox1.Size = new System.Drawing.Size(1280, 338);
			this.ultraGroupBox1.TabIndex = 7;
			this.ultraGroupBox1.Text = "제품 재고 현황";
			// 
			// ultraSplitter1
			// 
			this.ultraSplitter1.BackColor = System.Drawing.Color.White;
			this.ultraSplitter1.Dock = System.Windows.Forms.DockStyle.Top;
			this.ultraSplitter1.Location = new System.Drawing.Point(6, 344);
			this.ultraSplitter1.Name = "ultraSplitter1";
			this.ultraSplitter1.RestoreExtent = 338;
			this.ultraSplitter1.Size = new System.Drawing.Size(1280, 18);
			this.ultraSplitter1.TabIndex = 8;
			// 
			// ultraGroupBox2
			// 
			this.ultraGroupBox2.Controls.Add(this.grid2);
			this.ultraGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ultraGroupBox2.Location = new System.Drawing.Point(6, 362);
			this.ultraGroupBox2.Name = "ultraGroupBox2";
			this.ultraGroupBox2.Size = new System.Drawing.Size(1280, 321);
			this.ultraGroupBox2.TabIndex = 9;
			this.ultraGroupBox2.Text = "LOT 별 입/출 이력";
			// 
			// grid2
			// 
			this.grid2.AutoResizeColumn = true;
			this.grid2.AutoUserColumn = true;
			this.grid2.ContextMenuCopyEnabled = true;
			this.grid2.ContextMenuDeleteEnabled = true;
			this.grid2.ContextMenuExcelEnabled = true;
			this.grid2.ContextMenuInsertEnabled = true;
			this.grid2.ContextMenuPasteEnabled = true;
			this.grid2.DeleteButtonEnable = true;
			appearance1.BackColor = System.Drawing.SystemColors.Window;
			appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
			this.grid2.DisplayLayout.Appearance = appearance1;
			this.grid2.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
			this.grid2.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
			this.grid2.DisplayLayout.DefaultSelectedBackColor = System.Drawing.Color.Empty;
			appearance33.BackColor = System.Drawing.SystemColors.ActiveBorder;
			appearance33.BackColor2 = System.Drawing.SystemColors.ControlDark;
			appearance33.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			appearance33.BorderColor = System.Drawing.SystemColors.Window;
			this.grid2.DisplayLayout.GroupByBox.Appearance = appearance33;
			appearance34.ForeColor = System.Drawing.SystemColors.GrayText;
			this.grid2.DisplayLayout.GroupByBox.BandLabelAppearance = appearance34;
			this.grid2.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
			this.grid2.DisplayLayout.GroupByBox.Hidden = true;
			appearance35.BackColor = System.Drawing.SystemColors.ControlLightLight;
			appearance35.BackColor2 = System.Drawing.SystemColors.Control;
			appearance35.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
			appearance35.ForeColor = System.Drawing.SystemColors.GrayText;
			this.grid2.DisplayLayout.GroupByBox.PromptAppearance = appearance35;
			this.grid2.DisplayLayout.MaxColScrollRegions = 1;
			this.grid2.DisplayLayout.MaxRowScrollRegions = 1;
			appearance36.BackColor = System.Drawing.SystemColors.Window;
			appearance36.ForeColor = System.Drawing.SystemColors.ControlText;
			this.grid2.DisplayLayout.Override.ActiveCellAppearance = appearance36;
			appearance43.BackColor = System.Drawing.SystemColors.Highlight;
			appearance43.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.grid2.DisplayLayout.Override.ActiveRowAppearance = appearance43;
			this.grid2.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
			this.grid2.DisplayLayout.Override.AllowMultiCellOperations = ((Infragistics.Win.UltraWinGrid.AllowMultiCellOperation)((((((((Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Copy | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.CopyWithHeaders) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Cut) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Delete) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Paste) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Undo) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Redo) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Reserved)));
			this.grid2.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
			this.grid2.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
			appearance44.BackColor = System.Drawing.SystemColors.Window;
			this.grid2.DisplayLayout.Override.CardAreaAppearance = appearance44;
			appearance57.BorderColor = System.Drawing.Color.Silver;
			appearance57.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
			this.grid2.DisplayLayout.Override.CellAppearance = appearance57;
			this.grid2.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
			this.grid2.DisplayLayout.Override.CellPadding = 0;
			appearance58.BackColor = System.Drawing.SystemColors.Control;
			appearance58.BackColor2 = System.Drawing.SystemColors.ControlDark;
			appearance58.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
			appearance58.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
			appearance58.BorderColor = System.Drawing.SystemColors.Window;
			this.grid2.DisplayLayout.Override.GroupByRowAppearance = appearance58;
			this.grid2.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
			this.grid2.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
			appearance59.BackColor = System.Drawing.SystemColors.Window;
			appearance59.BorderColor = System.Drawing.Color.Silver;
			this.grid2.DisplayLayout.Override.RowAppearance = appearance59;
			this.grid2.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
			appearance61.BackColor = System.Drawing.SystemColors.ControlLight;
			this.grid2.DisplayLayout.Override.TemplateAddRowAppearance = appearance61;
			this.grid2.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
			this.grid2.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
			this.grid2.DisplayLayout.SelectionOverlayBorderThickness = 2;
			this.grid2.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
			this.grid2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grid2.EnterNextRowEnable = true;
			this.grid2.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.grid2.Location = new System.Drawing.Point(3, 30);
			this.grid2.Name = "grid2";
			this.grid2.Size = new System.Drawing.Size(1274, 288);
			this.grid2.TabIndex = 6;
			this.grid2.TabStop = false;
			this.grid2.Text = "grid2";
			this.grid2.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
			this.grid2.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChange;
			this.grid2.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
			this.grid2.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
			// 
			// WM_StockWmRec
			// 
			this.ClientSize = new System.Drawing.Size(1298, 778);
			this.Name = "WM_StockWmRec";
			this.Padding = new System.Windows.Forms.Padding(3);
			this.Text = "제품재고 현황 및 이력 관리";
			this.Load += new System.EventHandler(this.WM_StockWmRec_Load);
			((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).EndInit();
			this.gbxHeader.ResumeLayout(false);
			this.gbxHeader.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.gbxBody)).EndInit();
			this.gbxBody.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.cboPlantCode)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grid1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cboItemCode)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
			this.ultraGroupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
			this.ultraGroupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grid2)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion
        private DC00_Component.SLabel lblPlantCode;
        private DC00_Component.SLabel lblItemCode;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboPlantCode;
        private DC00_Component.Grid grid1;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboItemCode;
        private System.Windows.Forms.TextBox txtLotNo;
        private DC00_Component.SLabel sLabel3;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox2;
		private DC00_Component.Grid grid2;
		private Infragistics.Win.Misc.UltraSplitter ultraSplitter1;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
	}
}
