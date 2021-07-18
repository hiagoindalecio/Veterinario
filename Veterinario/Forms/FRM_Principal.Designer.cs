namespace Veterinario
{
    partial class Principal
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtUserLogado = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.atendimentoItem = new System.Windows.Forms.ToolStripMenuItem();
            this.novoAtendimentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGestaoAtendimentos = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.animaisItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastroToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastroAnimalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastroRaçaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastroTipoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.funcionariosItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastroFuncionarioItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestãoFuncionarioItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.AutoSize = false;
            this.menuStrip.BackColor = System.Drawing.Color.CornflowerBlue;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.atendimentoItem,
            this.clientesItem,
            this.animaisItem,
            this.funcionariosItem,
            this.toolStripMenuItem1});
            this.menuStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1264, 76);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.txtUserLogado});
            this.statusStrip1.Location = new System.Drawing.Point(0, 623);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1264, 58);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(110, 53);
            this.toolStripStatusLabel1.Text = "Bem vindo,";
            // 
            // txtUserLogado
            // 
            this.txtUserLogado.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserLogado.Name = "txtUserLogado";
            this.txtUserLogado.Size = new System.Drawing.Size(50, 53);
            this.txtUserLogado.Text = "Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.label1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1119, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Dev. By Hiago Indalécio";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.pictureBox1.Image = global::Veterinario.Properties.Resources.Raccoon__1_;
            this.pictureBox1.Location = new System.Drawing.Point(974, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(101, 76);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // atendimentoItem
            // 
            this.atendimentoItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novoAtendimentoToolStripMenuItem,
            this.btnGestaoAtendimentos});
            this.atendimentoItem.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.atendimentoItem.Image = global::Veterinario.Properties.Resources.veterinario;
            this.atendimentoItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.atendimentoItem.Name = "atendimentoItem";
            this.atendimentoItem.Size = new System.Drawing.Size(132, 72);
            this.atendimentoItem.Text = "Atendimento";
            this.atendimentoItem.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.atendimentoItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // novoAtendimentoToolStripMenuItem
            // 
            this.novoAtendimentoToolStripMenuItem.Name = "novoAtendimentoToolStripMenuItem";
            this.novoAtendimentoToolStripMenuItem.Size = new System.Drawing.Size(240, 26);
            this.novoAtendimentoToolStripMenuItem.Text = "Novo Atendimento";
            this.novoAtendimentoToolStripMenuItem.Click += new System.EventHandler(this.Openatendimento);
            // 
            // btnGestaoAtendimentos
            // 
            this.btnGestaoAtendimentos.Name = "btnGestaoAtendimentos";
            this.btnGestaoAtendimentos.Size = new System.Drawing.Size(240, 26);
            this.btnGestaoAtendimentos.Text = "Gestão";
            this.btnGestaoAtendimentos.Click += new System.EventHandler(this.OpenGestaoAtendimentos);
            // 
            // clientesItem
            // 
            this.clientesItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastroToolStripMenuItem,
            this.consultaToolStripMenuItem});
            this.clientesItem.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientesItem.Image = global::Veterinario.Properties.Resources.cliente;
            this.clientesItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.clientesItem.Name = "clientesItem";
            this.clientesItem.Size = new System.Drawing.Size(102, 72);
            this.clientesItem.Text = "Clientes";
            this.clientesItem.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.clientesItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // cadastroToolStripMenuItem
            // 
            this.cadastroToolStripMenuItem.Name = "cadastroToolStripMenuItem";
            this.cadastroToolStripMenuItem.Size = new System.Drawing.Size(160, 26);
            this.cadastroToolStripMenuItem.Text = "Cadastro";
            this.cadastroToolStripMenuItem.Click += new System.EventHandler(this.CadastroCliente);
            // 
            // consultaToolStripMenuItem
            // 
            this.consultaToolStripMenuItem.Name = "consultaToolStripMenuItem";
            this.consultaToolStripMenuItem.Size = new System.Drawing.Size(160, 26);
            this.consultaToolStripMenuItem.Text = "Gestão";
            this.consultaToolStripMenuItem.Click += new System.EventHandler(this.ConsultaCliente);
            // 
            // animaisItem
            // 
            this.animaisItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastroToolStripMenuItem1,
            this.consultaToolStripMenuItem1});
            this.animaisItem.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.animaisItem.Image = global::Veterinario.Properties.Resources.pet_house;
            this.animaisItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.animaisItem.Name = "animaisItem";
            this.animaisItem.Size = new System.Drawing.Size(92, 72);
            this.animaisItem.Text = "Animais";
            this.animaisItem.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.animaisItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // cadastroToolStripMenuItem1
            // 
            this.cadastroToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastroAnimalToolStripMenuItem,
            this.cadastroRaçaToolStripMenuItem,
            this.cadastroTipoToolStripMenuItem});
            this.cadastroToolStripMenuItem1.Name = "cadastroToolStripMenuItem1";
            this.cadastroToolStripMenuItem1.Size = new System.Drawing.Size(160, 26);
            this.cadastroToolStripMenuItem1.Text = "Cadastro";
            // 
            // cadastroAnimalToolStripMenuItem
            // 
            this.cadastroAnimalToolStripMenuItem.Name = "cadastroAnimalToolStripMenuItem";
            this.cadastroAnimalToolStripMenuItem.Size = new System.Drawing.Size(230, 26);
            this.cadastroAnimalToolStripMenuItem.Text = "Cadastro Animal";
            this.cadastroAnimalToolStripMenuItem.Click += new System.EventHandler(this.CadastroAnimal);
            // 
            // cadastroRaçaToolStripMenuItem
            // 
            this.cadastroRaçaToolStripMenuItem.Name = "cadastroRaçaToolStripMenuItem";
            this.cadastroRaçaToolStripMenuItem.Size = new System.Drawing.Size(230, 26);
            this.cadastroRaçaToolStripMenuItem.Text = "Cadastro Raça";
            this.cadastroRaçaToolStripMenuItem.Click += new System.EventHandler(this.CadastroRaca);
            // 
            // cadastroTipoToolStripMenuItem
            // 
            this.cadastroTipoToolStripMenuItem.Name = "cadastroTipoToolStripMenuItem";
            this.cadastroTipoToolStripMenuItem.Size = new System.Drawing.Size(230, 26);
            this.cadastroTipoToolStripMenuItem.Text = "Cadastro Tipo";
            this.cadastroTipoToolStripMenuItem.Click += new System.EventHandler(this.CadastroTipo);
            // 
            // consultaToolStripMenuItem1
            // 
            this.consultaToolStripMenuItem1.Name = "consultaToolStripMenuItem1";
            this.consultaToolStripMenuItem1.Size = new System.Drawing.Size(160, 26);
            this.consultaToolStripMenuItem1.Text = "Gestão";
            this.consultaToolStripMenuItem1.Click += new System.EventHandler(this.ConsultaAnimal);
            // 
            // funcionariosItem
            // 
            this.funcionariosItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastroFuncionarioItem,
            this.gestãoFuncionarioItem});
            this.funcionariosItem.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.funcionariosItem.Image = global::Veterinario.Properties.Resources.empregado;
            this.funcionariosItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.funcionariosItem.Name = "funcionariosItem";
            this.funcionariosItem.Size = new System.Drawing.Size(142, 72);
            this.funcionariosItem.Text = "Funcionários";
            this.funcionariosItem.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.funcionariosItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // cadastroFuncionarioItem
            // 
            this.cadastroFuncionarioItem.Name = "cadastroFuncionarioItem";
            this.cadastroFuncionarioItem.Size = new System.Drawing.Size(160, 26);
            this.cadastroFuncionarioItem.Text = "Cadastro";
            this.cadastroFuncionarioItem.Click += new System.EventHandler(this.OpenCadastroFuncionario);
            // 
            // gestãoFuncionarioItem
            // 
            this.gestãoFuncionarioItem.Name = "gestãoFuncionarioItem";
            this.gestãoFuncionarioItem.Size = new System.Drawing.Size(160, 26);
            this.gestãoFuncionarioItem.Text = "Gestão";
            this.gestãoFuncionarioItem.Click += new System.EventHandler(this.OpenConsultaFuncionario);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem1.Image = global::Veterinario.Properties.Resources.desligar;
            this.toolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(82, 72);
            this.toolStripMenuItem1.Text = "Logoff";
            this.toolStripMenuItem1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripMenuItem1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripMenuItem1.Click += new System.EventHandler(this.Logoff);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1280, 720);
            this.MinimumSize = new System.Drawing.Size(1280, 720);
            this.Name = "Principal";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Principal";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BackToLogin);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem atendimentoItem;
        private System.Windows.Forms.ToolStripMenuItem clientesItem;
        private System.Windows.Forms.ToolStripMenuItem cadastroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem animaisItem;
        private System.Windows.Forms.ToolStripMenuItem cadastroToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem consultaToolStripMenuItem1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel txtUserLogado;
        private System.Windows.Forms.ToolStripMenuItem cadastroAnimalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastroRaçaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastroTipoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem funcionariosItem;
        private System.Windows.Forms.ToolStripMenuItem cadastroFuncionarioItem;
        private System.Windows.Forms.ToolStripMenuItem gestãoFuncionarioItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem novoAtendimentoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnGestaoAtendimentos;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

