﻿namespace DC_POPUP
{
    partial class Report_LotBacodeROH
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            this.detail = new Telerik.Reporting.DetailSection();
            this.barcode1 = new Telerik.Reporting.Barcode();
            this.textBox12 = new Telerik.Reporting.TextBox();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.textBox6 = new Telerik.Reporting.TextBox();
            this.textBox7 = new Telerik.Reporting.TextBox();
            this.textBox8 = new Telerik.Reporting.TextBox();
            this.textBox9 = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(3.5000002384185791D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.barcode1,
            this.textBox12,
            this.textBox1,
            this.textBox2,
            this.textBox3,
            this.textBox4,
            this.textBox5,
            this.textBox6,
            this.textBox7,
            this.textBox8,
            this.textBox9});
            this.detail.Name = "detail";
            this.detail.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.detail.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.detail.Style.Visible = true;
            // 
            // barcode1
            // 
            this.barcode1.BarAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.barcode1.Bindings.Add(new Telerik.Reporting.Binding("Value", "=Fields.MATLOTNO"));
            this.barcode1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.19999989867210388D), Telerik.Reporting.Drawing.Unit.Cm(0.60000008344650269D));
            this.barcode1.Name = "barcode1";
            this.barcode1.ShowText = false;
            this.barcode1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(5.6999998092651367D), Telerik.Reporting.Drawing.Unit.Cm(0.59990012645721436D));
            this.barcode1.Stretch = true;
            this.barcode1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(0.0010000000474974513D);
            this.barcode1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.barcode1.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Bottom;
            this.barcode1.Style.Visible = true;
            this.barcode1.Value = "TestBarcode2D";
            // 
            // textBox12
            // 
            this.textBox12.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.19999979436397553D), Telerik.Reporting.Drawing.Unit.Cm(0.099999949336051941D));
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(5.6999998092651367D), Telerik.Reporting.Drawing.Unit.Cm(0.40000033378601074D));
            this.textBox12.Style.BackgroundColor = System.Drawing.Color.White;
            this.textBox12.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox12.Style.Font.Bold = true;
            this.textBox12.Style.Font.Name = "맑은 고딕";
            this.textBox12.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.textBox12.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox12.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox12.Value = "원자재 식별표";
            // 
            // textBox1
            // 
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.19999989867210388D), Telerik.Reporting.Drawing.Unit.Cm(1.2999999523162842D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.5000007152557373D), Telerik.Reporting.Drawing.Unit.Cm(0.40000033378601074D));
            this.textBox1.Style.BackgroundColor = System.Drawing.Color.White;
            this.textBox1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox1.Style.Font.Bold = true;
            this.textBox1.Style.Font.Name = "맑은 고딕";
            this.textBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.textBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox1.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox1.Value = "LOTNO";
            // 
            // textBox2
            // 
            this.textBox2.Bindings.Add(new Telerik.Reporting.Binding("Value", "=Fields.MATLOTNO"));
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(1.7002005577087402D), Telerik.Reporting.Drawing.Unit.Cm(1.2999999523162842D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.1997981071472168D), Telerik.Reporting.Drawing.Unit.Cm(0.40000033378601074D));
            this.textBox2.Style.BackgroundColor = System.Drawing.Color.White;
            this.textBox2.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox2.Style.Font.Bold = true;
            this.textBox2.Style.Font.Name = "맑은 고딕";
            this.textBox2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.textBox2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox2.Value = "TxtBox";
            // 
            // textBox3
            // 
            this.textBox3.Bindings.Add(new Telerik.Reporting.Binding("Value", "=Fields.ITEMCODE"));
            this.textBox3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(1.7068668603897095D), Telerik.Reporting.Drawing.Unit.Cm(1.7002002000808716D));
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.1931314468383789D), Telerik.Reporting.Drawing.Unit.Cm(0.40000033378601074D));
            this.textBox3.Style.BackgroundColor = System.Drawing.Color.White;
            this.textBox3.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox3.Style.Font.Bold = true;
            this.textBox3.Style.Font.Name = "맑은 고딕";
            this.textBox3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.textBox3.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox3.Value = "TxtBox";
            // 
            // textBox4
            // 
            this.textBox4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.20666615664958954D), Telerik.Reporting.Drawing.Unit.Cm(1.7002002000808716D));
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.5000007152557373D), Telerik.Reporting.Drawing.Unit.Cm(0.40000033378601074D));
            this.textBox4.Style.BackgroundColor = System.Drawing.Color.White;
            this.textBox4.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox4.Style.Font.Bold = true;
            this.textBox4.Style.Font.Name = "맑은 고딕";
            this.textBox4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.textBox4.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox4.Value = "품목";
            // 
            // textBox5
            // 
            this.textBox5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.20666535198688507D), Telerik.Reporting.Drawing.Unit.Cm(2.1004006862640381D));
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.5000007152557373D), Telerik.Reporting.Drawing.Unit.Cm(0.40000033378601074D));
            this.textBox5.Style.BackgroundColor = System.Drawing.Color.White;
            this.textBox5.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox5.Style.Font.Bold = true;
            this.textBox5.Style.Font.Name = "맑은 고딕";
            this.textBox5.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.textBox5.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox5.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox5.Value = "품명";
            // 
            // textBox6
            // 
            this.textBox6.Bindings.Add(new Telerik.Reporting.Binding("Value", "=Fields.ITEMNAME"));
            this.textBox6.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(1.7068668603897095D), Telerik.Reporting.Drawing.Unit.Cm(2.1004006862640381D));
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.1931309700012207D), Telerik.Reporting.Drawing.Unit.Cm(0.40000033378601074D));
            this.textBox6.Style.BackgroundColor = System.Drawing.Color.White;
            this.textBox6.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox6.Style.Font.Bold = true;
            this.textBox6.Style.Font.Name = "맑은 고딕";
            this.textBox6.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.textBox6.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox6.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox6.Value = "TxtBox";
            // 
            // textBox7
            // 
            this.textBox7.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.206666961312294D), Telerik.Reporting.Drawing.Unit.Cm(2.500601053237915D));
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.5000007152557373D), Telerik.Reporting.Drawing.Unit.Cm(0.40000033378601074D));
            this.textBox7.Style.BackgroundColor = System.Drawing.Color.White;
            this.textBox7.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox7.Style.Font.Bold = true;
            this.textBox7.Style.Font.Name = "맑은 고딕";
            this.textBox7.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.textBox7.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox7.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox7.Value = "수량";
            // 
            // textBox8
            // 
            this.textBox8.Bindings.Add(new Telerik.Reporting.Binding("Value", "=Fields.STOCKQTY"));
            this.textBox8.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(1.7068676948547363D), Telerik.Reporting.Drawing.Unit.Cm(2.500601053237915D));
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.2931323051452637D), Telerik.Reporting.Drawing.Unit.Cm(0.40000033378601074D));
            this.textBox8.Style.BackgroundColor = System.Drawing.Color.White;
            this.textBox8.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox8.Style.Font.Bold = true;
            this.textBox8.Style.Font.Name = "맑은 고딕";
            this.textBox8.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.textBox8.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox8.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox8.Value = "TxtBox";
            // 
            // textBox9
            // 
            this.textBox9.Bindings.Add(new Telerik.Reporting.Binding("Value", "=Fields.UNITCODE"));
            this.textBox9.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(4.0001997947692871D), Telerik.Reporting.Drawing.Unit.Cm(2.500601053237915D));
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.8997987508773804D), Telerik.Reporting.Drawing.Unit.Cm(0.40000033378601074D));
            this.textBox9.Style.BackgroundColor = System.Drawing.Color.White;
            this.textBox9.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox9.Style.Font.Bold = true;
            this.textBox9.Style.Font.Name = "맑은 고딕";
            this.textBox9.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.textBox9.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox9.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox9.Value = "TxtBox";
            // 
            // Report_LotBacodeROH
            // 
            this.DataSource = null;
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.detail});
            this.Name = "DA9999_R";
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Mm(1.2999999523162842D), Telerik.Reporting.Drawing.Unit.Mm(0.20000000298023224D), Telerik.Reporting.Drawing.Unit.Mm(1.5D), Telerik.Reporting.Drawing.Unit.Mm(0.20000000298023224D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.PageSettings.PaperSize = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(6.4000000953674316D), Telerik.Reporting.Drawing.Unit.Cm(6.4000000953674316D));
            reportParameter1.Name = "TraPlanDate";
            reportParameter1.Value = "TraPlanDate.Value";
            this.ReportParameters.Add(reportParameter1);
            this.Style.BackgroundColor = System.Drawing.Color.White;
            this.Style.BorderColor.Default = System.Drawing.Color.White;
            this.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None;
            this.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.Style.LineColor = System.Drawing.Color.White;
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
            styleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1});
            this.Width = Telerik.Reporting.Drawing.Unit.Cm(6.25D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.Barcode barcode1;
        private Telerik.Reporting.TextBox textBox12;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.TextBox textBox4;
        private Telerik.Reporting.TextBox textBox5;
        private Telerik.Reporting.TextBox textBox6;
        private Telerik.Reporting.TextBox textBox7;
        private Telerik.Reporting.TextBox textBox8;
        private Telerik.Reporting.TextBox textBox9;
    }
}