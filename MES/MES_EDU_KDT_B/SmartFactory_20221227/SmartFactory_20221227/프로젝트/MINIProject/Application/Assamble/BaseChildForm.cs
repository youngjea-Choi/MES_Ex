﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assamble
{
    public partial class BaseChildForm : Form, IChildCommds
    {
        // Interface 형식인 IChildCommds에 있는 멤버(필드, 매서드)는 반드시 구현되어야 한다.
        // BaseChildForm 클래스가 IChildCommds를 상속 받았기 때문이다.

        // BaseChildForm
        // Interface를 상속 받아 필수로 구현해야 하는 메서드의 기능을 모두 정의(구현)하고
        // 툴바의 기능과 연계하여 시스템 개발에 사용되는 기본 Form 양식을 제공한다.
        public BaseChildForm()
        {
            InitializeComponent();
        }

        // virtual 
        //  - 상속 받은 클래스에서 해당 매서드를 재정의 할 수 있도록 허용

        // abstract
        //  - 상속 받은 클래스에서 해당 매서드를 재 정의 할 수 있도록 허용하나 반드시 해당 매서드의 재정의 기능이 구현 되어 있어야 한다.
        public virtual void DoDelete()
        {
            MessageBox.Show("DoDelete");
        }


        public virtual void DoInquire()
        {
            MessageBox.Show("조회를 시작합니다.");
        }

        public virtual void DoNew()
        {
            
        }

        public virtual void DoSave()
        {
        
        }
    }
}
