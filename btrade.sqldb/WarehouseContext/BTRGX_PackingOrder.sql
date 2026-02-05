CREATE TABLE [dbo].[BTRGX_PackingOrder]
(
	PackingOrderId VARCHAR(26) NOT NULL CONSTRAINT DF_BTRGX_PackingOrder_PackingOrderId DEFAULT (''),
	PackingOrderDate DATETIME NOT NULL CONSTRAINT DF_BTRGX_PackingOrder_PackingOrderDate DEFAULT ('3000-01-01'),

	CustomerId VARCHAR(26) NOT NULL CONSTRAINT DF_BTRGX_PackingOrder_CustomerId DEFAULT (''),
	CustomerCode VARCHAR(10) NOT NULL CONSTRAINT DF_BTRGX_PackingOrder_CustomerCode DEFAULT (''),
	CustomerName VARCHAR(100) NOT NULL CONSTRAINT DF_BTRGX_PackingOrder_CustomerName DEFAULT (''),
	Alamat VARCHAR(200) NOT NULL CONSTRAINT DF_BTRGX_PackingOrder_AlamatKirim DEFAULT (''),
	NoTelp VARCHAR(20) NOT NULL CONSTRAINT DF_BTRGX_PackingOrder_NoTelp DEFAULT (''),
	Latitude DECIMAL(18, 15) NOT NULL CONSTRAINT DF_BTRGX_PackingOrder_Latitude DEFAULT (0),
	Longitude DECIMAL(18, 15) NOT NULL CONSTRAINT DF_BTRGX_PackingOrder_Longitude DEFAULT (0),
	Accuracy INT NOT NULL CONSTRAINT DF_BTRGX_PackingOrder_Accuracy DEFAULT (0),

	FakturId VARCHAR(26) NOT NULL CONSTRAINT DF_BTRGX_PackingOrder_FakturId DEFAULT (''),
	FakturCode VARCHAR(26) NOT NULL CONSTRAINT DF_BTRGX_PackingOrder_FakturCode DEFAULT (''),
	FakturDate DATETIME NOT NULL CONSTRAINT DF_BTRGX_PackingOrder_FakturDate DEFAULT ('3000-01-01'),
	AdminName VARCHAR(100) NOT NULL CONSTRAINT DF_BTRGX_PackingOrder_AdminName DEFAULT (''),

	WarehouseCode VARCHAR(6) NOT NULL CONSTRAINT DF_BTRGX_PackingOrder_WarehouseCode DEFAULT (''),
	OfficeCode VARCHAR(6) NOT NULL CONSTRAINT DF_BTRGX_PackingOrder_OfficeCode DEFAULT (''),
	UpdateTimestamp DATETIME NOT NULL CONSTRAINT DF_BTRGX_PackingOrder_UpdateTimestamp DEFAULT ('3000-01-01'),
	DownloadTimestamp DATETIME NOT NULL CONSTRAINT DF_BTRGX_PackingOrder_DownloadTimestamp DEFAULT ('3000-01-01'),

	CONSTRAINT PK_BTRG_PackingOrder PRIMARY KEY CLUSTERED (PackingOrderId)
)
GO

CREATE INDEX IX_BTRGX_PackingOrder_UpdateTimestamp ON [dbo].[BTRGX_PackingOrder] (UpdateTimestamp, WarehouseCode, PackingOrderId)
GO

