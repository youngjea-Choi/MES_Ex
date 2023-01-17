﻿#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PP_StockPPRec
//   Form Name    : 공정 재고 입출 이력
//   Name Space   : DC_PP
//   Created Date : 2020/08
//   Made By      : DSH
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Data;
using DC_POPUP;

using DC00_assm;
using DC00_WinForm;

using Infragistics.Win.UltraWinGrid;
#endregion

namespace KDT_Form
{
    public partial class PP_StockPPRec : DC00_WinForm.BaseMDIChildForm
    {

        #region < MEMBER AREA > 
        UltraGridUtil _GridUtil = new UltraGridUtil();  //그리드 객체 생성 
        DataTable rtnDtTemp = new DataTable(); // 
        #endregion


        #region < CONSTRUCTOR >
        public PP_StockPPRec()
        {
            InitializeComponent();
        }
        #endregion


        #region < FORM EVENTS >
        private void PP_StockPPRec_Load(object sender, EventArgs e)
        { 
            string plantCode        = LoginInfo.PlantCode;

            #region ▶ GRID ◀
            //_GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            //_GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE"  ,"공장",       true, GridColDataType_emu.VarChar,    120, 120, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitializeGrid(this.grid1);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "공장",         GridColDataType_emu.VarChar,    120, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "LOTNO"   ,   "LOTNO",       GridColDataType_emu.VarChar,    160, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE"   ,"품목",        GridColDataType_emu.VarChar,    140, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME"   ,"품명",        GridColDataType_emu.VarChar,    150, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INOUTDATE"  ,"입/출일자",   GridColDataType_emu.VarChar,    120, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WHCODE"     ,"창고",        GridColDataType_emu.VarChar,    120, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INOUTCODE"  ,"입출유형",    GridColDataType_emu.VarChar,    100, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INOUTFLAG"  ,"입출구분",    GridColDataType_emu.VarChar,    100, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INOUTQTY"   ,"입출수량",    GridColDataType_emu.Double,     100, Infragistics.Win.HAlign.Right,  true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "BASEUNIT"   ,"단위",        GridColDataType_emu.VarChar,    100, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER"      ,"등록자",      GridColDataType_emu.VarChar,    100, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE"   ,"등록일시",    GridColDataType_emu.DateTime24, 160, Infragistics.Win.HAlign.Left,   true, false);




            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            #region ▶ COMBOBOX ◀
            rtnDtTemp = Common.StandardCODE("PLANTCODE");  // 사업장
            Common.FillComboboxMaster(this.cboPlantCode, rtnDtTemp);
            UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp);

            rtnDtTemp = Common.StandardCODE("UNITCODE");     //단위
            UltraGridUtil.SetComboUltraGrid(this.grid1, "UNITCODE", rtnDtTemp);
             
            rtnDtTemp = Common.Get_ItemCode(new string[] { "ROH" });
            Common.FillComboboxMaster(this.cboItemCode, rtnDtTemp);


            rtnDtTemp = Common.StandardCODE("WHCODE");     //창고
            UltraGridUtil.SetComboUltraGrid(this.grid1, "WHCODE", rtnDtTemp);

            rtnDtTemp = Common.StandardCODE("INOUTCODE");     //입출유형
            UltraGridUtil.SetComboUltraGrid(this.grid1, "INOUTCODE", rtnDtTemp);

            rtnDtTemp = Common.StandardCODE("INOUTFLAG");     //입출 구분 
            UltraGridUtil.SetComboUltraGrid(this.grid1, "INOUTFLAG", rtnDtTemp);

            #endregion

            #region ▶ POP-UP ◀
            #endregion

            #region ▶ ENTER-MOVE ◀
            cboPlantCode.Value = plantCode;
            #endregion
        }
        #endregion


        #region < TOOL BAR AREA >
        public override void DoInquire()
        {
            DoFind();
        }
        private void DoFind()
        {
            DBHelper helper = new DBHelper(false);
            try
            { 
                _GridUtil.Grid_Clear(grid1);
                string sPlantCode = Convert.ToString(this.cboPlantCode.Value);
                string sItemCode  = Convert.ToString(this.cboItemCode.Value); 
                string sLotNo     = Convert.ToString(txtLotNo.Text );
                string sStartdate = string.Format("{0:yyyy-MM-dd}", dtStartDate.Value);
                string sEndDate   = string.Format("{0:yyyy-MM-dd}", dtEnddate.Value);

                rtnDtTemp = helper.FillTable("PP_StockPPRec_S1", CommandType.StoredProcedure
                                    , helper.CreateParameter("PLANTCODE", sPlantCode)
                                    , helper.CreateParameter("ITEMCODE",  sItemCode)
                                    , helper.CreateParameter("LOTNO",     sLotNo   )
                                    , helper.CreateParameter("STARTDATE", sStartdate)
                                    , helper.CreateParameter("ENDDATE",   sEndDate )
                                    );
                 
                this.grid1.DataSource = rtnDtTemp;
               
            }
            catch (Exception ex)
            {
                ShowDialog(ex.ToString(), DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion 
    }
}




