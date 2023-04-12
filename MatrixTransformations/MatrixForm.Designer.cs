using System.Drawing;
using System.Windows.Forms;

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
            const int LabelWidth = 50, LabelHeigth = 20, 
                TextColumn = 1, ValueColumn = 90, ControlsColumn = 140;
            SuspendLayout();

            // 
            // Control labels
            // 
            const int scaleRow = 0;
            scaleText = CreateLabel(LabelWidth, LabelHeigth, scaleRow, TextColumn, 0, "Scale");
            Controls.Add(scaleText);
            scaleValue = CreateLabel(LabelWidth, LabelHeigth, scaleRow, ValueColumn, 1, "0");
            Controls.Add(scaleValue);
            scaleControls = CreateLabel(LabelWidth, LabelHeigth, scaleRow, ControlsColumn, 1, "s/S");
            Controls.Add(scaleControls);

            const int translateXRow = 1;
            translateXText = CreateLabel(LabelWidth, LabelHeigth, translateXRow, TextColumn, 0, "Translate X");
            Controls.Add(translateXText);
            translateXValue = CreateLabel(LabelWidth, LabelHeigth, translateXRow, ValueColumn, 1, "0.0");
            Controls.Add(translateXValue);
            translateXControls = CreateLabel(LabelWidth, LabelHeigth, translateXRow, ControlsColumn, 1, "Left/Right");
            Controls.Add(translateXControls);
            
            const int translateYRow = 2;
            translateYText = CreateLabel(LabelWidth, LabelHeigth, translateYRow, TextColumn, 0, "Translate Y");
            Controls.Add(translateYText);
            translateYValue = CreateLabel(LabelWidth, LabelHeigth, translateYRow, ValueColumn, 1, "0.0");
            Controls.Add(translateYValue);
            translateYControls = CreateLabel(LabelWidth, LabelHeigth, translateYRow, ControlsColumn, 1, "Up/Down");
            Controls.Add(translateYControls);
            
            const int translateZRow = 3;
            translateZText = CreateLabel(LabelWidth, LabelHeigth, translateZRow, TextColumn, 0, "Translate Z");
            Controls.Add(translateZText);
            translateZValue = CreateLabel(LabelWidth, LabelHeigth, translateZRow, ValueColumn, 1, "0.0");
            Controls.Add(translateZValue);
            translateZControls = CreateLabel(LabelWidth, LabelHeigth, translateZRow, ControlsColumn, 1, "PgUp/PgDn");
            Controls.Add(translateZControls);
            
            const int rotateXRow = 4;
            rotateXText = CreateLabel(LabelWidth, LabelHeigth, rotateXRow, TextColumn, 0, "Rotate X");
            Controls.Add(rotateXText);
            rotateXValue = CreateLabel(LabelWidth, LabelHeigth, rotateXRow, ValueColumn, 1, "0");
            Controls.Add(rotateXValue);
            rotateXControls = CreateLabel(LabelWidth, LabelHeigth, rotateXRow, ControlsColumn, 1, "x/X");
            Controls.Add(rotateXControls);
            
            const int rotateYRow = 5;
            rotateYText = CreateLabel(LabelWidth, LabelHeigth, rotateYRow, TextColumn, 0, "Rotate Y");
            Controls.Add(rotateYText);
            rotateYValue = CreateLabel(LabelWidth, LabelHeigth, rotateYRow, ValueColumn, 1, "0");
            Controls.Add(rotateYValue);
            rotateYControls = CreateLabel(LabelWidth, LabelHeigth, rotateYRow, ControlsColumn, 1, "y/Y");
            Controls.Add(rotateYControls);
            
            const int rotateZRow = 6;
            rotateZText = CreateLabel(LabelWidth, LabelHeigth, rotateZRow, TextColumn, 0, "Rotate Z");
            Controls.Add(rotateZText);
            rotateZValue = CreateLabel(LabelWidth, LabelHeigth, rotateZRow, ValueColumn, 1, "0");
            Controls.Add(rotateZValue);
            rotateZControls = CreateLabel(LabelWidth, LabelHeigth, rotateZRow, ControlsColumn, 1, "z/Z");
            Controls.Add(rotateZControls);
            
            const int radiansRow = 8;
            radiansText = CreateLabel(LabelWidth, LabelHeigth, radiansRow, TextColumn, 0, "Radians");
            Controls.Add(radiansText);
            radiansValue = CreateLabel(LabelWidth, LabelHeigth, radiansRow, ValueColumn, 1, "0");
            Controls.Add(radiansValue);
            radiansControls = CreateLabel(LabelWidth, LabelHeigth, radiansRow, ControlsColumn, 1, "r/R");
            Controls.Add(radiansControls);
            
            const int distanceRow = 9;
            distanceText = CreateLabel(LabelWidth, LabelHeigth, distanceRow, TextColumn, 0, "Distance");
            Controls.Add(distanceText);
            distanceValue = CreateLabel(LabelWidth, LabelHeigth, distanceRow, ValueColumn, 1, "0");
            Controls.Add(distanceValue);
            distanceControls = CreateLabel(LabelWidth, LabelHeigth, distanceRow, ControlsColumn, 1, "d/D");
            Controls.Add(distanceControls);
            
            const int phiRow = 10;
            phiText = CreateLabel(LabelWidth, LabelHeigth, phiRow, TextColumn, 0, "Phi");
            Controls.Add(phiText);
            phiValue = CreateLabel(LabelWidth, LabelHeigth, phiRow, ValueColumn, 1, "0");
            Controls.Add(phiValue);
            phiControls = CreateLabel(LabelWidth, LabelHeigth, phiRow, ControlsColumn, 1, "p/P");
            Controls.Add(phiControls);

            const int thetaRow = 11;
            thetaText = CreateLabel(LabelWidth, LabelHeigth, thetaRow, TextColumn, 0, "Theta");
            Controls.Add(thetaText);
            thetaValue = CreateLabel(LabelWidth, LabelHeigth, thetaRow, ValueColumn, 1, "0");
            Controls.Add(thetaValue);
            thetaControls = CreateLabel(LabelWidth, LabelHeigth, thetaRow, ControlsColumn, 1, "t/T");
            Controls.Add(thetaControls);
            
            const int phaseRow = 13;
            phaseText = CreateLabel(LabelWidth, LabelHeigth, phaseRow, TextColumn, 0, "Phase");
            Controls.Add(phaseText);
            phaseValue = CreateLabel(LabelWidth, LabelHeigth, phaseRow, ValueColumn, 1, "0");
            Controls.Add(phaseValue);
            
            const int animationRow = 14;
            animationText = CreateLabel(LabelWidth, LabelHeigth, animationRow, TextColumn, 0, "Animation");
            Controls.Add(animationText);
            animationValue = CreateLabel(LabelWidth, LabelHeigth, animationRow, ValueColumn, 1, "Play");
            Controls.Add(animationValue);
            animationControls = CreateLabel(LabelWidth, LabelHeigth, animationRow, ControlsColumn, 1, "a/o");
            Controls.Add(animationControls);

            const int resetRow = 16;
            resetText = CreateLabel(LabelWidth, LabelHeigth, resetRow, TextColumn, 0, "Reset");
            Controls.Add(resetText);
            resetControls = CreateLabel(LabelWidth, LabelHeigth, resetRow, ValueColumn, 1, "C");
            Controls.Add(resetControls);

            // 
            // MatrixForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MatrixForm";
            Text = "Matrix transformations";
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
        private Label animationText, animationValue, animationControls;
        
        private Label CreateLabel(int labelWidth, int labelHeigt, int row, int column, int tabIndex, string text)
        {
            var label = new Label();
            label.AutoSize = true;
            label.Location = new Point(column, labelHeigt * row);
            label.Size = new Size(labelWidth, labelHeigt);
            label.TabIndex = tabIndex;
            label.Text = text;

            return label;
        }
    }
}
