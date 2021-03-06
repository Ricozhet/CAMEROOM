USE [CAMEROOM]
GO
/****** Object:  StoredProcedure [dbo].[cmr_getGrapherProfileByGrapherID]    Script Date: 8/6/2556 15:25:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		A
-- Create date: 08/June/2013 10:50
-- =============================================
ALTER PROCEDURE [dbo].[cmr_getGrapherProfileByGrapherID]
(@GRAPHERID bigint)
AS
BEGIN

	SET NOCOUNT ON;

  SELECT GRAPHEREMAIL,NAME,SURNAME,PERSONALID,TELEPHONENUMBER,SEX,PROVINCEID
  FROM [CAMEROOM].[dbo].[TBL_GRAPHER] as a JOIN [CAMEROOM].[dbo].[TBL_MAPPROVINCE] as b ON a.GRAPHERID = b.GRAPHERID
  WHERE a.GRAPHERID = @GRAPHERID
END
