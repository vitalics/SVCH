﻿using System;
using System.ComponentModel;

namespace Lab1
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.formula1 = new System.Windows.Forms.RadioButton();
            this.formula2 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.xValue = new System.Windows.Forms.TextBox();
            this.bValue = new System.Windows.Forms.TextBox();
            this.aValue = new System.Windows.Forms.TextBox();
            this.incrementList = new System.Windows.Forms.CheckedListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.graphic = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.xLastValue = new System.Windows.Forms.TextBox();
            this.xFirstValueProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.xLastProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.bValueProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.aValueProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.incrementListProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.dxValue = new System.Windows.Forms.TextBox();
            this.AddToList_button = new System.Windows.Forms.Button();
            this.dxErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.graphic)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xFirstValueProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xLastProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bValueProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aValueProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.incrementListProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // formula1
            // 
            this.formula1.AutoSize = true;
            this.formula1.Location = new System.Drawing.Point(6, 19);
            this.formula1.Name = "formula1";
            this.formula1.Size = new System.Drawing.Size(116, 17);
            this.formula1.TabIndex = 1;
            this.formula1.TabStop = true;
            this.formula1.Text = "y = x*x + tg(5x+b/x)";
            this.formula1.UseVisualStyleBackColor = true;
            this.formula1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.formula1_MouseClick);
            // 
            // formula2
            // 
            this.formula2.AutoSize = true;
            this.formula2.Location = new System.Drawing.Point(6, 68);
            this.formula2.Name = "formula2";
            this.formula2.Size = new System.Drawing.Size(137, 17);
            this.formula2.TabIndex = 2;
            this.formula2.TabStop = true;
            this.formula2.Text = "y = 0.1*a*x^3 * tg(a-b*x)";
            this.formula2.UseVisualStyleBackColor = true;
            this.formula2.Click += new System.EventHandler(this.formula2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "x first value";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "b value";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 201);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "a value";
            // 
            // xValue
            // 
            this.xValue.Location = new System.Drawing.Point(87, 120);
            this.xValue.MaxLength = 10;
            this.xValue.Name = "xValue";
            this.xValue.Size = new System.Drawing.Size(100, 20);
            this.xValue.TabIndex = 3;
            this.xValue.Validating += new System.ComponentModel.CancelEventHandler(this.xValue_Validating);
            // 
            // bValue
            // 
            this.bValue.Location = new System.Drawing.Point(87, 172);
            this.bValue.MaxLength = 10;
            this.bValue.Name = "bValue";
            this.bValue.Size = new System.Drawing.Size(100, 20);
            this.bValue.TabIndex = 5;
            this.bValue.Validating += new System.ComponentModel.CancelEventHandler(this.bValue_Validating);
            // 
            // aValue
            // 
            this.aValue.Location = new System.Drawing.Point(87, 198);
            this.aValue.MaxLength = 10;
            this.aValue.Name = "aValue";
            this.aValue.Size = new System.Drawing.Size(100, 20);
            this.aValue.TabIndex = 6;
            this.aValue.EnabledChanged += new System.EventHandler(this.aValue_EnabledChanged);
            this.aValue.Validating += new System.ComponentModel.CancelEventHandler(this.aValue_Validating);
            // 
            // incrementList
            // 
            this.incrementList.FormattingEnabled = true;
            this.incrementList.Location = new System.Drawing.Point(297, 27);
            this.incrementList.Name = "incrementList";
            this.incrementList.Size = new System.Drawing.Size(120, 154);
            this.incrementList.TabIndex = 8;
            this.incrementList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.incrementList_ItemCheck);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(47, 247);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Calculate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // graphic
            // 
            this.graphic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.graphic.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.graphic.Legends.Add(legend1);
            this.graphic.Location = new System.Drawing.Point(481, 27);
            this.graphic.Name = "graphic";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.graphic.Series.Add(series1);
            this.graphic.Size = new System.Drawing.Size(441, 402);
            this.graphic.TabIndex = 11;
            this.graphic.Text = "Graphic";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.formula2);
            this.groupBox1.Controls.Add(this.formula1);
            this.groupBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.groupBox1.Location = new System.Drawing.Point(30, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Formulas";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "x last value";
            // 
            // xLastValue
            // 
            this.xLastValue.Location = new System.Drawing.Point(87, 146);
            this.xLastValue.MaxLength = 10;
            this.xLastValue.Name = "xLastValue";
            this.xLastValue.Size = new System.Drawing.Size(100, 20);
            this.xLastValue.TabIndex = 4;
            this.xLastValue.Validating += new System.ComponentModel.CancelEventHandler(this.xLastValue_Validating);
            // 
            // xFirstValueProvider
            // 
            this.xFirstValueProvider.ContainerControl = this;
            // 
            // xLastProvider
            // 
            this.xLastProvider.ContainerControl = this;
            // 
            // bValueProvider
            // 
            this.bValueProvider.ContainerControl = this;
            // 
            // aValueProvider
            // 
            this.aValueProvider.ContainerControl = this;
            // 
            // incrementListProvider
            // 
            this.incrementListProvider.ContainerControl = this;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(224, 201);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Add dx value";
            // 
            // dxValue
            // 
            this.dxValue.Location = new System.Drawing.Point(299, 198);
            this.dxValue.MaxLength = 10;
            this.dxValue.Name = "dxValue";
            this.dxValue.Size = new System.Drawing.Size(118, 20);
            this.dxValue.TabIndex = 9;
            this.dxValue.Validating += new System.ComponentModel.CancelEventHandler(this.dxValue_Validating);
            // 
            // AddToList_button
            // 
            this.AddToList_button.Location = new System.Drawing.Point(299, 224);
            this.AddToList_button.Name = "AddToList_button";
            this.AddToList_button.Size = new System.Drawing.Size(118, 23);
            this.AddToList_button.TabIndex = 10;
            this.AddToList_button.Text = "Add to list";
            this.AddToList_button.UseVisualStyleBackColor = true;
            this.AddToList_button.Click += new System.EventHandler(this.AddToList_button_Click);
            // 
            // dxErrorProvider
            // 
            this.dxErrorProvider.ContainerControl = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 441);
            this.Controls.Add(this.AddToList_button);
            this.Controls.Add(this.dxValue);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.xLastValue);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.graphic);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.incrementList);
            this.Controls.Add(this.aValue);
            this.Controls.Add(this.bValue);
            this.Controls.Add(this.xValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(950, 480);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.graphic)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xFirstValueProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xLastProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bValueProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aValueProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.incrementListProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton formula1;
        private System.Windows.Forms.RadioButton formula2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox xValue;
        private System.Windows.Forms.TextBox bValue;
        private System.Windows.Forms.TextBox aValue;
        private System.Windows.Forms.CheckedListBox incrementList;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataVisualization.Charting.Chart graphic;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox xLastValue;
        public System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ErrorProvider xFirstValueProvider;
        private System.Windows.Forms.ErrorProvider xLastProvider;
        private System.Windows.Forms.ErrorProvider bValueProvider;
        private System.Windows.Forms.ErrorProvider aValueProvider;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ErrorProvider incrementListProvider;
        private System.Windows.Forms.Button AddToList_button;
        private System.Windows.Forms.TextBox dxValue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ErrorProvider dxErrorProvider;
    }
}

