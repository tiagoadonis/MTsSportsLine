--Deleting Zone
DROP TRIGGER Projeto.Complete_Sale;
DROP TRIGGER Projeto.Complete_Return;
--Creating Triggers
GO
CREATE TRIGGER Complete_Sale ON Projeto.Artigo_Comprado
AFTER INSERT
AS
	DECLARE @Code INT;
	DECLARE @PurchaseID INT;
	DECLARE @WorkerID INT;
	DECLARE @Store INT;
	DECLARE @Units INT;
	DECLARE @QuantStore INT; 
	SELECT @Code = Codigo FROM INSERTED;
	SELECT @PurchaseID = NumCompra FROM INSERTED;
	SELECT @Units = QuantArtigos FROM INSERTED;
	SELECT @WorkerID = NumFunc FROM Projeto.Compra WHERE Compra.NumCompra=@PurchaseID;
	SELECT @Store = NumLoja FROM Projeto.Funcionario WHERE Funcionario.NumFunc=@WorkerID; 
	SELECT @QuantStore = QuantArtigos FROM Projeto.Artigo_Loja WHERE Artigo_Loja.Codigo=@Code AND Artigo_Loja.NumLoja=@Store;
	IF (@Units > @QuantStore)
	BEGIN
		RAISERROR('Theres not enough units in the store to complete the purchase', 16, 1);
		ROLLBACK TRAN;
	END
	ELSE IF (@Units - @QuantStore = 0)
	BEGIN
		DELETE FROM Projeto.Artigo_Loja WHERE Artigo_Loja.Codigo=@Code;
	END
	ELSE
		UPDATE Projeto.Artigo_Loja SET QuantArtigos = @QuantStore - @Units WHERE Artigo_Loja.Codigo=@Code
																		     AND Artigo_Loja.NumLoja=@Store; 
GO
--Test Triggers
INSERT INTO Projeto.Artigo_Comprado(Codigo, NumCompra, QuantArtigos)
VALUES (103568, 39218, 11);
INSERT INTO Projeto.Compra(NumCompra, Data, Montante, NIF, NumFunc)
VALUES	(39218, '2020-05-01', 21.89, 438291045, 123091);
SELECT * FROM Projeto.Artigo_Comprado;
SELECT * FROM Projeto.Artigo_Loja;
-------------------------------------------------------------------
GO
CREATE TRIGGER Complete_Return ON Projeto.Artigo_Devolvido
AFTER INSERT
AS
	DECLARE @Code INT;
	DECLARE @ReturnID INT;
	DECLARE @WorkerID INT;
	DECLARE @Store INT;
	DECLARE @Units INT;
	DECLARE @QuantStore INT; 
	SELECT @Code = Codigo FROM INSERTED;
	SELECT @ReturnID = IDDevolucao FROM INSERTED;
	SELECT @Units = QuantArtigos FROM INSERTED;
	SELECT @WorkerID = NumFunc FROM Projeto.Devolucao WHERE Devolucao.IDDevolucao=@ReturnID;
	SELECT @Store = NumLoja FROM Projeto.Funcionario WHERE Funcionario.NumFunc=@WorkerID; 
	SELECT @QuantStore = QuantArtigos FROM Projeto.Artigo_Loja WHERE Artigo_Loja.Codigo=@Code AND Artigo_Loja.NumLoja=@Store;
	IF (@QuantStore =  0)
	BEGIN
		INSERT INTO Projeto.Artigo_Loja (Codigo, NumLoja, QuantArtigos)
		VALUES (@Code, @Store, @Units); 
	END
	ELSE 
		UPDATE Projeto.Artigo_Loja SET QuantArtigos = @QuantStore + @Units WHERE Artigo_Loja.Codigo=@Code
																		     AND Artigo_Loja.NumLoja=@Store; 
GO
--Test Triggers
INSERT INTO Projeto.Artigo_Devolvido(Codigo, IDDevolucao, QuantArtigos)
VALUES (826096, 30064, 1);
SELECT * FROM Projeto.Artigo_Devolvido;
SELECT * FROM Projeto.Artigo_Loja WHERE Artigo_Loja.NumLoja=1;
SELECT * FROM Projeto.Devolucao;
INSERT INTO Projeto.Devolucao(IDDevolucao, Data, Montante, NIF, NumFunc)
VALUES (30064, '2020-05-02', 29.99, 438291045, 139901);