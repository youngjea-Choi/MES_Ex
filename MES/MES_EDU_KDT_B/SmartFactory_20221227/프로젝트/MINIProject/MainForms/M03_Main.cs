﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Assamble;

//스래드(Thread)를 사용하기 위한 라이브러리 참조
using System.Threading;

//Form_List 클래스 라이버르리 참조
using Form_List;
using System.IO;
using System.Reflection;

namespace MainForms
{
    public partial class M03_Main : Form
    {
        // 메인화면 클래스 내부에서 시작 및 종료를 할 수 있도록 하기 위하여 클래스 내부의 필드 멤버로 스레드 객체 그릇 명명.
        private Thread thNowTime;

        public M03_Main()
        {
            ////로그인 창 실행
            //M01_Login M01 = new M01_Login();
            //M01.ShowDialog();

            ////로그인 성공 여부를 받아서 MAIN 화면 띄우는거 결정
            //if (!Convert.ToBoolean(M01.Tag))
            //{
            //    //로그인 실패시 메인창 종료

            //    //현재 클래스 종료
            //    //객체의 생성자 멤버에서 Close()실행 시 정상 종료 할 수 없음.
            //    //this.Close();

            //    //Application 클래스를 사용하여 프로세스의 강제 종료 처리.
            //    //현 시점에서 어플리케이션 강제 종료.
            //    Environment.Exit(0);
            //}
            // 폼에 있는 컨트롤 디자인을 초기화 하여 구성함.
            InitializeComponent();

            // 타이머 도구 기능 중지
            timer1.Enabled = false;

        }

        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    //문자의 서식 지정하여 연재 시간 표시.

        //    stsNowDateTime.Text = string.Format("{0 : yyyy-MM-dd HH:mm:ss}", DateTime.Now);

        //}

        private void M03_Main_Load(object sender, EventArgs e)
        {
            // 메인 화면 폼이 오픈 되는 시점.

            /* 신규 스레드를 통한 시간 체크
             스레드(Thread) : 프로세스 내부에서 생성되는 실제 작업의 주체를 추가 생성함으로서 하나의 프로세스(Main) 외에 여러가지 일을
                              동시에 수행 하는 기능.
                              메인 프로세스와는 별개로 개별적인 리소스(컴퓨터 메모리)를 가지고 구동하는 비동기식, 병렬식*/

            // 스레드를 이용한 현재 시간 표시 기능 구현
            // 1. 스레드가 실행 할 메서드를 포함할 클래스 객체. (ThreadStart)
            ThreadStart Threads = new ThreadStart(NowTimeSet);

            // 2. 스레드 클래스 생성 후 실행 메서드 포함되어 있는 클래스 첨부
            thNowTime = new Thread(Threads);

            // 3. 스레드를 시작
            thNowTime.Start();

            // 로그인한 아이디 상태창에 표시
            stsUserName.Text = Common.sUserName;
        }

        private void NowTimeSet()
        {
            //스레드가 실행 할 메서드
            //현재 시각 표현 로직 구현.

            //무한 루프를 통한 현재 시각 표현
            //int iBreakTime = 0;
            while (true)
            {
                Thread.Sleep(1000);
                //iBreakTime++;
                stsNowDateTime.Text = string.Format("{0 : yyyy-MM-dd HH:mm:ss}", DateTime.Now);

                //if (iBreakTime == 5)
                //{
                //    //MessageBox.Show("5초가 되어 무한루프를 종료");
                //    break;
                //}
            }
            //MessageBox.Show("5초가 되어 스레드 로직을 종료 합니다.");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // 시스템 종료 버튼 클릭
            // 종료 버튼을 눌러 프로그램을 종료 할때 스레드를 정상완료하지 않으면 응용 프로그램이 완벽히 종료 되지 않는다.
            //Environment.Exit(0);

            //종료 이벤트를 통해 스레드 등 관련 프로세스를 리소스에서 제거 후 안전하게 종료 할 수 있다.
            Application.Exit(); // -> 종료 이벤트를 실행함 FormClosing 이벤트

        }

        private void M03_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 창의 X 버튼 클릭 또는 alt +F4 기능 실행, 종료 버튼 클릭 했을 때 실행 이벤트.

            // 프로그램 종료 여부를 확인 하거나 실행되고 있는 스레드를 안전하게 삭제 후 종료 할 수 있다.

            // 1. 프로그램 종료 확인 메세지.
            if (MessageBox.Show("프로그램을 종료 하시겠습니까?", "프로그램 종료", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                //프로그램 종료 취소
                e.Cancel = true;
            }

            // 2. 구동되고 있는 스레드가 있다면 종료..
            if (thNowTime.IsAlive) //thNowTime 스레드가 돌아가고 있다면
            {
                //***** Abort - 프로세스의 종료를 구현 할 수 있는 대표적인 키워드)
                //Dispose()
                thNowTime.Abort();
            }

        }

        private void M_TEST_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            #region <이벤트 방법>
            //메뉴 리스트의 아이템(메뉴)를 클릭하였을때 이벤트

            // 1. CS 파일을 직접 호출
            //Form01_MDITest MDITest = new Form01_MDITest();
            //MDITest.Show();

            // MDI 로 하위 화면(자식 창)을 상위 폼(부모 창) 안에서 활서와 시키기.
            // MDI : Multiple Document Interface의 약자로 한개의 창에서 여러가지 작업을 할 수 있는 인터페이스를 뜻한다.

            // 2. MDI를 이용하여 화면 호출

            //Form01_MDITest Form01 = new Form01_MDITest();
            ////MDI 부모 창 Form과 연결
            //Form01.MdiParent = this;
            //Form01.Show();

            //// 3. 어셈블리( = 클래스 라이브러리, namespace, 프로젝트, DLL파일)
            //// Form_List 프로젝트를 호출(DLL)
            //// Application.StartupPath : 메인 프로그램이 시작되는 파일의 위치 - DLL 파일의 위치(Debug폴더)
            //Assembly assembly = Assembly.LoadFrom($"{Application.StartupPath}\\Form_List.DLL");
            //// 클릭한 메뉴의 cs 파일 타입 확인
            //Type typeForm = assembly.GetType($"Form_List.{e.ClickedItem.Name}", true);

            ////Form 형식으로 전환
            //Form FormMdi = (Form)Activator.CreateInstance(typeForm);
            ////종속관계 연결
            //FormMdi.MdiParent = this;

            ////화면 오픈
            //FormMdi.Show();


            //// 4. 탭 컨트롤(MyTabControl)의 탭 페이지에 메뉴선택한 클래스 화며 등록 및 활성화
            ////Form_List.DLL 호출
            //Assembly assembly = Assembly.LoadFrom($"{Application.StartupPath}\\Form_List.DLL");

            ////클릭한 메뉴의 CS 파일 타입 확인
            //Type typeForm = assembly.GetType($"Form_List.{e.ClickedItem.Name}");

            ////Form 형식으로 전환
            //Form FormMdi = (Form)Activator.CreateInstance(typeForm);

            ////탭 페이지에 폼을 추가하여 오픈한다.
            //myTabControl1.AddForm(FormMdi);

            #endregion

            // 5. 이미 활성화 되어있는 페이지의 메뉴 클릭 시 해당 화면 활성화
            //    활성화 되어있지 않은 메뉴 선택시 신규 탭 추가
            //Form_List.DLL 호출
            Assembly assembly = Assembly.LoadFrom($"{Application.StartupPath}\\Form_List.DLL");

            //클릭한 메뉴의 CS 파일 타입 확인
            Type typeForm = assembly.GetType($"Form_List.{e.ClickedItem.Name}");

            // Form 형식으로 전환
            Form FormMdi = (Form)Activator.CreateInstance(typeForm);

            // 해당되는 폼이 이미 오픈 되어있는지 확인 후 활성화 또는 신규 오픈.
            bool check = false;

            //for (int i = 0; i < myTabControl1.TabPages.Count; i++)
            //{
            //    //클릭한 메뉴의 이름으로 오픈되어있는 페이지가 있다면
            //    if(myTabControl1.TabPages[i].Name == e.ClickedItem.Name)
            //    {
            //        check = true;
            //        // 열린 탭을 활성화 하자
            //        //myTabControl1.SelectedIndex = i;
            //        myTabControl1.SelectedTab = myTabControl1.TabPages[i];
            //        break;
            //    }
            //}

            foreach (TabPage page in myTabControl1.TabPages)
            {
                if (page.Name == e.ClickedItem.Name)
                {
                    check = true;
                    myTabControl1.SelectedTab = page;
                    break;
                }
            }

            if (!check) myTabControl1.AddForm(FormMdi);

            //상태창 FormName 세팅.
            //stsFormName.Text = e.ClickedItem.Name;
            myTabControl1_Click(null, null);


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //오픈 되어 있는 페이지가 없을 경우 닫기 버튼 클릭 이벤트 종료
            if (myTabControl1.TabPages.Count == 0) return;
            // 닫기 버튼 클릭 시 활성화 되어 있는 페이지 닫기
            myTabControl1.SelectedTab.Dispose();

        
            myTabControl1_Click(null, null);

        }

        #region < 툴바의 기능 연계 >

        private void btnFunctionClick(object sender, EventArgs e)
        {
            ToolStripButton tsFunction = (ToolStripButton)sender;
            DoFunction(tsFunction.Text);
            
        }



        void DoFunction(string sStatus)
        {
            //오픈 되어 있는 페이지가 없을 경우 return
            if(myTabControl1.TabPages.Count == 0) return;

            // 현재 활성화 된 화면의 조회 / 추가 / 삭제 / 저장 기능을 수행하는 메서드

            #region < AS 와 IS >

            /*  
                캐스팅 : 상속받은 부모 클래스로 형 변환이 가능할 경우 형 변환을 명시적으로 실행하는 기능.
                    - AS : 대상으로부터 상속받은 클래스이면, 형 변환은 수행하고, 그렇지 않으면 NULL값을 대입하는 연산자
                    - IS : 대상으로부터 상속 받았는지 여부를 bool 형식으로 결과값만 반환.
             */

            //myTabControl1.SelectedTab.Controls[0] : 페이지에 추가된 컨트롤 중 최상위 컨트롤, 즉 baseForm 그자체
            //myTabControl1.SelectedTab.Controls[0]dl BaseChildForm을 상속받았는지 확인
            //형변환이 가능한지 확인...
            //if (myTabControl1.SelectedTab.Controls[0] is BaseChildForm == false) return;
            //BaseChildForm Child = (BaseChildForm)myTabControl1.SelectedTab.Controls[0];

            BaseChildForm Child = myTabControl1.SelectedTab.Controls[0] as BaseChildForm;
            if (Child == null) return;

        
            #endregion

            if (sStatus == "조회") Child.DoInquire();
            else if (sStatus == "추가") Child.DoNew();
            else if (sStatus == "삭제") Child.DoDelete();
            else if (sStatus == "저장") Child.DoSave();
        }

        #endregion

        private void myTabControl1_Click(object sender, EventArgs e)
        {
            if (myTabControl1.TabPages.Count == 0)
            {
                stsFormName.Text = "";
                return;
            }
            stsFormName.Text = myTabControl1.SelectedTab.Name;
        }
    }
}
