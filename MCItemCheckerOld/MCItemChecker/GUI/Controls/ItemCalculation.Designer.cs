
namespace MCItemChecker.GUI.Controls
{
    partial class ItemCalculation
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbBase = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.numAmount = new System.Windows.Forms.NumericUpDown();
            this.lCalculatedItemName = new System.Windows.Forms.Label();
            this.lvCalculatedItems = new System.Windows.Forms.ListView();
            this.cbfiltertype = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // cbBase
            // 
            this.cbBase.AutoSize = true;
            this.cbBase.Location = new System.Drawing.Point(313, 416);
            this.cbBase.Name = "cbBase";
            this.cbBase.Size = new System.Drawing.Size(78, 17);
            this.cbBase.TabIndex = 134;
            this.cbBase.Text = "Base Items";
            this.cbBase.UseVisualStyleBackColor = true;
            this.cbBase.CheckStateChanged += new System.EventHandler(this.CbBase_CheckStateChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(85, 415);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 13);
            this.label9.TabIndex = 133;
            this.label9.Text = "Amount:";
            // 
            // numAmount
            // 
            this.numAmount.Location = new System.Drawing.Point(134, 413);
            this.numAmount.Maximum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            0});
            this.numAmount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numAmount.Name = "numAmount";
            this.numAmount.Size = new System.Drawing.Size(117, 20);
            this.numAmount.TabIndex = 132;
            this.numAmount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NumAmount_KeyDown);
            // 
            // lCalculatedItemName
            // 
            this.lCalculatedItemName.AutoSize = true;
            this.lCalculatedItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCalculatedItemName.Location = new System.Drawing.Point(103, 10);
            this.lCalculatedItemName.Name = "lCalculatedItemName";
            this.lCalculatedItemName.Size = new System.Drawing.Size(11, 13);
            this.lCalculatedItemName.TabIndex = 131;
            this.lCalculatedItemName.Text = " ";
            // 
            // lvCalculatedItems
            // 
            this.lvCalculatedItems.FullRowSelect = true;
            this.lvCalculatedItems.GridLines = true;
            this.lvCalculatedItems.HideSelection = false;
            this.lvCalculatedItems.Location = new System.Drawing.Point(17, 33);
            this.lvCalculatedItems.Name = "lvCalculatedItems";
            this.lvCalculatedItems.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lvCalculatedItems.Size = new System.Drawing.Size(458, 344);
            this.lvCalculatedItems.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvCalculatedItems.TabIndex = 130;
            this.lvCalculatedItems.UseCompatibleStateImageBehavior = false;
            this.lvCalculatedItems.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LvCalculatedItems_KeyDown);
            this.lvCalculatedItems.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LvCalculatedItems_MouseClick);
            this.lvCalculatedItems.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LvCalculatedItems_MouseDoubleClick);
            // 
            // cbfiltertype
            // 
            this.cbfiltertype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbfiltertype.FormattingEnabled = true;
            this.cbfiltertype.Location = new System.Drawing.Point(134, 386);
            this.cbfiltertype.Name = "cbfiltertype";
            this.cbfiltertype.Size = new System.Drawing.Size(271, 21);
            this.cbfiltertype.TabIndex = 129;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(72, 390);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 13);
            this.label11.TabIndex = 128;
            this.label11.Text = "Filter Type:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(14, 10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(83, 13);
            this.label12.TabIndex = 125;
            this.label12.Text = "Viewing Item:";
            // 
            // ItemCalculation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.cbBase);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.numAmount);
            this.Controls.Add(this.lCalculatedItemName);
            this.Controls.Add(this.lvCalculatedItems);
            this.Controls.Add(this.cbfiltertype);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Name = "ItemCalculation";
            this.Size = new System.Drawing.Size(493, 441);
            ((System.ComponentModel.ISupportInitialize)(this.numAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbBase;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numAmount;
        private System.Windows.Forms.Label lCalculatedItemName;
        private System.Windows.Forms.ListView lvCalculatedItems;
        private System.Windows.Forms.ComboBox cbfiltertype;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
    }
}
