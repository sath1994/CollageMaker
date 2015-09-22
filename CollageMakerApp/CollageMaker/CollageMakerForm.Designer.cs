namespace CollageMaker
{
    partial class CollageMakerForm
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
            if (disposing && (components != null))
            {
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
            this.SelectButton = new System.Windows.Forms.Button();
            this.GoButton = new System.Windows.Forms.Button();
            this.FirstStepLabel = new System.Windows.Forms.Label();
            this.SecondStepLabel = new System.Windows.Forms.Label();
            this.imageNameTextBox = new System.Windows.Forms.TextBox();
            this.ThirdStepLabel = new System.Windows.Forms.Label();
            this.PictureNameLabel = new System.Windows.Forms.Label();
            this.FirstStepInstructionLabel = new System.Windows.Forms.Label();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.MainPictureButton = new System.Windows.Forms.Button();
            this.FourthStepLabel = new System.Windows.Forms.Label();
            this.MainPictureLabel = new System.Windows.Forms.Label();
            this.StatusProgressBar = new System.Windows.Forms.ProgressBar();
            this.AmountOfPicsLabel = new System.Windows.Forms.Label();
            this.FifthStepLabel = new System.Windows.Forms.Label();
            this.AmountOfPicsTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // SelectButton
            // 
            this.SelectButton.Location = new System.Drawing.Point(57, 69);
            this.SelectButton.Name = "SelectButton";
            this.SelectButton.Size = new System.Drawing.Size(75, 23);
            this.SelectButton.TabIndex = 0;
            this.SelectButton.Text = "Select";
            this.SelectButton.UseVisualStyleBackColor = true;
            this.SelectButton.Click += new System.EventHandler(this.SelectButton_Click);
            // 
            // GoButton
            // 
            this.GoButton.Location = new System.Drawing.Point(57, 147);
            this.GoButton.Name = "GoButton";
            this.GoButton.Size = new System.Drawing.Size(75, 23);
            this.GoButton.TabIndex = 1;
            this.GoButton.Text = "Go";
            this.GoButton.UseVisualStyleBackColor = true;
            this.GoButton.Click += new System.EventHandler(this.GoButton_Click);
            // 
            // FirstStepLabel
            // 
            this.FirstStepLabel.AutoSize = true;
            this.FirstStepLabel.Location = new System.Drawing.Point(12, 38);
            this.FirstStepLabel.Name = "FirstStepLabel";
            this.FirstStepLabel.Size = new System.Drawing.Size(44, 13);
            this.FirstStepLabel.TabIndex = 2;
            this.FirstStepLabel.Text = "Step 1 -";
            // 
            // SecondStepLabel
            // 
            this.SecondStepLabel.AutoSize = true;
            this.SecondStepLabel.Location = new System.Drawing.Point(12, 74);
            this.SecondStepLabel.Name = "SecondStepLabel";
            this.SecondStepLabel.Size = new System.Drawing.Size(44, 13);
            this.SecondStepLabel.TabIndex = 3;
            this.SecondStepLabel.Text = "Step 2 -";
            // 
            // imageNameTextBox
            // 
            this.imageNameTextBox.Location = new System.Drawing.Point(148, 126);
            this.imageNameTextBox.Name = "imageNameTextBox";
            this.imageNameTextBox.Size = new System.Drawing.Size(275, 20);
            this.imageNameTextBox.TabIndex = 4;
            this.imageNameTextBox.Text = "Enter Image Name";
            // 
            // ThirdStepLabel
            // 
            this.ThirdStepLabel.AutoSize = true;
            this.ThirdStepLabel.Location = new System.Drawing.Point(12, 106);
            this.ThirdStepLabel.Name = "ThirdStepLabel";
            this.ThirdStepLabel.Size = new System.Drawing.Size(44, 13);
            this.ThirdStepLabel.TabIndex = 5;
            this.ThirdStepLabel.Text = "Step 3 -";
            // 
            // PictureNameLabel
            // 
            this.PictureNameLabel.AutoSize = true;
            this.PictureNameLabel.Location = new System.Drawing.Point(58, 129);
            this.PictureNameLabel.Name = "PictureNameLabel";
            this.PictureNameLabel.Size = new System.Drawing.Size(74, 13);
            this.PictureNameLabel.TabIndex = 6;
            this.PictureNameLabel.Text = "Picture Name:";
            // 
            // FirstStepInstructionLabel
            // 
            this.FirstStepInstructionLabel.AutoSize = true;
            this.FirstStepInstructionLabel.Location = new System.Drawing.Point(145, 74);
            this.FirstStepInstructionLabel.Name = "FirstStepInstructionLabel";
            this.FirstStepInstructionLabel.Size = new System.Drawing.Size(267, 13);
            this.FirstStepInstructionLabel.TabIndex = 7;
            this.FirstStepInstructionLabel.Text = "Select the pictures you would like to make a collage of.";
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(19, 206);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(0, 13);
            this.StatusLabel.TabIndex = 9;
            // 
            // MainPictureButton
            // 
            this.MainPictureButton.Location = new System.Drawing.Point(57, 33);
            this.MainPictureButton.Name = "MainPictureButton";
            this.MainPictureButton.Size = new System.Drawing.Size(75, 23);
            this.MainPictureButton.TabIndex = 10;
            this.MainPictureButton.Text = "Main Pic";
            this.MainPictureButton.UseVisualStyleBackColor = true;
            this.MainPictureButton.Click += new System.EventHandler(this.MainPictureButton_Click);
            // 
            // FourthStepLabel
            // 
            this.FourthStepLabel.AutoSize = true;
            this.FourthStepLabel.Location = new System.Drawing.Point(12, 129);
            this.FourthStepLabel.Name = "FourthStepLabel";
            this.FourthStepLabel.Size = new System.Drawing.Size(44, 13);
            this.FourthStepLabel.TabIndex = 11;
            this.FourthStepLabel.Text = "Step 4 -";
            // 
            // MainPictureLabel
            // 
            this.MainPictureLabel.AutoSize = true;
            this.MainPictureLabel.Location = new System.Drawing.Point(145, 33);
            this.MainPictureLabel.Name = "MainPictureLabel";
            this.MainPictureLabel.Size = new System.Drawing.Size(233, 26);
            this.MainPictureLabel.TabIndex = 12;
            this.MainPictureLabel.Text = "Select Main picture you want to use. \r\nSelect nothing if you choose to have no pi" +
    "cture.";
            // 
            // StatusProgressBar
            // 
            this.StatusProgressBar.Location = new System.Drawing.Point(12, 236);
            this.StatusProgressBar.Name = "StatusProgressBar";
            this.StatusProgressBar.Size = new System.Drawing.Size(427, 23);
            this.StatusProgressBar.TabIndex = 13;
            // 
            // AmountOfPicsLabel
            // 
            this.AmountOfPicsLabel.AutoSize = true;
            this.AmountOfPicsLabel.Location = new System.Drawing.Point(61, 105);
            this.AmountOfPicsLabel.Name = "AmountOfPicsLabel";
            this.AmountOfPicsLabel.Size = new System.Drawing.Size(164, 13);
            this.AmountOfPicsLabel.TabIndex = 14;
            this.AmountOfPicsLabel.Text = "Amount of pics to use for collage:";
            // 
            // FifthStepLabel
            // 
            this.FifthStepLabel.AutoSize = true;
            this.FifthStepLabel.Location = new System.Drawing.Point(12, 152);
            this.FifthStepLabel.Name = "FifthStepLabel";
            this.FifthStepLabel.Size = new System.Drawing.Size(44, 13);
            this.FifthStepLabel.TabIndex = 15;
            this.FifthStepLabel.Text = "Step 5 -";
            // 
            // AmountOfPicsTextBox
            // 
            this.AmountOfPicsTextBox.Location = new System.Drawing.Point(231, 98);
            this.AmountOfPicsTextBox.Name = "AmountOfPicsTextBox";
            this.AmountOfPicsTextBox.Size = new System.Drawing.Size(100, 20);
            this.AmountOfPicsTextBox.TabIndex = 16;
            this.AmountOfPicsTextBox.Text = "200";
            // 
            // CollageMakerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 261);
            this.Controls.Add(this.AmountOfPicsTextBox);
            this.Controls.Add(this.FifthStepLabel);
            this.Controls.Add(this.AmountOfPicsLabel);
            this.Controls.Add(this.StatusProgressBar);
            this.Controls.Add(this.MainPictureLabel);
            this.Controls.Add(this.FourthStepLabel);
            this.Controls.Add(this.MainPictureButton);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.FirstStepInstructionLabel);
            this.Controls.Add(this.PictureNameLabel);
            this.Controls.Add(this.ThirdStepLabel);
            this.Controls.Add(this.imageNameTextBox);
            this.Controls.Add(this.SecondStepLabel);
            this.Controls.Add(this.FirstStepLabel);
            this.Controls.Add(this.GoButton);
            this.Controls.Add(this.SelectButton);
            this.Name = "CollageMakerForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SelectButton;
        private System.Windows.Forms.Button GoButton;
        private System.Windows.Forms.Label FirstStepLabel;
        private System.Windows.Forms.Label SecondStepLabel;
        private System.Windows.Forms.TextBox imageNameTextBox;
        private System.Windows.Forms.Label ThirdStepLabel;
        private System.Windows.Forms.Label PictureNameLabel;
        private System.Windows.Forms.Label FirstStepInstructionLabel;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Button MainPictureButton;
        private System.Windows.Forms.Label FourthStepLabel;
        private System.Windows.Forms.Label MainPictureLabel;
        private System.Windows.Forms.ProgressBar StatusProgressBar;
        private System.Windows.Forms.Label AmountOfPicsLabel;
        private System.Windows.Forms.Label FifthStepLabel;
        private System.Windows.Forms.TextBox AmountOfPicsTextBox;
    }
}

