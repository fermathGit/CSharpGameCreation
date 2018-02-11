namespace GameLoop {
    partial class Form1 {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose( bool disposing ) {
            if ( disposing && ( components != null ) ) {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this._openGlControl = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.SuspendLayout();
            // 
            // simpleOpenGlControl1
            // 
            this._openGlControl.AccumBits = ((byte)(0));
            this._openGlControl.AutoCheckErrors = false;
            this._openGlControl.AutoFinish = false;
            this._openGlControl.AutoMakeCurrent = true;
            this._openGlControl.AutoSwapBuffers = true;
            this._openGlControl.BackColor = System.Drawing.Color.Black;
            this._openGlControl.ColorBits = ((byte)(32));
            this._openGlControl.DepthBits = ((byte)(16));
            this._openGlControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._openGlControl.Location = new System.Drawing.Point(0, 0);
            this._openGlControl.Name = "simpleOpenGlControl1";
            this._openGlControl.Size = new System.Drawing.Size(284, 262);
            this._openGlControl.StencilBits = ((byte)(0));
            this._openGlControl.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this._openGlControl);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Tao.Platform.Windows.SimpleOpenGlControl _openGlControl;
    }
}

