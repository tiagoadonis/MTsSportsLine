-- Deleting zone
DROP PROCEDURE Projeto.Add_newStore;
DROP PROCEDURE Projeto.Add_storeProduct;
DROP PROCEDURE Projeto.Add_Warehouse;
DROP PROCEDURE Projeto.Add_warehouseProduct;
DROP PROCEDURE Projeto.Add_newClient;
DROP PROCEDURE Projeto.Remove_Store;
DROP PROCEDURE Projeto.Remove_storeProduct;
DROP PROCEDURE Projeto.Remove_Warehouse;
DROP PROCEDURE Projeto.Remove_WarehouseProduct;
DROP PROCEDURE Projeto.Remove_Client;

-- Adding Stored Procedures
GO
CREATE PROCEDURE Projeto.Add_newStore (@StoreNum INT, @Name VARCHAR(30), @Location VARCHAR(20)) 
AS
	INSERT Projeto.Loja (NumLoja, Nome, Localizacao) 
	VALUES (@StoreNum, @Name, @Location);
GO
--Test Procedure
EXEC Projeto.Add_newStore 4, 'M&T Sports Line - Guarda', 'Guarda';
----------------------------------------------------------
GO
CREATE PROCEDURE Projeto.Add_storeProduct (@Code INT, @Price DECIMAL(5,2), @Name VARCHAR(40), @Category VARCHAR(20), @StoreNum INT, @NumUnits INT) 
AS
	IF EXISTS (SELECT * FROM Projeto.Loja WHERE Loja.NumLoja=@StoreNum)
	BEGIN
		IF EXISTS (SELECT * FROM Projeto.Artigo_Loja WHERE Artigo_Loja.Codigo=@Code AND Artigo_Loja.NumLoja=@StoreNum)
		BEGIN
			DECLARE @Units INT;
			SELECT @Units=Artigo_Loja.QuantArtigos FROM Projeto.Artigo_Loja WHERE Artigo_Loja.Codigo=@Code AND Artigo_Loja.NumLoja=@StoreNum;
			UPDATE Projeto.Artigo_Loja SET QuantArtigos=@Units + @NumUnits WHERE Artigo_Loja.Codigo=@Code AND Artigo_Loja.NumLoja=@StoreNum;
		END
		ELSE
			IF EXISTS (SELECT * FROM Projeto.Artigo WHERE Artigo.Codigo=@Code)
			BEGIN
				INSERT Projeto.Artigo_Loja(Codigo, NumLoja, QuantArtigos) 
				VALUES (@Code, @StoreNum, @NumUnits);
			END
			ELSE
				INSERT Projeto.Artigo(Codigo, Preco, Nome, Categoria) 
				VALUES (@Code, @Price, @Name, @Category);
				INSERT Projeto.Artigo_Loja(Codigo, NumLoja, QuantArtigos) 
				VALUES (@Code, @StoreNum, @NumUnits);
	END
	ELSE
		RAISERROR ('The store number %d does not exists', 14, 1, @StoreNum);
GO
--Test Procedure
SELECT * FROM Projeto.Artigo;
SELECT * FROM Projeto.Artigo_Loja WHERE Artigo_Loja.NumLoja=1;
EXEC Projeto.Add_storeProduct 100001, 1.0, 'Meias curtas Reebok', 'Vestuário', 1, 1;
----------------------------------------------------------
GO
CREATE PROCEDURE Projeto.Add_Warehouse (@WarehouseID INT, @Storage INT, @StoreNum INT) 
AS
	IF EXISTS (SELECT * FROM Projeto.Loja WHERE Loja.NumLoja=@StoreNum)
	BEGIN
		INSERT Projeto.Armazem(IDArmazem, Capacidade, NumLoja) 
		VALUES (@WarehouseID, @Storage, @StoreNum);
	END
	ELSE
		RAISERROR ('The store number %d does not exists', 14, 1, @StoreNum);
GO
--Test Procedure
EXEC Projeto.Add_Warehouse 160, 100, 1; 
----------------------------------------------------------
GO
CREATE PROCEDURE Projeto.Add_warehouseProduct (@Code INT, @Price DECIMAL(5,2), @Name VARCHAR(40), @Category VARCHAR(20), @WarehouseID INT, @NumUnits INT) 
AS
	IF EXISTS (SELECT * FROM Projeto.Armazem WHERE Armazem.IDArmazem=@WarehouseID)
	BEGIN
		IF EXISTS (SELECT * FROM Projeto.Artigo_Armazem WHERE Artigo_Armazem.Codigo=@Code AND Artigo_Armazem.IDArmazem=@WarehouseID)
		BEGIN
			DECLARE @Units INT;
			SELECT @Units=Artigo_Armazem.QuantArtigos FROM Projeto.Artigo_Armazem WHERE Artigo_Armazem.Codigo=@Code 
													  AND Artigo_Armazem.IDArmazem=@WarehouseID;
			UPDATE Projeto.Artigo_Armazem SET QuantArtigos=@Units + @NumUnits WHERE Artigo_Armazem.Codigo=@Code 
													  AND Artigo_Armazem.IDArmazem=@WarehouseID;

		END
		ELSE
		IF EXISTS (SELECT * FROM Projeto.Artigo WHERE Artigo.Codigo=@Code)
		BEGIN
			INSERT Projeto.Artigo_Armazem(Codigo, IDArmazem, QuantArtigos) 
			VALUES (@Code, @WarehouseID, @NumUnits);
		END
		ELSE	
			INSERT Projeto.Artigo(Codigo, Preco, Nome, Categoria) 
			VALUES (@Code, @Price, @Name, @Category);
			INSERT Projeto.Artigo_Armazem(Codigo, IDArmazem, QuantArtigos) 
			VALUES (@Code, @WarehouseID, @NumUnits);
	END
	ELSE
		RAISERROR ('The warehouse number %d does not exists', 14, 1, @WarehouseID);
GO
--Test Procedure
SELECT * FROM Projeto.Artigo;
SELECT * FROM Projeto.Artigo_Armazem WHERE Artigo_Armazem.IDArmazem=110;
EXEC Projeto.Add_warehouseProduct 100002, 1.50, 'Touca natação Reebok', 'Acessório', 110, 1;
----------------------------------------------------------
GO
CREATE PROCEDURE Projeto.Add_newClient (@NIF INT, @Address VARCHAR(40), @Name VARCHAR(20), @Phone BIGINT) 
AS
	IF EXISTS (SELECT * FROM Projeto.Cliente WHERE Cliente.NIF=@NIF)
	BEGIN
		RAISERROR ('The client with NIF %d already exists', 14, 1, @NIF);
	END
	ELSE
		INSERT Projeto.Cliente (NIF, Morada, Nome, NumTelem)
		VALUES (@NIF, @Address, @Name, @Phone);
GO
--Test Procedure
EXEC Projeto.Add_newClient 100000000, 'Rua da Frente, Maia', 'Carlos Alberto', 911111111;

-- Removing Stored Procedures
GO
CREATE PROCEDURE Projeto.Remove_Store (@StoreNum INT) 
AS
	IF EXISTS (SELECT * FROM Projeto.Loja WHERE Loja.NumLoja=@StoreNum)
	BEGIN
		--Removing workers in @StoreNume store and dependencies
		DECLARE @WorkerID INT;
		SELECT @WorkerID = Funcionario.NumFunc FROM Projeto.Funcionario WHERE Funcionario.NumLoja=@StoreNum; 
		
		DECLARE @PurchaseID INT;
		DECLARE @ReturnID INT;
		SELECT @PurchaseID = Compra.NumCompra FROM Projeto.Compra WHERE Compra.NumFunc=@WorkerID;
		SELECT @ReturnID = Devolucao.IDDevolucao FROM Projeto.Devolucao WHERE Devolucao.NumFunc=@WorkerID;

		IF EXISTS(SELECT * FROM Projeto.Artigo_Comprado WHERE Artigo_Comprado.NumCompra=@PurchaseID)
		BEGIN
			DELETE FROM Projeto.Artigo_Comprado WHERE Artigo_Comprado.NumCompra=@PurchaseID;
		END
		IF EXISTS(SELECT * FROM Projeto.Artigo_Devolvido WHERE Artigo_Devolvido.IDDevolucao=@ReturnID)
		BEGIN
			DELETE FROM Projeto.Artigo_Devolvido WHERE Artigo_Devolvido.IDDevolucao=@ReturnID;
		END
		IF EXISTS(SELECT * FROM Projeto.Compra WHERE Compra.NumFunc=@WorkerID)
		BEGIN
			DELETE FROM Projeto.Compra WHERE Compra.NumFunc=@WorkerID;
		END
		IF EXISTS(SELECT * FROM Projeto.Devolucao WHERE Devolucao.NumFunc=@WorkerID)
		BEGIN
			DELETE FROM Projeto.Devolucao WHERE Devolucao.NumFunc=@WorkerID;
		END
		IF EXISTS(SELECT * FROM Projeto.Funcionario WHERE Funcionario.NumLoja=@StoreNum)
		BEGIN
			DELETE FROM Projeto.Funcionario WHERE Funcionario.NumLoja=@StoreNum;
		END

		--Removing store and dependencies
		DECLARE @Warehouse INT;
		SELECT @Warehouse = Armazem.IDArmazem FROM Projeto.Armazem WHERE Armazem.NumLoja=@StoreNum; 
		
		IF EXISTS(SELECT * FROM Projeto.Artigo_Armazem WHERE Artigo_Armazem.IDArmazem=@Warehouse)
		BEGIN
			DELETE FROM Projeto.Artigo_Armazem WHERE Artigo_Armazem.IDArmazem=@Warehouse;
		END
		IF EXISTS(SELECT * FROM Projeto.Armazem WHERE Armazem.NumLoja=@StoreNum)
		BEGIN
			DELETE FROM Projeto.Armazem WHERE Armazem.NumLoja=@StoreNum;
		END
		IF EXISTS(SELECT * FROM Projeto.Artigo_Loja WHERE Artigo_Loja.NumLoja=@StoreNum)
		BEGIN
			DELETE FROM Projeto.Artigo_Loja WHERE Artigo_Loja.NumLoja=@StoreNum;
		END
		DELETE FROM Projeto.Loja WHERE Loja.NumLoja=@StoreNum;
	END
	ELSE
		RAISERROR ('The store number %d does not exists', 14, 1, @StoreNum);
GO
--Test Procedure
EXEC Projeto.Remove_Store 4;
----------------------------------------------------------
GO
CREATE PROCEDURE Projeto.Remove_storeProduct (@StoreNum INT, @Code INT) 
AS
	IF EXISTS (SELECT * FROM Projeto.Artigo_Loja WHERE Artigo_Loja.NumLoja=@StoreNum AND Artigo_Loja.Codigo=@Code)
	BEGIN
		DELETE FROM Projeto.Artigo_Loja WHERE Artigo_Loja.NumLoja=@StoreNum AND Artigo_Loja.Codigo=@Code;
	END
	ELSE
		RAISERROR ('The product %d in the store number %d does not exists', 14, 1, @Code, @StoreNum);
GO
--Test Procedure
EXEC Projeto.Remove_storeProduct 1, 100001;	
----------------------------------------------------------
GO
CREATE PROCEDURE Projeto.Remove_Warehouse (@WarehouseID INT) 
AS
	IF EXISTS (SELECT * FROM Projeto.Armazem WHERE Armazem.IDArmazem=@WarehouseID)
	BEGIN
		--Removing warehouse dependencies
		DELETE FROM Projeto.Artigo_Armazem WHERE Artigo_Armazem.IDArmazem=@WarehouseID;
		--Removing Warehouse
		DELETE FROM Projeto.Armazem WHERE Armazem.IDArmazem=@WarehouseID;
	END
	ELSE
		RAISERROR ('The warehouse number %d does not exists', 14, 1, @WarehouseID);
GO
--Test Procedure
EXEC Projeto.Remove_Warehouse 160; 
----------------------------------------------------------
GO
CREATE PROCEDURE Projeto.Remove_WarehouseProduct (@WarehouseID INT, @Code INT) 
AS
	IF EXISTS (SELECT * FROM Projeto.Artigo_Armazem WHERE Artigo_Armazem.IDArmazem=@WarehouseID AND Artigo_Armazem.Codigo=@Code)
	BEGIN
		DELETE FROM Projeto.Artigo_Armazem WHERE Artigo_Armazem.IDArmazem=@WarehouseID AND Artigo_Armazem.Codigo=@Code;
	END
	ELSE
		RAISERROR ('The product %d in the warehouse number %d does not exists', 14, 1, @Code, @WarehouseID);
GO
--Test Procedure
EXEC Projeto.Remove_WarehouseProduct 110, 100002;
----------------------------------------------------------
GO
CREATE PROCEDURE Projeto.Remove_Client (@NIF BIGINT) 
AS
	IF EXISTS (SELECT * FROM Projeto.Cliente WHERE Cliente.NIF=@NIF)
	BEGIN
		IF EXISTS (SELECT * FROM Projeto.Compra WHERE Compra.NIF=@NIF)
		BEGIN
			DECLARE @PurchaseID INT;
			SELECT @PurchaseID = Compra.NumCompra FROM Projeto.Compra WHERE Compra.NIF=@NIF;
			DELETE FROM Projeto.Artigo_Comprado WHERE Artigo_Comprado.NumCompra=@PurchaseID;
			DELETE FROM Projeto.Compra WHERE Compra.NIF=@NIF;
		END
		IF EXISTS (SELECT * FROM Projeto.Devolucao WHERE Devolucao.NIF=@NIF)
		BEGIN
			DECLARE @ReturnID INT;
			SELECT @ReturnID = Devolucao.IDDevolucao FROM Projeto.Devolucao WHERE Devolucao.NIF=@NIF;
			DELETE FROM Projeto.Artigo_Devolvido WHERE Artigo_Devolvido.IDDevolucao=@ReturnID;
			DELETE FROM Projeto.Devolucao WHERE Devolucao.NIF=@NIF;
		END
		DELETE FROM Projeto.Cliente WHERE Cliente.NIF=@NIF;
	END
	ELSE
		RAISERROR ('The client with the NIF %d does not exists', 14, 1, @NIF);
GO
--Test Procedure
EXEC Projeto.Remove_Client 100000000;