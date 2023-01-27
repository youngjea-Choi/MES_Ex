#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PP_ActureOutput
//   Form Name    : 자재 재고 현황
//   Name Space   : KDT_Form
//   Created Date : 2023-01-04
//   Made By      : 최영재
//   Description  : 최초 프로그램 생성
// *---------------------------------------------------------------------------------------------*
#endregion

using DC_POPUP;
using DC00_assm;
using DC00_PuMan;
using DC00_WinForm;
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
    public partial class PP_ActureOutput : DC00_WinForm.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        UltraGridUtil GridUtil = new UltraGridUtil(); //그리드를 셋팅하는 클래스
        public PP_ActureOutput()
        {
            InitializeComponent();
        }
        #endregion

        #region < EVENT AREA >

        private void PP_ActureOutput_Load(object sender, EventArgs e)
        {
            // 1. 그리드 셋팅

           GridUtil.InitializeGrid(grid1); //그리드 초기화
            GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE",       "공장",         GridColDataType_emu.VarChar,    100, HAlign.Left,   false, false);
            GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE",  "작업장",       GridColDataType_emu.VarChar,    100, HAlign.Left,   false, false);
            GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME",  "작업장명",     GridColDataType_emu.VarChar,    150, HAlign.Left,    true, false);
            GridUtil.InitColumnUltraGrid(grid1, "ORDERNO",         "작업지시",     GridColDataType_emu.VarChar,    200, HAlign.Left,    true, false);
            GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE",        "생산품목",     GridColDataType_emu.VarChar,    200, HAlign.Left,    true, false);
            GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME",        "생산품명",     GridColDataType_emu.VarChar,    200, HAlign.Left,    true, false);
            GridUtil.InitColumnUltraGrid(grid1, "ORDERQTY",        "지시수량",     GridColDataType_emu.Double,     120, HAlign.Right,   true, false);
            GridUtil.InitColumnUltraGrid(grid1, "PRODQTY",         "양품수량",     GridColDataType_emu.Double,     120, HAlign.Right,   true, false);
            GridUtil.InitColumnUltraGrid(grid1, "BADQTY",          "불량수량",     GridColDataType_emu.Double,     120, HAlign.Right,   true, false);
            GridUtil.InitColumnUltraGrid(grid1, "UNITCODE",        "단위",         GridColDataType_emu.VarChar,    100, HAlign.Left,    true, false);
            GridUtil.InitColumnUltraGrid(grid1, "WORKSTATUSCODE",  "R/S코드",      GridColDataType_emu.VarChar,    100, HAlign.Left,   false, false);
            GridUtil.InitColumnUltraGrid(grid1, "WORKSTATUS",      "상태",         GridColDataType_emu.VarChar,    100, HAlign.Left,    true, false);

            GridUtil.InitColumnUltraGrid(grid1, "MATLOTNO",        "투입LOT",      GridColDataType_emu.VarChar,    300, HAlign.Left,    true, false);
            GridUtil.InitColumnUltraGrid(grid1, "COMPONENTQTY",    "투입잔량",     GridColDataType_emu.Double,     100, HAlign.Right,   true, false);
            GridUtil.InitColumnUltraGrid(grid1, "WORKER",          "작업자코드",   GridColDataType_emu.VarChar,    100, HAlign.Left,    true, false);
            GridUtil.InitColumnUltraGrid(grid1, "WORKERNAME",      "작업자명",     GridColDataType_emu.VarChar,    100, HAlign.Left,    true, false);
            GridUtil.InitColumnUltraGrid(grid1, "ORDSTARTDATE",    "지시시작일자", GridColDataType_emu.DateTime24, 400, HAlign.Left,    true, false);



            GridUtil.SetInitUltraGridBind(grid1); //그리드 데이터 바인딩 초기화

            // 2. 콤보박스 셋팅. - 사업장, 단위 , 작업장
            DataTable dtTemp = new DataTable(); // 콤보박스 셋팅 할 데이터를 받아올 자료형.

            //공장
            dtTemp = Common.StandardCODE("PLANTCODE");
            Common.FillComboboxMaster(cboPlantCode, dtTemp);
            UltraGridUtil.SetComboUltraGrid(grid1, "PLANTCODE", dtTemp); // 그리드에 콤보박스 세팅

            //단위
            dtTemp = Common.StandardCODE("UNITCODE");
            UltraGridUtil.SetComboUltraGrid(grid1, "UNITCODE", dtTemp);

            // 작업장
            dtTemp = Common.GET_Workcenter_Code();
            Common.FillComboboxMaster (this.cboWorkcenter, dtTemp);


            //작업자 팝업 호출
            BizTextBoxManager btbManger = new BizTextBoxManager();
            btbManger.PopUpAdd(txtWorkerID, txtWorkerName, "WORKER_MASTER");

        }
        #endregion

        #region < TOOLBAR AREA >

        public override void DoInquire()
        {
            //base.DoInquire();
            //트랜잭션을 사용하지 않을 helper
            DBHelper helper = new DBHelper(false);
            try
            {
                // 조회조건 변수 등록 및 데이터 대입
                string sPlantCode      = Convert.ToString(cboPlantCode.Value);
                string sWorkcenterCode = Convert.ToString(cboWorkcenter.Value);
 

                DataTable dtTemp = new DataTable();
                dtTemp = helper.FillTable("06PP_ActureOutput_S1", CommandType.StoredProcedure
                                           , helper.CreateParameter("@PLANTCODE", sPlantCode)
                                           , helper.CreateParameter("@WORKCENTERCODE", sWorkcenterCode)
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
            grid1.SetDefaultValue("PODATE", string.Format("{0:yyyy-MM-dd}", DateTime.Now)); // 오늘일자
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

                            helper.ExecuteNoneQuery("06PP_ActureOutput_D1", CommandType.StoredProcedure,
                                                    helper.CreateParameter("@PLANTCODE", Convert.ToString(dr["PLANTCODE"])),
                                                    helper.CreateParameter("@PLANNO", Convert.ToString(dr["PLANNO"]))
                                                    );
                            break;

                        //구매자재 발주 등록
                        case DataRowState.Added:
                            if (Convert.ToString(dr["ITEMCODE"]) == "") sMessage = "발주품목 ";
                            if (Convert.ToString(dr["CUSTCODE"]) == "") sMessage += "거래처 ";
                            if (Convert.ToString(dr["PODATE"]) == "") sMessage += "발주일자 ";
                            if (Convert.ToString(dr["POQTY"]) == "") sMessage += "발주수량 ";

                            if (sMessage != "") throw new Exception(sMessage + "을(를) 입력하지 않았습니다.");

                            helper.ExecuteNoneQuery("06PP_ActureOutput_I1", CommandType.StoredProcedure,
                                                   helper.CreateParameter("@PLANTCODE", Convert.ToString(dr["PLANTCODE"])),
                                                   helper.CreateParameter("@ITEMCODE", Convert.ToString(dr["ITEMCODE"])),
                                                   helper.CreateParameter("@POQTY", Convert.ToString(dr["POQTY"])),
                                                   helper.CreateParameter("@UNITCODE", Convert.ToString(dr["UNITCODE"])),
                                                   helper.CreateParameter("@CUSTCODE", Convert.ToString(dr["CUSTCODE"])),
                                                   helper.CreateParameter("@PODATE", Convert.ToString(dr["PODATE"])),
                                                   helper.CreateParameter("@MAKER", LoginInfo.UserID)
                                                   );
                            break;


                        //발주 내역으로 입고 등록
                        case DataRowState.Modified:

                            if (Convert.ToString(dr["INQTY"]) == "") throw new Exception("입고수량을 입력하지 않았습니다.");

                            helper.ExecuteNoneQuery("06PP_ActureOutput_U1", CommandType.StoredProcedure,
                                                   helper.CreateParameter("@PLANTCODE", Convert.ToString(dr["PLANTCODE"])),
                                                   helper.CreateParameter("@PONO", Convert.ToString(dr["PONO"])),
                                                   helper.CreateParameter("@INQTY", Convert.ToString(dr["INQTY"])),
                                                   helper.CreateParameter("@ITEMCODE", Convert.ToString(dr["ITEMCODE"])),
                                                   helper.CreateParameter("@EDITOR", LoginInfo.UserID)
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

        

       
        private void cboWorkcenter_ValueChanged(object sender, EventArgs e)
        {
            DoDelete();
        }


        #endregion


        #region <2. 작업자 등록>

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            // 작업장을 선택 하였는지 확인.
            if (grid1.ActiveRow == null) return;
            // 조회딘 작업장이 없을경우 리턴
            if (grid1.Rows.Count == 0) return;


            // 등록 할 작업자를 조회 하였는지 확인.
            string sWorkerId = txtWorkerID.Text;
            if (sWorkerId == "")
            {
                ShowDialog("작업자를 선택 후 진행 하세요.");
                return;

            }

            DBHelper helper = new DBHelper();
            try
            {
                string sWorkcentercode = Convert.ToString(grid1.ActiveRow.Cells["WORKCENTERCODE"].Value);
                string sPlantCode = Convert.ToString(grid1.ActiveRow.Cells["PLANTCODE"].Value);


                   helper.ExecuteNoneQuery("06PP_ActureOutput_I1", CommandType.StoredProcedure
                                           , helper.CreateParameter("@PLANTCODE", sPlantCode)
                                           , helper.CreateParameter("@WORKCENTERCODE", sWorkcentercode)
                                           , helper.CreateParameter("@WORKERID", sWorkerId)
                                           );
                if (helper.RSCODE != "S") throw new Exception(helper.RSMSG);
                helper.Commit();
                ShowDialog("작업자 등록을 완료 하였습니다.");

            }
            catch(Exception ex)
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

        private void grid1_AfterRowActivate(object sender, EventArgs e)
        {
            //작업자 세팅
            txtWorkerID.Text = Convert.ToString(grid1.ActiveRow.Cells["WORKER"].Value);
            txtWorkerName.Text = Convert.ToString(grid1.ActiveRow.Cells["WORKERNAME"].Value);

            //LOT 투입 내역 조회 및 투입/투입취소 버튼으로 변경
            string sLotNo = Convert.ToString(grid1.ActiveRow.Cells["MATLOTNO"].Value);
            if(sLotNo == "")
            {
                btnLOTIn.Text = "(4) LOT 투입";
                txtINLotNo.Text = "";
            }
            else
            {
                btnLOTIn.Text = "(4) LOT 투입취소";
                txtINLotNo.Text = sLotNo;

               

            }

            // 가동 / 비가동 상태 체크
            string sRunStop = Convert.ToString(grid1.ActiveRow.Cells["WORKSTATUSCODE"].Value);
            if (sRunStop == "R") btnRunStop.Text = "(5)비가동";
            else btnRunStop.Text = "(5)가동";
           

        }


        #region <3. 작업지시 선택>
        private void btnOrderNo_Click(object sender, EventArgs e)
        {
            // 작업장을 선택하지 않았거나 작업지시 등록 대상 작업장이 그리드에 조회 되지 않았을 경우 return
            if (grid1.ActiveRow == null) return;
            if (grid1.Rows.Count == 0) return;

            // 작업자 등록 여부 확인
            string sWorkerId = Convert.ToString(grid1.ActiveRow.Cells["WORKER"].Value);
            if (sWorkerId == "")
            {
                ShowDialog("작업자를 선택 후 진행 하세요.");
                return;

            }

            if (Convert.ToString(grid1.ActiveRow.Cells["WORKSTATUSCODE"].Value) == "R")
            {
                ShowDialog("현재 작업장이 가동 상태 입니다. \r\n 비가동 등록 후 진행하세요");
                return;

            }

            if (Convert.ToString(grid1.ActiveRow.Cells["MATLOTNO"].Value) != "")
            {
                ShowDialog("작업장에 투입된 원자재 LOT 의 정보가 존재 합니다. \r\n 투입을 취소 후 진행하세요.");
                return;

            }

            string sWorkcenterCode = Convert.ToString(grid1.ActiveRow.Cells["WORKCENTERCODE"].Value);
            string sWorkcenterName = Convert.ToString(grid1.ActiveRow.Cells["WORKCENTERNAME"].Value);


            POP_ORDERNO OrderPopup = new POP_ORDERNO(sWorkcenterCode, sWorkcenterName);
            OrderPopup.ShowDialog();

            string dOrderNo = Convert.ToString(OrderPopup.Tag);

            if (dOrderNo == "") return;

            // 선택한 작업지시 등록 로직 구현

            DBHelper helper = new DBHelper(true);

                
            try
            {
                string sWorkcentercode = Convert.ToString(grid1.ActiveRow.Cells["WORKCENTERCODE"].Value);
                string sPlantCode = Convert.ToString(grid1.ActiveRow.Cells["PLANTCODE"].Value);


                helper.ExecuteNoneQuery("06PP_ActureOutput_I2", CommandType.StoredProcedure
                                        ,helper.CreateParameter("@PLANTCODE", sPlantCode)
                                        ,helper.CreateParameter("@WORKCENTERCODE", sWorkcentercode)
                                        ,helper.CreateParameter("@WORKERID", sWorkerId)
                                        ,helper.CreateParameter("@ORDERNO", dOrderNo)
                                        );
                if (helper.RSCODE != "S") throw new Exception(helper.RSMSG);
                helper.Commit();
                ShowDialog("작업자 등록을 완료 하였습니다.");
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

        #region <4. LOT 투입 >

        private void btnLOTIn_Click(object sender, EventArgs e)
        {
            if (grid1.ActiveRow == null) return;

            DBHelper helper = new DBHelper(true);
            try
            {
                string sOrderNo = Convert.ToString(grid1.ActiveRow.Cells["ORDERNO"].Value);
                if (sOrderNo == "")
                {
                    ShowDialog("등록된 작업지시가 없습니다. \r\n 작업지시 등록 후 진행하세요.");
                    return;
                }

                string sWorkerId = Convert.ToString(grid1.ActiveRow.Cells["WORKER"].Value);
                if (sWorkerId == "")
                {
                    ShowDialog("등록된 작업자가 없습니다. \r\n 작업자 등록 후 진행하세요.");
                    return;
                }

                string sInCancleFlag = "IN"; // LOT 투입/취소 여부
                if (btnLOTIn.Text != "(4) LOT 투입") sInCancleFlag = "OUT";

                string sItemCode = Convert.ToString(grid1.ActiveRow.Cells["ITEMCODE"].Value);
                string sPlantCode = Convert.ToString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
                string sWorkcenterCode = Convert.ToString(grid1.ActiveRow.Cells["WORKCENTERCODE"].Value);
                string sUnitCode = Convert.ToString(grid1.ActiveRow.Cells["UNITCODE"].Value);
                string sLoTNo = txtINLotNo.Text;



                helper.ExecuteNoneQuery("06PP_ActureOutput_I3", CommandType.StoredProcedure
                                            , helper.CreateParameter("@PLANTCODE", sPlantCode)
                                            , helper.CreateParameter("@WORKCENTERCODE", sWorkcenterCode)
                                            , helper.CreateParameter("@ORDERNO", sOrderNo)
                                            , helper.CreateParameter("@WORKERID", sWorkerId)
                                            , helper.CreateParameter("@LOTNO", sLoTNo)
                                            , helper.CreateParameter("@ITEMCODE", sItemCode)
                                            , helper.CreateParameter("@UNITCODE", sUnitCode)
                                            , helper.CreateParameter("@INCANCLEFLAG", sInCancleFlag)
                                            );

                if (helper.RSCODE == "E")
                {
                    this.ShowDialog(helper.RSMSG, DialogForm.DialogType.OK);
                    helper.Rollback();
                    return;
                }

                helper.Commit();
                ShowDialog("LOT 투입/취소 등록을 완료하였습니다.");
                DoInquire();

                helper.Commit();

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


        #region <5. 가동/비가동>

        private void btnRunStop_Click(object sender, EventArgs e)
        {
            // 작업장의 가동/ 비가동 상태를 등록 함.

            if (grid1.Rows.Count == 0) return;
            if (grid1.ActiveRow == null) return;

            string sOrderNo = Convert.ToString(grid1.ActiveRow.Cells["ORDERNO"].Value);
            if (sOrderNo == "")
            {
                ShowDialog("작업지시를 선택하지 않았습니다. 작업지시 선택 후 진행하세요");
                return;

            }

            string sOrderId = Convert.ToString(grid1.ActiveRow.Cells["WORKER"].Value);
            if (WorkerID == "")
            {
                ShowDialog("작업자를 선택하지 않았습니다. 작업자 선택 후 진행하세요");
                return;
            }


            string sRunStop = "S";
            if (btnRunStop.Text == "(5)가동") sRunStop = "R";

            string sItemCode = Convert.ToString(grid1.ActiveRow.Cells["ITEMCODE"].Value);
            string sWOrkcenterCode = Convert.ToString(grid1.ActiveRow.Cells["WORKCENTERCODE"].Value);
            string sPLantCode = Convert.ToString(grid1.ActiveRow.Cells["PLANTCODE"].Value);


            DBHelper helper = new DBHelper(true);
            try
            {
                helper.ExecuteNoneQuery("06PP_ActureOutput_I4", CommandType.StoredProcedure,
                                         helper.CreateParameter("@PLANTCODE",             sPLantCode),
                                         helper.CreateParameter("@WORKCENTERCODE", sWOrkcenterCode),
                                         helper.CreateParameter("@ORDERNO",                 sOrderNo),
                                         helper.CreateParameter("@ITEMCODE",               sItemCode),
                                         helper.CreateParameter("@STATUS",                  sRunStop)
                                         );

                if (helper.RSCODE != "S") throw new Exception("등록 실패하였습니다.");

                helper.Commit();
                ShowDialog("정상적으로 등록 되었습니다");
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

        #region   <6. 생산실적 등록> 
        private void btnProdReg_Click(object sender, EventArgs e)
        {

            // 생산 실적 을 등록함
            if (grid1.Rows.Count == 0) return;
            if (grid1.ActiveRow == null) return;

            double dProdQty   = 0;  // 누적 양품 수량
            double dErrorQty  = 0;  // 누적 불량 수량
            double dTRrodQty  = 0;  // 입력 양품 수량
            double dTErrorQty = 0;  // 입력 불량 수량
            double dOrderQty  = 0;  // 작업 지시 수량

            // 누적 양품 수량
            string sProdQty = Convert.ToString(grid1.ActiveRow.Cells["PRODQTY"].Value).Replace(",", ""); //3자리마다 , 제거
            double.TryParse(sProdQty, out dProdQty);

            //누적 불량 수량
            string sErrorQty = Convert.ToString(grid1.ActiveRow.Cells["BADQTY"].Value).Replace(",", ""); //3자리마다 , 제거
            double.TryParse(sErrorQty, out dErrorQty);

            //입력 양품 수량
            string sTRrodQty = Convert.ToString(txtProdQty.Text).Replace(",", "");
            double.TryParse(sTRrodQty, out dTRrodQty);

            //입력 불량 수량
            string sTErrorQty = Convert.ToString(txtBadQty.Text).Replace(",", "");
            double.TryParse(sTErrorQty, out dTErrorQty);

            //지시 수량
            string sOrderQty = Convert.ToString(grid1.ActiveRow.Cells["ORDERQTY"].Value).Replace(",", ""); //3자리마다 , 제거
            double.TryParse(sOrderQty, out dOrderQty);


            // 실적 수량을 입력 하였는지 체크
            if (dTRrodQty + dTErrorQty == 0)
            {
                ShowDialog("실적 수량을 입력하지 않았습니다.확인후 진행하세요.");
                return;


            }

            // 누적 양품수량 + 입력 양품수량 의 합과 작업지시 수량의 체크
            if (dProdQty + dTErrorQty > dOrderQty )
            {
                ShowDialog("총 생산 수량이 작업지시 수량보다 많습니다.");
                return;
            }




            string sOrderNo = Convert.ToString(grid1.ActiveRow.Cells["ORDERNO"].Value);
            if (sOrderNo == "")
            {
                ShowDialog("작업지시를 선택하지 않았습니다. 작업지시 선택 후 진행하세요");
                return;

            }

            string sOrderId = Convert.ToString(grid1.ActiveRow.Cells["WORKER"].Value);
            if (WorkerID == "")
            {
                ShowDialog("작업자를 선택하지 않았습니다. 작업자 선택 후 진행하세요");
                return;
            }


            string sItemCode       = Convert.ToString(grid1.ActiveRow.Cells["ITEMCODE"].Value);
            string sWOrkcenterCode = Convert.ToString(grid1.ActiveRow.Cells["WORKCENTERCODE"].Value);
            string sPLantCode      = Convert.ToString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
            string sUnitCode       = Convert.ToString(grid1.ActiveRow.Cells["UNITCODE"].Value);
            string sMatLotNo       = Convert.ToString(grid1.ActiveRow.Cells["MATLOTNO"].Value);

            DBHelper helper = new DBHelper(true);
            try
            {
                helper.ExecuteNoneQuery("06PP_ActureOutput_I5", CommandType.StoredProcedure,
                                         helper.CreateParameter("@PLANTCODE",            sPLantCode),
                                         helper.CreateParameter("@WORKCENTERCODE",  sWOrkcenterCode),
                                         helper.CreateParameter("@ORDERNO",                sOrderNo),
                                         helper.CreateParameter("@ITEMCODE",              sItemCode),
                                         helper.CreateParameter("@UNITCODE",              sUnitCode),
                                         helper.CreateParameter("@PRODQTY",                dTRrodQty),
                                         helper.CreateParameter("@BADQTY",               dTErrorQty),
                                         helper.CreateParameter("@MATLOTNO",              sMatLotNo)
                                         );

                if (helper.RSCODE != "S") throw new Exception("등록 실패하였습니다.");

                helper.Commit();
                ShowDialog("정상적으로 등록 되었습니다");
                DoInquire();


                //제품 식별표에 출력 및 제품 LOT  별 데이터 조회
                DataTable dtTemp = helper.FillTable("06PP_ActureOutput_S2", CommandType.StoredProcedure
                                      , helper.CreateParameter("@PLANTCODE", sPLantCode)
                                      , helper.CreateParameter("@LOTNO", helper.RSMSG)
                                      );



                Report_LotBacodeROH ROH = new Report_LotBacodeROH();

            


                Telerik.Reporting.ReportBook Book = new Telerik.Reporting.ReportBook();

                Book.Reports.Add(ROH);

                ReportViewer Viewer = new ReportViewer(Book, 1);
                Viewer.ShowDialog();



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


        #region < 7. 작업지시 종료>
        private void btnOrderClose_Click(object sender, EventArgs e)
        {
            if (grid1.ActiveRow == null)
            if (grid1.Rows.Count == 0)
            return;

            string sMatLotNo = Convert.ToString(grid1.ActiveRow.Cells["MATLOTNO"].Value);
            string sRunStop = Convert.ToString(grid1.ActiveRow.Cells["WORKSTATUSCODE"].Value);

            if (sMatLotNo != "")
            {
                ShowDialog("투입 LOT가 존재 합니다. LOT 투입 취소 후 진행하세요.");
                return;
            }

            if (sRunStop == "R")
            {
                ShowDialog("작업장이 가동 상태입니다. 비가동 등록 후 진행하세요.");
                return;
            }

            DBHelper helper = new DBHelper(true);

            try
            {
                string sPlantCode        = Convert.ToString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
                string sWorkcenterCode   = Convert.ToString(grid1.ActiveRow.Cells["WORKCENTERCODE"].Value);
                string sOrderNo          = Convert.ToString(grid1.ActiveRow.Cells["ORDERNO"].Value);


                helper.ExecuteNoneQuery("06PP_ActureOutput_I6", CommandType.StoredProcedure,
                                        helper.CreateParameter("@PLANTCODE", sPlantCode),
                                        helper.CreateParameter("@WORKCENTERCODE", sWorkcenterCode),
                                        helper.CreateParameter("@ORDERNO", sOrderNo)
                                        );



                if (helper.RSCODE != "S") throw new Exception(helper.RSMSG);
                helper.Commit();
                ShowDialog("작업지시가 종료되었습니다.");
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
