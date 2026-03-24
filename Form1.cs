using EchoMessenger;
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

            // UI 배치 조정 (겹침 및 글자 잘림 해결)
            AdjustBottomControlsLayout();

            // 초기 메시지 개수 표시 및 입력 포커스
            UpdateMessageCount();
            txtStr.Focus();
        }

        /// <summary>
        /// 하단 라벨과 버튼의 크기 및 위치를 동적으로 조정합니다.
        /// </summary>
        private void AdjustBottomControlsLayout()
        {
            // 1. 글자가 절대 안 잘리도록 너비(Width)를 160으로 크게 늘립니다.
            btnClearAll.AutoSize = false;
            btnClearAll.Size = new System.Drawing.Size(160, 35); // 가로 160, 세로 35

            // 2. 버튼의 위치를 왼쪽 아래 구석으로 배치
            int margin = 15;
            int buttonX = margin;
            int buttonY = this.ClientSize.Height - btnClearAll.Height - margin;
            btnClearAll.Location = new System.Drawing.Point(buttonX, buttonY);

            // 3. '현재 대화' 라벨이 버튼 위로 올라가게 배치 (여유 공간 8px)
            int labelX = margin;
            int labelY = btnClearAll.Location.Y - lblCount.Height - 8;
            lblCount.Location = new System.Drawing.Point(labelX, labelY);
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

            // 길이 제한(추가 안전 검사: 디자이너에 MaxLength를 설정했어도 Trim 후 길이 확인)
            if (typed_msg.Length > 50)
            {
                MessageBox.Show("메시지는 최대 50자까지 입력할 수 있습니다.", "입력 제한", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstMsg.SelectedIndex >= 0)
                {
                    lstMsg.Items.RemoveAt(lstMsg.SelectedIndex);
                    UpdateMessageCount();
                }
                else
                {
                    MessageBox.Show("삭제할 항목을 선택하세요.", "삭제 실패", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("삭제 중 오류가 발생했습니다: " + ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            if (lstMsg.Items.Count == 0)
            {
                MessageBox.Show("삭제할 대화 기록이 없습니다.", "정보", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show("대화 기록을 모두 삭제하시겠습니까?", "대화 기록 삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                lstMsg.Items.Clear();
                UpdateMessageCount();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

