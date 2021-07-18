drop database if exists db_vet;
create database db_vet;
use db_vet;

-- creating tables

CREATE TABLE tb_cliente (
    id_cliente INTEGER PRIMARY KEY AUTO_INCREMENT,
	ativo_cliente tinyint,
    nome_cliente VARCHAR(150) NOT NULL,
    endereco_cliente VARCHAR(200) NOT NULL,
    bairro_cliente VARCHAR(50) NOT NULL,
    cidade_estado VARCHAR(50) NOT NULL,
    cep VARCHAR(30) NOT NULL,
    telefone_cliente VARCHAR(20) NOT NULL,
    celular_cliente VARCHAR(20) NOT NULL
);

CREATE TABLE tb_animal (
    id_animal INTEGER PRIMARY KEY AUTO_INCREMENT,
	nome_animal VARCHAR(100) NOT NULL,
    image BLOB,
	nascimento DATE NOT NULL,
    fk_dono INTEGER NOT NULL,
    fk_tipo INTEGER NOT NULL,
    fk_raca INTEGER NOT NULL
);

CREATE TABLE tb_funcionario (
    id_funcionario INTEGER PRIMARY KEY AUTO_INCREMENT,
	master_id tinyint,
	ativo_funcionario tinyint,
	login VARCHAR(50),
    nome_funcionario VARCHAR(150) NOT NULL,
    senha_funcionario VARCHAR(150) NOT NULL
);

CREATE TABLE tb_raca (
    id_raca INTEGER PRIMARY KEY AUTO_INCREMENT,
    nome_raca VARCHAR(100) NOT NULL,
    fk_tipo INTEGER NOT NULL
);

CREATE TABLE tb_tipo (
    id_tipo INTEGER PRIMARY KEY AUTO_INCREMENT,
    nome_tipo VARCHAR(100) NOT NULL
);

CREATE TABLE tb_atendimento (
    id_atendimento INTEGER PRIMARY KEY AUTO_INCREMENT,
    descricao_atendimento VARCHAR(250) NOT NULL,
    data_atendimento DATE NOT NULL,
    fk_funcionario INTEGER NOT NULL,
    fk_animal INTEGER NOT NULL
);
 

-- default inserts 

insert into tb_tipo values
(0,'Cachorro');

insert into tb_raca values
(0, 'Maltes', 1);

insert into tb_cliente values
(0, 1, 'Carlos Adão', 'Rua dos bobos, nº0', 'Jardim Amado', 'Campos do Jordão-SP', '12460-000', '(11)3456-9765', '(11)96588-3323');

insert into tb_animal values
(0, 'Floquinho', null, '2015-08-06', 0, 0, 0);

insert into tb_funcionario values
(0, 1, 1, 'admin', 'Administrador', 'd61d004c03457bac7b90c1e8d4f51113be162346b27af5307caffe21ef88597ff15ab1569e07155302ff7b0af29f7f0431531004568da3849a5708176815a70f');

insert into tb_atendimento values
(0, 'Leve dor na pata frontal direita, possível corte.', '2020-08-06', 1, 1);

-- add foreign keys

ALTER TABLE tb_animal ADD CONSTRAINT FK_tb_animal_cliente
    FOREIGN KEY (fk_dono)
    REFERENCES tb_cliente (id_cliente)
    ON DELETE RESTRICT;
 
ALTER TABLE tb_animal ADD CONSTRAINT FK_tb_animal_tipo
    FOREIGN KEY (fk_tipo)
    REFERENCES tb_tipo (id_tipo)
    ON DELETE RESTRICT;
 
ALTER TABLE tb_animal ADD CONSTRAINT FK_tb_animal_raca
    FOREIGN KEY (fk_raca)
    REFERENCES tb_raca (id_raca)
    ON DELETE RESTRICT;
 
ALTER TABLE tb_raca ADD CONSTRAINT FK_tb_raca_tipo
    FOREIGN KEY (fk_tipo)
    REFERENCES tb_tipo (id_tipo)
    ON DELETE RESTRICT;
 
ALTER TABLE tb_atendimento ADD CONSTRAINT FK_tb_atendimento_funcionario
    FOREIGN KEY (fk_funcionario)
    REFERENCES tb_funcionario (id_funcionario)
    ON DELETE RESTRICT;
 
ALTER TABLE tb_atendimento ADD CONSTRAINT FK_tb_atendimento_animal
    FOREIGN KEY (fk_animal)
    REFERENCES tb_animal (id_animal)
    ON DELETE RESTRICT;
	
-- procedures

DELIMITER $$

-- manipulação de animal

CREATE PROCEDURE `getAnimalById` (IN `pId_Animal` INT)  NO SQL
BEGIN
	SELECT * from tb_animal
    WHERE id_animal = pId_animal;
END$$

CREATE PROCEDURE `getAnimaisByIdDono` (IN `pId_Dono` INT)  NO SQL
BEGIN
	SELECT * from tb_animal
    WHERE fk_dono = pId_Dono;
END$$

CREATE PROCEDURE `getAllAnimals` ()  NO SQL
BEGIN
	SELECT * from tb_animal;
END$$

CREATE PROCEDURE `getAnimalByFilter` (IN `filtro` VARCHAR(50))  NO SQL
BEGIN
	SELECT * from tb_animal
    WHERE (id_animal LIKE CONCAT('%',filtro,'%') OR nome_animal LIKE CONCAT('%',filtro,'%') OR fk_dono LIKE CONCAT('%',filtro,'%'));
END

CREATE PROCEDURE `getAnimalAtivoByFilter` (IN `filtro` VARCHAR(50))  NO SQL
BEGIN
	SELECT * from tb_animal
    WHERE (id_animal LIKE CONCAT('%',filtro,'%') OR nome_animal LIKE CONCAT('%',filtro,'%') OR fk_dono LIKE CONCAT('%',filtro,'%'));
END$$

CREATE PROCEDURE `setAnimal` (IN `pId_animal` INT, IN `pNome_animal` VARCHAR(100), IN pImage BLOB, IN pNascimento DATE, IN pFk_dono INT, IN pFk_tipo INT, IN pFk_raca INT)  NO SQL
BEGIN
	INSERT INTO tb_animal(id_animal, nome_animal, image, nascimento, fk_dono, fk_tipo, fk_raca)
    VALUES(pId_animal, pNome_animal, pImage, pNascimento, pFk_dono, pFk_tipo, pFk_raca);
END$$

CREATE PROCEDURE `updatePictureAnimal` (IN pId_Animal INT, IN pImage BLOB)  NO SQL
BEGIN
	UPDATE tb_animal
	SET image = pImage
    WHERE id_animal = pId_Animal;
END$$

--manipulação de raca

CREATE PROCEDURE `getRacaById` (IN `pId_Raca` INT)  NO SQL
BEGIN
	SELECT * from tb_raca
    WHERE id_raca = pId_Raca;
END$$

CREATE PROCEDURE `getAllRacas` ()  NO SQL
BEGIN
	SELECT * from tb_raca;
END$$

CREATE PROCEDURE `getRacasByTipo` (IN `pFk_Tipo` INT)  NO SQL
BEGIN
	SELECT * from tb_raca
    WHERE fk_tipo = pFk_Tipo;
END$$

CREATE PROCEDURE `getRacaByFilter` (IN `pFk_Tipo` INT, IN `filtro` VARCHAR(50))  NO SQL
BEGIN
	SELECT * from tb_raca
    WHERE (nome_raca LIKE CONCAT('%',filtro,'%') OR id_raca LIKE CONCAT('%',filtro,'%')) AND fk_tipo = pFk_Tipo;
END$$

CREATE PROCEDURE `setRaca` (IN `pId_Raca` INT, IN `pNome_Raca` VARCHAR(100), IN `pFk_Tipo` INT)  NO SQL
BEGIN
	INSERT INTO tb_raca(id_raca, nome_raca, fk_tipo)
    VALUES(pId_Raca, pNome_Raca, pFk_Tipo);
END$$

-- manipulação de tipo

CREATE PROCEDURE `getTipoById` (IN `pId_Tipo` INT)  NO SQL
BEGIN
	SELECT * from tb_tipo
    WHERE id_tipo = pId_Tipo;
END$$

CREATE PROCEDURE `getAllTipos` ()  NO SQL
BEGIN
	SELECT * from tb_tipo;
END$$

CREATE PROCEDURE `getTipoByFilter` (IN `filtro` VARCHAR(50))  NO SQL
BEGIN
	SELECT * from tb_tipo
    WHERE (nome_tipo LIKE CONCAT('%',filtro,'%') OR id_tipo LIKE CONCAT('%',filtro,'%'));
END$$

CREATE PROCEDURE `setTipo` (IN `pId_Tipo` INT, IN `pNome_Tipo` VARCHAR(100))  NO SQL
BEGIN
	INSERT INTO tb_tipo(id_tipo, nome_tipo)
    VALUES(pId_Tipo, pNome_Tipo);
END$$

-- manipulação de cliente

CREATE PROCEDURE `getClienteById` (IN `pId_Cliente` INT)  NO SQL
BEGIN
	SELECT * from tb_cliente
    WHERE id_cliente = pId_cliente;
END$$

CREATE PROCEDURE `getClienteByFilter` (IN `filtro` VARCHAR(50))  NO SQL
BEGIN
	SELECT * from tb_cliente
    WHERE (id_cliente LIKE CONCAT('%',filtro,'%') OR nome_cliente LIKE CONCAT('%',filtro,'%') OR celular_cliente LIKE CONCAT('%',filtro,'%') OR cidade_estado LIKE CONCAT('%',filtro,'%'));
END$$

CREATE PROCEDURE `getClienteAtivoByFilter` (IN `filtro` VARCHAR(50))  NO SQL
BEGIN
	SELECT * from tb_cliente
    WHERE (id_cliente LIKE CONCAT('%',filtro,'%') OR nome_cliente LIKE CONCAT('%',filtro,'%') OR celular_cliente LIKE CONCAT('%',filtro,'%') OR cidade_estado LIKE CONCAT('%',filtro,'%')) AND ativo_cliente = 1;
END$$

CREATE PROCEDURE `getAllClientes` ()  NO SQL
BEGIN
	SELECT * from tb_cliente;
END$$

CREATE PROCEDURE `getAllClientesAtivos` ()  NO SQL
BEGIN
	SELECT * from tb_cliente
	WHERE ativo_cliente = 1;
END$$

CREATE PROCEDURE `setCliente` (IN `pId_Cliente` INT, IN `pAtivo_cliente` INT, IN `pNome_Cliente` VARCHAR(150), IN `pEndereco_cliente` VARCHAR(200), IN `pBairro_cliente` VARCHAR(50), IN `pCidade_estado` VARCHAR(50), IN `pCep` VARCHAR(30), IN `pTelefone_cliente` VARCHAR(20), IN `pCelular_cliente` VARCHAR(20))  NO SQL
BEGIN
	INSERT INTO tb_cliente(id_cliente, ativo_cliente, nome_cliente, endereco_cliente, bairro_cliente, cidade_estado, cep, telefone_cliente, celular_cliente)
    VALUES(pId_Cliente, pAtivo_cliente, pNome_Cliente, pEndereco_cliente, pBairro_cliente, pCidade_estado, pCep, pTelefone_cliente, pCelular_cliente);
END$$

CREATE PROCEDURE `updateCliente` (IN `pId_Cliente` INT, IN `pAtivo_cliente` INT, IN `pNome_Cliente` VARCHAR(150), IN `pEndereco_cliente` VARCHAR(200), IN `pBairro_cliente` VARCHAR(50), IN `pCidade_estado` VARCHAR(50), IN `pCep` VARCHAR(30), IN `pTelefone_cliente` VARCHAR(20), IN `pCelular_cliente` VARCHAR(20))  NO SQL
BEGIN
	UPDATE tb_cliente 
	SET ativo_cliente = pAtivo_cliente,
		nome_cliente = pNome_Cliente,
		endereco_cliente = pEndereco_cliente,
		bairro_cliente = pBairro_cliente,
		cidade_estado = pCidade_estado,
		cep = pCep,
		telefone_cliente = pTelefone_cliente,
		celular_cliente = pCelular_cliente
    WHERE id_cliente = pId_Cliente;
END$$

CREATE PROCEDURE `verificaClienteAtivo` (IN `pId_Cliente` INT)  NO SQL
BEGIN
	SET @ehativo:=-1;
	SELECT ativo_cliente
	INTO @ehativo
	FROM tb_cliente
	WHERE id_cliente = pId_Cliente;
    SELECT @ehativo;
END$$

-- manipulação de funcionário

CREATE PROCEDURE `getFuncionarioById` (IN `pId_Funcionario` INT)  NO SQL
BEGIN
	SELECT * FROM tb_funcionario
    WHERE id_funcionario = pId_Funcionario;
END$$

CREATE PROCEDURE `getAllFuncionarios` ()  NO SQL
BEGIN
	SELECT * FROM tb_funcionario;
END$$

CREATE PROCEDURE `getAllFuncionariosAtivos` ()  NO SQL
BEGIN
	SELECT * FROM tb_funcionario
	WHERE ativo_funcionario = 1;
END$$

CREATE PROCEDURE `getFuncionarioByFilter` (IN `filtro` VARCHAR(50))  NO SQL
BEGIN
	SELECT * FROM tb_funcionario
    WHERE (id_funcionario LIKE CONCAT('%',filtro,'%') OR nome_funcionario LIKE CONCAT('%',filtro,'%') OR login LIKE CONCAT('%',filtro,'%'));
END$$

CREATE PROCEDURE `getFuncionarioAtivoByFilter` (IN `filtro` VARCHAR(50))  NO SQL
BEGIN
	SELECT * FROM tb_funcionario
    WHERE (id_funcionario LIKE CONCAT('%',filtro,'%') OR nome_funcionario LIKE CONCAT('%',filtro,'%') OR login LIKE CONCAT('%',filtro,'%')) AND ativo_funcionario = 1;
END$$

CREATE PROCEDURE `setFuncionario` (IN `pId_Funcionario` INT, IN `pMaster_Id` TINYINT, IN `pAtivo_Funcionario` TINYINT, IN `pLogin` VARCHAR(50), IN `pNome_Funcionario` VARCHAR(150), IN `pSenha_Funcionario` VARCHAR(150))  NO SQL
BEGIN
	INSERT INTO tb_funcionario(id_funcionario, master_id, ativo_funcionario, login, nome_funcionario, senha_funcionario)
    VALUES(pId_Funcionario, pMaster_Id, pAtivo_Funcionario, pLogin, pNome_Funcionario, pSenha_Funcionario);
END$$

CREATE PROCEDURE `updateFuncionario` (IN `pId_Funcionario` INT, IN `pMaster_Id` TINYINT, IN `pAtivo_Funcionario` TINYINT, IN `pLogin` VARCHAR(50), IN `pNome_Funcionario` VARCHAR(150), IN `pSenha_Funcionario` VARCHAR(150))  NO SQL
BEGIN
	UPDATE tb_funcionario 
	SET master_id = pMaster_Id,
		ativo_funcionario = pAtivo_Funcionario,
		login = pLogin,
		nome_funcionario = pNome_Funcionario,
		senha_funcionario = pSenha_Funcionario
    WHERE id_funcionario = pId_Funcionario;
END$$

CREATE PROCEDURE `autenticarFuncionario` (IN `pLogin_Funcionario` VARCHAR(50), IN `pSenha_Funcionario` VARCHAR(150))
BEGIN
	SELECT * FROM tb_funcionario 
	WHERE login = pLogin_Funcionario AND senha_funcionario = pSenha_Funcionario;
END$$

-- manipulação de atendimento

CREATE PROCEDURE `getAtendimentoById` (IN `pId_Atendimento` INT)  NO SQL
BEGIN
	SELECT * from tb_atendimento
    WHERE id_atendimento = pId_Atendimento;
END$$

CREATE PROCEDURE `getAllAtendimentos` ()  NO SQL
BEGIN
	SELECT * from tb_atendimento atendimento
	LEFT JOIN tb_animal animal
	ON atendimento.fk_animal = animal.id_animal
	LEFT JOIN tb_funcionario funcionario
	ON atendimento.fk_funcionario = funcionario.id_funcionario;
END$$

CREATE PROCEDURE `setAtendimento` (IN `pId_Atendimento` INT, IN `pDescricao_atendimento` VARCHAR(250), IN `pData_Atendimento` DATE, IN `pFk_Funcionario` INT, IN `pFk_animal` INT)  NO SQL
BEGIN
	INSERT INTO tb_atendimento(id_atendimento, descricao_atendimento, data_atendimento, fk_funcionario, fk_animal)
    VALUES(pId_Atendimento, pDescricao_atendimento, pData_Atendimento, pFk_Funcionario, pFk_animal);
END$$

CREATE PROCEDURE `getAtendimentosByFilter` (IN `filtro` VARCHAR(50))  NO SQL
BEGIN
	SELECT *
	FROM tb_atendimento atendimento
	LEFT JOIN tb_animal animal
	ON atendimento.fk_animal = animal.id_animal
	LEFT JOIN tb_funcionario funcionario
	ON atendimento.fk_funcionario = funcionario.id_funcionario
	WHERE (id_atendimento LIKE CONCAT('%',filtro,'%') 
		OR descricao_atendimento LIKE CONCAT('%',filtro,'%') 
		OR data_atendimento LIKE CONCAT('%',filtro,'%')
		OR nome_funcionario LIKE CONCAT('%',filtro,'%')
		OR nome_animal LIKE CONCAT('%',filtro,'%'));
END$$

DELIMITER ;