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
            this.SuspendLayout();
            // 
            // EasyStartBottun
            // 
            this.EasyStartBottun.Font = new System.Drawing.Font("MS UI Gothic", 20F);
            this.EasyStartBottun.Location = new System.Drawing.Point(42, 34);
            this.EasyStartBottun.Name = "EasyStartBottun";
            this.EasyStartBottun.Size = new System.Drawing.Size(217, 56);
            this.EasyStartBottun.TabIndex = 0;
            this.EasyStartBottun.Text = "Easy Start";
            this.EasyStartBottun.UseVisualStyleBackColor = true;
            this.EasyStartBottun.Click += new System.EventHandler(this.EasyStartBottun_Click);
            // 
            // OpeningScreenCtr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.EasyStartBottun);
            this.Name = "OpeningScreenCtr";
            this.Size = new System.Drawing.Size(921, 521);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button EasyStartBottun;
    }
}
