namespace NewGame
{
    partial class OpeningScreenCtr
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.EasyStartBottun = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // EasyStartBottun
            // 
            this.EasyStartBottun.Font = new System.Drawing.Font("MS UI Gothic", 20F);
            this.EasyStartBottun.Location = new System.Drawing.Point(63, 127);
            this.EasyStartBottun.Name = "EasyStartBottun";
            this.EasyStartBottun.Size = new System.Drawing.Size(217, 56);
            this.EasyStartBottun.TabIndex = 0;
            this.EasyStartBottun.Text = "Game Start";
            this.EasyStartBottun.UseVisualStyleBackColor = true;
            this.EasyStartBottun.Click += new System.EventHandler(this.EasyStartBottun_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("MS UI Gothic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button2.Location = new System.Drawing.Point(63, 325);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(217, 51);
            this.button2.TabIndex = 3;
            this.button2.Text = "Quit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("装甲明朝", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(229, 438);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(689, 83);
            this.label1.TabIndex = 4;
            this.label1.Text = "AvoidAvoidAvoid";
            // 
            // OpeningScreenCtr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.EasyStartBottun);
            this.Name = "OpeningScreenCtr";
            this.Size = new System.Drawing.Size(921, 521);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button EasyStartBottun;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
    }
}
