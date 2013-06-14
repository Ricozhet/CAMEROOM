USE [CAMEROOM]
GO
/****** Object:  StoredProcedure [dbo].[cmr_getGrapherProfileByEmail]    Script Date: 08/06/2013 14:56:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Aim
-- Create date: 08/June/2013 14:58
-- =============================================
-- exec cmr_getGrapherPhotoByID '35'
CREATE PROCEDURE [dbo].[cmr_getGrapherPhotoByID]
(@grapherID int)
AS
BEGIN

	SET NOCOUNT ON;

  SELECT [PHOTO]
  FROM [dbo].[TBL_GRAPHER]
  WHERE [GRAPHERID] = @grapherID
END
