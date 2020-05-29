--Deleting Zone
DROP FUNCTION Projeto.PurchasedProductsPerClient;
DROP FUNCTION Projeto.ReturnedProductsPerClient;

--UDF'S
GO
CREATE FUNCTION Projeto.PurchasedProductsPerClient(@NIF BIGINT) RETURNS @PurchasedProducts TABLE
												  (Number INT, Product_Name VARCHAR(40), NºUnits INT, Date DATE, Purchase_Price DECIMAL(5,2))
AS
BEGIN
	INSERT @PurchasedProducts SELECT Compra.NumCompra AS Number, Artigo.Nome AS Product_Name, 
							  Artigo_Comprado.QuantArtigos AS NºUnits, Compra.Data AS Date, Compra.Montante AS Purchase_Price  
							  FROM (((Projeto.Artigo_Comprado JOIN Projeto.Compra ON Artigo_Comprado.NumCompra=Compra.NumCompra) 
							  JOIN Projeto.Cliente ON Compra.NIF=Cliente.NIF) JOIN Projeto.Artigo ON 
							  Artigo_Comprado.Codigo=Artigo.Codigo)
							  WHERE Cliente.NIF = @NIF
	RETURN;
END
GO
--Test Function
SELECT * FROM Projeto.PurchasedProductsPerClient(123456789);
--------------------------------------------------------------------------------------------
GO
CREATE FUNCTION Projeto.ReturnedProductsPerClient(@NIF BIGINT) RETURNS @ReturnedProducts TABLE
												  (Number INT, Product_Name VARCHAR(40), NºUnits INT, Date DATE, Returned_Value DECIMAL(5,2))
AS
BEGIN
	INSERT @ReturnedProducts SELECT Devolucao.IDDevolucao AS Number, Artigo.Nome AS Product_Name, 
						     Artigo_Devolvido.QuantArtigos AS NºUnits, Devolucao.Data AS Date, Devolucao.Montante AS Returned_Value
							 FROM (((Projeto.Artigo_Devolvido JOIN Projeto.Devolucao ON 
							 Artigo_Devolvido.IDDevolucao=Devolucao.IDDevolucao) JOIN Projeto.Artigo ON 
							 Artigo.Codigo=Artigo_Devolvido.Codigo) JOIN Projeto.Cliente ON Cliente.NIF=Devolucao.NIF)
							 WHERE Cliente.NIF = @NIF
	RETURN;
END
GO
--Test Function
SELECT * FROM Projeto.ReturnedProductsPerClient(123456789);
--------------------------------------------------------------------------------------------