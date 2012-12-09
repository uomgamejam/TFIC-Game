namespace KilburnEscape
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.imgScene = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.imgScene)).BeginInit();
			this.SuspendLayout();
			// 
			// imgScene
			// 
			this.imgScene.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.imgScene.Location = new System.Drawing.Point(12, 12);
			this.imgScene.Name = "imgScene";
			this.imgScene.Size = new System.Drawing.Size(506, 348);
			this.imgScene.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.imgScene.TabIndex = 0;
			this.imgScene.TabStop = false;
			this.imgScene.MouseUp += new System.Windows.Forms.MouseEventHandler(this.imgScene_MouseUp);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(530, 372);
			this.Controls.Add(this.imgScene);
			this.Name = "MainForm";
			this.Text = "Kilburn Escape";
			((System.ComponentModel.ISupportInitialize)(this.imgScene)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox imgScene;
	}
}

