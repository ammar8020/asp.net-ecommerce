CREATE TABLE [dbo].[Payment] (
[PaymentID] BIGINT IDENTITY (1, 1) NOT NULL,
[UserID] INT NULL,
[PID] NVARCHAR (MAX) NULL,
[CartTotal] FLOAT NULL,
[TotalPayed] MONEY NULL,
[PaymentType] NVARCHAR (50) NULL,
[PaymentStatus] NVARCHAR (50) NULL,
[DateOfPurchase] DATETIME NULL,
[Name] NVARCHAR (MAX) NULL,
[Address] NVARCHAR (MAX) NULL,
[MobileNumber] NVARCHAR (50) NULL,

PRIMARY KEY CLUSTERED ([PaymentID] ASC),
CONSTRAINT [FK_Payment_ToUsers] FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users] ([UserId])
);



CREATE PROCEDURE [dbo].[procAddProducts]
(
@PName nvarchar(MAX),
@PPrice money,
@PBrandID bigint,
@PCategoryID bigint,
@PShtDet nvarchar(MAX),
@PLongDet nvarchar(MAX),
@Quantity int
)
AS
insert into Products values(@PName,@PPrice,@PBrandID,@PCategoryID,
@PShtDet,@PLongDet,@Quantity)
select SCOPE_IDENTITY()
RETURN 0



CREATE PROCEDURE [dbo].[procDispAllProducts]

AS
select Products.*,ProductImages.*,Brands.Name
from Products
inner join Brands on Brands.BrandID=Products.PBrandID
cross apply(
select top 1 * from ProductImages where ProductImages.PID = Products.PID order by ProductImages.PID desc
) B
order by Products.pid desc
RETURN 0