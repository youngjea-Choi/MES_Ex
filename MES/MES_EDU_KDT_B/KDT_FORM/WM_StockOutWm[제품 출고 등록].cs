﻿#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PP_STockWIP
//   Form Name    : 재공 재고 조회
//   Name Space   : DC_PP
//   Created Date : 2023/01/27
//   Made By      : 이마무라 영재
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Data;
using DC00_PuMan;

using DC00_assm;
using DC00_WinForm;

using Infragistics.Win.UltraWinGrid;
#endregion

namespace KDT_Form
{
    public partial class WM_StockOutWm : DC00_WinForm.BaseMDIChildForm
    {

        #region < MEMBER AREA >
        DataTable rtnDtTemp = new DataTable(); // 
        UltraGridUtil _GridUtil = new UltraGridUtil();  //그리드 객체 생성 
        string plantCode = LoginInfo.PlantCode;

        #endregion


        #region < CONSTRUCTOR >
        public WM_StockOutWm()
        {
            InitializeComponent();
        }
        #endregion


        #region < FORM EVENTS >
        private void WM_StockOutWm_Load(object sender, EventArgs e)
        {
            #region ▶ GRID ◀
            // 상차 실적 공통 내역 조회 및 선택
            _GridUtil.InitializeGrid(this.grid1);

            _GridUtil.InitColumnUltraGrid(grid1, "CHK", "출고등록", GridColDataType_emu.CheckBox, 80, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "공장", GridColDataType_emu.VarChar, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "SHIPNO", "상차번호", GridColDataType_emu.VarChar, 140, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "SHIPDATE", "상차일자", GridColDataType_emu.VarChar, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "CARNO", "차량번호", GridColDataType_emu.VarChar, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTCODE", "거래처코드", GridColDataType_emu.VarChar, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTNAME", "거래처명", GridColDataType_emu.VarChar, 130, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKER", "운행자", GridColDataType_emu.VarChar, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "등록일시", GridColDataType_emu.DateTime24, 160, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "등록자", GridColDataType_emu.VarChar, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일시", GridColDataType_emu.DateTime24, 160, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "수정자", GridColDataType_emu.VarChar, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.SetInitUltraGridBind(grid1);

            _GridUtil.InitializeGrid(this.grid2);
            _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "공장", GridColDataType_emu.VarChar, 100, Infragistics.Win.HAlign.Left, false, false);
            _GridUtil.InitColumnUltraGrid(grid2, "SHIPNO", "상차번호", GridColDataType_emu.VarChar, 140, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "SHIPSEQ", "상차순번", GridColDataType_emu.VarChar, 80, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "LOTNO", "LOTNO", GridColDataType_emu.VarChar, 160, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE", "품번", GridColDataType_emu.VarChar, 140, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMNAME", "품명", GridColDataType_emu.VarChar, 160, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "SHIPQTY", "수량", GridColDataType_emu.Double, 80, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "UNITCODE", "단위", GridColDataType_emu.VarChar, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.SetInitUltraGridBind(grid2);
            #endregion

            #region ▶ COMBOBOX ◀
            rtnDtTemp = Common.StandardCODE("PLANTCODE");  // 사업장
            Common.FillComboboxMaster(this.cboPlantCode, rtnDtTemp);
            UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp);

            rtnDtTemp = Common.StandardCODE("UNIT");     //단위
            UltraGridUtil.SetComboUltraGrid(this.grid2, "ITEMTYPE", rtnDtTemp);

            #endregion

            #region ▶ POP-UP ◀
            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtCustCode, txtCustName, "CUST_MASTER");
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
                base.DoInquire();
                _GridUtil.Grid_Clear(grid1);
                string sPlantCode = Convert.ToString(cboPlantCode.Value);
                string sCarNo = Convert.ToString(txtCarNo.Text);
                string sShipNo = Convert.ToString(txtShipNo.Text);
                string sCustCode = Convert.ToString(txtCustCode.Text);
                string sStartDate = string.Format("{0:yyyy-MM-dd}", dtStartDate.Value);
                string sEndDate = string.Format("{0:yyyy-MM-dd}", dtEndDate.Value);


                rtnDtTemp = helper.FillTable("04WM_StockOutWm_S1", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("@PLANTCODE", sPlantCode)
                                                                   , helper.CreateParameter("@CARNO", sCarNo)
                                                                   , helper.CreateParameter("@SHIPNO", sShipNo)
                                                                   , helper.CreateParameter("@CUSTCODE", sCustCode)
                                                                   , helper.CreateParameter("@STARTDATE", sStartDate)
                                                                   , helper.CreateParameter("@ENDDATE", sEndDate)
                                                                   );
                this.ClosePrgForm();
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

        private void grid1_AfterRowActivate(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper(false);
            try
            {
                _GridUtil.Grid_Clear(grid2);
                string sPlantCode = Convert.ToString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
                string sShipNo = Convert.ToString(grid1.ActiveRow.Cells["SHIPNO"].Value);


                rtnDtTemp = helper.FillTable("06WM_StockOutWm_S2", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("@PLANTCODE", sPlantCode)
                                                                   , helper.CreateParameter("@SHIPNO", sShipNo)
                                                                   );
                //this.ClosePrgForm();
                this.grid2.DataSource = rtnDtTemp;
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

        public override void DoSave()
        {
            if (grid1.Rows.Count == 0) return;

            // 그리드 에서 변경 된 행 을 받아온다.
            DataTable dtChang = grid1.chkChange();
            if (dtChang == null)
            {
                ShowDialog("저장 할 내역이 없습니다.");
                return;
            }

            DBHelper helper = new DBHelper(true);
            try
            {
                string sTradingNo = string.Empty;
                string chkCarNo = string.Empty;
                for (int i = 0; i < dtChang.Rows.Count; i++)
                {
                    if (Convert.ToString(dtChang.Rows[i]["CHK"]) != "1") continue;

                    if (i == 0) chkCarNo = Convert.ToString(dtChang.Rows[i]["CARNO"]);
                    else
                    {
                        if (Convert.ToString(dtChang.Rows[i]["CARNO"]) != chkCarNo)
                        {
                            ShowDialog("차량번호가 동일하지 않은 상차실적은 출고등록 할 수 없습니다.");
                            return;
                        }
                    }
                }

                foreach (DataRow dr in dtChang.Rows)
                {
                    switch (dr.RowState)
                    {
                        case DataRowState.Modified:

                            if (Convert.ToString(dr["CHK"]) != "1") continue;

                            helper.ExecuteNoneQuery("06WM_StockOutWm_U1", CommandType.StoredProcedure,
                                                    helper.CreateParameter("@PLANTCODE", Convert.ToString(dr["PLANTCODE"])),
                                                    helper.CreateParameter("@SHIPNO", Convert.ToString(dr["SHIPNO"])),
                                                    helper.CreateParameter("@TRADINGNO", sTradingNo),
                                                    helper.CreateParameter("@MAKER", LoginInfo.UserID)
                                                    );

                            break;
                    }

                    if (helper.RSCODE != "S") throw new Exception(helper.RSMSG);
                    sTradingNo = helper.RSMSG;


                }

                helper.Commit();
                ShowDialog("출고 등록을 완료 하였습니다.");
                DoInquire();
            }
            catch (Exception ex)
            {
                helper.Rollback();
                ShowDialog(ex.ToString());
            }
            finally
            {
                helper.Close();

            }
        }
    }
}



