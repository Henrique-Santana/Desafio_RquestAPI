USE TestBrq;
GO

INSERT INTO Endereco(Cep, Endereco, Cidade, Estado, Numero, Complemento)
VALUES ('15810400', 'Rua Estados Unidos', 'Catanduva', 'S�o Paulo', '78', 'Bloco AB'),
	   ('14079038', 'Rua Moreira da Silva', 'Ribeir�o Preto', 'S�o Paulo', '12', 'Rua sem saida'),
	   ('12214000', 'Avenida Pico das Agulhas Negras', 'S�o Jos� dos Campos', 'S�o Paulo', '100', 'Em frete a pra�a')
GO

SELECT * FROM Endereco;

INSERT INTO DadosPessoais(Nome, Sobrenome, CPF, DataNascimento, IdEndereco)
VALUES ('Henrique', 'Barreiro', '12345678910', '2001-12-07', 1),
	   ('Wesley', 'Borges', '10987654321', '2000-05-12', 2),
	   ('Felyppe', 'Witt', '12131415161', '1998-11-10', 3)
GO

SELECT * FROM DadosPessoais;