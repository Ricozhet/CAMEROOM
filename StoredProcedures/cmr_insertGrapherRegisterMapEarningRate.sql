USE [CAMEROOM]
GO
/****** Object:  StoredProcedure [dbo].[cmr_insertGrapherRegisterMapEarningRate]    Script Date: 8/6/2556 14:31:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sutatpan Vi.
-- Create date: 6/June/2013 21:36
-- =============================================

ALTER PROCEDURE [dbo].[cmr_insertGrapherRegisterMapEarningRate]
@GRAPHERID bigint,
@EVENTTYPEID int,
@MORNINGRATE money,
@AFTERNOONRATE money,
@EVENINGRATE money,
@FULLDAYRATE money
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[TBL_EARNINGRATE] ([GRAPHERID],[EVENTTYPEID],[MORNINGRATE],[AFTERNOONRATE],[EVENINGRATE],[FULLDAYRATE])
	VALUES (@GRAPHERID,@EVENTTYPEID,@MORNINGRATE,@AFTERNOONRATE,@EVENINGRATE,@FULLDAYRATE)

END
