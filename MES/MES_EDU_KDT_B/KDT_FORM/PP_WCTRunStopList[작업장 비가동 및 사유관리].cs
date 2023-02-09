#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PP_WCTRunStopList
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
    public partial class PP_WCTRunStopList : DC00_WinForm.BaseMDIChildForm
    {

        #region < MEMBER AREA > 
        UltraGridUtil _GridUtil = new UltraGridUtil();  //그리드 객체 생성 
        DataTable rtnDtTemp = new DataTable(); // 
        #endregion


        #region < CONSTRUCTOR >
        public PP_WCTRunStopList()
        {
            InitializeComponent();
        }
        #endregion


        #region < FORM EVENTS >
        private void PP_WCTRunStopList_Load(object sender, EventArgs e)
        { 
            string plantCode        = LoginInfo.PlantCode;

            #region ▶ GRID ◀
           
            _GridUtil.InitializeGrid(this.grid1);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE",       "공장",                      GridColDataType_emu.VarChar,    120, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "RSSEQ",           "작업장 지시별 순번",        GridColDataType_emu.VarChar,    140, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE",  "작업장",                    GridColDataType_emu.VarChar,    150, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME",  "작업장명",                  GridColDataType_emu.VarChar,    120, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ORDERNO",         "작업지시번호",              GridColDataType_emu.VarChar,    160, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE",        "품목코드",                  GridColDataType_emu.VarChar,    120, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME",        "품명",                      GridColDataType_emu.Double,     100, Infragistics.Win.HAlign.Right,  true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKERNAME",      "작업자",                    GridColDataType_emu.VarChar,    100, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "STATUSNAME",      "가동/비가동",               GridColDataType_emu.VarChar,    100, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "RSSTARTDATE",     "시작일시",                  GridColDataType_emu.VarChar,    100, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "RSENDDATE",       "종료일시",                  GridColDataType_emu.VarChar,    120, Infragistics.Win.HAlign.Left,  false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "LOTO"   ,         "LOTNO",                     GridColDataType_emu.VarChar,    160, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "TIMEDIFF"   ,     "소요시간(분)",              GridColDataType_emu.VarChar,    140, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PRODQTY"   ,      "양품수량",                  GridColDataType_emu.VarChar,    150, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "BADQTY"  ,        "불량수량",                  GridColDataType_emu.VarChar,    120, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "REMARK"     ,     "사유",                      GridColDataType_emu.VarChar,    120, Infragistics.Win.HAlign.Left,   true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER"      ,     "등록자",                    GridColDataType_emu.VarChar,    100, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE"   ,     "등록일시",                  GridColDataType_emu.DateTime24, 160, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR"           ,"입출유형",                 GridColDataType_emu.VarChar,    100, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE"  ,      "입출구분",                  GridColDataType_emu.VarChar,    100, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            #region ▶ COMBOBOX ◀
            rtnDtTemp = Common.StandardCODE("PLANTCODE");  // 사업장
            Common.FillComboboxMaster(this.cboPlantCode, rtnDtTemp);

            rtnDtTemp = Common.GET_Workcenter_Code();    //작업장
            Common.FillComboboxMaster(this.cboWCode, rtnDtTemp);


            rtnDtTemp = Common.GET_StopList(); // 비가동 사유
            UltraGridUtil.SetComboUltraGrid(this.grid1, "REMARK", rtnDtTemp);


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
                string sItemCode  = Convert.ToString(this.cboWCode.Value);
                string sStartDate = string.Format("{0:yyyy-MM-dd}", dtStartDate.Value);
                string sEndDate   = string.Format("{0:yyyy-MM-dd}", dtEnddate.Value);


                rtnDtTemp = helper.FillTable("06PP_WCTRunStopList_S1", CommandType.StoredProcedure
                                    , helper.CreateParameter("PLANTCODE", sPlantCode)
                                    , helper.CreateParameter("WORKCENTERCODE", sItemCode)
                                    , helper.CreateParameter("STARTDATE", sStartDate)
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
        #endregion

        public override void DoSave()
        {
            // 저장 할 대상이 있는지 확인 (그리드에 번경된 내역이 있는지 추출)
            DataTable dt = grid1.chkChange();
            if (dt == null)
            {
                ShowDialog("저장 할 내역이 없습니다.");
                return;
            }

            DBHelper helper = new DBHelper(true); // 트랜잭션 사용 DB 커넥터.
            try
            {
                foreach (DataRow drRow in dt.Rows)
                {
                    switch (drRow.RowState)
                    {
                        case DataRowState.Modified:
                            if (Convert.ToString(drRow["REMARK"]) == "") continue;
                            helper.ExecuteNoneQuery("06PP_WCTRunStopList_U1",           CommandType.StoredProcedure
                                             , helper.CreateParameter("PLANTCODE",      Convert.ToString(drRow["PLANTCODE"]))
                                             , helper.CreateParameter("WORKCENTERCODE", Convert.ToString(drRow["WORKCENTERCODE"]))
                                             , helper.CreateParameter("ORDERNO",        Convert.ToString(drRow["ORDERNO"]))
                                             , helper.CreateParameter("RSSEQ",          Convert.ToString(drRow["RSSEQ"]))
                                             , helper.CreateParameter("REMARK",         Convert.ToString(drRow["REMARK"]))
                                             , helper.CreateParameter("MAKEDATE",         Convert.ToString(drRow["MAKEDATE"]))
                                             , helper.CreateParameter("EDITOR",         LoginInfo.UserID)
                                             );
                            break;
                    }
                    if (helper.RSCODE != "S")
                    {
                        helper.Rollback();
                        ShowDialog(helper.RSMSG);
                        return;
                    }
                }
                helper.Commit();
                ClosePrgForm();
               ShowDialog("정상적으로 등록을 완료 하였습니다.");

            }
            catch (Exception ex)
            {
                ClosePrgForm();
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




