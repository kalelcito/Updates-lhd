/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [idTrama]
      ,[Trama]
      ,[Fecha]
      ,[idUser]
      ,[RFCEMI]
      ,[tipo]
      ,[observaciones]
      ,[Estab]
      ,[PtoEmi]
      ,[Secuencial]
      ,[serie]
      ,[folio]
      ,[noReserva]
      ,[RFCRECEPTOR]
      ,[nombreArchivo]
      ,[noTicket]
  FROM [IpsofactuMxEmision_Prueba].[dbo].[Log_Trama]

  select * from Log_Trama where Trama LIKE 'T%'

  select * from Log_Trama where observaciones='ExtranetOK'

  select * from Log_Trama where Fecha>='2018-04-26 09:54:41.000'

  UPDATE Log_Trama SET observaciones='',tipo=2 WHERE idTrama=22731