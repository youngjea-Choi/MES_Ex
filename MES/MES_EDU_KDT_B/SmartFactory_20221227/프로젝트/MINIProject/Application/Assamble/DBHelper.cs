﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//SQL SERVER에 접속할 수 있게 도와주는 API
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Assamble
{
    /*----------------------------------------------------------------------------
     * 데이터 베이스 접속 및 트랜잭션을 관리 할 수 있게 도와주는 DBHelper Class
     -----------------------------------------------------------------------------*/
    public  class DBHelper
    {

        public SqlConnection sCon;
        public SqlCommand cmd;
        public SqlTransaction sTran;
        public SqlDataAdapter adapter;
     
        public DBHelper()
        {
            sCon = new SqlConnection(Common.sConn);
            // 데이터베이스 오픈.
            sCon.Open();
        }

        public void Close()
        {
            //데이터 베이스 종료
            sCon.Close();
        }
        /// <summary>
        /// 저장프로시져 세팅 메서드
        /// </summary>
        /// <param name="SP_Name">저장프로시저 이름</param>
        public void SetSelectSP(String SP_Name)
        {
            try
            {
                adapter = new SqlDataAdapter(SP_Name, sCon);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                //기본적으로 모든 프로시져에 적용될 내용.
                adapter.SelectCommand.Parameters.AddWithValue("@LANG", "KO");
                adapter.SelectCommand.Parameters.AddWithValue("@RS_CODE", "").Direction = ParameterDirection.Output;
                adapter.SelectCommand.Parameters.AddWithValue("@RS_MSG", "").Direction = ParameterDirection.Output;
            }
            catch(Exception ex) 
            {
                Close();
                MessageBox.Show("조회에 실패했습니다." + ex.ToString());

            }
          

        }

        /// <summary>
        ///  저장프로시져 파라미터 세팅 메서드
        /// </summary>
        /// <param name="variableName">파라미터명</param>
        /// <param name="value">파라미터값</param>
        public void SetSelectSP_Param(string variableName, string value)
        {
            adapter.SelectCommand.Parameters.AddWithValue(variableName, value);
        }

        public void SelectSP_Run(DataTable dtTemp)
        {
            try
            {
                adapter.Fill(dtTemp);
            }
            catch(Exception ex)
            {
                MessageBox.Show("조회에 실패했습니다." + ex.ToString());
            }
            finally
            {
                Close();
            }
          
           
        }

        public void SelectSql(string sql, DataTable dtTemp)
        {
            adapter = new SqlDataAdapter(sql, sCon);

            adapter.Fill(dtTemp);
            
        }

        public void SetChangeSP(string SP_Name)
        {
            cmd = new SqlCommand();
            sTran = sCon.BeginTransaction();
            // 4. 트랜잭션 커맨드에 연결
            cmd.Transaction = sTran;
            // 5. 커맨드에 접속 정보 연결
            cmd.Connection = sCon;

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = SP_Name;
          

            cmd.Parameters.AddWithValue("@LANG", "KO");
            cmd.Parameters.AddWithValue("@RS_CODE", "").Direction = ParameterDirection.Output;
            cmd.Parameters.AddWithValue("@RS_MSG", "").Direction = ParameterDirection.Output;
        }
        
        public void SetChangeSP_Param(string variableName, string value)
        {
            cmd.Parameters.AddWithValue(variableName, value);
          
        }

        public void ChangeSP_Run()
        {
           
             cmd.ExecuteNonQuery();
            
              
        }
    }
}
