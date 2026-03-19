using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EchoMessenger
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            SendMessage();
        }

        private void txtStr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // 엔터 눌렀을 때 엔터 입력(벨 등)을 막고 전송 처리
                e.SuppressKeyPress = true;
                SendMessage();
            }
        }

        private void SendMessage()
        {
            // 앞뒤 공백 제거해서 본문만 검사
            string typed_msg = txtStr.Text.Trim();

            // 비어 있거나 공백만 있는 경우 전송하지 않음
            if (string.IsNullOrEmpty(typed_msg))
            {
                txtStr.Clear();
                txtStr.Focus();
                return;
            }

            // 정상 메시지 추가 후 입력창 비우기 및 포커스 유지
            lstMsg.Items.Add(typed_msg);
            txtStr.Clear();
            txtStr.Focus();
        }
    }
}
