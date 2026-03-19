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

            // 초기 메시지 개수 표시 및 입력 포커스
            UpdateMessageCount();
            txtStr.Focus();
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
                // Enter의 기본 동작(벨 등) 방지 후 전송 처리
                e.SuppressKeyPress = true;
                SendMessage();
            }
        }

        private void SendMessage()
        {
            // 앞뒤 공백 제거
            string typed_msg = txtStr.Text.Trim();

            // 빈 문자열 또는 공백만 있으면 전송하지 않음
            if (string.IsNullOrEmpty(typed_msg))
            {
                txtStr.Clear();
                txtStr.Focus();
                return;
            }

            // 타임스탬프 추가 [HH:mm:ss]
            string timeStamp = DateTime.Now.ToString("HH:mm:ss");
            string displayMsg = $"[{timeStamp}] {typed_msg}";

            // 리스트에 추가 및 자동 스크롤
            lstMsg.Items.Add(displayMsg);
            if (lstMsg.Items.Count > 0)
            {
                lstMsg.TopIndex = lstMsg.Items.Count - 1;
            }

            // 입력창 초기화 및 포커스 유지
            txtStr.Clear();
            txtStr.Focus();

            // 카운트 갱신
            UpdateMessageCount();
        }

        private void UpdateMessageCount()
        {
            lblCount.Text = $"현재 대화: {lstMsg.Items.Count}개";
        }
    }
}
