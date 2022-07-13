/****** Script for SelectTopNRows command from SSMS  ******/
SELECT cust.PersonID,(cust.FirstName + ' ' +cust.LastName) as 'full name',cust.Age,
ord.OrderID, ord.DateCreated, ord.MethodofPurchase as 'Purchase Method' ,
cust.Occupation,cust.MartialStatus,orddet.ProductNumber, orddet.ProductOrigin
  FROM [TallerChallenge].[dbo].[Customer] cust
  INNER JOIN [dbo].[ORDERS] ord ON cust.PersonID = ord.PersonID
  INNER JOIN [dbo].[OrdersDetails] orddet ON ord.OrderID = orddet.OrderID
  WHERE orddet.ProductID = '1112222333'