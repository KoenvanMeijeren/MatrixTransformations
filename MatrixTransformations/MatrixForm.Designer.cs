namespace MatrixTransformations
{
    partial class MatrixForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            const int LabelWidth = 50, LabelHeigt = 20;
            SuspendLayout();

            // 
            // Control labels
            // 
            scaleText = new Label();
            scaleText.AutoSize = true;
            scaleText.Location = new Point(1, 0);
            scaleText.Name = "scaleText";
            scaleText.Size = new Size(LabelWidth, LabelHeigt);
            scaleText.TabIndex = 0;
            scaleText.Text = "Scale";
            Controls.Add(scaleText);
            
            scaleValue = new Label();
            scaleValue.AutoSize = true;
            scaleValue.Location = new Point(90, 0);
            scaleValue.Name = "scaleValue";
            scaleValue.Size = new Size(LabelWidth, LabelHeigt);
            scaleValue.TabIndex = 1;
            scaleValue.Text = "0";
            Controls.Add(scaleValue);
            
            scaleControls = new Label();
            scaleControls.AutoSize = true;
            scaleControls.Location = new Point(140, 0);
            scaleControls.Name = "scaleControls";
            scaleControls.Size = new Size(LabelWidth, LabelHeigt);
            scaleControls.TabIndex = 2;
            scaleControls.Text = "s/S";
            Controls.Add(scaleControls);

            translateXText = new Label();
            translateXText.AutoSize = true;
            translateXText.Location = new Point(1, LabelHeigt * 1);
            translateXText.Name = "translateXText";
            translateXText.Size = new Size(LabelWidth, LabelHeigt);
            translateXText.TabIndex = 0;
            translateXText.Text = "Translate X";
            Controls.Add(translateXText);
            
            translateXValue = new Label();
            translateXValue.AutoSize = true;
            translateXValue.Location = new Point(90, LabelHeigt * 1);
            translateXValue.Name = "translateXValue";
            translateXValue.Size = new Size(LabelWidth, LabelHeigt);
            translateXValue.TabIndex = 1;
            translateXValue.Text = "0.0";
            Controls.Add(translateXValue);
            
            translateXControls = new Label();
            translateXControls.AutoSize = true;
            translateXControls.Location = new Point(140, LabelHeigt * 1);
            translateXControls.Name = "translateXControls";
            translateXControls.Size = new Size(LabelWidth, LabelHeigt);
            translateXControls.TabIndex = 2;
            translateXControls.Text = "Left/Right";
            Controls.Add(translateXControls);
            
            translateYText = new Label();
            translateYText.AutoSize = true;
            translateYText.Location = new Point(1, LabelHeigt * 2);
            translateYText.Name = "translateYText";
            translateYText.Size = new Size(LabelWidth, LabelHeigt);
            translateYText.TabIndex = 0;
            translateYText.Text = "Translate Y";
            Controls.Add(translateYText);
            
            translateYValue = new Label();
            translateYValue.AutoSize = true;
            translateYValue.Location = new Point(90, LabelHeigt * 2);
            translateYValue.Name = "translateYValue";
            translateYValue.Size = new Size(LabelWidth, LabelHeigt);
            translateYValue.TabIndex = 1;
            translateYValue.Text = "0.0";
            Controls.Add(translateYValue);
            
            translateYControls = new Label();
            translateYControls.AutoSize = true;
            translateYControls.Location = new Point(140, LabelHeigt * 2);
            translateYControls.Name = "translateYControls";
            translateYControls.Size = new Size(LabelWidth, LabelHeigt);
            translateYControls.TabIndex = 2;
            translateYControls.Text = "Up/Down";
            Controls.Add(translateYControls);
            
            translateZText = new Label();
            translateZText.AutoSize = true;
            translateZText.Location = new Point(1, LabelHeigt * 3);
            translateZText.Name = "translateZText";
            translateZText.Size = new Size(LabelWidth, LabelHeigt);
            translateZText.TabIndex = 0;
            translateZText.Text = "Translate Z";
            Controls.Add(translateZText);
            
            translateZValue = new Label();
            translateZValue.AutoSize = true;
            translateZValue.Location = new Point(90, LabelHeigt * 3);
            translateZValue.Name = "translateZValue";
            translateZValue.Size = new Size(LabelWidth, LabelHeigt);
            translateZValue.TabIndex = 1;
            translateZValue.Text = "0.0";
            Controls.Add(translateZValue);
            
            translateZControls = new Label();
            translateZControls.AutoSize = true;
            translateZControls.Location = new Point(140, LabelHeigt * 3);
            translateZControls.Name = "translateZControls";
            translateZControls.Size = new Size(LabelWidth, LabelHeigt);
            translateZControls.TabIndex = 2;
            translateZControls.Text = "PgUp/PgDn";
            Controls.Add(translateZControls);
            
            rotateXText = new Label();
            rotateXText.AutoSize = true;
            rotateXText.Location = new Point(1, LabelHeigt * 4);
            rotateXText.Name = "rotateXText";
            rotateXText.Size = new Size(LabelWidth, LabelHeigt);
            rotateXText.TabIndex = 0;
            rotateXText.Text = "Rotate X";
            Controls.Add(rotateXText);
            
            rotateXValue = new Label();
            rotateXValue.AutoSize = true;
            rotateXValue.Location = new Point(90, LabelHeigt * 4);
            rotateXValue.Name = "rotateXValue";
            rotateXValue.Size = new Size(LabelWidth, LabelHeigt);
            rotateXValue.TabIndex = 1;
            rotateXValue.Text = "0";
            Controls.Add(rotateXValue);
            
            rotateXControls = new Label();
            rotateXControls.AutoSize = true;
            rotateXControls.Location = new Point(140, LabelHeigt * 4);
            rotateXControls.Name = "rotateXControls";
            rotateXControls.Size = new Size(LabelWidth, LabelHeigt);
            rotateXControls.TabIndex = 2;
            rotateXControls.Text = "x/X";
            Controls.Add(rotateXControls);
            
            rotateYText = new Label();
            rotateYText.AutoSize = true;
            rotateYText.Location = new Point(1, LabelHeigt * 5);
            rotateYText.Name = "rotateYText";
            rotateYText.Size = new Size(LabelWidth, LabelHeigt);
            rotateYText.TabIndex = 0;
            rotateYText.Text = "Rotate Y";
            Controls.Add(rotateYText);
            
            rotateYValue = new Label();
            rotateYValue.AutoSize = true;
            rotateYValue.Location = new Point(90, LabelHeigt * 5);
            rotateYValue.Name = "rotateYValue";
            rotateYValue.Size = new Size(LabelWidth, LabelHeigt);
            rotateYValue.TabIndex = 1;
            rotateYValue.Text = "0";
            Controls.Add(rotateYValue);
            
            rotateYControls = new Label();
            rotateYControls.AutoSize = true;
            rotateYControls.Location = new Point(140, LabelHeigt * 5);
            rotateYControls.Name = "rotateYControls";
            rotateYControls.Size = new Size(LabelWidth, LabelHeigt);
            rotateYControls.TabIndex = 2;
            rotateYControls.Text = "y/Y";
            Controls.Add(rotateYControls);
            
            rotateZText = new Label();
            rotateZText.AutoSize = true;
            rotateZText.Location = new Point(1, LabelHeigt * 6);
            rotateZText.Name = "rotateZText";
            rotateZText.Size = new Size(LabelWidth, LabelHeigt);
            rotateZText.TabIndex = 0;
            rotateZText.Text = "Rotate Z";
            Controls.Add(rotateZText);
            
            rotateZValue = new Label();
            rotateZValue.AutoSize = true;
            rotateZValue.Location = new Point(90, LabelHeigt * 6);
            rotateZValue.Name = "rotateZValue";
            rotateZValue.Size = new Size(LabelWidth, LabelHeigt);
            rotateZValue.TabIndex = 1;
            rotateZValue.Text = "0";
            Controls.Add(rotateZValue);
            
            rotateZControls = new Label();
            rotateZControls.AutoSize = true;
            rotateZControls.Location = new Point(140, LabelHeigt * 6);
            rotateZControls.Name = "rotateZControls";
            rotateZControls.Size = new Size(LabelWidth, LabelHeigt);
            rotateZControls.TabIndex = 2;
            rotateZControls.Text = "z/Z";
            Controls.Add(rotateZControls);
            
            radiansText = new Label();
            radiansText.AutoSize = true;
            radiansText.Location = new Point(1, LabelHeigt * 7 + 10);
            radiansText.Name = "radiansText";
            radiansText.Size = new Size(LabelWidth, LabelHeigt);
            radiansText.TabIndex = 0;
            radiansText.Text = "Radians";
            Controls.Add(radiansText);
            
            radiansValue = new Label();
            radiansValue.AutoSize = true;
            radiansValue.Location = new Point(90, LabelHeigt * 7 + 10);
            radiansValue.Name = "radiansValue";
            radiansValue.Size = new Size(LabelWidth, LabelHeigt);
            radiansValue.TabIndex = 1;
            radiansValue.Text = "0";
            Controls.Add(radiansValue);
            
            radiansControls = new Label();
            radiansControls.AutoSize = true;
            radiansControls.Location = new Point(140, LabelHeigt * 7 + 10);
            radiansControls.Name = "radiansControls";
            radiansControls.Size = new Size(LabelWidth, LabelHeigt);
            radiansControls.TabIndex = 2;
            radiansControls.Text = "r/R";
            Controls.Add(radiansControls);
            
            distanceText = new Label();
            distanceText.AutoSize = true;
            distanceText.Location = new Point(1, LabelHeigt * 8 + 10);
            distanceText.Name = "distanceText";
            distanceText.Size = new Size(LabelWidth, LabelHeigt);
            distanceText.TabIndex = 0;
            distanceText.Text = "Distance";
            Controls.Add(distanceText);
            
            distanceValue = new Label();
            distanceValue.AutoSize = true;
            distanceValue.Location = new Point(90, LabelHeigt * 8 + 10);
            distanceValue.Name = "distanceValue";
            distanceValue.Size = new Size(LabelWidth, LabelHeigt);
            distanceValue.TabIndex = 1;
            distanceValue.Text = "0";
            Controls.Add(distanceValue);
            
            distanceControls = new Label();
            distanceControls.AutoSize = true;
            distanceControls.Location = new Point(140, LabelHeigt * 8 + 10);
            distanceControls.Name = "distanceControls";
            distanceControls.Size = new Size(LabelWidth, LabelHeigt);
            distanceControls.TabIndex = 2;
            distanceControls.Text = "d/D";
            Controls.Add(distanceControls);
            
            phiText = new Label();
            phiText.AutoSize = true;
            phiText.Location = new Point(1, LabelHeigt * 9 + 10);
            phiText.Name = "phiText";
            phiText.Size = new Size(LabelWidth, LabelHeigt);
            phiText.TabIndex = 0;
            phiText.Text = "Phi";
            Controls.Add(phiText);
            
            phiValue = new Label();
            phiValue.AutoSize = true;
            phiValue.Location = new Point(90, LabelHeigt * 9 + 10);
            phiValue.Name = "phiValue";
            phiValue.Size = new Size(LabelWidth, LabelHeigt);
            phiValue.TabIndex = 1;
            phiValue.Text = "0";
            Controls.Add(phiValue);
            
            phiControls = new Label();
            phiControls.AutoSize = true;
            phiControls.Location = new Point(140, LabelHeigt * 9 + 10);
            phiControls.Name = "phiControls";
            phiControls.Size = new Size(LabelWidth, LabelHeigt);
            phiControls.TabIndex = 2;
            phiControls.Text = "p/P";
            Controls.Add(phiControls);
            
            thetaText = new Label();
            thetaText.AutoSize = true;
            thetaText.Location = new Point(1, LabelHeigt * 10 + 10);
            thetaText.Name = "thetaText";
            thetaText.Size = new Size(LabelWidth, LabelHeigt);
            thetaText.TabIndex = 0;
            thetaText.Text = "Theta";
            Controls.Add(thetaText);
            
            thetaValue = new Label();
            thetaValue.AutoSize = true;
            thetaValue.Location = new Point(90, LabelHeigt * 10 + 10);
            thetaValue.Name = "thetaValue";
            thetaValue.Size = new Size(LabelWidth, LabelHeigt);
            thetaValue.TabIndex = 1;
            thetaValue.Text = "0";
            Controls.Add(thetaValue);
            
            thetaControls = new Label();
            thetaControls.AutoSize = true;
            thetaControls.Location = new Point(140, LabelHeigt * 10 + 10);
            thetaControls.Name = "thetaControls";
            thetaControls.Size = new Size(LabelWidth, LabelHeigt);
            thetaControls.TabIndex = 2;
            thetaControls.Text = "t/T";
            Controls.Add(thetaControls);
            
            phaseText = new Label();
            phaseText.AutoSize = true;
            phaseText.Location = new Point(1, LabelHeigt * 12);
            phaseText.Name = "phaseText";
            phaseText.Size = new Size(LabelWidth, LabelHeigt);
            phaseText.TabIndex = 0;
            phaseText.Text = "Phase";
            Controls.Add(phaseText);
            
            phaseValue = new Label();
            phaseValue.AutoSize = true;
            phaseValue.Location = new Point(90, LabelHeigt * 12);
            phaseValue.Name = "phaseValue";
            phaseValue.Size = new Size(LabelWidth, LabelHeigt);
            phaseValue.TabIndex = 1;
            phaseValue.Text = "0";
            Controls.Add(phaseValue);

            resetText = new Label();
            resetText.AutoSize = true;
            resetText.Location = new Point(1, LabelHeigt * 13);
            resetText.Name = "resetText";
            resetText.Size = new Size(LabelWidth, LabelHeigt);
            resetText.TabIndex = 0;
            resetText.Text = "Reset";
            Controls.Add(resetText);

            resetControls = new Label();
            resetControls.AutoSize = true;
            resetControls.Location = new Point(90, LabelHeigt * 13);
            resetControls.Name = "resetControls";
            resetControls.Size = new Size(LabelWidth, LabelHeigt);
            resetControls.TabIndex = 2;
            resetControls.Text = "C";
            Controls.Add(resetControls);
            
            // 
            // MatrixForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MatrixForm";
            Text = "Form";
            KeyDown += Form_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label scaleText, scaleValue, scaleControls;
        private Label translateXText, translateXValue, translateXControls;
        private Label translateYText, translateYValue, translateYControls;
        private Label translateZText, translateZValue, translateZControls;
        private Label rotateXText, rotateXValue, rotateXControls;
        private Label rotateYText, rotateYValue, rotateYControls;
        private Label rotateZText, rotateZValue, rotateZControls;
        private Label radiansText, radiansValue, radiansControls;
        private Label distanceText, distanceValue, distanceControls;
        private Label phiText, phiValue, phiControls;
        private Label thetaText, thetaValue, thetaControls;
        private Label phaseText, phaseValue;
        private Label resetText, resetControls;
    }
}
