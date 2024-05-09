
namespace Kursovaya_V._1.Pages
{
    partial class FormViewAddress
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
            this.comboBoxDistrict = new System.Windows.Forms.ComboBox();
            this.cinemaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cinemaDb2DataSet = new Kursovaya_V._1.CinemaDb2DataSet();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cinemaTableAdapter = new Kursovaya_V._1.CinemaDb2DataSetTableAdapters.CinemaTableAdapter();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.fKMovieCinemaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.movieTableAdapter = new Kursovaya_V._1.CinemaDb2DataSetTableAdapters.MovieTableAdapter();
            this.cinemaBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.linkLabel5 = new System.Windows.Forms.LinkLabel();
            this.button6 = new System.Windows.Forms.Button();
            this.fKMovieCinemaBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.fKMovieCinemaBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.fKMovieCinemaBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.fKSessionMovieBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sessionTableAdapter = new Kursovaya_V._1.CinemaDb2DataSetTableAdapters.SessionTableAdapter();
            this.fKSessionMovieBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.fKSessionMovieBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.cinemaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cinemaDb2DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKMovieCinemaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cinemaBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKMovieCinemaBindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKMovieCinemaBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKMovieCinemaBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKSessionMovieBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKSessionMovieBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKSessionMovieBindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxDistrict
            // 
            this.comboBoxDistrict.DataSource = this.cinemaBindingSource;
            this.comboBoxDistrict.DisplayMember = "NameCinema";
            this.comboBoxDistrict.FormattingEnabled = true;
            this.comboBoxDistrict.Location = new System.Drawing.Point(132, 93);
            this.comboBoxDistrict.Name = "comboBoxDistrict";
            this.comboBoxDistrict.Size = new System.Drawing.Size(174, 21);
            this.comboBoxDistrict.TabIndex = 17;
            this.comboBoxDistrict.ValueMember = "CinemaId";
            this.comboBoxDistrict.SelectedIndexChanged += new System.EventHandler(this.comboBoxDistrict_SelectedIndexChanged_1);
            // 
            // cinemaBindingSource
            // 
            this.cinemaBindingSource.DataMember = "Cinema";
            this.cinemaBindingSource.DataSource = this.cinemaDb2DataSet;
            // 
            // cinemaDb2DataSet
            // 
            this.cinemaDb2DataSet.DataSetName = "CinemaDb2DataSet";
            this.cinemaDb2DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(107, 153);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(232, 20);
            this.textBox1.TabIndex = 20;
            // 
            // cinemaTableAdapter
            // 
            this.cinemaTableAdapter.ClearBeforeFill = true;
            // 
            // fKMovieCinemaBindingSource
            // 
            this.fKMovieCinemaBindingSource.DataMember = "FK_Movie_Cinema";
            this.fKMovieCinemaBindingSource.DataSource = this.cinemaBindingSource;
            // 
            // movieTableAdapter
            // 
            this.movieTableAdapter.ClearBeforeFill = true;
            // 
            // cinemaBindingSource1
            // 
            this.cinemaBindingSource1.DataMember = "Cinema";
            this.cinemaBindingSource1.DataSource = this.cinemaDb2DataSet;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MediumPurple;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.button1.Location = new System.Drawing.Point(132, 202);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(184, 29);
            this.button1.TabIndex = 21;
            this.button1.Text = "Вывести адрес документом";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // linkLabel5
            // 
            this.linkLabel5.AutoSize = true;
            this.linkLabel5.LinkColor = System.Drawing.Color.Navy;
            this.linkLabel5.Location = new System.Drawing.Point(162, 47);
            this.linkLabel5.Name = "linkLabel5";
            this.linkLabel5.Size = new System.Drawing.Size(112, 13);
            this.linkLabel5.TabIndex = 22;
            this.linkLabel5.TabStop = true;
            this.linkLabel5.Text = "Выберите кинотеатр";
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.button6.Location = new System.Drawing.Point(12, 12);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 23;
            this.button6.Text = "Назад";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // fKMovieCinemaBindingSource3
            // 
            this.fKMovieCinemaBindingSource3.DataMember = "FK_Movie_Cinema";
            this.fKMovieCinemaBindingSource3.DataSource = this.cinemaBindingSource;
            // 
            // fKMovieCinemaBindingSource1
            // 
            this.fKMovieCinemaBindingSource1.DataMember = "FK_Movie_Cinema";
            this.fKMovieCinemaBindingSource1.DataSource = this.cinemaBindingSource;
            // 
            // fKMovieCinemaBindingSource2
            // 
            this.fKMovieCinemaBindingSource2.DataMember = "FK_Movie_Cinema";
            this.fKMovieCinemaBindingSource2.DataSource = this.cinemaBindingSource;
            // 
            // fKSessionMovieBindingSource
            // 
            this.fKSessionMovieBindingSource.DataMember = "FK_Session_Movie";
            this.fKSessionMovieBindingSource.DataSource = this.fKMovieCinemaBindingSource3;
            // 
            // sessionTableAdapter
            // 
            this.sessionTableAdapter.ClearBeforeFill = true;
            // 
            // fKSessionMovieBindingSource1
            // 
            this.fKSessionMovieBindingSource1.DataMember = "FK_Session_Movie";
            this.fKSessionMovieBindingSource1.DataSource = this.fKMovieCinemaBindingSource;
            // 
            // fKSessionMovieBindingSource2
            // 
            this.fKSessionMovieBindingSource2.DataMember = "FK_Session_Movie";
            this.fKSessionMovieBindingSource2.DataSource = this.fKMovieCinemaBindingSource3;
            // 
            // FormViewAddress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(435, 262);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.linkLabel5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBoxDistrict);
            this.Name = "FormViewAddress";
            this.Text = "FormViewAddress";
            this.Load += new System.EventHandler(this.FormViewAddress_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cinemaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cinemaDb2DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKMovieCinemaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cinemaBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKMovieCinemaBindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKMovieCinemaBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKMovieCinemaBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKSessionMovieBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKSessionMovieBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKSessionMovieBindingSource2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxDistrict;
        private System.Windows.Forms.TextBox textBox1;
        private CinemaDb2DataSet cinemaDb2DataSet;
        private System.Windows.Forms.BindingSource cinemaBindingSource;
        private CinemaDb2DataSetTableAdapters.CinemaTableAdapter cinemaTableAdapter;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.BindingSource fKMovieCinemaBindingSource;
        private CinemaDb2DataSetTableAdapters.MovieTableAdapter movieTableAdapter;
        private System.Windows.Forms.BindingSource cinemaBindingSource1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.LinkLabel linkLabel5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.BindingSource fKMovieCinemaBindingSource3;
        private System.Windows.Forms.BindingSource fKMovieCinemaBindingSource1;
        private System.Windows.Forms.BindingSource fKMovieCinemaBindingSource2;
        private System.Windows.Forms.BindingSource fKSessionMovieBindingSource;
        private CinemaDb2DataSetTableAdapters.SessionTableAdapter sessionTableAdapter;
        private System.Windows.Forms.BindingSource fKSessionMovieBindingSource1;
        private System.Windows.Forms.BindingSource fKSessionMovieBindingSource2;
    }
}