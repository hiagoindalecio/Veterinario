namespace Veterinario.Forms
{
    partial class FRM_Consulta_Funcionario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_Consulta_Funcionario));
            this.gbFuncionarios = new System.Windows.Forms.GroupBox();
            this.lstFuncionarios = new System.Windows.Forms.ListView();
            this.clnID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clnNome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clnMasterID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clnAtivo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ckbAtivos = new System.Windows.Forms.CheckBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbDados = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbAtivo = new System.Windows.Forms.ComboBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.cbxSenha = new System.Windows.Forms.CheckBox();
            this.eyeSenha1 = new System.Windows.Forms.Label();
            this.txtSenha1 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.eyeSenha2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSenha2 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbMaster = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.gbFuncionarios.SuspendLayout();
            this.gbDados.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFuncionarios
            // 
            this.gbFuncionarios.Controls.Add(this.lstFuncionarios);
            this.gbFuncionarios.Controls.Add(this.ckbAtivos);
            this.gbFuncionarios.Controls.Add(this.btnEdit);
            this.gbFuncionarios.Controls.Add(this.label3);
            this.gbFuncionarios.Controls.Add(this.txtFiltro);
            this.gbFuncionarios.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFuncionarios.Location = new System.Drawing.Point(18, 133);
            this.gbFuncionarios.Name = "gbFuncionarios";
            this.gbFuncionarios.Size = new System.Drawing.Size(834, 418);
            this.gbFuncionarios.TabIndex = 13;
            this.gbFuncionarios.TabStop = false;
            this.gbFuncionarios.Text = "Funcionários";
            // 
            // lstFuncionarios
            // 
            this.lstFuncionarios.AutoArrange = false;
            this.lstFuncionarios.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clnID,
            this.clnNome,
            this.clnMasterID,
            this.clnAtivo});
            this.lstFuncionarios.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstFuncionarios.FullRowSelect = true;
            this.lstFuncionarios.HideSelection = false;
            this.lstFuncionarios.Location = new System.Drawing.Point(14, 51);
            this.lstFuncionarios.Name = "lstFuncionarios";
            this.lstFuncionarios.Size = new System.Drawing.Size(814, 359);
            this.lstFuncionarios.TabIndex = 1;
            this.lstFuncionarios.UseCompatibleStateImageBehavior = false;
            this.lstFuncionarios.View = System.Windows.Forms.View.Details;
            // 
            // clnID
            // 
            this.clnID.Text = "ID";
            // 
            // clnNome
            // 
            this.clnNome.Text = "Nome";
            this.clnNome.Width = 430;
            // 
            // clnMasterID
            // 
            this.clnMasterID.Text = "Master ID";
            this.clnMasterID.Width = 192;
            // 
            // clnAtivo
            // 
            this.clnAtivo.Text = "Ativo";
            this.clnAtivo.Width = 128;
            // 
            // ckbAtivos
            // 
            this.ckbAtivos.AutoSize = true;
            this.ckbAtivos.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbAtivos.Location = new System.Drawing.Point(648, 8);
            this.ckbAtivos.Name = "ckbAtivos";
            this.ckbAtivos.Size = new System.Drawing.Size(99, 48);
            this.ckbAtivos.TabIndex = 9;
            this.ckbAtivos.Text = "Somente\r\nAtivos";
            this.ckbAtivos.UseVisualStyleBackColor = true;
            this.ckbAtivos.CheckedChanged += new System.EventHandler(this.AlteraFiltro);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(753, 15);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 32);
            this.btnEdit.TabIndex = 7;
            this.btnEdit.Text = "Editar";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.EditarFuncionario);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 22);
            this.label3.TabIndex = 6;
            this.label3.Text = "Pesquisa";
            // 
            // txtFiltro
            // 
            this.txtFiltro.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltro.Location = new System.Drawing.Point(102, 17);
            this.txtFiltro.MaxLength = 50;
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(539, 30);
            this.txtFiltro.TabIndex = 0;
            this.txtFiltro.TextChanged += new System.EventHandler(this.Filtro);
            this.txtFiltro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RemoverFiltro);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(414, 19);
            this.label2.TabIndex = 12;
            this.label2.Text = "Bem vindo à área de consulta de funcionários.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(399, 34);
            this.label1.TabIndex = 11;
            this.label1.Text = "Consulta de Funcionários";
            // 
            // gbDados
            // 
            this.gbDados.Controls.Add(this.label5);
            this.gbDados.Controls.Add(this.cmbAtivo);
            this.gbDados.Controls.Add(this.btnCancelar);
            this.gbDados.Controls.Add(this.btnAtualizar);
            this.gbDados.Controls.Add(this.cbxSenha);
            this.gbDados.Controls.Add(this.eyeSenha1);
            this.gbDados.Controls.Add(this.txtSenha1);
            this.gbDados.Controls.Add(this.label10);
            this.gbDados.Controls.Add(this.label8);
            this.gbDados.Controls.Add(this.eyeSenha2);
            this.gbDados.Controls.Add(this.label7);
            this.gbDados.Controls.Add(this.txtSenha2);
            this.gbDados.Controls.Add(this.label9);
            this.gbDados.Controls.Add(this.cmbMaster);
            this.gbDados.Controls.Add(this.label6);
            this.gbDados.Controls.Add(this.txtLogin);
            this.gbDados.Controls.Add(this.label4);
            this.gbDados.Controls.Add(this.txtNome);
            this.gbDados.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDados.Location = new System.Drawing.Point(858, 133);
            this.gbDados.Name = "gbDados";
            this.gbDados.Size = new System.Drawing.Size(399, 418);
            this.gbDados.TabIndex = 10;
            this.gbDados.TabStop = false;
            this.gbDados.Text = "Dados";
            this.gbDados.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(283, 281);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 22);
            this.label5.TabIndex = 81;
            this.label5.Text = "Ativo";
            // 
            // cmbAtivo
            // 
            this.cmbAtivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAtivo.Font = new System.Drawing.Font("Consolas", 14.25F);
            this.cmbAtivo.FormattingEnabled = true;
            this.cmbAtivo.Items.AddRange(new object[] {
            "Sim",
            "Não"});
            this.cmbAtivo.Location = new System.Drawing.Point(287, 307);
            this.cmbAtivo.Margin = new System.Windows.Forms.Padding(4);
            this.cmbAtivo.Name = "cmbAtivo";
            this.cmbAtivo.Size = new System.Drawing.Size(96, 30);
            this.cmbAtivo.TabIndex = 80;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(176, 378);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(105, 32);
            this.btnCancelar.TabIndex = 79;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.CancelarEdicao);
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtualizar.Location = new System.Drawing.Point(287, 378);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(105, 32);
            this.btnAtualizar.TabIndex = 78;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.AtualizarFuncionario);
            // 
            // cbxSenha
            // 
            this.cbxSenha.AutoSize = true;
            this.cbxSenha.Location = new System.Drawing.Point(21, 274);
            this.cbxSenha.Name = "cbxSenha";
            this.cbxSenha.Size = new System.Drawing.Size(211, 22);
            this.cbxSenha.TabIndex = 76;
            this.cbxSenha.Text = "Senha Padrão (\"102030\")";
            this.cbxSenha.UseVisualStyleBackColor = true;
            this.cbxSenha.CheckedChanged += new System.EventHandler(this.SenhaPadrao);
            // 
            // eyeSenha1
            // 
            this.eyeSenha1.BackColor = System.Drawing.Color.White;
            this.eyeSenha1.Image = ((System.Drawing.Image)(resources.GetObject("eyeSenha1.Image")));
            this.eyeSenha1.Location = new System.Drawing.Point(272, 179);
            this.eyeSenha1.Name = "eyeSenha1";
            this.eyeSenha1.Size = new System.Drawing.Size(25, 24);
            this.eyeSenha1.TabIndex = 75;
            this.eyeSenha1.Click += new System.EventHandler(this.VisualizarSenha);
            // 
            // txtSenha1
            // 
            this.txtSenha1.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenha1.Location = new System.Drawing.Point(21, 176);
            this.txtSenha1.Name = "txtSenha1";
            this.txtSenha1.Size = new System.Drawing.Size(285, 30);
            this.txtSenha1.TabIndex = 74;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(17, 213);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(160, 22);
            this.label10.TabIndex = 73;
            this.label10.Text = "Confirmar Senha";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(17, 151);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 22);
            this.label8.TabIndex = 72;
            this.label8.Text = "Senha";
            // 
            // eyeSenha2
            // 
            this.eyeSenha2.BackColor = System.Drawing.Color.White;
            this.eyeSenha2.Image = ((System.Drawing.Image)(resources.GetObject("eyeSenha2.Image")));
            this.eyeSenha2.Location = new System.Drawing.Point(272, 241);
            this.eyeSenha2.Name = "eyeSenha2";
            this.eyeSenha2.Size = new System.Drawing.Size(25, 24);
            this.eyeSenha2.TabIndex = 69;
            this.eyeSenha2.Click += new System.EventHandler(this.VisualizarSenha2);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(-195, 235);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 22);
            this.label7.TabIndex = 63;
            this.label7.Text = "Senha";
            // 
            // txtSenha2
            // 
            this.txtSenha2.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenha2.Location = new System.Drawing.Point(21, 238);
            this.txtSenha2.Name = "txtSenha2";
            this.txtSenha2.Size = new System.Drawing.Size(285, 30);
            this.txtSenha2.TabIndex = 64;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(292, 89);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 22);
            this.label9.TabIndex = 62;
            this.label9.Text = "ID mestre";
            // 
            // cmbMaster
            // 
            this.cmbMaster.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMaster.Font = new System.Drawing.Font("Consolas", 14.25F);
            this.cmbMaster.FormattingEnabled = true;
            this.cmbMaster.Items.AddRange(new object[] {
            "Sim",
            "Não"});
            this.cmbMaster.Location = new System.Drawing.Point(296, 115);
            this.cmbMaster.Margin = new System.Windows.Forms.Padding(4);
            this.cmbMaster.Name = "cmbMaster";
            this.cmbMaster.Size = new System.Drawing.Size(96, 30);
            this.cmbMaster.TabIndex = 61;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(17, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 22);
            this.label6.TabIndex = 60;
            this.label6.Text = "Login";
            // 
            // txtLogin
            // 
            this.txtLogin.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLogin.Location = new System.Drawing.Point(21, 115);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(268, 30);
            this.txtLogin.TabIndex = 59;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 22);
            this.label4.TabIndex = 6;
            this.label4.Text = "Nome";
            // 
            // txtNome
            // 
            this.txtNome.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.Location = new System.Drawing.Point(21, 50);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(372, 30);
            this.txtNome.TabIndex = 5;
            this.txtNome.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidarTexto);
            // 
            // FRM_Consulta_Funcionario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 745);
            this.ControlBox = false;
            this.Controls.Add(this.gbDados);
            this.Controls.Add(this.gbFuncionarios);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1280, 745);
            this.MinimumSize = new System.Drawing.Size(1280, 745);
            this.Name = "FRM_Consulta_Funcionario";
            this.Text = "Consulta Funcionário";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Close);
            this.Load += new System.EventHandler(this.LoadAll);
            this.gbFuncionarios.ResumeLayout(false);
            this.gbFuncionarios.PerformLayout();
            this.gbDados.ResumeLayout(false);
            this.gbDados.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFuncionarios;
        private System.Windows.Forms.ListView lstFuncionarios;
        private System.Windows.Forms.ColumnHeader clnID;
        private System.Windows.Forms.ColumnHeader clnNome;
        private System.Windows.Forms.ColumnHeader clnMasterID;
        private System.Windows.Forms.CheckBox ckbAtivos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbDados;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.ColumnHeader clnAtivo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbMaster;
        private System.Windows.Forms.Label eyeSenha1;
        private System.Windows.Forms.TextBox txtSenha1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label eyeSenha2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSenha2;
        private System.Windows.Forms.CheckBox cbxSenha;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbAtivo;
    }
}