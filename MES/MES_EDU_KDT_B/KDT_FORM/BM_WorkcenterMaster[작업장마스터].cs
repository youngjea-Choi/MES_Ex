﻿#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM_WorkcenterMaster
//   Form Name    : 작업장 마스터
//   Name Space   : KDT_Form
//   Created Date : 2023-01-02
//   Made By      : 최영재
//   Description  : 기준정보(작업장마스터) 관리 화면
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
    public partial class BM_WorkcenterMaster : DC00_WinForm.BaseMDIChildForm
    {
        #region< MEMBER AREA >
        UltraGridUtil GridUtil = new UltraGridUtil(); //그리드를 셋팅하는 클래스

        public BM_WorkcenterMaster()
        {
            InitializeComponent();
        }

        #endregion

        #region < EVENT AREA >
        private void BM_WorkcenterMaster_Load(object sender, EventArgs e)
        {
            // 1. 그리드 셋팅
           
            GridUtil.InitializeGrid(grid1); //그리드 초기화
            GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE",       "공장",           GridColDataType_emu.VarChar,    100, HAlign.Left,  true, true);
            GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE",  "작업장",         GridColDataType_emu.VarChar,    100, HAlign.Left,  true, true);
            GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME",  "작업장명",       GridColDataType_emu.VarChar,    130, HAlign.Left,  true, true);
            GridUtil.InitColumnUltraGrid(grid1, "BANCODE",         "작업반",         GridColDataType_emu.VarChar,    100, HAlign.Left,  true, true);
            GridUtil.InitColumnUltraGrid(grid1, "ATSTFLAG",        "무사유사용여부", GridColDataType_emu.VarChar,    100, HAlign.Left,  true, true);
            GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERGUBUN", "사용처",         GridColDataType_emu.VarChar,    100, HAlign.Left,  true, true);
            GridUtil.InitColumnUltraGrid(grid1, "STDMANCNT",       "기준인원",       GridColDataType_emu.Integer,    100, HAlign.Right, true, true);
            GridUtil.InitColumnUltraGrid(grid1, "DOWNTIMECOST",    "비가동금액",     GridColDataType_emu.Integer,    100, HAlign.Right, true, true);
            GridUtil.InitColumnUltraGrid(grid1, "MOLDUSE",         "금형사용여부",   GridColDataType_emu.VarChar,    100, HAlign.Left,  true, true);
            GridUtil.InitColumnUltraGrid(grid1, "USEFLAG",         "사용여부",       GridColDataType_emu.VarChar,    100, HAlign.Left,  true, true);
                                                                                                                                        
            GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE",        "등록일시",       GridColDataType_emu.DateTime24, 150, HAlign.Left,  true, false);
            GridUtil.InitColumnUltraGrid(grid1, "MAKER",           "등록자",         GridColDataType_emu.VarChar,    100, HAlign.Left,  true, false);
            GridUtil.InitColumnUltraGrid(grid1, "EDITDATE",        "수정일시",       GridColDataType_emu.DateTime24, 150, HAlign.Left,  true, false);
            GridUtil.InitColumnUltraGrid(grid1, "EDITOR",          "수정자",         GridColDataType_emu.VarChar,    100, HAlign.Left,  true, false);
            GridUtil.SetInitUltraGridBind(grid1); //그리드 데이터 바인딩 초기화

            // 2. 콤보박스 셋팅.
            Common _Common = new Common(); //Common 클래스 객체 생성
            DataTable dtTemp = new DataTable(); // 콤보박스 셋팅 할 데이터를 받아올 자료형.

            //공장
            dtTemp = Common.StandardCODE("PLANTCODE");                   // 공통기준정보 PLANTCODE 데이터 가져오기.
            Common.FillComboboxMaster(cboPlantCode, dtTemp);             // 콤보박스 컨트롤에 셋팅
            UltraGridUtil.SetComboUltraGrid(grid1, "PLANTCODE", dtTemp); // 그리드에 콤보박스 세팅

            //작업반
            dtTemp = Common.StandardCODE("BANCODE");                  
            Common.FillComboboxMaster(cboDeptCode, dtTemp);  
            UltraGridUtil.SetComboUltraGrid(grid1, "BANCODE", dtTemp);

            //사용여부
            dtTemp = Common.StandardCODE("USEFLAG");                   
            Common.FillComboboxMaster(cboUseFlag, dtTemp); 
            UltraGridUtil.SetComboUltraGrid(grid1, "USEFLAG",  dtTemp); // 사용여부 
            UltraGridUtil.SetComboUltraGrid(grid1, "ATSTFLAG", dtTemp);// 무사유여부
            UltraGridUtil.SetComboUltraGrid(grid1, "MOLDUSE",  dtTemp); // 금형여부

            //사용처
            dtTemp = Common.StandardCODE("WORKCENTERGUBUN");
            UltraGridUtil.SetComboUltraGrid(grid1, "WORKCENTERGUBUN", dtTemp); // 사용처 
        }
        #endregion

        #region < TOOLBAR AREA >
        public override void DoNew()
        {
            //신규행 추가
            grid1.InsertRow();

            //기본값 세팅
            grid1.SetDefaultValue("PLANTCODE", LoginInfo.PlantCode);
            grid1.SetDefaultValue("USEFLAG",   "Y"); // 사용여부
            grid1.SetDefaultValue("ATSTFLAG",  "N"); // 비가동여부
            grid1.SetDefaultValue("MOLDUSE",   "N"); // 금형사용여부

        }

        public override void DoDelete()
        {
            grid1.DeleteRow();
        }

        public override void DoInquire()
        {
            base.DoInquire();

            //트랜잭션을 사용하지 않을 helper
            DBHelper helper = new DBHelper(false);
            try
            {
                // 조회조건 변수 등록 및 데이터 대입
                string sPlantCode = Convert.ToString(cboPlantCode.Value); // 공장
                string sWorkcenterCode = txtWorkcenterCode.Text;          // 작업장 코드
                string sWorkcenterName = txtWorkcenterName.Text;          // 작업장 명
                string sBanCode = Convert.ToString(cboDeptCode.Value);    // 반 코드
                string sUseFlag = Convert.ToString(cboUseFlag.Value);     // 사용여부

                DataTable dtTemp = new DataTable();
                dtTemp = helper.FillTable("06BM_Workcenter_S1", CommandType.StoredProcedure
                                           , helper.CreateParameter("PLANTCODE",      sPlantCode)
                                           , helper.CreateParameter("WORKCENTERCODE", sWorkcenterCode)
                                           , helper.CreateParameter("WORKCENTERNAME", sWorkcenterName)
                                           , helper.CreateParameter("BANCODE",        sBanCode)
                                           , helper.CreateParameter("USEFLAG",        sUseFlag)
                                           );
                
               if(dtTemp.Rows.Count == 0 ) 
               {
                    ShowDialog("조회할 내역이 없습니다.");
                    GridUtil.Grid_Clear(grid1);
                    return;
               }
               grid1.DataSource= dtTemp;
               
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

      

        public override void DoSave()
        {
            base.DoSave();

            DataTable dtTemp = grid1.chkChange();

            if(dtTemp == null)
            {
                ShowDialog("저장할 행이 없습니다.");
                return;
            }

            DBHelper helper = new DBHelper(true); // 트랜잭션 사용 DB 커넥터

            try
            {
                foreach(DataRow dr in dtTemp.Rows) 
                {
                   

                    switch(dr.RowState)
                    {
                        case DataRowState.Deleted:
                            dr.RejectChanges(); // 삭제된 데이터 원삭복귀

                            helper.ExecuteNoneQuery("06BM_Workcenter_D1", CommandType.StoredProcedure,
                                                    helper.CreateParameter("@PLANTCODE", Convert.ToString(dr["PLANTCODE"])),
                                                    helper.CreateParameter("@WORKCENTERCODE", Convert.ToString(dr["WORKCENTERCODE"]))
                                                    );
                            break;
                        case DataRowState.Added:
                            //숫자 형 데이터 입력 여부 확인
                            int iSTDMANCNT = 0;
                            int iDOWNTIMECOST = 0;
                            int.TryParse(Convert.ToString(dr["STDMANCNT"]), out iSTDMANCNT);
                            int.TryParse(Convert.ToString(dr["DOWNTIMECOST"]), out iDOWNTIMECOST);

                            helper.ExecuteNoneQuery("06BM_Workcenter_I1", CommandType.StoredProcedure,
                                                   helper.CreateParameter("@PLANTCODE",       Convert.ToString(dr["PLANTCODE"])),
                                                   helper.CreateParameter("@WORKCENTERCODE",  Convert.ToString(dr["WORKCENTERCODE"])),
                                                   helper.CreateParameter("@WORKCENTERNAME",  Convert.ToString(dr["WORKCENTERNAME"])),
                                                   helper.CreateParameter("@BANCODE",         Convert.ToString(dr["BANCODE"])),
                                                   helper.CreateParameter("@ATSTFLAG",        Convert.ToString(dr["ATSTFLAG"])),
                                                   helper.CreateParameter("@WORKCENTERGUBUN", Convert.ToString(dr["WORKCENTERGUBUN"])),
                                                   helper.CreateParameter("@STDMANCNT",       iSTDMANCNT),
                                                   helper.CreateParameter("@DOWNTIMECOST",    iDOWNTIMECOST),
                                                   helper.CreateParameter("@MOLDUSE",         Convert.ToString(dr["MOLDUSE"])),
                                                   helper.CreateParameter("@USEFLAG",         Convert.ToString(dr["USEFLAG"])),
                                                   helper.CreateParameter("@MAKER",           LoginInfo.UserID)
                                                   );
                            break;
                        case DataRowState.Modified:
                            //숫자 형 데이터 입력 여부 확인
                            iSTDMANCNT = 0;
                            iDOWNTIMECOST = 0;
                            int.TryParse(Convert.ToString(dr["STDMANCNT"]), out iSTDMANCNT);
                            int.TryParse(Convert.ToString(dr["DOWNTIMECOST"]), out iDOWNTIMECOST);

                            helper.ExecuteNoneQuery("06BM_Workcenter_U1", CommandType.StoredProcedure,
                                                   helper.CreateParameter("@PLANTCODE",       Convert.ToString(dr["PLANTCODE"])),
                                                   helper.CreateParameter("@WORKCENTERCODE",  Convert.ToString(dr["WORKCENTERCODE"])),
                                                   helper.CreateParameter("@WORKCENTERNAME",  Convert.ToString(dr["WORKCENTERNAME"])),
                                                   helper.CreateParameter("@BANCODE",         Convert.ToString(dr["BANCODE"])),
                                                   helper.CreateParameter("@ATSTFLAG",        Convert.ToString(dr["ATSTFLAG"])),
                                                   helper.CreateParameter("@WORKCENTERGUBUN", Convert.ToString(dr["WORKCENTERGUBUN"])),
                                                   helper.CreateParameter("@STDMANCNT",       iSTDMANCNT),
                                                   helper.CreateParameter("@DOWNTIMECOST",    iDOWNTIMECOST),
                                                   helper.CreateParameter("@MOLDUSE",         Convert.ToString(dr["MOLDUSE"])),
                                                   helper.CreateParameter("@USEFLAG",         Convert.ToString(dr["USEFLAG"])),
                                                   helper.CreateParameter("@EDITOR",          LoginInfo.UserID)
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
