﻿#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : WM_StockShip
//   Form Name    : 공정 재고 입출 이력
//   Name Space   : DC_PP
//   Created Date : 2023-01-27
//   Made By      : 최영재
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Data;
using DC_POPUP;

using DC00_assm;
using DC00_PuMan;
using DC00_WinForm;

using Infragistics.Win.UltraWinGrid;
#endregion

namespace KDT_Form
{
    public partial class WM_StockShip : DC00_WinForm.BaseMDIChildForm
    {

        #region < MEMBER AREA > 
        UltraGridUtil _GridUtil = new UltraGridUtil();  //그리드 객체 생성 
        DataTable rtnDtTemp = new DataTable(); // 
        #endregion


        #region < CONSTRUCTOR >
        public WM_StockShip()
        {
            InitializeComponent();
        }
        #endregion


        #region < FORM EVENTS >
        private void WM_StockShip_Load(object sender, EventArgs e)
        {
            string plantCode = LoginInfo.PlantCode;

            #region ▶ GRID ◀
            _GridUtil.InitializeGrid(this.grid1);
            _GridUtil.InitColumnUltraGrid(grid1, "CHK", "상차등록", GridColDataType_emu.CheckBox, 80, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "공장", GridColDataType_emu.VarChar, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", GridColDataType_emu.VarChar, 140, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", GridColDataType_emu.VarChar, 150, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "LOTNO", "LOT NO", GridColDataType_emu.VarChar, 150, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WHCODE", "창고", GridColDataType_emu.VarChar, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "STOCKQTY", "재고수량", GridColDataType_emu.Double, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "단위", GridColDataType_emu.VarChar, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INDATE", "입고일자", GridColDataType_emu.VarChar, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "입고자", GridColDataType_emu.VarChar, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "입고일시", GridColDataType_emu.DateTime24, 180, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            #region ▶ COMBOBOX ◀
            rtnDtTemp = Common.StandardCODE("PLANTCODE");  // 사업장
            Common.FillComboboxMaster(this.cboPlantCode, rtnDtTemp);
            UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp);

            rtnDtTemp = Common.StandardCODE("UNITCODE");     //단위
            UltraGridUtil.SetComboUltraGrid(this.grid1, "UNITCODE", rtnDtTemp);

            rtnDtTemp = Common.StandardCODE("WHCODE");     //창고
            UltraGridUtil.SetComboUltraGrid(this.grid1, "WHCODE", rtnDtTemp);

            rtnDtTemp = Common.Get_ItemCode(new string[] { "FERT" });
            Common.FillComboboxMaster(cboItemCode, rtnDtTemp);
            #endregion

            #region ▶ POP-UP ◀
            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtWorkerID, txtWorkerName, "WORKER_MASTER");
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
                _GridUtil.Grid_Clear(grid1);
                string sPlantCode = Convert.ToString(this.cboPlantCode.Value);
                string sItemCode = Convert.ToString(this.cboItemCode.Value);
                string sLotNo = Convert.ToString(txtLotNo.Text);
                string sStartdate = string.Format("{0:yyyy-MM-dd}", dtStartDate.Value);
                string sEndDate = string.Format("{0:yyyy-MM-dd}", dtEnddate.Value);

                rtnDtTemp = helper.FillTable("06WM_StockShip_S1", CommandType.StoredProcedure
                                    , helper.CreateParameter("PLANTCODE", sPlantCode)
                                    , helper.CreateParameter("ITEMCODE", sItemCode)
                                    , helper.CreateParameter("LOTNO", sLotNo)
                                    , helper.CreateParameter("STARTDATE", sStartdate)
                                    , helper.CreateParameter("ENDDATE", sEndDate)
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


        public override void DoSave()
        {
            if (grid1.Rows.Count == 0) return;

            // 그리드 에서 변경 된 행 을 받아온다.
            DataTable dtChang = grid1.chkChange();
            if (dtChang == null) return;

            DBHelper helper = new DBHelper(true);
            try
            {
                //차량 번호 입력 여부 확인
                string sCarNo = txtCarNo.Text;
                if (sCarNo == "")
                {
                    ShowDialog("차량 정보를 입력하지 않았습니다.");
                    return;
                }
                //운송자 정보 입력 여부 확인
                string sWorker = txtWorkerID.Text;
                if (sWorker == "")
                {
                    ShowDialog("운송자 정보를 입력하지 않았습니다.");
                    return;
                }
                //거래처 정보 입력 여부 확인
                string sCustCode = txtCustCode.Text;
                if (sCustCode == "")
                {
                    ShowDialog("거래처 정보를 입력하지 않았습니다.");
                    return;
                }

                string sLotNo = string.Empty;
                string sItemCode = string.Empty;
                string sPlantCode = string.Empty;
                double dStockQty = 0;
                string sShipNo = string.Empty;

                foreach (DataRow dr in dtChang.Rows)
                {
                    switch (dr.RowState)
                    {
                        case DataRowState.Modified:

                            sLotNo = Convert.ToString(dr["LOTNO"]);
                            sItemCode = Convert.ToString(dr["ITEMCODE"]);
                            sPlantCode = Convert.ToString(dr["PLANTCODE"]);
                            dStockQty = Convert.ToDouble(dr["STOCKQTY"]);
                            //updateCnt++;
                            helper.ExecuteNoneQuery("06WM_StockShip_U1", CommandType.StoredProcedure,
                                              helper.CreateParameter("@PLANTCODE",   sPlantCode),
                                              helper.CreateParameter("@LOTNO",           sLotNo),
                                              helper.CreateParameter("@CARNO",           sCarNo),
                                              helper.CreateParameter("@CUSTCODE",     sCustCode),
                                              helper.CreateParameter("@WORKER",         sWorker),
                                              helper.CreateParameter("@ITEMCODE",     sItemCode),
                                              helper.CreateParameter("@SHIPQTY",      dStockQty),
                                              helper.CreateParameter("@MAKER", LoginInfo.UserID),
                                              helper.CreateParameter("@SHIPNO",         sShipNo)
                                              );
                            break;
                    }

                    if (helper.RSCODE != "S") throw new Exception(helper.RSMSG);
                    sShipNo = helper.RSMSG;
                }

                helper.Commit();
                ShowDialog("상차 실적 등록을 완료 하였습니다.");
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
        #endregion
    }
}



