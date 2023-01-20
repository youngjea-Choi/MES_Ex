#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : AP_OrderPerProduct
//   Form Name    : 작업지시 별 생산실적 현황
//   Name Space   : KDT_Form
//   Created Date : 2023-01-020
//   Made By      : 최영재
//   Description  : 최초 프로그램 생성
// *---------------------------------------------------------------------------------------------*
#endregion

using DC00_assm;
using Infragistics.Win;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KDT_Form
{
    public partial class AP_OrderPerProduct : DC00_WinForm.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        UltraGridUtil GridUtil = new UltraGridUtil(); //그리드를 셋팅하는 클래스
        public AP_OrderPerProduct()
        {
            InitializeComponent();
        }
        #endregion

        #region < EVENT AREA >

        private void AP_OrderPerProduct_Load(object sender, EventArgs e)
        {
            // 1. 그리드 셋팅

            GridUtil.InitializeGrid(grid1); //그리드 초기화
            GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE",       "공장",              GridColDataType_emu.VarChar,    100, HAlign.Left,  true, false);
            GridUtil.InitColumnUltraGrid(grid1, "ORDERNO",         "작업지시번호",      GridColDataType_emu.VarChar,    150, HAlign.Left,  true, false);
            GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE",        "품목",              GridColDataType_emu.VarChar,    150, HAlign.Left,  true, false);
            GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME",        "품목명",            GridColDataType_emu.VarChar,    150, HAlign.Left,  true, false);
            GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE",  "작업장코드",        GridColDataType_emu.VarChar,    100, HAlign.Left,  true, false);
            GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME",  "작업장",            GridColDataType_emu.VarChar,    120, HAlign.Left,  true, false);
            GridUtil.InitColumnUltraGrid(grid1, "ORDERQTY",        "지시수량",          GridColDataType_emu.Double,     100, HAlign.Right, true, false);
            GridUtil.InitColumnUltraGrid(grid1, "UNITCODE",        "단위",              GridColDataType_emu.VarChar,    100, HAlign.Left,  true, false);
            GridUtil.InitColumnUltraGrid(grid1, "ORDERDATE",       "지시일자",          GridColDataType_emu.VarChar,    100, HAlign.Left,  true, false);
            GridUtil.InitColumnUltraGrid(grid1, "PRODQTY",         "양품수량",          GridColDataType_emu.Double,     100, HAlign.Right, true, false);
            GridUtil.InitColumnUltraGrid(grid1, "BADQTY",          "불량수량",          GridColDataType_emu.Double,     100, HAlign.Right, true, false);
            GridUtil.InitColumnUltraGrid(grid1, "TOTALPRODQTY",    "합계",              GridColDataType_emu.Double,     100, HAlign.Right, true, false);
            GridUtil.InitColumnUltraGrid(grid1, "ACTRATE",         "지시달성률",        GridColDataType_emu.VarChar,    100, HAlign.Left,  true, false);
            GridUtil.InitColumnUltraGrid(grid1, "FIRSTSTARTDATE",  "지시시작일시",      GridColDataType_emu.DateTime24, 150, HAlign.Left,  true, false);
            GridUtil.InitColumnUltraGrid(grid1, "ORDERCLOSEDATE",  "지시종료일시",      GridColDataType_emu.DateTime24, 150, HAlign.Left,  true, false);
            GridUtil.InitColumnUltraGrid(grid1, "TOTALRUNTIME",    "지시운영시간(분)",  GridColDataType_emu.Double,     100, HAlign.Right, true, false);


            GridUtil.SetInitUltraGridBind(grid1); //그리드 데이터 바인딩 초기화

            // 2. 콤보박스 셋팅.
            DataTable dtTemp = new DataTable(); // 콤보박스 셋팅 할 데이터를 받아올 자료형.

            //공장
            dtTemp = Common.StandardCODE("PLANTCODE");                   // 공통기준정보 PLANTCODE 데이터 가져오기.
            Common.FillComboboxMaster(cboPlantCode, dtTemp);             // 콤보박스 컨트롤에 셋팅
            UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", dtTemp); // 그리드에 콤보박스 세팅

            //단위
            dtTemp = Common.StandardCODE("UNITCODE");
            UltraGridUtil.SetComboUltraGrid(grid1, "UNITCODE", dtTemp);
            UltraGridUtil.SetComboUltraGrid(this.grid1, "UNITCODE", dtTemp); // 그리드에 콤보박스 세팅

            //ROH : 원자재, HLAB : 반제품, FERT : 완제품
            dtTemp = Common.Get_ItemCode(new string[] { "FERT" });
            Common.FillComboboxMaster(cboItemCode, dtTemp);


            dtTemp = Common.GET_Workcenter_Code();
            Common.FillComboboxMaster(this.cboWorkcenter, dtTemp);
        }
        #endregion

        #region < TOOLBAR AREA >

        public override void DoInquire()
        {
            base.DoInquire();
             //트랜잭션을 사용하지 않을 helper
            DBHelper helper = new DBHelper(false);
            try
            {
                // 조회조건 변수 등록 및 데이터 대입
                string sPlantCode = Convert.ToString(cboPlantCode.Value);        // 공장
                string sWorkcenterCode = Convert.ToString(cboWorkcenter.Value);  // 작업장
                string sStartDate = Convert.ToString(dtStartDate.Value);         // 입출시작일자
                string sEndDate = Convert.ToString(dtEndDate.Value);             // 입출끝난일자
                string sItemCode = Convert.ToString(cboItemCode.Value);          // 품목 코드
                string sOrderNo = txtOrderNo.Text;                               // 작업지시번호



                DataTable dtTemp = new DataTable();
                dtTemp = helper.FillTable("06AP_OrderPerProduct_S1", CommandType.StoredProcedure
                                           , helper.CreateParameter("@PLANTCODE", sPlantCode)
                                           , helper.CreateParameter("@WORKCENTERCODE", sWorkcenterCode)
                                           , helper.CreateParameter("@STARTDATE", sStartDate)
                                           , helper.CreateParameter("@ENDDATE", sEndDate)
                                           , helper.CreateParameter("@ITEMCODE", sItemCode)
                                           , helper.CreateParameter("@ORDERNO", sOrderNo)
                                           );

                if (dtTemp.Rows.Count == 0)
                {
                    ShowDialog("조회할 내역이 없습니다.");
                    GridUtil.Grid_Clear(grid1);
                    return;
                }
                grid1.DataSource = dtTemp;

            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.ToString());

            }
            finally 
            {
                helper.Close();
            }
        }

        public override void DoNew()
        {
            grid1.InsertRow();

            //기본갑 세팅
            grid1.SetDefaultValue("PLANTCODE", LoginInfo.PlantCode);
            grid1.SetDefaultValue("CHK", 0); // 확정체크
            grid1.SetDefaultValue("PODATE", string.Format("{0:yyyy-MM-dd}",DateTime.Now)); // 오늘일자
        }

        public override void DoDelete()
        {
            grid1.DeleteRow();
        }

        public override void DoSave()
        {
            base.DoSave();

            DataTable dtTemp = grid1.chkChange();

            if (dtTemp == null)
            {
                ShowDialog("저장할 행이 없습니다.");
                return;
            }

            string sMessage = string.Empty; // 필수 입력 내역 확인용 변수


            DBHelper helper = new DBHelper(true); // 트랜잭션 사용 DB 커넥터

            try
            {
                foreach (DataRow dr in dtTemp.Rows)
                {


                    switch (dr.RowState)
                    {
                        case DataRowState.Deleted:
                            dr.RejectChanges(); // 삭제된 데이터 원상복귀

                            //생산계획을 취소

                            helper.ExecuteNoneQuery("06AP_OrderPerProduct_D1", CommandType.StoredProcedure,
                                                    helper.CreateParameter("@PLANTCODE", Convert.ToString(dr["PLANTCODE"])),
                                                    helper.CreateParameter("@PLANNO",    Convert.ToString(dr["PLANNO"]))
                                                    );
                            break;
                            
                            //구매자재 발주 등록
                        case DataRowState.Added:
                            if (Convert.ToString(dr["ITEMCODE"]) == "") sMessage = "발주품목 ";
                            if (Convert.ToString(dr["CUSTCODE"]) == "") sMessage += "거래처 ";
                            if (Convert.ToString(dr["PODATE"]) == "")   sMessage += "발주일자 ";
                            if (Convert.ToString(dr["POQTY"]) == "")    sMessage += "발주수량 ";

                            if(sMessage != "") throw new Exception(sMessage + "을(를) 입력하지 않았습니다.");
                         
                            helper.ExecuteNoneQuery("06AP_OrderPerProduct_I1", CommandType.StoredProcedure,
                                                   helper.CreateParameter("@PLANTCODE", Convert.ToString(dr["PLANTCODE"])),
                                                   helper.CreateParameter("@ITEMCODE",  Convert.ToString(dr["ITEMCODE"])),
                                                   helper.CreateParameter("@POQTY",     Convert.ToString(dr["POQTY"])),
                                                   helper.CreateParameter("@UNITCODE",  Convert.ToString(dr["UNITCODE"])),
                                                   helper.CreateParameter("@CUSTCODE",  Convert.ToString(dr["CUSTCODE"])),
                                                   helper.CreateParameter("@PODATE",    Convert.ToString(dr["PODATE"])),
                                                   helper.CreateParameter("@MAKER",     LoginInfo.UserID)
                                                   );                                   
                            break;

                            
                            //발주 내역으로 입고 등록
                        case DataRowState.Modified:
                     
                            if (Convert.ToString(dr["INQTY"]) == "") throw new Exception("입고수량을 입력하지 않았습니다.");

                            helper.ExecuteNoneQuery("06AP_OrderPerProduct_U1", CommandType.StoredProcedure,
                                                   helper.CreateParameter("@PLANTCODE", Convert.ToString(dr["PLANTCODE"])),
                                                   helper.CreateParameter("@PONO",      Convert.ToString(dr["PONO"])),
                                                   helper.CreateParameter("@INQTY",     Convert.ToString(dr["INQTY"])),
                                                   helper.CreateParameter("@ITEMCODE", Convert.ToString(dr["ITEMCODE"])),
                                                   helper.CreateParameter("@EDITOR",    LoginInfo.UserID)
                                                   );
                            break;
                    }

                    if (helper.RSCODE != "S")
                    {
                        //1번째 방법
                        helper.Rollback();
                        ShowDialog(helper.RSMSG);
                        return;
                        ////2번째 방법
                        //throw new Exception(helper.RSMSG);
                    }

                }

                //ClosePrgForm();
                helper.Commit();
                ShowDialog("정상적으로 등록 하였습니다.");
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
