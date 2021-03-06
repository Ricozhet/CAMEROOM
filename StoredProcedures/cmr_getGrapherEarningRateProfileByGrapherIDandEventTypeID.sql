USE [CAMEROOM]
GO
/****** Object:  StoredProcedure [dbo].[cmr_getGrapherEarningRateProfileByGrapherIDandEventTypeID]    Script Date: 8/6/2556 15:17:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		A
-- Create date: 08/June/2013 13:20
-- =============================================
ALTER PROCEDURE [dbo].[cmr_getGrapherEarningRateProfileByGrapherIDandEventTypeID]
(
@GRAPHERID bigint,
@EVENTTYPEID int
)
AS
BEGIN
	SET NOCOUNT ON;

    SELECT MORNINGRATE,AFTERNOONRATE,EVENINGRATE,FULLDAYRATE
  FROM [CAMEROOM].[dbo].[TBL_EARNINGRATE] as a JOIN  [CAMEROOM].[dbo].[TBL_GRAPHER] as b
  ON a.GRAPHERID = b.GRAPHERID
  WHERE a.GRAPHERID = @GRAPHERID AND a.EVENTTYPEID = @EVENTTYPEID
END
