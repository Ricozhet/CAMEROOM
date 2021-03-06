USE [CAMEROOM]
GO
/****** Object:  StoredProcedure [dbo].[cmr_insertGrapherRegister]    Script Date: 07/06/2013 20:04:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sutatpan Vi.
-- Create date: 20/Apr/2013 16:14
-- =============================================

ALTER PROCEDURE [dbo].[cmr_insertGrapherRegister]
@GRAPHEREMAIL varchar(100),
@NAME nvarchar(50),
@SURNAME nvarchar(50),
@PERSONALID char(13),
@TELEPHONENUMBER varchar(30),
@SEX char(1),
@PASSWORD nvarchar(250),
@PROVINCEID  int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @GRAPHERID bigint

    -- Insert statements for procedure here
	INSERT INTO [dbo].[TBL_GRAPHER] ([GRAPHEREMAIL],[NAME],[SURNAME],[PERSONALID],[TELEPHONENUMBER],[SEX],[GRAPHERLEVEL],[STATUS],[PASSWORD],
	[CREATEDDATE])
	VALUES (@GRAPHEREMAIL,@NAME,@SURNAME,@PERSONALID,@TELEPHONENUMBER,@SEX,'1','1',@PASSWORD,GETDATE())

	SELECT @GRAPHERID = @@IDENTITY
	INSERT INTO [dbo].[TBL_MAPPROVINCE] ([GRAPHERID],[PROVINCEID])
	VALUES (@GrapherID, @PROVINCEID)

END
